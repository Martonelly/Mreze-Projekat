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
    public class Polje
    {
        public string Naziv {  get; set; }
        public string Tip { get; set; }
        public Polje()
        {
        }

        public Polje(string naziv, string tip)
        {
            Naziv = naziv;
            Tip = tip;
        }
    }
}
