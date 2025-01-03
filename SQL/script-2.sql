USE LibraRestaurant
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryItems]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryItems](
	[CategoryItemId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CategoryItems] PRIMARY KEY CLUSTERED 
(
	[CategoryItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NameEn] [nvarchar](max) NOT NULL,
	[Fullname] [nvarchar](max) NOT NULL,
	[FullnameEn] [nvarchar](max) NOT NULL,
	[CodeName] [nvarchar](max) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NameEn] [nvarchar](max) NOT NULL,
	[Fullname] [nvarchar](max) NOT NULL,
	[FullnameEn] [nvarchar](max) NOT NULL,
	[CodeName] [nvarchar](max) NOT NULL,
	[CityId] [int] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRoles](
	[EmployeeRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[AssignedDate] [datetime] NOT NULL,
	[RevokedDate] [datetime] NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED 
(
	[EmployeeRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[StoreId] [uniqueidentifier] NULL,
	[Email] [nvarchar](320) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Mobile] [nvarchar](15) NOT NULL,
	[Status] [int] NOT NULL,
	[RegisteredAt] [datetime2](7) NOT NULL,
	[LastLoggedinDate] [datetimeoffset](7) NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](75) NOT NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[Summary] [nvarchar](1000) NULL,
	[SKU] [nvarchar](100) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Recipe] [nvarchar](1000) NULL,
	[Instruction] [nvarchar](1000) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastUpdatedAt] [datetime2](7) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHeaders]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHeaders](
	[OrderId] [uniqueidentifier] NOT NULL,
	[OrderNo] [nvarchar](max) NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[PaymentMethodId] [int] NULL,
	[PaymentTimeId] [int] NULL,
	[ServantId] [uniqueidentifier] NULL,
	[CashierId] [uniqueidentifier] NULL,
	[CustomerNotes] [nvarchar](max) NULL,
	[ReservationId] [int] NOT NULL,
	[PriceCalculated] [float] NOT NULL,
	[PriceAdjustment] [float] NULL,
	[PriceAdjustmentReason] [nvarchar](max) NULL,
	[Subtotal] [float] NOT NULL,
	[Tax] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[LatestStatus] [int] NOT NULL,
	[LatestStatusUpdate] [datetime] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[IsPreparationDelayed] [bit] NOT NULL,
	[DelayedTime] [datetime2](7) NULL,
	[IsCanceled] [bit] NOT NULL,
	[CanceledTime] [datetime2](7) NULL,
	[CanceledReason] [nvarchar](max) NULL,
	[IsReady] [bit] NOT NULL,
	[ReadyTime] [datetime2](7) NULL,
	[IsCompleted] [bit] NOT NULL,
	[CompletedTime] [datetime2](7) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrderHeaders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[OrderLineId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsCanceled] [bit] NOT NULL,
	[CanceledTime] [datetime] NULL,
	[CanceledReason] [nvarchar](max) NULL,
	[CustomerReview] [nvarchar](max) NULL,
	[CustomerLike] [int] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED 
(
	[OrderLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentHistories]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentHistories](
	[PaymentHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [nvarchar](max) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[PaymentMethodId] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[CurrencyId] [int] NULL,
	[Status] [int] NOT NULL,
	[ResponseJSON] [nvarchar](max) NULL,
	[CallbackURL] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PaymentHistories] PRIMARY KEY CLUSTERED 
(
	[PaymentHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Picture] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[TableNumber] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ReservationTime] [datetime] NULL,
	[CustomerName] [nvarchar](max) NULL,
	[CustomerPhone] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [ntext] NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredDomainEvents]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredDomainEvents](
	[Id] [uniqueidentifier] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Employee] [nvarchar](100) NOT NULL,
	[CorrelationId] [nvarchar](100) NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[AggregateNumberId] [int] NOT NULL,
	[Action] [varchar](100) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StoredDomainEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredDomainNotifications]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredDomainNotifications](
	[Id] [uniqueidentifier] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Employee] [nvarchar](100) NOT NULL,
	[CorrelationId] [nvarchar](100) NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[AggregateNumberId] [int] NOT NULL,
	[MessageType] [nvarchar](100) NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](1024) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_StoredDomainNotifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[StoreId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CityId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[WardId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[TaxCode] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[GpsLocation] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[BankBranch] [nvarchar](max) NULL,
	[BankCode] [nvarchar](max) NULL,
	[BankAccount] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[OldToken] [nvarchar](max) NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RevokedAt] [datetime] NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wards]    Script Date: 9/24/2024 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wards](
	[WardId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NameEn] [nvarchar](max) NOT NULL,
	[Fullname] [nvarchar](max) NOT NULL,
	[FullnameEn] [nvarchar](max) NOT NULL,
	[CodeName] [nvarchar](max) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[NumberId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Wards] PRIMARY KEY CLUSTERED 
(
	[WardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240801044734_check', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240801045711_check', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240831020815_InitialCreate', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240831022207_check-v2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240831022237_check-v2', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240909081814_CategoryItem', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240915020827_Role', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240915130744_EmployeeRole', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240916091538_RoleUpdate', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240920083233_Token', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240921030545_UpdateToken2', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (2, N'Khai vị', N'', 1, N'https://static.vecteezy.com/system/resources/thumbnails/032/325/402/small_2x/mozzarella-cheese-sticks-with-ketchup-isolated-on-transparent-background-file-cut-out-ai-generated-png.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (3, N'Món gà', N'', 1, N'https://www.pngkey.com/png/full/235-2351748_share-this-image-fried-chicken-dinner-transparent.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (4, N'Món phụ', N'', 1, N'https://www.freeiconspng.com/thumbs/soup-png/meat-soup-png-7.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (5, N'Rau trộn', N'', 1, N'https://png.pngtree.com/png-clipart/20230427/original/pngtree-transparent-salad-vegetables-and-fruits-png-image_9116505.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (7, N'Món lẩu', N'', 1, N'https://rakuen.com.vn/wp-content/uploads/2021/08/lau.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (8, N'Tráng miệng', N'', 1, N'https://www.pngplay.com/wp-content/uploads/13/Dessert-Transparent-Images.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (9, N'Món cá', N'', 1, N'https://r2.erweima.ai/imgcompressed/compressed_d68b863795c8827e4f0478ef3fa4d425.webp', N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [IsActive], [Picture], [Id], [NumberId], [Deleted]) VALUES (10, N'Shushi', N'', 1, N'https://pngimg.com/d/sushi_PNG98864.png', N'00000000-0000-0000-0000-000000000000', 0, 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryItems] ON 

INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (1, 2, 1, NULL, N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (2, 2, 2, NULL, N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (3, 3, 2, NULL, N'00000000-0000-0000-0000-000000000000', 0, 1)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (4, 2, 3, NULL, N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (5, 2, 4, NULL, N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (6, 3, 5, NULL, N'00000000-0000-0000-0000-000000000000', 0, 0)
INSERT [dbo].[CategoryItems] ([CategoryItemId], [CategoryId], [ItemId], [Description], [Id], [NumberId], [Deleted]) VALUES (7, 5, 1, NULL, N'00000000-0000-0000-0000-000000000000', 0, 1)
SET IDENTITY_INSERT [dbo].[CategoryItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (1, N'Hà Nội', N'Ha Noi', N'Thành phố Hà Nội', N'Ha Noi City', N'ha_noi', N'96959305-55ce-4ec9-ae9d-2fc98dc360d8', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (2, N'Hà Giang', N'Ha Giang', N'Tỉnh Hà Giang', N'Ha Giang Province', N'ha_giang', N'ca5fa468-8e91-4828-b294-714606571391', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (3, N'Cao Bằng', N'Cao Bang', N'Tỉnh Cao Bằng', N'Cao Bang Province', N'cao_bang', N'99f71147-cc02-403b-8c3d-6d91702b7678', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (4, N'Bắc Kạn', N'Bac Kan', N'Tỉnh Bắc Kạn', N'Bac Kan Province', N'bac_kan', N'1013fbbe-79b2-4d6e-a55d-3daf44a8eb24', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (5, N'Tuyên Quang', N'Tuyen Quang', N'Tỉnh Tuyên Quang', N'Tuyen Quang Province', N'tuyen_quang', N'375426b5-d01a-429e-a684-342eab81d16b', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (6, N'Lào Cai', N'Lao Cai', N'Tỉnh Lào Cai', N'Lao Cai Province', N'lao_cai', N'4e42e557-2646-4e56-b220-3185b9ae3716', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (7, N'Điện Biên', N'Dien Bien', N'Tỉnh Điện Biên', N'Dien Bien Province', N'dien_bien', N'fffac9e5-b400-459f-b0fe-4dc46fe56aa8', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (8, N'Lai Châu', N'Lai Chau', N'Tỉnh Lai Châu', N'Lai Chau Province', N'lai_chau', N'941b5bdc-0e11-4d58-af10-a34b738e4987', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (9, N'Sơn La', N'Son La', N'Tỉnh Sơn La', N'Son La Province', N'son_la', N'176ab115-03f8-437c-ae74-956a0563fc8b', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (10, N'Yên Bái', N'Yen Bai', N'Tỉnh Yên Bái', N'Yen Bai Province', N'yen_bai', N'16b4cda4-7eb7-40dc-9c73-132670a19f04', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (11, N'Hoà Bình', N'Hoa Binh', N'Tỉnh Hoà Bình', N'Hoa Binh Province', N'hoa_binh', N'cbff9629-031b-49d3-9b70-9ec5ee7b3ade', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (12, N'Thái Nguyên', N'Thai Nguyen', N'Tỉnh Thái Nguyên', N'Thai Nguyen Province', N'thai_nguyen', N'999e375e-c900-4347-abcc-b634de3a65c2', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (13, N'Lạng Sơn', N'Lang Son', N'Tỉnh Lạng Sơn', N'Lang Son Province', N'lang_son', N'ef482869-c54d-4a65-b050-809b4eb33d1a', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (14, N'Quảng Ninh', N'Quang Ninh', N'Tỉnh Quảng Ninh', N'Quang Ninh Province', N'quang_ninh', N'fd006cb0-269c-45cc-9900-407568c6ff95', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (15, N'Bắc Giang', N'Bac Giang', N'Tỉnh Bắc Giang', N'Bac Giang Province', N'bac_giang', N'cce2ea4f-3322-44e8-95ca-ee8dedf72101', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (16, N'Phú Thọ', N'Phu Tho', N'Tỉnh Phú Thọ', N'Phu Tho Province', N'phu_tho', N'3b54e3e4-8014-48d2-9c91-65f1511b5e32', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (17, N'Vĩnh Phúc', N'Vinh Phuc', N'Tỉnh Vĩnh Phúc', N'Vinh Phuc Province', N'vinh_phuc', N'e520df7e-e068-4bce-99d7-4ff84e0e168c', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (18, N'Bắc Ninh', N'Bac Ninh', N'Tỉnh Bắc Ninh', N'Bac Ninh Province', N'bac_ninh', N'99cc1916-78b7-41c6-b045-a488e6e71e6f', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (19, N'Hải Dương', N'Hai Duong', N'Tỉnh Hải Dương', N'Hai Duong Province', N'hai_duong', N'0853d4ef-74ce-41cb-ac8e-a3891be5f1cf', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (20, N'Hải Phòng', N'Hai Phong', N'Thành phố Hải Phòng', N'Hai Phong City', N'hai_phong', N'8d7c7daf-45b4-4f20-b199-693ffa64fb23', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (21, N'Hưng Yên', N'Hung Yen', N'Tỉnh Hưng Yên', N'Hung Yen Province', N'hung_yen', N'f53793d6-be44-4881-bb2e-c95710b3526a', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (22, N'Thái Bình', N'Thai Binh', N'Tỉnh Thái Bình', N'Thai Binh Province', N'thai_binh', N'0c4cfa1c-ec9b-4aa7-85ae-cf4281d84e6d', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (23, N'Hà Nam', N'Ha Nam', N'Tỉnh Hà Nam', N'Ha Nam Province', N'ha_nam', N'42f02d92-56bf-4177-b417-7644a8dab82d', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (24, N'Nam Định', N'Nam Dinh', N'Tỉnh Nam Định', N'Nam Dinh Province', N'nam_dinh', N'99a76978-4934-4711-abf1-0629a6ac4973', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (25, N'Ninh Bình', N'Ninh Binh', N'Tỉnh Ninh Bình', N'Ninh Binh Province', N'ninh_binh', N'9722cdba-1ad7-4650-aa2e-467536c68357', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (26, N'Thanh Hóa', N'Thanh Hoa', N'Tỉnh Thanh Hóa', N'Thanh Hoa Province', N'thanh_hoa', N'1b326a84-39b4-4a13-9274-7c39933f9515', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (27, N'Nghệ An', N'Nghe An', N'Tỉnh Nghệ An', N'Nghe An Province', N'nghe_an', N'2672fe89-dacb-48d9-ac93-460135967c6c', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (28, N'Hà Tĩnh', N'Ha Tinh', N'Tỉnh Hà Tĩnh', N'Ha Tinh Province', N'ha_tinh', N'932b0114-a7f0-4836-bcdd-779e2520d498', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (29, N'Quảng Bình', N'Quang Binh', N'Tỉnh Quảng Bình', N'Quang Binh Province', N'quang_binh', N'd4a188d5-2f2f-4ec7-ba80-fd663c63d2d0', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (30, N'Quảng Trị', N'Quang Tri', N'Tỉnh Quảng Trị', N'Quang Tri Province', N'quang_tri', N'6b4bdc66-0ee7-438c-99e0-83742b6ba1ea', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (31, N'Thừa Thiên Huế', N'Thua Thien Hue', N'Tỉnh Thừa Thiên Huế', N'Thua Thien Hue Province', N'thua_thien_hue', N'4d5a912d-fb06-4392-bb9c-fd7235c086c8', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (32, N'Đà Nẵng', N'Da Nang', N'Thành phố Đà Nẵng', N'Da Nang City', N'da_nang', N'ba5c3e1d-bfe1-48c9-b93b-8711cc379195', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (33, N'Quảng Nam', N'Quang Nam', N'Tỉnh Quảng Nam', N'Quang Nam Province', N'quang_nam', N'8d4a84a2-d7d2-492c-8afe-6f21e5dfebc7', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (34, N'Quảng Ngãi', N'Quang Ngai', N'Tỉnh Quảng Ngãi', N'Quang Ngai Province', N'quang_ngai', N'395df9d0-0e80-4fbc-a65b-8de755b141ce', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (35, N'Bình Định', N'Binh Dinh', N'Tỉnh Bình Định', N'Binh Dinh Province', N'binh_dinh', N'd7a63df5-0d0e-457e-acd8-b032448a5bac', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (36, N'Phú Yên', N'Phu Yen', N'Tỉnh Phú Yên', N'Phu Yen Province', N'phu_yen', N'ea210b7c-79ef-4132-a827-ba1d8aa49a8e', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (37, N'Khánh Hòa', N'Khanh Hoa', N'Tỉnh Khánh Hòa', N'Khanh Hoa Province', N'khanh_hoa', N'dea383c0-328a-4f5d-86f2-9d794fdf2999', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (38, N'Ninh Thuận', N'Ninh Thuan', N'Tỉnh Ninh Thuận', N'Ninh Thuan Province', N'ninh_thuan', N'e2a1d9f2-3fa7-4d85-906a-cd575e5fb0ee', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (39, N'Bình Thuận', N'Binh Thuan', N'Tỉnh Bình Thuận', N'Binh Thuan Province', N'binh_thuan', N'd40de27d-7f54-42d7-bb76-2c21faca4c05', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (40, N'Kon Tum', N'Kon Tum', N'Tỉnh Kon Tum', N'Kon Tum Province', N'kon_tum', N'91eeb5ad-ada8-4d0a-b8bb-f681e8f5b9d1', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (41, N'Gia Lai', N'Gia Lai', N'Tỉnh Gia Lai', N'Gia Lai Province', N'gia_lai', N'071d4794-2528-4b88-832a-92313220dbdf', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (42, N'Đắk Lắk', N'Dak Lak', N'Tỉnh Đắk Lắk', N'Dak Lak Province', N'dak_lak', N'8db7308f-4c87-4779-9cea-0578d519276d', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (43, N'Đắk Nông', N'Dak Nong', N'Tỉnh Đắk Nông', N'Dak Nong Province', N'dak_nong', N'dba373fb-075e-4043-b86c-39f340cc13ed', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (44, N'Lâm Đồng', N'Lam Dong', N'Tỉnh Lâm Đồng', N'Lam Dong Province', N'lam_dong', N'12195c68-6924-4e5b-b202-ad5d49494717', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (45, N'Bình Phước', N'Binh Phuoc', N'Tỉnh Bình Phước', N'Binh Phuoc Province', N'binh_phuoc', N'08355a3c-1f81-4cd7-bd0e-d9cd3b2de528', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (46, N'Tây Ninh', N'Tay Ninh', N'Tỉnh Tây Ninh', N'Tay Ninh Province', N'tay_ninh', N'be895145-85ea-417e-b9ee-895768103932', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (47, N'Bình Dương', N'Binh Duong', N'Tỉnh Bình Dương', N'Binh Duong Province', N'binh_duong', N'd9f4c4ec-74cb-4958-99d2-68771d2edff5', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (48, N'Đồng Nai', N'Dong Nai', N'Tỉnh Đồng Nai', N'Dong Nai Province', N'dong_nai', N'45b714d3-df7c-4b58-a710-ae01ead05cbd', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (49, N'Bà Rịa - Vũng Tàu', N'Ba Ria - Vung Tau', N'Tỉnh Bà Rịa - Vũng Tàu', N'Ba Ria - Vung Tau Province', N'ba_ria_vung_tau', N'6c9bb926-7611-41a5-92f8-bfddcd0861a6', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (50, N'Hồ Chí Minh', N'Ho Chi Minh', N'Thành phố Hồ Chí Minh', N'Ho Chi Minh City', N'ho_chi_minh', N'ca5a6a69-8ea7-4a06-858b-dfe82f35f108', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (51, N'Long An', N'Long An', N'Tỉnh Long An', N'Long An Province', N'long_an', N'73afc707-bbd4-4639-a6c7-ec5609238586', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (52, N'Tiền Giang', N'Tien Giang', N'Tỉnh Tiền Giang', N'Tien Giang Province', N'tien_giang', N'c2bb52c4-75da-4da5-8bc8-e1bbf22ca22a', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (53, N'Bến Tre', N'Ben Tre', N'Tỉnh Bến Tre', N'Ben Tre Province', N'ben_tre', N'de0ecf89-3d2e-470f-88ed-27bf91de7514', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (54, N'Trà Vinh', N'Tra Vinh', N'Tỉnh Trà Vinh', N'Tra Vinh Province', N'tra_vinh', N'87b358aa-d4ba-4a41-b4b7-a61dcb5bac76', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (55, N'Vĩnh Long', N'Vinh Long', N'Tỉnh Vĩnh Long', N'Vinh Long Province', N'vinh_long', N'84aee72a-67ac-413f-9443-f1d65fedfa80', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (56, N'Đồng Tháp', N'Dong Thap', N'Tỉnh Đồng Tháp', N'Dong Thap Province', N'dong_thap', N'7b0928ab-4b22-4856-8925-e6896e7da70a', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (57, N'An Giang', N'An Giang', N'Tỉnh An Giang', N'An Giang Province', N'an_giang', N'16440a55-7b7a-44f6-9dba-cb7e0e289d9e', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (58, N'Kiên Giang', N'Kien Giang', N'Tỉnh Kiên Giang', N'Kien Giang Province', N'kien_giang', N'f1ee245c-e133-4fd9-a51b-7fd3efa56d08', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (59, N'Cần Thơ', N'Can Tho', N'Thành phố Cần Thơ', N'Can Tho City', N'can_tho', N'77c92d90-8ab6-429f-9d6d-71403c9f8a07', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (60, N'Hậu Giang', N'Hau Giang', N'Tỉnh Hậu Giang', N'Hau Giang Province', N'hau_giang', N'2d8d9fb6-6dce-4f2f-b76d-6583414c7733', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (61, N'Sóc Trăng', N'Soc Trang', N'Tỉnh Sóc Trăng', N'Soc Trang Province', N'soc_trang', N'4324940e-252c-4c1a-bd83-d490fabf83c5', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (62, N'Bạc Liêu', N'Bac Lieu', N'Tỉnh Bạc Liêu', N'Bac Lieu Province', N'bac_lieu', N'd4c645da-bb86-43ee-8d06-22901e9cbe34', 1, 0)
INSERT [dbo].[Cities] ([CityId], [Name], [NameEn], [Fullname], [FullnameEn], [CodeName], [Id], [NumberId], [Deleted]) VALUES (63, N'Cà Mau', N'Ca Mau', N'Tỉnh Cà Mau', N'Ca Mau Province', N'ca_mau', N'636f8854-204a-4615-8497-def783e8e1ed', 1, 0)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (1, N'VNĐ', N'Việt Nam Đồng', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (4, N'USD', N'Đô La Mỹ', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (5, N'GBP', N'Bảng Anh', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (6, N'JPY', N'Yên Nhật', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (7, N'KPW', N'Won', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (8, N'CNY', N'Nhân Dân Tệ', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (9, N'TWD', N'Tân Đài Tệ', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (10, N'HKD', N'Đô La Hồng Kông', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (11, N'₭', N'Kíp Lào', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (12, N'៛', N'Riel Campuchia', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (14, N'INR', N'Rupee Ấn Độ', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (15, N'THB', N'Bạt Thái Lan', N'00000000-0000-0000-0000-000000000000', 1, 0)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Description], [Id], [NumberId], [Deleted]) VALUES (16, N'EUR', N'Euro', N'00000000-0000-0000-0000-000000000000', 1, 0)
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Districts] ON 
ALTER TABLE [dbo].[Tokens] ADD  DEFAULT ('2024-01-01T00:00:00.000') FOR [ExpireDate]
GO
ALTER TABLE [dbo].[CategoryItems]  WITH CHECK ADD  CONSTRAINT [FK_CategoryItem_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryItems] CHECK CONSTRAINT [FK_CategoryItem_Category_CategoryId]
GO
ALTER TABLE [dbo].[CategoryItems]  WITH CHECK ADD  CONSTRAINT [FK_CategoryItem_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[MenuItems] ([ItemId])
GO
ALTER TABLE [dbo].[CategoryItems] CHECK CONSTRAINT [FK_CategoryItem_Item_ItemId]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_District_City_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_District_City_CityId]
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRole_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRole_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRole_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRole_Role_RoleId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Store_StoreId] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employee_Store_StoreId]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Store_StoreId] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menu_Store_StoreId]
GO
ALTER TABLE [dbo].[OrderHeaders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Store_StoreId] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[OrderHeaders] CHECK CONSTRAINT [FK_Order_Store_StoreId]
GO
ALTER TABLE [dbo].[OrderHeaders]  WITH CHECK ADD  CONSTRAINT [FK_OrderHeader_PaymentMethod_PaymentMethodId] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[OrderHeaders] CHECK CONSTRAINT [FK_OrderHeader_PaymentMethod_PaymentMethodId]
GO
ALTER TABLE [dbo].[OrderHeaders]  WITH CHECK ADD  CONSTRAINT [FK_OrderHeader_Reservation_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservations] ([ReservationId])
GO
ALTER TABLE [dbo].[OrderHeaders] CHECK CONSTRAINT [FK_OrderHeader_Reservation_ReservationId]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[MenuItems] ([ItemId])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLine_Item_ItemId]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderHeaders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLine_Order_OrderId]
GO
ALTER TABLE [dbo].[PaymentHistories]  WITH CHECK ADD  CONSTRAINT [FK_PaymentHistory_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderHeaders] ([OrderId])
GO
ALTER TABLE [dbo].[PaymentHistories] CHECK CONSTRAINT [FK_PaymentHistory_Order_OrderId]
GO
ALTER TABLE [dbo].[PaymentHistories]  WITH CHECK ADD  CONSTRAINT [FK_PaymentHistory_PaymentMethod_PaymentMethodId] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[PaymentHistories] CHECK CONSTRAINT [FK_PaymentHistory_PaymentMethod_PaymentMethodId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Store_StoreId] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservation_Store_StoreId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Store_City_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Store_City_CityId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Store_District_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Store_District_DistrictId]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Store_Ward_WardId] FOREIGN KEY([WardId])
REFERENCES [dbo].[Wards] ([WardId])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Store_Ward_WardId]
GO
ALTER TABLE [dbo].[Tokens]  WITH CHECK ADD  CONSTRAINT [FK_Token_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tokens] CHECK CONSTRAINT [FK_Token_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[Wards]  WITH CHECK ADD  CONSTRAINT [FK_Ward_District_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
GO
ALTER TABLE [dbo].[Wards] CHECK CONSTRAINT [FK_Ward_District_DistrictId]
GO
