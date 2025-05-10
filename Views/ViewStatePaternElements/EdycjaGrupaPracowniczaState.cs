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

        public EdycjaGrupaPracowniczaState(IGrupyPracowniczeViewMethodsToManipulateView frm) : base(frm)
        { 
        
        }

        public override void AddGrupaPracowniczaClick()
        {
        }
        public override void EditGrupaPracowniczaClick()
        {
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
            return "EdycjaGrupaPracowniczaState";
        }
    }
}
