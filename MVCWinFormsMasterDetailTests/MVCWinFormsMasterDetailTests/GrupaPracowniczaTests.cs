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
    }
}
