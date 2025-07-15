using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class Pracownik:ICloneable
    {
        public Pracownik(int idPracownika, string nazwisko, string imie) 
        {
            IdPracownika = idPracownika;
            Nazwisko = nazwisko;
            Imie = imie;
        }
        public int IdPracownika { get; set; }
        public string Nazwisko { get; set; }
        public string Imie {  get; set; }
        public object Clone()
        {
            Pracownik other = (Pracownik)MemberwiseClone();
            return other;
        }
    }
}
