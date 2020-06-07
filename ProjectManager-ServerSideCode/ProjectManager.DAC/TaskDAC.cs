using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManager.DAC
{
    public class TaskDAC : BaseDAC
    {
        public TaskDAC() : base()
        {

        }
        public TaskDAC(Project_ManagerEntities context) : base(context)
        {

        }

        public List<MODEL.Task> RetrieveTaskByProjectId(int projectId)
        {
            using (projectManagerCtx)
            {
                return projectManagerCtx.Tasks.Where(z => z.Project_ID == projectId).Select(x => new MODEL.Task()
                {
                    TaskId = x.Task_ID,
                    Task_Name = x.Task_Name,
                    ParentTaskName = projectManagerCtx.ParentTasks.Where(y => y.Parent_Task_ID == x.Parent_Task_ID).FirstOrDefault().Parent_Task_Name,
                    Start_Date = x.Start_Date,
                    End_Date = x.End_Date,
                    Priority = x.Priority,
                    Status = x.Status,
                    User = projectManagerCtx.Users.Where(y => y.Task_ID == x.Task_ID).Select(z => new MODEL.User()
                    {
                        UserId = z.User_ID,
                        FirstName = z.First_Name
                    }).FirstOrDefault(),
                }).ToList();
            }

        }

        public List<MODEL.ParentTask> RetrieveParentTasks()
        {
            using (projectManagerCtx)
            {
                return projectManagerCtx.ParentTasks.Select(x => new MODEL.ParentTask()
                {
                    ParentTaskId = x.Parent_Task_ID,
                    ParentTaskName = x.Parent_Task_Name
                }).ToList();
            }
        }


        public int InsertTaskDetails(MODEL.Task task)
        {
            using (projectManagerCtx)
            {

                if (task.Priority == 0)
                {
                    projectManagerCtx.ParentTasks.Add(new DAC.ParentTask()
                    {
                        Parent_Task_Name = task.Task_Name

                    });
                }
                else
                {
                    Task taskDetail = new Task()
                    {
                        Task_Name = task.Task_Name,
                        Project_ID = task.Project_ID,
                        Start_Date = task.Start_Date,
                        End_Date = task.End_Date,
                        Parent_Task_ID = task.Parent_ID,
                        Priority = task.Priority,
                        Status = task.Status
                    };
                    projectManagerCtx.Tasks.Add(taskDetail);
                    projectManagerCtx.SaveChanges();

                    var editDetails = (from editUser in projectManagerCtx.Users
                                       where editUser.User_ID.ToString().Contains(task.User.UserId.ToString())
                                       select editUser).ToList();
                    // Modify existing records
                    if (editDetails != null && editDetails.Count > 0)
                    {
                        editDetails.First().Task_ID = taskDetail.Task_ID;
                    }
                }
                return projectManagerCtx.SaveChanges();
            }
        }

        public int UpdateTaskDetails(MODEL.Task task)
        {
            using (projectManagerCtx)
            {
                var editDetails = (from editTask in projectManagerCtx.Tasks
                                   where editTask.Task_ID.ToString().Contains(task.TaskId.ToString())
                                   select editTask).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.Task_Name = task.Task_Name;
                    editDetails.Start_Date = task.Start_Date;
                    editDetails.End_Date = task.End_Date;
                    editDetails.Status = task.Status;
                    editDetails.Priority = task.Priority;

                }
                var editDetailsUser = (from editUser in projectManagerCtx.Users
                                       where editUser.User_ID.ToString().Contains(task.User.UserId.ToString())
                                       select editUser).First();
                // Modify existing records
                if (editDetailsUser != null)
                {
                    editDetails.Task_ID = task.TaskId;
                }
                return projectManagerCtx.SaveChanges();
            }

        }

        public int DeleteTaskDetails(MODEL.Task task)
        {
            using (projectManagerCtx)
            {
                var deleteTask = (from editTask in projectManagerCtx.Tasks
                                  where editTask.Task_ID.ToString().Contains(task.TaskId.ToString())
                                  select editTask).First();
                // Delete existing record
                if (deleteTask != null)
                {
                    deleteTask.Status = 1;
                }
                return projectManagerCtx.SaveChanges();
            }

        }
    }
}
