using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            var loginFb = new LoginFb();
            var loginHana = new LoginHana();

            string Profile = "profile";
            ChromeOptions option = new ChromeOptions();
            if (!Directory.Exists(Profile))
            {
                Directory.CreateDirectory(Profile);
            }
            if (Directory.Exists(Profile))
            {
                string name = "100027294830101";
                option.AddArgument("user-data-dir=" + Profile + "\\" + name);
            }


            IWebDriver chromeDriver = new ChromeDriver(option);


            var re = loginFb.LoginFacebook(chromeDriver);
            if (re == "Ok")
            {
                // thao tac tiep
                loginHana.LoginHanaa(chromeDriver);
                loginHana.SelectAccount("", chromeDriver);

            }
            else
            {
                // bao loi co the tai khoan bi check point
            }



            //loginfb.LoginFbWithCookie(cookie, chromeDriver);

            //loginfb.LoginFbWithUidAndPass("vuvantinh_hp1993@yahoo.com", "anhyeuemnhieu", chromeDriver);


            Thread.Sleep(10000);

            chromeDriver.Close();
            chromeDriver.Quit();

        }

    }
}
