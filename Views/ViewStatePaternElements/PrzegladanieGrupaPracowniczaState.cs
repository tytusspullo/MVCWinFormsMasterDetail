using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class PrzegladanieGrupaPracowniczaState:GrupaPracowniczaState
    {
        public PrzegladanieGrupaPracowniczaState(FrmGrupyPracownicze frm) :base(frm)
        {
             
        }

        public override void AddGrupaPracowniczaClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override void EditGrupaPracowniczaClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override string ToString()
        {
            return "PrzegladanieGrupaPracowniczaState";
        }
    }
}
