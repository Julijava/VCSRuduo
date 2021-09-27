/* 2021.09.15, Julija Žinienė
 *1) Užduotis:
Puslapiui https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent
parašyti testus, ar teisingai parodo jūsų naršyklę, jei paleidžiate testus su:
chrome,
firefox,
opera ar safari
(optional).
 */

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita2NamuDarbai
    {
        private static IWebDriver _driver;

        [TearDown] // rasome ne OneTearDown, t.y. be One zodzio, kad ne iskarto uzdarytu browseri
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("Chrome", TestName = "Testing Chrome")]
        [TestCase("Firefox", TestName = "Testing Firefox")]
        public static void TestBrowser(String browser)
        {
            if ("Chrome".Equals(browser))
                _driver = new ChromeDriver();
            if ("Firefox".Equals(browser))
                _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");

            IWebElement actualResult = _driver.FindElement(By.CssSelector("#primary-detection > div"));
            Assert.IsTrue(actualResult.Text.Contains(browser), $"Browser is not {browser}");
        }
    }
}
