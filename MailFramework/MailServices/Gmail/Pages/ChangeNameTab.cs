using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    /// <summary>
    /// A class that defines the chagne name tab entity
    /// </summary>
    public class ChangeNameTab: BasePage
    {
        private IWebElement NameField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()='Имя']/following::input")));

        private IWebElement SurnameField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()='Фамилия']/following::input")));

        private IWebElement ConfirmButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()='Сохранить']")));

        private readonly string _driverTitle = "Имя";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public ChangeNameTab(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The change name tab is opened");
        }


        /// <summary>
        /// Method for changing the name of the account owner 
        /// </summary>
        /// <param name="name">A new name for replacing</param>
        /// <returns>Current page</returns>
        public ChangeNameTab ChangeName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
            return this;
        }


        /// <summary>
        /// Method for changing the surname of the account owner
        /// </summary>
        /// <param name="surname">A new surname for replacing</param>
        /// <returns>Current page</returns>
        public ChangeNameTab ChangeSurname(string surname)
        {
            SurnameField.Clear();
            SurnameField.SendKeys(surname);
            return this;
        }


        /// <summary>
        /// Method for confirming changes by pressing the confirmation button
        /// </summary>
        /// <returns>Current page</returns>
        public ChangeNameTab ConfirmChanges()
        {
            ConfirmButton.Click();
            return this;
        }
    }
}
