using ProjectManager.ActionFilters;
using ProjectManager.Models;
using ProjectManagerBC;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class UserController : ApiController
    {
        UserBC _userObjBC = null;

        public UserController()
        {
            _userObjBC = new UserBC();
        }

        public UserController(UserBC userObjBC)
        {
            _userObjBC = userObjBC;
        }

        [HttpGet]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/test")]
        public JSendResponse TestUser()
        {
            return new JSendResponse()
            {
                Data = "Hello"
            };
        }

        [HttpGet]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/user")]
        public JSendResponse GetUser()
        {
            List<User> Users = _userObjBC.GetUser();

            return new JSendResponse()
            {
                Data = Users
            };
        }

        [HttpPost]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        [Route("api/user/add")]
        public JSendResponse AddUserDetails(User user)
        {
            
            return new JSendResponse()
            {
                Data = _userObjBC.AddUserDetails(user)
            };

        }

        [HttpPost]
        [Route("api/user/update")]
        [ProjectManagerLogFilter]
        [ProjectManagerExceptionFilter]
        public JSendResponse UpdateUserDetails(User user)
        {            
            return new JSendResponse()
            {
                Data = _userObjBC.UpdateUserDetails(user)
            };
        }

        [HttpPost]
        [Route("api/user/delete")]
        public JSendResponse DeleteUserDetails(User user)
        {            
            return new JSendResponse()
            {
                Data = _userObjBC.DeleteUserDetails(user)
            };
        }
    }
}