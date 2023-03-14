using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilVisit
{
    internal interface ICanDoReport
    {
        List<punct> GetList();
        void EndReport();
    }
}
