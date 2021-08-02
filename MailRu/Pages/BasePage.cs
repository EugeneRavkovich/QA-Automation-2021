using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages
{
    /// <summary>
    /// A class that defines an instance of a base page for inheritance
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// The maximum waiting time for the element appearing, measured in seconds
        /// </summary>
        private readonly int _waitTime = 15;

        /// <summary>
        /// Method for getting the WebDriverWait instance
        /// </summary>
        public WebDriverWait Wait { get; }

        /// <summary>
        /// An instance of a Selenium driver
        /// </summary>
        public IWebDriver Driver { get; protected set; }


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">Selenium driver instance</param>
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(_waitTime));
        }
    }
}