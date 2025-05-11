using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class EdycjaPracownikState:GrupaPracowniczaState
    {
        public EdycjaPracownikState(IGrupyPracowniczeViewMethodsToManipulateView frm) : base(frm)
        {
        }


        public override string ToString()
        {
            return "EdycjaPracownikState"; 
        }
    }
}
