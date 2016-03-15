using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortScores
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestResultCreation()
        {
            var testResult = TestResult.FromString("BUNDY, TERESSA, 88");

            Assert.AreEqual(testResult.FirstName, "TERESSA");
            Assert.AreEqual(testResult.LastName, "BUNDY");
            Assert.AreEqual(testResult.Score, 88);

            var nullResult = TestResult.FromString("BUNDY, TERESSA, 88, 98");
            Assert.IsNull(nullResult, "Should have failed on too many columns");

            nullResult = TestResult.FromString("BUNDY, TERESSA, 88.98");
            Assert.IsNull(nullResult, "Should have failed on too bad integer for score");
        }
    }
}
