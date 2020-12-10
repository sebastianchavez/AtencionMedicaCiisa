using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class Csv
    {
        [Key]
        public string Name { get; set; }
        public int Box { get; set; }
        public DateTime Date { get; set; }
        public int Patients { get; set; }
    }
}
