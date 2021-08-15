using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    public class InboxPage: BasePage
    {
        private readonly string _driverTitle = "Входящие";

        private const string _lastMessageXpath = "//table[@role='grid']//tr[1]";

        private IWebElement WriteLetterButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@class='T-I T-I-KE L3']")));

        private IWebElement RecipientField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//textarea[@name='to']")));

        private IWebElement MessageField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@aria-label='Тело письма']")));

        private IWebElement SendMessageButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[text()='Отправить']")));

        private IWebElement LastIncommingMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath(_lastMessageXpath)));

        private IWebElement MessageAddressee =>
            Driver.FindElement(By.XPath(_lastMessageXpath + "//span[@name!='я']"));

        private IWebElement MessageContent =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("(//div[@class='a3s aiL ']//div)[3]")));

        private IWebElement AvailableAccountsTab =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]")));

        private IWebElement ManageAccountButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//a[contains(text(), 'Управление')]")));

        private readonly string _boldFontWeight = "700";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The inbox page is loaded");
        }


        public InboxPage OpenNewMessageTab()
        {
            WriteLetterButton.Click();
            return this;
        }


        public InboxPage EnterRecipient(string recipient)
        {
            RecipientField.SendKeys(recipient);
            return this;
        }


        public InboxPage EnterMessage(string message)
        {
            MessageField.SendKeys(message);
            return this;
        }


        public InboxPage SendMessage()
        {
            SendMessageButton.Click();
            return this;
        }


        public bool IsMessageNotRead()
        {
            return MessageAddressee.GetCssValue("font-weight") == _boldFontWeight;
        }


        public bool IsCorrectAddressee(string addressee)
        {
            return MessageAddressee.GetAttribute("email") == addressee;
        }


        public InboxPage OpenLastIncommingMessage()
        {
            LastIncommingMessage.Click();
            return this;
        }


        public string GetMessageContent()
        {
            return MessageContent.Text;
        }


        public InboxPage OpenAvailableAccountsTab()
        {
            AvailableAccountsTab.Click();
            return this;
        }


        public AccountPage OpenAccountSettings()
        {
            ManageAccountButton.Click();
            return new AccountPage(Driver);
        }
    }
}
