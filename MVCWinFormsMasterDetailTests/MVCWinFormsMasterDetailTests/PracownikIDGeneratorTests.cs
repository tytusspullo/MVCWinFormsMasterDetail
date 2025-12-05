using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWinFormsMasterDetail.Models;
using MVCWinFormsMasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetailTests
{
    [TestClass]
    public class PracownikIDGeneratorTests
    {
        [TestMethod]
        public void TestGenerateForEmptyList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            var grupa = new GrupaPracownicza(1, "Oddział Ratunkowy");
            grupy.Add(grupa);
            var generator = new PracownikIDGenerator();
            var newIdPracownika = generator.GenerateID(grupa.Pracownicy);
            Assert.AreEqual(newIdPracownika, 1);
        }

        [TestMethod]
        public void TestGenerateForFilledList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            var grupa = new GrupaPracownicza(1, "Oddział Ratunkowy");
            grupa.Pracownicy.Add(new Pracownik(44,"Kowalski","Piotr"));
            grupa.Pracownicy.Add(new Pracownik(45, "Nowak", "Adam"));
            grupy.Add(grupa);
            var generator = new PracownikIDGenerator();
            var newIdPracownika = generator.GenerateID(grupa.Pracownicy);
            Assert.AreEqual(newIdPracownika, 46);
        }
    }
}
