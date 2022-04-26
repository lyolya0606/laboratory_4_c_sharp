using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace laboratory_4.Tests {
    [TestClass()]
    public class DatabaseWorkTests {
        [TestMethod()]
        public void AddTest() {
            DatabaseWork work = new DatabaseWork();
            int expected = 4;
            work.Add("6", "xxx", "yyy", "e", "33", 9, "TestDefaultConnection");
            int result = work.GetCount("TestDefaultConnection");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DeleteTest() {
            DatabaseWork work = new DatabaseWork();
            int expected = 3;
            work.Delete("6", "TestDefaultConnection");
            int result = work.GetCount("TestDefaultConnection");
            Assert.AreEqual(expected, result);
        }
    }
}