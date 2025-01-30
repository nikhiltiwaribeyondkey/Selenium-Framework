using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using AngleSharp.Dom;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Diagnostics;

namespace NUnitBasicTutorial
{
    internal class AlertPratice
    {


        public IWebDriver driver;
        public IWebDriver driverManager;
        public WebDriverWait wait;

        IAlert alert;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();



            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            //driver.Url = "https://www.beyondkey.com/";

            //// Implicit Wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //// Explicit Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));



        }

        [Test]
        public void AlertTest()
        {
            driver.FindElement(By.Id("name")).SendKeys("Nikhil");
            driver.FindElement(By.Id("alertbtn")).Click();

            //  alert.Accept();
            //// Or dismiss alert
            //alert.Dismiss();
            // Read the alert text
            alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            TestContext.Progress.WriteLine($" Alert Text {alertText}");
            alert.Accept();

            driver.SwitchTo().DefaultContent();

        }

        [Test]
        public void AutoSuggestionDropDown()
        {
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("ind");

            //Thread.Sleep(3000);

            //IList<IWebElement> optionSetElement = wait.Until(ExpectedConditions.ElementIsVisible(driver.FindElements(By.CssSelector(".ui-menu-item div")));

            //IList<IWebElement> optionSetElement=  wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElements(By.CssSelector(".ui-menu-item div"))));
          
            IList<IWebElement> optionSetElement = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".ui-menu-item div")));
            
            //IList<IWebElement> optionSetElement = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            TestContext.Progress.WriteLine($" optionValue COunt  {optionSetElement.Count}");

            if(optionSetElement.Count > 0)
            {
                foreach (IWebElement option in optionSetElement)
                {
                    String optionValue = option.Text;

                    TestContext.Progress.WriteLine($" optionValue Text {optionValue}");

                    if (optionValue.Equals("India"))
                    {
                        option.Click();
                    }
                }
            }

            
        }
        
        [Test]
        public void MouseAction()
        {
            driver.Url = "https://www.beyondkey.com/";

            IWebElement element = driver.FindElement(By.CssSelector(".tpnav a.arrowDown.firstSub "));

            var actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
        
        [Test]
        public void IframeAction()
        {


            //By Index: Switch to a frame using its index (0 - based).
            //By Name or ID: Switch to a frame using its name or id attribute.
            //By WebElement: Switch to a frame using a located IWebElement.

            ScrollingOfPage();

            //driver.SwitchTo().Frame(1);

            // By Name Switching Frame
            //driver.SwitchTo().Frame("iframe-name");

            //By ID
            //driver.SwitchTo().Frame("courses-iframe");

            // by Using Web Elemnt 
            IWebElement frameElement = driver.FindElement(By.Id("courses-iframe"));
            driver.SwitchTo().Frame(frameElement);

            driver.FindElement(By.LinkText("Blog")).Click();

            driver.SwitchTo().DefaultContent();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");

            driver.FindElement(By.XPath("//button[text()=\"Home\"]")).Click();

        }

        
        public void  ScrollingOfPage()
        {
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 500);");

            // For Bottom of Page
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            // For Top
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");

            // For particular Element 
            IWebElement element = driver.FindElement(By.Id("courses-iframe"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);



        }
    }
}
