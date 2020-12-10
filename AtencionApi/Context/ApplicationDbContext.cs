using AtencionApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtencionApi.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Attention> Attentions { get; set; }
        public DbSet<AttentionBox> AttentionBoxes { get; set; }
        public DbSet<AttentionDoctor> AttentionDoctors { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<Csv> Csv { get; set; }

    }
}
