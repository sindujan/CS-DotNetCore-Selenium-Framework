using CS.Core.TestAuto.Framework.Base;
using CS.CrossPlatform.Test.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CS.CrossPlatform.Test.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    { 
        
        //Context injection
        private new readonly ParallelConfig _parallelConfig;

        public LoginSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<LoginPage>().Login(data.UserName, data.Password);
        }

        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            if (_parallelConfig.CurrentPage.As<HomePage>().GetLoggedInUser().Contains("admin"))
                System.Console.WriteLine("Sucess login");
            else
                System.Console.WriteLine("Unsucessful login");
        }


        [Then(@"I click logout")]
        public void ThenIClickLogout()
        {
            _parallelConfig.CurrentPage.As<HomePage>().ClickLogOff();
        }



    }
}
