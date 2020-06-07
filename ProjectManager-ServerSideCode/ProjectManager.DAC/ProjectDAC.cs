using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManager.DAC
{
    public class ProjectDAC : BaseDAC
    {
        public ProjectDAC() : base()
        {

        }
        public ProjectDAC(Project_ManagerEntities context) : base(context)
        {

        }

        public List<MODEL.Project> RetrieveProjects()
        {
            using (projectManagerCtx)
            {
                return projectManagerCtx.Projects.Select(x => new MODEL.Project()
                {
                    ProjectId = x.Project_ID,
                    ProjectName = x.Project_Name,
                    ProjectEndDate = x.End_Date,
                    ProjectStartDate = x.Start_Date,
                    Priority = x.Priority,
                    User = projectManagerCtx.Users.Where(y => y.Project_ID == x.Project_ID).Select(z => new MODEL.User()
                    {
                        UserId = z.User_ID
                    }).FirstOrDefault(),
                    NoOfTasks = projectManagerCtx.Tasks.Where(y => y.Project_ID == x.Project_ID).Count(),
                    NoOfCompletedTasks = projectManagerCtx.Tasks.Where(y => y.Project_ID == x.Project_ID && y.Status == 1).Count(),
                }).ToList();
            }
        }

        public int InsertProjectDetails(MODEL.Project project)
        {
            using (projectManagerCtx)
            {
                DAC.Project proj = new DAC.Project()
                {
                    Project_Name = project.ProjectName,
                    Start_Date = project.ProjectStartDate,
                    End_Date = project.ProjectEndDate,
                    Priority = project.Priority
                };
                projectManagerCtx.Projects.Add(proj);
                projectManagerCtx.SaveChanges();
                var editDetails = (from editUser in projectManagerCtx.Users
                                   where editUser.User_ID.ToString().Contains(project.User.UserId.ToString())
                                   select editUser).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.Project_ID = proj.Project_ID;
                }
                return projectManagerCtx.SaveChanges();
            }
        }

        public int UpdateProjectDetails(MODEL.Project project)
        {
            using (projectManagerCtx)
            {
                var editProjDetails = (from editProject in projectManagerCtx.Projects
                                       where editProject.Project_ID.ToString().Contains(project.ProjectId.ToString())
                                       select editProject).First();
                // Modify existing records
                if (editProjDetails != null)
                {
                    editProjDetails.Project_Name = project.ProjectName;
                    editProjDetails.Start_Date = project.ProjectStartDate;
                    editProjDetails.End_Date = project.ProjectEndDate;
                    editProjDetails.Priority = project.Priority;
                }


                var editDetails = (from editUser in projectManagerCtx.Users
                                   where editUser.User_ID.ToString().Contains(project.User.UserId.ToString())
                                   select editUser).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.Project_ID = project.ProjectId;
                }
                return projectManagerCtx.SaveChanges();
            }

        }
        public int DeleteProjectDetails(MODEL.Project project)
        {
            using (projectManagerCtx)
            {

                var editDetails = (from proj in projectManagerCtx.Projects
                                   where proj.Project_ID == project.ProjectId
                                   select proj).First();
                // Delete existing record
                if (editDetails != null)
                {
                    projectManagerCtx.Projects.Remove(editDetails);
                }
                return projectManagerCtx.SaveChanges();
            }

        }



    }
}
