using Lab_13.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13.Context
{
    public class Context : DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }

        public Context() : base("DbConnection")
        { }
    }
}
