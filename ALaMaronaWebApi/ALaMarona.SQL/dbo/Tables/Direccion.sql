CREATE TABLE [dbo].[Direccion]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Calle] VARCHAR(250) NOT NULL, 
    [Piso] NCHAR(3) NULL, 
    [Departamento] NCHAR(3) NULL, 
    [CodigoPostal] VARCHAR(10) NOT NULL, 
    [IdPais] INT NOT NULL, 
    [IdProvincia] INT NOT NULL, 
    [IdLocalidad] INT NULL, 
    [Altura] INT NULL, 
    CONSTRAINT [FK_Direccion_Pais] FOREIGN KEY ([IdPais]) REFERENCES [Pais]([Id]),
	CONSTRAINT [FK_Direccion_Provincia] FOREIGN KEY ([IdProvincia]) REFERENCES [Provincia]([Id]),
	CONSTRAINT [FK_Direccion_Localidad] FOREIGN KEY ([IdLocalidad]) REFERENCES [Localidad]([Id])
)
