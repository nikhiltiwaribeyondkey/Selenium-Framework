using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumC_Framework.pages;
using SeleniumC_Framework.utilities;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;
using static SeleniumC_Framework.utilities.ExcelDataReader;

namespace SeleniumC_Framework.Tests
{
    [Parallelizable((ParallelScope.Self))]
    class E2EExcel : BaseClass
    {

        //ProductPage productPage;
        Utilities utilities;
        
        
        [Test]
        //[TestCase("rahulshettyacademy","learning")]
        //[TestCase("rahulshet", "learning")]
        [TestCaseSource(nameof(getExcelTestData))]
        public void Login(String username,String password)
        {
            String[] itemName = { "iphone X", "Blackberry" };
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


            By cartButton = By.PartialLinkText("0");
            utilities.waitForVisibility(driver.Value, cartButton);
            utilities.AddItemIntoCart(driver.Value, productHomePage.getAppCards(), itemName);


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



                

            }


            //DataCollection collection = new DataCollection();
            ////collection.collectInCollection("C:\\Users\\nikhil.tiwari\\source\\repos\\C#BasicTutorial\\SeleniumC#Framework\\data\\ExcelTestData.xlsx");
            //collection.collectInCollection("data/ExcelTestData.xlsx");
            //String userNameExel = collection.ReadData(1, "UserName");

            //UdateExcelClass reader = new UdateExcelClass();
            //reader.UpdateExcelFile("data/ExcelTestData.xlsx", "Test",2,"Password", "newValue");

 }


        [Test]
        public void  UpdateExcelData()
        {
            String projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string testData = projectPath + "/data/ExcelTestData.xlsx";

            DataCollection excelReader = new DataCollection();
            excelReader.UpdateExcelFile(testData, "Test", 1, "UserName", "rahulshettyacademy");
            //excelReader.UpdateExcelData;


        }
        [TearDown]
        public void   TearDown() {

            //driver.Quit();
            //driver.Close();

        }
        
    }
}