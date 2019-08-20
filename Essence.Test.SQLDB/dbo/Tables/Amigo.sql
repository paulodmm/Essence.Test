CREATE TABLE [dbo].[Amigo] (
    [AmigoId]   INT            NOT NULL IDENTITY,
    [Nome]      NVARCHAR (255) NOT NULL,
    [Latitude]  FLOAT (53)     NOT NULL,
    [Longitude] FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([AmigoId] ASC)
);

