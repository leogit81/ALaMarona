CREATE TABLE [dbo].[Stock] (
    [id]         BIGINT NOT NULL,
    [idProducto] BIGINT NOT NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Stock_Producto] FOREIGN KEY ([idProducto]) REFERENCES [dbo].[Producto] ([id])
);

