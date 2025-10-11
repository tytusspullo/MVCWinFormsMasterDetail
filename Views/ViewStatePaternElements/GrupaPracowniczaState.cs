using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public abstract class GrupaPracowniczaState
    {
        protected FrmGrupyPracownicze _frm = null;
        public GrupaPracowniczaState(FrmGrupyPracownicze frm)
        { 
            _frm = frm;
        }

        public virtual void AddGrupaPracowniczaClick()
        { 
        }
        public virtual void EditGrupaPracowniczaClick()
        {
        }
        public virtual void SaveGrupaPracowniczaClick()
        {
        }
        public virtual void CancelGrupaPracowniczaClick()
        {
        }
        public virtual void AddPracownikClick()
        {
        }
        public virtual void EditPracownikClick()
        {
        }
        public virtual void SavePracownikClick()
        {
        }
        public virtual void CancelPracownikClick()
        {
        }
        public override string ToString()
        {
            return "GrupaPracowniczaState";
        }
    }
}
