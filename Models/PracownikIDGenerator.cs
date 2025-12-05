using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    public class PracownikIDGenerator
    {
        //To change if real db used
        public int GenerateID(List<Pracownik> pracownicy)
        {
            return pracownicy.Count == 0
                ? 1 : pracownicy.Select(p => p.IdPracownika).Max() + 1;
        }
    }
}
