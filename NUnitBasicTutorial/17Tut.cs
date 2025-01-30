using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;

namespace NUnitBasicTutorial
{
    internal class _17Tut
    {

        public IWebDriver driver;
        public IWebDriver driverManager;
        public WebDriverWait wait;


        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
     
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));



        }

        [Test]
        public void DropDownTest()
        {
            IWebElement dropDownElement = driver.FindElement(By.XPath("//div[@class=\"form-group\"]//select[@class=\"form-control\"]"));
             Assert.IsNotNull(dropDownElement,"Not Empty");
            SelectElement selectElement=new SelectElement(dropDownElement);

            selectElement.SelectByText("Teacher");

            selectElement.SelectByValue("consult");
            //selectElement.SelectByIndex(1);


            IList<IWebElement> radioButtonList= driver.FindElements(By.Id("usertype")); 

            
            //radioButtonList = driver.FindElements(By.Id("#usertype"));
            


            if(radioButtonList.Count > 0)
            {
                foreach (IWebElement radioButton in radioButtonList)
                {
                    TestContext.Progress.WriteLine($"Value  {radioButton.GetDomAttribute("value")} ");
                    if (radioButton.GetAttribute("value").Equals("user"))
                    {
                        radioButton.Click();
                    }
                }
            }

            //driver.FindElement(By.Id("#okayBtn")).Click();
            //Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@id=\"okayBtn\"]")).Click();

            // Wait for an element to be visible
           
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"okayBtn\"]")));
            element.Click();



        }








        [TearDown]
        public void TearDown()
        {
            //driver.Dispose();
        }


    }
}
