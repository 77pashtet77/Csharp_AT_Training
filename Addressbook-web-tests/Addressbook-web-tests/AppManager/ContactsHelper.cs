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

        public ContactsHelper SelectContact(int index)
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

            if (!IsContactPresent())
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
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath(".//td[2]")).Text, element.FindElement(By.XPath(".//td[3]")).Text)
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToContactsPage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromForm(int index)
        {
            manager.Navigator.GoToContactsPage();
            InitContactEdit(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string birthday = driver.FindElement(By.XPath("//select[@name='bday']/option[1]")).GetAttribute("value") + "." 
                + driver.FindElement(By.XPath("//select[@name='bmonth']/option[1]")).GetAttribute("value") + "."
                + driver.FindElement(By.Name("byear")).GetAttribute("value");
            string anniversary = driver.FindElement(By.XPath("//select[@name='aday']/option[1]")).GetAttribute("value") + "."
                + driver.FindElement(By.XPath("//select[@name='amonth']/option[1]")).GetAttribute("value") + "."
                + driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string secondAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(lastName, firstName)
            {
                MiddleName = middleName, 
                Nickname = nickname, 
                Address = address,
                Company = company, 
                Title = title, 
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = faxPhone, 
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Birthday = birthday, 
                Anniversary = anniversary, 
                SecondAddress = secondAddress, 
                SecondHomePhone = secondHomePhone, 
                Notes = notes
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToContactsPage();

            return Int32.Parse(driver.FindElement(By.Id("search_count")).Text);
        }
    }
}
