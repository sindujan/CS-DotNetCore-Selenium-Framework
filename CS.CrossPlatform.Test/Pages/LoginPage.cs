using CS.Core.TestAuto.Framework.Base;
using OpenQA.Selenium;
using CS.Core.TestAuto.Framework.Extensions;

namespace CS.CrossPlatform.Test.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage(ParallelConfig parallelConfig) : base(parallelConfig) { }


        IWebElement txtUserName => _parallelConfig.Driver.FindById("UserName");

        IWebElement txtPassword => _parallelConfig.Driver.FindById("Password");

        IWebElement btnLogin => _parallelConfig.Driver.FindByCss("input.btn");

        IWebElement btnLoginss => _parallelConfig.Driver.FindByCss("input.btnssss");


        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }


        public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return new HomePage(_parallelConfig);
        }


        internal void CheckIfLoginExist()
        {
            txtUserName.AssertElementPresent();
        }

        internal BasePage ClickLoginButtons()
        {
            btnLoginss.Submit();
            return new HomePage(_parallelConfig);
        }
    }
}
