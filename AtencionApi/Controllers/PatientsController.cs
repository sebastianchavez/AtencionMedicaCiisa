using AtencionApi.Context;
using AtencionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PatientsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            return context.Patients.ToList();
        }
        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<Patient> GetById(int id)
        {
            return context.Patients.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetPatientById", new { id = patient.Id }, patient);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            context.Entry(patient).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
    }
}
