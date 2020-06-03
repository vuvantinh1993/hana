using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hana
{
    public class LoginHana
    {
        private string _url { get => "https://fb.vieclamonline.org/"; }
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
                return "Oke";
            }
            else
            {
                var re = LoginHanaWithUidAndPass(_name, _pass, chromeDriver);
                if (re == "Ok")
                {
                    return "Ok";
                }
            }
            return "NotOk";
        }

        private string LoginHanaWithUidAndPass(string userId, string pass, IWebDriver chromeDriver)
        {
            chromeDriver.Url = _url;
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
            return "NotOk";
        }

        public string SelectAccount(string id, IWebDriver chromeDriver)
        {
            chromeDriver.FindElement(By.LinkText("Kiếm tiền")).Click();
            return "NotOk";
        }

    }
}
