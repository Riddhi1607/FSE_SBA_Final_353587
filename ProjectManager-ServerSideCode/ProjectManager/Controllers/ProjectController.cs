using ProjectManager.ActionFilters;
using ProjectManager.Models;
using ProjectManagerBC;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        ProjectBC projObjBC = null;

        public ProjectController()
        {
            projObjBC = new ProjectBC();
        }

        public ProjectController(ProjectBC projectBc)
        {
            projObjBC = projectBc;
        }

        [HttpGet]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/project")]
        public JSendResponse RetrieveProjects()
        {
            List<Project> Projects = projObjBC.RetrieveProjects();

            return new JSendResponse()
            {
                Data = Projects
            };

        }

        [HttpPost]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/project/add")]
        public JSendResponse AddProjectDetails(Project project)
        {            
            return new JSendResponse()
            {
                Data = projObjBC.AddProjectDetails(project)
            };

        }


        [HttpPost]
        [Route("api/project/update")]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        public JSendResponse UpdateProjectDetails(Project project)
        {            
            return new JSendResponse()
            {
                Data = projObjBC.UpdateProjectDetails(project)
            };
        }

        [HttpPost]
        [Route("api/project/delete")]
        public JSendResponse DeleteProjectDetails(Project project)
        {            
            return new JSendResponse()
            {
                Data = projObjBC.DeleteProjectDetails(project)
            };
        }

    }
}