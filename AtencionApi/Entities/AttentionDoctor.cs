using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class AttentionDoctor
    {
        public int Id { get; set; }
        public int AttentionId { get; set; }
        public int DoctorId { get; set; }
        public Attention Attention { get; set; }
        public Doctor Doctor { get; set; }
    }
}
