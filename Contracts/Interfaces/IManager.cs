using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IManager
    {
        int ManagerID { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
    }
}
