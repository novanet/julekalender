SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAnswersForDate]
	@date DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	
		A.[Id],
		A.[DoorId],
		A.[UserId],
		A.[Location],
		A.[Country],
		A.[LocationIsCorrect],
		A.[CountryIsCorrect],
		IIF ((CAST(A.LocationIsCorrect AS INT) + CAST(A.CountryIsCorrect AS INT)) = 2 AND DATEDIFF(second, F.[When], A.[When]) < 3600, 1, 0) as Bonus,
		DATEDIFF(second, F.[When], A.[When]) AS TimeToAnswer,
		F.[When] as OpenedAt,
		A.[When] as AnsweredAt
	FROM [dbo].[Answer] A
	INNER JOIN [dbo].[FirstTimeOpeningDoor] F ON A.UserId = F.UserId AND A.DoorId = F.DoorId
	WHERE CAST(A.[When] as DATE) = @date
	and A.[Id] IN ( select max(id) from [dbo].[Answer] where CAST([When] as DATE) = @date group by [userId])

END
GO