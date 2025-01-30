using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections;


namespace NUnitBasicTutorial
{
    internal class XpathPratice
    {
   
        public IWebDriver driver;
        public IWebDriver driverManager;


        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://example.com");

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";







            //driverManager = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());


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
            var errorMsg = driver.FindElement(By.ClassName("alert-danger")).Text;
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



            IWebElement adminRadioButton = driver.FindElement(By.XPath("//input[@type='radio' and @value='admin']"));
            adminRadioButton.Click();
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

            // Using Tranverse
            //IWebElement
             ArrayList <IWebElement> divElement= new ArrayList<IWebElement> ();



        }
        [TearDown]
        public void TearDown()
        {
            // to close current window
            //driver.Close();
            //// to close all window
            //driver.Quit();
        }

    }


}
