using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TheLongestSequence.Tests
{
    [TestClass]
    public class UniqueSequenceFinderTests
    {
        [TestMethod]
        [DataRow("tocom", 3)]
        [DataRow("mmmmmm", 1)]
        [DataRow("momomom", 2)]
        [DataRow("12312", 3)]
        [DataRow("1111", 1)]
        [DataRow("    ", 1)]
        [DataRow("", 0)]
        public void GetSubstringLengthCheckPositive(string input, int expectedLength) 
        {
            Assert.AreEqual(expectedLength, UniqueSequenceFinder.GetSubstringLength(input));
        }

        [TestMethod]
        [DataRow("tocomposite", 7)]
        [DataRow("absdfetaj", 8)]
        [DataRow("asporas", 5)]
        [DataRow("arrownrra", 4)]
        [DataRow("", 0)]
        public void GetTheLongestUniqueSubsequenceCheckPositive(string input, int expectedLength)
        {
            Assert.AreEqual(expectedLength, UniqueSequenceFinder.GetTheLongestUniqueSubsequenceLength(input));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTheLongestSubsequenceWithNullInputPositive() 
        {
            string input = null;
            input.GetTheLongestUniqueSubsequenceLength();
        }
    }
}
