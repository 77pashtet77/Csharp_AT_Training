using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected RegistrationHelper registration;
        protected FtpHelper ftp;
        protected JamesHelper james;
        protected MailHelper mail;
        protected LoginHelper auth;
        protected ProjectManagementHelper projects;
        protected SidebarNavigationHelper sidebar;
        protected ManagementMenuHelper managementMenu;


        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/";

            registration = new RegistrationHelper(this);
            ftp = new FtpHelper(this);
            james = new JamesHelper(this);
            mail = new MailHelper(this);
            auth = new LoginHelper(this);
            projects = new ProjectManagementHelper(this);
            sidebar = new SidebarNavigationHelper(this);
            managementMenu = new ManagementMenuHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager NewInstance = new ApplicationManager();
                app.Value = NewInstance;
                NewInstance.driver.Url = "http://localhost/mantisbt-2.25.5/login_page.php";
                NewInstance.driver.Manage().Window.Maximize();
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration
        { get { return registration; } }
        public FtpHelper Ftp
        { get { return ftp; } }
        public JamesHelper James
        { get { return james; } }
        public MailHelper Mail
        { get { return mail; } }
        public LoginHelper Auth
        { get { return auth; } }
        public ProjectManagementHelper Projects
        { get { return projects; } }
        public SidebarNavigationHelper Sidebar
        { get { return sidebar; } }
        public ManagementMenuHelper ManagementMenu
        { get { return managementMenu; } }
    }
}
