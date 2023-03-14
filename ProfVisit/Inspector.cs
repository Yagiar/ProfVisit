using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfilVisit
{
    public class Inspector:ICanDoReport //класс инспектор
    {
        string name;        
        public string Name { get { return name; } }
        string controlobject;
        public string ControlObject { get { return controlobject; } }
        string controlorgan;
        public string ControlOrgan { get { return controlorgan; } }
        string typeofvisit;
        public string TypeOfVisit { get { return typeofvisit; } }
        private report report;
        public Inspector(string name, string ControlObject,string ControlOrgan,string TypeOfVisit)
        {
            this.name = name;
            this.controlobject = ControlObject;
            this.controlorgan = ControlOrgan;
            this.typeofvisit = TypeOfVisit;
            report = new report();

        }
        public List<punct> GetList()
        {
            return report.Puncts;
        }
        public void StartReport(List<punct> puncts)
        {
            report.Regist(StartPunct);
            report.FillReport(puncts);

        }
        public void EndReport()
        {
            report = null;

        }
        ~Inspector()
        {
            name= null;
            controlobject = null;
            controlorgan = null;
            typeofvisit = null;
        }
        public void StartPunct(punct p)
        {
            p.Used = false;
        }
    }
}
