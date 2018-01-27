CREATE TABLE [dbo].[StockMovimiento] (
    [id]             BIGINT          NOT NULL,
    [idStock]        BIGINT          NOT NULL,
    [fecha]          DATETIME        NOT NULL,
    [cantidad]       INT             NOT NULL,
    [precioUnitario] DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_StockMovimiento] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StockMovimiento_Stock] FOREIGN KEY ([idStock]) REFERENCES [dbo].[Stock] ([id])
);

