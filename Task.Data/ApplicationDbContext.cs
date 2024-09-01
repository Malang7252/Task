using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Task.Models.Entities;

namespace Task.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Client>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Client>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            // Seed Roles
            var userRoleId = "c3129a50-6964-4e12-bff9-9ae3eb32c692";
            var adminRoleId = "5bd1711f-38cc-47ce-960b-242d82b86a18";

            var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = userRoleId,
                ConcurrencyStamp = userRoleId,
                Name = "User",
                NormalizedName = "USER",
            },
            new IdentityRole
            {
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
            }
        };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Clients
            var clientId1 = Guid.NewGuid();
            var clientId2 = Guid.NewGuid();

            var clients = new List<Client>
        {
            new Client
            {
                Id = clientId1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PersonalId = "12345678901",
                MobileNumber = "+11234567890",
                Sex = "Male",
                ProfilePhoto = "john_doe_profile.jpg" , // Add ProfilePhoto

            },
            new Client
            {
                Id = clientId2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PersonalId = "10987654321",
                MobileNumber = "+19876543210",
                Sex = "Female",
                ProfilePhoto = "jane_smith_profile.jpg"  // Add ProfilePhoto

            }
        };
            builder.Entity<Client>().HasData(clients);

            // Seed Addresses
            var addresses = new List<Address>
        {
            new Address
            {
                Id = Guid.NewGuid(),
                Country = "USA",
                City = "New York",
                Street = "123 Main St",
                ZipCode = "10001",
                ClientId = clientId1
            },
            new Address
            {
                Id = Guid.NewGuid(),
                Country = "Canada",
                City = "Toronto",
                Street = "456 Maple Ave",
                ZipCode = "M5V 2T6",
                ClientId = clientId2
            }
        };
            builder.Entity<Address>().HasData(addresses);

            // Seed Accounts
            var accounts = new List<Account>
        {
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "1234567890",
                Balance = 1000m,
                ClientId = clientId1
            },
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "0987654321",
                Balance = 500m,
                ClientId = clientId2
            }
        };
            builder.Entity<Account>().HasData(accounts);
        }

    }
}
