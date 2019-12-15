CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] NVARCHAR(50)
);

BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\torir\Desktop\CS-460\CS460-F19-Victoria-Rhine\HW8\SportsSite\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);