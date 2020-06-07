using ProjectManager.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManagerBC
{
    public class TaskBC
    {
        public TaskDAC taskDAC = null;
        public TaskBC()
        {
            taskDAC = new TaskDAC();
        }

        public List<MODEL.Task> RetrieveTaskByProjectId(int projectId)
        {
            if (projectId < 0)
            {
                throw new ArithmeticException("ProjectId cannot be negative");
            }
           

            return taskDAC.RetrieveTaskByProjectId(projectId);

        }

        public List<MODEL.ParentTask> RetrieveParentTasks()
        {
            return taskDAC.RetrieveParentTasks();
        }


        public int AddTaskDetails(MODEL.Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task object is null");
            }
            if (task.Parent_ID < 0)
            {
                throw new ArithmeticException("Parent Id of task cannot be negative");
            }
            if (task.Project_ID < 0)
            {
                throw new ArithmeticException("Project Id cannot be negative");
            }
            if (task.TaskId < 0)
            {
                throw new ArithmeticException("Task id cannot be negative");
            }

            return taskDAC.InsertTaskDetails(task);
        }

        public int UpdateTaskDetails(MODEL.Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task object is null");
            }
            if (task.Parent_ID < 0)
            {
                throw new ArithmeticException("Parent Id of task cannot be negative");
            }
            if (task.Project_ID < 0)
            {
                throw new ArithmeticException("Project Id cannot be negative");
            }
            if (task.TaskId < 0)
            {
                throw new ArithmeticException("Task id cannot be negative");
            }

            return taskDAC.UpdateTaskDetails(task);
        }

        public int DeleteTaskDetails(MODEL.Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task object is null");
            }
            if (task.Parent_ID < 0)
            {
                throw new ArithmeticException("Parent Id of task cannot be negative");
            }
            if (task.Project_ID < 0)
            {
                throw new ArithmeticException("Project Id cannot be negative");
            }
            if (task.TaskId < 0)
            {
                throw new ArithmeticException("Task id cannot be negative");
            }

            return taskDAC.DeleteTaskDetails(task);
        }
    }
}
