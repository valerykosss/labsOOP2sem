using Lab_11.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.Context
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Library { get; set; }

        public Context() : base("DbConnection")
        { }
    }
}
