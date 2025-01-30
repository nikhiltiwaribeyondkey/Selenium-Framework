
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumC_Framework.pages
{
    internal class ProductHomePage
    {

        IWebDriver driver;

        public ProductHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            TestContext.Progress.WriteLine("Driver Detail " + this.driver.Title);
            

        }

        
        // Locators
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> appCard;


        public IList<IWebElement> getAppCards() {
            IList<IWebElement> ele = driver.FindElements(By.TagName("app-card"));
            TestContext.Progress.WriteLine("BY ID x " + ele.Count);
            return appCard;
        }
    }
}
