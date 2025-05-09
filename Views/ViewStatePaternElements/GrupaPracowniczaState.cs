using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public abstract class GrupaPracowniczaState
    {
        public virtual void AddGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        { 
            
        }
        public virtual void EditGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        {

        }
        public virtual void SaveGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        { 
        
        }
        public virtual void CancelGrupaPracowniczaClick(IGrupyPracowniczeViewMethodsToManipulateView frm)
        { 
        
        }

        public override string ToString()
        {
            return "GrupaPracowniczaState";
        }
    }
}
