CREATE PROCEDURE [dbo].[SP_GenerateCsv]   
    @initDate DATE,
	@finishDate DATE
AS   
BEGIN
SELECT d.[Name], b.[Id] AS 'Box', a.[Date], COUNT(*) AS 'Patients'
FROM Doctors d
INNER JOIN AttentionDoctors ad ON d.Id = ad.DoctorId
INNER JOIN Attentions a ON a.Id = ad.AttentionId
INNER JOIN AttentionBoxes ab ON ab.AttentionId = a.Id
INNER JOIN Boxes b ON b.Id = ab.BoxId
WHERE a.[Date] >= @initDate
AND a.[Date] <= @finishDate
GROUP BY d.[Name], b.[Id], a.[Date]
ORDER BY a.[Date]
END