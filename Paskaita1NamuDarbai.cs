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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSRuduo
{
     public class Paskaita1NamuDarbai
    {
        [Test]
        public static void Test2plus2()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            //Thread.Sleep(5000);
            IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            popup.Click();

            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            string myText = "2";
            inputField.SendKeys(myText);

            IWebElement inputField2 = driver.FindElement(By.Id("sum2"));
            inputField2.Clear();
            string myText2 = "2";
            inputField2.SendKeys(myText2);

            IWebElement getTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            getTotalButton.Click();

            IWebElement actualResultText = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", actualResultText.Text, "Sum is not correct");
            driver.Quit();
        }

        [Test]
        public static void TestMinus5Plus3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(5000);
            IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            popup.Click();

            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            string myText = "-5";
            inputField.SendKeys(myText);

            IWebElement inputField2 = driver.FindElement(By.Id("sum2"));
            inputField2.Clear();
            string myText2 = "3";
            inputField2.SendKeys(myText2);

            IWebElement getTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            getTotalButton.Click();

            IWebElement actualResultText = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", actualResultText.Text, "Sum is not correct");
            driver.Quit();
        }
        [Test]
        public static void TestAplusB()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(5000);
            IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            popup.Click();

            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            string myText = "A";
            inputField.SendKeys(myText);

            IWebElement inputField2 = driver.FindElement(By.Id("sum2"));
            inputField2.Clear();
            string myText2 = "B";
            inputField2.SendKeys(myText2);

            IWebElement getTotalButton = driver.FindElement(By.CssSelector("#gettotal > button"));
            getTotalButton.Click();

            IWebElement actualResultText = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", actualResultText.Text, "Sum is not correct");
            driver.Quit();
        }
     }
}
