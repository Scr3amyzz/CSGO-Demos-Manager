﻿using System;
using GalaSoft.MvvmLight.Threading;
using CSGO_Demos_Manager.Internals;

namespace CSGO_Demos_Manager
{
	public partial class App
	{
		public App()
		{
			DispatcherHelper.Initialize();
#if RELEASE
			AppDomain.CurrentDomain.UnhandledException += HandleAppDomainUnhandleException;
#endif
			CSGO_Demos_Manager.Properties.Settings.Default.SelectedPlayerSteamId = 0;
			CSGO_Demos_Manager.Properties.Settings.Default.DateStatsTo = DateTime.Today;
			CSGO_Demos_Manager.Properties.Settings.Default.Save();
		}

		private static void HandleAppDomainUnhandleException(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception)args.ExceptionObject;
			Logger.Instance.Log(e);
			System.Windows.MessageBox.Show("An unexpected error occured. Please send the 'errors.log' file accessible from settings." + Environment.NewLine
				+ "Message Error : " + Environment.NewLine + e.Message, "Error");
		}
	}
}
