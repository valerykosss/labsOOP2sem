using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace lab3
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex myRegex = new Regex(textBox1.Text);

            //BankAccount bankAccount = null;
            List<BankAccount> accounts;
            XmlSerializer deser = new XmlSerializer(typeof(List<BankAccount>));
            using (FileStream stream = new FileStream("BankNew.xml", FileMode.Open))
            {
                //bankAccount = deserializer.Deserialize(stream) as BankAccount;
                accounts = (List<BankAccount>)deser.Deserialize(stream);
            }
            listBox1.Items.Clear();
            List<BankAccount> searchResult = new List<BankAccount>();
            foreach (BankAccount accs in accounts)
            {
                if (myRegex.IsMatch(accs.ResultInfo))
                {
                    int balanceFromTextBox, depositNumberFromTextBox;
                    StringBuilder fio = new StringBuilder(accs.OwnerInfo.Surname);
                    fio.Append(" ");
                    fio.Append(accs.OwnerInfo.Name);
                    fio.Append(" ");
                    fio.Append(accs.OwnerInfo.MiddleName);
                    if (checkBox1.Checked)
                    {
                        /*if (comboBox1.Text != accs.DepositType)//по типу вклада
                            continue;*/
                        if (textBox2.Text.Length > 0 && textBox2.Text != fio.ToString())
                            continue;
                        if (textBox3.Text.Length > 0 && (balanceFromTextBox = int.Parse(textBox3.Text)) != accs.Balance)
                            continue;
                        if (textBox4.Text.Length > 0 && (depositNumberFromTextBox = int.Parse(textBox4.Text)) != accs.DepositNumber)
                            continue;
                        
                    }
                    searchResult.Add(accs);
                    //listBox1.Items.Add(accs.ResultInfo);
                }
            }
            IEnumerable<BankAccount> ordered = null;
            if (domainUpDown1.Text == "По номеру депозита")
                ordered = searchResult.OrderBy(p => p.DepositNumber);
            else
                ordered = searchResult.OrderBy(p => p.Balance);
            foreach (BankAccount item in ordered)
                listBox1.Items.Add(item.ResultInfo);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
