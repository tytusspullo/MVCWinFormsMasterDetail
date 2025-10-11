using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class EdycjaPracownikState:GrupaPracowniczaState
    {

        public EdycjaPracownikState(FrmGrupyPracownicze frm) : base(frm)
        { 
        }
        
        public override void SavePracownikClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override void CancelPracownikClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
       
        public override string ToString()
        {
            return "EdycjaPracownikState"; 
        }
    }
}
