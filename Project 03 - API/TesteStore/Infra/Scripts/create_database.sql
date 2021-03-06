CREATE DATABASE TESTESTORE;
use TESTESTORE;


CREATE TABLE Customer
(
	Id char(36)  PRIMARY KEY NOT NULL,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	Document CHAR(11) NOT NULL,
	Email VARCHAR(160) NOT NULL,
	Phone VARCHAR(13) NOT NULL
);

CREATE TABLE Address
(
	Id char(36)  PRIMARY KEY NOT NULL,
	CustomerId char(36) NOT NULL,
	Number VARCHAR(10) NOT NULL,
	Complement VARCHAR(40) NOT NULL,
	District VARCHAR(60) NOT NULL,
	City VARCHAR(60) NOT NULL,
	State CHAR(2) NOT NULL,
	Country CHAR(2) NOT NULL,
	ZipCode CHAR(8) NOT NULL,
	Type char(36) NOT NULL DEFAULT 1,
	FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);


CREATE TABLE Product
(
	Id char(36) PRIMARY KEY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	Description TEXT NOT NULL,
	Image VARCHAR(1024) NOT NULL,
	Price DECIMAL(19, 2) NOT NULL,
	QuantityOnHand DECIMAL(10, 2) NOT NULL
);

CREATE TABLE OrderTb
(
	Id char(36) PRIMARY KEY NOT NULL,
	CustomerId char(36)  NOT NULL,
	CreateDate DATETIME NOT NULL DEFAULT now(),
	Status char(36) NOT NULL DEFAULT 1,
	FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE OrderItem (
	Id char(36) PRIMARY KEY NOT NULL,
	OrderId char(36)  NOT NULL,
	ProductId char(36)  NOT NULL,
	Quantity DECIMAL(10, 2) NOT NULL,
	Price DECIMAL(19, 2) NOT NULL,
	FOREIGN KEY(OrderId) REFERENCES OrderTb(Id),
	FOREIGN KEY(ProductId) REFERENCES Product(Id)
);

CREATE TABLE Delivery (
	Id char(36) PRIMARY KEY NOT NULL,
	OrderId char(36)  NOT NULL,
	CreateDate DATETIME NOT NULL DEFAULT now(),
	EstimatedDeliveryDate  DATETIME NOT NULL,
	Status char(36) NOT NULL DEFAULT 1,
	FOREIGN KEY(OrderId) REFERENCES OrderTb(Id)
);
