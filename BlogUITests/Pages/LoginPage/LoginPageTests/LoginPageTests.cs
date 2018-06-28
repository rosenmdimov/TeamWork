using BlogBuild.Tests.Pages.AccountPage;

namespace BlogBuild.Tests.Pages.LoginPage.LoginPageTests
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    using TestStack.Seleno.BrowserStack.Core.Extensions;

    [TestFixture]
    class LoginPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            // this.driver = new InternetExplorerDriver();

            // this.driver = new ChromeDriver();
            this.driver = new FirefoxDriver();
            
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Close();
        }

        [Test]
        [Property("UITest Login loaded", 1)]
        [Author("Rossen Dimov")]
        public void LoginPageLoaded()
        {
            var loginPage = new LoginPage(this.driver);

            loginPage.NavigateTo();

            loginPage.AssertLoginPageLoaded("Log in");
        }

        [Test]
        [Property ("User Is Logged In",1)]
        [Author("Rossen Dimov")]
        public void TryToLoggingIn()
        {
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);
            
            loginPage.Login();
            accountPage.NavigateTo();
            accountPage.AssertIsLogged("Hello abv@abv.bg!");
        }
    }
}
