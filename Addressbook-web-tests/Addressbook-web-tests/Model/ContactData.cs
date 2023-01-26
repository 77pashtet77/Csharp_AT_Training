using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;

        public ContactData() { }

        public ContactData(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (LastName == other.LastName) && (FirstName == other.FirstName);
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() ^ FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "Lastname=" + LastName + "\nFirstname=" + FirstName;
            //add for full contact data filling
            /*
                + "\nMiddleName=" + MiddleName + "\nNickname=" + Nickname 
                + "\nAddress=" + Address + "\nCompany=" + Company + "\nTitle=" + Title + "\nHomePhone=" + HomePhone 
                + "\nMobilePhone=" + MobilePhone + "\nWorkPhone=" + WorkPhone + "\nFaxPhone=" + FaxPhone + "\nEmail1=" + Email1 
                + "\nEmail2=" + Email2 + "\nEmail3=" + Email3 + "\nBirthday=" + Birthday + "\nAnniversary=" + Anniversary 
                + "\nSecondAddress=" + SecondAddress + "\nSecondHomePhone=" + SecondHomePhone + "\nNotes=" + Notes;
            */
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) != 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "id")]
        public string Id { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string FaxPhone { get; set; }


        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondHomePhone)).Trim();
                }
            } 
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, @"[-\s()]", "") + "\r\n";
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email1 + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "bday")]
        public string BirthdayDay { get; set; }

        [Column(Name = "bmonth")]
        public string BirthdayMonth { get; set; }

        [Column(Name = "byear")]
        public string BirthdayYear { get; set; }

        [Column(Name = "aday")]
        public string AnniversaryDay { get; set; }

        [Column(Name = "amonth")]
        public string AnniversaryMonth { get; set; }

        [Column(Name = "ayear")]
        public string AnniversaryYear { get; set; }

        [Column(Name = "address2")]
        public string SecondAddress { get; set; }

        [Column(Name = "phone2")]
        public string SecondHomePhone { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
