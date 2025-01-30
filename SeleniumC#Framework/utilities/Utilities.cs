using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using static SeleniumC_Framework.utilities.ExcelDataReader;

namespace SeleniumC_Framework.utilities
{
    internal class Utilities
    {

        public void AddItemIntoCart(IWebDriver driver,IList<IWebElement> cardsElement, String[] itemName)
        {
            //IList<IWebElement> cardsElement = driver.FindElements(By.TagName("app-card"));
            //String[] itemName = { "iphone X", "Blackberry" };
            TestContext.Progress.WriteLine(" InSide Utilities Product Card Count " + cardsElement.Count);
            foreach (IWebElement cardElement in cardsElement)
            {

                String name = cardElement.FindElement(By.CssSelector(".card-title a")).Text;

                if (itemName.Contains(name))
                {
                    TestContext.Progress.WriteLine($"Product NAME {name}");
                    cardElement.FindElement(By.CssSelector(".card-footer button")).Click();

                }


            }

            //wait.Until(ExpectedConditions.ElementIsVisible(())).Click();

            waitForVisibility(driver, By.PartialLinkText("Checkout")).Click();

            //CheckOutPage();




        }


        public IWebElement waitForVisibility(IWebDriver driver,By locator){

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));


            //wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector("label > a")))).Click();
            ////button.btn.btn - info

            //wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector("button.btn.btn-info")))).Click();

            //wait.Until(ExpectedConditions.ElementIsVisible((By.LinkText("India")))).Click();

        }

        public IWebElement waitForElementToBeClickable(IWebDriver driver, By locator)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));


           

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

    }
}
