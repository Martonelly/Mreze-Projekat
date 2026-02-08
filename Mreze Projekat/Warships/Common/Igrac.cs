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
    public class Igrac
    {
        public Matrica Tabla = new Matrica();
        public int IdIgraca { get; set; }
        public string KorisnickoIme { get; set; }
        public int BrojPromasaja {  get; set; }

        public int[] Brodovi = { 1, 1, 1, 1, 1 };
        public bool Aktivan {  get; set; }
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
        public override string ToString()
        {
            return IdIgraca.ToString() + KorisnickoIme;
        }

        public void AzurirajPoljePoImenu(string naziv, string tip)
        {
            foreach(Polje p in Tabla.Polja)
            {
                if (p.Naziv == naziv)
                    p.Tip = tip;
            }
        }

        public string pronadjiPolje(string naziv)
        {
            foreach (Polje p in Tabla.Polja)
            {
                if (p.Naziv == naziv)
                    return p.Tip;
            }
            return "";
        }
    }
}
