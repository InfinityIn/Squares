--Предполагаю, что связь Many-To-Many реализована с помощью третьей таблицы, тогда:

CREATE TABLE Products(
    Id int NOT NULL,
    Name nchar[100] NOT NULL,    
    PRIMARY KEY (Id)
);

CREATE TABLE Categories(
    Id int NOT NULL,
    Name nchar[100] NOT NULL,    
    PRIMARY KEY (Id)
);

CREATE TABLE ProductCategories(
    ProductId int NOT NULL,
    CategoryId int NOT NULL,    
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)	    
);

    

SELECT s1.Name, s3.Name
FROM Products s1 
LEFT JOIN ProductCategories s2 ON s1.Id = s2.ProductId
INNER JOIN Categories s3 ON s2.CategoryId = s3.Id