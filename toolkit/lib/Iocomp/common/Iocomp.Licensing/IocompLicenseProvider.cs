using Iocomp.Classes;
using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Licensing
{
	public abstract class IocompLicenseProvider : LicenseProvider
	{
		private class IocompLicense : License
		{
			private IocompLicenseProvider m_Owner;

			private string m_LicenseKey;

			public override string LicenseKey => this.m_LicenseKey;

			public IocompLicense(IocompLicenseProvider owner, string licensekey)
			{
				this.m_Owner = owner;
				this.m_LicenseKey = licensekey;
			}

			public override void Dispose()
			{
				this.m_Owner = null;
				this.m_LicenseKey = null;
			}
		}

		private static DateTime m_LastEvalPopUpDateTime = DateTime.Now - new TimeSpan(1, 0, 0);

		private static Timer m_Timer;

		private static Form m_EvaluationForm;

		private static ArrayList m_DynamicLicenseKeys;

		private static readonly object licenseManagerLock = new object();

		public static void AddLicenseKey(Type type, string value)
		{
			if (IocompLicenseProvider.m_DynamicLicenseKeys == null)
			{
				IocompLicenseProvider.m_DynamicLicenseKeys = new ArrayList();
			}
			DynamicLicenseKey dynamicLicenseKey = new DynamicLicenseKey();
			dynamicLicenseKey.Type = type;
			dynamicLicenseKey.KeyString = value;
			IocompLicenseProvider.m_DynamicLicenseKeys.Add(dynamicLicenseKey);
		}

		~IocompLicenseProvider()
		{
			if (IocompLicenseProvider.m_Timer != null)
			{
				IocompLicenseProvider.m_Timer.Enabled = false;
				IocompLicenseProvider.m_Timer = null;
			}
			if (IocompLicenseProvider.m_EvaluationForm != null)
			{
				IocompLicenseProvider.m_EvaluationForm.Hide();
				IocompLicenseProvider.m_EvaluationForm.Dispose();
			}
		}

		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			IocompLicense iocompLicense = null;
			string text = null;
			RegistryKey registryKey = null;
			Type type2 = type;
			registryKey = Registry.LocalMachine.OpenSubKey("Software\\Iocomp\\.Net Licenses V3");
			if (registryKey == null)
			{
				registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Iocomp\\.Net Licenses V3");
			}
			do
			{
				if (!(type2 != typeof(Component)) && !(type2.Name == "OPCData"))
				{
					break;
				}
				if (IocompLicenseProvider.m_DynamicLicenseKeys != null)
				{
					int num = 0;
					while (num < IocompLicenseProvider.m_DynamicLicenseKeys.Count)
					{
						if (!((IocompLicenseProvider.m_DynamicLicenseKeys[num] as DynamicLicenseKey).Type == type))
						{
							num++;
							continue;
						}
						text = (IocompLicenseProvider.m_DynamicLicenseKeys[num] as DynamicLicenseKey).KeyString;
						break;
					}
				}
				if (text == null && registryKey != null)
				{
					text = (string)registryKey.GetValue(type2.FullName);
				}
				try
				{
					if (text == null)
					{
						text = this.GetSavedLicenseKeySpecial(type2, null);
					}
				}
				catch (Exception)
				{
					text = null;
					iocompLicense = null;
				}
				if (text != null && this.LicenseKeyValid(type, text))
				{
					iocompLicense = new IocompLicense(this, text);
					break;
				}
				type2 = type2.BaseType;
			}
			while (!(type2 == (Type)null) && !(type2 != typeof(object)));
			if (iocompLicense == null)
			{
				if (DateTime.Now > IocompLicenseProvider.m_LastEvalPopUpDateTime + new TimeSpan(0, 10, 0))
				{
					if (IocompLicenseProvider.m_Timer == null)
					{
						IocompLicenseProvider.m_Timer = new Timer();
						IocompLicenseProvider.m_Timer.Interval = 200;
						IocompLicenseProvider.m_Timer.Tick += this.m_Timer_Tick;
						IocompLicenseProvider.m_Timer.Enabled = false;
					}
					IocompLicenseProvider.m_LastEvalPopUpDateTime = DateTime.Now;
				}
				iocompLicense = new IocompLicense(this, "Evaluation");
			}
			if (context != null && iocompLicense != null)
			{
				context.SetSavedLicenseKey(type, iocompLicense.LicenseKey);
			}
			return iocompLicense;
		}

		private void m_Timer_Tick(object sender, EventArgs e)
		{
			IocompLicenseProvider.m_Timer.Stop();
			IocompLicenseProvider.m_Timer.Interval = 600000;
			IocompLicenseProvider.m_Timer.Stop();
			if (IocompLicenseProvider.m_EvaluationForm == null)
			{
				IocompLicenseProvider.m_EvaluationForm = new EvaluationForm();
			}
		}

		protected virtual bool LicenseKeyValid(Type type, string licensekey)
		{
			return false;
		}

		public string GetSavedLicenseKeySpecial(Type type, Assembly resourceAssembly)
		{
			LicenseContext licenseContext = new CustomLicenseContext();
			return licenseContext.GetSavedLicenseKey(type, resourceAssembly);
		}
	}
}
