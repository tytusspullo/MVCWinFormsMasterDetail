using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    internal class GrupaPracowniczaValidator
    {

        public bool IsIdValid(int newId, List<GrupaPracownicza> list) 
        {
            return list.Select(t => t.IdGrupyPracowniczej == newId).Count() == 0;
        }
    }
}
