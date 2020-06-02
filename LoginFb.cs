using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hana
{
    public class LoginFb
    {
        public void LoginFbWithCookie(string cookies, IWebDriver chromeDriver)
        {
            chromeDriver.Url = "https://facebook.com";
            cookies = cookies.Replace(" ", "");
            var listCookie = cookies.Split(';');
            foreach (string e in listCookie)
            {
                var val = e.Split('=');
                try
                {
                    chromeDriver.Manage().Cookies.AddCookie(new Cookie(val[0], val[1]));
                }
                catch
                {
                    MessageBox.Show("bạn phải tắt chrome" + "trước khi chạy");
                }
            }
            chromeDriver.Url = "https://mbasic.facebook.com";
            chromeDriver.Navigate();
        }

        public ReadOnlyCollection<Cookie> GetCookieFb(IWebDriver chromeDriver)
        {
            var cookie = chromeDriver.Manage().Cookies.AllCookies;
            return cookie;
        }

        // truyên trang home fb
        public string GetUserIdFromHome(IWebDriver chromeDriver)
        {
            var userId = chromeDriver.FindElement(By.Name("target")).GetAttribute("value");
            return userId;
        }

        public string LoginFbWithUidAndPass(string userId, string pass, IWebDriver chromeDriver)
        {
            chromeDriver.Url = "https://facebook.com/login";
            chromeDriver.FindElement(By.Name("email")).SendKeys(userId);
            chromeDriver.FindElement(By.Name("pass")).SendKeys(pass);
            chromeDriver.FindElement(By.Name("login")).Click();
            return "Ok";
        }

    }
}
