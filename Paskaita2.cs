/* 2021.09.13, Julija Žinienė
 * Namų darbas:
2 Input fields
2+2
-5+3
a + b
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita2
    {
        //klases virsuje apsirasome globalius kintamuosius, siuo _driver
        //pries zodelius driver sudedame bruksnelius _driver (visur)
        public static IWebDriver _driver;

        // OneTimeSetUp gerai, tuo, kad ji parasome viena karta ir juo galima issaukti trim testam ta pati browseri
        [OneTimeSetUp]
        //OneTimeSetUp'e darome be static zodelio
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement popup = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            // funcijoje Until nurodome ka veikti; rasome e - jis iteruoja per visa html ir iesko to html elemento
            //kadangi lauksime popup, tai jo Id reikia nurodyti
            wait.Until(e => e.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            popup.Click();
        }
        //OneTimeTearDown - po visu testu uzdarys browseri, ir cia be static
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("A", "B", "NaN", TestName = "A + B = NaN")]
        public static void TestSum(string firstValue, string secondValue, string expecterResult)
        {
            IWebElement inputField = _driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            inputField.SendKeys(firstValue);

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            inputField2.Clear();
            inputField2.SendKeys(secondValue);

            IWebElement getTotalButton = _driver.FindElement(By.CssSelector("#gettotal > button"));
            getTotalButton.Click();

            IWebElement actualResult = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(expecterResult, actualResult.Text, "Sum is not correct");
        }
    }
}

