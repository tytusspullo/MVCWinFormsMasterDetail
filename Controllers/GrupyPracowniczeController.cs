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
        }
        private void updateViewDetailValues(GrupaPracownicza grupaPracownicza)
        {
            _view.GrupaPracowniczaID = grupaPracownicza.IdGrupyPracowniczej;
            _view.GrupaPracowniczaNazwa = grupaPracownicza.NazwaGrupyPracowniczej;
        }
        private void updateGrupaPracowniczaWithViewValues(GrupaPracownicza grupaPracownicza)
        {
            grupaPracownicza.IdGrupyPracowniczej = _view.GrupaPracowniczaID;
            grupaPracownicza.NazwaGrupyPracowniczej = _view.GrupaPracowniczaNazwa;
        }

        #region EventsDelegatedFromView
        public void AddGrupaPracownicza()
        {
            var grupaPracownicza = new GrupaPracownicza(0, "");
            _seletedGrupaPracownicza = grupaPracownicza;
            this.updateViewDetailValues(_seletedGrupaPracownicza);
            _view.ShowEditGroupBoxGrupaPracownicza();
        }
        public void EditGrupaPracownicza()
        {
            _view.ShowEditGroupBoxGrupaPracownicza();
        } 
        public void RemoveGrupaPracownicza()
        {
            int id = this._view.GetIdOfSelectedInGridGrupaPracownicza();
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
            _view.HideEditGroupBoxGrupaPracownicza();
        }
        public void CancelGrupaPracownicza()
        {
            _view.HideEditGroupBoxGrupaPracownicza();
        }
        public void SelectedPracownikChanged(string selectedPracownikId)
        {

        }
        #endregion

    }
}
