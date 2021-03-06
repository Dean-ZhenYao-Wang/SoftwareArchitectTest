USE [SoftwareArchitectTest]
GO
/****** Object:  StoredProcedure [dbo].[ValidationCreditCard]    Script Date: 2018/11/27 11:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ValidationCreditCard]
@cardnumber nvarchar(16),
@expiryDate nvarchar(6),
@ValidationResult varchar(20) out
AS
BEGIN

DECLARE @count int 
set @count=(select count(*) from T_CreditCard where CardNumber=@cardnumber and ExpiryDate=@expiryDate)
if @count<=0
begin
set @ValidationResult='does not exist'
end
else
begin
set @ValidationResult=''
end
select @ValidationResult
END

GO
/****** Object:  Table [dbo].[T_CreditCard]    Script Date: 2018/11/27 11:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CreditCard](
	[Id] [uniqueidentifier] NOT NULL,
	[CardNumber] [nvarchar](16) NULL,
	[CardType] [nvarchar](20) NULL,
	[ExpiryDate] [nvarchar](6) NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_T_CreditCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_EventExecutionErrorLog]    Script Date: 2018/11/27 11:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EventExecutionErrorLog](
	[LogID] [uniqueidentifier] NOT NULL,
	[FunctionName] [nvarchar](300) NOT NULL,
	[PersonName] [nvarchar](30) NULL,
	[ErrorDescription] [nvarchar](max) NOT NULL,
	[OccurrenceTime] [datetime] NOT NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_EventExecutionErrorLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Users]    Script Date: 2018/11/27 11:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Users](
	[Id] [uniqueidentifier] NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[AccessToken] [nvarchar](50) NULL,
	[LoginErrorTimes] [int] NOT NULL,
	[LastLoginErrorDateTime] [datetime] NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_T_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[T_CreditCard] ([Id], [CardNumber], [CardType], [ExpiryDate], [CreateDateTime], [IsDeleted]) VALUES (N'5aeb6a35-e0f8-4d0f-b651-0aa644e59f81', N'3528258976381678', N'jcb', N'012011', CAST(0x0000A9A500000000 AS DateTime), 0)
INSERT [dbo].[T_CreditCard] ([Id], [CardNumber], [CardType], [ExpiryDate], [CreateDateTime], [IsDeleted]) VALUES (N'd4b5bf56-db79-4552-aa79-0b4f9ca746b0', N'5789081276381293', N'master', N'012011', CAST(0x0000A9A500000000 AS DateTime), 0)
INSERT [dbo].[T_CreditCard] ([Id], [CardNumber], [CardType], [ExpiryDate], [CreateDateTime], [IsDeleted]) VALUES (N'e3b4b3c3-ab5e-4f64-b967-32207276f2ad', N'342825897638134', N'amex', N'012011', CAST(0x0000A9A500000000 AS DateTime), 0)
INSERT [dbo].[T_CreditCard] ([Id], [CardNumber], [CardType], [ExpiryDate], [CreateDateTime], [IsDeleted]) VALUES (N'652c863b-19ed-4d15-98ed-44a605ad751a', N'4789081276381293', N'visa', N'082008', CAST(0x0000A9A500000000 AS DateTime), 0)
INSERT [dbo].[T_CreditCard] ([Id], [CardNumber], [CardType], [ExpiryDate], [CreateDateTime], [IsDeleted]) VALUES (N'02fbe5cf-9fbc-4bd7-87c2-71c81f22fa46', N'1', N'1', N'1', CAST(0x0000A9A500000000 AS DateTime), 0)
INSERT [dbo].[T_Users] ([Id], [LoginName], [PassWord], [AccessToken], [LoginErrorTimes], [LastLoginErrorDateTime], [CreateDateTime], [IsDeleted]) VALUES (N'111e61e8-6ac5-4c49-8e58-7436558087e5', N'admin', N'admin', NULL, 0, NULL, CAST(0x0000A9A500000000 AS DateTime), 0)
