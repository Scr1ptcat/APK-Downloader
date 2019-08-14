Use the following query to build the dataset for download:

SELECT TOP (1000) [sha256]
      ,[pkg_name]
      ,[vercode]
      ,[markets]
  FROM [Androzoo APKs].[dbo].[Androzoo APK List - Aug 3rd]  
  WHERE pkg_name in (SELECT pkg_name
				     From [Androzoo APKs].[dbo].[Androzoo APK List - Aug 3rd] 
					 Group BY pkg_name 
					 Having Count(*) > 1 )
 and markets = 'play.google.com'
  order by pkg_name
