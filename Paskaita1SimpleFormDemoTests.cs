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
    public class Paskaita1SimpleFormDemoTests
    {
        [Test]
        public static void TestSingleInputField()
        {
            // pakelia browser
            IWebDriver driver = new ChromeDriver(); // sukuriame nauja kintamaji driver, IWebdriver tipo
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html"; // kuriam priskiriame narsykle   
            driver.Manage().Window.Maximize(); // maksimizuojame puslapi

            Thread.Sleep(5000);
            IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            popup.Click();


            // reikia isidentifikuoti elementus, susiranda web elementa
            IWebElement inputField = driver.FindElement(By.Id("user-message"));

            // tekstas, kuris bus irasomas i inputField
            string myText = "Hello";

            //iraso teksta i inputField
            inputField.SendKeys(myText);

            //popup identifikacija
            //IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            //popup.Click();

            //identifikuoja showMessage mygtuka
            IWebElement showMessageButton = driver.FindElement(By.CssSelector("#get-input > button"));
            showMessageButton.Click();


            //Identifikuojam actual result elemeta
            IWebElement actualResultText = driver.FindElement(By.Id("display"));

            //Tikrinam Expected vs Actual
            Assert.AreEqual(myText, actualResultText.Text, "Text is not correct");
            Assert.IsTrue(actualResultText.Text.Contains("Hello"));
            
            //Uzdaro driver'i
            //driver.Quit();
        }
    }
}
