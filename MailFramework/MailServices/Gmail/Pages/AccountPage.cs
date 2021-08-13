using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    public class AccountPage: BasePage
    {
        private readonly By _personalInformationLocator = By.XPath("(//a[@href='personal-info?gar=1'])[2]");

        private readonly By _nameFieldLocator = By.XPath("//a[@href='name?gar=1']");

        private readonly string _driverTitle = "Аккаунт Google";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public AccountPage(IWebDriver driver) : base(driver)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Wait.Until(ExpectedConditions.TitleIs(_driverTitle));
            _logger.Info("The account configuration page is loaded");
        }


        public AccountPage OpenPersonalInformationTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_personalInformationLocator));
            Driver.FindElement(_personalInformationLocator).Click();
            return this;
        }


        public ChangeNameTab OpenChangeNameTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_nameFieldLocator));
            Driver.FindElement(_nameFieldLocator).Click();
            return new ChangeNameTab(Driver);
        }
    }
}
