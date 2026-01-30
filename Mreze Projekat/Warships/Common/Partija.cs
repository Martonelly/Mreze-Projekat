using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Partija
    {
        public List<Igrac> Igraci = new List<Igrac>();
        public bool Zavrseno = false;
        public Partija()
        {

        }
        public override string ToString()
        {
            string igraci = "";
            foreach(Igrac i in Igraci) {
                igraci += i.ToString() + "";
                igraci += "\n";
            }
            return igraci;
        }
    }
}
