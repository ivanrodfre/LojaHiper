USE [LojaHiper]
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Superman', CAST(90.00 AS Decimal(18, 2)), 100)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476427e', N'Caneca Superman ', CAST(50.00 AS Decimal(18, 2)), 100)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27b4bb', N'Camiseta Batman', CAST(75.00 AS Decimal(18, 2)), 150)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27c4bb', N'Camiseta Homem Aranha', CAST(80.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'52dd696b-0882-4a73-9525-6af55dd416a4', N'Caneca Homem Aranha', CAST(20.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'191ddd3e-acd4-4c3b-ae74-8e473993c5da', N'Caneca Homem Aranha', CAST(15.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'fc184e11-014c-4978-aa10-9eb5e1af369b', N'Camiseta Homem Aranha', CAST(100.00 AS Decimal(18, 2)), 9)
INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [Estoque]) VALUES (N'20e08cd4-2402-4e76-a3c9-a026185b193d', N'Caneca Deadpool', CAST(20.00 AS Decimal(18, 2)), 3)

select * from Produtos