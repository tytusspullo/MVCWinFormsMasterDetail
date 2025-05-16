using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class PrzegladanieGrupaPracowniczaState:GrupaPracowniczaState
    {
        public PrzegladanieGrupaPracowniczaState(IGrupyPracowniczeViewMethodsToManipulateView frm) :base(frm)
        { 
        }

        public override void AddGrupaPracowniczaClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
        }
        public override void EditGrupaPracowniczaClick()
        {
            _frm.State = new EdycjaGrupaPracowniczaState(_frm);
        }
        public override void SaveGrupaPracowniczaClick()
        {
        }
        public override void CancelGrupaPracowniczaClick()
        {
        }

        public override void AddPracownikClick()
        {
            
        }
        public override void EditPracownikClick()
        {
            
        }
        public override void SavePracownikClick()
        {
            
        }
        public override void CancelPracownikClick()
        {
            
        }

        public override string ToString()
        {
            return "PrzegladanieGrupaPracowniczaState";
        }
    }
}
