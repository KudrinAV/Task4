﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReportDTO
    {
        string Name { get; set; }
        public DateTime Date {get;set;}

        public ManagerDTO Manager;
    }
}
