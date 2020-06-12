USE [Project_Manager]
GO

/****** Object:  Table [dbo].[Tasks]    Script Date: 6/12/2020 8:36:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Task_ID] [int] NULL,
	[Project_ID] [int] NULL,
	[Task_Name] [varchar](50) NULL,
	[Start_Date] [datetime2](7) NULL,
	[End_Date] [datetime2](7) NULL,
	[Priority] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

