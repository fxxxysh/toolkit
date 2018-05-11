using System;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public sealed class GPFunctions
	{
		private GPFunctions()
		{
		}

		public static bool Equals(Font font1, Font font2)
		{
			if (font1 != null && font2 == null)
			{
				return false;
			}
			if (font1 == null && font2 != null)
			{
				return false;
			}
			if (font1 == null && font2 == null)
			{
				return true;
			}
			return font1.Equals(font2);
		}

		public static bool Equals(ImageList imageList1, ImageList imageList2)
		{
			if (imageList1 != null && imageList2 == null)
			{
				return false;
			}
			if (imageList1 == null && imageList2 != null)
			{
				return false;
			}
			if (imageList1 == null && imageList2 == null)
			{
				return true;
			}
			return imageList1.Equals(imageList2);
		}

		public static object CreateInstance(Type type, string fullName)
		{
			Type[] array = null;
			object obj = null;
			string message = "Iocomp : Unable to create instance of object : " + fullName;
			if (type != (Type)null)
			{
				try
				{
					obj = Activator.CreateInstance(type);
				}
				catch (Exception ex)
				{
					message = "Iocomp : Error Creating object by Type ( " + fullName + ") : " + ex.Message;
				}
				if (obj != null)
				{
					return obj;
				}
				try
				{
					obj = Activator.CreateInstance(type.Assembly.FullName, type.FullName);
				}
				catch (Exception ex2)
				{
					message = "Iocomp : Error Creating object by Assembly-Type ( " + fullName + ") : " + ex2.Message;
				}
				if (obj != null)
				{
					return obj;
				}
			}
			if (fullName != string.Empty)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				int num = 0;
				while (true)
				{
					if (num >= assemblies.Length)
					{
						break;
					}
					Assembly assembly = assemblies[num];
					if (!(assembly is AssemblyBuilder))
					{
						try
						{
							array = assembly.GetTypes();
						}
						catch (Exception ex3)
						{
							message = "Iocomp : Error geting ASM Types : " + ex3.Message;
						}
						Type[] array2 = array;
						int num2 = 0;
						while (true)
						{
							if (num2 >= array2.Length)
							{
								break;
							}
							Type type2 = array2[num2];
							if (type2.FullName == fullName)
							{
								try
								{
									obj = Activator.CreateInstance(assembly.FullName, fullName).Unwrap();
								}
								catch (Exception ex4)
								{
									message = "Iocomp : Error Creating object by Assembly_Reflection-Type ( " + fullName + ") : " + ex4.Message;
								}
								if (obj == null)
								{
									goto IL_0124;
								}
								return obj;
							}
							goto IL_0124;
							IL_0124:
							num2++;
						}
					}
					num++;
				}
			}
			if (obj == null)
			{
				new Exception(message);
			}
			return obj;
		}
	}
}
