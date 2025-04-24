using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetail
{
    public partial class FrmGrupyPracownicze : Form, IGrupyPracowniczeViewMethodsToManipulateView
    {
        GrupyPracowniczeController _controller = null;
        
        public FrmGrupyPracownicze()
        {
            InitializeComponent();
        }

        #region IGrupyPracowniczeView_MethodsNeededToManipulateView
        public void SetController(GrupyPracowniczeController controller)
        {
            _controller = controller;
        }
        public int GrupaPracowniczaID 
        {
            get { return Convert.ToInt32(tbIDGrupaPracownicza.Text); }
            set { tbIDGrupaPracownicza.Text = value.ToString(); } 
        }
        public string GrupaPracowniczaNazwa
        {
            get { return tbNazwaGrupaPracownicza.Text; }
            set { tbNazwaGrupaPracownicza.Text = value; }
        }
        public void ClearGridGrupyPracownize()
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
            foreach (ListViewItem row in this.lvGrupyPracownicze.Items)
            {
                if (row.Text == grupaPracownicza.IdGrupyPracowniczej.ToString())
                {
                    row.Selected = true;
                }
            }
        }
        public void ShowEditGroupBoxGrupaPracownicza()
        {
            gbEdit.Visible = true;
        }
        public void HideEditGroupBoxGrupaPracownicza()
        {
            gbEdit.Visible = false;
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
            if (this.lvGrupyPracownicze.SelectedItems.Count > 0)
                this._controller.SelectedGrupaPracowniczaChanged(this.lvGrupyPracownicze.SelectedItems[0].Text);
        }
        private void btnSaveGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.SaveGrupaPracownicza();
        }
        private void btnCancelGrupaPracownicza_Click(object sender, EventArgs e)
        {
            _controller.CancelGrupaPracownicza();
        }
        private void lvPracownicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPracownicy.SelectedItems.Count > 0)
                _controller.SelectedPracownikChanged(this.lvPracownicy.SelectedItems[0].Text);
        }

        #endregion


    }
}
