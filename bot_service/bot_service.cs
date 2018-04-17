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
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace bot_service
{
	public class bot_service : ServiceBase
	{
		static System.Timers.Timer tt;
		static int x;
		static System.IO.StreamWriter sw=new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory +MyServiceName+ "_Log.txt",true );
		public const string MyServiceName = "bot_service";
		//public const string MyServiceName = AppDomain.CurrentDomain.FriendlyName ;
        public const string Description = "create by mojtaba ghaemi for telegram bot مجتبی قائمی sharpboy@gmail.com";
        public const string DisplayName = "Telegram Bot Servise";

		
		public bot_service()
		{
			InitializeComponent();
		}
		
		private void InitializeComponent()
		{
			this.ServiceName = bot_service.MyServiceName ;
			tt=  new System.Timers.Timer(500);
			tt.Elapsed+=new System.Timers.ElapsedEventHandler(ttevent);
			sw.AutoFlush=true;
			sw.WriteLine("new Initialize "+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));

		}
		
		protected override void Dispose(bool disposing)
		{
			tt.Dispose();
			sw.Close();
			sw.Dispose();
			base.Dispose(disposing);
		}
		
		protected override void OnStart(string[] args)
		{
			
			sw.WriteLine("new start "+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
			while (DateTime.Now.Millisecond  !=0) 
			{
			//Console.WriteLine("timer{0} ",DateTime.Now.Millisecond );
			}
			
			tt.Enabled=true ;
		}
		
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			sw.WriteLine("new stop "+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
		}
		
		static void ttevent(object sender, System.Timers.ElapsedEventArgs e)
		{
			x++;
			sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:f"));
			Console.WriteLine("timer{0} , {1}",x,DateTime.Now.ToString("HH:mm:ss:f"));
		}

	}
}
