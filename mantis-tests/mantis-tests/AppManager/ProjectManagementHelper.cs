using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper CreateNewProject(ProjectData project)
        {
            manager.Sidebar.GoToManagementTab();
            manager.ManagementMenu.ManageProjects();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            System.Threading.Thread.Sleep(3000);
            return this;
        }

        public ProjectManagementHelper DeleteProject(int index)
        {
            manager.Sidebar.GoToManagementTab();
            manager.ManagementMenu.ManageProjects();
            SelectExistingProject(index);
            InitDeleteProject();
            return this;
        }

        public ProjectManagementHelper SelectExistingProject(int index)
        {
            driver.FindElement(By.XPath(@"//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[" + (index + 1) + "]")).Click();
            return this;
        }
        public ProjectManagementHelper InitDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }

        public ProjectManagementHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath(@"//form[@action='manage_proj_create_page.php']")).Click();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath(@"//input[@type='submit']")).Click();
            return this;
        }

        public List<ProjectData> GetProjectsList()
        {
            manager.Sidebar.GoToManagementTab();
            manager.ManagementMenu.ManageProjects();

            List<ProjectData> projectsList = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath(@"//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                projectsList.Add(new ProjectData(element.FindElement(By.XPath(@"td[1]/a")).Text));
            }

            return projectsList;
        }
    }
}
