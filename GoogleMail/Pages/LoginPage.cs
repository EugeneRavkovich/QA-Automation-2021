using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    public class LoginPage: BasePage
    {
        private readonly By _usernameFieldLocator = By.XPath("//input[@type='email']");

        private readonly By _confirmButtonLocator = By.XPath("//span[text()='Далее']");

        private readonly By _passwordFieldLocator = By.XPath("//input[@type='password']");

        private readonly string _driverTitle = "Gmail";

        private readonly By _incorrectUsernameMessageLocator = By.XPath("//div[text()[contains(., 'Не удалось')]]");

        private readonly By _emptyUsernameMessageLocator = By.XPath("//div[text()[contains(., 'Введите адрес')]]");

        private readonly By _incorrectPasswordMessageLocator = By.XPath("//span[contains(text(), 'Неверный')]");

        private readonly By _emptyPasswordMessageLocator = By.XPath("//span[text()[contains(., 'Введите пароль')]]");


        public LoginPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
        }


        public LoginPage EnterUsername(string username)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_usernameFieldLocator));
            Driver.FindElement(_usernameFieldLocator).SendKeys(username);
            return this;
        }


        public LoginPage ConfirmUsername()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return this;
        }


        public LoginPage EnterPassword(string password)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_passwordFieldLocator));
            Driver.FindElement(_passwordFieldLocator).SendKeys(password);
            return this;
        }


        public InboxPage ConfirmPassword()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_confirmButtonLocator));
            Driver.FindElement(_confirmButtonLocator).Click();
            return new InboxPage(Driver);
        }


        public bool IsIncorrectUsernameMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_incorrectUsernameMessageLocator));
            var incorrectUsernameMessage = Driver.FindElement(_incorrectUsernameMessageLocator);
            return incorrectUsernameMessage != null;
        }


        public bool IsEmptyUsernameMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_emptyUsernameMessageLocator));
            var emptyUsernameMessage = Driver.FindElement(_emptyUsernameMessageLocator);
            return emptyUsernameMessage != null;
        }


        public bool IsIncorrectPasswordMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_incorrectPasswordMessageLocator));
            var incorrectPasswordMessage = Driver.FindElement(_incorrectPasswordMessageLocator);
            return incorrectPasswordMessage != null;
        }


        public bool IsEmptyPasswordMessageShown()
        {
            Wait.Until(ExpectedConditions.ElementExists(_emptyPasswordMessageLocator));
            var emptyPasswordMessage = Driver.FindElement(_emptyPasswordMessageLocator);
            return emptyPasswordMessage != null;
        }
    }
}