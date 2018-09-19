CREATE TABLE [dbo].[Persona]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [PrimerNombre] NVARCHAR(50) NULL,
	[SegundoNombre] NVARCHAR(50) NULL,
	[Apellido] NVARCHAR(100) NULL,
	[Alias] NVARCHAR(30) NULL,
	[Telefono] NVARCHAR(25) NULL,
	[TipoDocumento] NVARCHAR(4) NULL,
	[NumeroDocumento] BIGINT NULL, 
    [FechaNacimiento] DATETIME NULL, 
    [IdDomicilio] INT NULL, 
    [IdLugarNacimiento] INT NULL, 
    [EstadoCivil] NVARCHAR(30) NULL, 
    [PersonType] NVARCHAR(50) NOT NULL, 
    [EMail] NVARCHAR(250) NULL, 
    [Codigo] NVARCHAR(8) NULL, 
    CONSTRAINT [FK_Persona_Domicilio] FOREIGN KEY ([IdDomicilio]) REFERENCES [Direccion]([Id]),
	CONSTRAINT [FK_Persona_LugarNacimiento] FOREIGN KEY ([IdLugarNacimiento]) REFERENCES [Direccion]([Id]),
	CONSTRAINT [UK_PERSONA_DOCUMENTO] UNIQUE(TipoDocumento, NumeroDocumento),
	CONSTRAINT [UK_PERSONA_CODIGO] UNIQUE(Codigo)
)
