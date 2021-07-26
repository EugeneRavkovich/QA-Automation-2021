using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    public class InboxPage: BasePage
    {
        //private const string _lastMessageXpath = "//table[@id=':23']/tbody/tr[1]";
        private const string _lastMessageXpath = "//table[@role='grid']//tr[1]";
        //private const string _lastMessageXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";

        private readonly string _driverTitle = "Входящие";

        private readonly By _writeLetterButtonLocator = By.XPath("//div[@class='T-I T-I-KE L3']");

        private readonly By _recipientFieldLocator = By.XPath("//textarea[@name='to']");

        private readonly By _messageFieldLocator = By.XPath("//div[@aria-label='Тело письма']");

        private readonly By _sendMessageButtonLocator = By.XPath("//div[text()='Отправить']");

        private readonly By _lastIncommingMessageLocator = By.XPath(_lastMessageXpath);

        private readonly By _messageAddresseeLocator = By.XPath(_lastMessageXpath +
            "//span[@name]");

        private readonly By _messageContent = By.XPath("//div[@class='a3s aiL ']/div[2]/div[1]");

        private readonly By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private readonly By _manageAccountButtonLocator = By.XPath("//a[contains(text(), 'Управление')]");

        private readonly string _boldFontWeight = "700";


        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
        }


        public InboxPage OpenNewMessageTab()
        {
            Wait.Until(ExpectedConditions.ElementExists(_writeLetterButtonLocator));
            Driver.FindElement(_writeLetterButtonLocator).Click();
            return this;
        }


        public InboxPage EnterRecipient(string recipient)
        {
            Wait.Until(ExpectedConditions.ElementExists(_recipientFieldLocator));
            Driver.FindElement(_recipientFieldLocator).SendKeys(recipient);
            return this;
        }


        public InboxPage EnterMessage(string message)
        {
            Wait.Until(ExpectedConditions.ElementExists(_messageFieldLocator));
            Driver.FindElement(_messageFieldLocator).SendKeys(message);
            return this;
        }


        public InboxPage SendMessage()
        {
            Wait.Until(ExpectedConditions.ElementExists(_sendMessageButtonLocator));
            Driver.FindElement(_sendMessageButtonLocator).Click();
            return this;
        }


        public bool IsMessageNotRead()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_lastIncommingMessageLocator));
            string actualFontWeight = Driver.FindElement(_messageAddresseeLocator).GetCssValue("font-weight");
            return actualFontWeight == _boldFontWeight;
        }


        public bool IsCorrectAddressee(string addressee)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_lastIncommingMessageLocator));
            var messageAddressee = Driver.FindElement(_messageAddresseeLocator).Text;
            return messageAddressee == addressee;
        }


        public InboxPage OpenMessage()
        {
            Driver.FindElement(_lastIncommingMessageLocator).Click();
            return this;        
        }


        public string GetMessageContent()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageContent));
            return Driver.FindElement(_messageContent).Text;
        }


        public InboxPage OpenAvailableAccountsTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_availableAccountsTabLocator));
            Driver.FindElement(_availableAccountsTabLocator).Click();
            return this;
        }


        public AccountPage OpenAccountSettings()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_manageAccountButtonLocator));
            Driver.FindElement(_manageAccountButtonLocator).Click();
            return new AccountPage(Driver);
        }
    }
}
