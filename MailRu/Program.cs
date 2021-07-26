using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using MailRu.Pages;
using OpenQA.Selenium.Support.UI;
using MailRu.Helpers;

namespace MailRu
{
    class Program
    {
        static void Main(string[] args)
        {
            MailRuHelper.InitBrowser();
            var ip = MailRuHelper.DoLogin("gaaasmanov", "password1_9pass");
            Console.WriteLine(ip.IsMessageNotRead());
            Console.WriteLine(ip.IsCorrectAddressee("Антон Антонов"));
            Console.WriteLine(MailRuHelper.IsCorrectMessage("Антон Антонов"));
           // MailRuHelper.WaitUntilMessageCome("Антон Антонов");
            Console.WriteLine(MailRuHelper.IsCorrectMessage("Антон Антонов"));
            //Console.WriteLine(MailRuHelper.IsCorrectContent("Hello!"));
            Console.WriteLine("finish");
            
            



        }
    }
}
