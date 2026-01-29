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
    public class Matrica
    {
        public int Dimenzija { get; set; }
        public List<Polje> Polja = new List<Polje>();
        public Matrica()
        {
        }
    }
}
