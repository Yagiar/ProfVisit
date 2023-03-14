using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Policy;

namespace ProfilVisit
{
    public partial class Start : Form
    { 
        
        public Start()
        {
            InitializeComponent();
        }
        Inspector inspector;
        TextBox[] tb;
        List<punct> list;
        int CountNumbers;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Thread t2 = new Thread(MyException);
            t2.Start();
        }
        
        private bool CheckTb()
        {
            if (button1.Enabled == false)
            {
                foreach (TextBox tbs in tb)
                {
                    if (tbs.Text == "")
                    {
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
        private void StartProver_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxObject.Text != "" && textBoxOrgan.Text != "" && textBoxObject.Text != ""&&CheckTb())
            {
                list = new List<punct>();
                inspector = new Inspector(textBoxName.Text, textBoxObject.Text, textBoxOrgan.Text, label7.Text);
                foreach(TextBox tbs in tb)
                {
                    punct p = new punct();
                    p.Name = tbs.Text;
                    list.Add(p);
                }
                inspector.StartReport(list);
                DoReport doReport = new DoReport(inspector,CountNumbers);
                doReport.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте коррекность ввода данных");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxCount.Text!="")
            {
                try
                {
                    CountNumbers = Convert.ToInt32(textBoxCount.Text);
                    tb = new TextBox[CountNumbers];
                    for (int i = 0; i < CountNumbers; i++)
                    {
                        Label label = new Label();
                        label.Left = 10;
                        label.Width = 20;
                        label.Height = 12;
                        label.Top = 190 + i * 28;
                        label.Text = (i + 1).ToString();
                        label.Visible = true;
                        label.ForeColor = Color.Black;
                        label.Parent = this;
                        tb[i] = new TextBox();
                        tb[i].Width = 100;
                        tb[i].Height = 22;
                        tb[i].Left = 34;
                        tb[i].Top = 186 + i * 28;
                        tb[i].Parent = this;
                    }
                    Refresh();
                    button1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Проверьте коррекность ввода данных");
                }
            }
        }

        void MyException()
        {
            MessageBox.Show("Здравствуйте, инспектор");
        }

        
    }
}
