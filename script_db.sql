USE [master]
GO
CREATE DATABASE [CK]
GO
ALTER DATABASE [CK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CK] SET ARITHABORT OFF 
GO
ALTER DATABASE [CK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CK] SET  MULTI_USER 
GO
ALTER DATABASE [CK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CK] SET QUERY_STORE = OFF
GO
USE [CK]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolio](
	[PortfolioID] [uniqueidentifier] NOT NULL,
	[Balance] [money] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED 
(
	[PortfolioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trade](
	[TradeID] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[PortfolioID] [uniqueidentifier] NOT NULL,
	[Date] [nvarchar](10) NOT NULL,
	[NumberOfShares] [decimal](14, 5) NOT NULL,
	[Price] [money] NOT NULL,
	[Currency] [nvarchar](10) NOT NULL,
	[MarketValue] [money] NOT NULL,
	[Action] [nvarchar](10) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Asset] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Salt] [nvarchar](50) NULL,
	[Token] [nvarchar](100) NOT NULL,
	[RefreshToken] [nvarchar](100) NULL,
	[TokenExpiration] [datetime] NULL,
	[RefreshTokenExpiration] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Portfolio]  WITH CHECK ADD  CONSTRAINT [FK_Portfolio_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Portfolio] CHECK CONSTRAINT [FK_Portfolio_User]
GO
ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioTrade] FOREIGN KEY([PortfolioID])
REFERENCES [dbo].[Portfolio] ([PortfolioID])
GO
ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_PortfolioTrade]
GO
USE [master]
GO
ALTER DATABASE [CK] SET  READ_WRITE 
GO
