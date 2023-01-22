using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
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


        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Id { get; set; }

        public string MiddleName { get; set; }

        public string Nickname { get; set; }

        public string Address { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

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

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        public string SecondAddress { get; set; }

        public string SecondHomePhone { get; set; }

        public string Notes { get; set; }
    }
}
