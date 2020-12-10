using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class Attention
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InitHour { get; set; }
        public string FinishHour { get; set; }
        public string State { get; set; }
        public int PatientId { get; set; }
        public Patient Patients { get; set; }
        
    }
}
