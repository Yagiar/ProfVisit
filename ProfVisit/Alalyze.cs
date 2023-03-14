using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfilVisit
{
    public partial class Alalyze : Form
    {
        Label LabelNumber,label1;
        TextBox tb;
        Inspector inspector;
        RadioButton rb1,rb2,rb3;
        List<RadioButton> rbs =new List<RadioButton>();
        int num,CountNumbers;
        public Alalyze(int number, Inspector ins,int count)
        {
            inspector = ins;
            num = number;
            CountNumbers = count;
            InitializeComponent();
            LabelNumber = new Label();
            LabelNumber.Height = 20;
            LabelNumber.Width = 200;
            LabelNumber.Text = (number+1).ToString() + " " + inspector.GetList()[number].Name.ToString();
            LabelNumber.Left = 12;
            LabelNumber.Top = 20;
            LabelNumber.Parent = this;
            
            rb1=new RadioButton();
            rb1.Text = "Все в порядке";
            rb1.Name = "1";
            rb1.Left = 12;
            rb1.Top = 40;
            rb1.Checked = false;
            rb1.Height = 20;
            rb1.Click += new EventHandler(CheckRadio);
            rb1.Parent = this;

            rb2 = new RadioButton();
            rb2.Text = "Дать рекомендацию";
            rb2.Width = 200;
            rb2.Name= "2";
            rb2.Left = 12;
            rb2.Top = 40 + 20;
            rb2.Checked = false;
            rb2.Height = 20;
            rb2.Click += new EventHandler(CheckRadio);
            rb2.Parent = this;

            rb3 = new RadioButton();
            rb3.Width = 200;
            rb3.AutoSize = false;
            rb3.Text = "Непосредственное нарушение!";
            rb3.Name= "3";
            rb3.Left = 12;
            rb3.Top = 40 + 40;
            rb3.Checked = false;
            rb3.Height = 20;
            rb3.Click += new EventHandler(CheckRadio);
            rb3.Parent = this;

            label1=new Label();
            label1.Left = 12;
            label1.Top = 100;
            label1.Height = 20;
            label1.Text = "Описание:";
            label1.Visible = false;
            label1.Parent = this;
            
            rbs.Add(rb1);
            rbs.Add(rb2);
            rbs.Add(rb3);

            tb = new TextBox();
            tb.Left = 12;
            tb.Top = 120;
            tb.Height = 20;
            tb.Width = 500;
            tb.Visible = false;
            tb.Parent = this;

            Button button = new Button();
            button.Text = "Назад";
            button.Height = 20;
            button.Width = 100;
            button.Top = 150;
            button.Left = 12;
            button.Click += new EventHandler(ReturnForm);
            button.Parent = this;
        }
        public void ReturnForm(object sender, EventArgs e)
        {
            for (int i = 0; i < rbs.Count; i++)
            {
                if (rbs[i].Checked)
                {
                    inspector.GetList()[num].Used = true;
                    if (rbs[i].Name == "1")
                    {
                        inspector.GetList()[num].Reccomendation = "Все в порядке";
                        DoReport doReport = new DoReport(inspector,CountNumbers);
                        doReport.Show();
                        this.Close();
                        break;
                    }
                    else if(tb.Text!="")
                    {
                        if (rbs[i].Text== "Непосредственное нарушение!")
                        {
                            inspector.GetList()[num].Status = 3;
                        }
                        inspector.GetList()[num].Reccomendation = rbs[i].Text+" "+tb.Text;
                        inspector.GetList()[num].Used = true;
                        DoReport doReport = new DoReport(inspector,CountNumbers);
                        doReport.Show();
                        this.Close();
                        break;
                    }
                }
            }
        }
        public void CheckRadio(object sender,EventArgs e)
        {
            var rb = (RadioButton)sender;
            switch(rb.Name)
            {
                case "1":
                    {
                        label1.Visible = false;
                        tb.Visible = false;
                        break;
                    }
                case "2":
                    {
                        label1.Visible = true;
                        tb.Visible = true;
                        break;
                    }
                case "3":
                    {
                        label1.Visible = true;
                        tb.Visible = true;
                        break;
                    }
            }
        }
    }
}
