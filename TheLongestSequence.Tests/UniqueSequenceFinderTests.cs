using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TheLongestSequence.Tests
{
    [TestClass]
    public class UniqueSequenceFinderTests
    { 
        [TestMethod]
        [DataRow("tocom", "toc")]
        [DataRow("mmmmmm", "m")]
        [DataRow("momomom", "mo")]
        [DataRow("12312", "123")]
        [DataRow("1111", "1")]
        [DataRow("    ", " ")]
        public void GetSubstringCheckPositive(string input, string expected)
        {
            Assert.AreEqual(expected, UniqueSequenceFinder.GetSubstring(input));
        }


        [TestMethod]
        [DataRow("tocomposite", "mposite")]
        [DataRow("absdfetaj", "bsdfetaj")]
        [DataRow("asporas", "aspor")]
        [DataRow("arrownrra", "rown")]
        [DataRow("12344123312211", "1234")]
        public void GetTheLongestUniqueSubsequenceCheckPositive(string input, string expected) 
        {
            Assert.AreEqual(expected, UniqueSequenceFinder.GetTheLongestUniqueSubsequence(input));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTheLongestUniqueSubsequenceWithEmptyInputNegative() 
        {
            string input = string.Empty;
            input.GetTheLongestUniqueSubsequence();

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTheLongestSubsequenceWithNullInput() 
        {
            string input = null;
            input.GetTheLongestUniqueSubsequence();
        }
    }
}
