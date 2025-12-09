using MVCWinFormsMasterDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MVCWinFormsMasterDetail
{
    public partial class FrmGrupyPracownicze : Form, IGrupyPracowniczeViewMethodsToManipulateView
    {
        GrupyPracowniczeController _controller = null;
        GrupaPracowniczaState _state = null;

        public FrmGrupyPracownicze()
        {
            _state = new PrzegladanieGrupaPracowniczaState(this);
            InitializeComponent();
            btnEditGrupaPracownicza.Enabled = false;
        }

        public GrupaPracowniczaState State
        {
            get { return _state; }
            set { 
                _state = value;
                UpdateViewLookToItsState();
                }
        }
        public void UpdateStatusBarState()
        {
            this.Text = _state.ToString();
        }
        private void UpdateViewLookToItsState()
        {
            switch (_state)
            {
                case PrzegladanieGrupaPracowniczaState przegladanieGrupaPracowniczaState:
                    HideEditGroupBoxGrupaPracownicza();
                    HideEditGroupBoxPracownicy();
                    //update buttons
                    GroupBoxGrupaPracowniczaEditButtons().Enabled = true;
                    PanelGrupaPracowniczaSaveButtons().Enabled = false;
                    PanelPracownikEditButtons().Enabled = false;
                    PanelPracownikSaveButtons().Enabled = false;
                    UpdateStatusBarState();
                    break;
                case EdycjaGrupaPracowniczaState edycjaGrupaPracowniczaState:
                    ShowEditGroupBoxGrupaPracownicza();
                    HideEditGroupBoxPracownicy();
                    //update buttons
                    GroupBoxGrupaPracowniczaEditButtons().Enabled = false;
                    PanelGrupaPracowniczaSaveButtons().Enabled = true;
                    PanelPracownikEditButtons().Enabled = true;
                    PanelPracownikSaveButtons().Enabled = false;
                    UpdateStatusBarState();
                    break;
                case EdycjaPracownikState edycjaPracownikState:
                    ShowEditGroupBoxGrupaPracownicza();
                    ShowEditGroupBoxPracownicy();
                    //update buttons
                    GroupBoxGrupaPracowniczaEditButtons().Enabled = false;
                    PanelGrupaPracowniczaSaveButtons().Enabled = false;
                    PanelPracownikEditButtons().Enabled = false;
                    PanelPracownikSaveButtons().Enabled = true;
                    UpdateStatusBarState();
                    break;
                default:
                    break;
            }
        }
        private GroupBox GroupBoxGrupaPracowniczaEditButtons()
        {
            return this.gbGrupaPracowniczaEditButtons;
        }
        private Panel PanelPracownikEditButtons()
        {
            return this.pnPracownikEditButtons;
        }
        private Panel PanelGrupaPracowniczaSaveButtons()
        {
            return this.pnGrupaPracowniczaSaveButtons;
        }
        private Panel PanelPracownikSaveButtons()
        {
            return this.pnPracownikSaveButtons;
        }

        #region IGrupyPracowniczeView_MethodsNeededToManipulateView
        public void SetController(GrupyPracowniczeController controller)
        {
            _controller = controller;
        }
        public int GrupaPracowniczaID
        {
            get
            {
                if (int.TryParse(tbIDGrupaPracownicza.Text, out int result))
                {
                    return result;
                }
                return 0;
            }
            set
            {
                tbIDGrupaPracownicza.Text = value.ToString();
            }
        }
        public string GrupaPracowniczaNazwa
        {
            get { return tbNazwaGrupaPracownicza.Text; }
            set { tbNazwaGrupaPracownicza.Text = value; }
        }
        public int PracownikID 
        {
            get { return Convert.ToInt32(tbIDPracownika.Text); }
            set { tbIDPracownika.Text = value.ToString(); }
        }
        public string PracownikNazwisko 
        {
            get { return tbNazwisko.Text; }
            set { tbNazwisko.Text = value.ToString(); }
        }
        public string PracownikImie 
        {
            get { return tbImie.Text; }    
            set { tbImie.Text = value.ToString(); }
        }

        public void ClearGridGrupyPracownicze()
        {
            this.lvGrupyPracownicze.Columns.Clear();
            this.lvGrupyPracownicze.Columns.Add("Id", 150, HorizontalAlignment.Left);
            this.lvGrupyPracownicze.Columns.Add("Nazwa", 150, HorizontalAlignment.Left);
            this.lvGrupyPracownicze.Items.Clear();
        }
        public int GetIdOfSelectedInGridGrupaPracownicza()
        {
            if (this.lvGrupyPracownicze.SelectedItems.Count > 0)
                return Convert.ToInt32(lvGrupyPracownicze.SelectedItems[0].Text);
            else
                return 0;
        }
        public void AddToGrid(GrupaPracownicza grupaPracownicza)
        {
            ListViewItem parent;
            parent = this.lvGrupyPracownicze.Items.Add(grupaPracownicza.IdGrupyPracowniczej.ToString());
            parent.SubItems.Add(grupaPracownicza.NazwaGrupyPracowniczej);
        } 
        public void UpdateGrid(GrupaPracownicza grupaPracownicza)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.lvGrupyPracownicze.Items)
            {
                if (row.Text == grupaPracownicza.IdGrupyPracowniczej.ToString())
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = grupaPracownicza.IdGrupyPracowniczej.ToString();
                rowToUpdate.SubItems[1].Text = grupaPracownicza.NazwaGrupyPracowniczej;
            }
        }
        public void RemoveFromGrid(GrupaPracownicza grupaPracownicza)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.lvGrupyPracownicze.Items)
            {
                if (row.Text == grupaPracownicza.IdGrupyPracowniczej.ToString())
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.lvGrupyPracownicze.Items.Remove(rowToRemove);
                this.lvGrupyPracownicze.Focus();
            }
        }
        public void SetSelectedInGrid(GrupaPracownicza grupaPracownicza)
        {
            int id = grupaPracownicza?.IdGrupyPracowniczej ?? 0;

            if (lvGrupyPracownicze.SelectedItems.Count == 1 &&
                lvGrupyPracownicze.SelectedItems[0].Text == id.ToString())
            {
                return; // No change needed
            }

            lvGrupyPracownicze.SelectedItems.Clear();
            foreach (ListViewItem row in lvGrupyPracownicze.Items)
            {
                if (row.Text == id.ToString())
                {
                    row.Selected = true;
                    row.Focused = true;
                    break;
                }
            }
        }
        public void ShowEditGroupBoxGrupaPracownicza()
        {
            gbEdit.Visible = true;
            gbEdit.Dock = DockStyle.Fill;
            lvGrupyPracownicze.Visible = false;
        }
        public void HideEditGroupBoxGrupaPracownicza()
        {
            gbEdit.Visible = false;
            gbEdit.Dock = DockStyle.Top;
            lvGrupyPracownicze.Visible = true;
        }

        public void ClearGridPracownicy()
        {
            this.lvPracownicy.Columns.Clear();
            this.lvPracownicy.Columns.Add("Id", 150, HorizontalAlignment.Left);
            this.lvPracownicy.Columns.Add("Nazwisko Imię", 150, HorizontalAlignment.Left);
            this.lvPracownicy.Items.Clear();
        }
        public void AddToGrid(Pracownik pracownik)
        {
            ListViewItem parent;
            parent = this.lvPracownicy.Items.Add(pracownik.IdPracownika.ToString());
            parent.SubItems.Add(pracownik.Nazwisko + " " + pracownik.Imie);
        }
        public void UpdateGrid(Pracownik pracownik)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.lvPracownicy.Items)
            {
                if (row.Text == pracownik.IdPracownika.ToString())
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = pracownik.IdPracownika.ToString();
                rowToUpdate.SubItems[1].Text = pracownik.Nazwisko + " " + pracownik.Imie;
            }
        }
        public void RemoveFromGrid(Pracownik pracownik)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.lvPracownicy.Items)
            {
                if (row.Text == pracownik.IdPracownika.ToString())
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.lvPracownicy.Items.Remove(rowToRemove);
                this.lvPracownicy.Focus();
            }
        }
        public int GetIdOfSelectedInGridPracownik()
        {
            if (this.lvPracownicy.SelectedItems.Count > 0)
                return Convert.ToInt32(lvPracownicy.SelectedItems[0].Text);
            else
                return 0;
        }
        public void SetSelectedInGrid(Pracownik pracownik)
        {
            int id = pracownik?.IdPracownika ?? 0;

            if (lvPracownicy.SelectedItems.Count == 1 &&
                lvPracownicy.SelectedItems[0].Text == id.ToString())
            {
                return; 
            }

            lvPracownicy.SelectedItems.Clear(); 
            foreach (ListViewItem row in lvPracownicy.Items)
            {
                if (row.Text == id.ToString())
                {
                    row.Selected = true;
                    row.Focused = true;
                    break;
                }
            }
        }
        public void ShowEditGroupBoxPracownicy()
        {
            pnEditPracownik.Visible = true;
        }
        public void HideEditGroupBoxPracownicy()
        {
            pnEditPracownik.Visible = false;
        }
        #endregion 
        
        #region EventsDelagatedToController
        private void btnAddGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.AddGrupaPracownicza();
        }
        private void btnEditGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.EditGrupaPracownicza();
        }
        private void btnRemoveGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.RemoveGrupaPracownicza();
        }
        private void lvGrupyPracownicze_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditGrupaPracownicza.Enabled = lvGrupyPracownicze.SelectedItems.Count > 0;
            if (lvGrupyPracownicze.SelectedItems.Count > 0)
            {
                _controller.SelectedGrupaPracowniczaChanged(lvGrupyPracownicze.SelectedItems[0].Text);
            }
        }
        private void btnSaveGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.SaveGrupaPracownicza();
        }
        private void btnCancelGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.CancelGrupaPracownicza();
        }
        private void btnAddPracownik_Click(object sender, EventArgs e)
        {
            _controller.AddPracownik();
        }
        private void btnEditPracownik_Click(object sender, EventArgs e)
        {
            _controller.EditPracownik();
        }
        private void btnRemovePracownik_Click(object sender, EventArgs e)
        {
            _controller.RemovePracownik();
        }
        private void lvPracownicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPracownicy.SelectedItems.Count > 0)
                this._controller.SelectedPracownikChanged(this.lvPracownicy.SelectedItems[0].Text);
        }
        private void btnSaveEditPracownik_Click(object sender, EventArgs e)
        {
            _controller.SavePracownik();
        }
        private void btnCancelEditPracownik_Click(object sender, EventArgs e)
        {
            _controller.CancelEditPracownik();
        }
        #endregion
    }
}
