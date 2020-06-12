using ProjectManager.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL = ProjectManager.Models;

namespace ProjectManagerBC
{
    public class UserBC
    {
        public UserDAC userDAC = null;

        public UserBC()
        {
            userDAC = new UserDAC();

        }

        public UserBC(IProject_ManagerContext context)
        {
            userDAC = new UserDAC(context);

        }

        public List<MODEL.User> GetUser()
        {
            return userDAC.GetUser();
        }

        public int AddUserDetails(MODEL.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User id is null");
            }
            try
            {
                int employeeId = Convert.ToInt32(user.EmployeeId);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format of employee Id", ex);
            }
            if (Convert.ToInt32(user.EmployeeId) < 0)
            {
                throw new ArithmeticException("Employee id cannot be negative");
            }
            if (Convert.ToInt32(user.ProjectId) < 0)
            {
                throw new ArithmeticException("Project id cannot be negative");
            }
            return userDAC.InsertUserDetails(user);
        }

        public int UpdateUserDetails(MODEL.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User id is null");
            }
            try
            {
                int employeeId = Convert.ToInt32(user.EmployeeId);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format of employee Id", ex);
            }
            if (Convert.ToInt32(user.EmployeeId) < 0)
            {
                throw new ArithmeticException("Employee id cannot be negative");
            }
            if (Convert.ToInt32(user.ProjectId) < 0)
            {
                throw new ArithmeticException("Project id cannot be negative");
            }
            if (user.UserId <= 0)
            {
                throw new ArithmeticException("User id cannot be negative or 0");
            }
            return userDAC.UpdateUserDetails(user);
        }

        public int DeleteUserDetails(MODEL.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User id is null");
            }
            try
            {
                int employeeId = Convert.ToInt32(user.EmployeeId);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format of employee Id", ex);
            }
            if (Convert.ToInt32(user.EmployeeId) < 0)
            {
                throw new ArithmeticException("Employee id cannot be negative");
            }
            if (Convert.ToInt32(user.ProjectId) < 0)
            {
                throw new ArithmeticException("Project id cannot be negative");
            }
            if (user.UserId <= 0)
            {
                throw new ArithmeticException("User id cannot be negative or 0");
            }
            return userDAC.DeleteUserDetails(user);
        }
    }
}
