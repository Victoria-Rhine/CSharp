CREATE TABLE [dbo].[Homework]
(
	[ID]		 INT IDENTITY (1,1)		NOT NULL,
	[PRIORITY]	 INT					NOT NULL,
	[DATE]		 DATE					NOT NULL,
	[TIME]		 TEXT					NOT NULL,
	[DEPARTMENT] NVARCHAR(64)			NOT NULL,
	[COURSEID]	 INT					NOT NULL,
	[TITLE]		 TEXT					NOT NULL,
	[NOTES]		 TEXT					NOT NULL,
	CONSTRAINT [PK_dbo.Homework] PRIMARY KEY CLUSTERED ([ID])
);

INSERT INTO [dbo].[Homework] (PRIORITY, DATE, TIME, DEPARTMENT, COURSEID, TITLE, NOTES) VALUES
	('1','2019-11-20', '11:59 PM', 'CS', '340', 'Essay', 'Include sources'),
	('2','2018-11-12', '10:00 AM', 'GEOG', '371', 'Forum', '2 paragraphs'),
	('3','2019-12-05', '5:00 PM', 'CS', '365', 'FLASK API', 'Use git branch'),
	('2','2019-11-17', '11:59 PM', 'GEOG', '384', 'Journal', 'Include biographies'),
	('1','2019-10-20', '11:59 PM', 'CS', '340', 'Essay', 'Research 5 topics')

GO