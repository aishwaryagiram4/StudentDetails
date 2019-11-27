CREATE TABLE [dbo].[LoginTable] (
    [EmailId]    VARCHAR (100) NOT NULL,
    [Password]   VARCHAR (100) NOT NULL,
    [CratedDate] DATETIME      DEFAULT (getdate()) NOT NULL
);

