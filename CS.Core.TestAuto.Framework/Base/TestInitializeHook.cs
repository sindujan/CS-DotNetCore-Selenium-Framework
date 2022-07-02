using CS.Core.TestAuto.Framework.Config;
using CS.Core.TestAuto.Framework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;

namespace CS.Core.TestAuto.Framework.Base
{
    public class TestInitializeHook : Steps
    {

        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    driverOptions = new InternetExplorerOptions();
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalFirefoxOption(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalFirefoxOption(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalChromeOption(CapabilityType.EnableProfiling, true);
                    break;
            }

            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://172.17.212.150:30001/wd/hub"), driverOptions.ToCapabilities());
        }

        public virtual void NaviateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }


        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.InternetExplorer => new InternetExplorerOptions(),
                BrowserType.FireFox => new FirefoxOptions(),
                BrowserType.Chrome => new ChromeOptions(),
                _ => new ChromeOptions(),
            };
        }
    }
}
