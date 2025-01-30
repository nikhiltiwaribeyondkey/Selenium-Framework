using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumC_Framework.pages
{
    internal class CheckOutAddressPage
    {

        IWebDriver driver;

        public CheckOutAddressPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(_driver, this);
            PageFactory.InitElements(this.driver, this);

        }


        // Locators
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement countryText;


        public void setCountryName(String name)
        {
            countryText.SendKeys(name);  
        }

        public void selectCountryName()
        {

        }
    }
}
