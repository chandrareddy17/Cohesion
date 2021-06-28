using Microsoft.EntityFrameworkCore.Migrations;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsTermsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInvitationCodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    InvitationCode = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvitationCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserInvitationCodes_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInvitationCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsTermsAccepted", "Password", "UserName" },
                values: new object[] { 1, false, "silkyfinch", "david.smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsTermsAccepted", "Password", "UserName" },
                values: new object[] { 2, false, "Ack777!", "john.welbourne" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsTermsAccepted", "Password", "UserName" },
                values: new object[] { 3, false, "paraclete12!", "micheal.page" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceID", "DeviceName", "UserId" },
                values: new object[,]
                {
                    { 10000000002L, "Lenovo Laptop", 1 },
                    { 10000000003L, "iPad", 2 },
                    { 10000000004L, "iPhone", 2 },
                    { 10000000005L, "Samsung", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvitationCodes_DeviceId",
                table: "UserInvitationCodes",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvitationCodes_UserId",
                table: "UserInvitationCodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInvitationCodes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
