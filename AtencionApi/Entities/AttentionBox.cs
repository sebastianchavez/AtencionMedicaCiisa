using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class AttentionBox
    {
        public int Id { get; set; }
        public int AttentionId { get; set; }
        public int BoxId { get; set; }
        public Attention Attention { get; set; }
        public Box Box { get; set; }
    }
}
