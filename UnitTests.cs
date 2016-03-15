using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortScores
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestResultInvalidInteger()
        {
            var nullResult = TestResult.FromString("BUNDY, TERESSA, 88.98");
            Assert.IsNull(nullResult, "Should have failed on too bad integer for score");
        }

        [TestMethod]
        public void TestResultTooManyColumns()
        {
            var nullResult = TestResult.FromString("BUNDY, TERESSA, 88, 98");
            Assert.IsNull(nullResult, "Should have failed on too many columns");
        }

        [TestMethod]
        public void TestResultTooFewColumns()
        {
            var nullResult = TestResult.FromString("BUNDY, 88");
            Assert.IsNull(nullResult, "Should have failed on too few columns");
        }

        [TestMethod]
        public void TestResultProperParsing()
        {
            var testResult = TestResult.FromString("BUNDY, TERESSA, 88");

            Assert.AreEqual(testResult.FirstName, "TERESSA");
            Assert.AreEqual(testResult.LastName, "BUNDY");
            Assert.AreEqual(testResult.Score, 88);

        }
    }
}
