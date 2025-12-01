using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    public class GrupaPracowniczaIDGenerator
    {
        public int GenerateID(List<GrupaPracownicza> grupyPracownicze) 
        {
            return grupyPracownicze.Count == 0 
                ? 1 : grupyPracownicze.Select(p => p.IdGrupyPracowniczej).Max() + 1;
        }
    }
}
