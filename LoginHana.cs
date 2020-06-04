using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace hana
{
    public class LoginHana
    {
        private string _url { get => "https://fb.vieclamonline.org/"; }
        private string _urlJobfb { get => "https://fb.vieclamonline.org/jobs/facebook"; }
        private string _name { get => "vuvantinh21993"; }
        private string _pass { get => "17111993aA"; }

        // truyên trang home fb
        public string GetUserIdFromHome(IWebDriver chromeDriver)
        {
            var userId = chromeDriver.FindElement(By.Name("target")).GetAttribute("value");
            return userId;
        }

        public string LoginHanaa(IWebDriver chromeDriver)
        {
            if (chromeDriver.Url == _url)
            {
                chromeDriver.Url = _urlJobfb;
                return "Oke";
            }
            else
            {
                var re = LoginHanaWithUidAndPass(_name, _pass, chromeDriver);
                if (re == "Ok")
                {
                    chromeDriver.Url = _urlJobfb;
                    return "Ok";
                }
            }
            return "NotOk";
        }

        private string LoginHanaWithUidAndPass(string userId, string pass, IWebDriver chromeDriver)
        {
            chromeDriver.Url = _url;
            chromeDriver.Navigate();
            if (chromeDriver.Url != _url)
            {
                chromeDriver.FindElement(By.Name("username")).SendKeys(userId);
                chromeDriver.FindElement(By.Name("password")).SendKeys(pass);
                chromeDriver.FindElement(By.TagName("button")).Click();
                if (chromeDriver.Url == _url)
                {
                    return "Ok";
                }
            }
            if (chromeDriver.Url == _url)
            {
                return "Ok";
            }
            return "NotOk";
        }

        public void GetJobHana(IWebDriver chromeDriver)
        {
            chromeDriver.Url = _urlJobfb;


            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);

            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 10));
            try
            {
                wait.Until(drv => drv.FindElements(By.XPath("//a[@data-v-99f91c00]")));
                var sele = chromeDriver.FindElements(By.XPath("//a[@data-v-99f91c00]"));
                var listLinkHana = new List<string>();

                for (int i = 0; i < sele.Count; i++)
                {
                    var linkJobHana = sele[i].GetAttribute("href");
                    listLinkHana.Add(linkJobHana);
                }
                for (int i = 0; i < listLinkHana.Count; i++)
                {
                    chromeDriver.Url = listLinkHana[i];
                }
            }
            catch
            {
                chromeDriver.Url = _urlJobfb;
                chromeDriver.Navigate();
            }



            //var m = c[0].GetAttribute("href");


            Thread.Sleep(20000);
        }


        public void test(IWebDriver chromeDriver)
        {

            //To wait for element visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromTicks(5000));
            wait.Until(drv => drv.FindElement(By.XPath("//a[@data-v-99f91c00]")));


            //chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //WebElement element = (new WebDriverWait(driver, 10))
            //.until(ExpectedConditions.elementToBeClickable(By.id("someid")));



            //driver.findElement(By.xpath("//input[@id='text3']")).sendKeys("Text box is visible now");

            //System.out.print("Text box text3 is now visible");

        }

    }
}
