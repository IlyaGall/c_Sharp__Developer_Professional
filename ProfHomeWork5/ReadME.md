# Объяснение реализации по принципам SOLID

1. Принцип единственной ответственности (Single Responsibility Principle):

Каждый класс в проектах имеет одну четко определенную ответственность. `Game` отвечает за логику игры, `Settings` за хранение параметров игры, а `Program` только за запуск приложения.

2. Принцип инверсии зависимостей (Dependency Inversion Principle):

В класс `Game` передается интерфейс `ISettings`, а не конкретный класс настроек. Это позволяет легко заменять реализации и проводить тестирование.

3. Принцип разделения интерфейса (Interface Segregation Principle):

Интерфейсы `IGame` и `ISettings` содержат только необходимые методы и свойства, не навязывая ненужные зависимости.

4. Принцип открытости/закрытости (Open/Closed Principle):

Классы могут быть расширены (например, можно создать новый класс, который реализует интерфейс `IGame` с изменёнными правилами), но изменять существующий код не нужно.

5. Принцип подстановки Барбары Лисков (Liskov Substitution Principle):

Имеется возможность заменить реализацию интерфейса `ISettings` без изменения кода, который использует этот интерфейс (например, можно создать другой класс настроек, не нарушая работу игры).

6. CodeStyle:

Код написан с соблюдением стандартов чистоты кода: используются понятные имена переменных и методов, соблюдены отступы, и структура кода логична и читаема.

## Время выполнения задачи

На реализацию данной задачи ушло около 12 часов. Много времени ушло на осознания "Принцип подстановки Барбары Лисков (Liskov Substitution Principle)"
