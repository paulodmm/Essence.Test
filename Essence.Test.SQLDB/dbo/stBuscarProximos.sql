-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	busca os amigos próximos
-- Execution:	exec stBuscarProximos 1
-- =============================================
CREATE PROCEDURE stBuscarProximos 
	-- Add the parameters for the stored procedure here
	@AmigoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO CalculoHistoricoLog
	SELECT GETDATE() DataInsert, a.AmigoId, b.AmigoId,
		dbo.fnCalcularDistancia(a.Latitude, a.Longitude, b.Latitude,b.Longitude) Distancia
	FROM Amigo a
	INNER JOIN Amigo b on a.AmigoId!=b.AmigoId
	WHERE NOT EXISTS(
		SELECT 1 FROM CalculoHistoricoLog WHERE AmigoId1=a.AmigoId AND AmigoId2=b.AmigoId
		UNION
		SELECT 1 FROM CalculoHistoricoLog WHERE AmigoId2=a.AmigoId AND AmigoId1=b.AmigoId
	)
	AND A.AmigoId=@AmigoId
	
	SELECT DISTINCT TOP 3 AmigoId, Latitude, Longitude, Nome, Distancia
	FROM (
		SELECT a.AmigoId AmigoIdComparar, B.AmigoId, b.Latitude, b.Longitude, b.Nome, C.Calculo as Distancia
		FROM CalculoHistoricoLog C
		INNER JOIN Amigo A ON A.AmigoId=c.AmigoId1
		INNER JOIN Amigo B ON b.AmigoId=c.AmigoId2
		UNION
		SELECT b.AmigoId AmigoIdComparar, a.AmigoId, a.Latitude, a.Longitude, a.Nome, C.Calculo as Distancia
		FROM CalculoHistoricoLog C
		INNER JOIN Amigo A ON A.AmigoId=c.AmigoId1
		INNER JOIN Amigo B ON b.AmigoId=c.AmigoId2
	) AS Calculos
	WHERE AmigoIdComparar=@AmigoId and AmigoId<>@AmigoId
	ORDER BY Distancia
END
GO

