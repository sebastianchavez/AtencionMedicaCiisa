using AtencionApi.Context;
using AtencionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BoxesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Box>> Get()
        {
            return context.Boxes.ToList();
        }

        [HttpGet("{id}", Name = "GetBoxById")]
        public ActionResult<Box> GetById(int id)
        {
            return context.Boxes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Box box)
        {
            context.Boxes.Add(box);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetBoxById", new { id = box.Id }, box);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Box box)
        {
            if (id != box.Id)
            {
                return BadRequest();
            }

            context.Entry(box).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
    }

    
}
