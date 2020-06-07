using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAC
{
    public class BaseDAC
    {
        public Project_ManagerEntities projectManagerCtx = null;
        public BaseDAC()
        {
            projectManagerCtx = new Project_ManagerEntities();
        }

        public BaseDAC(Project_ManagerEntities projectManagerTestContext)
        {
            projectManagerCtx = new Project_ManagerEntities();
        }

    }
}
