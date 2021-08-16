using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    /// <summary>
    /// A class that defines the account settings page entity
    /// </summary>
    public class AccountPage: BasePage
    {
        private IWebElement PersonalInformationTab =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("(//a[@href='personal-info?gar=1'])[2]")));
                //By.XPath("//div[text()='Личная информация']/parent::a")));

        private IWebElement NameField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//a[@href='name?gar=1']")));

        private readonly string _driverTitle = "Аккаунт Google";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public AccountPage(IWebDriver driver) : base(driver)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Wait.Until(ExpectedConditionsWrapper.TitleIs(_driverTitle));
            _logger.Info("The account configuration page is loaded");
        }


        /// <summary>
        /// Method for opening the personal information tab
        /// by pressing the "personal information" button
        /// </summary>
        /// <returns>Current page</returns>
        public AccountPage OpenPersonalInformationTab()
        {
            PersonalInformationTab.Click();
            return this;
        }


        /// <summary>
        /// Method for opening the tab for changing the alias of the account owner
        /// </summary>
        /// <returns>Current page</returns>
        public ChangeNameTab OpenChangeNameTab()
        {
            NameField.Click();
            return new ChangeNameTab(Driver);
        }
    }
}
