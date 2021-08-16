using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    /// <summary>
    /// A class that defines the message tab entity
    /// </summary>
    public class MessageTab: BasePage
    {
        private readonly string _driverTitle = "(без темы)";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private IWebElement MessageContent =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("(//div[@class='a3s aiL ']//div)[3]")));


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public MessageTab(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The message tab is loaded");
        }


        /// <summary>
        /// Method for getting the last incomming message content
        /// </summary>
        /// <returns>The content of a message</returns>
        public string GetMessageContent()
        {
            return MessageContent.Text;
        }


        /// <summary>
        /// Method for leaving the message tab
        /// </summary>
        /// <returns></returns>
        public InboxPage GetBackToTheInboxPage()
        {
            Driver.Navigate().Back();
            return new InboxPage(Driver);
        }
    }
}
