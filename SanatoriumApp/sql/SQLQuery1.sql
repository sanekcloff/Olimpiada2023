USE Olymp_XX
GO

INSERT INTO [dbo].[PaymentMethods]
           ([Title])
     VALUES
           ('��������'),
		   ('�����������'),
		   ('���')
GO

INSERT INTO [dbo].[SanatoriumRoomCategories]
           ([Title],[Coefficient])
     VALUES
           ('�����������',1),
		   ('�������',1.2),
		   ('����',1.5)
GO

INSERT INTO [dbo].[SanatoriumRooms]
           ([RoomSize],[QuantityOfSeats],[QuantityOfRooms],[RoomAmenities],[RoomWindow],[Description],[Status],[Cost],[SanatoriumRoomCategoryId])
     VALUES
           (10,4,2,'�� �������','�� ������','����������',0,1500,1),
		   (15,6,2,'�� �������','�� ������','����������',1,2000,2),
		   (30,15,3,'�� �������','�� ������','����������',0,3000,3)
GO

INSERT INTO [dbo].[SanatoriumPrograms]
           ([Title]
           ,[QuantityOfProcedures]
           ,[MinQuantityDays]
           ,[Description]
           ,[Cost])
     VALUES
           ('�����������',4,5,'����������',1000),
		   ('�����������',8,9,'����������',2000)
GO






