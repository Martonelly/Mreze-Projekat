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
    public class Igrac
    {
        public Matrica Tabla = new Matrica();
        public int IdIgraca { get; set; }
        public string KorisnickoIme { get; set; }
        public int BrojPromasaja {  get; set; }

        public int[] Brodovi = new int[5];
        public Igrac()
        {
            Tabla = new Matrica();
            IdIgraca = 0;
            KorisnickoIme = string.Empty;
            BrojPromasaja = 0;
        }

        public Igrac(int idIgraca, string korisnickoIme)
        {
            IdIgraca = idIgraca;
            KorisnickoIme = korisnickoIme;
            BrojPromasaja = 0;
            Tabla = new Matrica();
        }

        public int SumirajBrodove()
        {
            return Brodovi.Sum();
        }
    }
}
