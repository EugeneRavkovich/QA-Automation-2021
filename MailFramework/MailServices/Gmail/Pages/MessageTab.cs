using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    public class MessageTab: BasePage
    {
        private readonly string _driverTitle = "(без темы)";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private IWebElement MessageContent =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("(//div[@class='a3s aiL ']//div)[3]")));

        public MessageTab(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The message tab is loaded");
        }


        public string GetMessageContent()
        {
            return MessageContent.Text;
        }


        public InboxPage GetBackToTheInboxPage()
        {
            Driver.Navigate().Back();
            return new InboxPage(Driver);
        }
    }
}
