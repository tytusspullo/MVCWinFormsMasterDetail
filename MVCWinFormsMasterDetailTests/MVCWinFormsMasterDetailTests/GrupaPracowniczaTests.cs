using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MVCWinFormsMasterDetail;
using System.Linq;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetailTests
{
    [TestClass]
    public class GrupaPracowniczaTests
    {

        [TestMethod]
        public void DodajGrupaPracowniczaOrazZapisz()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.IdGrupyPracowniczej = 2;
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Nowak";
            controller.SaveGrupaPracownicza();

            Assert.IsTrue((grupyPracownicze.Count == 1) && grupyPracownicze[0].IdGrupyPracowniczej != 0);
        }
        [TestMethod]
        public void DodajGrupaPracowniczaOrazAnuluj()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.LoadView();
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Nowak";
            controller.CancelGrupaPracownicza();

            Assert.IsTrue((grupyPracownicze.Count == 0));
        }
        [TestMethod]
        public void DodajGrupyPracownicze()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.IdGrupyPracowniczej = 2;
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Nowak";
            controller.SaveGrupaPracownicza();
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.IdGrupyPracowniczej = 3;
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Kowalski";
            controller.SaveGrupaPracownicza();

            Assert.IsTrue((grupyPracownicze.Count == 2));
        }
        [TestMethod]
        public void EdytujGrupaPracowniczaOrazZapisz()
        {
            string newName = "Nowak-Kowalski Adam";
            string changedId = "2";

            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Nowak Piotr"));
            grupyPracownicze.Add(new GrupaPracownicza(2, "Nowak Adam"));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.SelectedGrupaPracowniczaChanged(changedId);
            controller.EditGrupaPracownicza();
            view.GrupaPracowniczaNazwa = newName;
            controller.SaveGrupaPracownicza();

            var grupaPracownicza = grupyPracownicze.SingleOrDefault(w => w.IdGrupyPracowniczej.ToString() == changedId);

            Assert.IsTrue(grupaPracownicza.NazwaGrupyPracowniczej == newName);
        }
        [TestMethod]
        public void EdytujGrupaPracowniczaOrazAnuluj()
        {
            string newName = "Nowak-Kowalski Adam";
            string oldName = "Nowak Adam";
            string changedId = "2";

            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Nowak Piotr"));
            grupyPracownicze.Add(new GrupaPracownicza(2, oldName));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.SelectedGrupaPracowniczaChanged(changedId);
            controller.EditGrupaPracownicza();
            view.GrupaPracowniczaNazwa = newName;
            controller.CancelGrupaPracownicza();

            var grupaPracownicza = grupyPracownicze.SingleOrDefault(w => w.IdGrupyPracowniczej.ToString() == changedId);

            Assert.IsTrue(grupaPracownicza.NazwaGrupyPracowniczej == oldName);
        }
        [TestMethod]
        public void UsunGrupaPracownicza()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Nowak Piotr"));
            grupyPracownicze.Add(new GrupaPracownicza(2, "Nowak Adam"));
            grupyPracownicze.Add(new GrupaPracownicza(3, "Nowak Ryszard"));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.SelectedGrupaPracowniczaChanged("2");
            controller.RemoveGrupaPracownicza();

            Assert.IsTrue(grupyPracownicze.Count == 2);
        }
        [TestMethod]
        public void DodajGrupaPracowniczaDodajPracownika()
        {
            string nazwaGrupyPracowniczej = "SOR";
            string imiePracownika = "Karol";
            string nazwiskoPracownika = "Nowak";
            
            var view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.AddGrupaPracownicza();
            view.GrupaPracowniczaNazwa = nazwaGrupyPracowniczej;
            controller.AddPracownik();
            view.PracownikImie = imiePracownika;
            view.PracownikNazwisko = nazwiskoPracownika;
            controller.SavePracownik();
            controller.SaveGrupaPracownicza();

            Assert.IsTrue(grupyPracownicze[0].NazwaGrupyPracowniczej == nazwaGrupyPracowniczej &&
                        grupyPracownicze[0].Pracownicy.Count == 1);
        }
        [TestMethod]
        public void EdytujGrupaPracowniczaDodajPracownika()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Apteka"));
            grupyPracownicze.Add(new GrupaPracownicza(2, "Oddział Rehabilitacji"));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.SelectedGrupaPracowniczaChanged("2");
            controller.EditGrupaPracownicza();
            controller.AddPracownik();
            controller.EditedPracownik.Imie = "Piotr";
            controller.EditedPracownik.Nazwisko = "Nowak";
            controller.SavePracownik();
            controller.SaveGrupaPracownicza();
            Assert.IsTrue(grupyPracownicze[1].Pracownicy.Count == 1);
        }
        [TestMethod]
        public void EdytujGrupaPracowniczaUsunPracownika()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();

            grupyPracownicze.Add(new GrupaPracownicza(1, "Apteka"));
            var grupaZPracownikami = new GrupaPracownicza(2, "Oddział Rehabilitacji");
            grupaZPracownikami.Pracownicy.Add(new Pracownik(11, "Nowak", "Janusz"));
            grupaZPracownikami.Pracownicy.Add(new Pracownik(12, "Kowalski", "Zbigniew"));
            grupyPracownicze.Add(grupaZPracownikami);
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.SelectedGrupaPracowniczaChanged("2");
            controller.EditGrupaPracownicza();
            controller.SelectedPracownikChanged("12");
            controller.RemovePracownik();
            controller.SaveGrupaPracownicza();
            
            Assert.IsTrue(grupyPracownicze[1].Pracownicy.Count == 1);
        }
        [TestMethod]
        public void GrupaPracowniczaTestKopii()
        {
            GrupaPracownicza grupa = new GrupaPracownicza();
            grupa.IdGrupyPracowniczej = 10;
            grupa.NazwaGrupyPracowniczej = "Apteka";

            var pracownik1 = new Pracownik(1, "Nowak", "Janusz");
            var pracownik2 = new Pracownik(2, "Kowalski", "Zbigniew");
            var pracownik3 = new Pracownik(3, "Nowak", "Ania");
            grupa.Pracownicy.Add(pracownik1);
            grupa.Pracownicy.Add(pracownik2);
            grupa.Pracownicy.Add(pracownik3);

            GrupaPracownicza kopia = (GrupaPracownicza)grupa.Clone();

            Assert.IsTrue(kopia.IdGrupyPracowniczej == grupa.IdGrupyPracowniczej &&
                            kopia.NazwaGrupyPracowniczej == grupa.NazwaGrupyPracowniczej &&
                            kopia.Pracownicy.Count == grupa.Pracownicy.Count
                );
        }
        [TestMethod]
        public void PracownikTestKopii()
        {
            Pracownik pracownik = new Pracownik(2,"Kowalski","Tadeusz");
            Pracownik kopia = (Pracownik)pracownik.Clone();
            
            Assert.IsTrue(kopia.Nazwisko == pracownik.Nazwisko &&
                            kopia.Imie == pracownik.Imie &&
                            kopia.IdPracownika == pracownik.IdPracownika);
        }
    }
}
