using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V129.CSS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumC_Framework.pages;
using SeleniumC_Framework.utilities;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

using Allure.NUnit.Attributes;
using static SeleniumC_Framework.utilities.ExcelDataReader;
using Allure.NUnit;


namespace SeleniumC_Framework.Tests
{
    //[Parallelizable((ParallelScope.Children))]
    //[TestFixture]
    //[Parallelizable((ParallelScope.Self))]

    [AllureNUnit]
    class Tests : BaseClass
    {

        //ProductPage productPage;
        Utilities utilities;
        
        
        [Test]
        //[TestCase("rahulshettyacademy","learning")]
        //[TestCase("rahulshet", "learning")]
        [TestCaseSource(nameof(getTestData))]
        [Parallelizable((ParallelScope.All))]
        [Category("TestLogin")]
        [AllureDescription("For Login of User With password ")]
        public void Login(String username,String password, String[] itemName)
        {
            //DataCollection collection = new DataCollection();
            ////collection.collectInCollection("C:\\Users\\nikhil.tiwari\\source\\repos\\C#BasicTutorial\\SeleniumC#Framework\\data\\ExcelTestData.xlsx");
            //collection.collectInCollection("data/ExcelTestData.xlsx");
            //String  userNameExel = collection.ReadData(1, "UserName");
            //TestContext.Progress.WriteLine("User Name" + userNameExel);



            
            string url = ConfigurationManager.AppSettings["url"];
            driver.Value.Url = url;
            LoginPage loginPagePOM = new LoginPage(driver.Value);

            ProductHomePage productHomePage = new ProductHomePage(driver.Value);

            CheckOutPage checkOutPage = new CheckOutPage(driver.Value);
            CheckOutAddressPage checkOutAddressPage = new CheckOutAddressPage(driver.Value);

            //productPage = new ProductPage(driver);

            utilities = new Utilities();

            //loginPagePOM.setUserName("rahulshettyacademy");
            //loginPagePOM.setPassword("learning");
            loginPagePOM.setUserName(username);
            loginPagePOM.setPassword(password);


            
            loginPagePOM.ClickTermAndCondition();
            loginPagePOM.ClickSignInButton();

            logStep("Login Successful with user " + username);

            By cartButton = By.PartialLinkText("0");
            utilities.waitForVisibility(driver.Value, cartButton);
            utilities.AddItemIntoCart(driver.Value, productHomePage.getAppCards(), itemName);

            logStep("product Added Successfully " + itemName);

            if (checkOutPage.getItemRowSelected().Count() > 2)
            {
                checkOutPage.clickOnCheckoutButton();


                By labelForterm = By.CssSelector("label > a");
                By btnInfo = By.CssSelector("button.btn.btn-info");
                By autoSuggestionClick = By.LinkText("India");
                By submitBtn = By.XPath("//input[@type='submit']");

                utilities.waitForElementToBeClickable(driver.Value, labelForterm).Click();
                utilities.waitForElementToBeClickable(driver.Value, btnInfo).Click();
                checkOutAddressPage.setCountryName("ind");

                utilities.waitForVisibility(driver.Value, autoSuggestionClick).Click();
                utilities.waitForElementToBeClickable(driver.Value, submitBtn).Click();


                logStep("Product Purchase Successfully ");



            }


        }
 

        [Test]
        [Category("Mouse CLick")]
        public void MouseClick()
        {


            Actions actions = new Actions(driver.Value);
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            IWebElement element = driver.Value.FindElement(By.CssSelector("div[class='tpnavMenu'] a:nth-child(1)"));
            actions.MoveToElement(element).Click().Perform();


        }
        [TearDown]
        public void   TearDown() {

            //driver.Quit();
            //driver.Close();

        }
        
    }

   
}