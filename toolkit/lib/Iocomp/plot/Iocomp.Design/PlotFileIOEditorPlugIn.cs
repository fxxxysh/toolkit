using Iocomp.Instrumentation.Plotting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotFileIOEditorPlugIn : PlugInStandard
	{
		private GroupBox ConfigurationGroupBox;

		private GroupBox DataGroupBox;

		private Button SaveConfigurationButton;

		private Button LoadConfigurationButton;

		private Button LoadDataButton;

		private Button SaveDataButton;

		private Container components;

		public PlotFileIOEditorPlugIn()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.ConfigurationGroupBox = new GroupBox();
			this.LoadConfigurationButton = new Button();
			this.SaveConfigurationButton = new Button();
			this.DataGroupBox = new GroupBox();
			this.LoadDataButton = new Button();
			this.SaveDataButton = new Button();
			this.ConfigurationGroupBox.SuspendLayout();
			this.DataGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.ConfigurationGroupBox.Controls.Add(this.LoadConfigurationButton);
			this.ConfigurationGroupBox.Controls.Add(this.SaveConfigurationButton);
			this.ConfigurationGroupBox.Location = new Point(48, 32);
			this.ConfigurationGroupBox.Name = "ConfigurationGroupBox";
			this.ConfigurationGroupBox.Size = new Size(152, 120);
			this.ConfigurationGroupBox.TabIndex = 0;
			this.ConfigurationGroupBox.TabStop = false;
			this.ConfigurationGroupBox.Text = "Properties (Configuration)";
			this.LoadConfigurationButton.Location = new Point(40, 72);
			this.LoadConfigurationButton.Name = "LoadConfigurationButton";
			this.LoadConfigurationButton.Size = new Size(80, 23);
			this.LoadConfigurationButton.TabIndex = 1;
			this.LoadConfigurationButton.Text = "Load";
			this.LoadConfigurationButton.Click += this.LoadConfigurationButton_Click;
			this.SaveConfigurationButton.Location = new Point(40, 24);
			this.SaveConfigurationButton.Name = "SaveConfigurationButton";
			this.SaveConfigurationButton.Size = new Size(80, 23);
			this.SaveConfigurationButton.TabIndex = 0;
			this.SaveConfigurationButton.Text = "Save";
			this.SaveConfigurationButton.Click += this.SaveConfigurationButton_Click;
			this.DataGroupBox.Controls.Add(this.LoadDataButton);
			this.DataGroupBox.Controls.Add(this.SaveDataButton);
			this.DataGroupBox.Location = new Point(216, 32);
			this.DataGroupBox.Name = "DataGroupBox";
			this.DataGroupBox.Size = new Size(152, 120);
			this.DataGroupBox.TabIndex = 1;
			this.DataGroupBox.TabStop = false;
			this.DataGroupBox.Text = "Data (All Channels)";
			this.LoadDataButton.Location = new Point(40, 69);
			this.LoadDataButton.Name = "LoadDataButton";
			this.LoadDataButton.Size = new Size(80, 23);
			this.LoadDataButton.TabIndex = 1;
			this.LoadDataButton.Text = "Load";
			this.LoadDataButton.Click += this.LoadDataButton_Click;
			this.SaveDataButton.Location = new Point(40, 24);
			this.SaveDataButton.Name = "SaveDataButton";
			this.SaveDataButton.Size = new Size(80, 23);
			this.SaveDataButton.TabIndex = 0;
			this.SaveDataButton.Text = "Save";
			this.SaveDataButton.Click += this.SaveDataButton_Click;
			base.Controls.Add(this.DataGroupBox);
			base.Controls.Add(this.ConfigurationGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotFileIOEditorPlugIn";
			base.Size = new Size(544, 256);
			this.ConfigurationGroupBox.ResumeLayout(false);
			this.DataGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void SaveConfigurationButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Configuration";
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.ShowHelp = true;
			saveFileDialog.InitialDirectory = Application.StartupPath;
			saveFileDialog.FileName = "Untitled.cfg";
			saveFileDialog.DefaultExt = "cfg";
			saveFileDialog.Filter = "Configuration(*.cfg)|*.cfg|All Files(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).SavePropertiesToFile(saveFileDialog.FileName);
			}
		}

		private void LoadConfigurationButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load Configuration";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ShowHelp = true;
			openFileDialog.ValidateNames = true;
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "cfg";
			openFileDialog.Filter = "Configuration(*.cfg)|*.cfg|All Files(*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).LoadPropertiesFromFile(openFileDialog.FileName);
			}
		}

		private void SaveDataButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Data";
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.InitialDirectory = Application.StartupPath;
			saveFileDialog.ShowHelp = true;
			saveFileDialog.FileName = "Untitled.dat";
			saveFileDialog.DefaultExt = "dat";
			saveFileDialog.Filter = "Data(*.dat)|*.dat|All Files(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).SaveDataToFile(saveFileDialog.FileName);
			}
		}

		private void LoadDataButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load Data";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ShowHelp = true;
			openFileDialog.ValidateNames = true;
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "dat";
			openFileDialog.Filter = "Data(*.dat)|*.dat|All Files(*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).LoadDataFromFile(openFileDialog.FileName);
			}
		}
	}
}
