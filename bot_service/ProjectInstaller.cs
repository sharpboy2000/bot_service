/*
 * Created by SharpDevelop.
 * User: m.ghaemi
 * Date: 26/10/1394
 * Time: 04:27 ب.ظ
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace bot_service
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();
            
            serviceInstaller = new ServiceInstaller();
            // Here you can set properties on serviceProcessInstaller or register event handlers
            serviceProcessInstaller.Account = ServiceAccount.LocalService;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = bot_service.MyServiceName;
            serviceInstaller.Description = "create by mojtaba ghaemi for telegram bot مجتبی قائمی sharpboy@gmail.com";
            serviceInstaller.DisplayName = "Telegram Bot Servise";
            serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            this.Installers.AddRange(new Installer[] {serviceProcessInstaller, serviceInstaller});
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName, Environment.MachineName))
                {
                    if (sc.Status != ServiceControllerStatus.Running)
                        sc.Start();
                }
            }
            catch (Exception ee)
            {
            	using(System.IO.StreamWriter sw=new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "tat.txt") )
            	{
					sw.WriteLine("catch AfterInstall "+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
					sw.WriteLine("err "+ee.ToString());
					sw.Close();
            	}
                //EventLog.WriteEntry("Application", ee.ToString(), EventLogEntryType.Error);
            }
        }

    }
}