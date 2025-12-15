using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class GrupaPracownicza : ICloneable
    {
        public GrupaPracownicza()
        { }
        public GrupaPracownicza(int idGrupyPracowniczej, string nazwa)
        {
            IdGrupyPracowniczej = idGrupyPracowniczej;
            NazwaGrupyPracowniczej = nazwa;
        }
        public int IdGrupyPracowniczej { get; set; } // Klucz główny
        public string NazwaGrupyPracowniczej { get; set; }

        public List<Pracownik> Pracownicy { get; set; } = new List<Pracownik>();

        public object Clone()
        {
            var other = new GrupaPracownicza
            {
                IdGrupyPracowniczej = this.IdGrupyPracowniczej,
                NazwaGrupyPracowniczej = this.NazwaGrupyPracowniczej,
                Pracownicy = this.Pracownicy.Select(p => (Pracownik)p.Clone()).ToList()
            };
            return other;
        }
    }
}
