using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PercentLegendEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private CheckBox VisibleCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MarginTextBox;

		private EditBox RowSpacingTextBox;

		private EditBox TitleMarginTextBox;

		private FocusLabel label1;

		private ColorPicker ForeColorPicker;

		private FontButton FontButton;

		private Container components;

		public PercentLegendEditorPlugIn()
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
			this.VisibleCheckBox = new CheckBox();
			this.label4 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			this.label2 = new FocusLabel();
			this.RowSpacingTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.MarginTextBox = new EditBox();
			this.FontButton = new FontButton();
			this.TitleMarginTextBox = new EditBox();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(80, 0);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(64, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ForeColorPicker;
			this.label4.Location = new Point(21, 123);
			this.label4.Name = "label4";
			this.label4.Size = new Size(59, 15);
			this.label4.Text = "Fore Color";
			this.label4.LoadingEnd();
			this.ForeColorPicker.Location = new Point(80, 120);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(144, 21);
			this.ForeColorPicker.TabIndex = 4;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.RowSpacingTextBox;
			this.label2.Location = new Point(8, 82);
			this.label2.Name = "label2";
			this.label2.Size = new Size(72, 15);
			this.label2.Text = "Row Spacing";
			this.label2.LoadingEnd();
			this.RowSpacingTextBox.LoadingBegin();
			this.RowSpacingTextBox.Location = new Point(80, 80);
			this.RowSpacingTextBox.Name = "RowSpacingTextBox";
			this.RowSpacingTextBox.PropertyName = "RowSpacing";
			this.RowSpacingTextBox.Size = new Size(48, 20);
			this.RowSpacingTextBox.TabIndex = 3;
			this.RowSpacingTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MarginTextBox;
			this.label3.Location = new Point(39, 34);
			this.label3.Name = "label3";
			this.label3.Size = new Size(41, 15);
			this.label3.Text = "Margin";
			this.label3.LoadingEnd();
			this.MarginTextBox.LoadingBegin();
			this.MarginTextBox.Location = new Point(80, 32);
			this.MarginTextBox.Name = "MarginTextBox";
			this.MarginTextBox.PropertyName = "Margin";
			this.MarginTextBox.Size = new Size(48, 20);
			this.MarginTextBox.TabIndex = 1;
			this.MarginTextBox.LoadingEnd();
			this.FontButton.Location = new Point(280, 120);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.TabIndex = 5;
			this.TitleMarginTextBox.LoadingBegin();
			this.TitleMarginTextBox.Location = new Point(80, 56);
			this.TitleMarginTextBox.Name = "TitleMarginTextBox";
			this.TitleMarginTextBox.PropertyName = "TitleMargin";
			this.TitleMarginTextBox.Size = new Size(48, 20);
			this.TitleMarginTextBox.TabIndex = 2;
			this.TitleMarginTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.TitleMarginTextBox;
			this.label1.Location = new Point(15, 58);
			this.label1.Name = "label1";
			this.label1.Size = new Size(65, 15);
			this.label1.Text = "Title Margin";
			this.label1.LoadingEnd();
			base.Controls.Add(this.label1);
			base.Controls.Add(this.TitleMarginTextBox);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.RowSpacingTextBox);
			base.Controls.Add(this.MarginTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.VisibleCheckBox);
			base.Name = "PercentLegendEditorPlugIn";
			base.Size = new Size(496, 224);
			base.Title = "Legend Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PercentLegendColumnEditorPlugIn(), "Column Value", false);
			base.AddSubPlugIn(new PercentLegendColumnEditorPlugIn(), "Column Percent", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PercentLegend).ColumnValue;
			base.SubPlugIns[1].Value = (base.Value as PercentLegend).ColumnPercent;
		}
	}
}
