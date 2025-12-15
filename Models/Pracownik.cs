using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class Pracownik : ICloneable
    {

        public Pracownik()
        {
        }
        public Pracownik(int idPracownika, string imie, string nazwisko,GrupaPracownicza grupa)
        {
            IdPracownika = idPracownika;
            Imie = imie;
            Nazwisko = nazwisko;
            GrupaPracownicza = grupa;
        }
        public int IdPracownika { get; set; } // Klucz główny
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        // Klucz obcy
        public GrupaPracownicza GrupaPracownicza { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
