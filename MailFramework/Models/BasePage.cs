using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailFramework.Models
{
    public abstract class BasePage
    {
        private readonly int _waitTime = 15;

        public WebDriverWait Wait { get; private set; }

        public IWebDriver Driver { get; protected set; }


        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(_waitTime));
        }
    }
}
