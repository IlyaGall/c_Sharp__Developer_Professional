using Microsoft.EntityFrameworkCore;
using ProfHomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1
{
    internal class Requst
    {
        /*
            Добавление нового продукта
            Обновление цены продукта
            Выбор всех заказов определенного пользователя
            Расчет общей стоимости заказа
            Подсчет количества товаров на складе
            Получение 5 самых дорогих товаров
            Список товаров с низким запасом (менее 5 штук)
         */
        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="productName">Название продукта</param>
        /// <param name="description">Описание продукта</param>
        /// <param name="prive">Цена продукта</param>
        /// <param name="quantityInStock">Колличество продукта</param>
        /// <returns></returns>
        public async Task SetNewProduct(string productName, string description, double prive, double quantityInStock)
        {

            //ToDO: спросить лучше передовать объект типа Product или параметры в метод, а внутри формировать сам объект?
            using (Context db = new Context())
            {
                Product product = new Product { ProductName = productName, Description = description, Price = prive, QuantityInStock = quantityInStock };
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Обновление продукта
        /// </summary>
        /// <param name="productUpgrate">Экземпляр продукта</param>
        /// <returns></returns>
        public async Task SetNewPriceProduct(Product productUpgrate)
        {
            using (Context db = new Context())
            {
                Product productSerch = await db.Products.FindAsync(productUpgrate.ProductID);
                if (productSerch != null)
                {
                    productSerch.Price = productUpgrate.Price;
                    await db.SaveChangesAsync();
                }
            }

        }
        /// <summary>
        /// Выбор всех заказов определенного пользователя
        /// </summary>
        /// <param name="productSerch"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetProduct(User userSerchProduct)
        {
            using (Context db = new Context())
            {
                return await db.Orders
                        .Where(o => o.UserID == userSerchProduct.UserID)
                        .ToListAsync();

            }
        }

        /// <summary>
        /// Расчет общей стоимости заказа
        /// </summary>
        /// <param name="userSerchProduct"></param>
        /// <returns></returns>
        public async Task<double> GetTotalOrderCost(Order orderId)
        {
            using (Context db = new Context())
            {
                //int orderId = 1;/* ваш OrderID, по которому нужно посчитать сумму */;

                return await db.OrderDetails
                            .Where(e => e.OrderID.OrderID == orderId.OrderID)
                            .SumAsync(e => e.TotalCost);
            }
        }

        /// <summary>
        ///  Подсчет количества товаров на складе
        /// </summary>
        /// <returns></returns>
        public async Task<double> GetProductsInStock()
        {
            using (Context db = new Context())
            {
                return await db.Products
                            .SumAsync(e => e.QuantityInStock);
            }
        }
        /// <summary>
        /// Получение 5 самых дорогих товаров
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetTheMostExpensiveProducts()
        {
            using (Context db = new Context())
            {
                return await db.Products.
                    OrderByDescending(p => p.Price)
                                          .Take(5)
                                          .ToListAsync(); 
            }
        }

        /// <summary>
        /// Список товаров с низким запасом (менее 5 штук)
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetListOfProductsWithLowStock()
        {
            using (Context db = new Context())
            {
                return await db.Products.
                    OrderBy(p => p.QuantityInStock)
                                          .Take(5)
                                          .ToListAsync();
            }
        }

    }
}
