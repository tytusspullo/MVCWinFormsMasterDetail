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
        public override void AddGrupaPracowniczaClick()
        {
            
        }
        public override void EditGrupaPracowniczaClick()
        {
           
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
            return "EdycjaPracownikState"; 
        }
    }
}
