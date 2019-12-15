ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_dbo.RSVP_dbo.Persons_ID2];
ALTER TABLE [dbo].[RSVP] DROP CONSTRAINT [FK_dbo.RSVP_dbo.Persons_ID];
ALTER TABLE [dbo].[RSVP] DROP CONSTRAINT [FK_dbo.RSVP_dbo.Events_ID];

DROP TABLE [dbo].[Events];
DROP TABLE [dbo].[Persons];
DROP TABLE [dbo].[RSVP];