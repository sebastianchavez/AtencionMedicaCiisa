using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class Call
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        [Required( ErrorMessage = "Id de atención es requerido")]
        public int AttentionId { get; set; }
        public Attention Attention { get; set; }
    }
}
