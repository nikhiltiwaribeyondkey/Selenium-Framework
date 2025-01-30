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
using OpenQA.Selenium.Firefox;
using System.Configuration;
using AngleSharp.Dom;
using Newtonsoft.Json.Linq;
using static SeleniumC_Framework.utilities.ExcelDataReader;
using AventStack.ExtentReports;
using System.ComponentModel.DataAnnotations;
using AventStack.ExtentReports.Reporter;


//[assembly:LevelOfParallelism(1)]
namespace SeleniumC_Framework.utilities
{
   
    internal class BaseClass
    {
        //protected IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        protected IWebDriver driverManager;
        protected  WebDriverWait wait;
        public ExtentReports extent;
        public ExtentTest test;



        [OneTimeSetUp]
        public void oneTimeSetup()
        {

            String projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string reportPath = projectPath + "/index.html";
            var htmlReport = new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AddSystemInfo("Environment", "QA");
              
        }

        [SetUp]
        public void Setup()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            //driver = new ChromeDriver();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string browerName = ConfigurationManager.AppSettings["browser"];
            string url= ConfigurationManager.AppSettings["url"];

            TestContext.Progress.WriteLine($"From App COnf FIle {browerName} and  {url}");

            //initBrowser("Chrome");
            //driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";


            initBrowser(browerName);
            driver.Value.Url = url;

            driver.Value.Manage().Window.Maximize();
            //// Implicit Wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //// Explicit Wait
            wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(10));


           TestContext.Progress.WriteLine("JSON DATA Array" +GetJsonReader().getArrayData("expected_product").ToString());


            //TestContext.Progress.WriteLine("Data From Excel File " +ExcelDataReader.ExcelTableDataReader();

        }


        public void initBrowser(string browserName)
        {
            switch (browserName)
            {

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                    driver.Value = new ChromeDriver();
                    
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

                    driver.Value = new FirefoxDriver();
                    break;


            }
        }
        [TearDown]
        public void TearDown()
        {

            DateTime time = DateTime.Now;
            string filename="ScreenSHot_"+time.ToString("h_mm_ss")+"png";

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace=TestContext.CurrentContext.Result.StackTrace;

            if(status== NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("test Fail", captureScreenShot(driver.Value,filename));
                 test.Log(Status.Fail,"test Failed with Log trace"+ stackTrace);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("test Pass", captureScreenShot(driver.Value, filename));
                test.Log(Status.Pass, "test Pass with Log trace" + stackTrace);
            }
            extent.Flush();

            //Thread.Sleep(10000);
            driver.Value.Quit();
            //driver.Close();

        }


        public AventStack.ExtentReports.Model.Media captureScreenShot(IWebDriver driver,string fileName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,fileName).Build() ;


        }


        public IWebElement waitForVisibility(By locator){
           
            return wait.Until(ExpectedConditions.ElementIsVisible(locator)); ;

        }


        static public IEnumerable<TestCaseData> getTestData()
        {
            //yield return new TestCaseData("Uday","passwaord");
            //yield return new TestCaseData("rahulshettyacademy", "learning");

            
            //TestContext.Progress.WriteLine($"JSON Array Data {GetJsonReader().getArrayData("expected_product")}");

            yield return new TestCaseData(GetJsonReader().getData("username"),GetJsonReader().getData("password"), GetJsonReader().getArrayData("expected_product"));
            yield return new TestCaseData(GetJsonReader().getData("wrong_username"), GetJsonReader().getData("wrong_password"), GetJsonReader().getArrayData("expected_product"));
             
             


        }

        static public IEnumerable<TestCaseData> getExcelTestData()
        {
            DataCollection collection = new DataCollection();
            //collection.collectInCollection("C:\\Users\\nikhil.tiwari\\source\\repos\\C#BasicTutorial\\SeleniumC#Framework\\data\\ExcelTestData.xlsx");
            collection.collectInCollection("data/ExcelTestData.xlsx");
            String userNameExel = collection.ReadData(1, "UserName");
            yield return new TestCaseData(collection.ReadData(1, "UserName"), collection.ReadData(1, "Password"));
            yield return new TestCaseData(collection.ReadData(2, "UserName"), collection.ReadData(2, "Password"));




        }



        public static JsonReader GetJsonReader()
        {
            return new JsonReader();
        }


    }
}
