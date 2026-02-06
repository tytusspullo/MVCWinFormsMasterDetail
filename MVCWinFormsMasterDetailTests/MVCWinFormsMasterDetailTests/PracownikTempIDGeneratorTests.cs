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
    public class PracownikTempIDGeneratorTests
    {
        [TestMethod]
        public void TestGenerateForEmptyList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            var grupa = new GrupaPracownicza(1, "Oddział Ratunkowy");
            grupy.Add(grupa);
            var generator = new PracownikTempIDGenerator();
            var newIdPracownika = generator.GenerateTempID(grupa.Pracownicy);
            Assert.AreEqual(newIdPracownika, -1);
        }

        [TestMethod]
        public void TestGenerateForFilledList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            //GrupyPracowniczeController controller = new GrupyPracowniczeController()
            //simulated db two rows.
            var grupa = new GrupaPracownicza(1, "Oddział Ratunkowy");
            grupa.Pracownicy.Add(new Pracownik(44, "Kowalski", "Piotr", grupa));
            grupa.Pracownicy.Add(new Pracownik(45, "Nowak", "Adam", grupa));
            grupy.Add(grupa);
            //added new positions

            var generator = new PracownikTempIDGenerator();
            
            var pracownik = new Pracownik(0, "Testowy", "Jan", grupa);
            pracownik.TempId = generator.GenerateTempID(grupa.Pracownicy); 
            grupa.Pracownicy.Add(pracownik);

            var pracownik2 = new Pracownik(0, "Testowy2", "Jan2", grupa);
            pracownik2.TempId = generator.GenerateTempID(grupa.Pracownicy); 
            grupa.Pracownicy.Add(pracownik2);


            Assert.AreEqual(pracownik2.TempId, -2 );
        }
    }
}
