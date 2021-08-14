using OpenQA.Selenium;
using System;

namespace MailFramework.Wrappers
{
    public class ExpectedConditionsWrapper
    {
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


        public static Func<IWebDriver, bool> TitleContains(string partOfTitle)
        {
            return driver =>
            {
                return driver.Title.Contains(partOfTitle);
            };
        }


        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return driver =>
            {
                return driver.Title == title;
            };
        }
    }
}
