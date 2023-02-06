using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using mantis_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        private string baseUrl;

        public LoginHelper(ApplicationManager manager, String baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

        public LoginHelper Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return this;
                }

                Logout();
                return this;
            }
            driver.Url = baseUrl + "/login_page.php";
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath(@"//input[@type='submit']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath(@"//input[@type='submit']")).Click();
            return this;
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/span")).Click();
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/ul/li[4]")).Click();
                return this;
            }
            return this;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }
    }
}
