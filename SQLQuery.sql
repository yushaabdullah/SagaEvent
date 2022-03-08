CREATE DATABASE sagaevent
GO

USE sagaevent
GO


CREATE TABLE ADMIN
(
adminID int IDENTITY(1,1) PRIMARY KEY,
adminEmail varchar(100) NOT NULL,
adminPassword varchar(200) NOT NULL,
)



CREATE TABLE USERS
(
userId int IDENTITY(1,1) PRIMARY KEY,
userEmail varchar(100) NOT NULL,
userPassword varchar(200) NOT NULL,
userFullName varchar(200) NOT NULL,
userAddresss varchar(500) NOT NULL,
userPhone varchar(11) NOT NULL,
)




CREATE TABLE EVENTS
(
eventId int IDENTITY(1,1) PRIMARY KEY,
eventName varchar(100) NOT NULL,
eventType varchar(100) NOT NULL,
eventDescription varchar(500) NOT NULL,
eventPreparationTime varchar(100) NOT NULL,
eventPrice varchar(100) NOT NULL,
eventPhoto varchar(500) NOT NULL,
eventRating float NULL,
)





CREATE TABLE FOODS
(
foodId int IDENTITY(1,1) PRIMARY KEY,
foodName varchar(100) NOT NULL,
foodDescription varchar(500) NOT NULL,
foodPrice varchar(100) NOT NULL,
foodPhoto varchar(500) NOT NULL,
)


CREATE TABLE ORDERS
(
orderId int IDENTITY(1,1) PRIMARY KEY,
orderStatus varchar(50) NOT NULL,
paymentStatus varchar(50) NOT NULL,
guestNumber int NOT NULL,
eventDate date NOT NULL,
eventId int NOT NULL FOREIGN KEY REFERENCES EVENTS (eventId),
foodId int NOT NULL FOREIGN KEY REFERENCES FOODS (foodId),
userId int NOT NULL FOREIGN KEY REFERENCES USERS (userId),
eventPlace varchar(500) NOT NULL,
)



Insert into ADMIN VALUES ('admin@gmail.com','123456')


Insert into EVENTS (eventName,eventType,eventDescription, eventPreparationTime,eventPrice,eventPhoto) values (@eventName,@eventType,@eventDescription, @eventPreparationTime,@eventPrice,@eventPhoto)


update [dbo].[EVENTS] set eventName=@eventName ,eventType =@eventType ,eventDescription = @eventDescription , eventPreparationTime =@eventPreparationTime,eventPrice=@eventPrice,eventPhoto=@eventPhoto where eventName=@eventName 