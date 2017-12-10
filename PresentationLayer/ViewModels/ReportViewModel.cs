using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ReportViewModel
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public ManagerViewModel Manager { get; private set; }

        public ReportViewModel(string name, DateTime date, ManagerViewModel manager)
        {
            Name = name;
            Date = date;
            Manager = manager;
        }
    }
}
