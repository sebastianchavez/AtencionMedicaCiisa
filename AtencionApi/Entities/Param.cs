using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class Param
    {
        public int Id { get; set; }
        public int TimerCall { get; set; }
        public int TimerViewCall { get; set; }
    }
}
