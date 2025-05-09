using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class PrzegladanieGrupaPracowniczaState:GrupaPracowniczaState
    {
        public override void AddGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        {
            frm.State = new EdycjaGrupaPracowniczaState();
        }
        public override void EditGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        {
            frm.State = new EdycjaGrupaPracowniczaState();
        }
        public override void SaveGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        {
            frm.State = new PrzegladanieGrupaPracowniczaState();
        }
        public override void CancelGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        {
            frm.State = new PrzegladanieGrupaPracowniczaState();
        }

        public override string ToString()
        {
            return "PrzegladanieGrupaPracowniczaState";
        }
    }
}
