using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class SidebarNavigationHelper : HelperBase
    {
        public SidebarNavigationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public SidebarNavigationHelper GoToViewTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[1]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToTaskListTab ()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[2]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToTaskCreationTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[3]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToJournalTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[4]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToRoadmapTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[5]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToSummaryTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]")).Click();
            return this;
        }

        public SidebarNavigationHelper GoToManagementTab()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]")).Click();
            return this;
        }
    }
}
