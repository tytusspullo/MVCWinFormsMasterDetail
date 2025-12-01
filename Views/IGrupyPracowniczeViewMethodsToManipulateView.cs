using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetail
{
    public interface IGrupyPracowniczeViewMethodsToManipulateView
    {
        void SetController(GrupyPracowniczeController controller);

        //State - Design Patern
        GrupaPracowniczaState State { get; set; }
        void UpdateStatusBarState();


        //Methods to manipulate Master
        void ClearGridGrupyPracownicze();
        void AddToGrid(GrupaPracownicza grupaPracownicza);
        void UpdateGrid(GrupaPracownicza grupaPracownicza);
        void RemoveFromGrid(GrupaPracownicza grupaPracownicza);
        int GetIdOfSelectedInGridGrupaPracownicza();
        void SetSelectedInGrid(GrupaPracownicza grupaPracownicza);
        int GrupaPracowniczaID { get; set; }
        string GrupaPracowniczaNazwa { get; set; }
        void ShowEditGroupBoxGrupaPracownicza();
        void HideEditGroupBoxGrupaPracownicza();

        //Methods to manipulate Details
        void ClearGridPracownicy();
        void AddToGrid(Pracownik pracownik);
        void UpdateGrid(Pracownik pracownik);
        void RemoveFromGrid(Pracownik pracownik);
        int GetIdOfSelectedInGridPracownik();
        void SetSelectedInGrid(Pracownik pracownik);
        int PracownikID { get; set; }
        string PracownikNazwisko { get; set; }
        string PracownikImie { get; set; }
        void ShowEditGroupBoxPracownicy();
        void HideEditGroupBoxPracownicy();

    }
}
