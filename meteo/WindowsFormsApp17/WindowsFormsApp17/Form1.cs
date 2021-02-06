using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            serialPort1.Open();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String txt= serialPort1.ReadLine();

            using (FileStream fstream = new FileStream($"note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(txt+" "+DateTime.Now);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            char q = txt[0];
            switch(q)
            {
                case 'T':label1.Text = txt.Substring(0);break;
                case 'H': label2.Text = txt.Substring(0); break;
                case 'R':
                    if(txt.Equals("R1\r"))
                    {
                        label3.Text = "Идет дождь";
                    }
                    else
                    {
                        label3.Text = "Дождя нет";
                    }
                     break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            serialPort1.Close();

        }
    }
}
