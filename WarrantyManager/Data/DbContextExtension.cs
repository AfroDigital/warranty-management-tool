using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using WarrantyManager.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WarrantyManager.Data
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this WarrantyManagementDbContext _context, bool seed)
        {
            _context.Database.SetCommandTimeout(900);

            if (seed)
            {
                ClearDatabase(_context);
                SeedDatabase(_context);

            }


        }


        public static void ClearDatabase(WarrantyManagementDbContext _context)
        {

            var warranties = _context.CustomerWarranties.Any();
            var customers = _context.Customers.Any();
            var distributors = _context.Distributors.Any();


            if (warranties)
            {
                _context.RemoveRange(_context.CustomerWarranties);
            }

            if (customers)
            {
                _context.RemoveRange(_context.Customers);
            }

            if (distributors)
            {
                _context.RemoveRange(_context.Distributors);
            }


        }






        public static void SeedDatabase(WarrantyManagementDbContext _context)
        {



            var customers = new List<Customer>()
            {
                new Customer { Name= "Petrov Kovalovsky" },
                new Customer { Name= "Paul Pot" },
                new Customer { Name= "Najibulla Nasreddin"  },
                new Customer { Name= "Richard Holbroke"  },
                new Customer { Name= "August Fontamanti" },
                new Customer { Name= "Bom Trady" },
                new Customer { Name= "Bantonio Rown"  },
                new Customer { Name= "Joe Bayou Burrows" },
                new Customer { Name= "Mo Salah" },
                new Customer { Name= "Sadio Mane"}

            };

            _context.Customers.AddRange(customers);
            _context.SaveChanges();


            var distributors = new List<Distributor>()
            {
                new Distributor {  Name= "ShineBot Gadgets", Customers = new int[] { 0, 2 }.Select(i => customers[i]).ToList()  },
                new Distributor {  Name= "East India Electronics", Customers = new int[] { 3, 5 }.Select(i => customers[i]).ToList()  },
                new Distributor {  Name= "Gadgets For Africa" , Customers = new int[] { 6, 3 }.Select(i => customers[i]).ToList() }
            };

            _context.Distributors.AddRange(distributors);
            _context.SaveChanges();



            string[] products = new string[] { "ShortWave Transistor Radio", "20 BTU Air Conditioner", "Blueetooth Portable Speaker", "240 Volt Air Fryer" };

            var customerWarranties = new List<Warranty>();

            foreach (var customer in customers)
            {
                foreach (var product in products)
                {
                    customerWarranties.Add(new Warranty { CustomerId = customer.Id, ProductName = product, PurchaseDate = GeneratePurchaseDate(), SerialNumber = GenerateSerialNumber() });
                }
            }

            _context.CustomerWarranties.AddRange(customerWarranties);
            _context.SaveChanges();



        }


        private static string GenerateSerialNumber()
        {
            return "REM" + Guid.NewGuid().ToString().Substring(0, 5);
        }

        private static DateTime GeneratePurchaseDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2021, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}
