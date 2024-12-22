# Спроектируйте и создайте структуру базы данных для виртуального магазина, следуя этому плану:

## Таблица "Products" (Продукты):
* ProductID (Основной ключ)
* ProductName (Название продукта)
* Description (Описание)
* Price (Цена)
* QuantityInStock (Количество на складе)


## Таблица "Users" (Пользователи):
* UserID (Основной ключ)
* UserName (Имя пользователя)
* Email (Электронная почта)
* RegistrationDate (Дата регистрации)


## Таблица "Orders" (Заказы):
* OrderID (Основной ключ)
* UserID (Внешний ключ)
* OrderDate (Дата заказа)
* Status (Статус)


## Таблица "OrderDetails" (Детали заказа):
* OrderDetailID (Основной ключ)
* OrderID (Внешний ключ)
* ProductID (Внешний ключ)
* Quantity (Количество)
* TotalCost (Общая стоимость)


## Установление связей:
* Связь между "Users" и "Orders"
* Связь между "Orders" и "OrderDetails"
* Связь между "Products" и "OrderDetails"


## SQL запросы:
* Добавление нового продукта
* Обновление цены продукта
* Выбор всех заказов определенного пользователя
* Расчет общей стоимости заказа
* Подсчет количества товаров на складе
* Получение 5 самых дорогих товаров
* Список товаров с низким запасом (менее 5 штук)


[!alt](https://github.com/IlyaGall/c_Sharp__Developer_Professional/blob/main/ProfHomeWork1/IMG/%D0%94%D0%B8%D0%B0%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0%20%D0%B1%D0%B5%D0%B7%20%D0%BD%D0%B0%D0%B7%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F.drawio.png)
