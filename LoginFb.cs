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
        private string _url { get => "https://www.facebook.com/"; }
        private string _urlLogin { get => "https://facebook.com/login"; }
        private string _uid { get => "vuvantinh_hp1993@yahoo.com"; }
        private string _pass { get => "anhyeuemnhieu"; }

        private string _cookie { get => "xs=48%3Aw-P0pR1VHCDYdw%3A2%3A1589082242%3A1118%3A6296;c_user=100027294830101;"; }


        public string LoginFacebook(IWebDriver chromeDriver)
        {
            chromeDriver.Url = _urlLogin;
            if (chromeDriver.Url == _url)
            {
                return "Ok";
            }
            else
            {
                // tiến hành đăng nhập bằng cookie
                var re = LoginFbWithCookie(_cookie, chromeDriver);
                if (re == "Ok")
                {
                    return "Ok";
                }
                else
                {
                    var reUid = LoginFbWithUidAndPass(_uid, _pass, chromeDriver);
                    if (reUid == "Ok")
                    {
                        return "Ok";
                    }
                }
            }
            return "Ok";
        }



        public string LoginFbWithCookie(string cookies, IWebDriver chromeDriver)
        {
            chromeDriver.Url = _url;
            cookies = cookies.Replace(" ", "");
            var listCookie = cookies.Split(';');
            foreach (string e in listCookie)
            {
                var val = e.Split('=');
                if (val.Count() == 2)
                {
                    chromeDriver.Manage().Cookies.AddCookie(new Cookie(val[0], val[1]));
                }
            }
            chromeDriver.Url = _url;
            chromeDriver.Navigate();
            if (chromeDriver.Url == _url)
            {
                return "Ok";
            }
            else
            {
                return "NotOk";
            }
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
            chromeDriver.Url = _urlLogin;
            if (chromeDriver.Url != _urlLogin)
            {
                chromeDriver.FindElement(By.Name("email")).SendKeys(userId);
                chromeDriver.FindElement(By.Name("pass")).SendKeys(pass);
                chromeDriver.FindElement(By.Name("login")).Click();
                if (chromeDriver.Url == _url)
                {
                    return "Ok";
                }
            }
            return "NotOk";
        }


    }
}
