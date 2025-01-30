
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;



namespace SeleniumC_Framework.pages
{
     internal class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
            //PageFactory.InitElements(_driver, this);
            PageFactory.InitElements(this.driver,this);

        }


        // Locators
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;

        //clickking  on  term and Condition
        [FindsBy(How = How.Id, Using = "terms")]
        private IWebElement TermAndCondition;


        //clickking  on  term and Condition
        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement SignInBtn;
        //driver.FindElement(By.Id("signInBtn")).Click();



        public IWebElement getUserName() {
            return Username;
        }

        public void  setUserName(String userName){
            Username.SendKeys(userName);
        }

        public IWebElement getPassword()
        {
            return Password;
        }

        public void setPassword(String password)
        {
            Password.SendKeys(password);
        }

        public  void  ClickTermAndCondition() {
            TermAndCondition.Click();  
        }

        public void ClickSignInButton()
        {
            SignInBtn.Click();
        }




    }
}
