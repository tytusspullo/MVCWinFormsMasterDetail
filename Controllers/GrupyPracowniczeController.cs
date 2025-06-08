using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail
{
    public class GrupyPracowniczeController
    {
        IGrupyPracowniczeViewMethodsToManipulateView _view;
        List<GrupaPracownicza> _grupyPracownicze = new List<GrupaPracownicza>();
        GrupaPracownicza _seletedGrupaPracownicza = null;
        Pracownik _selectedPracownik = null;

        public GrupyPracowniczeController(IGrupyPracowniczeViewMethodsToManipulateView view, List<GrupaPracownicza> grupyPracownicze)
        {
            _view = view;
            _grupyPracownicze = grupyPracownicze;
            view.SetController(this);
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
        private void updateViewDetailValues(GrupaPracownicza grupaPracownicza)
        {
            _view.GrupaPracowniczaID = grupaPracownicza.IdGrupyPracowniczej;
            _view.GrupaPracowniczaNazwa = grupaPracownicza.NazwaGrupyPracowniczej;
        }
        private void updateViewDetailValues(Pracownik pracownik)
        {
            _view.PracownikID = pracownik.IdPracownika;
            _view.PracownikNazwisko = pracownik.Nazwisko;
            _view.PracownikImie = pracownik.Imie;
        }

        private void updateGrupaPracowniczaWithViewValues(GrupaPracownicza grupaPracownicza)
        {
            grupaPracownicza.IdGrupyPracowniczej = _view.GrupaPracowniczaID;
            grupaPracownicza.NazwaGrupyPracowniczej = _view.GrupaPracowniczaNazwa;
        }
        private void updatePracownikWithViewValues(Pracownik pracownik)
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
            this.updateViewDetailValues(_seletedGrupaPracownicza);
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
                    updateViewDetailValues(grupaPracownicza);
                    _view.SetSelectedInGrid(grupaPracownicza);
                    
                    _view.ClearGridPracownicy();
                    if (_seletedGrupaPracownicza.Pracownicy.Count > 0)
                    {
                        foreach (Pracownik pracownik in _seletedGrupaPracownicza.Pracownicy)
                        {
                            _selectedPracownik = _seletedGrupaPracownicza.Pracownicy[0];
                            if (pracownik.IdPracownika == Convert.ToInt32(_selectedPracownik.IdPracownika))
                            {
                                updateViewDetailValues(pracownik);
                                _view.SetSelectedInGrid(pracownik);
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
        public void SaveGrupaPracownicza()
        {
            updateGrupaPracowniczaWithViewValues(_seletedGrupaPracownicza);
            if (!this._grupyPracownicze.Contains(_seletedGrupaPracownicza))
            {
                this._grupyPracownicze.Add(_seletedGrupaPracownicza);
                this._view.AddToGrid(_seletedGrupaPracownicza);
            }
            else
            {
                this._view.UpdateGrid(_seletedGrupaPracownicza);
            }
            _view.SetSelectedInGrid(_seletedGrupaPracownicza);
            _view.State.SaveGrupaPracowniczaClick();
            _view.HideEditGroupBoxGrupaPracownicza();
            _view.UpdateState();
        }
        public void CancelGrupaPracownicza()
        {
            _view.HideEditGroupBoxGrupaPracownicza();
            _view.State.CancelGrupaPracowniczaClick();
            _view.UpdateState();
        }
        public void SelectedPracownikChanged(string selectedPracownikId)
        {
            foreach (Pracownik pracownik in _seletedGrupaPracownicza.Pracownicy)
            {
                if (pracownik.IdPracownika == Convert.ToInt32(selectedPracownikId))
                {
                    _selectedPracownik = pracownik;
                    updateViewDetailValues(pracownik);
                    _view.SetSelectedInGrid(pracownik);
                    break;
                }
            }
        }
        public void AddPracownik()
        {
            var pracownik = new Pracownik(0, "", "");
            _selectedPracownik = pracownik;
            this.updateViewDetailValues(_selectedPracownik);
            _view.ShowEditGroupBoxPracownicy();
            _view.State.AddPracownikClick();
            _view.UpdateState();
        }
        public void EditPracownik()
        {
            this.updateViewDetailValues(_selectedPracownik);
            _view.ShowEditGroupBoxPracownicy();
            _view.State.EditPracownikClick();
            _view.UpdateState();
        }
        public void RemovePracownik()
        { 
            
        }
        public void SaveEditPracownik() 
        {
            updatePracownikWithViewValues(_selectedPracownik);
            if (!this._seletedGrupaPracownicza.Pracownicy.Contains(_selectedPracownik))
            {
                this._seletedGrupaPracownicza.Pracownicy.Add(_selectedPracownik);
                this._view.AddToGrid(_selectedPracownik);
            }
            else
            {
                this._view.UpdateGrid(_selectedPracownik);
            }
            _view.SetSelectedInGrid(_selectedPracownik);
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
