using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Security.Principal;
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
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager manager) : base(manager) { }

        public ContactsHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            manager.Navigator.InitContactCreation();
            FillContactForm(contact);
            SubmitNewContact();
            return this;
        }

        public ContactsHelper Remove(int v, bool alertAccept)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(v);
            RemoveContact();
            AlertAccept(alertAccept);
            return this;
        }

        public ContactsHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            InitContactEdit(v);
            FillContactForm(contact);
            UpdateContact();
            return this;
        }

        public ContactsHelper InitContactEdit(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactsHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper RemoveContactThroughEdit(int v) 
        {
            manager.Navigator.GoToContactsPage();
            InitContactEdit(v);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactsHelper SelectContact (int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + (index + 2) + "]/td[1]/input")).Click();
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactsHelper CreateContactIfNoneExists()
        {
            manager.Navigator.GoToContactsPage();

            if (! IsContactPresent()) 
            {
                ContactData contact = new ContactData("Good", "Doggie");
                Create(contact);
                return this;
            }
            return this;
        }

        public ContactsHelper AlertAccept(bool alertAccept)
        {
            if (alertAccept == true)
            {
                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                driver.SwitchTo().Alert().Dismiss();

            }
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.GoToContactsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                int index = 1;
                foreach (IWebElement element in elements)
                {
                    index++;
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("//table//tr[" + index + "]//td[2]")).Text, element.FindElement(By.XPath("//table//tr[" + index + "]//td[3]")).Text)
                    {
                        //adding Id property for each found element
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }

            return new List<ContactData>(contactCache);
        }

        //Hashing
        //Remove code below for stable tests
        public int GetContactsCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.Name("entry")).Count;
        }
        //Remove
    }
}
