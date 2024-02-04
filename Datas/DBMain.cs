using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eshop2.Models;
using System.Security.Principal;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;

namespace Eshop2.Datas
{
    public class DBMain : DbContext
    {
        private readonly IEncryptionProvider encryption;
        public DBMain()
        {
            // it should be 16 charecters which is 128 bites 
            encryption = new GenerateEncryptionProvider("Test1234567890_+");
        }
        public DbSet<Account> Accounts{get; set;}
        public DbSet<Buy> Buys{get; set;}
        public DbSet<Comment> Comments{get; set;}
        public DbSet<DetailsBuy> DetailsBuys{get; set;}
        public DbSet<Others> Others{get; set;}
        public DbSet<Product> Products{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SqlServer2019;Database=eShop;Trusted_Connection=True;TrustServerCertificate=True",
             sql=>sql.UseNetTopologySuite());  // we add `UseNetTopologySuite` beacause we want use special data (x, y) geography

            // SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            // sql.DataSource = ".\\SqlServer2019";
            // sql.InitialCatalog = "eShop";
            // sql.IntegratedSecurity = true;
            // sql.TrustServerCertificate = true;
            // optionsBuilder.UseSqlServer(sql.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(encryption);
            var asm = typeof(Program).Assembly;  // for aadding all changes in Mapping files to database 
            modelBuilder.ApplyConfigurationsFromAssembly(asm);
        }
    }
}
