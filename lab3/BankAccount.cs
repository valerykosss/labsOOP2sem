using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    [Serializable]
    public class BankAccount
    {
        public int DepositNumber { get; set; }
        public string DepositType { get; set; }
        public int Balance { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public Owner OwnerInfo { get; set; }
        public string ResultInfo { get; set; }
    }
}