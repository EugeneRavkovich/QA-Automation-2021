using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TheLongestSequence.Tests
{
    [TestClass]
    public class DigitsSequenceFinderTests
    {
        [TestMethod]
        public void GetTheLongestIdenticalDigitsSequenceLength_EmptyInput_ReturnZero()
        {
            string sequence = string.Empty;

            var actual = sequence.GetTheLongestIdenticalDigitsSequenceLength();

            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetTheLongestIdenticalDigitsSequenceLength_NullInput_ThrowArgumentException()
        {
            string sequence = null;

            Assert.ThrowsException<ArgumentException>(() => sequence.GetTheLongestIdenticalDigitsSequenceLength());
        }


        [TestMethod]
        [DataRow("111233", 3)]    // subsequence at the beginning of the sequence
        [DataRow("1122233", 3)]    // subsequence in the center of the sequence
        [DataRow("12333", 3)]    // subsequence at the end of the sequence
        [DataRow("as11fdвп{}111qw", 3)]    // non-digits characters between digits sequence && digits subsequence starts with non-digits characters
        [DataRow("111dsa[", 3)]    // subsequence ends with non-digits characters
        [DataRow("asdsa[]qweпри", 0)]    // a sequence of non-digits
        public void GetTheLongestIdenticalDigitsSequenceLength_VariousInput_CorrectResult(string sequence, int expected)
        {
            var actual = sequence.GetTheLongestIdenticalDigitsSequenceLength();
            Assert.AreEqual(expected, actual);
        }
    }
}
