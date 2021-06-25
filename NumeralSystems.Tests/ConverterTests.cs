using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeralSystems.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        [DataRow(2, "-10000000000000000000000000000000")]
        [DataRow(3, "-12112122212110202102")]
        [DataRow(4, "-2000000000000000")]
        [DataRow(5, "-13344223434043")]
        [DataRow(6, "-553032005532")]
        [DataRow(7, "-104134211162")]
        [DataRow(8, "-20000000000")]
        [DataRow(9, "-5478773672")]
        [DataRow(10, "-2147483648")]
        [DataRow(11, "-A02220282")]
        [DataRow(12, "-4BB2308A8")]
        [DataRow(13, "-282BA4AAB")]
        [DataRow(14, "-1652CA932")]
        [DataRow(15, "-C87E66B8")]
        [DataRow(16, "-80000000")]
        [DataRow(17, "-53G7F549")]
        [DataRow(18, "-3928G3H2")]
        [DataRow(19, "-27C57H33")]
        [DataRow(20, "-1DB1F928")]
        public void ConverterMinIntValue(int systemBase, string expectedResult)
        {
            Assert.AreEqual(expectedResult, Converter.Convert(int.MinValue, systemBase));
        }


        [TestMethod]
        [DataRow(2, "1111111111111111111111111111111")]
        [DataRow(3, "12112122212110202101")]
        [DataRow(4, "1333333333333333")]
        [DataRow(5, "13344223434042")]
        [DataRow(6, "553032005531")]
        [DataRow(7, "104134211161")]
        [DataRow(8, "17777777777")]
        [DataRow(9, "5478773671")]
        [DataRow(10, "2147483647")]
        [DataRow(11, "A02220281")]
        [DataRow(12, "4BB2308A7")]
        [DataRow(13, "282BA4AAA")]
        [DataRow(14, "1652CA931")]
        [DataRow(15, "C87E66B7")]
        [DataRow(16, "7FFFFFFF")]
        [DataRow(17, "53G7F548")]
        [DataRow(18, "3928G3H1")]
        [DataRow(19, "27C57H32")]
        [DataRow(20, "1DB1F927")]
        public void ConverterMaxIntValuePositive(int systemBase, string expectedResult) 
        {
            Assert.AreEqual(expectedResult, Converter.Convert(int.MaxValue, systemBase));
        }


        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(12)]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(15)]
        [DataRow(16)]
        [DataRow(17)]
        [DataRow(18)]
        [DataRow(19)]
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
