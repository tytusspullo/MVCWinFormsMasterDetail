using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWinFormsMasterDetail;
using MVCWinFormsMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetailTests
{
    [TestClass]
    public class GrupaPracowniczaIDGeneratorTests
    {


        [TestMethod]
        public void TestGenerateForEmptyList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            var generator = new GrupaPracowniczaIDGenerator();
            var newId = generator.GenerateID(grupy);
            Assert.AreEqual(newId, 1);    
        }

        [TestMethod]
        public void TestGenerateForFilledList()
        {
            List<GrupaPracownicza> grupy = new List<GrupaPracownicza>();
            grupy.Add(new GrupaPracownicza(1,"Oddział Ratunkowy"));
            grupy.Add(new GrupaPracownicza(2, "Oddział Rehabilitacji"));
            grupy.Add(new GrupaPracownicza(3, "Apteka"));
            var generator = new GrupaPracowniczaIDGenerator();
            var newId = generator.GenerateID(grupy);
            Assert.AreEqual(newId, 4);
        }
    }
}
