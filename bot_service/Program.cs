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
using System.ServiceProcess;
using System.Text;
using System.Linq;
using System.Configuration.Install;
using System.Reflection ;
namespace bot_service
{

	
	static class Program
	{
		/// <summary>
		/// This method starts the service.
		/// </summary>
		static void Main()
		{
			if (Environment.UserInteractive)
			{
			ConsoleKeyInfo cki;
			Console.WriteLine("service "+ bot_service.MyServiceName+" DisplayName "+ bot_service.DisplayName );
			
			ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == bot_service.MyServiceName);
			if(sc==null)
				{
				    Console.WriteLine(bot_service.MyServiceName+" Is Not installed");
					Console.WriteLine("Do you want install:(y) \n");
					cki = Console.ReadKey();
					if (cki.Key.ToString()=="Y")
					{
				    Console.WriteLine(bot_service.MyServiceName+" Is Start install");
				     ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
					}
				}
				else 
				{
				    Console.WriteLine(bot_service.MyServiceName+" Is Start installed and Status:" +sc.Status);
					Console.WriteLine("For uninstall peree:(1)");
					if (sc.Status== ServiceControllerStatus.Running)
						Console.WriteLine("For Stop      peree:(2)");
						else 					
						Console.WriteLine("For Start     peree:(2)");
						
					cki = Console.ReadKey();
					if(cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1 )
					{
				     Console.WriteLine(bot_service.MyServiceName+" Is Start UNinstall");
				     ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
					}
					else 
					{
						if (sc.Status== ServiceControllerStatus.Running)
							sc.Stop();
						else 					
							sc.Start();

					}
						/*
    				 try
					  {
	    				sc.Start();
	    				sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(100));
					  }
					  catch
					  {
					  	Console.WriteLine( "err" );
					  }	*/
				}
  
                
				Console.ReadKey() ;
					
				
			}
			else 
			{
			// To run more than one service you have to add them here
			ServiceBase.Run(new ServiceBase[] { new bot_service() });
			}
		}
	}
}
