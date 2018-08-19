CREATE TABLE [dbo].[MovimientoStock] (
    [id]             BIGINT          IDENTITY(1,1) NOT NULL,
    [idProducto]        BIGINT          NOT NULL,
    [fecha]          DATETIME        NOT NULL,
    [cantidad]       INT             NOT NULL,
    [precioCompra] DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_MovimientoStock] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StockMovimiento_Producto] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Producto] ([id])
);

