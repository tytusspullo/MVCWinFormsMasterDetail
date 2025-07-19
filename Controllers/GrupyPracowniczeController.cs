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
        private void UpdateLookOfViewToItsState()
        {
            switch (_view.State)
            {
                case PrzegladanieGrupaPracowniczaState przegladanieGrupaPracowniczaState:
                    _view.HideEditGroupBoxGrupaPracownicza();
                    _view.HideEditGroupBoxPracownicy();
                    //update buttons
                    _view.GroupBoxGrupaPracowniczaEditButtons().Enabled = true;
                    _view.PanelGrupaPracowniczaSaveButtons().Enabled = false;
                    _view.PanelPracownikEditButtons().Enabled = false;
                    _view.PanelPracownikSaveButtons().Enabled = false;
                    _view.UpdateStatusBarState();
                    break;
                case EdycjaGrupaPracowniczaState edycjaGrupaPracowniczaState:
                    _view.ShowEditGroupBoxGrupaPracownicza();
                    _view.HideEditGroupBoxPracownicy();
                    //update buttons
                    _view.GroupBoxGrupaPracowniczaEditButtons().Enabled = false;
                    _view.PanelGrupaPracowniczaSaveButtons().Enabled = true;
                    _view.PanelPracownikEditButtons().Enabled = true;
                    _view.PanelPracownikSaveButtons().Enabled = false;
                    _view.UpdateStatusBarState();
                    break;
                case EdycjaPracownikState edycjaPracownikState:
                    _view.ShowEditGroupBoxGrupaPracownicza();
                    _view.ShowEditGroupBoxPracownicy();
                    //update buttons
                    _view.GroupBoxGrupaPracowniczaEditButtons().Enabled = false;
                    _view.PanelGrupaPracowniczaSaveButtons().Enabled = false;
                    _view.PanelPracownikEditButtons().Enabled = false;
                    _view.PanelPracownikSaveButtons().Enabled = true;
                    _view.UpdateStatusBarState();
                    break;
                default:
                    break;
            }
        }

        #region EventsDelegatedFromView
        public void AddGrupaPracownicza()
        {
            _seletedGrupaPracownicza = new GrupaPracownicza(0, ""); 
            _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            this.UpdateViewDetailValues(_editedGrupaPracownicza);
            //manage state
            _view.State.AddGrupaPracowniczaClick();
            UpdateLookOfViewToItsState();
        }
        public void EditGrupaPracownicza()
        {
            UpdateViewDetailValues(_editedGrupaPracownicza);
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
            
            _view.State.EditGrupaPracowniczaClick(); 
            UpdateLookOfViewToItsState();
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
                    //UpdateViewDetailValues(_editedGrupaPracownicza); //testing move out
                    _view.SetSelectedInGrid(_editedGrupaPracownicza);

                    //testing move out
                    //_view.ClearGridPracownicy();
                    //if (_editedGrupaPracownicza.Pracownicy.Count > 0)
                    //{
                    //    foreach (Pracownik pracownik in _editedGrupaPracownicza.Pracownicy)
                    //    {
                    //        _view.AddToGrid(pracownik);
                    //    }
                    //    //zaznacz pracownika
                    //    _selectedPracownik = _editedGrupaPracownicza.Pracownicy[0];
                    //    _editedPracownik = (Pracownik)_editedGrupaPracownicza.Pracownicy[0].Clone();
                    //    UpdateViewDetailValues(_editedPracownik);
                    //    _view.SetSelectedInGrid(_editedPracownik);
                    //}
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
                this._view.AddToGrid(_editedGrupaPracownicza);
            }
            else
            {
                //edit
                int idx = _grupyPracownicze.IndexOf(
                                _grupyPracownicze.FirstOrDefault(p => p.IdGrupyPracowniczej == _seletedGrupaPracownicza.IdGrupyPracowniczej));
                if (idx != -1)
                {
                    _grupyPracownicze[idx] = _editedGrupaPracownicza; //update collection references
                    this._view.UpdateGrid(_editedGrupaPracownicza);
                }
            }

            _view.SetSelectedInGrid(_seletedGrupaPracownicza);
            _view.State.SaveGrupaPracowniczaClick();
            UpdateLookOfViewToItsState();
        }
        public void CancelGrupaPracownicza()
        {
            //wyczysc wartosci i formularze
            //zrob nowa kopie z selected na kolejna edycje gdyby user zechcial ponownie edytowac ten rekord
            //uaktualnij dane w formularzu
            //uaktualnij pracownikow
            _editedGrupaPracownicza = (GrupaPracownicza)_seletedGrupaPracownicza.Clone();
            UpdateViewDetailValues(_editedGrupaPracownicza);

            _view.State.CancelGrupaPracowniczaClick();
            UpdateLookOfViewToItsState();
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
            _editedPracownik = (Pracownik)_selectedPracownik.Clone();
            this.UpdateViewDetailValues(_editedPracownik);
            
            _view.State.AddPracownikClick();
            UpdateLookOfViewToItsState();
        }
        public void EditPracownik()
        {
            this.UpdateViewDetailValues(_editedPracownik);
            _view.State.EditPracownikClick();
            UpdateLookOfViewToItsState();
        }
        public void RemovePracownik()
        { 
            //Do not change view state
            //operations for List Pracownicy
        }
        public void SaveEditPracownik() 
        {
            UpdatePracownikWithViewValues(_editedPracownik);
            if (!this._seletedGrupaPracownicza.Pracownicy.Contains(_selectedPracownik))
            {
                this._seletedGrupaPracownicza.Pracownicy.Add(_editedPracownik);
                this._view.AddToGrid(_editedPracownik);
            }
            else
            {
                this._view.UpdateGrid(_editedPracownik);
            }
            _view.SetSelectedInGrid(_editedPracownik);

            _view.State.SavePracownikClick();
            UpdateLookOfViewToItsState();
        }
        public void CancelEditPracownik()
        {
            //przywroc edited pracownika na nowa kopie
            _editedPracownik = (Pracownik)_selectedPracownik.Clone();
            //UpdateViewDetailValues(_editedPracownik);
            _view.State.CancelPracownikClick();
            UpdateLookOfViewToItsState();
        }
        #endregion

    }
}
