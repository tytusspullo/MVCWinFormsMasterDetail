using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    public class PracownikTempIDGenerator
    {

        public int GenerateTempID(List<Pracownik> list)
        {
            if (list.Count > 0)
            {
                int min = list.Min(p => p.TempId);
                return --min;
            }
            else
            {
                return -1;
            }
            
        }
    }
}
