using OpenQA.Selenium;
using System;

namespace MailFramework.Wrappers
{
    /// <summary>
    /// Wrapper class of Selenium.Extras.ExpectedConditions
    /// </summary>
    public class ExpectedConditionsWrapper
    {
        /// <summary>
        /// Checks whether element is visible
        /// </summary>
        /// <param name="locator">Element's locator</param>
        /// <returns>True if visible, else false</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return driver =>
            {
                try
                {
                    IWebElement tempElement = driver.FindElement(locator);
                    return tempElement.Displayed ? tempElement : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }


        /// <summary>
        /// Checks whether the title contains a provided substring
        /// </summary>
        /// <param name="partOfTitle">Part of a title</param>
        /// <returns>True if contains, else false</returns>
        public static Func<IWebDriver, bool> TitleContains(string partOfTitle)
        {
            return driver =>
            {
                return driver.Title.Contains(partOfTitle);
            };
        }


        /// <summary>
        /// Checks whether the title is simmilar to provided
        /// </summary>
        /// <param name="title">Title for comparing</param>
        /// <returns>True if equal, else false</returns>
        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return driver =>
            {
                return driver.Title == title;
            };
        }
    }
}
