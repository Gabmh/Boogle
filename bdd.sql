
-- ************************************** [usuario]

CREATE TABLE [usuario]
(
 [usuario_id] int NOT NULL ,
 [apodo]      varchar(50) NOT NULL ,
 [password]   varchar(50) NOT NULL ,
 [confirmpassword]   varchar(50) NOT NULL ,
 [mail]       varchar(50) NOT NULL ,
 [fecha_nac]  date NOT NULL ,
 [rol]        int ,
 [fecha_alta] date ,


 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([usuario_id] ASC)
);
GO

-- ************************************** [autor]

CREATE TABLE [autor]
(
 [id_autor]  int NOT NULL ,
 [nombre]    varchar(50) NOT NULL ,
 [apellido]  varchar(50) NOT NULL ,
 [fecha_nac] date NOT NULL ,


 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED ([id_autor] ASC)
);
GO

-- ************************************** [editor]

CREATE TABLE [editor]
(
 [id_editor] int NOT NULL ,
 [nombre]    varchar(50) NOT NULL ,
 [pais]      varchar(50) NOT NULL ,
 [url]       varchar(100) NOT NULL ,


 CONSTRAINT [PK_editor] PRIMARY KEY CLUSTERED ([id_editor] ASC)
);
GO

-- ************************************** [libro]

CREATE TABLE [libro]
(
 [libro_id]  int NOT NULL ,
 [titulo]    varchar(50) NOT NULL ,
 [idioma]    varchar(50) NOT NULL ,
 [cant_pag]  smallint NOT NULL ,
 [generos]   varchar(500) NOT NULL ,
 [isbn]      varchar(50) NOT NULL ,
 [url]       varchar(500) NOT NULL ,
 [imagen]    varbinary(max) NOT NULL ,
 [eliminado] tinyint NOT NULL ,
 [id_autor]  int NOT NULL ,
 [id_editor] int NOT NULL ,


 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED ([libro_id] ASC),
 CONSTRAINT [autor_libro_FK] FOREIGN KEY ([id_autor])  REFERENCES [autor]([id_autor]),
 CONSTRAINT [editor_libro_FK] FOREIGN KEY ([id_editor])  REFERENCES [editor]([id_editor])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_56] ON [libro] 
 (
  [id_autor] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_66] ON [libro] 
 (
  [id_editor] ASC
 )

GO

-- ************************************** [usuario_libro]

CREATE TABLE [usuario_libro]
(
 [usuario_id] int NOT NULL ,
 [libro_id]   int NOT NULL ,


 CONSTRAINT [PK_LibroVisto] PRIMARY KEY CLUSTERED ([usuario_id] ASC, [libro_id] ASC),
 CONSTRAINT [libro_usuario_libro_FK] FOREIGN KEY ([libro_id])  REFERENCES [libro]([libro_id]),
 CONSTRAINT [usuario_usuario_libro_FK] FOREIGN KEY ([usuario_id])  REFERENCES [usuario]([usuario_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_44] ON [usuario_libro] 
 (
  [usuario_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_47] ON [usuario_libro] 
 (
  [libro_id] ASC
 )

GO