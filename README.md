# Тестовое задание для Mindbox

## Вопрос №1
Разместите код на Github и приложите ссылку. Если в задании что-то непонятно, опишите возникшие вопросы и сделанные предположения. Например, в комментариях в коде.
### Задание:
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам (__Директория Area в репозитории__). Дополнительно к работоспособности оценим:
- Юнит-тесты - **в директрии Area.Tests**
- Легкость добавления других фигур - __для добавления новой фигуры необходимо реализовать интерфейс `IFigure` и наследоваться от класса `Figure`__
- Вычисление площади фигуры без знания типа фигуры в compile-time - __не до конца понятно что имеется в виду, попытка реализовать данный пункт - метод `AutoDetectArea()` родительского класса `Figure`__
- Проверку на то, является ли треугольник прямоугольным - __свойство `IsRectangular` класса `Rectangle`__

## Вопрос №2
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

<details>
  <summary>Код создания таблиц</summary>
  
  
  __Судя во всему в данном случае имеем связь многие ко многим__
  
  Примерная структура базы данных могла бы выглядеть следующим образом:
  
  ```sql
 create table Product
(
	ProductId int primary key,
	ProductName nvarchar(64) not null
);

insert into Product(ProductId, ProductName) values (1, 'bread');
insert into Product(ProductId, ProductName) values (2, 'coffe');
insert into Product(ProductId, ProductName) values (3, 'apple');
insert into Product(ProductId, ProductName) values (4, 'tomato');
insert into Product(ProductId, ProductName) values (5, 'bear');
insert into Product(ProductId, ProductName) values (6, 'pepper');

create table Category
(
	CategoryId int primary key,
	CategoryName nvarchar(32) not null
);

insert into Category(CategoryId, CategoryName) values (1, 'drink');
insert into Category(CategoryId, CategoryName) values (2, 'fruit');
insert into Category(CategoryId, CategoryName) values (3, 'perishable');
insert into Category(CategoryId, CategoryName) values (4, 'long-term storage');
insert into Category(CategoryId, CategoryName) values (5, 'vegetables');

create table ProductCategory
(
	ProductId int foreign key references Product,
	CategoryId int foreign key references Category
	primary key(ProductId, CategoryId)
);

insert into ProductCategory(ProductId, CategoryId) values (2, 1);
insert into ProductCategory(ProductId, CategoryId) values (2, 4);
insert into ProductCategory(ProductId, CategoryId) values (3, 2);
insert into ProductCategory(ProductId, CategoryId) values (3, 3);
insert into ProductCategory(ProductId, CategoryId) values (4, 3);
insert into ProductCategory(ProductId, CategoryId) values (4, 5);
insert into ProductCategory(ProductId, CategoryId) values (5, 1);
  ```
  
</details>

> SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

__Это можно сделать с помощью следующего запроса:__
```sql
select Product.ProductName,
       Category.CategoryName
from Product
left join ProductCategory ON Product.ProductId = ProductCategory.ProductId
left join Category ON Category.CategoryId = ProductCategory.CategoryId;
```
