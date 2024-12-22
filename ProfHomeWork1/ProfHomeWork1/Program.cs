
using Microsoft.EntityFrameworkCore;
using ProfHomeWork1.Models;
using System.ComponentModel.DataAnnotations;

namespace ProfHomeWork1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (Context db = new Context()) 
            {
                db.DeletedBD();
            }
            AddTestingData addTestingData = new AddTestingData();

            Requst requst = new Requst();
            await requst.SetNewProduct("Мясо кролика", "Не только ценный мех, но и вкусное мясо", 599.99, 293);
            await requst.SetNewPriceProduct(new Product() { ProductID = 6, Price = 1111 });
            
            // получение данных
            using (Context db = new Context())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Users list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.UserID}.{u.UserName} - {u.Email} {u.RegistrationDate}");
                }
            }
            using (Context db = new Context())
            {
                // получаем объекты из бд и выводим на консоль
                var products = db.Products.ToList();
                Console.WriteLine("Product list:");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.ProductID}.{p.ProductName} - {p.Description} {p.Price} {p.QuantityInStock}");
                }
            }

            Console.WriteLine($"\nВыбор всех заказов определенного пользователя");

            foreach (var itemProduct in await requst.GetProduct(new User() { UserID = 1 }))
            {
                Console.WriteLine($"{itemProduct.UserID} - {itemProduct.OrderID}");
            }

           Console.WriteLine( $"\nРасчёт общей стоимости заказа c id = 1 {await requst.GetTotalOrderCost(new Order() { OrderID = 1 })}");
           Console.WriteLine($"\nКоличество товара на складе: {await requst.GetProductsInStock()}");
           Console.WriteLine($"\nсамые 5-ть дорогих продуктов:");
            foreach (var itemProduct in await requst.GetTheMostExpensiveProducts()) 
            {
                  Console.WriteLine($"{itemProduct.ProductName} -> {itemProduct.Price}");
            }
            Console.WriteLine($"\n5-ть продуктов, которых меньше всего :");
            foreach (var itemProduct in await requst.GetListOfProductsWithLowStock())
            {
                Console.WriteLine($"{itemProduct.ProductName} -> {itemProduct.QuantityInStock}");
            }
        }
    }
}
