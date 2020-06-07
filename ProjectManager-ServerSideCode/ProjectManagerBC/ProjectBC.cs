using ProjectManager.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManagerBC
{
    public class ProjectBC
    {
        public ProjectDAC projectDAC = null;
        public ProjectBC()
        {
            projectDAC = new ProjectDAC();
        }

        public List<MODEL.Project> RetrieveProjects()
        {
            return projectDAC.RetrieveProjects();
        }

        public int AddProjectDetails(MODEL.Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("Project is null");
            }
            if (project.ProjectId < 0)
            {
                throw new ArithmeticException("Project ID cannot be negative");
            }
            if (project.User == null)
            {
                throw new ArgumentNullException("User related to the project cannot be null");
            }
            if (project.User.ProjectId < 0)
            {
                throw new ArithmeticException("User object project Id cannot be negative");
            }
            if (project.NoOfCompletedTasks > project.NoOfTasks)
            {
                throw new ArgumentException("Completed tasks cannot be greater than total tasks");
            }
            return projectDAC.InsertProjectDetails(project);
        }


        public int UpdateProjectDetails(MODEL.Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("Project is null");
            }
            if (project.ProjectId < 0)
            {
                throw new ArithmeticException("Project ID cannot be negative");
            }
            if (project.User == null)
            {
                throw new ArgumentNullException("User related to the project cannot be null");
            }
            if (project.User.ProjectId < 0)
            {
                throw new ArithmeticException("User object project Id cannot be negative");
            }
            if (project.NoOfCompletedTasks > project.NoOfTasks)
            {
                throw new ArgumentException("Completed tasks cannot be greater than total tasks");
            }

            return projectDAC.UpdateProjectDetails(project);


        }

        public int DeleteProjectDetails(MODEL.Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("Project is null");
            }
            if (project.ProjectId < 0)
            {
                throw new ArithmeticException("Project ID cannot be negative");
            }
            if (project.User == null)
            {
                throw new ArgumentNullException("User related to the project cannot be null");
            }
            if (project.User.ProjectId < 0)
            {
                throw new ArithmeticException("User object project Id cannot be negative");
            }
            if (project.NoOfCompletedTasks > project.NoOfTasks)
            {
                throw new ArgumentException("Completed tasks cannot be greater than total tasks");
            }

            return projectDAC.DeleteProjectDetails(project);
        }


    }
}
