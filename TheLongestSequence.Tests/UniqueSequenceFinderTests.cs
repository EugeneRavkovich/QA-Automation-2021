using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TheLongestSequence.Tests
{
    [TestClass]
    public class UniqueSequenceFinderTests
    {
        [TestMethod]
        public void GetTheLongestUniqueSubsequenceLength_EmptyInput_ReturnZero()
        {
            string sequence = string.Empty;

            var actual = sequence.GetTheLongestUniqueSubsequenceLength();

            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetTheLongestUniqueSubsequenceLength_NullInput_ThrowArgumentException()
        {
            string sequence = null;

            Assert.ThrowsException<ArgumentException>(() => sequence.GetTheLongestUniqueSubsequenceLength());
        }


        [TestMethod]
        [DataRow("abcb", 3)]    // subsequence at the beginning of the sequence
        [DataRow("abcattm", 4)]    // subsequence in the center of the sequence
        [DataRow("abcb1efgh", 7)]    // subsequence at the end of the sequence
        [DataRow("1111111", 1)]    // identical characters as input
        public void GetTheLongestUniqueSubsequenceLength_VariousInput_CorrestResult(string sequence, int expected)
        {
            var actual = sequence.GetTheLongestUniqueSubsequenceLength();

            Assert.AreEqual(expected, actual);
        }
    }
}
