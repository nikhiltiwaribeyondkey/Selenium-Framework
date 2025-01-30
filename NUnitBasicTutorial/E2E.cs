using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.DevTools.V129.FedCm;
using SeleniumExtras.WaitHelpers;
using AngleSharp.Text;
using System.Reflection.Emit;

namespace NUnitBasicTutorial
{
    internal class E2E
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

            //// Implicit Wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //// Explicit Wait
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

            CartIfNoItemInCard();




        }


        [Test]
        public void LoginSce()
        {
            IWebElement dropDownElement = driver.FindElement(By.XPath("//div[@class=\"form-group\"]//select[@class=\"form-control\"]"));
            Assert.IsNotNull(dropDownElement, "Not Empty");



            IList<IWebElement> userNameAndPasswordList = driver.FindElements(By.XPath("//p[contains(text(),'username is')]/b/i"));
            driver.FindElement(By.Id("username")).SendKeys(userNameAndPasswordList[0].Text);
            driver.FindElement(By.Id("password")).SendKeys(userNameAndPasswordList[1].Text);



            //clickking  on  term and Condition
            driver.FindElement(By.Id("terms")).Click();

            IList<IWebElement> radioButtonList = driver.FindElements(By.Id("usertype"));
            if (radioButtonList.Count > 0)
            {
                foreach (IWebElement radioButton in radioButtonList)
                {
                    TestContext.Progress.WriteLine($"Value  {radioButton.GetDomAttribute("value")} ");



                    if (radioButton.GetDomAttribute("value").Equals("user"))
                    {
                        radioButton.Click();
                    }

                }
            }


            SelectElement selectElement = new SelectElement(dropDownElement);
            selectElement.SelectByValue("consult");
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"okayBtn\"]")));
            element.Click();
            driver.FindElement(By.Id("signInBtn")).Click();

            


        }



        [Test]
        public void LoginCase()
        {
            IWebElement dropDownElement = driver.FindElement(By.XPath("//div[@class=\"form-group\"]//select[@class=\"form-control\"]"));
            Assert.IsNotNull(dropDownElement, "Not Empty");
            IList<IWebElement> userNameAndPasswordList = driver.FindElements(By.XPath("//p[contains(text(),'username is')]/b/i"));



            //clickking  on  term and Condition
            driver.FindElement(By.Id("terms")).Click();

            IWebElement checkBoxStatus = driver.FindElement(By.Id("terms"));
            checkBoxStatus.GetAttribute("checked");



            IList<IWebElement> radioButtonList = driver.FindElements(By.Id("usertype"));
            if (radioButtonList.Count > 0)
            {
                foreach (IWebElement radioButton in radioButtonList)
                {
                    TestContext.Progress.WriteLine($"Value  {radioButton.GetDomAttribute("value")} is CHeked {checkBoxStatus.GetAttribute("checked")} ");
                    if (radioButton.GetAttribute("value").Equals("user"))
                    {
                        radioButton.Click();
                    }


                    //if (radioButton.GetDomAttribute("value").Equals("user"))
                    //{
                    //    if(checkBoxStatus.GetAttribute("checked")){
                    //    radioButton.Click();
                    //}

                }
            }


            SelectElement selectElement = new SelectElement(dropDownElement);
            //selectElement.SelectByText("Teacher");
            selectElement.SelectByValue("consult");
            //selectElement.SelectByIndex(1);



            driver.FindElement(By.Id("okayBtn")).Click();
            //Thread.Sleep(2000);

            //IWebElement element = wait.Until(ExpectedConditions.);
            //element.Click();

            //driver.FindElement(By.XPath("//button[@id=\"okayBtn\"]")).Click();

            // Wait for an element to be visible


            //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"okayBtn\"]")));
            //element.Click();

            //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"signInBtn\"]")));
            //element.Click();

            driver.FindElement(By.Id("signInBtn")).Click();




        }

        [Test]
        public void WaitMethod()
        {

            //// Exclipit Wait 
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //implicitlyWait
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            IWebElement checkBoxStatus = driver.FindElement(By.Id("terms"));
            //clickking  on  term and Condition
            driver.FindElement(By.Id("terms")).Click();


            IList<IWebElement> radioButtonList = driver.FindElements(By.Id("usertype"));
            if (radioButtonList.Count > 0)
            {
                foreach (IWebElement radioButton in radioButtonList)
                {
                    TestContext.Progress.WriteLine($"Value  {radioButton.GetDomAttribute("value")} is CHeked {checkBoxStatus.GetAttribute("checked")} ");
                    if (radioButton.GetAttribute("value").Equals("user"))
                    {
                        radioButton.Click();
                    }



                }
            }

            TestContext.Progress.WriteLine($"CHeked 2 {checkBoxStatus.GetAttribute("checked")} ");
            //driver.FindElement(By.XPath("//button[@id=\"okayBtn\"]")).Click();
            //driver.FindElement(By.Id("okayBtn"));



           

            //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id=\"okayBtn\"]")));
            //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"okayBtn\"]")));


            IWebElement element2 = driver.FindElement(By.XPath("//button[@id='okayBtn']"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element2, "Okay"));
            element2.Click();

            driver.FindElement(By.Id("signInBtn")).Click();



            //driver.FindElement(By.ClassName("alert").Click();

            TestContext.Progress.WriteLine($"CHeked  3{checkBoxStatus.GetAttribute("checked")} Button text - {driver.FindElement(By.XPath("//button[@id=\"okayBtn\"]")).Text} ");

            //driver.FindElement(By.ClassName("alert"))

            TestContext.Progress.WriteLine($" Error Message { driver.FindElement(By.ClassName("alert")).Text}");



        }

       
        public void CartIfNoItemInCard()
        {
            //String cartElement = driver.FindElement(ByClassName("btn-primary")).Text;
            //Thread.Sleep(3000);

            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible((By.PartialLinkText("0"))));
            //element.Click();

            //String cartElement = driver.FindElement(By.XPath("//*[contains(@class, 'btn') and contains(@class, 'btn-primary')]")).Text;
            //String cartElement = driver.FindElement(By.PartialLinkText("0")).Text;
            String cartElement1 = wait.Until(ExpectedConditions.ElementIsVisible((By.PartialLinkText("0")))).Text;
            Boolean isNoItem = cartElement1.Contains("0");

            TestContext.Progress.WriteLine($"Caart Value  {cartElement1}  --- {isNoItem}");

            if (!isNoItem) { 
              
                     
            
            }
            else {
                AddItemIntoCart();


            }


        }
    
    
       public void AddItemIntoCart(){
            IList<IWebElement> cardsElement = driver.FindElements(By.TagName("app-card"));
            String[] itemName = { "iphone X", "Blackberry" };

            foreach (IWebElement cardElement in cardsElement) { 
             
                String name=cardElement.FindElement(By.CssSelector(".card-title a")).Text;
             
                if (itemName.Contains(name)) {
                    TestContext.Progress.WriteLine($"Product NAME {name}");
                    cardElement.FindElement(By.CssSelector(".card-footer button")).Click();

                }


            }

             wait.Until(ExpectedConditions.ElementIsVisible((By.PartialLinkText("Checkout")))).Click();

            CheckOutPage();




        }

        public void CheckOutPage()
        {
            IList<IWebElement> itemRow = driver.FindElements(By.CssSelector("table.table  tbody tr"));
            TestContext.Progress.WriteLine("Item Count is "+itemRow.Count);

            if (itemRow.Count > 2) {

                driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();
                //driver.FindElement(By.Id("checkbox2")).Click();

                

                driver.FindElement(By.Id("country")).SendKeys("Ind");
                
                ////Thread.Sleep(10000);
                ////wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Id("checkbox2")))).Click();

                //wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//input[@id=\"checkbox2\"]")))).Click();
                //label > a

                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector("label > a")))).Click();
                //button.btn.btn - info

                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector("button.btn.btn-info")))).Click();

                wait.Until(ExpectedConditions.ElementIsVisible((By.LinkText("India")))).Click();

                //input[@type='submit']

                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//input[@type='submit']")))).Click();


                //wait.Until(ExpectedConditions.ElementIsVisible((By.Id("checkbox2")))).Click();










            }


        }

        [TearDown]
        public void teardown()
        {

        }
    
    }
}
