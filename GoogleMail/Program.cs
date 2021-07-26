using GoogleMail.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GoogleMail.Pages;
using System;

namespace GoogleMail
{
    class Program
    {
        static void Main(string[] args)
        {
            GmailHelper.InitBrowser();
            InboxPage ip = (InboxPage)GmailHelper.DoLogin("qwerty7312oo", "password1_8pass");
            //GmailHelper.SendMessage("gaaasmanov@mail.ru", "1231");
            //ip.OpenMessage();
            
            Console.WriteLine(ip.IsMessageNotRead());
            Console.WriteLine(ip.IsCorrectAddressee("Олег Газманов"));
            //ip.OpenMessage();
            //Console.WriteLine(ip.GetMessageContent());
            ip.OpenAvailableAccountsTab();
            AccountPage ap = ip.OpenAccountSettings();
            ap.OpenPersonalInformationTab();
        }
    }
}
