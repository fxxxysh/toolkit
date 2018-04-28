using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public sealed class UpdateRateTimer
	{
		private static Timer m_Timer;

		private static ArrayList m_ControlList;

		static UpdateRateTimer()
		{
			UpdateRateTimer.m_ControlList = new ArrayList();
		}

		public static void AddControl(IUpdateRate update)
		{
			UpdateRateTimer.m_ControlList.Add(update);
			if (UpdateRateTimer.m_Timer == null)
			{
				UpdateRateTimer.m_Timer = new Timer();
				UpdateRateTimer.m_Timer.Interval = 100;
				UpdateRateTimer.m_Timer.Enabled = true;
				UpdateRateTimer.m_Timer.Tick += UpdateRateTimer.m_Timer_Tick;
			}
		}

		public static void RemoveControl(IUpdateRate update)
		{
			UpdateRateTimer.m_ControlList.Remove(update);
			if (UpdateRateTimer.m_ControlList.Count == 0)
			{
				UpdateRateTimer.m_Timer.Enabled = false;
				UpdateRateTimer.m_Timer.Dispose();
				UpdateRateTimer.m_Timer = null;
			}
		}

		public static bool NeedsUpdate(IUpdateRate update)
		{
			if (update.FrameRate == 0.0)
			{
				return false;
			}
			if (update.Active)
			{
				return false;
			}
			if (!update.Needed)
			{
				return false;
			}
			DateTime now = DateTime.Now;
			if (Math2.DateTimeToDouble(now) > Math2.DateTimeToDouble(update.LastRepaintTime) + 1.0 / update.FrameRate * 1.0 / 86400.0)
			{
				return true;
			}
			return false;
		}

		private static void m_Timer_Tick(object sender, EventArgs e)
		{
			foreach (IUpdateRate control in UpdateRateTimer.m_ControlList)
			{
				if (UpdateRateTimer.NeedsUpdate(control))
				{
					control.InvalidateControl();
				}
			}
		}
	}
}
