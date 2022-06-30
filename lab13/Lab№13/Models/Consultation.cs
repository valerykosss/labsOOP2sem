using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Count { get; set; }
    }
}
