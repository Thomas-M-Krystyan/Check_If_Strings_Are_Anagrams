using System.ComponentModel;
using CheckIfAnagrams;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIfAnagramsTests
{
    [TestClass()]
    public class StringComparisonTests
    {
        // Constants
        private const string FirstString = "Armageddon!";

        [TestMethod()]
        [DisplayName("Comparison of different strings")]
        public void Test_IfComparisonOf_DifferentStrings_ReturnsFalse()
        {
            const string secondString = "Apocalypse";

            Assert.IsFalse(StringComparison.CheckIfAnagrams(FirstString, secondString));
        }

        [TestMethod()]
        [DisplayName("Comparison of the same strings: written backward")]
        public void Test_IfComparisonOf_TheSameStrings_ButWrittenBackwards_ReturnsTrue()
        {
            const string secondString = "!noddegamrA";

            Assert.IsTrue(StringComparison.CheckIfAnagrams(FirstString, secondString));
        }

        [TestMethod()]
        [DisplayName("Comparison of the same strings: rearranged letters")]
        public void Test_IfComparisonOf_TheSameStrings_ButWithRearrangedLetters_ReturnsTrue()
        {
            const string secondString = "dnarde!mAog";

            Assert.IsTrue(StringComparison.CheckIfAnagrams(FirstString, secondString));
        }

        [TestMethod()]
        [DisplayName("Comparison of the same strings: case insensitive")]
        public void Test_IfComparisonOf_TheSameStrings_ButWithDifferentCaseSensitiveLetters_ReturnsTrue()
        {
            const string secondString = "aRmageDdOn!";

            Assert.IsTrue(StringComparison.CheckIfAnagrams(FirstString, secondString));
        }
    }
}