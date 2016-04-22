SET IDENTITY_INSERT [dbo].[Manager] ON;
INSERT INTO [Manager](ManagerId, Name, Surname) 
VALUES
(1, 'Anton', 'Antonov'),
(2, 'Borus', 'Borusov'),
(3, 'Ivan', 'Ivanov');
SET IDENTITY_INSERT [dbo].[Manager] OFF;

SET IDENTITY_INSERT [dbo].[Order] ON;
INSERT INTO [Order](OrderId, Number, CreationDate, ShipmentDate, Note, ManagerId)
VALUES
(1, 'Number1', GETDATE(), NULL, NULL, 1),
(2, 'Number2', GETDATE(), NULL, NULL, 1),
(3, 'Number3', GETDATE(), NULL, NULL, 2),
(4, 'Number4', GETDATE(), NULL, NULL, 3),
(5, 'Number5', GETDATE(), NULL, NULL, 3);
SET IDENTITY_INSERT [dbo].[Order] ON;

SELECT * FROM [Manager]