using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita2CheckBoxDemo
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            //wait.Until(e => e.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            //popup.Click();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // _driver.Close();
        }

        [Test]
        public static void TestSingleCheckBoxDemo()
        {
            IWebElement singleCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            singleCheckBox.Click();

            IWebElement singleCheckBoxResult = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(singleCheckBoxResult.Text.Contains("Success"));
        }

        [Test]
        public static void TestMultipleCheckBox()
        {
            IReadOnlyCollection<IWebElement> multipleCheckBoxes = _driver.FindElements(By.ClassName("cb1-element")); // identifikuoja elementu sarasa

            foreach (IWebElement checkBox in multipleCheckBoxes)
            {
                checkBox.Click();
            }
        }

        [Test]
        public static void TestButton()
        {
            IWebElement button = _driver.FindElement(By.CssSelector("#check1"));
            if (button.GetAttribute("value").Equals("Check All"))
            {
                button.Click();
            }
        }
    }
}




