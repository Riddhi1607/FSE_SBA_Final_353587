USE [Project_Manager]
GO

/****** Object:  Table [dbo].[ParentTask]    Script Date: 6/12/2020 8:35:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParentTask](
	[Parent_Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Task_Name] [varchar](50) NULL,
 CONSTRAINT [PK_ParentTask] PRIMARY KEY CLUSTERED 
(
	[Parent_Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

