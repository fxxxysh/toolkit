using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataCursorChannelEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel4;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox ChannelNameTextBox;

		private EditBox Pointer1PositionTextBox;

		private EditBox Pointer2PositionTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SnapToPointCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterControlCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox HideHintOnDragCheckBox;

		private Container components;

		public PlotDataCursorChannelEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ChannelNameTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.Pointer1PositionTextBox = new EditBox();
			this.XReferenceLabel = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel2 = new FocusLabel();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.Pointer2PositionTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.SnapToPointCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel6 = new FocusLabel();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.MasterControlCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.HideHintOnDragCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)this.LayerNumericUpDown).BeginInit();
			((ISupportInitialize)this.HitRegionSizeUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(272, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 7;
			this.VisibleCheckBox.Text = "Visible";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(104, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(67, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ChannelNameTextBox.LoadingBegin();
			this.ChannelNameTextBox.Location = new Point(104, 136);
			this.ChannelNameTextBox.Name = "ChannelNameTextBox";
			this.ChannelNameTextBox.PropertyName = "ChannelName";
			this.ChannelNameTextBox.Size = new Size(144, 20);
			this.ChannelNameTextBox.TabIndex = 4;
			this.ChannelNameTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ChannelNameTextBox;
			this.focusLabel4.Location = new Point(23, 138);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(81, 15);
			this.focusLabel4.Text = "Channel Name";
			this.focusLabel4.LoadingEnd();
			this.ColorPicker.Location = new Point(104, 200);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 5;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(70, 203);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.Pointer1PositionTextBox.LoadingBegin();
			this.Pointer1PositionTextBox.Location = new Point(104, 80);
			this.Pointer1PositionTextBox.Name = "Pointer1PositionTextBox";
			this.Pointer1PositionTextBox.PropertyName = "Pointer1Position";
			this.Pointer1PositionTextBox.Size = new Size(144, 20);
			this.Pointer1PositionTextBox.TabIndex = 2;
			this.Pointer1PositionTextBox.LoadingEnd();
			this.XReferenceLabel.LoadingBegin();
			this.XReferenceLabel.FocusControl = this.Pointer1PositionTextBox;
			this.XReferenceLabel.Location = new Point(10, 82);
			this.XReferenceLabel.Name = "XReferenceLabel";
			this.XReferenceLabel.Size = new Size(94, 15);
			this.XReferenceLabel.Text = "Pointer 1 Position";
			this.XReferenceLabel.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(104, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TitleTextBox;
			this.focusLabel2.Location = new Point(51, 43);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(53, 15);
			this.focusLabel2.Text = "Title Text";
			this.focusLabel2.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(272, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 8;
			this.EnabledCheckBox.Text = "Enabled";
			this.ContextMenuEnabledCheckBox.Location = new Point(384, 27);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 9;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.Pointer2PositionTextBox.LoadingBegin();
			this.Pointer2PositionTextBox.Location = new Point(104, 104);
			this.Pointer2PositionTextBox.Name = "Pointer2PositionTextBox";
			this.Pointer2PositionTextBox.PropertyName = "Pointer2Position";
			this.Pointer2PositionTextBox.Size = new Size(144, 20);
			this.Pointer2PositionTextBox.TabIndex = 3;
			this.Pointer2PositionTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.Pointer2PositionTextBox;
			this.focusLabel3.Location = new Point(10, 106);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(94, 15);
			this.focusLabel3.Text = "Pointer 2 Position";
			this.focusLabel3.LoadingEnd();
			this.LayerNumericUpDown.Location = new Point(192, 200);
			this.LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.LayerNumericUpDown.Name = "LayerNumericUpDown";
			this.LayerNumericUpDown.PropertyName = "Layer";
			this.LayerNumericUpDown.Size = new Size(56, 20);
			this.LayerNumericUpDown.TabIndex = 6;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(157, 201);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(272, 51);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 10;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(288, 136);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(120, 21);
			this.StyleComboBox.TabIndex = 15;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.StyleComboBox;
			this.focusLabel7.Location = new Point(256, 138);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(32, 15);
			this.focusLabel7.Text = "Style";
			this.focusLabel7.LoadingEnd();
			this.SnapToPointCheckBox.Location = new Point(272, 79);
			this.SnapToPointCheckBox.Name = "SnapToPointCheckBox";
			this.SnapToPointCheckBox.PropertyName = "SnapToPoint";
			this.SnapToPointCheckBox.Size = new Size(96, 24);
			this.SnapToPointCheckBox.TabIndex = 12;
			this.SnapToPointCheckBox.Text = "Snap To Point";
			this.HitRegionSizeUpDown.Location = new Point(352, 200);
			this.HitRegionSizeUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.HitRegionSizeUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.HitRegionSizeUpDown.Name = "HitRegionSizeUpDown";
			this.HitRegionSizeUpDown.PropertyName = "HitRegionSize";
			this.HitRegionSizeUpDown.Size = new Size(56, 20);
			this.HitRegionSizeUpDown.TabIndex = 17;
			this.HitRegionSizeUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.HitRegionSizeUpDown;
			this.focusLabel6.Location = new Point(269, 201);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(83, 15);
			this.focusLabel6.Text = "Hit Region Size";
			this.focusLabel6.LoadingEnd();
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(328, 160);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 16;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel8.Location = new Point(253, 162);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(75, 15);
			this.focusLabel8.Text = "Clipping Style";
			this.focusLabel8.LoadingEnd();
			this.MasterControlCheckBox.Location = new Point(272, 103);
			this.MasterControlCheckBox.Name = "MasterControlCheckBox";
			this.MasterControlCheckBox.PropertyName = "MasterControl";
			this.MasterControlCheckBox.Size = new Size(136, 24);
			this.MasterControlCheckBox.TabIndex = 14;
			this.MasterControlCheckBox.Text = "Master Control";
			this.CanFocusCheckBox.Location = new Point(384, 51);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 11;
			this.CanFocusCheckBox.Text = "Can Focus";
			this.HideHintOnDragCheckBox.Location = new Point(384, 80);
			this.HideHintOnDragCheckBox.Name = "HideHintOnDragCheckBox";
			this.HideHintOnDragCheckBox.PropertyName = "HideHintOnDrag";
			this.HideHintOnDragCheckBox.Size = new Size(136, 24);
			this.HideHintOnDragCheckBox.TabIndex = 13;
			this.HideHintOnDragCheckBox.Text = "Hide Hint On Drag";
			base.Controls.Add(this.HideHintOnDragCheckBox);
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.MasterControlCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.HitRegionSizeUpDown);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.SnapToPointCheckBox);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.Pointer2PositionTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.Pointer1PositionTextBox);
			base.Controls.Add(this.XReferenceLabel);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.ChannelNameTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorChannelEditorPlugIn";
			base.Size = new Size(552, 256);
			((ISupportInitialize)this.LayerNumericUpDown).EndInit();
			((ISupportInitialize)this.HitRegionSizeUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
			base.AddSubPlugIn(new PlotDataCursorHintEditorPlugIn(), "Hint", false);
			base.AddSubPlugIn(new PlotDataCursorWindowEditorPlugIn(), "Window", false);
			base.AddSubPlugIn(new PlotDataCursorMultipleStyleMenuItemsEditorPlugIn(), "Style Menu-Items", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorChannel).Line;
			base.SubPlugIns[1].Value = (base.Value as PlotDataCursorChannel).Hint;
			base.SubPlugIns[2].Value = (base.Value as PlotDataCursorChannel).Window;
			base.SubPlugIns[3].Value = (base.Value as PlotDataCursorChannel).StyleMenuItems;
		}
	}
}
