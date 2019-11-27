SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CalculatePointsForDate]
	@date DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[DailyScore]([UserId],[DoorId],[DoorNumber],[Points],[Bonus],[TimeToAnswer],[Year], [NameOfUser], [Rank])
	
	SELECT *, ROW_NUMBER() OVER(PARTITION BY X.[UserId] ORDER BY X.Points DESC) as [Rank]
	FROM (
		SELECT
			A.[UserId],
			A.[DoorId],	
			D.[Number] as 'DoorNumber',	
			CAST(A.LocationIsCorrect AS INT)*D.PointsForLocation + CAST(A.CountryIsCorrect AS INT) as Points,			
			0 as [Bonus],
			DATEDIFF(second, F.[When], A.[When]) AS TimeToAnswer,
			YEAR(GETDATE()) as [Year],
			U.[Name] as [NameOfUser]
			FROM [dbo].[Answer] A
		INNER JOIN [dbo].[Door] D ON D.Id = A.DoorId
		INNER JOIN [dbo].[FirstTimeOpeningDoor] F ON A.UserId = F.UserId AND A.DoorId = F.DoorId
		INNER JOIN [dbo].[AspNetUsers] U ON U.Id = A.UserId
		WHERE CAST(A.[When] as DATE) = @date
		AND A.[Id] IN ( select max(id) from [dbo].[Answer] where CAST([When] as DATE) = @date group by [userId])
	) X

	DELETE FROM [dbo].[DailyScoreLastUpdated]
	INSERT INTO [dbo].[DailyScoreLastUpdated]([LastUpdated]) VALUES (@date)
END
GO