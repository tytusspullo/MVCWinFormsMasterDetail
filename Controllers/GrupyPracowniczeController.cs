using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetail
{
    public class GrupyPracowniczeController
    {
        List<GrupaPracownicza> _grupyPracownicze = new List<GrupaPracownicza>();  //model
        IGrupyPracowniczeViewMethodsToManipulateView _view = null;  //view reference
        GrupaPracownicza _seletedGrupaPracownicza = null;           //for searching purpouses
        GrupaPracownicza _editedGrupaPracownicza = null;            //for editing operation and SAVE or REJECT changes, deep copy of selected item
        Pracownik _selectedPracownik = null;                        //for searching purpouses
        Pracownik _editedPracownik = null;                          //for editing operation and SAVE or REJECT changes, deep copy of selected item

        public GrupyPracowniczeController(IGrupyPracowniczeViewMethodsToManipulateView view, List<GrupaPracownicza> grupyPracownicze)
        {
            _view = view;
            _grupyPracownicze = grupyPracownicze;
            _view.SetController(this);
        }

        //for start load of lists
        public void LoadView()
        {
            _view.ClearGridGrupyPracownize();
            foreach (GrupaPracownicza grupaPracownicza in _grupyPracownicze)
                _view.AddToGrid(grupaPracownicza);
            _view.SetSelectedInGrid((GrupaPracownicza)_grupyPracownicze[0]);
            
            _view.ClearGridPracownicy();
            _view.UpdateState();
        }
        public GrupaPracownicza EditedGrupaPracownicza 
        { 
            get => _editedGrupaPracownicza; 
            set => _editedGrupaPracownicza = value; 
        }
        public Pracownik EditedPracownik 
        { 
            get => _editedPracownik; 
            set => _editedPracownik = value; 
        }
        public void UpdateViewDetailValues(GrupaPracownicza grupaPracownicza)
        {
            _view.GrupaPracowniczaID = grupaPracownicza.IdGrupyPracowniczej;
            _view.GrupaPracowniczaNazwa = grupaPracownicza.NazwaGrupyPracowniczej;
        }
        private void UpdateViewDetailValues(Pracownik pracownik)
        {
            _view.PracownikID = pracownik.IdPracownika;
            _view.PracownikNazwisko = pracownik.Nazwisko;
            _view.PracownikImie = pracownik.Imie;
        }
        private void UpdateGrupaPracowniczaWithViewValues(GrupaPracownicza grupaPracownicza)
        {
            grupaPracownicza.IdGrupyPracowniczej = _view.GrupaPracowniczaID;
            grupaPracownicza.NazwaGrupyPracowniczej = _view.GrupaPracowniczaNazwa;
        }
        private void UpdatePracownikWithViewValues(Pracownik pracownik)
        {
            pracownik.IdPracownika = _view.PracownikID;
            pracownik.Nazwisko = _view.PracownikNazwisko;
            pracownik.Imie = _view.PracownikImie;
        }

        #region EventsDelegatedFromView
        public void AddGrupaPracownicza()
        {
            var grupaPracownicza = new GrupaPracownicza(0, "");
            _seletedGrupaPracownicza = grupaPracownicza;
            _editedGrupaPracownicza = (GrupaPracownicza)grupaPracownicza.Clone();
            //this.updateViewDetailValues(EditedGrupaPracownicza);
            _view.ShowEditGroupBoxGrupaPracownicza();
            
            _view.State.AddGrupaPracowniczaClick();
            _view.UpdateState();
        }
        public void EditGrupaPracownicza()
        {
            _view.ShowEditGroupBoxGrupaPracownicza();
            _view.State.EditGrupaPracowniczaClick();
            _view.UpdateState();
        } 
        public void RemoveGrupaPracownicza()
        {
            int id = _seletedGrupaPracownicza.IdGrupyPracowniczej;
            GrupaPracownicza grupaPracowniczaToRemove = null;

            if (id != 0)
            {
                foreach (GrupaPracownicza grupaPracownicza in this._grupyPracownicze)
                {
                    if (grupaPracownicza.IdGrupyPracowniczej == id)
                    {
                        grupaPracowniczaToRemove = grupaPracownicza;
                        break;
                    }
                }

                if (grupaPracowniczaToRemove != null)
                {
                    int newSelectedIndex = this._grupyPracownicze.IndexOf(grupaPracowniczaToRemove);
                    this._grupyPracownicze.Remove(grupaPracowniczaToRemove);
                    this._view.RemoveFromGrid(grupaPracowniczaToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _grupyPracownicze.Count)
                    {
                        this._view.SetSelectedInGrid((GrupaPracownicza)_grupyPracownicze[newSelectedIndex]);
                    }
                }
            }
        }
        public void SelectedGrupaPracowniczaChanged(string selectedGrupaPracowniczaId)
        {
            foreach (GrupaPracownicza grupaPracownicza in this._grupyPracownicze)
            {
                if (grupaPracownicza.IdGrupyPracowniczej == Convert.ToInt32(selectedGrupaPracowniczaId))
                {
                    _seletedGrupaPracownicza = grupaPracownicza;
                    _editedGrupaPracownicza = (GrupaPracownicza)grupaPracownicza.Clone();
                    UpdateViewDetailValues(_editedGrupaPracownicza);
                    _view.SetSelectedInGrid(_editedGrupaPracownicza);
                    
                    _view.ClearGridPracownicy();
                    if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                    {
                        foreach (Pracownik pracownik in _editedGrupaPracownicza.Pracownicy)
                        {
                            _view.AddToGrid(pracownik);
                        }
                        //zaznacz pracownika
                        _selectedPracownik = _editedGrupaPracownicza.Pracownicy[0];
                        _editedPracownik = (Pracownik)_editedGrupaPracownicza.Pracownicy[0].Clone();
                        UpdateViewDetailValues(_editedPracownik);
                        _view.SetSelectedInGrid(_editedPracownik);
                    }
                    break;
                }
            }
        }
        public void SaveGrupaPracownicza()
        {
            UpdateGrupaPracowniczaWithViewValues(_editedGrupaPracownicza); //get changed values

            if (!this._grupyPracownicze.Contains(_seletedGrupaPracownicza))
            {
                //new
                this._grupyPracownicze.Add(_editedGrupaPracownicza); //add new reference
                this._view.AddToGrid(_seletedGrupaPracownicza);
            }
            else
            {
                //edit
                int idx = _grupyPracownicze.IndexOf(
                                _grupyPracownicze.FirstOrDefault(p => p.IdGrupyPracowniczej == _seletedGrupaPracownicza.IdGrupyPracowniczej));
                if (idx != -1)
                {
                    _grupyPracownicze[idx] = EditedGrupaPracownicza; //update collection references
                    this._view.UpdateGrid(EditedGrupaPracownicza);
                }
            }

            _view.SetSelectedInGrid(_seletedGrupaPracownicza);
            _view.State.SaveGrupaPracowniczaClick();
            _view.HideEditGroupBoxGrupaPracownicza();
            _view.UpdateState();
        }
        public void CancelGrupaPracownicza()
        {
            //wyczysc wartosci i formularze
            //zrob nowa kopie z selected na kolejna edycje gdyby user zechcial ponownie edytowac ten rekord
            //uaktualnij dane w formularzu
            //uaktualnij pracownikow
            _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            UpdateViewDetailValues(_editedGrupaPracownicza);
            _view.HideEditGroupBoxGrupaPracownicza();
            _view.State.CancelGrupaPracowniczaClick();
            _view.UpdateState();
        }
        public void SelectedPracownikChanged(string selectedPracownikId)
        {
            foreach (Pracownik pracownik in _editedGrupaPracownicza.Pracownicy)
            {
                if (pracownik.IdPracownika == Convert.ToInt32(selectedPracownikId))
                {
                    _selectedPracownik = pracownik;
                    _editedPracownik = (Pracownik)_selectedPracownik.Clone();
                    UpdateViewDetailValues(EditedPracownik);
                    _view.SetSelectedInGrid(EditedPracownik);
                    break;
                }
            }
        }
        public void AddPracownik()
        {
            var pracownik = new Pracownik(0, "", "");
            _selectedPracownik = pracownik;
            EditedPracownik = (Pracownik)_selectedPracownik.Clone();
            this.UpdateViewDetailValues(EditedPracownik);
            _view.ShowEditGroupBoxPracownicy();
            _view.State.AddPracownikClick();
            _view.UpdateState();
        }
        public void EditPracownik()
        {
            this.UpdateViewDetailValues(EditedPracownik);
            _view.ShowEditGroupBoxPracownicy();
            _view.State.EditPracownikClick();
            _view.UpdateState();
        }
        public void RemovePracownik()
        { 
            
        }
        public void SaveEditPracownik() 
        {
            UpdatePracownikWithViewValues(EditedPracownik);
            if (!this._seletedGrupaPracownicza.Pracownicy.Contains(_selectedPracownik))
            {
                this._seletedGrupaPracownicza.Pracownicy.Add(EditedPracownik);
                this._view.AddToGrid(EditedPracownik);
            }
            else
            {
                this._view.UpdateGrid(EditedPracownik);
            }
            _view.SetSelectedInGrid(EditedPracownik);
            _view.State.SavePracownikClick();
            _view.HideEditGroupBoxPracownicy();
            _view.UpdateState();
        }
        public void CancelEditPracownik()
        {
            _view.HideEditGroupBoxPracownicy();
            _view.State.CancelPracownikClick();
            _view.UpdateState();
        }
        #endregion

    }
}
