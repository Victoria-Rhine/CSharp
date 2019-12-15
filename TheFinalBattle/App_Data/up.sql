CREATE TABLE [dbo].[Persons]
(
	[ID]			INT IDENTITY(1,1) NOT NULL,
	[Name]			NVARCHAR(50)	   NOT NULL,			  
	CONSTRAINT [PK_dbo.Persons] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Events]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Title]			NVARCHAR(50)		NOT NULL,
	[Start]			DATETIME			NOT NULL,
	[Duration]		INT					NOT NULL,
	[Location]		NVARCHAR(50)		NOT NULL,
	[PersonID]		INT					NOT NULL,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RSVP_dbo.Persons_ID2] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]),	
);

CREATE TABLE [dbo].[RSVP]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Timestamp]		DATETIME			NOT NULL,
	[EventID]		INT					NOT NULL,
	[PersonID]		INT					NOT NULL,	
	CONSTRAINT [PK_dbo.RSVP] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RSVP_dbo.Events_ID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID]),
	CONSTRAINT [FK_dbo.RSVP_dbo.Persons_ID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Persons] ([ID]),	
);
            