using CohesionIB.ApiEnginner.CodeChallenge.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions
            <MyContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<UserInvitationCode> UserInvitationCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "david.smith",
                    Password = "silkyfinch",
                    IsTermsAccepted = false
                },
                new User
                {
                    UserId = 2,
                    UserName = "john.welbourne",
                    Password = "Ack777!",
                    IsTermsAccepted = false
                }, 
                new User
                {
                    UserId = 3,
                    UserName = "micheal.page",
                    Password = "paraclete12!",
                    IsTermsAccepted = false
                }
              );

            modelBuilder.Entity<Device>().HasData(
                new Device
                {
                    DeviceID = 10000000002,
                    DeviceName = "Lenovo Laptop",
                    UserId = 1
                },
                new Device
                {
                    DeviceID = 10000000003,
                    DeviceName = "iPad",
                    UserId = 2
                },
                new Device
                {
                    DeviceID = 10000000004,
                    DeviceName = "iPhone",
                    UserId = 2
                },
                new Device
                {
                    DeviceID = 10000000005,
                    DeviceName = "Samsung",
                    UserId = 2
                }
                );

        }
    }
}
