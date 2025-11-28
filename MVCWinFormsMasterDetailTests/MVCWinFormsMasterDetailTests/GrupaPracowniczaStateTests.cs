using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWinFormsMasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCWinFormsMasterDetailTests
{
    [TestClass]
    public class GrupaPracowniczaStateTests
    {
        public GrupaPracowniczaStateTests()
        {
        }

        [TestMethod]
        public void AddGrupaPracowniczaClicked()
        {
            var view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            grupyPracownicze.Clear();
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.IdGrupyPracowniczej = 2;
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Nowak";
            controller.UpdateViewWithGrupaPracowniczaValues(controller.EditedGrupaPracownicza);

            Assert.IsTrue(view.State is EdycjaGrupaPracowniczaState);
        }

        [TestMethod]
        public void EdycjaGrupaPracowniczaClicked()
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
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = newName;
            controller.UpdateViewWithGrupaPracowniczaValues(controller.EditedGrupaPracownicza);

            Assert.IsTrue(view.State is EdycjaGrupaPracowniczaState);
        }

        [TestMethod]
        public void SaveGrupaPracowniczaClicked()
        {
            var view = new FrmGrupyPracownicze();
            var grupyPracownicze = new List<GrupaPracownicza>();
            var controller = new GrupyPracowniczeController(view, grupyPracownicze);
            grupyPracownicze.Clear();
            controller.AddGrupaPracownicza();
            controller.EditedGrupaPracownicza.IdGrupyPracowniczej = 2;
            controller.EditedGrupaPracownicza.NazwaGrupyPracowniczej = "Nowak";
            controller.UpdateViewWithGrupaPracowniczaValues(controller.EditedGrupaPracownicza);
            controller.SaveGrupaPracownicza();

            Assert.IsTrue(view.State is PrzegladanieGrupaPracowniczaState);
        }

    }
}
