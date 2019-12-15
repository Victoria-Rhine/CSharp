ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_dbo.Athletes_ID];
DROP TABLE [dbo].[Athletes];

ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Coaches_ID];
DROP TABLE [dbo].[Coaches];

ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_dbo.Events_ID];
DROP TABLE [dbo].[Events];

ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_dbo.LocationDetails_ID];
DROP TABLE [dbo].[LocationDetails];

DROP TABLE [dbo].[Teams];

DROP TABLE [dbo].[Results];




