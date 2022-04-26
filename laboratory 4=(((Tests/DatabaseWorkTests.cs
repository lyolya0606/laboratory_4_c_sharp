using Microsoft.VisualStudio.TestTools.UnitTesting;
using laboratory_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace laboratory_4.Tests {
    [TestClass()]
    public class DatabaseWorkTests {
        [TestMethod()]
        public void AddTest() {
            DatabaseWork work = new DatabaseWork();
            int expected = 4;
            int x = work.GetCount("TestDefaultConnection"); ;
            work.Add("6", "xxx", "yyy", "e", "33", 9, "TestDefaultConnection");
            int result = work.GetCount("TestDefaultConnection");
            Assert.AreEqual(expected, result);
        }
    }
}