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

        public Igrac PronadjiIgracaPoImenu(string ime)
        {
            foreach(Igrac i in Igraci)
            {
                if (i.KorisnickoIme == ime)
                    return i;
            }
            return null;
        }

        public Igrac PronadjiIgracaPoId(int id)
        {
            foreach (Igrac i in Igraci)
            {
                if (i.IdIgraca == id)
                    return i;
            }
            return null;
        }

        public void ObrisiIgraca(int id)
        {
            foreach (Igrac i in Igraci)
            {
                if (i.IdIgraca == id)
                    i.Aktivan = false;
            }
        }

        public void AzurirajIgraca(int id, Igrac igrac)
        {
            for(int i = 0; i < Igraci.Count; i++)
            {
                if (Igraci[i].IdIgraca == id)
                        Igraci[i] = igrac;
            }
        }
    }
}
