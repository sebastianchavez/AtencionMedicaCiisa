using AtencionApi.Context;
using AtencionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtencionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AttentionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Lista de atenciones
        [HttpGet]
        public ActionResult<IEnumerable<Attention>> Get()
        {
            return context.Attentions.Include(x => x.Patients).ToList();
        }

        //Atenciones del día
        [HttpGet("today")]
        public ActionResult<IEnumerable<Attention>> GetToday()
        {
            return context.Attentions.Include(p => p.Patients).Where(a => a.Date == DateTime.Today).ToList();
        }

        [HttpGet("pending")]
        public ActionResult<IEnumerable<AttentionBox>> GetPendingAttention()
        {
            var attentionBoxes = (from a in context.AttentionBoxes
                                                 join b in context.Attentions on a.AttentionId equals b.Id
                                                 join c in context.Boxes on a.BoxId equals c.Id
                                                 where b.State == "PENDING"
                                                 select a).Include(x => x.Attention.Patients).Include(x => x.Box).ToList();

            if(attentionBoxes.Count == 0)
            {
                return NotFound(new { Message = "No hay atenciones pendientes" });
            }



            return attentionBoxes;
        }

        [HttpGet("created")]
        public ActionResult<Attention> GetCreatedAttention()
        {
            return context.Attentions.Include(p => p.Patients).FirstOrDefault(a => a.Date == DateTime.Today && a.State == "CREATED");
        }

        //AtencionApi segun ID
        [HttpGet("{id}", Name = "GetAttentionById")]
        public ActionResult<Attention> GetById(int id)
        {
            return context.Attentions.FirstOrDefault(a => a.Id == id);
        }

        // Crear atencion
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RequestAttention request)
        {
            try
            {
                // Buscar Paciente
                Patient patient = context.Patients.FirstOrDefault(p => p.Id == request.PatientId);
                if(patient == null)
                {
                    return NotFound(new { Message = "No existe paciente" });
                }

                // Buscar Box
                Box box = context.Boxes.FirstOrDefault(b => b.Id == request.BoxId);
                if(box == null)
                {
                    return NotFound(new { Message = "No existe box" });
                }

                // Buscar doctor
                Doctor doctor = context.Doctors.FirstOrDefault(d => d.Id == request.DoctorId);
                if(doctor == null)
                {
                    return NotFound(new { Message = "No existe doctor" });
                }
                
                // Crear atencion
                Attention attention = new Attention() { Date = request.Date, InitHour = request.InitHour, FinishHour = request.FinishHour, PatientId = patient.Id, Patients = patient, State = request.State };
                await context.Attentions.AddAsync(attention);
                context.SaveChanges();
                
                //Crear relaciones box y doctor
                AttentionBox attentionBox = new AttentionBox() { BoxId = request.BoxId, AttentionId = attention.Id, Attention = attention, Box = box };
                await context.AttentionBoxes.AddAsync(attentionBox);
                AttentionDoctor attentionDoctor = new AttentionDoctor() { DoctorId = request.DoctorId, AttentionId = attention.Id, Attention = attention, Doctor = doctor };
                await context.AttentionDoctors.AddAsync(attentionDoctor);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetAttentionById", new { id = attention.Id }, attention);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new NotFoundResult();
            }
        }

        /** Funcion que genera csv segun rango de fechas 
         * Endpoint /api/attentions/report-csv?initDate=12-12-2020&finishDate=12-12-2021
         * @param initDate fecha de inicio
         * @param finishDate fecha de fin */
        [HttpGet("report-csv")]
        public IActionResult Csv(DateTime initDate, DateTime finishDate)
        {
            if (initDate == new DateTime())
            {
                return BadRequest(new { Message = "La fecha de inicio es requerida" });
            }
            if (finishDate == new DateTime())
            {
                return BadRequest(new { Message = "La fecha de termino es requerida" });
            }

            // Ejecución de procedimiento almacenado
            var sql = "exec SP_GenerateCsv @initDate = {0}, @finishDate = {1}";
            var queryResult = context.Csv.FromSqlRaw(sql, initDate, finishDate).ToList();
            if (queryResult.Count() == 0)
            {
                // Si no retorna datos
                return NotFound(new { Message = "No existen registros en este rango de fechas" });
            }

            var sb = new StringBuilder();
            sb.Append("Nombre Doctor;Box;Fecha Atencion;Cantidad pacientes atendidos\r\n");
            queryResult.ForEach(v =>
            {
                sb.Append(v.Name + ";" + v.Box + ";" + v.Date.ToString("dd-MM-yyyy") + ";" + v.Patients + "\r\n");
            });


            /** File es una funcion que se hereda de ControllerBase el cual es necesario pasar el arreglo de bytes correspondiente al archivo
             * el conten-type correspondiente al Header y el nombre con el que quedará el archivo, si examina función esto ya viene con el StatusCode200Ok */
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/csv", "Reporte.csv");
        }
    }

    //Clase Request que valida atencion
    public class RequestAttention
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string InitHour { get; set; }
        [Required]
        public string FinishHour { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int BoxId { get; set; }
        [Required]
        public int DoctorId { get; set; }
    }

    public class AttenttionDetail
    {
        public string NameDoctor { get; set; }
        public Object Attention { get; set; }
    }
}
