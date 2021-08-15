using OpenQA.Selenium;
using System.IO;
using System;
using NUnit.Framework;

namespace MailFramework.Utilities
{
    public class ScreenshotMaker
    {
        private const string SaveTo = ".//Screenshots/";

        public static void MakeScreenshot(IWebDriver driver)
        {
            DeleteDirectory();
            CreateDirectory();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(CreateFilename(), ScreenshotImageFormat.Jpeg);
        }


        private static void DeleteDirectory()
        {
            Directory.Delete(SaveTo);
        }


        private static void CreateDirectory()
        {
            Directory.CreateDirectory(SaveTo);
        }


        private static string CreateFilename()
        {
            string longdate = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string testName = TestContext.CurrentContext.Test.FullName;
            return SaveTo + testName + longdate + ".jpg";
        }
    }
}
