using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotAnnotationUnitTypesEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeHeightComboBox;

		private FocusLabel focusLabel13;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeWidthComboBox;

		private FocusLabel focusLabel12;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeYComboBox;

		private FocusLabel focusLabel11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeXComboBox;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeSizeComboBox;

		private FocusLabel focusLabel9;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeLocationComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeAllComboBox;

		private FocusLabel focusLabel3;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox1;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox2;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox3;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox4;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox5;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox6;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox7;

		private FocusLabel focusLabel14;

		private Label label1;

		private Container components;

		public PlotAnnotationUnitTypesEditorPlugIn()
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
			this.UnitTypeHeightComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel13 = new FocusLabel();
			this.UnitTypeWidthComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel12 = new FocusLabel();
			this.UnitTypeYComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel11 = new FocusLabel();
			this.UnitTypeXComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel10 = new FocusLabel();
			this.UnitTypeSizeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel9 = new FocusLabel();
			this.UnitTypeLocationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.UnitTypeAllComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel3 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.comboBox7 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel14 = new FocusLabel();
			this.comboBox6 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.comboBox5 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel6 = new FocusLabel();
			this.comboBox4 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.comboBox3 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel4 = new FocusLabel();
			this.comboBox2 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel2 = new FocusLabel();
			this.comboBox1 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.label1 = new Label();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.UnitTypeHeightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeHeightComboBox.Location = new Point(192, 120);
			this.UnitTypeHeightComboBox.MaxDropDownItems = 20;
			this.UnitTypeHeightComboBox.Name = "UnitTypeHeightComboBox";
			this.UnitTypeHeightComboBox.PropertyName = "UnitTypeHeight";
			this.UnitTypeHeightComboBox.Size = new Size(80, 21);
			this.UnitTypeHeightComboBox.TabIndex = 6;
			this.focusLabel13.LoadingBegin();
			this.focusLabel13.FocusControl = this.UnitTypeHeightComboBox;
			this.focusLabel13.Location = new Point(153, 122);
			this.focusLabel13.Name = "focusLabel13";
			this.focusLabel13.Size = new Size(39, 15);
			this.focusLabel13.Text = "Height";
			this.focusLabel13.LoadingEnd();
			this.UnitTypeWidthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeWidthComboBox.Location = new Point(192, 96);
			this.UnitTypeWidthComboBox.MaxDropDownItems = 20;
			this.UnitTypeWidthComboBox.Name = "UnitTypeWidthComboBox";
			this.UnitTypeWidthComboBox.PropertyName = "UnitTypeWidth";
			this.UnitTypeWidthComboBox.Size = new Size(80, 21);
			this.UnitTypeWidthComboBox.TabIndex = 5;
			this.focusLabel12.LoadingBegin();
			this.focusLabel12.FocusControl = this.UnitTypeWidthComboBox;
			this.focusLabel12.Location = new Point(156, 98);
			this.focusLabel12.Name = "focusLabel12";
			this.focusLabel12.Size = new Size(36, 15);
			this.focusLabel12.Text = "Width";
			this.focusLabel12.LoadingEnd();
			this.UnitTypeYComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeYComboBox.Location = new Point(56, 120);
			this.UnitTypeYComboBox.MaxDropDownItems = 20;
			this.UnitTypeYComboBox.Name = "UnitTypeYComboBox";
			this.UnitTypeYComboBox.PropertyName = "UnitTypeY";
			this.UnitTypeYComboBox.Size = new Size(80, 21);
			this.UnitTypeYComboBox.TabIndex = 3;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.UnitTypeYComboBox;
			this.focusLabel11.Location = new Point(41, 122);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(15, 15);
			this.focusLabel11.Text = "Y";
			this.focusLabel11.LoadingEnd();
			this.UnitTypeXComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeXComboBox.Location = new Point(56, 96);
			this.UnitTypeXComboBox.MaxDropDownItems = 20;
			this.UnitTypeXComboBox.Name = "UnitTypeXComboBox";
			this.UnitTypeXComboBox.PropertyName = "UnitTypeX";
			this.UnitTypeXComboBox.Size = new Size(80, 21);
			this.UnitTypeXComboBox.TabIndex = 2;
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.UnitTypeXComboBox;
			this.focusLabel10.Location = new Point(41, 98);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(15, 15);
			this.focusLabel10.Text = "X";
			this.focusLabel10.LoadingEnd();
			this.UnitTypeSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeSizeComboBox.Location = new Point(192, 64);
			this.UnitTypeSizeComboBox.MaxDropDownItems = 20;
			this.UnitTypeSizeComboBox.Name = "UnitTypeSizeComboBox";
			this.UnitTypeSizeComboBox.PropertyName = "UnitTypeSize";
			this.UnitTypeSizeComboBox.Size = new Size(80, 21);
			this.UnitTypeSizeComboBox.TabIndex = 4;
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.UnitTypeSizeComboBox;
			this.focusLabel9.Location = new Point(163, 66);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(29, 15);
			this.focusLabel9.Text = "Size";
			this.focusLabel9.LoadingEnd();
			this.UnitTypeLocationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeLocationComboBox.Location = new Point(56, 64);
			this.UnitTypeLocationComboBox.MaxDropDownItems = 20;
			this.UnitTypeLocationComboBox.Name = "UnitTypeLocationComboBox";
			this.UnitTypeLocationComboBox.PropertyName = "UnitTypeLocation";
			this.UnitTypeLocationComboBox.Size = new Size(80, 21);
			this.UnitTypeLocationComboBox.TabIndex = 1;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.UnitTypeLocationComboBox;
			this.focusLabel8.Location = new Point(7, 66);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(49, 15);
			this.focusLabel8.Text = "Location";
			this.focusLabel8.LoadingEnd();
			this.UnitTypeAllComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.UnitTypeAllComboBox.Location = new Point(56, 32);
			this.UnitTypeAllComboBox.MaxDropDownItems = 20;
			this.UnitTypeAllComboBox.Name = "UnitTypeAllComboBox";
			this.UnitTypeAllComboBox.PropertyName = "UnitTypeAll";
			this.UnitTypeAllComboBox.Size = new Size(80, 21);
			this.UnitTypeAllComboBox.TabIndex = 0;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.UnitTypeAllComboBox;
			this.focusLabel3.Location = new Point(36, 34);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(20, 15);
			this.focusLabel3.Text = "All";
			this.focusLabel3.LoadingEnd();
			this.groupBox1.Controls.Add(this.comboBox7);
			this.groupBox1.Controls.Add(this.focusLabel14);
			this.groupBox1.Controls.Add(this.comboBox6);
			this.groupBox1.Controls.Add(this.focusLabel7);
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.focusLabel6);
			this.groupBox1.Controls.Add(this.comboBox4);
			this.groupBox1.Controls.Add(this.focusLabel5);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.focusLabel4);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.focusLabel2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.focusLabel1);
			this.groupBox1.Location = new Point(296, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(296, 152);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actual";
			this.comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox7.Location = new Point(200, 112);
			this.comboBox7.MaxDropDownItems = 20;
			this.comboBox7.Name = "comboBox7";
			this.comboBox7.PropertyName = "ActualUnitTypeHeight";
			this.comboBox7.ReadOnly = true;
			this.comboBox7.Size = new Size(80, 21);
			this.comboBox7.TabIndex = 6;
			this.focusLabel14.LoadingBegin();
			this.focusLabel14.AutoSize = false;
			this.focusLabel14.FocusControl = this.comboBox7;
			this.focusLabel14.Location = new Point(161, 114);
			this.focusLabel14.Name = "focusLabel14";
			this.focusLabel14.Size = new Size(39, 15);
			this.focusLabel14.Text = "Height";
			this.focusLabel14.LoadingEnd();
			this.comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox6.Location = new Point(200, 88);
			this.comboBox6.MaxDropDownItems = 20;
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.PropertyName = "ActualUnitTypeWidth";
			this.comboBox6.ReadOnly = true;
			this.comboBox6.Size = new Size(80, 21);
			this.comboBox6.TabIndex = 5;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.comboBox6;
			this.focusLabel7.Location = new Point(164, 90);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(36, 15);
			this.focusLabel7.Text = "Width";
			this.focusLabel7.LoadingEnd();
			this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox5.Location = new Point(64, 112);
			this.comboBox5.MaxDropDownItems = 20;
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.PropertyName = "ActualUnitTypeY";
			this.comboBox5.ReadOnly = true;
			this.comboBox5.Size = new Size(80, 21);
			this.comboBox5.TabIndex = 3;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.comboBox5;
			this.focusLabel6.Location = new Point(49, 114);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(15, 15);
			this.focusLabel6.Text = "Y";
			this.focusLabel6.LoadingEnd();
			this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox4.Location = new Point(64, 88);
			this.comboBox4.MaxDropDownItems = 20;
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.PropertyName = "ActualUnitTypeX";
			this.comboBox4.ReadOnly = true;
			this.comboBox4.Size = new Size(80, 21);
			this.comboBox4.TabIndex = 2;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.comboBox4;
			this.focusLabel5.Location = new Point(49, 90);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(15, 15);
			this.focusLabel5.Text = "X";
			this.focusLabel5.LoadingEnd();
			this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox3.Location = new Point(200, 56);
			this.comboBox3.MaxDropDownItems = 20;
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.PropertyName = "ActualUnitTypeSize";
			this.comboBox3.ReadOnly = true;
			this.comboBox3.Size = new Size(80, 21);
			this.comboBox3.TabIndex = 4;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.comboBox3;
			this.focusLabel4.Location = new Point(171, 58);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(29, 15);
			this.focusLabel4.Text = "Size";
			this.focusLabel4.LoadingEnd();
			this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox2.Location = new Point(64, 56);
			this.comboBox2.MaxDropDownItems = 20;
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.PropertyName = "ActualUnitTypeLocation";
			this.comboBox2.ReadOnly = true;
			this.comboBox2.Size = new Size(80, 21);
			this.comboBox2.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.comboBox2;
			this.focusLabel2.Location = new Point(15, 58);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(49, 15);
			this.focusLabel2.Text = "Location";
			this.focusLabel2.LoadingEnd();
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new Point(64, 24);
			this.comboBox1.MaxDropDownItems = 20;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.PropertyName = "ActualUnitTypeAll";
			this.comboBox1.ReadOnly = true;
			this.comboBox1.Size = new Size(80, 21);
			this.comboBox1.TabIndex = 0;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.comboBox1;
			this.focusLabel1.Location = new Point(44, 26);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(20, 15);
			this.focusLabel1.Text = "All";
			this.focusLabel1.LoadingEnd();
			this.label1.Location = new Point(8, 168);
			this.label1.Name = "label1";
			this.label1.Size = new Size(296, 64);
			this.label1.TabIndex = 8;
			this.label1.Text = "Notes: For Line && Polygon Annotations, use the All setting only! Pixel option is typically used on the Size, Width, and Height settings only! Percent settings are in units of 0.0 - 1.0";
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.UnitTypeHeightComboBox);
			base.Controls.Add(this.focusLabel13);
			base.Controls.Add(this.UnitTypeWidthComboBox);
			base.Controls.Add(this.focusLabel12);
			base.Controls.Add(this.UnitTypeYComboBox);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.UnitTypeXComboBox);
			base.Controls.Add(this.focusLabel10);
			base.Controls.Add(this.UnitTypeSizeComboBox);
			base.Controls.Add(this.focusLabel9);
			base.Controls.Add(this.UnitTypeLocationComboBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.UnitTypeAllComboBox);
			base.Controls.Add(this.focusLabel3);
			base.Location = new Point(10, 20);
			base.Name = "PlotAnnotationUnitTypesEditorPlugIn";
			base.Size = new Size(608, 240);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
