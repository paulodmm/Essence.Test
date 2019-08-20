CREATE TABLE [dbo].[CalculoHistoricoLog]
(
	[CalculoHistoricoLogId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataInclusao] Datetime NOT NULL, 
    [AmigoId1] INT NOT NULL, 
    [AmigoId2] INT NOT NULL, 
    [Calculo] FLOAT NOT NULL
)
