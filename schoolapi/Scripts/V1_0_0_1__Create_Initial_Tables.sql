if (not exists (select * from sys.tables where name = 'student')) 
begin
		CREATE TABLE [dbo].[student](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[firstName] [nvarchar](255) NULL,
			[lastName] [nvarchar](255) NOT NULL,
			[gender] [nvarchar](50) NOT NULL,
			[dateOfBirth] [date] NOT NULL,
			[createdOn] [datetime] NULL,
			[contact] [varchar](24) NULL,
			[email] [nvarchar](255) NULL,
			[middleName] [nvarchar](255) NULL,
			[isActive] [bit] NOT NULL,
			[parents] [nvarchar](Max) NULL,
			[addresses] [nvarchar](Max) NULL,
			[guardian] [nvarchar](Max) NULL,
			 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)
		)
end






