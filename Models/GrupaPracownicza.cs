using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class GrupaPracownicza
    {
        private List<Pracownik> _pracownicy = null;

        public GrupaPracownicza()
        {
            _pracownicy = new List<Pracownik>();
        }
        public GrupaPracownicza(int idGrupyPracowniczej, string nazwa) :this()
        {
            IdGrupyPracowniczej = idGrupyPracowniczej;
            NazwaGrupyPracowniczej = nazwa;
        }

        public int IdGrupyPracowniczej { get; set; }
        public string NazwaGrupyPracowniczej { get; set; }
        public List<Pracownik> Pracownicy
        {
            get { return _pracownicy; }
        }


    }
}
