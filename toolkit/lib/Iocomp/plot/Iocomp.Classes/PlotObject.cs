using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot objects.")]
	[TypeConverter(typeof(CollectionItemConverter))]
	public abstract class PlotObject : SubClassBase, IPlotObject, IPlotDraw
	{
		private string m_Name;

		private string m_TitleText;

		private int m_Layer;

		private bool m_UserCanEdit;

		private bool m_CanFocus;

		private bool m_ContextMenuEnabled;

		private Plot m_Plot;

		private Rectangle m_BoundsClip;

		private string m_NameShort;

		private bool m_CanDraw;

		bool IPlotDraw.CanDraw
		{
			get
			{
				return this.m_CanDraw;
			}
		}

		Plot IPlotObject.Plot
		{
			get
			{
				return this.Plot;
			}
			set
			{
				this.Plot = value;
			}
		}

		protected Plot Plot
		{
			get
			{
				return this.m_Plot;
			}
			set
			{
				this.m_Plot = value;
			}
		}

		protected bool CanDraw
		{
			get
			{
				return this.m_CanDraw;
			}
			set
			{
				this.m_CanDraw = value;
			}
		}

		protected string NameShort
		{
			get
			{
				return this.m_NameShort;
			}
			set
			{
				this.m_NameShort = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public Rectangle BoundsClip
		{
			get
			{
				return this.m_BoundsClip;
			}
			set
			{
				if (this.m_BoundsClip != value)
				{
					this.m_BoundsClip = value;
					this.OnBoundsClipChanged(this.m_BoundsClip);
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ContextMenuEnabled
		{
			get
			{
				return this.m_ContextMenuEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ContextMenuEnabled", value);
				if (this.ContextMenuEnabled != value)
				{
					this.m_ContextMenuEnabled = value;
					base.DoPropertyChange(this, "ContextMenuEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Name
		{
			get
			{
				if (this.m_Name == null)
				{
					this.m_Name = Const.EmptyString;
				}
				return this.m_Name;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("Name", value);
				if (this.Name != value)
				{
					string name = this.m_Name;
					this.m_Name = value;
					base.DoPropertyChange(this, "Name");
					if (base.Collection is IPlotObjectCollectionBase)
					{
						(base.Collection as IPlotObjectCollectionBase).HandleObjectRenamed(this, name);
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual string TitleText
		{
			get
			{
				if (this.m_TitleText == null)
				{
					this.m_TitleText = Const.EmptyString;
				}
				return this.m_TitleText;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("TitleText", value);
				if (this.TitleText != value)
				{
					this.m_TitleText = value;
					base.DoPropertyChange(this, "TitleText");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Layer
		{
			get
			{
				return this.m_Layer;
			}
			set
			{
				base.PropertyUpdateDefault("Layer", value);
				if (this.Layer != value)
				{
					this.m_Layer = value;
					base.DoPropertyChange(this, "Layer");
				}
			}
		}

		[Description("")]
		[Browsable(false)]
		public double LayerWithSubLevel
		{
			get
			{
				if (this is PlotDataView)
				{
					return (double)this.Layer + 0.0;
				}
				if (this is PlotAxis)
				{
					return (double)this.Layer + 0.01;
				}
				if (this is PlotLimitBase)
				{
					return (double)this.Layer + 0.02;
				}
				if (this is PlotChannelBase)
				{
					return (double)this.Layer + 0.03;
				}
				if (this is PlotAnnotationBase)
				{
					return (double)this.Layer + 0.04;
				}
				return (double)this.Layer + 0.0;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool UserCanEdit
		{
			get
			{
				return this.m_UserCanEdit;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanEdit", value);
				if (this.UserCanEdit != value)
				{
					this.m_UserCanEdit = value;
					base.DoPropertyChange(this, "UserCanEdit");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool CanFocus
		{
			get
			{
				return this.m_CanFocus;
			}
			set
			{
				base.PropertyUpdateDefault("CanFocus", value);
				if (this.CanFocus != value)
				{
					this.m_CanFocus = value;
					base.DoPropertyChange(this, "CanFocus");
				}
			}
		}

		protected override bool CanFocusInternal => this.m_CanFocus;

		public new bool Focused => base.Focused;

		public string Description
		{
			get
			{
				if (this.TitleText != null && this.TitleText.Length != 0)
				{
					return this.TitleText + "-" + this.NameShort;
				}
				if (this.Name != null && this.Name.Length != 0)
				{
					return this.Name + "-" + this.NameShort;
				}
				return "<No Name>-" + this.NameShort;
			}
		}

		public string DisplayDescription
		{
			get
			{
				if (this.TitleText != null && this.TitleText.Length != 0)
				{
					return this.TitleText;
				}
				if (this.Name != null && this.Name.Length != 0)
				{
					return this.Name;
				}
				return "<No Name>";
			}
		}

		[Description("")]
		[Browsable(false)]
		public event BoundsChangeEventHandler BoundsClipChanged;

		void IPlotDraw.DrawSetup(PaintArgs p)
		{
			this.DrawSetup(p);
		}

		void IPlotDraw.DrawCalculations(PaintArgs p)
		{
			this.DrawCalculations(p);
		}

		void IPlotDraw.Draw(PaintArgs p)
		{
			this.DrawInternal(p);
		}

		void IPlotDraw.DrawBackgroundLayer1(PaintArgs p)
		{
			this.DrawBackgroundLayer1Internal(p);
		}

		void IPlotDraw.DrawBackgroundLayer2(PaintArgs p)
		{
			this.DrawBackgroundLayer2Internal(p);
		}

		void IPlotDraw.DrawForegroundLayer1(PaintArgs p)
		{
			this.DrawForegroundLayer1Internal(p);
		}

		void IPlotDraw.DrawForegroundLayer2(PaintArgs p)
		{
			this.DrawForegroundLayer2Internal(p);
		}

		void IPlotDraw.DrawFocusRectangles(PaintArgs p)
		{
			this.DrawFocusRectanglesInternal(p);
		}

		void IPlotDraw.UpdateCanDraw(PaintArgs p)
		{
			this.UpdateCanDrawInternal(p);
		}

		void IPlotDraw.UpdateBoundsClip(PaintArgs p)
		{
			this.UpdateBoundsClipInternal(p);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Enabled = true;
			this.Layer = 100;
			this.UserCanEdit = true;
			this.CanFocus = true;
			this.ContextMenuEnabled = true;
			this.Name = "";
			this.TitleText = "";
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeContextMenuEnabled()
		{
			return base.PropertyShouldSerialize("ContextMenuEnabled");
		}

		private void ResetContextMenuEnabled()
		{
			base.PropertyReset("ContextMenuEnabled");
		}

		private bool ShouldSerializeName()
		{
			return base.PropertyShouldSerialize("Name");
		}

		private void ResetName()
		{
			base.PropertyReset("Name");
		}

		public virtual void ObjectRenamed(PlotObject value, string oldName)
		{
		}

		public virtual void ObjectRemoved(PlotObject value)
		{
		}

		public virtual void ObjectAdded(PlotObject value)
		{
		}

		private bool ShouldSerializeTitleText()
		{
			return base.PropertyShouldSerialize("TitleText");
		}

		private void ResetTitleText()
		{
			base.PropertyReset("TitleText");
		}

		private bool ShouldSerializeLayer()
		{
			return base.PropertyShouldSerialize("Layer");
		}

		private void ResetLayer()
		{
			base.PropertyReset("Layer");
		}

		private bool ShouldSerializeUserCanEdit()
		{
			return base.PropertyShouldSerialize("UserCanEdit");
		}

		private void ResetUserCanEdit()
		{
			base.PropertyReset("UserCanEdit");
		}

		private bool ShouldSerializeCanFocus()
		{
			return base.PropertyShouldSerialize("CanFocus");
		}

		private void ResetCanFocus()
		{
			base.PropertyReset("CanFocus");
		}

		public override string ToString()
		{
			return this.Description;
		}

		protected virtual void OnBoundsClipChanged(Rectangle r)
		{
			if (this.BoundsClipChanged != null)
			{
				this.BoundsClipChanged(this, new BoundsEventArgs(r));
			}
		}

		private void DrawInternal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.Draw(p);
			}
		}

		private void DrawBackgroundLayer1Internal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.DrawBackgroundLayer1(p);
			}
		}

		private void DrawBackgroundLayer2Internal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.DrawBackgroundLayer2(p);
			}
		}

		private void DrawForegroundLayer1Internal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.DrawForegroundLayer1(p);
			}
		}

		private void DrawForegroundLayer2Internal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.DrawForegroundLayer2(p);
			}
		}

		private void DrawFocusRectanglesInternal(PaintArgs p)
		{
			if (this.CanDraw)
			{
				this.DrawFocusRectangles(p);
			}
		}

		private void UpdateCanDrawInternal(PaintArgs p)
		{
			this.CanDraw = true;
			this.UpdateCanDraw(p);
		}

		private void UpdateBoundsClipInternal(PaintArgs p)
		{
			this.UpdateBoundsClip(p);
		}

		protected virtual void DrawSetup(PaintArgs p)
		{
		}

		protected virtual void DrawCalculations(PaintArgs p)
		{
		}

		protected abstract void Draw(PaintArgs p);

		protected virtual void DrawBackgroundLayer1(PaintArgs p)
		{
		}

		protected virtual void DrawBackgroundLayer2(PaintArgs p)
		{
		}

		protected virtual void DrawForegroundLayer1(PaintArgs p)
		{
		}

		protected virtual void DrawForegroundLayer2(PaintArgs p)
		{
		}

		protected virtual void DrawFocusRectangles(PaintArgs p)
		{
		}

		protected virtual void UpdateBoundsClip(PaintArgs p)
		{
		}

		protected virtual void UpdateCanDraw(PaintArgs p)
		{
			if (!this.Visible)
			{
				this.CanDraw = false;
			}
		}

		protected virtual void PopulateContextMenu(ContextMenu menu)
		{
			if (this.UserCanEdit)
			{
				MenuItem item = new MenuItem("Edit", this.MenuItemEdit_Click);
				menu.MenuItems.Add(item);
			}
		}

		protected void AddMenuItem(Menu menu, string text, EventHandler eventhandler, bool isChecked)
		{
			MenuItem menuItem = new MenuItem();
			menuItem.Text = text;
			menuItem.Click += eventhandler;
			menuItem.Checked = isChecked;
			menu.MenuItems.Add(menuItem);
		}

		private void MenuItemEdit_Click(object sender, EventArgs e)
		{
			base.ShowEditorCustom(false, true);
		}

		protected override void InternalOnMouseRight(MouseEventArgs e)
		{
			base.Focus();
			if (this.ContextMenuEnabled)
			{
				ContextMenu contextMenu = new ContextMenu();
				this.PopulateContextMenu(contextMenu);
				contextMenu.Show(this.Plot, new Point(e.X + 10, e.Y + 10));
			}
		}
	}
}
