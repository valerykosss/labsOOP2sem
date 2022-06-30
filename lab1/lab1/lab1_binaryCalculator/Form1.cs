using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_binaryCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton3.Checked = true;
        }

        /*обработчики событий на кнопках*/
        private void button1_Click(object sender, EventArgs e)//Clear
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\n&\n";//переходы на новые строки отделяют 1 и 2 число, получается 3 строки
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\n|\n";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\n^\n";
        }
        private void button15_Click(object sender, EventArgs e)//~
        {
            textBox1.Text += "\n~";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)//=
        {
            try
            {
                int result = BinaryCalculator.MyParser(textBox1.Lines);
                int intBase = 0;
                if (radioButton1.Checked)
                    intBase = 2;
                else if (radioButton2.Checked)
                    intBase = 8;
                else if (radioButton3.Checked)
                    intBase = 10;
                else if (radioButton4.Checked)
                    intBase = 16;
                textBox1.Clear();
                textBox1.AppendText("=" + Convert.ToString(result, intBase));
            }
            catch (Exception)
            {
                textBox1.Clear();
                textBox1.AppendText("Exception");
            }
        }
    }
    class BinaryCalculator
    {
        public static int AndOperation(int x, int y)
        {
            return (x & y);
        }

        public static int OrOperation(int x, int y)
        {
            return (x | y);
        }

        public static int XorOperation(int x, int y)
        {
            return (x ^ y);
        }
        private static int CountDependingOnOperation(int first, int second, string operation)
        {
            switch (operation[0])
            {
                case '&':
                    return AndOperation(first, second);
                case '|':
                    return OrOperation(first, second);
                case '^':
                    return XorOperation(first, second);
                default:
                    throw new InvalidOperationException();
            }
        }

        public static int MyParser(string[] operandOperantorOperandArray)
        {
            //~operand
            if (operandOperantorOperandArray.Length < 2)
                throw new IndexOutOfRangeException();

            //~
            if (operandOperantorOperandArray[operandOperantorOperandArray.Length - 1][0] == '~')
            {
                if (Int32.TryParse(operandOperantorOperandArray[operandOperantorOperandArray.Length - 2], out int negInt)==true)
                    return ~negInt;
                else
                    throw new InvalidOperationException();
            }


            //operand_operator_operand
            if (operandOperantorOperandArray.Length < 3)
                throw new IndexOutOfRangeException();

            if (Int32.TryParse(operandOperantorOperandArray[operandOperantorOperandArray.Length - 1 - 2], out int firstValue)==true && Int32.TryParse(operandOperantorOperandArray[operandOperantorOperandArray.Length - 1], out int secondValue)==true)
                return CountDependingOnOperation(firstValue, secondValue, operandOperantorOperandArray[operandOperantorOperandArray.Length - 1 - 1]);
            else
                throw new InvalidOperationException();
        }
    }
}

