using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
        public  string Speciality { get; set; }
    }
}
