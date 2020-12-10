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
    public class CallsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CallsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Call>> Get()
        {
            return context.Calls.ToList();
        }
        // Buscar segun ID
        [HttpGet("{id}", Name = "GetCallById")]
        public ActionResult<Call> GetById(int id)
        {
            return context.Calls.FirstOrDefault(c => c.Id == id);
        }

        // Crear llamado
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Call call)
        {
            try
            {
                Attention attention = context.Attentions.FirstOrDefault(a => a.Id == call.AttentionId);
                if(attention == null)
                {
                    return BadRequest();
                }

                call.State = "CREATED";

                await context.Calls.AddAsync(call);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetCallById", new { id = call.Id }, call);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }

        // Buscar llamado pendiente
        [HttpGet("pending")]
        public ActionResult<Call> GetPendingCalls()
        {
            return context.Calls.FirstOrDefault(x => x.State == "PENDING");
        }

        // buscar llamado
        [HttpGet("created")]
        public ActionResult<Object> GetCreatedCalls()
        {
            Call call = context.Calls.Include(x => x.Attention.Patients).FirstOrDefault(x => x.State == "CREATED");
            if(call == null)
            {
                return NotFound();
            }

            AttentionBox attentionBox = context.AttentionBoxes.Include(x => x.Box).FirstOrDefault(x => x.AttentionId == call.AttentionId);
            if(attentionBox == null)
            {
                return NotFound();
            }

            AttentionDoctor attentionDoctor = context.AttentionDoctors.Include(x => x.Doctor).FirstOrDefault(x => x.AttentionId == call.Attention.Id);

            return new { call, attentionBox, attentionDoctor };
        }

        // Actualizar llamado
        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            Call call = context.Calls.FirstOrDefault(c => c.Id == id);
            if(call == null)
            {
                return NotFound(new { Message = "No existe llamado" });
            }

            Attention attention = context.Attentions.FirstOrDefault(a => a.Id == call.AttentionId);
            if(attention == null)
            {
                return NotFound(new { Message = "No existe atención" });
            }

            call.State = "CALL";
            attention.State = "PENDING";

            context.Entry(call).State = EntityState.Modified;
            context.Entry(attention).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("generate")]
        public ActionResult<Call> GenerateCall([FromBody]Call request)
        {
                Attention attention = context.Attentions.FirstOrDefault(x => x.Id == request.AttentionId);
            if(attention == null)
            {
                return NotFound(new { Message = "No existe atención" });
            }

            Call call = new Call() { AttentionId = request.AttentionId, Date = DateTime.Now, State = "CREATED", Attention = attention };
            context.Calls.Add(call);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetCallById", new { id = call.Id }, call);
        }

    }
}
