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
            };
        }
    }
}
