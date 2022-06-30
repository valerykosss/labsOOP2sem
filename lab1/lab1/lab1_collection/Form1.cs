using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_collection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int enteredCollectionSize;
        List<int> collection = new List<int>();
        Func<int, int, bool> delForTwoCollectionMember;

        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;//sets the character corresponding to the key pressed
            if (!Char.IsDigit(number) && !Char.IsControl(e.KeyChar)) // если не цифры и клавиша BackSpace
            {
                e.Handled = true; // для остановки последующего движения информации о событии
            }
        }

        //сгенерировать коллекцию
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                enteredCollectionSize = Convert.ToInt32(textBox1.Text);
                textBox2.Clear();
                textBox3.Clear();
                if (enteredCollectionSize >= 1 && enteredCollectionSize <= 20)
                {
                    collection.Clear();
                    Random random = new Random();
                    for (int i = 0; i < enteredCollectionSize; i++)
                    {
                        collection.Add(random.Next(1, 200));
                        textBox2.Text += "Площадь квадрата " + collection[i] + " см^2" + "\r\n";
                    }
                }
                else if (enteredCollectionSize == 0)
                {
                    textBox2.Text = "Коллекция не может состоять из 0 элементов!";
                }
                else
                {
                    textBox2.Text = "Максимальный допустимый размер коллекции 20";
                }
            }
            else
            {
                textBox2.Text = "Вы не ввели размер коллекции";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.Text = "Сортировка размерностей площадей квадрата по возрастанию:" + "\r\n";
            delForTwoCollectionMember = IsFirstMore;
            Sort(collection, delForTwoCollectionMember);
            for (int i = 0; i < enteredCollectionSize; i++)
            {
                textBox3.Text += "Площадь квадрата " + collection[i] + " см^2" + "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.Text = "Сортировка размерностей площадей квадрата по убыванию:" + "\r\n";
            delForTwoCollectionMember = IsFirstLess;
            Sort(collection, delForTwoCollectionMember);
            for (int i = 0; i < enteredCollectionSize; i++)
            {
                textBox3.Text += "Площадь квадрата " + collection[i] + " см^2" + "\r\n";
            }
        }

        static void Sort(List<int> list, Func<int, int, bool> del)
        {
            int temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (del(list[i], list[j]))
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        bool IsFirstMore(int i, int j)
        {
            return i > j;
        }

        bool IsFirstLess(int i, int j)
        {
            return i < j;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int maxSquare = collection.Max();
            textBox3.Text = "Наибольшая площадь квадрата равна " + maxSquare + " см^2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int minSquare = collection.Min();
            textBox3.Text = "Наименьшая площадь квадрата равна " + minSquare + " см^2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Отсортированные значения площадей в диапазоне 40-80 см^2" + "\r\n";
            var values = collection.Where(collectionItem => (collectionItem >= 40 && collectionItem <= 80))
                                   .OrderBy(n => n);
            foreach (int value in values)
            {
                textBox3.Text += value + "\r\n";
            }
        }
    }
}
