﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManager.DAC
{
    public class UserDAC : BaseDAC
    {
        public UserDAC() : base()
        {

        }

        public List<MODEL.User> GetUser()
        {
            using (projectManagerCtx)
            {
                return projectManagerCtx.Users.Select(x => new MODEL.User()
                {
                    FirstName = x.First_Name,
                    LastName = x.Last_Name,
                    EmployeeId = x.Employee_ID,
                    UserId = x.User_ID
                }).ToList();
            }

        }

        public int InsertUserDetails(MODEL.User user)
        {
            using (projectManagerCtx)
            {
                projectManagerCtx.Users.Add(new DAC.User()
                {
                    Last_Name = user.LastName,
                    First_Name = user.FirstName,
                    Employee_ID = user.EmployeeId
                });
                return projectManagerCtx.SaveChanges();
            }
        }

        public int UpdateUserDetails(MODEL.User user)
        {
            using (projectManagerCtx)
            {
                var editDetails = (from editUser in projectManagerCtx.Users
                                   where editUser.User_ID == user.UserId
                                   select editUser).First();
                // Modify existing records
                if (editDetails != null)
                {
                    editDetails.First_Name = user.FirstName;
                    editDetails.Last_Name = user.LastName;
                    editDetails.Employee_ID = user.EmployeeId;

                }
                return projectManagerCtx.SaveChanges();
            }

        }

        public int DeleteUserDetails(MODEL.User user)
        {
            using (projectManagerCtx)
            {
                var editDetails = (from editUser in projectManagerCtx.Users
                                   where editUser.User_ID == user.UserId
                                   select editUser).First();
                // Delete existing record
                if (editDetails != null)
                {
                    projectManagerCtx.Users.Remove(editDetails);
                }
                return projectManagerCtx.SaveChanges();
            }

        }


    }
}
