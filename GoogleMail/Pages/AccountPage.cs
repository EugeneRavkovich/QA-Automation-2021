using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    /// <summary>
    /// A class that defines the account settings page entity
    /// </summary>
    public class AccountPage: BasePage
    {
        private readonly By _personalInformationLocator = By.XPath("(//a[@href='personal-info?gar=1'])[2]");

        private readonly By _nameFieldLocator = By.XPath("//a[@href='name?gar=1']");

        private readonly By _nameLocator = By.XPath("//span[text()='Имя']/following::input");

        private readonly By _surnameLocator = By.XPath("//span[text()='Фамилия']/following::input");

        private readonly By _confirmButtonLocator = By.XPath("//span[text()='Сохранить']");

        private readonly string _driverTitle = "Аккаунт Google";


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public AccountPage(IWebDriver driver) : base(driver)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Wait.Until(ExpectedConditions.TitleIs(_driverTitle));
        }


        /// <summary>
        /// Method for opening the personal information tab
        /// by pressing the "personal information" button
        /// </summary>
        /// <returns>Current page</returns>
        public AccountPage OpenPersonalInformationTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_personalInformationLocator));
            Driver.FindElement(_personalInformationLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for opening the tab for changing the alias of the account owner
        /// </summary>
        /// <returns>Current page</returns>
        public AccountPage OpenChangeNameTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_nameFieldLocator));
            Driver.FindElement(_nameFieldLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for changing the name of the account owner 
        /// </summary>
        /// <param name="name">A new name for replacing</param>
        /// <returns>Current page</returns>
        public AccountPage ChangeName(string name)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_nameLocator));
            Driver.FindElement(_nameLocator).Clear();
            Driver.FindElement(_nameLocator).SendKeys(name);
            return this;
        }


        /// <summary>
        /// Method for changing the surname of the account owner
        /// </summary>
        /// <param name="surname">A new surname for replacing</param>
        /// <returns>Current page</returns>
        public AccountPage ChangeSurname(string surname)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_surnameLocator));
            Driver.FindElement(_surnameLocator).Clear();
            Driver.FindElement(_surnameLocator).SendKeys(surname);
            return this;
        }


        /// <summary>
        /// Method for confirming changes by pressing the confirmation button
        /// </summary>
        /// <returns></returns>
        public AccountPage ConfirmChanges()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return this;
        }
    }
}