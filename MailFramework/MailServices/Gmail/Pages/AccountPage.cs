using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
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


        public AccountPage(IWebDriver driver) : base(driver)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Wait.Until(ExpectedConditionsWrapper.TitleIs(_driverTitle));
            _logger.Info("The account configuration page is loaded");
        }


        public AccountPage OpenPersonalInformationTab()
        {
            PersonalInformationTab.Click();
            return this;
        }


        public ChangeNameTab OpenChangeNameTab()
        {
            NameField.Click();
            return new ChangeNameTab(Driver);
        }
    }
}
