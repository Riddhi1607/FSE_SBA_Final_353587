using ProjectManager.DAC;
using ProjectManager.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManager.DAC.Task;

namespace ProjectManager.Test
{
    public class Test_Project_ManagerContext : IProject_ManagerContext
    {
        public Test_Project_ManagerContext()
        {
            this.ParentTasks = new TestDbSet<ParentTask>();
            this.Projects = new TestDbSet<Project>();
            this.Tasks = new TestDbSet<Task>();
            this.Users = new TestDbSet<User>();
        }
        public DbSet<ParentTask> ParentTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {

        }
    }
}
