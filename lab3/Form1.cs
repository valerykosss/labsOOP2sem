using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3
{
    public partial class Form1 : Form
    {
        public List<BankAccount> listBankAccount;
        public BankAccount bankAccount;
        public Form1()
        {
            InitializeComponent();
            listBankAccount = new List<BankAccount>();
        }
        private void button1_Click(object sender, EventArgs e)//Добавить
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Вы не ввели номер счета!");
                return;
            }
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Вы не выбрали тип вклада!");
                return;
            }
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Вы не ввели сумму, необходимую положить на счет!");
                return;
            }
            if (textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("")
                || textBox6.Text.Equals(""))
            {
                MessageBox.Show("Заполните ВСЕ поля, содержащие информацию о владельце!");
                return;
            }
            string passportData = textBox6.Text;
            Regex regex = new Regex(@"^[a-zA-Z]{2}\d{7}$");
            Match match = regex.Match(passportData);
            if (!match.Success)
            {
                MessageBox.Show("Неверно введены серия и номер паспорта! Введите еще раз");
                return;
            }
            //ValidatePassportData();
            BankAccount bankAccount = new BankAccount
            {
                DepositNumber = Int32.Parse(textBox1.Text),
                DepositType = comboBox1.Text,
                Balance = Int32.Parse(textBox2.Text),
                AccountCreationDate = dateTimePicker1.Value,
                OwnerInfo = new Owner
                {
                    Name = textBox3.Text,
                    Surname = textBox4.Text,
                    MiddleName = textBox5.Text,
                    PassportInfo = textBox6.Text,
                    DateBirth = dateTimePicker2.Value
                }
            };
            bankAccount.ResultInfo = bankAccount.OwnerInfo.Surname + " " + bankAccount.OwnerInfo.Name +
                " " + bankAccount.OwnerInfo.MiddleName + "; счет:" + bankAccount.DepositNumber +
                "(от" + bankAccount.AccountCreationDate + ") " + bankAccount.DepositType + "; сумма:" +
                bankAccount.Balance + "$ ";
            if (checkBox1.Checked) bankAccount.ResultInfo += "; смс-оповещения";
            if (checkBox2.Checked) bankAccount.ResultInfo += "; интеренет-банкинг";
            if (checkBox3.Checked) bankAccount.ResultInfo += "; 3-D secure";
            listBox1.Items.Add(bankAccount.ResultInfo);
            listBankAccount.Add(bankAccount);

        }
        private void button2_Click(object sender, EventArgs e)//Serialize
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BankAccount>));
            using (FileStream stream = new FileStream("BankNew.xml", FileMode.Truncate))
            {
                serializer.Serialize(stream, listBankAccount);
            }
        }

        private void button3_Click(object sender, EventArgs e)//Deserialize
        {
            List<BankAccount> accounts;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<BankAccount>));
            using (FileStream stream = new FileStream("BankNew.xml", FileMode.Open))
            {
                //bankAccount = serializer.Deserialize(stream) as BankAccount;
                accounts = (List<BankAccount>)deserializer.Deserialize(stream);
            }
            foreach (BankAccount accs in accounts)
            {
                listBox1.Items.Add(accs.ResultInfo);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//Смс-оповещения
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//интернет-банкинг
        {

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)//3-D secure
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//список
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//номер счета
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//тип вклада
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//сумма к поплнению
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)//дата открытия счета
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//имя 
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//фамилия
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//отчество
        {

        }
        /*private void ValidatePassportData()
        {
            string email = textBox6.Text;
            Regex regex = new Regex(@"^[a-zA-Z]{2}\d{7}$");

            Match match = regex.Match(email);
            if (!match.Success)
                MessageBox.Show("Неверно введены серия и номер паспорта");
        }*/
        private void textBox6_TextChanged(object sender, EventArgs e)//данные паспорта
        {

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)//дата рождения владельца
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog(this);
        }

        private void сортироватьПоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ФИО разработчика: Косс Валерия Александровна");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
