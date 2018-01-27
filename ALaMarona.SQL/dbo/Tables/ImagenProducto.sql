CREATE TABLE [dbo].[ImagenProducto] (
    [id]         BIGINT          NOT NULL IDENTITY,
    [idProducto] BIGINT          NOT NULL,
    [imagen]     VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_ImagenProducto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ImagenProducto_Producto] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Producto] ([id])
) TEXTIMAGE_ON [imagenesProductos];

