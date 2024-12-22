using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProfHomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1
{
    public class Context : DbContext
    {
        /// <summary>
        /// Удаление БД
        /// </summary>
        public void DeletedBD()
        {
            Database.EnsureDeleted();
        }

        /// <summary>
        /// Новая Бд
        /// </summary>
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            //.HasColumnName("random");
            //тут задём через билдер новое свойство для таблицы, делаем не через []

     

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
