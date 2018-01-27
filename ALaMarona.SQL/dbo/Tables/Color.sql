CREATE TABLE [dbo].[Color] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [codigoHexa]   NCHAR (6)     NULL,
    [Descripcion] VARCHAR (100) NULL,
    [Nombre] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UK_COLOR_HEXA] UNIQUE([codigoHexa]),
	CONSTRAINT [UK_NOMBRE] UNIQUE(Nombre)
);

