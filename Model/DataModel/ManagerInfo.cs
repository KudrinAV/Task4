using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class ManagerInfo
    {
        [Key]
        public int ManagerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
