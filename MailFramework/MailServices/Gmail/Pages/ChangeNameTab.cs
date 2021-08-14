using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
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


        public ChangeNameTab(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The change name tab is opened");
        }


        public ChangeNameTab ChangeName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
            return this;
        }


        public ChangeNameTab ChangeSurname(string surname)
        {
            SurnameField.Clear();
            SurnameField.SendKeys(surname);
            return this;
        }


        public ChangeNameTab ConfirmChanges()
        {
            ConfirmButton.Click();
            return this;
        }
    }
}
