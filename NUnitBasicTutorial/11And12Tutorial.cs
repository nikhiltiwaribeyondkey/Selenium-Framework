using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using static NUnit.Framework.Constraints.Tolerance;

namespace NUnitBasicTutorial
{
    internal class _11And12Tutorial
    {
       public IWebDriver driver;
        public IWebDriver driverManager;


        [SetUp]
         public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new  ChromeDriver();
            //driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://example.com");







            //driverManager = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());


        }

        [Test]
        public void Test() {

            driver.Navigate().GoToUrl("https://www.google.com/");

            TestContext.Progress.WriteLine($"Window name {driver.Title} and {driver.Url}");

            IWebElement elementUsingXPath = driver.FindElement(By.XPath("//*[@id='APjFqb']"));
            //*[@id="APjFqb"]
            elementUsingXPath.SendKeys("youtube");
            elementUsingXPath.SendKeys(Keys.Enter);

            //IWebElement element = driver.FindElement(By.Id("APjFqb"));
            //element.SendKeys("youtube ");

            //*[@id="jZ2SBf"]/div[1]/span

            //driver.FindElement(By.XPath("//*[@id=\"jZ2SBf\"]/div[1]/span")).Click();
            //*[@id="jZ2SBf"]/div[1]/span
            //btnClickUSearch.Click();



            //driver.Manage().Window.Maximize();



            //IWebElement btnClick = driver.FindElement(By.Name("btnK"));
            //btnClick.Click();

            //IWebElement btnClickUsingXML = driver.FindElement(By.XPath("//input[@type='submit' and @aria-label='Google Search']"));
            //btnClickUsingXML.Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement searchButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Google Search']")));
            //searchButton.Click();


            //IWebElement searchButton = wait.Until(ExpectedConditions.(By.XPath("//input[@value='Google Search']")));
            //searchButton.Click();

// 

        }



        [Test]
         public void GotoUrl()
        {
            // USED when we, want to back , referesh thing Also
            //driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
             driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";


            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Nikhil");

            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("1234");

            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            Thread.Sleep(3000);

            //alert alert-danger col - md - 12
           var errorMsg= driver.FindElement(By.ClassName("alert-danger")).Text;
           TestContext.Progress.WriteLine(errorMsg);

            //// Locate the radio button using an appropriate selector
            //string radioButtonName = driver.FindElement(By.Id("usertype")).;
            //TestContext.Progress.WriteLine($"Radio Button Selected {radioButtonName}");


            // Click the radio button
            //radioButton.Click();


            //IWebElement adminRadioButton = driver.FindElement(By.XPath("//input[@type='radio' and @value='user']"));
            //adminRadioButton.Click();

            //// Assert that the Admin radio button is selected
            //Assert.IsTrue(adminRadioButton.Selected, "Admin radio button is not selected.");



            IWebElement adminRadioButton = driver.FindElement(By.XPath("//input[@type='radio' and @value='user']"));
            var textValue = adminRadioButton.GetAttribute("value");
            TestContext.Progress.WriteLine($"Radio Button Selected {textValue}");

            //adminRadioButton.Click();

            // Assert that the Admin radio button is selected
            Assert.IsNotNull(textValue, "The text value is null.");
            Assert.IsTrue(!string.IsNullOrEmpty(textValue) && textValue == "admin", "The value is not 'admin'.");


            // top to bottom
            //div[@class="form-group"][5]//span[1]//input

            //bottom to top
            //input[@id="terms"]/..



















        }
        [TearDown]
        public void TearDown() {
            // to close current window
            //driver.Close();
            //// to close all window
            //driver.Quit();
        }  

    }


}


