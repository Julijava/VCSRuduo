/* 2021.09.13, Julija Ziniene
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita1
    {
        //public object SystemTime { get; private set; }

        // 4 yra lyginis skaicius
        // Dabar yra 11 valandu

        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even");
        }

        [Test]
        public static void TestNowIs14()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(13, currentTime.Hour, "Now is not 14");
        }
      
        [Test]
        public static void TestIf995Divisiblefrom3()
        {
            int leftOver = 995 % 3;
            Assert.AreNotEqual(0, leftOver, "995 is divisible from 3");
        }

        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(); // sukuriame nauja kintamaji driver, IWebdriver tipo
            //driver.Url = "https://promotime.lt/"; // kuriam priskiriame narsykle
            driver.Url = "https://login.yahoo.com/"; // kuriam priskiriame narsykle   
            driver.Manage().Window.Maximize(); // maksimizuojame puslapi
            //driver.Quit();
        }
        [Test]
        public static void TestFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(); // sukuriame nauja kintamaji driver, IWebdriver tipo
            driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            driver.Manage().Window.Maximize(); // maksimizuojame puslapi
            //driver.Quit();
        }
    }
}
