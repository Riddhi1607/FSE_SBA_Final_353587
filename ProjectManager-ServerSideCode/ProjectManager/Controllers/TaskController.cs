using ProjectManager.ActionFilters;
using ProjectManagerBC;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using MODEL = ProjectManager.Models;

namespace ProjectManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        TaskBC taskObj = null;

        public TaskController()
        {
            taskObj = new TaskBC();
        }

        public TaskController(TaskBC taskBc)
        {
            taskObj = taskBc;
        }

        [HttpGet]
        [Route("api/task")]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        public JSendResponse RetrieveTaskByProjectId(int projectId)
        {
            List<Task> Tasks = taskObj.RetrieveTaskByProjectId(projectId);

            return new JSendResponse()
            {
                Data = Tasks
            };

        }

        [HttpGet]
        [Route("api/task/parent")]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        public JSendResponse RetrieveParentTasks()
        {
            List<ParentTask> ParentTasks = taskObj.RetrieveParentTasks();

            return new JSendResponse()
            {
                Data = ParentTasks
            };

        }

        [HttpPost]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/task/add")]
        public JSendResponse AddTaskDetails(Task task)
        {           
            return new JSendResponse()
            {
                Data = taskObj.AddTaskDetails(task)
            };

        }

        [HttpPost]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/task/update")]
        public JSendResponse UpdateTaskDetails(Task task)
        {           
            return new JSendResponse()
            {
                Data = taskObj.UpdateTaskDetails(task)
            };

        }
        [HttpPost]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/task/delete")]
        public JSendResponse DeleteTaskDetails(Task task)
        {           
            return new JSendResponse()
            {
                Data = taskObj.DeleteTaskDetails(task)
            };
        }


    }
}