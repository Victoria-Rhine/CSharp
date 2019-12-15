INSERT INTO [dbo].[Persons](Name)
	VALUES
	('Julie Morgan'),
	('Horacio Gutierrez'),
	('James Bond'),
	('Diana Prince'),
	('Baby Yoda'),
	('Peter Rabbit');

INSERT INTO [dbo].[Events](Title, Start, Duration, Location, PersonID)
	VALUES
	('Ghirardelli Wedding', '01/20/2020 12:00:00', 4, 'State Street Event Center', 1),
	('Spy Retirement Banquet', '04/12/2020 17:00:00', 7, 'United Artists Headquarters', 2),
	('Bachelorette Party', '06/05/2020 19:00:00', 9, 'The Amado', 1);

INSERT INTO [dbo].[RSVP](Timestamp, EventID, PersonID)
	VALUES
	('12/05/2019 09:12:45', 1, 6),
	('11/14/2019 20:01:02', 1, 4),
	('10/05/2019 19:27:16', 2, 3),
	('12/01/2019 12:12:12', 3, 5),
	('12/02/2019 06:07:08',  3, 4);