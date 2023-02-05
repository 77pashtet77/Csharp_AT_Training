using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ManagementMenuHelper ManageOverview ()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[1]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageUsers()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[2]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageProjects()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[3]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageTags()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[4]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageCustomFields()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[5]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageGlobalProfiles()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[6]")).Click();
            return this;
        }

        public ManagementMenuHelper ManagePlugins()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[7]")).Click();
            return this;
        }

        public ManagementMenuHelper ManageConfig()
        {
            driver.FindElement(By.XPath("//div[@class='page-content']/div[@class='row']/ul/li[8]")).Click();
            return this;
        }
    }
}
