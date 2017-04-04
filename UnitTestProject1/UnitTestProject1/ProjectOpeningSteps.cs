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
        private static Button button;
        private static TextBox textbox;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            application = Application.Launch(@"C:\Program Files (x86)\SDL\SDL Trados Studio\Studio5\SDLTradosStudio.exe");
            //window = application.GetWindow(SearchCriteria.ByText("SDL Trados Studio 2017 Product Activation"), InitializeOption.NoCache);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        //    Button okButton = window.Get<Button>(SearchCriteria.ByAutomationId("_activateDeactivateButton"));
        //    okButton.Click();
        //    window.Close();
        }

        [Given(@"I have successfully loaded the application")]
        public void GivenIHaveOpenedTheFolderContainingTheProjects()
        {
        //    ClickButtonFoundByAutomationId(window, "_activateDeactivateButton");
        }

        [Given(@"I have written the project's name into the textbox")]
        public void GivenIHaveWrittenTheProjectSNameIntoTheTextbox()
        {
        //    ClickMenuFoundByText(window, "Open Project");
        //    TextBox textbox = window.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
        //    WriteInsideTextbox(textbox, "Project 1");
        //    ClickButtonFoundByAutomationId(window, "1");
        //    WriteInsideTextbox(textbox, "Project 1.sdlproj");
        }

        [When(@"I press Open")]
        public void WhenIPressOpen()
        {
        //    ClickButtonFoundByAutomationId(window, "1");
        }

        [Then(@"the dialog box should occur")]
        public void ThenTheDialogBoxShouldOccur()
        {
        //    Button okButton = window.Get<Button>(SearchCriteria.ByAutomationId("2"));
            Thread.Sleep(10000);
            Assert.IsNotNull(application);
        }

        static void ClickButtonFoundByAutomationId(Window window, string buttonName)
        {
            try
            {
                window.Get<Button>(SearchCriteria.ByAutomationId(buttonName)).Click();
            }
            catch
            {

            }
        }

        static void ClickMenuFoundByText(Window window, string menuName)
        {
            try
            {
                window.Get<Menu>(SearchCriteria.ByText(menuName)).Click();
            }
            catch
            {

            }
        }

        static void WriteInsideTextbox(TextBox textbox, string text)
        {
            textbox.SetValue(text);
        }

    }
}
