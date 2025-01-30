using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumC_Framework.pages
{
    internal class CheckOutPage
    {

        IWebDriver driver;

        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(_driver, this);
            PageFactory.InitElements(this.driver, this);

        }


        // Locators
        [FindsBy(How = How.CssSelector, Using = "table.table  tbody tr")]
        private IList<IWebElement> itemRowSelected;

        // Locators
        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-success")]
        private IWebElement checkOutbtn;


        public IList<IWebElement> getItemRowSelected(){
            return itemRowSelected;
        }

        public void clickOnCheckoutButton()
        {
            checkOutbtn.Click();
        }





    }
}
