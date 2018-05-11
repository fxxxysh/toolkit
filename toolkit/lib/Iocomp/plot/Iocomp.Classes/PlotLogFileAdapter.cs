using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Plot Log File Adapter.")]
	public class PlotLogFileAdapter : SubClassBase, IPlotLogFileAdapter
	{
		private string m_FileName;

		private int m_BufferSize;

		private bool m_Active;

		private Plot m_Plot;

		private int m_BufferIndex;

		private int m_BufferCount;

		private bool m_Append;

		private bool m_AppendFileMustExist;

		private bool m_AllowFileOverwrite;

		[Description("")]
		public string FileName
		{
			get
			{
				return this.m_FileName;
			}
			set
			{
				base.PropertyUpdateDefault("FileName", value);
				if (this.FileName != value)
				{
					if (this.Active)
					{
						throw new Exception("FileName can not be changed while logging is active");
					}
					this.m_FileName = value;
					base.DoPropertyChange(this, "FileName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int BufferSize
		{
			get
			{
				return this.m_BufferSize;
			}
			set
			{
				base.PropertyUpdateDefault("BufferSize", value);
				if (this.BufferSize != value)
				{
					this.m_BufferSize = value;
					base.DoPropertyChange(this, "BufferSize");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Append
		{
			get
			{
				return this.m_Append;
			}
			set
			{
				base.PropertyUpdateDefault("Append", value);
				if (this.Append != value)
				{
					this.m_Append = value;
					base.DoPropertyChange(this, "Append");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool AppendFileMustExist
		{
			get
			{
				return this.m_AppendFileMustExist;
			}
			set
			{
				base.PropertyUpdateDefault("AppendFileMustExist", value);
				if (this.AppendFileMustExist != value)
				{
					this.m_AppendFileMustExist = value;
					base.DoPropertyChange(this, "AppendFileMustExist");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool AllowFileOverwrite
		{
			get
			{
				return this.m_AllowFileOverwrite;
			}
			set
			{
				base.PropertyUpdateDefault("AllowFileOverwrite", value);
				if (this.AllowFileOverwrite != value)
				{
					this.m_AllowFileOverwrite = value;
					base.DoPropertyChange(this, "AllowFileOverwrite");
				}
			}
		}

		[Description("")]
		public bool Active
		{
			get
			{
				return this.m_Active;
			}
		}

		[Description("")]
		public int BufferIndex
		{
			get
			{
				return this.m_BufferIndex;
			}
		}

		[Description("")]
		public int BufferCount
		{
			get
			{
				return this.m_BufferCount;
			}
		}

		private Plot Plot => this.m_Plot;

		public event EventHandler Activated;

		public event EventHandler Deactivated;

		protected override string GetPlugInTitle()
		{
			return "Log File";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLogFileAdapterEditorPlugIn";
		}

		void IPlotLogFileAdapter.IncrementBufferCount()
		{
			this.IncrementBufferCount();
		}

		public PlotLogFileAdapter()
		{
			base.DoCreate();
		}

		public PlotLogFileAdapter(Plot value)
		{
			this.m_Plot = value;
			base.DoCreate();
		}

		private bool ShouldSerializeFileName()
		{
			return base.PropertyShouldSerialize("FileName");
		}

		private void ResetFileName()
		{
			base.PropertyReset("FileName");
		}

		private bool ShouldSerializeBufferSize()
		{
			return base.PropertyShouldSerialize("BufferSize");
		}

		private void ResetBufferSize()
		{
			base.PropertyReset("BufferSize");
		}

		private bool ShouldSerializeAppend()
		{
			return base.PropertyShouldSerialize("Append");
		}

		private void ResetAppend()
		{
			base.PropertyReset("Append");
		}

		private bool ShouldSerializeAppendFileMustExist()
		{
			return base.PropertyShouldSerialize("AppendFileMustExist");
		}

		private void ResetAppendFileMustExist()
		{
			base.PropertyReset("AppendFileMustExist");
		}

		private bool ShouldSerializeAllowFileOverwrite()
		{
			return base.PropertyShouldSerialize("AllowFileOverwrite");
		}

		private void ResetAllowFileOverwrite()
		{
			base.PropertyReset("AllowFileOverwrite");
		}

		private void IncrementBufferCount()
		{
			this.m_BufferCount++;
			if (this.m_BufferCount >= this.BufferSize)
			{
				this.Flush();
			}
		}

		private void OnActivated()
		{
			if (this.Activated != null)
			{
				this.Activated(this, EventArgs.Empty);
			}
		}

		private void OnDeactivated()
		{
			if (this.Deactivated != null)
			{
				this.Deactivated(this, EventArgs.Empty);
			}
		}

		private void Flush()
		{
			if (this.m_BufferCount != 0)
			{
				string fileDeliminatorCharacter = this.Plot.FileDeliminatorCharacter;
				FileStream fileStream = File.Open(this.FileName, FileMode.Append, FileAccess.Write, FileShare.None);
				try
				{
					StreamWriter streamWriter = new StreamWriter(fileStream);
					try
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < this.BufferCount; i++)
						{
							stringBuilder.Length = 0;
							stringBuilder.Append(this.Plot.Channels[0].GetX(this.BufferIndex + i).ToString());
							stringBuilder.Append(fileDeliminatorCharacter);
							for (int j = 0; j < this.Plot.Channels.Count; j++)
							{
								stringBuilder.Append(this.Plot.Channels[j].GetY(this.BufferIndex + i).ToString());
								if (j != this.Plot.Channels.LastIndex)
								{
									stringBuilder.Append(fileDeliminatorCharacter);
								}
							}
							streamWriter.WriteLine(stringBuilder.ToString());
						}
					}
					finally
					{
						streamWriter.Close();
					}
				}
				finally
				{
					fileStream.Close();
				}
				this.m_BufferIndex += this.BufferCount;
				this.m_BufferCount = 0;
			}
		}

		private void LogFinalSetup()
		{
			this.m_BufferIndex = this.Plot.Channels[0].Count;
			this.m_BufferCount = 0;
			this.m_Active = true;
			this.OnActivated();
		}

		private void CheckChannelsForSynchronization()
		{
			PlotChannelBase plotChannelBase = this.Plot.Channels[0];
			int num = 1;
			while (true)
			{
				if (num < this.Plot.Channels.Count)
				{
					if (plotChannelBase.Count == this.Plot.Channels[num].Count)
					{
						num++;
						continue;
					}
					break;
				}
				return;
			}
			throw new Exception("Log Activate Error: Channels not Synchronized (Data-Point Counts Differ).");
		}

		public void Activate()
		{
			if (this.Active)
			{
				throw new Exception("Log Activate Error: Log is already active.");
			}
			if (this.Plot.Channels.Count == 0)
			{
				throw new Exception("Log Activate Error: No Channels.");
			}
			this.CheckChannelsForSynchronization();
			if (this.FileName == null)
			{
				throw new Exception("Log Activate Error: File Name not defined");
			}
			if (this.FileName == Const.EmptyString)
			{
				throw new Exception("Log Activate Error: File Name not defined");
			}
			string fileDeliminatorCharacter = this.Plot.FileDeliminatorCharacter;
			bool flag = File.Exists(this.FileName);
			FileStream fileStream;
			if (!this.Append)
			{
				if (flag && !this.AllowFileOverwrite)
				{
					throw new Exception("Log Activate Error: " + this.FileName + " already exists! Can not overwrite.");
				}
			}
			else
			{
				if (!flag && this.AppendFileMustExist)
				{
					throw new Exception("Log Activate Error: Can not append, " + this.FileName + " does not exist.");
				}
				if (flag)
				{
					fileStream = File.Open(this.FileName, FileMode.Append, FileAccess.Write, FileShare.None);
					fileStream.Close();
					this.LogFinalSetup();
					return;
				}
			}
			fileStream = File.Open(this.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				StreamWriter streamWriter = new StreamWriter(fileStream);
				try
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("(X)");
					stringBuilder.Append(fileDeliminatorCharacter);
					for (int i = 0; i < this.Plot.Channels.Count; i++)
					{
						stringBuilder.Append(this.Plot.Channels[i].DisplayDescription);
						stringBuilder.Append("(Y)");
						if (i != this.Plot.Channels.LastIndex)
						{
							stringBuilder.Append(fileDeliminatorCharacter);
						}
					}
					streamWriter.WriteLine(stringBuilder.ToString());
				}
				finally
				{
					streamWriter.Close();
				}
			}
			finally
			{
				fileStream.Close();
			}
			this.LogFinalSetup();
		}

		public void Deactivate()
		{
			if (!this.Active)
			{
				throw new Exception("Log Deactivate Error: Log is not active.");
			}
			this.Flush();
			this.m_Active = false;
			this.OnDeactivated();
		}
	}
}
