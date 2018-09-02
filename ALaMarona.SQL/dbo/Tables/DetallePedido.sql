CREATE TABLE [dbo].[DetallePedido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [IdProducto] BIGINT NOT NULL, 
    [Precio] DECIMAL(19, 4) NOT NULL, 
    [Cantidad] INT NOT NULL, 
    [IdPedido] BIGINT NOT NULL,
	[IdMovimientoStock] BIGINT NULL, 
    CONSTRAINT FK_DetallePedido_Pedido FOREIGN KEY([IdPedido]) REFERENCES Pedido(Id)
)
