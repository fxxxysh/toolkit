using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Iocomp.Classes
{
	public sealed class InstanceIO
	{
		static InstanceIO()
		{
		}

		public static void SavePropertiesToFile(object instance, string fileName)
		{
			FileStream fileStream = File.Create(fileName);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			InstanceIO.SavePropertiesToStream(instance, streamWriter);
			streamWriter.Close();
			fileStream.Close();
		}

		public static void LoadPropertiesFromFile(object instance, string fileName)
		{
			FileStream fileStream = File.OpenRead(fileName);
			StreamReader streamReader = new StreamReader(fileStream);
			InstanceIO.LoadPropertiesFromStream(instance, streamReader);
			streamReader.Close();
			fileStream.Close();
		}

		public static void SavePropertiesToStream(object instance, StreamWriter streamWriter)
		{
			InstanceIO.SaveInstance(instance, "", streamWriter);
		}

		public static void LoadPropertiesFromStream(object instance, StreamReader streamReader)
		{
			InstanceIO.LoadInstance(instance, streamReader);
		}

		private static void ThrowStreamError()
		{
			throw new Exception("Invalid properties stream format");
		}

		private static string GetNewPath(string curentPath, string seperator, string pathExtension)
		{
			if (curentPath == string.Empty)
			{
				return pathExtension;
			}
			return curentPath + seperator + pathExtension;
		}

		private static void SaveInstance(object instance, string path, StreamWriter streamWriter)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
			foreach (PropertyDescriptor item in properties)
			{
				if (item.IsBrowsable && item.ShouldSerializeValue(instance) && item.SerializationVisibility != 0)
				{
					if (item.SerializationVisibility == DesignerSerializationVisibility.Content)
					{
						object value = item.GetValue(instance);
						string newPath = InstanceIO.GetNewPath(path, ".", item.Name);
						if (value is System.Collections.CollectionBase)
						{
							InstanceIO.SaveInstance(value, newPath, streamWriter);
						}
						else
						{
							InstanceIO.SaveInstance(value, newPath, streamWriter);
						}
					}
					if (!item.IsReadOnly && (!item.PropertyType.IsClass || !(item.PropertyType != typeof(string))))
					{
						InstanceIO.WriteProperty(instance, item, path, streamWriter);
					}
				}
			}
			if (instance is IList)
			{
				IList list = instance as IList;
				streamWriter.WriteLine(path + " = LoadingBegin");
				for (int i = 0; i < list.Count; i++)
				{
					object obj = list[i];
					string fullName = obj.GetType().FullName;
					streamWriter.WriteLine(path + " = new " + fullName);
					InstanceIO.SaveInstance(obj, InstanceIO.GetNewPath(path, "", "(" + i.ToString() + ")"), streamWriter);
				}
				streamWriter.WriteLine(path + " = LoadingEnd");
			}
		}

		private static void LoadInstance(object instance, StreamReader streamReader)
		{
			while (true)
			{
				string text = streamReader.ReadLine();
				if (text == null)
				{
					break;
				}
				string[] array = text.Split('=');
				if (array.Length == 2)
				{
					string nameString = array[0].Trim();
					string valueString = array[1].Trim();
					InstanceIO.LoadValue(instance, nameString, valueString);
				}
			}
		}

		private static void WriteProperty(object instance, PropertyDescriptor descriptor, string path, StreamWriter streamWriter)
		{
			string str = (!(path == string.Empty)) ? (path + "." + descriptor.Name) : descriptor.Name;
			object value = descriptor.GetValue(instance);
			if (value != null)
			{
				TypeConverter converter = descriptor.Converter;
				string text = converter.ConvertToString(value);
				text = text.Replace("\r", "#13");
				text = text.Replace("\n", "#10");
				streamWriter.WriteLine(str + " = " + text);
			}
		}

		private static void LoadValue(object instance, string nameString, string valueString)
		{
			int num = nameString.IndexOf('(');
			if (num != -1 && num < nameString.IndexOf('.'))
			{
				string text = nameString.Substring(0, num).Trim();
				int num2 = nameString.IndexOf(')');
				if (num2 == -1)
				{
					InstanceIO.ThrowStreamError();
				}
				string text2 = nameString.Substring(num + 1, num2 - num - 1).Trim();
				if (text2 == string.Empty)
				{
					InstanceIO.ThrowStreamError();
				}
				if (nameString.Substring(num2 + 1, 1) != ".")
				{
					InstanceIO.ThrowStreamError();
				}
				string nameString2 = nameString.Substring(num2 + 2).Trim();
				object obj;
				if (text != string.Empty)
				{
					PropertyInfo property = instance.GetType().GetProperty(text);
					obj = property.GetValue(instance, null);
				}
				else
				{
					obj = instance;
				}
				if (!(obj is IList))
				{
					InstanceIO.ThrowStreamError();
				}
				IList list = obj as IList;
				obj = list[int.Parse(text2)];
				InstanceIO.LoadValue(obj, nameString2, valueString);
			}
			else
			{
				int num3 = nameString.IndexOf('.');
				if (num3 != -1)
				{
					string text3 = nameString.Substring(0, num3).Trim();
					string nameString2 = nameString.Substring(num3 + 1).Trim();
					if (text3 != null && nameString2 != null && !(text3 == string.Empty) && !(nameString2 == string.Empty))
					{
						PropertyInfo property = instance.GetType().GetProperty(text3);
						InstanceIO.LoadValue(property.GetValue(instance, null), nameString2, valueString);
					}
				}
				else if (nameString != string.Empty)
				{
					PropertyInfo property = instance.GetType().GetProperty(nameString);
					if (!(property == (PropertyInfo)null))
					{
						object obj = property.GetValue(instance, null);
						if (obj is IList)
						{
							InstanceIO.LoadValue(property.GetValue(instance, null), "", valueString);
						}
						else if (property.CanWrite)
						{
							obj.GetType();
							TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
							valueString = valueString.Replace("#13", "\r");
							valueString = valueString.Replace("#10", "\n");
							property.SetValue(instance, converter.ConvertFromString(valueString), null);
						}
					}
				}
				else if (instance is IList)
				{
					IList list = instance as IList;
					if (valueString.ToUpper() == "LoadingBegin".ToUpper())
					{
						list.Clear();
					}
					else if (!(valueString.ToUpper() == "LoadingEnd".ToUpper()) && valueString.StartsWith("new"))
					{
						string text4 = valueString.Substring(4).Trim();
						Type.GetType(text4);
						Assembly assembly = instance.GetType().Assembly;
						object obj2 = assembly.CreateInstance(text4);
						if (obj2 == null)
						{
							throw new Exception("Failed to create a new (" + text4 + ").");
						}
						list.Add(obj2);
					}
				}
			}
		}
	}
}
