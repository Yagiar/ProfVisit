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
using System.IO;

namespace ProfilVisit
{
    public partial class DoReport : Form
    {
        Inspector inspector;
        int CountNumbers;
        public DoReport(Inspector ins,int count)
        {
            InitializeComponent();
            inspector = ins;
            CountNumbers = count;
            Label name = new Label();
            name.Text = ins.Name;
            name.Left = 177;
            name.Top = 45;
            name.Parent = this;
            Label Object = new Label();
            Object.Text = ins.ControlObject;
            Object.Left = 177;
            Object.Top = 45 + 28;
            Object.Parent = this;
            Label Organ = new Label();
            Organ.Text = ins.ControlOrgan;
            Organ.Left = 177;
            Organ.Top = 45 + 56;
            Organ.Parent = this;
            Label type = new Label();
            type.Text = ins.TypeOfVisit;
            type.Width = 500;
            type.AutoSize = false;
            type.Left = 177;
            type.Top = 45 + 56 + 28;
            type.Parent = this;
            for(int i=0;i<CountNumbers;i++)
            {
                Button button = new Button();
                button.Height = 20;
                button.Width = 15;
                button.Text = (i + 1).ToString();
                button.Left = 25;
                button.Top = 260 + i * 28;
                button.Update();
                button.Click += new EventHandler(Smth);
                this.Controls.Add(button);
            }
            int k = 0;
            foreach (punct p in inspector.GetList())
            {
                Label label = new Label();
                label.Text = p.Name+" "+p.Reccomendation;
                label.Top = 263 + k * 28;
                k++;
                label.Left = 50;
                label.Width = 500;
                label.Parent = this;

            }
        }
        public void Smth(object sender , EventArgs e)
        {
            var b = (Button)sender;
            Alalyze anal = new Alalyze(Convert.ToInt32(b.Text) - 1,this.inspector,CountNumbers);
            anal.Show();
            this.Close();
        }

        private void EndReport_Click(object sender, EventArgs e)
        {
            int k = 0;
            string text = "";
            text += "Имя инспектора: " + inspector.Name + "\n";
            text += "Контролируемый объект: " + inspector.ControlObject + "\n";
            text += "Контролирующий орган: " + inspector.ControlOrgan + "\n";
            text += "Вид мероприятия: " + inspector.TypeOfVisit + "\n";
            for(int i=0;i<inspector.GetList().Count;i++)
            {
                if(inspector.GetList()[i].Used)
                {
                    k++;
                }
                text += (i+1).ToString()+" " + inspector.GetList()[i].Name+" " + inspector.GetList()[i].Reccomendation +"\n";
            }
            foreach (punct p in inspector.GetList())
            {
                if (p.Status == 3)
                {
                    text += "\n" + "Так как выявлено непосредственное нарушение, отчёт отправляется в высшую инстанцию.";
                }
            }
            if (k == inspector.GetList().Count)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = dlg.FileName;
                File.WriteAllText(filename, text);
                MessageBox.Show("Отчёт сохранен");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Проверьте все пункты");
            }
        }
    }
}
