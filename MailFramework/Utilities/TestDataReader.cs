using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace MailFramework.Utilities
{
    /// <summary>
    /// Class for reading data from resorce files
    /// </summary>
    public class TestDataReader
    {
        private static readonly string _filePath = "MailFramework/Resources/";
        //private static readonly string _filePath = "../../Resources/";

        private static readonly string _env = TestContext.Parameters["environment"];
        //private static readonly string _env = "qa";


        /// <summary>
        /// Method for getting the value by key from .json file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetTestData(string key)
        {
            var root = JObject.Parse(File.ReadAllText(_filePath + _env + ".json"));
            return root.Descendants().
                    OfType<JProperty>().
                    Where(x => x.Name == key).
                    First().Value.ToString();
        } 
    }
}
