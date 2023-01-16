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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create (GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            if (driver.Url == "http://localhost/" + "addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return this;
            }

            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public bool IsGroupPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper CreateGroupIfNoneExists()
        {
            manager.Navigator.GoToGroupsPage();

            if (!IsGroupPresent())
            {
                GroupData group = new GroupData("Dawgs");
                group.Header = "All dawgs from our block";
                group.Footer = "Fear teh reaper";

                Create(group);
                return this;
            }
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupsList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text) {
                        //adding Id property for each found element
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupCache);
        }

        //Hashing
        //Remove code below for stable tests
        public int GetGroupsCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
        //Remove
    }
}
