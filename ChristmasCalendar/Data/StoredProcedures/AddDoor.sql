DECLARE @guid UNIQUEIDENTIFIER
SET @guid = NEWID()

INSERT INTO [dbo].[Door]
           ([Country]
           ,[Location]
           ,[ImagePath]
           ,[ForDate]
           ,[Number]
           ,[Description]
           ,[PointsForCountry]
           ,[PointsForLocation])
     VALUES
           ('Sverige'
           ,'Nord-Koster'
           ,'https://julekalender.blob.core.windows.net/2019/' + cast(@guid as varchar(100)) +'.jpg'
           ,'2019-12-20'
           ,15
           ,'Kategori: Vanskelig'
           ,1
           ,3)


SELECT @guid