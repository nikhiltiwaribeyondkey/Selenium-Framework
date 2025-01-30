using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace NUnitBasicTutorial
{
    internal class Action
    {
        public IWebDriver driver;
        public IWebDriver driverManager;
        public WebDriverWait wait;
        Actions actions;

        IAlert alert;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
             actions = new Actions(driver);



            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            //driver.Url = "https://www.beyondkey.com/";


            //// Implicit Wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //// Explicit Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));



        }

        [Test]
        public  void MouseClick()
        {
            IWebElement element= driver.FindElement(By.CssSelector("div[class='tpnavMenu'] a:nth-child(1)"));
             actions.MoveToElement(element).Click().Perform();

        }
        [Test]
        public void MouseActionHoverAndClickForDragNDrop()
        {
          

            IWebElement element = driver.FindElement(By.CssSelector(".tpnav a.arrowDown.firstSub "));
            //IWebElement element1 = driver.FindElement(By.CssSelector(".row .col-sm-4 .submenuDrp a"));


            IWebElement element1 = driver.FindElement(By.CssSelector("a[href='/technologies/microsoft-technologies']"));


            var actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
            

            actions.MoveToElement(element1).Click().Perform();



        }

        [Test]
        public void  keyboardAction()
        {
            // Locate an input 
            IWebElement inputField = driver.FindElement(By.Id("search"));

            // Create an Actions object
            Actions actions = new Actions(driver);

            // Simulate typing with SHIFT key pressed (uppercase letters)
            actions.Click(inputField)
                   .KeyDown(Keys.Shift)
                   .SendKeys("selenium")
                   .KeyUp(Keys.Shift)
                   .Perform();

        }
    
    }
}
