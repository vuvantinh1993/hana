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
            var loginfb = new LoginFb();
            string Profile = "profile";
            ChromeOptions option = new ChromeOptions();
            if (!Directory.Exists(Profile))
            {
                Directory.CreateDirectory(Profile);
            }

            if (Directory.Exists(Profile))
            {
                int name = 5;
                option.AddArgument("user-data-dir=" + Profile + "\\" + name);
            }


            IWebDriver chromeDriver = new ChromeDriver(option);

            var cookie = "sb=JQbRXp_GOlvgC4ZJduuIa_Mx; datr=JQbRXls0BfS96Ou9yuNSqSpk; wd=1920x367; c_user=100005592542762; xs=42%3AMKNvdnBC4IJy-w%3A2%3A1591059537%3A15340%3A6317; fr=0UrxUXk4dBlVnXO9E.AWUv6SnE5HwRCoBdZVIlb65nbyE.Be0PVg.DJ.F7R.0.0.Be1aRQ.AWVLnt6_; spin=r.1002190679_b.trunk_t.1591059537_s.1_v.2_; presence=EDvF3EtimeF1591059539EuserFA21B05592542762A2EstateFDutF1591059539352CEchF_7bCC";

            loginfb.LoginFbWithCookie(cookie, chromeDriver);

            //loginfb.LoginFbWithUidAndPass("vuvantinh_hp1993@yahoo.com", "anhyeuemnhieu", chromeDriver);


            Thread.Sleep(20000);

            chromeDriver.Close();
            chromeDriver.Quit();

        }

    }
}
