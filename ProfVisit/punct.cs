using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilVisit
{
    public class punct
    {
        private string name;
        private string reccomendation;
        private bool used =false;
        private int status;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Reccomendation
        {
            get { return reccomendation; }
            set { reccomendation = value; }
        }
        public bool Used
        {
            get { return used; }
            set { used = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
