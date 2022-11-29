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

#

<details>
  <summary>Код создания таблиц</summary>
  
  *Судя во всему в данном случае имеем связь многие ко многим*
  
  Примерная структура базы данных могла бы выглядеть следующим образом:
  
  ```sql
	CREATE TABLE Product
	(
		ProductId int PRIMARY KEY,
		ProductName nvarchar(64) NOT NULL
	);

	INSERT INTO Product(ProductId, ProductName) VALUES (1, 'bread');
	INSERT INTO Product(ProductId, ProductName) VALUES (2, 'coffe');
	INSERT INTO Product(ProductId, ProductName) VALUES (3, 'apple');
	INSERT INTO Product(ProductId, ProductName) VALUES (4, 'tomato');
	INSERT INTO Product(ProductId, ProductName) VALUES (5, 'bear');
	INSERT INTO Product(ProductId, ProductName) VALUES (6, 'pepper');


	CREATE TABLE Category 
	(
		CategoryId int PRIMARY KEY,
		CategoryName nvarchar(32) NOT NULL
	);

	INSERT INTO Category(CategoryId, CategoryName) VALUES (1, 'drink');
	INSERT INTO Category(CategoryId, CategoryName) VALUES (2, 'fruit');
	INSERT INTO Category(CategoryId, CategoryName) VALUES (3, 'perishable');
	INSERT INTO Category(CategoryId, CategoryName) VALUES (4, 'long-term storage');
	INSERT INTO Category(CategoryId, CategoryName) VALUES (5, 'vegetables');


	CREATE TABLE ProductCategory 
	(
		ProductId int FOREIGN KEY REFERENCES Product,
		CategoryId int FOREIGN KEY REFERENCES Category 
		PRIMARY key(ProductId, CategoryId)
	);

	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (2, 1);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (2, 4);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (3, 2);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (3, 3);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (4, 3);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (4, 5);
	INSERT INTO ProductCategory(ProductId, CategoryId) VALUES (5, 1);
  ```
  
</details>

##

> SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

__Это можно сделать с помощью следующего запроса:__
```sql
SELECT Product.ProductName,
       Category.CategoryName
FROM Product
LEFT JOIN ProductCategory ON Product.ProductId = ProductCategory.ProductId
LEFT JOIN Category ON Category.CategoryId = ProductCategory.CategoryId;
```
