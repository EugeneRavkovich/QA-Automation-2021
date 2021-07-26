using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    public class BasePage
    {
        private readonly int _waitTime = 15;

        public WebDriverWait Wait { get; }

        public IWebDriver Driver { get; protected set; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(_waitTime));
        }
    }
}
