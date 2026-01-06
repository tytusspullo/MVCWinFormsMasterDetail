using MVCWinFormsMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetail
{
    public class GrupyPracowniczeController
    {
        IGrupyPracowniczeRepository _repository = null;
        List<GrupaPracownicza> _cachedGrupy = null;                                 //model
        IGrupyPracowniczeViewMethodsToManipulateView _view = null;                  //view reference
        GrupaPracownicza _seletedGrupaPracownicza = null;                           //for searching purpouses, pointer on orginal list / model
        GrupaPracownicza _editedGrupaPracownicza = null;                            //for editing operation and SAVE or REJECT changes, deep copy of selected item
        Pracownik _selectedPracownik = null;                                        //for searching purpouses
        Pracownik _editedPracownik = null;                                          //for editing operation and SAVE or REJECT changes, deep copy of selected item
        PracownikTempIDGenerator _pracownikTempIDGenerator = null;                  //generate Temp ID until replaced by cascade save Grupa Pracownicza with Pracownik

        public GrupyPracowniczeController(IGrupyPracowniczeViewMethodsToManipulateView view, IGrupyPracowniczeRepository repository)
        {
            _view = view;
            _repository = repository;
            _pracownikTempIDGenerator = new PracownikTempIDGenerator();
            _view.SetController(this);
        }

        //for start load of lists
        public async Task LoadViewAsync()
        {
            _view.ClearGridGrupyPracownicze();
            _cachedGrupy = await _repository.GetAllWithPracownicyAsync();
            if (_cachedGrupy.Count > 0)
            {
                foreach (var grupaPracownicza in _cachedGrupy)
                {
                    _view.AddToGrid(grupaPracownicza);
                }
                _seletedGrupaPracownicza = _cachedGrupy[0];
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
        private void UpdateViewWithGrupaPracowniczaValues(GrupaPracownicza grupaPracownicza)
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
            if (_cachedGrupy.Count > 0)
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
                var grupaPracowniczaToRemove = _cachedGrupy.SingleOrDefault(g => g.IdGrupyPracowniczej == id);
                
                if (grupaPracowniczaToRemove != null)
                {
                    int deletedIndex = this._cachedGrupy.IndexOf(grupaPracowniczaToRemove);
                    this._cachedGrupy.Remove(grupaPracowniczaToRemove);
                    _repository.DeleteGrupaAsync(grupaPracowniczaToRemove.IdGrupyPracowniczej);
                    this._view.RemoveFromGrid(grupaPracowniczaToRemove);

                    if (_cachedGrupy.Count > 0)
                    {
                        var newdForSelect = _cachedGrupy.ElementAtOrDefault(deletedIndex)  //cover normal case
                                                ?? _cachedGrupy.LastOrDefault();           //cover case when removed last and get by index
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
                _seletedGrupaPracownicza = _cachedGrupy.SingleOrDefault(p => p.IdGrupyPracowniczej == Convert.ToInt32(selectedGrupaPracowniczaId));
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
        public async Task SaveGrupaPracowniczaAsync()
        {
            UpdateGrupaPracowniczaWithViewValues(_editedGrupaPracownicza);

            if (IsNewGrupaPracownicza())
            {
                await _repository.AddGrupaAsync(_editedGrupaPracownicza);
                _cachedGrupy.Add(_editedGrupaPracownicza);
                this._view.AddToGrid(_editedGrupaPracownicza);
            }
            else
            {
                if (_cachedGrupy.Contains(_seletedGrupaPracownicza))
                {
                    int idx = _cachedGrupy.IndexOf(_cachedGrupy.FirstOrDefault(p => p.IdGrupyPracowniczej == _seletedGrupaPracownicza.IdGrupyPracowniczej));
                    if (idx != -1)
                    {
                        
                        await _repository.UpdateGrupaAsync(_editedGrupaPracownicza);
                        //_cachedGrupy ma juz referencje
                        this._view.UpdateGrid(_editedGrupaPracownicza);
                    }
                }
            }
            _seletedGrupaPracownicza = _editedGrupaPracownicza;
            _view.SetSelectedInGrid(_editedGrupaPracownicza);
            _view.State.SaveGrupaPracowniczaClick();
        }
        private bool IsNewGrupaPracownicza()
        {
            return _editedGrupaPracownicza.IdGrupyPracowniczej == 0;

        }
        public void CancelGrupaPracownicza()
        {
            if (_seletedGrupaPracownicza != null)
            {
                _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            }
            else
            {
                _editedGrupaPracownicza = new GrupaPracownicza(0, "");
            }
            UpdateViewWithGrupaPracowniczaValues(_editedGrupaPracownicza);
            _view.State.CancelGrupaPracowniczaClick();
        }

        public void SelectedPracownikChanged(string selectedPracownikId)
        {
            Pracownik pracownik = null;
            if (Convert.ToInt32(selectedPracownikId) > 0)
            {
                pracownik = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.IdPracownika == Convert.ToInt32(selectedPracownikId));
            }
            else
            {
                pracownik = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.TempId == Convert.ToInt32(selectedPracownikId));
            }

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
            _editedPracownik = new Pracownik(0, "", "" , _editedGrupaPracownicza);
            this.UpdateViewWithPracownikValues(_editedPracownik);
            _view.State.AddPracownikClick();
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
            Pracownik pracownikToRemove = null;
            int id = _selectedPracownik?.IdPracownika ?? 0;

            if (id == 0) //new Pracownik
            {
                int tempId = _selectedPracownik?.TempId ?? 0;
                pracownikToRemove = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.TempId == tempId);
            }

            if (id != 0) //existing Pracownik   
            {
                pracownikToRemove = _editedGrupaPracownicza.Pracownicy.SingleOrDefault(p => p.IdPracownika == id);
            }

            if (pracownikToRemove != null)
            {
                int deletedIndex = this._editedGrupaPracownicza.Pracownicy.IndexOf(pracownikToRemove);
                _editedGrupaPracownicza.Pracownicy.Remove(pracownikToRemove);
                _view.RemoveFromGrid(pracownikToRemove);

                if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                {
                    var newForSelect = _editedGrupaPracownicza.Pracownicy.ElementAtOrDefault(deletedIndex)
                        ?? _editedGrupaPracownicza.Pracownicy.LastOrDefault();
                    _view.SetSelectedInGrid(newForSelect); //invoke Selection change
                }
                else
                {
                    _selectedPracownik = null;
                    _editedPracownik = null;
                }
            }

        }
        public void SavePracownik() 
        {
            UpdatePracownikWithViewValues(_editedPracownik);
            if (IsNewPracownik())
            {
                //var generator = new PracownikIDGenerator();
                //_editedPracownik.IdPracownika = generator.GenerateID(_editedGrupaPracownicza.Pracownicy);
                _editedPracownik.TempId = _pracownikTempIDGenerator.GenerateTempID();
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
        private bool IsNewPracownik()
        {
            int idPracownika = _editedPracownik?.IdPracownika ?? 0;

            bool isNew = idPracownika > 0 ? false : true;
            return isNew;
        }
        public void CancelEditPracownik()
        {
            if (_selectedPracownik != null)
            {
                _editedPracownik = (Pracownik)_selectedPracownik.Clone();
            }
            else
            {
                _editedPracownik = new Pracownik(0, "", "" , _editedGrupaPracownicza);
            }
            UpdateViewWithPracownikValues(_editedPracownik);
            _view.State.CancelPracownikClick();
        }
        #endregion

    }
}
