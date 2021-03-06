USE [master]
GO
/****** Object:  Database [Kiosco_UTM_FINAL]    Script Date: 24/07/2021 11:13:15 ******/
CREATE DATABASE [Kiosco_UTM_FINAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kiosco_UTM_FINAL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kiosco_UTM_FINAL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kiosco_UTM_FINAL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kiosco_UTM_FINAL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kiosco_UTM_FINAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET  MULTI_USER 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kiosco_UTM_FINAL', N'ON'
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET QUERY_STORE = OFF
GO
USE [Kiosco_UTM_FINAL]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Matricula_Alumno] [varchar](50) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[ApellidoP] [varchar](60) NOT NULL,
	[ApellidoM] [varchar](60) NULL,
	[Estatus] [bit] NULL,
	[clave_Grado_Alumnos] [int] NOT NULL,
	[clave_Grupo_Alumnos] [varchar](1) NOT NULL,
	[Clave_Division_Alumno] [int] NOT NULL,
	[Clave_Carrera_Alumno] [int] NOT NULL,
 CONSTRAINT [pk_Matricula_Alumno] PRIMARY KEY CLUSTERED 
(
	[Matricula_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos_Proyecto]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos_Proyecto](
	[id_Alumnos_Proyecto] [int] IDENTITY(1,1) NOT NULL,
	[Matricula_Alumno_Proyecto] [varchar](50) NOT NULL,
	[Id_Proyecto_Proyecto] [int] NOT NULL,
 CONSTRAINT [PK_id_equipos_proyecto] PRIMARY KEY CLUSTERED 
(
	[id_Alumnos_Proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[Codigo_Carrera] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Carrera] [varchar](60) NOT NULL,
	[Clave_division] [int] NOT NULL,
 CONSTRAINT [pk_id_Carrera] PRIMARY KEY CLUSTERED 
(
	[Codigo_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisiones]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisiones](
	[Codigo_Divisiones] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Division] [varchar](40) NOT NULL,
	[Descripcion_division] [varchar](max) NOT NULL,
 CONSTRAINT [pk_id_divisiones] PRIMARY KEY CLUSTERED 
(
	[Codigo_Divisiones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grado]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grado](
	[Grado] [int] NOT NULL,
	[Ciclo] [varchar](11) NOT NULL,
 CONSTRAINT [pk_grado] PRIMARY KEY CLUSTERED 
(
	[Grado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[Grupo] [varchar](1) NOT NULL,
 CONSTRAINT [pk_Grupo] PRIMARY KEY CLUSTERED 
(
	[Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[Matricula_Maestros] [varchar](50) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[ApellidoP] [varchar](60) NOT NULL,
	[ApellidoM] [varchar](60) NULL,
	[Estatus] [bit] NULL,
	[clave_division_maestros] [int] NOT NULL,
 CONSTRAINT [pk_id_Profesores] PRIMARY KEY CLUSTERED 
(
	[Matricula_Maestros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyectos](
	[Id_Proyecto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[imagen] [varchar](max) NOT NULL,
	[Video] [varchar](max) NOT NULL,
	[Estatus] [bit] NULL,
	[Clave_Division_Proyectos] [int] NOT NULL,
	[Clave_Carrera_Proyectos] [int] NOT NULL,
	[Clave_Grado_Proyectos] [int] NOT NULL,
	[Clave_Grupo_Proyectos] [varchar](1) NOT NULL,
 CONSTRAINT [pk_Id_Proyecto] PRIMARY KEY CLUSTERED 
(
	[Id_Proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/07/2021 11:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Correo] [varchar](100) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[ApellidoP] [varchar](40) NOT NULL,
	[ApellidoM] [varchar](40) NULL,
	[Estatus] [bit] NULL,
	[Contraseña] [varchar](max) NOT NULL,
 CONSTRAINT [pk_correo_Usuario] PRIMARY KEY CLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Alumnos] ([Matricula_Alumno], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_Grado_Alumnos], [clave_Grupo_Alumnos], [Clave_Division_Alumno], [Clave_Carrera_Alumno]) VALUES (N'0239012', N'christian', N'balam', N'rosas', 1, 1, N'A', 1, 1)
INSERT [dbo].[Alumnos] ([Matricula_Alumno], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_Grado_Alumnos], [clave_Grupo_Alumnos], [Clave_Division_Alumno], [Clave_Carrera_Alumno]) VALUES (N'57467', N'Jon', N'Sabido', N'Reynoso', 0, 2, N'B', 3, 4)
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (1, N'DSM', 1)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (2, N'Mecatronica', 2)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (3, N'IRD', 1)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (4, N'Gastronomia', 3)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (6, N'Contabilidad', 3)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (7, N'Turismo', 3)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (9, N'Energías Renovables', 2)
INSERT [dbo].[Carreras] ([Codigo_Carrera], [Nombre_Carrera], [Clave_division]) VALUES (10, N'Área Instalaciones Eléctricas', 2)
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisiones] ON 

INSERT [dbo].[Divisiones] ([Codigo_Divisiones], [Nombre_Division], [Descripcion_division]) VALUES (1, N'TIC', N'División de Tecnologias')
INSERT [dbo].[Divisiones] ([Codigo_Divisiones], [Nombre_Division], [Descripcion_division]) VALUES (2, N'Industrial', N'División Industrial')
INSERT [dbo].[Divisiones] ([Codigo_Divisiones], [Nombre_Division], [Descripcion_division]) VALUES (3, N'Administracion', N'Division Administracion')
SET IDENTITY_INSERT [dbo].[Divisiones] OFF
GO
INSERT [dbo].[Grado] ([Grado], [Ciclo]) VALUES (1, N'2021-2022')
INSERT [dbo].[Grado] ([Grado], [Ciclo]) VALUES (2, N'2021-2022')
GO
INSERT [dbo].[Grupo] ([Grupo]) VALUES (N'A')
INSERT [dbo].[Grupo] ([Grupo]) VALUES (N'B')
INSERT [dbo].[Grupo] ([Grupo]) VALUES (N'C')
GO
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0014', N'María de la Luz', N'García', N'Escalante', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0039', N'Luigui Agustín', N'Chulim', N'Carballo', 1, 2)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0073', N'Ivette', N'Aguayo', N'Cardenas', 1, 2)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0188', N'Thelma Esther', N'Moo', N'Novelo', 1, 2)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0189', N'German', N'Cabrera', N'Rosado', 1, 2)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0303', N'Jose', N'Aguilar', N'Zapata', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0330', N'Ricardo Antonio', N'Díaz', N'Loría', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0345', N'Patricia Maria', N'Toledo', N'Barrera', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0349', N'María del Carmen', N'Pacho', N'Suarez', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0351', N'Cecilia', N'Moguel', N'Dominguez', 1, 3)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0433', N'Aureny Magaly', N'Miam', N'Uc', 1, 2)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'0654', N'Roger', N'Gongora', N'Flores', 1, 1)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'121212', N'Laura', N'Castillo', N'Salazar', 1, 1)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'125A', N'Aurelio', N'Mex', N'Mex', 1, 1)
INSERT [dbo].[Profesores] ([Matricula_Maestros], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [clave_division_maestros]) VALUES (N'126B', N'Carlos', N'Canto', N'Bonilla', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Proyectos] ON 

INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (22, N'Crear un chat estilo Whatsapp', N'Aprenda a como crear su propio chat de texto en su móvil.', N'8a599204-ed31-4767-a371-52479c95f8a6_imagen_2021-07-23_120619.png', N'<iframe width="560" height="315" src="https://www.youtube.com/embed/T3agoyB_sbA" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 1, 1, 1, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (23, N'Nodejs Curso Desde Cero', N'El proyecto indicado para aprender acerca de Nodejs', N'036fb2bc-7029-4514-8b86-13fbfb5d3c3f_imagen_2021-07-23_120720.png', N'<iframe width="1863" height="770" src="https://www.youtube.com/embed/BhvLIzVL8_o" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 1, 1, 2, N'B')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (24, N'Crear una interfaz moderna en C#', N'Todo acerca de la actualidad en las interfaces modernas dentro de C#, lo podrás encontrar aqui!', N'1d261fd3-3806-4d00-b2fd-537f9eddda06_imagen_2021-07-23_120825.png', N'<iframe width="560" height="315" src="https://www.youtube.com/embed/vYDyGxoq9JU" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 1, 1, 2, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (25, N'Curso de contabilidad básica para principiantes', N'Entra al mundo de la contabilidad partiendo con este curso', N'3c1882bc-edac-452a-b26c-38fa6ccd185e_imagen_2021-07-23_121016.png', N'<iframe width="1863" height="770" src="https://www.youtube.com/embed/BpurN5_a3WU" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 3, 6, 2, N'B')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (26, N'Curso Gratuito GUÍA DE SITIO DE TURISMO CULTURAL', N'Todo acerca del turismo y su impacto en la actualidad', N'cf8f74cc-54b7-47ff-829d-480d33c3ba18_imagen_2021-07-23_121127.png', N'<iframe width="1863" height="770" src="https://www.youtube.com/embed/ND2yZ97OyZE" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 3, 7, 2, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (27, N'Pastel de Vainilla | Básicos de Repostría', N'Hacer un pastel es complicado, aquí te enseñaremos a verlo de una manera más facíl', N'a42735bb-e79b-46fb-8bcd-6a7b9cd9f266_imagen_2021-07-23_121301.png', N'<iframe width="1863" height="770" src="https://www.youtube.com/embed/rdBfwUjxO_E" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 3, 4, 2, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (28, N'Instalación de paneles solares paso a paso', N'Aprende a instalar paso por paso un panel solar', N'a1bb24aa-b83a-4a8a-978b-ac6a4850a046_imagen_2021-07-23_122732.png', N'<iframe width="560" height="315" src="https://www.youtube.com/embed/QmGP5yBWEgw" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 2, 9, 2, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (29, N'Arduino para principiantes', N'Crea tu primer sistema Arduino guiándote con este curso', N'stock.jpg', N'<iframe width="1863" height="770" src="https://www.youtube.com/embed/YHw8_QP0cMI" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 2, 2, 2, N'B')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (30, N'Cableado de una instalación eléctrica', N'Instalación de un cableado en casa, ¡Apréndelo aquí, en este curso!', N'd578e3fa-9760-44e4-b36e-bcb80d1cd2f2_imagen_2021-07-23_122620.png', N'<iframe width="560" height="315" src="https://www.youtube.com/embed/7CQxUFt8kFg" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 2, 10, 1, N'A')
INSERT [dbo].[Proyectos] ([Id_Proyecto], [Nombre], [Descripcion], [imagen], [Video], [Estatus], [Clave_Division_Proyectos], [Clave_Carrera_Proyectos], [Clave_Grado_Proyectos], [Clave_Grupo_Proyectos]) VALUES (31, N'Proyecto De Pagina Web', N'Crea una pagina web desde 0', N'04e5f97a-5e38-4a53-9866-5be36fd8b551_Humo naranja.jpg', N'<iframe width="560" height="315" src="https://www.youtube.com/embed/RIZdjT1472Y?controls=0" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>', 1, 3, 7, 2, N'C')
SET IDENTITY_INSERT [dbo].[Proyectos] OFF
GO
INSERT [dbo].[Usuarios] ([Correo], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [Contraseña]) VALUES (N'abrahamherrera0001@gmail.com', N'Jonathan', N'Herrera', N'Caro', 1, N'123')
INSERT [dbo].[Usuarios] ([Correo], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [Contraseña]) VALUES (N'alumno1234@utm.com', N'Oscar', N'Perez', N'Uh', 1, N'xxx')
INSERT [dbo].[Usuarios] ([Correo], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [Contraseña]) VALUES (N'alumnojonathan@utm.com', N'Jonathan', N'Sabido', N'Reynoso', 1, N'utm')
INSERT [dbo].[Usuarios] ([Correo], [Nombre], [ApellidoP], [ApellidoM], [Estatus], [Contraseña]) VALUES (N'hola@hotmail.com', N'hola', N'mundo', N'mundo', 1, N'123')
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_Clave_Carrera_Alumno] FOREIGN KEY([Clave_Carrera_Alumno])
REFERENCES [dbo].[Carreras] ([Codigo_Carrera])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_Clave_Carrera_Alumno]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_Clave_Division_Alumno] FOREIGN KEY([Clave_Division_Alumno])
REFERENCES [dbo].[Divisiones] ([Codigo_Divisiones])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_Clave_Division_Alumno]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_clave_Grado_Alumnos] FOREIGN KEY([clave_Grado_Alumnos])
REFERENCES [dbo].[Grado] ([Grado])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_clave_Grado_Alumnos]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_clave_Grupo_Alumnos] FOREIGN KEY([clave_Grupo_Alumnos])
REFERENCES [dbo].[Grupo] ([Grupo])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_clave_Grupo_Alumnos]
GO
ALTER TABLE [dbo].[Alumnos_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Id_Proyecto_Proyecto] FOREIGN KEY([Id_Proyecto_Proyecto])
REFERENCES [dbo].[Proyectos] ([Id_Proyecto])
GO
ALTER TABLE [dbo].[Alumnos_Proyecto] CHECK CONSTRAINT [FK_Id_Proyecto_Proyecto]
GO
ALTER TABLE [dbo].[Alumnos_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Alumno_Proyecto] FOREIGN KEY([Matricula_Alumno_Proyecto])
REFERENCES [dbo].[Alumnos] ([Matricula_Alumno])
GO
ALTER TABLE [dbo].[Alumnos_Proyecto] CHECK CONSTRAINT [FK_Matricula_Alumno_Proyecto]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [fk_Clave_division] FOREIGN KEY([Clave_division])
REFERENCES [dbo].[Divisiones] ([Codigo_Divisiones])
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [fk_Clave_division]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [fk_clave_division_maestros] FOREIGN KEY([clave_division_maestros])
REFERENCES [dbo].[Divisiones] ([Codigo_Divisiones])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [fk_clave_division_maestros]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_Clave_Carrera_Proyectos] FOREIGN KEY([Clave_Carrera_Proyectos])
REFERENCES [dbo].[Carreras] ([Codigo_Carrera])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_Clave_Carrera_Proyectos]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_Clave_Division_Proyectos] FOREIGN KEY([Clave_Division_Proyectos])
REFERENCES [dbo].[Divisiones] ([Codigo_Divisiones])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_Clave_Division_Proyectos]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [fk_clave_Grado_Proyectos] FOREIGN KEY([Clave_Grado_Proyectos])
REFERENCES [dbo].[Grado] ([Grado])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [fk_clave_Grado_Proyectos]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [fk_clave_Grupo_Proyectos] FOREIGN KEY([Clave_Grupo_Proyectos])
REFERENCES [dbo].[Grupo] ([Grupo])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [fk_clave_Grupo_Proyectos]
GO
USE [master]
GO
ALTER DATABASE [Kiosco_UTM_FINAL] SET  READ_WRITE 
GO
