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
        }
        public override void EditPracownikClick()
        {
            _frm.State = new EdycjaPracownikState(_frm);
        }
        public override void SaveGrupaPracowniczaClick()
        {
            _frm.State = new PrzegladanieGrupaPracowniczaState(_frm);
        }
        public override void CancelGrupaPracowniczaClick()
        {
            _frm.State = new PrzegladanieGrupaPracowniczaState(_frm);
        }
        public override string ToString()
        {
            return "Grupy Pracownicze - Edycja";
        }
    }
}
