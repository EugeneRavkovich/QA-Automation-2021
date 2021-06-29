using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeralSystems.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        [DataRow(2, "-10000000000000000000000000000000")]
        [DataRow(10, "-2147483648")]
        [DataRow(11, "-A02220282")]
        [DataRow(20, "-1DB1F928")]
        public void ConverterMinIntValue(int systemBase, string expectedResult)
        {
            Assert.AreEqual(expectedResult, Converter.Convert(int.MinValue, systemBase));
        }


        [TestMethod]
        [DataRow(2, "1111111111111111111111111111111")]
        [DataRow(10, "2147483647")]
        [DataRow(11, "A02220281")]
        [DataRow(20, "1DB1F927")]
        public void ConverterMaxIntValuePositive(int systemBase, string expectedResult) 
        {
            Assert.AreEqual(expectedResult, Converter.Convert(int.MaxValue, systemBase));
        }


        [TestMethod]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(20)]
        public void ConverterZeroPositive(int systemBase) 
        {
            Assert.AreEqual("0" , Converter.Convert(0, systemBase));
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        [DataRow(1)]
        [DataRow(21)]
        public void ConverterSystemBaseOutOfBoundary(int systemBase) 
        {
            var result = Converter.Convert(32132131, systemBase);
        }
    }
}
