using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public interface IGrupyPracowniczeViewMethodsToManipulateView
    {
        void SetController(GrupyPracowniczeController controller);
        GrupaPracowniczaState State { get; set; }
        void ClearGridGrupyPracownize();
        void AddToGrid(GrupaPracownicza grupaPracownicza);
        void UpdateGrid(GrupaPracownicza grupaPracownicza);
        void RemoveFromGrid(GrupaPracownicza grupaPracownicza);
        int GetIdOfSelectedInGridGrupaPracownicza();
        void SetSelectedInGrid(GrupaPracownicza grupaPracownicza);
        int GrupaPracowniczaID { get; set; }
        string GrupaPracowniczaNazwa { get; set; }
        void ShowEditGroupBoxGrupaPracownicza();
        void HideEditGroupBoxGrupaPracownicza();
        void UpdateState();
    }
}
