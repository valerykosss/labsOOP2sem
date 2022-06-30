using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    [Serializable]
    public class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PassportInfo { get; set; }
        public DateTime DateBirth { get; set; }

    }
}
