using AtencionApi.Context;
using AtencionApi.Entities;
using AtencionApi.Helpers;
using CsvHelper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AtencionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly EncryptingAttribute encrypting;
        public DoctorsController(ApplicationDbContext context)
        {
            this.context = context;
            this.encrypting = new EncryptingAttribute();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> Get()
        {
            return context.Doctors.ToList();
        }

        [HttpGet("{id}", Name = "GetDoctorById")]
        public ActionResult<Doctor> GetById(int id)
        {
            return context.Doctors.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Doctor>> GetByName(string name)
        {
            return FindDoctor(name);
        }

        [HttpGet("name/{name}/speciality/{speciality}")]
        public ActionResult<IEnumerable<Doctor>> GetByNameAndSpecility(string name, string speciality)
        {
            return FindDoctor(name, speciality);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetDoctorById", new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]Doctor doctor)
        {
            doctor.Password = encrypting.EncryptMD5(doctor.Password);
            context.Doctors.Add(doctor);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetDoctorById", new { id = doctor.Id }, doctor);
        }

        [HttpPost("login")]
        public ActionResult<Doctor> Login([FromBody]RequestLogin request)
        {
            Doctor doctor = context.Doctors.FirstOrDefault(x => x.User == request.user);
            if(doctor == null)
            {
                return NotFound(new { Message= "Usuario invalido" });
            }

            if (doctor.Password != encrypting.EncryptMD5(request.password))
            {
                return BadRequest(new { Message = "Contraseña invalida"});
            }

            return doctor;
        }

        [HttpGet("csv")]
        public IActionResult Csv()
        {
            var sb = new StringBuilder();

            //context.Doctors.ToList();
            sb.Append("Nombre Doctor;Box;Fecha Atencion;Cantidad pacientes atendidos\r\n");
            



            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/csv", "asd.csv");
        }

        // Funciones con sobrecarga
        public List<Doctor> FindDoctor(string name)
        {
            return context.Doctors.Include(x=> x.Name == name).ToList();
        }
        public List<Doctor> FindDoctor(string name, string speciality)
        {
            return context.Doctors.Include(x=> x.Name == name && x.Speciality == speciality).ToList();
        }

    }

    public class RequestLogin
    {
        [Required( ErrorMessage = "El usuario es requerido")]
        public string user { get; set; }
        [Required( ErrorMessage = "La contraseña es requerida")]
        public string password { get; set; }
    }

    public class Record
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Tickets { get; set; }
    }
}
