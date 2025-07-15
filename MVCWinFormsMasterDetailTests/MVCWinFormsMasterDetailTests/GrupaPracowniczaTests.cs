using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MVCWinFormsMasterDetail;
using System.Linq;

namespace MVCWinFormsMasterDetailTests
{
    [TestClass]
    public class GrupaPracowniczaTests
    {

        [TestMethod]
        public void DodajGrupaPracownicza()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            controller.AddGrupaPracownicza();
            controller.SaveGrupaPracownicza();

            Assert.IsTrue((grupyPracownicze.Count == 1));
        }

        [TestMethod]
        public void EdytujGrupaPracownicza()
        {
            string newName = "Nowak-Kowalski Adam";
            string changedId = "2";

            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Nowak Piotr"));
            grupyPracownicze.Add(new GrupaPracownicza(2, "Nowak Adam"));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);

            controller.SelectedGrupaPracowniczaChanged("2");
            view.GrupaPracowniczaNazwa = newName;
            controller.EditGrupaPracownicza();
            controller.SaveGrupaPracownicza();

            var grupaPracownicza = grupyPracownicze.SingleOrDefault(w => w.IdGrupyPracowniczej.ToString() == changedId);

            Assert.IsTrue(grupaPracownicza.NazwaGrupyPracowniczej == newName);
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
        public void EdytujGrupaPracowniczaDodajPracownika()
        {
            FrmGrupyPracownicze view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            grupyPracownicze.Add(new GrupaPracownicza(1, "Nowak Piotr"));
            grupyPracownicze.Add(new GrupaPracownicza(2, "Nowak Adam"));
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            
            controller.SelectedGrupaPracowniczaChanged("2");
            controller.EditGrupaPracownicza();
            controller.AddPracownik();
            view.PracownikID = 3;
            view.PracownikImie = "Piotr";
            view.PracownikNazwisko = "Nowak";
            controller.SaveEditPracownik();
            Assert.IsTrue(grupyPracownicze[1].Pracownicy.Count == 1);
        }


        [TestMethod]
        public void GrupaPracowniczaTestKopii()
        {
            bool pozycjeKopii = false;

            GrupaPracownicza grupa = new GrupaPracownicza();
            grupa.IdGrupyPracowniczej = 10;
            grupa.NazwaGrupyPracowniczej = "Apteka";
            //pozycje
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
            var kopia = pracownik.Clone();
            bool same = ReferenceEquals(pracownik, kopia);
            Assert.IsTrue(same);
        }
    }
}
