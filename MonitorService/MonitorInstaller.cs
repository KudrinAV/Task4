using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace BLL
{
    [RunInstaller(true)]
    public partial class MonitorInstaller : Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public MonitorInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "MonitorService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);

        }
    }
}
