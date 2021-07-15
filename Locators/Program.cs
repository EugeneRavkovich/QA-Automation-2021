using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Locators
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Url = "https://www.bbc.com/sport";
            //IWebElement homepageButton = driver.FindElement(By.LinkText("Homepage"));
            //homepageButton.Click();
            //string welcomeText = driver.FindElement(By.ClassName("module__title")).Text;
            //Console.WriteLine(welcomeText);
            //IWebElement searchField = driver.FindElement(By.Id("orb-search-q"));
            //searchField.SendKeys("office");
            //IWebElement searchButton = driver.FindElement(By.CssSelector("button[id='orb-search-button']"));
            //searchButton.Click();
            //IWebElement sportNewsButton = driver.FindElement(By.PartialLinkText("Sport"));
            //sportNewsButton.Click();
            //IWebElement tennisNewsButton = driver.FindElement(By.CssSelector("a[href*='tennis']"));
            //tennisNewsButton.Click();
            //string tennisHeadNewsText = driver.FindElement(By.XPath("//*[@class='gs-c-promo-heading__title gel-double-pica-bold sp-o-link-split__text']")).Text;
            //Console.WriteLine(tennisHeadNewsText);


            //
            //  using XPath Axes
            //


            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.bbc.com/sport";
            IWebElement homepageButton = driver.FindElement(By.XPath("//*[@class='orb-nav-pri-container b-r b-g-p']/descendant::a[1]"));
            homepageButton.Click();
            string welcomeText = driver.FindElement(By.XPath("//*[@id='page']/descendant::h2")).Text;
            Console.WriteLine(welcomeText);
            IWebElement searchField = driver.FindElement(By.XPath("//*[@class='b-f']/descendant::input"));
            searchField.SendKeys("office");
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@class='b-f']/descendant::input/following-sibling::button"));
            searchButton.Click();
            IWebElement sportNewsButton = driver.FindElement(By.XPath("//*[@role='list']/descendant::a[4]"));
            sportNewsButton.Click();
            IWebElement tennisNewsButton = driver.FindElement(By.XPath("//*[@id='sp-nav-all-item']/preceding-sibling::ul/descendant::a[6]"));
            tennisNewsButton.Click();
            string tennisHeadNewsText = driver.FindElement(By.XPath("//*[@class='gs-c-promo-heading gs-o-faux-block-link__overlay-link sp-o-link-split__anchor gel-double-pica-bold']/descendant::h3")).Text;
            Console.WriteLine(tennisHeadNewsText);
        }
    }
}