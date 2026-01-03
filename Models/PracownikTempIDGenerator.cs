using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    public class PracownikTempIDGenerator
    {
        private int currentTempId = -1;

        public int GenerateTempID()
        {
            return currentTempId--;
        }
    }
}
