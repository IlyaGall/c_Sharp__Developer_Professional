using ProfHomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1
{
    /// <summary>
    /// Класс для добовления тестовых данных
    /// </summary>
    internal class AddTestingData
    {
        public AddTestingData()
        {
            // добавление данных
            using (Context db = new Context())
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


                // создаем два объекта User
                User user1 = new User { UserName = "Tom", Email = "ad@d.com", RegistrationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) };
                User user2 = new User { UserName = "Alice", Email = "ru", RegistrationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) };
                // добавляем их в бд
                db.Users.AddRange(user1, user2);

                // создаем 3 объекта order
                Order order = new Order { Status = "false", OrderDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), UserID = 1, User = user1 };
                Order order2 = new Order { Status = "Ok", OrderDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), UserID = 1, User = user1 };
                Order order3 = new Order { Status = "Ok", OrderDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), UserID = 2, User = user2 };
                db.Orders.AddRange(order, order2, order3);

                // создаем два объекта product
                Product product = new Product { ProductName = "Конфета", Description = "Конфеть - испорченная", Price = 1000, QuantityInStock = 20 };
                Product product1 = new Product { ProductName = "Банан", Description = "Банан - зелённый", Price = 200, QuantityInStock = 201 };
                Product product2 = new Product { ProductName = "Макароны", Description = "***", Price = 57, QuantityInStock = 2 };
                Product product3 = new Product { ProductName = "Абрикос", Description = "1 абрикос", Price = 70, QuantityInStock = 1000 };
                Product product4 = new Product { ProductName = "Белый порошок", Description = "Предположительно для стирки", Price = 12000, QuantityInStock = 12 };
                // добавляем их в бд
                db.Products.AddRange(product, product1, product2, product3, product4);

                OrderDetail orderD = new OrderDetail { Quantity = 2, TotalCost = 121 , OrderID = order };
                OrderDetail orderD_ = new OrderDetail { Quantity = 2, TotalCost = 111114, OrderID = order };

                OrderDetail orderD2 = new OrderDetail { Quantity = 3, TotalCost = 1000, OrderID = order2 };
                OrderDetail orderD3 = new OrderDetail { Quantity = 1, TotalCost = 230, OrderID = order3 };
                db.OrderDetails.AddRange(orderD, orderD_, orderD2, orderD3);


                db.SaveChanges();


            }
        }
    }
}
