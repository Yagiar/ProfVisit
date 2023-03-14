using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfilVisit
{
    public delegate void AccountHandler(punct p);

    public class report//класс отчёта
    {
        AccountHandler taken;
        public List<punct> Puncts = new List<punct>();
        
        public void FillReport(List<punct> puncts)
        {
            Puncts = puncts;
            foreach (punct p in Puncts)
            {
                taken(p);
            }
        }
        public void Regist(AccountHandler del)
        {
            taken = del;
        }
    }
}
