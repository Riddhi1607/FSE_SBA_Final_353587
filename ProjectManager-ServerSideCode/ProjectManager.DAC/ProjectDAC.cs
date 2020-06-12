using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManager.DAC
{
    public class ProjectDAC
    {
        private IProject_ManagerContext _projectManagerCtx;

        public ProjectDAC()
        {
            _projectManagerCtx = new Project_ManagerContext();
        }
        public ProjectDAC(IProject_ManagerContext context)
        {
            _projectManagerCtx = context;
        }

        public List<MODEL.Project> RetrieveProjects()
        {
            using (_projectManagerCtx)
            {
                return _projectManagerCtx.Projects.Select(x => new MODEL.Project()
                {
                    ProjectId = x.Project_ID,
                    ProjectName = x.Project_Name,
                    ProjectEndDate = x.End_Date,
                    ProjectStartDate = x.Start_Date,
                    Priority = x.Priority,
                    User = _projectManagerCtx.Users.Where(y => y.Project_ID == x.Project_ID).Select(z => new MODEL.User()
                    {
                        UserId = z.User_ID
                    }).FirstOrDefault(),
                    NoOfTasks = _projectManagerCtx.Tasks.Where(y => y.Project_ID == x.Project_ID).Count(),
                    NoOfCompletedTasks = _projectManagerCtx.Tasks.Where(y => y.Project_ID == x.Project_ID && y.Status == 1).Count(),
                }).ToList();
            }
        }

        public int InsertProjectDetails(MODEL.Project project)
        {
            using (_projectManagerCtx)
            {
                DAC.Project proj = new DAC.Project()
                {
                    Project_Name = project.ProjectName,
                    Start_Date = project.ProjectStartDate,
                    End_Date = project.ProjectEndDate,
                    Priority = project.Priority
                };
                _projectManagerCtx.Projects.Add(proj);
                _projectManagerCtx.SaveChanges();
                var editDetails = (from editUser in _projectManagerCtx.Users
                                   where editUser.User_ID.ToString().Contains(project.User.UserId.ToString())
                                   select editUser).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.Project_ID = proj.Project_ID;
                }
                return _projectManagerCtx.SaveChanges();
            }
        }

        public int UpdateProjectDetails(MODEL.Project project)
        {
            using (_projectManagerCtx)
            {
                var editProjDetails = (from editProject in _projectManagerCtx.Projects
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


                var editDetails = (from editUser in _projectManagerCtx.Users
                                   where editUser.User_ID.ToString().Contains(project.User.UserId.ToString())
                                   select editUser).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.Project_ID = project.ProjectId;
                }
                return _projectManagerCtx.SaveChanges();
            }

        }
        public int DeleteProjectDetails(MODEL.Project project)
        {
            using (_projectManagerCtx)
            {

                var editDetails = (from proj in _projectManagerCtx.Projects
                                   where proj.Project_ID == project.ProjectId
                                   select proj).First();
                // Delete existing record
                if (editDetails != null)
                {
                    _projectManagerCtx.Projects.Remove(editDetails);
                }
                return _projectManagerCtx.SaveChanges();
            }

        }



    }
}
