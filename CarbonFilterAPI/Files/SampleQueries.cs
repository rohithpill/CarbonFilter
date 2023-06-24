namespace CarbonFilterAPI.Files
{
    public class SampleQueries
    {
        public static string GetQuestionPickList()
        {
            return
@"IF EXISTS (SELECT 1 FROM sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[GetQuestionPickList]'))
BEGIN
	DROP FUNCTION [dbo].[GetQuestionPickList]
END

GO

CREATE FUNCTION GetQuestionPickList
(@QuestionId as INT)
RETURNS TABLE
AS
RETURN
SELECT PickListItemName FROM PickLists WHERE @QuestionId = QuestionId


GO

--SELECT * FROM GetQuestionPickList(2);

GO";
        }

        public static string GetQuestionDropDownOptions()
        {
            return
@"IF EXISTS (SELECT 1 FROM sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[GetQuestionDropDownOptions]'))
BEGIN
	DROP FUNCTION [dbo].GetQuestionDropDownOptions
END

GO

CREATE FUNCTION GetQuestionDropDownOptions
(@QuestionId as INT)
RETURNS TABLE
AS
RETURN
SELECT 
CAST(CAST(MinValue AS INT) AS NVARCHAR)  + 
CASE WHEN MaxValue IS NULL THEN  '' ELSE ' - ' + CAST(CAST(MaxValue AS INT) AS NVARCHAR) END
+ ' ' + ISNULL(DropDownUnit, '') AS 'Range' 
FROM Questions Q 
INNER JOIN DropDowns D on Q.DropDownId = D.DropDownId
INNER JOIN DropDownOptions DO on DO.DropDownId = D.DropDownId
WHERE @QuestionId = Q.QuestionId

GO

--SELECT * FROM GetQuestionDropDownOptions(5);

GO";
        }

        public static string TestQueries()
        {
            return
@"SELECT 
CategoryName,
QuestionNum,
QuestionName,
PickListItemName,
--MinValue, MaxValue, DropDownUnit,
CAST(CAST(MinValue AS INT) AS NVARCHAR)  + 
CASE WHEN MaxValue IS NULL THEN  '' ELSE ' - ' + CAST(CAST(MaxValue AS INT) AS NVARCHAR) END
+ ' ' + ISNULL(DropDownUnit, '') AS 'Range'

FROM Categories C
INNER JOIN Questions Q on Q.CategoryId = C.CategoryId
LEFT JOIN PickLists P on Q.QuestionId = P.QuestionId
LEFT JOIN DropDowns D on Q.DropDownId = D.DropDownId
LEFT JOIN DropDownOptions DO on DO.DropDownId = D.DropDownId


SELECT 
CategoryName,
QuestionNum,
QuestionName,
PickListItemName
FROM Categories C
INNER JOIN Questions Q on Q.CategoryId = C.CategoryId
LEFT JOIN PickLists P on Q.QuestionId = P.QuestionId

SELECT 
CategoryName,
QuestionNum,
QuestionName,
CAST(CAST(MinValue AS INT) AS NVARCHAR)  + 
CASE WHEN MaxValue IS NULL THEN  '' ELSE ' - ' + CAST(CAST(MaxValue AS INT) AS NVARCHAR) END
+ ' ' + ISNULL(DropDownUnit, '') AS 'Range'
FROM Categories C
INNER JOIN Questions Q on Q.CategoryId = C.CategoryId
LEFT JOIN DropDowns D on Q.DropDownId = D.DropDownId
LEFT JOIN DropDownOptions DO on DO.DropDownId = D.DropDownId";
        }
    }
}
