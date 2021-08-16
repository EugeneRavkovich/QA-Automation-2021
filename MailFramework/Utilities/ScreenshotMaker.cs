using OpenQA.Selenium;
using System.IO;
using System;
using NUnit.Framework;

namespace MailFramework.Utilities
{
    /// <summary>
    /// Class for making a screenshots
    /// </summary>
    public class ScreenshotMaker
    {
        private const string SaveTo = ".//Screenshots/";


        /// <summary>
        /// Method for making a screenshots
        /// </summary>
        /// <param name="driver">The current state of the Selenium WebDriver object</param>
        public static void MakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(CreateFilename(), ScreenshotImageFormat.Jpeg);
        }


        /// <summary>
        /// Method for checking if directory already exists
        /// </summary>
        private static void CheckDirectory()
        {
            if (!Directory.Exists(SaveTo))
            {
                Directory.CreateDirectory(SaveTo);
            }
        }


        /// <summary>
        /// Method for creating a filename for picture
        /// </summary>
        /// <returns>New unique name</returns>
        private static string CreateFilename()
        {
            string longdate = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string testName = TestContext.CurrentContext.Test.FullName;
            CheckDirectory();
            return SaveTo + testName + longdate + ".jpg";
        }
    }
}
