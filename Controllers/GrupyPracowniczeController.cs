using MVCWinFormsMasterDetail.Models;
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
        List<GrupaPracownicza> _grupyPracownicze = new List<GrupaPracownicza>();    //model
        IGrupyPracowniczeViewMethodsToManipulateView _view = null;                  //view reference
        GrupaPracownicza _seletedGrupaPracownicza = null;                           //for searching purpouses, pointer on orginal list / model
        GrupaPracownicza _editedGrupaPracownicza = null;                            //for editing operation and SAVE or REJECT changes, deep copy of selected item
        Pracownik _selectedPracownik = null;                                        //for searching purpouses
        Pracownik _editedPracownik = null;                                          //for editing operation and SAVE or REJECT changes, deep copy of selected item

        public GrupyPracowniczeController(IGrupyPracowniczeViewMethodsToManipulateView view, List<GrupaPracownicza> grupyPracownicze)
        {
            _view = view;
            _grupyPracownicze = grupyPracownicze;
            _view.SetController(this);
        }

        //for start load of lists
        public void LoadView()
        {
            _view.ClearGridGrupyPracownicze();
            if (_grupyPracownicze.Count > 0)
            {
                foreach (var grupaPracownicza in _grupyPracownicze)
                {
                    _view.AddToGrid(grupaPracownicza);
                }
                _seletedGrupaPracownicza = _grupyPracownicze[0];
                _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
                _view.SetSelectedInGrid(_seletedGrupaPracownicza);
                UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
            }
            else
            {
                _seletedGrupaPracownicza = new GrupaPracownicza(0, "");
                _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
                UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
            }
            _view.ClearGridPracownicy();
            _view.UpdateStatusBarState();
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
        public void UpdateViewWithGrupaPracowniczaValues(GrupaPracownicza grupaPracownicza)
        {
            if (grupaPracownicza != null)
            {
                _view.GrupaPracowniczaID = grupaPracownicza.IdGrupyPracowniczej;
                _view.GrupaPracowniczaNazwa = grupaPracownicza.NazwaGrupyPracowniczej;
            }
            else
            {
                _view.GrupaPracowniczaID = 0;
                _view.GrupaPracowniczaNazwa = string.Empty;
            }
        }
        private void UpdateViewWithPracownikValues(Pracownik pracownik)
        {
            if (pracownik != null)
            {
                _view.PracownikID = pracownik.IdPracownika;
                _view.PracownikNazwisko = pracownik.Nazwisko;
                _view.PracownikImie = pracownik.Imie;
            }
            else
            {
                _view.PracownikID = 0;
                _view.PracownikNazwisko = string.Empty;
                _view.PracownikImie = string.Empty;
            }
        }
        private void UpdateGrupaPracowniczaWithViewValues(GrupaPracownicza grupaPracownicza)
        {
            if (grupaPracownicza != null)
            {
                grupaPracownicza.IdGrupyPracowniczej = _view.GrupaPracowniczaID;
                grupaPracownicza.NazwaGrupyPracowniczej = _view.GrupaPracowniczaNazwa;
            }
        }
        private void UpdatePracownikWithViewValues(Pracownik pracownik)
        {
            if (pracownik != null)
            {
                pracownik.IdPracownika = _view.PracownikID;
                pracownik.Nazwisko = _view.PracownikNazwisko;
                pracownik.Imie = _view.PracownikImie;
            }
        }
        private void FillListPracownicy(IList<Pracownik> pracownicy)
        {
            foreach (Pracownik item in pracownicy)
            {
                _view.AddToGrid(item);
            }
        }

        #region EventsDelegatedFromView
        public void AddGrupaPracownicza()
        {
            _editedGrupaPracownicza = new GrupaPracownicza(0, "");
            this.UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
            _view.ClearGridPracownicy();
            _view.State.AddGrupaPracowniczaClick();
        }
        public void EditGrupaPracownicza()
        {
            if (_grupyPracownicze.Count > 0)
            {
                UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
                _view.ClearGridPracownicy();
                if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                {
                    FillListPracownicy(_editedGrupaPracownicza.Pracownicy);
                    _selectedPracownik = _editedGrupaPracownicza.Pracownicy[0];
                    _editedPracownik = (Pracownik)_selectedPracownik.Clone();
                    UpdateViewWithPracownikValues(_editedPracownik);
                    _view.SetSelectedInGrid(_editedPracownik);
                }
                _view.State.EditGrupaPracowniczaClick();
            }
        }
        public void RemoveGrupaPracownicza()
        {
            int id = _seletedGrupaPracownicza?.IdGrupyPracowniczej ?? 0;

            if (id != 0)
            {
                var grupaPracowniczaToRemove = _grupyPracownicze.SingleOrDefault(g => g.IdGrupyPracowniczej == id);
                
                if (grupaPracowniczaToRemove != null)
                {
                    int deletedIndex = this._grupyPracownicze.IndexOf(grupaPracowniczaToRemove);//
                    this._grupyPracownicze.Remove(grupaPracowniczaToRemove);
                    this._view.RemoveFromGrid(grupaPracowniczaToRemove);

                    if (_grupyPracownicze.Count > 0)
                    {
                        var newdForSelect = _grupyPracownicze.ElementAtOrDefault(deletedIndex)  //cover normal case
                                                ?? _grupyPracownicze.LastOrDefault();           //cover case when removed last and get by index
                        _view.SetSelectedInGrid(newdForSelect);
                        //change edited, change record in display?
                    }
                }
            }
        }
        public void SelectedGrupaPracowniczaChanged(string selectedGrupaPracowniczaId)
        {
            int previousId = _seletedGrupaPracownicza?.IdGrupyPracowniczej ?? -1;
            _seletedGrupaPracownicza = null;
            _editedGrupaPracownicza = null;
            _selectedPracownik = null;
            _editedPracownik = null;

            if (!string.IsNullOrEmpty(selectedGrupaPracowniczaId))
            {
                _seletedGrupaPracownicza = _grupyPracownicze.SingleOrDefault(p => p.IdGrupyPracowniczej == Convert.ToInt32(selectedGrupaPracowniczaId));
                _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            }

            if (_seletedGrupaPracownicza == null)
            {
                _seletedGrupaPracownicza = new GrupaPracownicza(0, "");
                _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            }

            if (_seletedGrupaPracownicza.IdGrupyPracowniczej != previousId)
            {
                UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
                _view.SetSelectedInGrid(_seletedGrupaPracownicza);
                _view.ClearGridPracownicy();
                if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                {
                    FillListPracownicy(_editedGrupaPracownicza.Pracownicy);
                    _selectedPracownik = _editedGrupaPracownicza.Pracownicy[0];
                    _editedPracownik = (Pracownik)_selectedPracownik.Clone();
                    _view.SetSelectedInGrid(_editedPracownik);
                }
            }
        }
        public void SaveGrupaPracownicza()
        {
            UpdateGrupaPracowniczaWithViewValues(_editedGrupaPracownicza); //get changed values

            if (IsNewRecord())
            {
                var generator = new GrupaPracowniczaIDGenerator();
                _editedGrupaPracownicza.IdGrupyPracowniczej = generator.GenerateID(_grupyPracownicze);
                this._grupyPracownicze.Add(_editedGrupaPracownicza);
                this._view.AddToGrid(_editedGrupaPracownicza);
            }
            else
            {
                if (_grupyPracownicze.Contains(_seletedGrupaPracownicza))
                {
                    int idx = _grupyPracownicze.IndexOf(_grupyPracownicze.FirstOrDefault(p => p.IdGrupyPracowniczej == _seletedGrupaPracownicza.IdGrupyPracowniczej));
                    if (idx != -1)
                    {
                        _grupyPracownicze[idx] = _editedGrupaPracownicza;
                        this._view.UpdateGrid(_editedGrupaPracownicza);
                    }
                }
            }
            _view.SetSelectedInGrid(_editedGrupaPracownicza);
            _view.State.SaveGrupaPracowniczaClick();
            //UpdateViewLookToItsState();
        }
        private bool IsNewRecord()
        {
            return _grupyPracownicze.SingleOrDefault(p => p.IdGrupyPracowniczej == _editedGrupaPracownicza.IdGrupyPracowniczej) == null;
               
        }
        public void CancelGrupaPracownicza()
        {
            _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
            _view.State.CancelGrupaPracowniczaClick();
            //UpdateViewLookToItsState();
        }

        public void SelectedPracownikChanged(string selectedPracownikId)
        {
            var pracownik = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.IdPracownika == Convert.ToInt32(selectedPracownikId));
            if (pracownik != null)
            {
                _selectedPracownik = pracownik;
                _editedPracownik = (Pracownik)_selectedPracownik.Clone();
                UpdateViewWithPracownikValues(EditedPracownik);
                _view.SetSelectedInGrid(EditedPracownik);
            }
        }
        public void AddPracownik()
        {
            var pracownik = new Pracownik(0, "", "");
            _selectedPracownik = pracownik;
            _editedPracownik = (Pracownik)_selectedPracownik.Clone();
            this.UpdateViewWithPracownikValues(_editedPracownik);
            
            _view.State.AddPracownikClick();
            //UpdateViewLookToItsState();
        }
        public void EditPracownik()
        {
            if (_editedGrupaPracownicza.Pracownicy.Count > 0)
            {
                this.UpdateViewWithPracownikValues(_editedPracownik);
                _view.State.EditPracownikClick();
            }
        }
        public void RemovePracownik()
        {
            //Do not change view state
            int id = _selectedPracownik?.IdPracownika ?? 0;
            if (id != 0)
            {
                var pracownikToRemove = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.IdPracownika == id);
                if (pracownikToRemove != null)
                {
                    int deletedIndex = this._editedGrupaPracownicza.Pracownicy.IndexOf(pracownikToRemove);
                    _editedGrupaPracownicza.Pracownicy.Remove(pracownikToRemove);
                    _view.RemoveFromGrid(pracownikToRemove);

                    if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                    {
                        var newForSelect = _editedGrupaPracownicza.Pracownicy.ElementAtOrDefault(deletedIndex)
                            ?? _editedGrupaPracownicza.Pracownicy.LastOrDefault();
                        _view.SetSelectedInGrid(_editedGrupaPracownicza.Pracownicy[deletedIndex]); //invoke Selection change
                    }
                    else
                    {
                        _selectedPracownik = null;
                        _editedPracownik = null;
                    }
                }
            }

        }
        public void SaveEditPracownik() 
        {
            UpdatePracownikWithViewValues(_editedPracownik);
            if (!this._editedGrupaPracownicza.Pracownicy.Contains(_selectedPracownik))
            {
                this._editedGrupaPracownicza.Pracownicy.Add(_editedPracownik);
                this._view.AddToGrid(_editedPracownik);
            }
            else
            {
                int idx = _editedGrupaPracownicza.Pracownicy.IndexOf(_selectedPracownik);
                if (idx != -1)
                {
                    _editedGrupaPracownicza.Pracownicy[idx] = _editedPracownik;
                    this._view.UpdateGrid(_editedPracownik);
                }
            }
            _view.SetSelectedInGrid(_editedPracownik);
            _view.State.SavePracownikClick();
        }
        public void CancelEditPracownik()
        {
            _editedPracownik = (Pracownik)_selectedPracownik.Clone();
            _view.State.CancelPracownikClick();
        }
        #endregion

    }
}
