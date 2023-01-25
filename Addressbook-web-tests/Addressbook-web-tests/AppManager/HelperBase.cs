using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public HelperBase Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
                return this;
            }
            return this;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //converting text representation of a month into a number for easier parsing
        public string MonthConverter(string monthText)
        {
            Dictionary<string, string> months = new Dictionary<string, string>()
{
                { "January", "1"},
                { "February", "2"},
                { "March", "3"},
                { "April", "4"},
                { "May", "5"},
                { "June", "6"},
                { "July", "7"},
                { "August", "8"},
                { "September", "9"},
                { "October", "10"},
                { "November", "11"},
                { "December", "12"},
};
            foreach (var month in months)
            {
                if (monthText.Contains(month.Key))
                {
                    string thisMonth = month.Value;
                    monthText =  thisMonth;
                }
            }
            return monthText;
        }
    }
}