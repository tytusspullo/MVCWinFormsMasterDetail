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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            IsMdiContainer = true;

            InitializeComponent();
        }

        private void Load()
        {
            List<GrupaPracownicza> grupyPracownicze = new List<GrupaPracownicza>();

            GrupaPracownicza grupa = new GrupaPracownicza();
            grupa.IdGrupyPracowniczej = 1;
            grupa.NazwaGrupyPracowniczej = "Apteka";
            grupa.Pracownicy.Add(new Pracownik(11, "Nowak", "Jan"));
            grupa.Pracownicy.Add(new Pracownik(12, "Kowalski", "Piotr"));
            grupyPracownicze.Add(grupa);

            GrupaPracownicza grupa2 = new GrupaPracownicza();
            grupa2.IdGrupyPracowniczej = 2;
            grupa2.NazwaGrupyPracowniczej = "Odzial Chemioterapi";
            grupa2.Pracownicy.Add(new Pracownik(13, "Orzel", "Ryszard"));
            grupa2.Pracownicy.Add(new Pracownik(14, "Nowakowski", "Karol"));
            grupyPracownicze.Add(grupa2);

            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            GrupyPracowniczeController controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.LoadView();
            view.Show();
        }

        private void grupyPracowniczeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
