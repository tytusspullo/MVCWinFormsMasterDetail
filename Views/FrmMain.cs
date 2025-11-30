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
        List<GrupaPracownicza> grupyPracownicze = null;
        public FrmMain()
        {
            IsMdiContainer = true;

            InitializeComponent();
        }

        private void Load()
        {
            grupyPracownicze = new List<GrupaPracownicza>();
            //LoadSampleData();
            var view = new FrmGrupyPracownicze();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
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

        private void LoadSampleData()
        {
            grupyPracownicze.Clear();
            var grupa = new GrupaPracownicza();
            grupa.IdGrupyPracowniczej = 1;
            grupa.NazwaGrupyPracowniczej = "Apteka";
            grupa.Pracownicy.Add(new Pracownik(11, "Nowak", "Jan"));
            grupa.Pracownicy.Add(new Pracownik(12, "Kowalski", "Piotr"));
            grupyPracownicze.Add(grupa);

            var grupa2 = new GrupaPracownicza();
            grupa2.IdGrupyPracowniczej = 2;
            grupa2.NazwaGrupyPracowniczej = "Odzial Chemioterapi";
            grupa2.Pracownicy.Add(new Pracownik(13, "Orzel", "Ryszard"));
            grupa2.Pracownicy.Add(new Pracownik(14, "Nowakowski", "Karol"));
            grupyPracownicze.Add(grupa2);

            var grupa3 = new GrupaPracownicza();
            grupa3.IdGrupyPracowniczej = 3;
            grupa3.NazwaGrupyPracowniczej = "Odzial Ratunkowy";
            grupa3.Pracownicy.Add(new Pracownik(15, "Kowalski", "Jan"));
            grupyPracownicze.Add(grupa3);
        }


        
    }
}
