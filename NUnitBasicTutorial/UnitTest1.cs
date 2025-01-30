using System.Collections.ObjectModel;
using System.Diagnostics;
using OpenQA.Selenium;

namespace NUnitBasicTutorial
{
    public class Tests:IWebDriver
    {
        //public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public string Title => throw new NotImplementedException();

        //public string PageSource => throw new NotImplementedException();

        //public string CurrentWindowHandle => throw new NotImplementedException();

        //public ReadOnlyCollection<string> WindowHandles => throw new NotImplementedException();

        [SetUp]
        //[OneTimeSetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("THis is Setup Function");
            //new WebDriverManager.DriverManager()
            
        }

        //[SetUp]
        ////[OneTimeSetUp]
        //public void Setup1()
        //{
        //    TestContext.Progress.WriteLine("THis is  one time Setup Function");

        //}

        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{
        //    TestContext.Progress.WriteLine("THis is OneTimeSetUp Function");

        //}


        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("THis is Test 1 Function");
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("THis is Test 2 Function");
            Assert.Pass();
        }
        //[TearDown]
        [OneTimeTearDown]
        public void TearDown() {

            TestContext.Progress.WriteLine("THis is TearDown");
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public IOptions Manage()
        {
            throw new NotImplementedException();
        }

        public INavigation Navigate()
        {
            throw new NotImplementedException();
        }

        public ITargetLocator SwitchTo()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}