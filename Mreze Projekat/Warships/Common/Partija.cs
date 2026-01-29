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
    public class Partija
    {
        public List<Igrac> Igraci = new List<Igrac>();
        public bool Zavrseno = false;
        public Partija()
        {

        }
    }
}
