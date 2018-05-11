using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotAxisTrackingEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel7;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignFirstStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private EditBox ScrollCompressMaxTextBox;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ExpandStyleComboBox;

		private FocusLabel focusLabel4;

		private EditBox SpanMinEditBox;

		private EditBox MinMarginEditBox;

		private FocusLabel focusLabel5;

		private EditBox MaxMarginEditBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotAxisTrackingEditorPlugIn()
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
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.AlignFirstStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ScrollCompressMaxTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.ExpandStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel3 = new FocusLabel();
			this.SpanMinEditBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.MinMarginEditBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.MaxMarginEditBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(96, 72);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(136, 21);
			this.StyleComboBox.TabIndex = 1;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.StyleComboBox;
			this.focusLabel7.Location = new Point(64, 74);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(32, 15);
			this.focusLabel7.Text = "Style";
			this.focusLabel7.LoadingEnd();
			this.AlignFirstStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.AlignFirstStyleComboBox.Location = new Point(352, 184);
			this.AlignFirstStyleComboBox.MaxDropDownItems = 20;
			this.AlignFirstStyleComboBox.Name = "AlignFirstStyleComboBox";
			this.AlignFirstStyleComboBox.PropertyName = "AlignFirstStyle";
			this.AlignFirstStyleComboBox.Size = new Size(136, 21);
			this.AlignFirstStyleComboBox.TabIndex = 6;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.AlignFirstStyleComboBox;
			this.focusLabel1.Location = new Point(268, 186);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(84, 15);
			this.focusLabel1.Text = "Align First Style";
			this.focusLabel1.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(96, 40);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 0;
			this.EnabledCheckBox.Text = "Enabled";
			this.ScrollCompressMaxTextBox.LoadingBegin();
			this.ScrollCompressMaxTextBox.Location = new Point(352, 208);
			this.ScrollCompressMaxTextBox.Name = "ScrollCompressMaxTextBox";
			this.ScrollCompressMaxTextBox.PropertyName = "ScrollCompressMax";
			this.ScrollCompressMaxTextBox.Size = new Size(136, 20);
			this.ScrollCompressMaxTextBox.TabIndex = 7;
			this.ScrollCompressMaxTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.ScrollCompressMaxTextBox;
			this.focusLabel2.Location = new Point(240, 210);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(112, 15);
			this.focusLabel2.Text = "Scroll Compress Max";
			this.focusLabel2.LoadingEnd();
			this.ExpandStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ExpandStyleComboBox.Location = new Point(96, 96);
			this.ExpandStyleComboBox.MaxDropDownItems = 20;
			this.ExpandStyleComboBox.Name = "ExpandStyleComboBox";
			this.ExpandStyleComboBox.PropertyName = "ExpandStyle";
			this.ExpandStyleComboBox.Size = new Size(136, 21);
			this.ExpandStyleComboBox.TabIndex = 2;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.ExpandStyleComboBox;
			this.focusLabel3.Location = new Point(24, 98);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(72, 15);
			this.focusLabel3.Text = "Expand Style";
			this.focusLabel3.LoadingEnd();
			this.SpanMinEditBox.LoadingBegin();
			this.SpanMinEditBox.Location = new Point(96, 144);
			this.SpanMinEditBox.Name = "SpanMinEditBox";
			this.SpanMinEditBox.PropertyName = "SpanMin";
			this.SpanMinEditBox.Size = new Size(136, 20);
			this.SpanMinEditBox.TabIndex = 3;
			this.SpanMinEditBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.SpanMinEditBox;
			this.focusLabel4.Location = new Point(42, 146);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(54, 15);
			this.focusLabel4.Text = "Span Min";
			this.focusLabel4.LoadingEnd();
			this.MinMarginEditBox.LoadingBegin();
			this.MinMarginEditBox.Location = new Point(96, 208);
			this.MinMarginEditBox.Name = "MinMarginEditBox";
			this.MinMarginEditBox.PropertyName = "MinMargin";
			this.MinMarginEditBox.Size = new Size(136, 20);
			this.MinMarginEditBox.TabIndex = 5;
			this.MinMarginEditBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.MinMarginEditBox;
			this.focusLabel5.Location = new Point(34, 210);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(62, 15);
			this.focusLabel5.Text = "Min Margin";
			this.focusLabel5.LoadingEnd();
			this.MaxMarginEditBox.LoadingBegin();
			this.MaxMarginEditBox.Location = new Point(96, 184);
			this.MaxMarginEditBox.Name = "MaxMarginEditBox";
			this.MaxMarginEditBox.PropertyName = "MaxMargin";
			this.MaxMarginEditBox.Size = new Size(136, 20);
			this.MaxMarginEditBox.TabIndex = 4;
			this.MaxMarginEditBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.MaxMarginEditBox;
			this.focusLabel6.Location = new Point(31, 186);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(65, 15);
			this.focusLabel6.Text = "Max Margin";
			this.focusLabel6.LoadingEnd();
			base.Controls.Add(this.MaxMarginEditBox);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.MinMarginEditBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.SpanMinEditBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.ExpandStyleComboBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.ScrollCompressMaxTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.AlignFirstStyleComboBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.focusLabel7);
			base.Location = new Point(10, 20);
			base.Name = "PlotAxisTrackingEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
