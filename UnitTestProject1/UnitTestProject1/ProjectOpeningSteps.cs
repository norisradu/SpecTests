using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.MenuItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace ConsoleApplication1
{
    [Binding]
    public class ProjectOpeningSteps
    {
        private static Application application;
        private static Window window;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            application = Application.Launch(@"C:\Program Files\SDL\SDL Trados Studio\Studio5\SDLTradosStudio.exe");
            Window window = application.GetWindow("Product Activation");
            var continueButton = window.Get(SearchCriteria.ByAutomationId("_okCancelButton"));
            try
            {
                continueButton.Click();
            }
            catch { }
            window.WaitWhileBusy();
            try
            {
                window = application.GetWindow("SDL Trados Studio Setup");
            }
            catch { }
            window.WaitWhileBusy();
            var nextButton = window.Get(SearchCriteria.ByAutomationId("_nextButton"));
            try
            {
                nextButton.Click();
            }
            catch { }
            try
            {
                var textboxEmail = window.Get(SearchCriteria.ByAutomationId("_textBoxEmail"));
                textboxEmail.SetValue("mail@yahoo.com");
            }
            catch { }
            try
            {
                nextButton.Click();
            }
            catch { }
            try
            {
                nextButton.Click();
            }
            catch { }
            window.Get(SearchCriteria.ByAutomationId("radioButtonNo")).Click();
            nextButton.Click();
            window.Get(SearchCriteria.ByAutomationId("_finishButton")).Click();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            window.Close();
        }

        [Given(@"I have successfully launched the application")]
        public void GivenIHaveLaunchedTheApplication()
        {
            window = application.GetWindow(SearchCriteria.ByAutomationId("StudioWindowForm"), InitializeOption.NoCache);
        }

        [Then(@"the main window should open")]
        public void ThenTheMainWindowShouldOpen()
        {
            Assert.IsNotNull(window);
        }
    }
}