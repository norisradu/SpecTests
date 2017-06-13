using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.MenuItems;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        private static Application application;
        private static Window window;

        static void Main(string[] args)
        {
            application = Application.Launch(@"C:\temp\SDLTradosGroupShare2017\EnterpriseEditionSetup.exe");
            window = application.GetWindow("SDL Trados GroupShare - Install");
            Button nextButton = window.Get<Button>(SearchCriteria.ByAutomationId("btnNext"));
            nextButton.Click();
            CheckBox checkbox = window.Get<CheckBox>(SearchCriteria.ByAutomationId("ProjectServerCheckbox"));
            checkbox.Click();
            nextButton.Click();
            checkbox = window.Get<CheckBox>(SearchCriteria.ByAutomationId("chkApplicationServer"));
            checkbox.Click();
            checkbox = window.Get<CheckBox>(SearchCriteria.ByAutomationId("chkWebServer"));
            checkbox.Click();
            nextButton.Click();
            window.Get<RadioButton>(SearchCriteria.ByAutomationId("SQLAutoRadio")).Click();
            nextButton.Click();
            nextButton.Click();
            nextButton.Click();
            nextButton.Click();
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtSmtpHost"), TimeSpan.FromMinutes(1)).SetValue("smtp.mail.yahoo.com");
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtSmtpUser"), TimeSpan.FromMinutes(1)).SetValue("mail@yahoo.com");
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtSmtpPort"), TimeSpan.FromMinutes(1)).SetValue("465");
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtSmtpPassword"), TimeSpan.FromMinutes(1)).SetValue("pass");
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(1)).Click();
            nextButton.Click();
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtNTUser"), TimeSpan.FromMinutes(1)).SetValue("Administrator");
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtPassword"), TimeSpan.FromMinutes(1)).SetValue("Passw0rd.");
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(1)).Click();
            GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtWebPort"), TimeSpan.FromMinutes(1)).SetValue("90");
            nextButton.Click();
            nextButton.Click();
            Button nxt = GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(5));
            nxt.Click();
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(1)).Click();
            TextBox txtBox = GetWithWait<TextBox>(window, SearchCriteria.ByAutomationId("txtServer"), TimeSpan.FromMinutes(1));
            txtBox.SetValue(@"WIN-6H0KV6V56CF\SQLEXPRESS");
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(2)).Click();
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnNext"), TimeSpan.FromMinutes(2)).Click();
            GetWithWait<Button>(window, SearchCriteria.ByAutomationId("btnFinish"), TimeSpan.FromMinutes(6)).Click();
        }

        private static T GetWithWait<T>(Window window, SearchCriteria searchCriteria, TimeSpan timeout) where T : UIItem
        {
            T result = null;
            var start = DateTime.Now;
            while (DateTime.Now - start < timeout)
            //for (int i = 0; i < 240; i++)
            {
                result = window.Get<T>(searchCriteria);
                if (result.Enabled)
                {
                    return result;
                }
                Thread.Sleep(1000);
            }
            return result;
        }
    }
}
