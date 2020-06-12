using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAC
{
    public interface IProject_ManagerContext : IDisposable
    {
        DbSet<ParentTask> ParentTasks { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();

    }
}
