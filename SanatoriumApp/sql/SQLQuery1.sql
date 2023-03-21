USE Olymp_XX
GO

INSERT INTO [dbo].[PaymentMethods]
           ([Title])
     VALUES
           ('Наличные'),
		   ('Безналичные'),
		   ('МИР')
GO

INSERT INTO [dbo].[SanatoriumRoomCategories]
           ([Title],[Coefficient])
     VALUES
           ('Стандартный',1),
		   ('Премиум',1.2),
		   ('Люкс',1.5)
GO

INSERT INTO [dbo].[SanatoriumRooms]
           ([RoomSize],[QuantityOfSeats],[QuantityOfRooms],[RoomAmenities],[RoomWindow],[Description],[Status],[Cost],[SanatoriumRoomCategoryId])
     VALUES
           (10,4,2,'не указаны','не указан','отсутсвует',0,1500,1),
		   (15,6,2,'не указаны','не указан','отсутсвует',1,2000,2),
		   (30,15,3,'не указаны','не указан','отсутсвует',0,3000,3)
GO

INSERT INTO [dbo].[SanatoriumPrograms]
           ([Title]
           ,[QuantityOfProcedures]
           ,[MinQuantityDays]
           ,[Description]
           ,[Cost])
     VALUES
           ('Стандартная',4,5,'Отсутсвует',1000),
		   ('Расширенная',8,9,'Отсутсвует',2000)
GO






