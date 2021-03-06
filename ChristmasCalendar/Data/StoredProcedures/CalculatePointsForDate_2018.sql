﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CalculatePointsForDate]
	@date DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[DailyScore]([UserId],[DoorId],[Points],[Bonus],[TimeToAnswer],[Rank],[RankMovement],[Year], [NameOfUser])
	SELECT
		A.[UserId],
		A.[DoorId],		
		CAST(A.LocationIsCorrect AS INT) + CAST(A.CountryIsCorrect AS INT) as Points,			
		IIF ((CAST(A.LocationIsCorrect AS INT) + CAST(A.CountryIsCorrect AS INT)) = 2 AND DATEDIFF(second, F.[When], A.[When]) < 3600, 1, 0) as Bonus,
		DATEDIFF(second, F.[When], A.[When]) AS TimeToAnswer,
		1 as [Rank],
		0 as [RankMovement],
		YEAR(GETDATE()) as [Year],
		U.[Name] as [NameOfUser]
		FROM [dbo].[Answer] A
	INNER JOIN [dbo].[FirstTimeOpeningDoor] F ON A.UserId = F.UserId AND A.DoorId = F.DoorId
	INNER JOIN [dbo].[AspNetUsers] U ON U.Id = A.UserId
	WHERE CAST(A.[When] as DATE) = @date
	AND A.[Id] IN ( select max(id) from [dbo].[Answer] where CAST([When] as DATE) = @date group by [userId])

	DELETE FROM [dbo].[DailyScoreLastUpdated]
	INSERT INTO [dbo].[DailyScoreLastUpdated]([LastUpdated]) VALUES (@date)
END
GO