using AtencionApi.Context;
using AtencionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ParamsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet( Name = "GetParam")]
        public ActionResult<Param> Get()
        {
            Param param = context.Params.OrderByDescending(p => p.Id).FirstOrDefault();
            if(param == null)
            {
                return NotFound(new { Message = "No existen parametros" });
            }
            return param;
        }

        [HttpPost]
        public ActionResult<Param> Post([FromBody]Param param)
        {
            context.Params.Add(param);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetParam", new { id = param.Id }, param);
        }
    }
}
