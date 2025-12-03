using MVCWinFormsMasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class EdycjaGrupaPracowniczaState:GrupaPracowniczaState
    {
        public EdycjaGrupaPracowniczaState(FrmGrupyPracownicze frm) : base(frm)
        { 
        
        }

        public override void AddPracownikClick()
        {
            _frm.State = new EdycjaPracownikState(_frm);
            _frm.UpdateViewLookToItsState();    
        }
        public override void EditPracownikClick()
        {
            _frm.State = new EdycjaPracownikState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override void SaveGrupaPracowniczaClick()
        {
            _frm.State = new PrzegladanieGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override void CancelGrupaPracowniczaClick()
        {
            _frm.State = new PrzegladanieGrupaPracowniczaState(_frm);
            _frm.UpdateViewLookToItsState();
        }
        public override string ToString()
        {
            return "Grupy Pracownicze - Edycja";
        }
    }
}
