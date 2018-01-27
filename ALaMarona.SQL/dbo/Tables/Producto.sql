CREATE TABLE [dbo].[Producto] (
    [id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Codigo]      NCHAR (30)    NOT NULL,
    [Descripcion] VARCHAR (150) NULL,
    [Talle]       INT           NULL,
    [idColor]     INT           NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Producto_Color] FOREIGN KEY ([idColor]) REFERENCES [dbo].[Color] ([id]),
	CONSTRAINT UK_CODIGO_PRODUCTO UNIQUE(CODIGO)
);

