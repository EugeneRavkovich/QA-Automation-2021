using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailFramework.Models
{
    /// <summary>
    /// Class that defines the entity of a BasePage for inheritance
    /// </summary>
    public abstract class BasePage
    {
        /// <summary>
        /// The maximum WebElement waiting time, in seconds
        /// </summary>
        private readonly int _waitTime = 30;

        /// <summary>
        /// Method for setting and getting a WebDriverWait object
        /// </summary>
        public WebDriverWait Wait { get; private set; }

        /// <summary>
        /// Method for setting and getting the WebDriver object
        /// </summary>
        public IWebDriver Driver { get; protected set; }


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">Selenium WebDriver object</param>
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(_waitTime));
        }
    }
}
