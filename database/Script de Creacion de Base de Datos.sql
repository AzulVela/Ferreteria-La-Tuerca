create database tp_latuerca;
go

USE [Tp_LaTuerca]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodCliente] [int] NOT NULL identity,
	[Apellido] [varchar](20) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Telefono] [varchar](30) NULL,
	[CUIT] [varchar](15) NULL,
	[Habilitado] [bit] Default 1,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Factura]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Factura](
	[IdDetalleFactura] [int] NOT NULL,
	[NroFactura] [int] NOT NULL,
	[CodTipoFactura] [int] NOT NULL,
	[CodProducto] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [float] NULL,
 CONSTRAINT [PK_Detalle_Factura] PRIMARY KEY CLUSTERED 
 
(
	[NroFactura] ASC,
	[CodTipoFactura] ASC,
	[IdDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estructura]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estructura](
	[IdPSuperior] [int] NOT NULL,
	[IdPInferior] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Habilitado] [bit] Default 1,
 CONSTRAINT [PK_Estructura] PRIMARY KEY CLUSTERED 
(
	[IdPSuperior] ASC,
	[IdPInferior] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[NroFactura] [int] NOT NULL identity,
	[CodTipoFactura] [int] NOT NULL,
	[CodCliente] [int] NOT NULL,
	[CodTipoDocV] [int] NOT NULL,
	[NroTipoDocV] [int] NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED
(
	[NroFactura] ASC,
	[CodTipoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[CodProducto] [int] NOT NULL identity,
	[Nombre] [varchar](20) NOT NULL,
	[Descripcion] [varchar](30) NULL,
	[CodTipoMedida] [int] NOT NULL,
	[Precio] [float] NOT NULL,
	[CodTipoUso] [int] NOT NULL,
	[CodProveedor] [int] NOT NULL,
	[Habilitado] [bit] default 1
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[CodProveedor] [int] NOT NULL identity,
	[Apellido] [varchar](20) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](30) NULL,
	[TiempoDeEntrega] [int] NULL,
	[Habilitado] [bit] Default 1,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[CodProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Doc]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Doc](
	[CodTipoDoc] [int] NOT NULL identity,
	[Nombre] [varchar](20) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Doc] PRIMARY KEY CLUSTERED 
(
	[CodTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Factura]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Factura](
	[CodTipoFactura] [int] NOT NULL identity,
	[Nombre] [varchar](20) NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Factura] PRIMARY KEY CLUSTERED 
(
	[CodTipoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Medida]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Medida](
	[CodTipoMedida] [int] NOT NULL identity,
	[Nombre] [varchar](30) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Medida] PRIMARY KEY CLUSTERED 
(
	[CodTipoMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Uso]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Uso](
	[CodTipoUso] [int] NOT NULL identity,
	[Nombre] [varchar](30) NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Tipo_Uso] PRIMARY KEY CLUSTERED 
(
	[CodTipoUso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 12-Sep-19 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[CodTipoDoc] [int] NOT NULL,
	[NroTipoDoc] [int] NOT NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaNac] [datetime] NULL,
	[Apellido] [varchar](20) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Telefono] [varchar](30) NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[CodTipoDoc] ASC,
	[NroTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalle_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Factura_Factura] FOREIGN KEY([NroFactura], [CodTipoFactura])
REFERENCES [dbo].[Factura] ([NroFactura], [CodTipoFactura])
GO
ALTER TABLE [dbo].[Detalle_Factura] CHECK CONSTRAINT [FK_Detalle_Factura_Factura]
GO
ALTER TABLE [dbo].[Estructura]  WITH CHECK ADD  CONSTRAINT [FK_Estructura_Producto_Inferior] FOREIGN KEY([IdPInferior])
REFERENCES [dbo].[Producto] ([CodProducto])
GO
ALTER TABLE [dbo].[Estructura] CHECK CONSTRAINT [FK_Estructura_Producto_Inferior]
GO
ALTER TABLE [dbo].[Estructura]  WITH CHECK ADD  CONSTRAINT [FK_Estructura_Producto_Superior] FOREIGN KEY([IdPSuperior])
REFERENCES [dbo].[Producto] ([CodProducto])
GO
ALTER TABLE [dbo].[Estructura] CHECK CONSTRAINT [FK_Estructura_Producto_Superior]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([CodCliente])
REFERENCES [dbo].[Cliente] ([CodCliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Vendedor] FOREIGN KEY([CodTipoDocV], [NroTipoDocV])
REFERENCES [dbo].[Vendedor] ([CodTipoDoc], [NroTipoDoc])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Vendedor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tipo_Medida] FOREIGN KEY([CodTipoMedida])
REFERENCES [dbo].[Tipo_Medida] ([CodTipoMedida])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tipo_Medida]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tipo_Uso] FOREIGN KEY([CodTipoUso])
REFERENCES [dbo].[Tipo_Uso] ([CodTipoUso])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tipo_Uso]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Tipo_Doc] FOREIGN KEY([CodTipoDoc])
REFERENCES [dbo].[Tipo_Doc] ([CodTipoDoc])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Tipo_Doc]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor] FOREIGN KEY([CodProveedor])
REFERENCES [dbo].[Proveedor] ([CodProveedor])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor]
GO

create table usuarios
(idUsuario int primary key identity,
nombreUsuario varchar(50) not null,
password varchar(50) not null,
email varchar(50) not null,
habilitado bit default 1);

go

CREATE TABLE Cuenta_Corriente
(idCuentaCorriente int primary key identity,
NroFactura int not null,
CodTipoFactura int not null,
CodCliente int not null,
habilitado bit default 1,
CONSTRAINT [FK_Factura_CuentaCorriente] FOREIGN KEY([NroFactura], [CodTipoFactura])
REFERENCES [dbo].[Factura] ([NroFactura], [CodTipoFactura]),
CONSTRAINT [FK_Cliente] FOREIGN KEY([CodCliente])
REFERENCES [dbo].[Cliente] ([CodCliente])
);


go

insert into usuarios values
('AVela','75865','azul.vela.junio@gmail.com',1),
('SDemasi','76726','',1),
('EVera','78198','',1),
('TBonanzea','72087','',1);

insert into tipo_medida values
('Metros','Medida de longitud'),
('Metros cuadrados','Medida de superficie'),
('Metros c�bicos','Medida de vol�men'),
('Kg','Medida de masa'),
('N/A','Herramental/Maquinaria'),
('Unidad','Producto/insumo por unidad');

insert into tipo_uso values
('General','Herramienta/insumo de prop�sito general'),
('Alba�iler�a','Herramienta/insumo de alba�iler�a'),
('Carpinter�a','Herramienta/insumo de carpinter�a'),
('Producto terminado','Producto fabricado por la ferreter�a con insumos propios');

insert into proveedor values 
('Ferro','Cons','Duarte Quiroz 621','351-2293485',30,1),
('Zara','Te','Av. Col�n 829','351-2397372',15,1),
('Falco','Hnos.','Acu�a 81','3571-648292',20,1),
('Fabricaci�n propia','Fabricaci�n propia',null,null,null,1);


insert into producto values 
('Amoladora','Herramienta',5,3000,1,1,1),
('Hormigonera','Maquinaria alba�iler�a',5,10000,2,2,1),
('Clavo corto','Clavo 4cm',6,0.24,1,3,1),
('Clavo largo','Clavo 7cm',6,0.40,1,3,1),
('Placa Madera','Insumo de carpinter�a',2,500,3,2,1),
('Tornillo','Insumo general',1,0.60,1,1,1),
('Tuerca','Insumo general',1,0.40,1,3,1),
('Mesa','Mesa por m2',2,2000,4,4,1);

insert into estructura values
(8,5,2,1),
(8,3,20,1),
(8,4,20,1),
(8,6,8,1),
(8,7,8,1);

insert into tipo_factura values 
('A','Emitida por RI a RI'),
('B','Emitida por RI a CF'),
('C','Emitida por monotributista');

insert into cliente values 
('P�rez','Juan','351-1231292','30-72098763-6',default),
('Pito','Elsa','351-4921292','30-72093243-2',default),
('Flores del Campo','Zacar�as','351-1242292','30-62028421-6',default),
('Lancha','Chin Chu','351-5124286','30-72839637-3',default);

go

insert into tipo_doc values
('DNI','Documento Nacional de Identidad'),
('LE','Libreta de Enrolamiento'),
('CI','C�dula de Identidad');

insert into vendedor values 
(1,36975628,convert(datetime,'16/02/1995',103),convert(datetime,'05/03/1975',103),'Gaona Lugo','Orlando','351-2852890'),
(1,38976271,convert(datetime,'01/12/1988',103),convert(datetime,'15/02/1996',103),'Mac Allister','Alexis','351-8273615'),
(2,29665267,convert(datetime,'11/11/1960',103),convert(datetime,'25/10/1980',103),'Andrada','Esteban','351-2773025');
