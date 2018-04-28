using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Multiple Base.")]
	public abstract class PlotDataCursorMultipleBase : PlotDataCursorBase
	{
		private PlotDataCursorMultipleStyle m_Style;

		private PlotDataCursorMultipleStyleMenuItems m_StyleMenuItems;

		private PlotDataCursorDisplay m_Display;

		private double m_Pointer1ValueXY;

		private double m_Pointer2ValueXY;

		private double m_Pointer1ValueX;

		private double m_Pointer2ValueX;

		private double m_Pointer1ValueY;

		private double m_Pointer2ValueY;

		private double m_Pointer1DeltaX;

		private double m_Pointer2DeltaX;

		private double m_Pointer1DeltaY;

		private double m_Pointer2DeltaY;

		private double m_Pointer1InverseDeltaX;

		private double m_Pointer2InverseDeltaX;

		private double m_Pointer1InverseDeltaY;

		private double m_Pointer2InverseDeltaY;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotDataCursorMultipleStyleMenuItems StyleMenuItems
		{
			get
			{
				return this.m_StyleMenuItems;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Pointer1Position
		{
			get
			{
				return base.Pointer1.Position;
			}
			set
			{
				base.PropertyUpdateDefault("Pointer1Position", value);
				if (this.Pointer1Position != value)
				{
					base.Pointer1.Position = value;
					base.DoPropertyChange(this, "Pointer1Position");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Pointer2Position
		{
			get
			{
				return base.Pointer2.Position;
			}
			set
			{
				base.PropertyUpdateDefault("Pointer2Position", value);
				if (this.Pointer2Position != value)
				{
					base.Pointer2.Position = value;
					base.DoPropertyChange(this, "Pointer2Position");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDataCursorMultipleStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (this.Style != value)
				{
					if (this.Style == PlotDataCursorMultipleStyle.ValueXY)
					{
						this.m_Pointer1ValueXY = this.Pointer1Position;
						this.m_Pointer2ValueXY = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.ValueX)
					{
						this.m_Pointer1ValueX = this.Pointer1Position;
						this.m_Pointer2ValueX = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.ValueY)
					{
						this.m_Pointer1ValueY = this.Pointer1Position;
						this.m_Pointer2ValueY = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.DeltaX)
					{
						this.m_Pointer1DeltaX = this.Pointer1Position;
						this.m_Pointer2DeltaX = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.DeltaY)
					{
						this.m_Pointer1DeltaY = this.Pointer1Position;
						this.m_Pointer2DeltaY = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
					{
						this.m_Pointer1InverseDeltaX = this.Pointer1Position;
						this.m_Pointer2InverseDeltaX = this.Pointer2Position;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.InverseDeltaY)
					{
						this.m_Pointer1InverseDeltaY = this.Pointer1Position;
						this.m_Pointer2InverseDeltaY = this.Pointer2Position;
					}
					this.m_Style = value;
					if (this.Style == PlotDataCursorMultipleStyle.ValueXY)
					{
						this.Pointer1Position = this.m_Pointer1ValueXY;
						this.Pointer2Position = this.m_Pointer2ValueXY;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.ValueX)
					{
						this.Pointer1Position = this.m_Pointer1ValueX;
						this.Pointer2Position = this.m_Pointer2ValueX;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.ValueY)
					{
						this.Pointer1Position = this.m_Pointer1ValueY;
						this.Pointer2Position = this.m_Pointer2ValueY;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.DeltaX)
					{
						this.Pointer1Position = this.m_Pointer1DeltaX;
						this.Pointer2Position = this.m_Pointer2DeltaX;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.DeltaY)
					{
						this.Pointer1Position = this.m_Pointer1DeltaY;
						this.Pointer2Position = this.m_Pointer2DeltaY;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
					{
						this.Pointer1Position = this.m_Pointer1InverseDeltaX;
						this.Pointer2Position = this.m_Pointer2InverseDeltaX;
					}
					else if (this.Style == PlotDataCursorMultipleStyle.InverseDeltaY)
					{
						this.Pointer1Position = this.m_Pointer1InverseDeltaY;
						this.Pointer2Position = this.m_Pointer2InverseDeltaY;
					}
					base.DoPropertyChange(this, "Style");
				}
				this.SetupPointers();
			}
		}

		protected PlotDataCursorDisplay Display => this.m_Display;

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Display = new PlotDataCursorDisplay();
			this.m_StyleMenuItems = new PlotDataCursorMultipleStyleMenuItems();
			base.AddSubClass(this.StyleMenuItems);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Pointer1Position = 0.5;
			this.Pointer2Position = 0.5;
			this.m_Pointer1ValueXY = 0.5;
			this.m_Pointer2ValueXY = 0.5;
			this.m_Pointer1ValueX = 0.5;
			this.m_Pointer2ValueX = 0.5;
			this.m_Pointer1ValueY = 0.5;
			this.m_Pointer2ValueY = 0.5;
			this.m_Pointer1DeltaX = 0.45;
			this.m_Pointer2DeltaX = 0.55;
			this.m_Pointer1DeltaY = 0.45;
			this.m_Pointer2DeltaY = 0.55;
			this.m_Pointer1InverseDeltaX = 0.45;
			this.m_Pointer2InverseDeltaX = 0.55;
			this.m_Pointer1InverseDeltaY = 0.45;
			this.m_Pointer2InverseDeltaY = 0.55;
			this.Style = PlotDataCursorMultipleStyle.ValueXY;
		}

		private bool ShouldSerializeStyleMenuItems()
		{
			return ((ISubClassBase)this.StyleMenuItems).ShouldSerialize();
		}

		private void ResetStyleMenuItems()
		{
			((ISubClassBase)this.StyleMenuItems).ResetToDefault();
		}

		private bool ShouldSerializePointer1Position()
		{
			return base.PropertyShouldSerialize("Pointer1Position");
		}

		private void ResetPointer1Position()
		{
			base.PropertyReset("Pointer1Position");
		}

		private bool ShouldSerializePointer2Position()
		{
			return base.PropertyShouldSerialize("Pointer2Position");
		}

		private void ResetPointer2Position()
		{
			base.PropertyReset("Pointer2Position");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Style";
			menu.MenuItems.Add(menuItem);
			if (this.StyleMenuItems.ShowValueXY)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionValueXY, this.MenuItemStyleXY_Click, this.Style == PlotDataCursorMultipleStyle.ValueXY);
			}
			if (this.StyleMenuItems.ShowValueX)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionValueX, this.MenuItemStyleX_Click, this.Style == PlotDataCursorMultipleStyle.ValueX);
			}
			if (this.StyleMenuItems.ShowValueY)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionValueY, this.MenuItemStyleY_Click, this.Style == PlotDataCursorMultipleStyle.ValueY);
			}
			if (this.StyleMenuItems.ShowDeltaX)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionDeltaX, this.MenuItemStyleDeltaX_Click, this.Style == PlotDataCursorMultipleStyle.DeltaX);
			}
			if (this.StyleMenuItems.ShowDeltaY)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionDeltaY, this.MenuItemStyleDeltaY_Click, this.Style == PlotDataCursorMultipleStyle.DeltaY);
			}
			if (this.StyleMenuItems.ShowInverseDeltaX)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionInverseDeltaX, this.MenuItemStyleInverseDeltaX_Click, this.Style == PlotDataCursorMultipleStyle.InverseDeltaX);
			}
			if (this.StyleMenuItems.ShowInverseDeltaY)
			{
				base.AddMenuItem(menuItem, this.StyleMenuItems.CaptionInverseDeltaY, this.MenuItemStyleInverseDeltaY_Click, this.Style == PlotDataCursorMultipleStyle.InverseDeltaY);
			}
		}

		private void MenuItemStyleXY_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.ValueXY;
		}

		private void MenuItemStyleX_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.ValueX;
		}

		private void MenuItemStyleY_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.ValueY;
		}

		private void MenuItemStyleDeltaX_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.DeltaX;
		}

		private void MenuItemStyleDeltaY_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.DeltaY;
		}

		private void MenuItemStyleInverseDeltaX_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.InverseDeltaX;
		}

		private void MenuItemStyleInverseDeltaY_Click(object sender, EventArgs e)
		{
			this.Style = PlotDataCursorMultipleStyle.InverseDeltaY;
		}
	}
}
