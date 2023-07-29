using CarbonFilter.Models;
using System.Text.Json;

namespace CarbonFilterAPI.Files
{
    public class SampleQueries
    {
        public List<Response> CreateSampleResponse()
        {
            List<Response> reponses = new List<Response>();

            Response response1 = new Response();
            response1.ResponseId = 1;
            response1.QuestionId = 1;
            //response1.PickListItemId = 1;
            response1.DropDownOptionId = 1;
            reponses.Add(response1);

            Response response2 = new Response();
            response2.ResponseId = 1;
            response2.QuestionId = 2;
            response2.PickListItemId = 2;
            response2.DropDownOptionId = 14;
            reponses.Add(response2);

            Response response3 = new Response();
            response3.ResponseId = 1;
            response3.QuestionId = 3;
            response3.PickListItemId = 5;
            response3.DropDownOptionId = 24;
            reponses.Add(response3);

            Response response4 = new Response();
            response4.ResponseId = 1;
            response4.QuestionId = 4;
            response4.PickListItemId = 9;
            response4.DropDownOptionId = 30;
            reponses.Add(response4);

            Response response5 = new Response();
            response5.ResponseId = 1;
            response5.QuestionId = 5;
            response5.PickListItemId = 13;
            response5.DropDownOptionId = 40;
            reponses.Add(response5);

            Response response6 = new Response();
            response6.ResponseId = 1;
            response6.QuestionId = 6;
            response6.PickListItemId = 17;
            response6.DropDownOptionId = 50;
            reponses.Add(response6);

            Response response7 = new Response();
            response7.ResponseId = 1;
            response7.QuestionId = 7;
            //response7.PickListItemId = 5;
            response7.DropDownOptionId = 55;
            reponses.Add(response7);

            Response response8 = new Response();
            response8.ResponseId = 1;
            response8.QuestionId = 8;
            //response8.PickListItemId = 5;
            response8.DropDownOptionId = 65;
            reponses.Add(response8);

            Response response9 = new Response();
            response9.ResponseId = 1;
            response9.QuestionId = 9;
            //response9.PickListItemId = 5;
            response9.DropDownOptionId = 70;
            reponses.Add(response9);

            Response response10 = new Response();
            response10.ResponseId = 1;
            response10.QuestionId = 10;
            response10.PickListItemId = 5;
            //response10.DropDownOptionId = 24;
            reponses.Add(response10);

            return reponses;
        }

        public string GetSampleResponse()
        {
            return JsonSerializer.Serialize(CreateSampleResponse()).ToString();
        }
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
SELECT PickListItemName FROM PickListItems WHERE @QuestionId = QuestionId


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
LEFT JOIN PickListItems P on Q.QuestionId = P.QuestionId
LEFT JOIN DropDowns D on Q.DropDownId = D.DropDownId
LEFT JOIN DropDownOptions DO on DO.DropDownId = D.DropDownId


SELECT 
CategoryName,
QuestionNum,
QuestionName,
PickListItemName
FROM Categories C
INNER JOIN Questions Q on Q.CategoryId = C.CategoryId
LEFT JOIN PickListItems P on Q.QuestionId = P.QuestionId

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
