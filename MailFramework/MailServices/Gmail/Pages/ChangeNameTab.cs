using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MailFramework.Models;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    public class ChangeNameTab: BasePage
    {
        private readonly By _nameLocator = By.XPath("//span[text()='Имя']/following::input");

        private readonly By _surnameLocator = By.XPath("//span[text()='Фамилия']/following::input");

        private readonly By _confirmButtonLocator = By.XPath("//span[text()='Сохранить']");

        private readonly string _driverTitle = "Имя";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public ChangeNameTab(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
            _logger.Info("The change name tab is opened");
        }


        public ChangeNameTab ChangeName(string name)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_nameLocator));
            Driver.FindElement(_nameLocator).Clear();
            Driver.FindElement(_nameLocator).SendKeys(name);
            return this;
        }


        public ChangeNameTab ChangeSurname(string surname)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_surnameLocator));
            Driver.FindElement(_surnameLocator).Clear();
            Driver.FindElement(_surnameLocator).SendKeys(surname);
            return this;
        }


        public ChangeNameTab ConfirmChanges()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return this;
        }
    }
}
