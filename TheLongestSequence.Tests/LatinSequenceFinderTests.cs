using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TheLongestSequence.Tests
{
    [TestClass]
    public class LatinSequenceFinderTests
    {
        [TestMethod]
        public void GetTheLongestIdenticalLatinLettersSequenceLength_EmptyInput_ReturnZero()
        {
            string sequence = string.Empty;

            var actual = sequence.GetTheLongestIdenticalLatinLettersSequenceLength();

            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetTheLongestIdenticalLatinLettersSequenceLength_NullInput_ThrowArgumentException()
        {
            string sequence = null;

            Assert.ThrowsException<ArgumentException>(() => sequence.GetTheLongestIdenticalLatinLettersSequenceLength());
        }


        [TestMethod]
        [DataRow("aabcde", 2)]    // subsequence at the beginning of the sequence
        [DataRow("abccde", 2)]    // subsequence in the center of the sequence
        [DataRow("abcdee", 2)]    // subsequence at the end of the sequence
        [DataRow("abcdffгклfffq", 3)]    // non-Latin characters between Latin sequence && Latin subsequence starts with non-latin characters
        [DataRow("ffffйц", 4)]    // subsequence ends with non-Latin characters
        [DataRow("ыфывф13213213", 0)]    // a sequence of non-Latin characters
        public void GetTheLongestIdenticalLatinLettersSequenceLength_VariousInput_CorrectResult(string sequence, int expected)
        {
            var actual = sequence.GetTheLongestIdenticalLatinLettersSequenceLength();

            Assert.AreEqual(expected, actual);
        }
    }
}