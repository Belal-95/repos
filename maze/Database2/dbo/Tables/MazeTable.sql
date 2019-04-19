CREATE TABLE [dbo].[MazeTable] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [deposit]   INT          NOT NULL,
    [widthrawl] INT          NOT NULL,
    [reasons]   VARCHAR (50) NOT NULL,
    [remains]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)

);
--insert into MazeTable values (5555,666,'hh',88);
