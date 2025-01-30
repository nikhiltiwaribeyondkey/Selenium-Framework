using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace NUnitBasicTutorial
{
    internal class Window
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



            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }


        [Test]
        public void Login()
        {
            IWebElement dropDownElement = driver.FindElement(By.XPath("//div[@class=\"form-group\"]//select[@class=\"form-control\"]"));
            Assert.IsNotNull(dropDownElement, "Not Empty");




            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            //driver.FindElement(By.Id("password")).SendKeys("learning");




            //// Locate the username and password using XPath
            //IWebElement usernameElement = driver.FindElement(By.XPath("//p[contains(text(),'username is')]/b/i[0]"));
            //IWebElement passwordElement = driver.FindElement(By.XPath("//p[contains(text(),'Password is')]/b/i[1]"));

            IList<IWebElement> userNameAndPasswordList = driver.FindElements(By.XPath("//p[contains(text(),'username is')]/b/i"));
            driver.FindElement(By.Id("username")).SendKeys(userNameAndPasswordList[0].Text);
            driver.FindElement(By.Id("password")).SendKeys(userNameAndPasswordList[1].Text);

            //// Retrieve the text values
            //string username = usernameElement.Text;
            //string password = passwordElement.Text;


            // driver.FindElement(By.Id("username")).SendKeys(username);
            //driver.FindElement(By.Id("password")).SendKeys(password);


            //clickking  on  term and Condition
            driver.FindElement(By.Id("terms")).Click();

            IList<IWebElement> radioButtonList = driver.FindElements(By.Id("usertype"));
            if (radioButtonList.Count > 0)
            {
                foreach (IWebElement radioButton in radioButtonList)
                {
                    TestContext.Progress.WriteLine($"Value  {radioButton.GetDomAttribute("value")} ");
                    //if (radioButton.GetAttribute("value").Equals("user"))
                    //{
                    //    radioButton.Click();
                    //}


                    if (radioButton.GetDomAttribute("value").Equals("user"))
                    {
                        radioButton.Click();
                    }

                }
            }


            SelectElement selectElement = new SelectElement(dropDownElement);
            //selectElement.SelectByText("Teacher");
            selectElement.SelectByValue("consult");
            //selectElement.SelectByIndex(1);


            //driver.FindElement(By.Id("okayBtn")).Click();
            //Thread.Sleep(2000);

            //IWebElement element = wait.Until(ExpectedConditions.);
            //element.Click();

            //driver.FindElement(By.XPath("//button[@id=\"okayBtn\"]")).Click();

            // Wait for an element to be visible


            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"okayBtn\"]")));
            element.Click();

            //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"signInBtn\"]")));
            //element.Click();

            driver.FindElement(By.Id("signInBtn")).Click();

           




        }


        [Test]
        public void window()
        {

            driver.FindElement(By.CssSelector(".blinkingText")).Click();

            // this will hold refrence of Current Window
            String parentWindow = driver.CurrentWindowHandle;

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //p[@class='im-para red']
           //String text= driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
       
           String text= driver.FindElement(By.XPath("//p[@class='im-para red']/strong/a")).Text;
           TestContext.Progress.WriteLine($"Current {text}");
            // for closing Child window
            //driver.Close();

            // for backing Control Back to parent Window
            //driver.SwitchTo().Window(driver.WindowHandles[0]);
            // OR
            //driver.SwitchTo().Window(parentWindow);

            

            IList<String> windowHandler = driver.WindowHandles;

            foreach (String windowHandlerElement in windowHandler)
            {
                if (driver.Url.Equals("https://rahulshettyacademy.com/documents-request"))
                {
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }

                break;
            }


            driver.FindElement(By.Id("username")).SendKeys(text);


        }
    }
}
