using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class spGenerateCsv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SP_GenerateCsv]   
                @initDate DATE,
	            @finishDate DATE
            AS   
            BEGIN
            SELECT d.[Name] AS 'Nombre Doctor', b.[Id] AS 'Box', a.[Date] AS 'Fecha Atencion', COUNT(*) AS 'Cantidad pacientes atendidos'
            FROM Doctors d
            INNER JOIN AttentionDoctors ad ON d.Id = ad.DoctorId
            INNER JOIN Attentions a ON a.Id = ad.AttentionId
            INNER JOIN AttentionBoxes ab ON ab.AttentionId = a.Id
            INNER JOIN Boxes b ON b.Id = ab.BoxId
            INNER JOIN Patients p ON p.Id = a.PatientId	
            WHERE a.[Date] >= @initDate
            AND a.[Date] <= @finishDate
            GROUP BY d.[Name], b.[Id], a.[Date]
            ORDER BY a.[Date]
            END
            ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
