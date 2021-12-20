using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//МИХАЛИШИН ЕГОР ОЛЕГОВИЧ ГР.4301-21
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int Fd = 0;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add($"Column{NumberUpDown1.Value}", $"F {NumberUpDown1.Value}");
        }

        void Form1_Load(object sender, EventArgs e)
        {

        }

        //определяет количество строк то есть количество переменных
        void kolvo_strok(object sender, EventArgs e)
        {
                for (int i = 0; i < Math.Pow(2, (Convert.ToInt32(NumberUpDown1.Value) - 1)); i++)
                {
                    if (Convert.ToInt32(NumberUpDown1.Value) == 1)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows.Add();
                    }
                    else
                    {
                        dataGridView1.Rows.Add();
                    }
                }
            Fd = Convert.ToInt32(NumberUpDown1.Value);
        }

        //вычисление СДНФ
        void SDNF_Click(object sender, EventArgs e)
        {
            string bd = "";
            string b = "";
            for(int i = 0; i < Math.Pow(2, (Convert.ToInt32(Fd))); i++)
            {
                bd = "";
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == 1)
                {
                    b += "(";
                    bd = Convert.ToString(i, 2);
                    if (bd.Length != Convert.ToString(Convert.ToInt32(Math.Pow(2, (Fd))), 2).Length)
                    {
                        for(int q = 0; true; q++)
                        {
                            if(bd.Length+1 == Convert.ToString(Convert.ToInt32(Math.Pow(2, (Fd))), 2).Length)
                            {
                                break;
                            }
                            bd = "0" + bd;
                        }
                    }
                    for (int j = 0; j < Fd; j++)
                    {
                        if (bd[j] == '0')
                        {
                            b += "!X" + (j + 1);
                        }
                        else
                        {
                            b += "X" + (j + 1);
                        }
                        if(j+1 != Fd)
                        {
                            b += "";
                        }   
                    }
                    b += ")";
                }
                if(i != Math.Pow(2, (Convert.ToInt32(Fd))))
                {
                    b += "V";
                }
            }
            for(int i = 0; i<b.Length; i++)
            {
                if(b[0] == 'V')
                {
                    b = b.Remove(0, 1);
                }
                if(b[b.Length-1] == 'V')
                {
                    b = b.Remove(b.Length-1, 1);
                }
                if(b[i] == 'V' && b[i+1] == 'V')
                {
                    b = b.Remove(i, 1);
                    i -= 1;
                }
            }
            label2.Text =  b; 
        }

        //вычислениее СКНФ
        void SKNF_Click(object sender, EventArgs e)
        {
            string bd = "";
            string b = "";
            for (int i = 0; i < Math.Pow(2, (Convert.ToInt32(Fd))); i++)
            {
                bd = "";
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == 0)
                {
                    b += "(";
                    bd = Convert.ToString(i, 2);
                    if (bd.Length != Convert.ToString(Convert.ToInt32(Math.Pow(2, (Fd))), 2).Length)
                    {
                        for (int q = 0; true; q++)
                        {
                            if (bd.Length + 1 == Convert.ToString(Convert.ToInt32(Math.Pow(2, (Fd))), 2).Length)
                            {
                                break;
                            }
                            bd = "0" + bd;
                        }
                    }
                    for (int j = 0; j < Fd; j++)
                    {
                        if (bd[j] == '0')
                        {
                            b += "X" + (j + 1);
                        }
                        else
                        {
                            b += "!X" + (j + 1);
                        }
                        if (j + 1 != Fd)
                        {
                            b += "V";
                        }
                    }
                    b += ")";
                }
                if (i != Math.Pow(2, (Convert.ToInt32(Fd))))
                {
                    b += "V";
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                if (b[0] == 'V')
                {
                    b = b.Remove(0, 1);
                }
                if (b[b.Length - 1] == 'V')
                {
                    b = b.Remove(b.Length - 1, 1);
                }
                if (b[i] == 'V' && b[i + 1] == 'V')
                {
                    b = b.Remove(i, 1);
                    i -= 1;
                }
            }
            label2.Text = b;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    }
}
