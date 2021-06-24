using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_first_prog
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.onliner.by/";
            IWebElement catalog = driver.FindElement(By.LinkText("Каталог"));
            catalog.Click();
            IWebElement electronics = driver.FindElement(By.XPath("//*[@data-id='1']"));
            electronics.Click();
            IWebElement mobilePhonesAndAccessories = driver.FindElement(By.ClassName("catalog-navigation-list__aside-title"));
            mobilePhonesAndAccessories.Click();
            IWebElement mobilePhones = driver.FindElement(By.XPath("//*[@class='catalog-navigation-list__dropdown-list']/a[1]"));
            mobilePhones.Click();
            String telephoneModel = driver.FindElement(By.XPath("//*[@data-bind='html: product.extended_name || product.full_name']")).Text;
            String telephonePrice = driver.FindElement(By.XPath("//*[@class='schema-product__price-value schema-product__price-value_primary']/span")).Text;

            Console.WriteLine("\nThe first mobile phone on the first page: \n"+ 
                        "Model: " + telephoneModel + "\nPrice: " + telephonePrice);
        }
    }
}
