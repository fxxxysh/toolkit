using Iocomp.Classes;
using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Iocomp.Instrumentation.Plotting
{
	[Description("PlotBase")]
	[DesignerCategory("code")]
	public abstract class PlotBase : ControlBase
	{
		private PlotLabelBaseCollection m_Labels;

		private PlotAnnotationBaseCollection m_Annotations;

		private PlotLegendBaseCollection m_Legends;

		private PlotTableBaseCollection m_Tables;

		private PlotBrush m_Background;

		protected IPlotBrush I_Background;

		private PlotFileDeliminator m_FileDeliminator;

		private bool m_ContextMenusEnabled;

		private ImageList m_ImageListAnnotations;

		private ImageList m_ImageListCommon;

		private PlotCopyToClipboardFormat m_CopyToClipboardFormat;

		private PlotXValueTextDateTimeFormat m_XValueTextDateTimeFormat;

		private string m_DefaultSaveImagePath;

		private PlotPrintAdapter m_PrintAdapter;

		protected UIInputCollection m_UICollection;

		protected PlotObjectCollection m_ObjectList;

		protected PlotSorterLayer m_SorterLayer;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Plot Print Adapter")]
		[Browsable(true)]
		public PlotPrintAdapter PrintAdapter
		{
			get
			{
				return this.m_PrintAdapter;
			}
		}

		[Description("Annotation ImageList")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageListAnnotations
		{
			get
			{
				return this.m_ImageListAnnotations;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListAnnotations", value);
				if (this.ImageListAnnotations != value)
				{
					this.m_ImageListAnnotations = value;
					base.DoPropertyChange(this, "ImageListAnnotations");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Common ImageList")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public ImageList ImageListCommon
		{
			get
			{
				return this.m_ImageListCommon;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListCommon", value);
				if (this.ImageListCommon != value)
				{
					this.m_ImageListCommon = value;
					base.DoPropertyChange(this, "ImageListCommon");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Background
		{
			get
			{
				return this.m_Background;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotLabelBaseCollection Labels
		{
			get
			{
				return this.m_Labels;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotAnnotationBaseCollection Annotations
		{
			get
			{
				return this.m_Annotations;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotLegendBaseCollection Legends
		{
			get
			{
				return this.m_Legends;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotTableBaseCollection Tables
		{
			get
			{
				return this.m_Tables;
			}
		}

		[Browsable(false)]
		public string FileDeliminatorCharacter
		{
			get
			{
				if (this.FileDeliminator == PlotFileDeliminator.Comma)
				{
					return ",";
				}
				return "\t";
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Annotation ImageList")]
		public PlotFileDeliminator FileDeliminator
		{
			get
			{
				return this.m_FileDeliminator;
			}
			set
			{
				base.PropertyUpdateDefault("FileDeliminator", value);
				if (this.FileDeliminator != value)
				{
					this.m_FileDeliminator = value;
					base.DoPropertyChange(this, "FileDeliminator");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Copy To Clipboard Format")]
		public PlotCopyToClipboardFormat CopyToClipboardFormat
		{
			get
			{
				return this.m_CopyToClipboardFormat;
			}
			set
			{
				base.PropertyUpdateDefault("CopyToClipboardFormat", value);
				if (this.CopyToClipboardFormat != value)
				{
					this.m_CopyToClipboardFormat = value;
					base.DoPropertyChange(this, "CopyToClipboardFormat");
				}
			}
		}

		[Description("X-Value Text Date-Time Format")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotXValueTextDateTimeFormat XValueTextDateTimeFormat
		{
			get
			{
				return this.m_XValueTextDateTimeFormat;
			}
			set
			{
				base.PropertyUpdateDefault("XValueTextDateTimeFormat", value);
				if (this.XValueTextDateTimeFormat != value)
				{
					this.m_XValueTextDateTimeFormat = value;
					base.DoPropertyChange(this, "XValueTextDateTimeFormat");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the initial default path for the save button on the toolbar.")]
		public string DefaultSaveImagePath
		{
			get
			{
				if (this.m_DefaultSaveImagePath == null)
				{
					return string.Empty;
				}
				return this.m_DefaultSaveImagePath;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				base.PropertyUpdateDefault("DefaultSaveImagePath", value);
				if (this.DefaultSaveImagePath != value)
				{
					this.m_DefaultSaveImagePath = value;
					base.DoPropertyChange(this, "DefaultSaveImagePath");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Common ImageList")]
		public Color DefaultGridLineColor
		{
			get
			{
				return base.CustomColor1;
			}
			set
			{
				base.PropertyUpdateDefault("DefaultGridLineColor", value);
				base.CustomColor1 = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Common ImageList")]
		public bool ContextMenusEnabled
		{
			get
			{
				return this.m_ContextMenusEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ContextMenusEnabled", value);
				if (this.ContextMenusEnabled != value)
				{
					this.m_ContextMenusEnabled = value;
					base.DoPropertyChange(this, "ContextMenusEnabled");
				}
			}
		}

		public event AddRemoveObjectEventHandler PlotObjectAdded;

		public event AddRemoveObjectEventHandler PlotObjectRemoved;

		public event PlotObjectRenamedEventHandler PlotObjectRenamed;

		protected override string GetPlugInTitle()
		{
			return "Plot";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotEditorPlugIn";
		}

		protected virtual void OnPlotObjectAdded(ObjectEventArgs e)
		{
			if (this.PlotObjectAdded != null)
			{
				this.PlotObjectAdded(this, new ObjectEventArgs(e.Object));
			}
		}

		protected virtual void OnPlotObjectRemoved(ObjectEventArgs e)
		{
			if (this.PlotObjectRemoved != null)
			{
				this.PlotObjectRemoved(this, new ObjectEventArgs(e.Object));
			}
		}

		protected virtual void OnPlotObjectRenamed(PlotObjectRenamedEventArgs e)
		{
			if (this.PlotObjectRenamed != null)
			{
				this.PlotObjectRenamed(this, e);
			}
		}

		protected override void CreateObjects()
		{
			this.m_UICollection = new UIInputCollection(this);
			this.m_UICollection.NoHitDefaultType = typeof(PlotDataView);
			this.m_PrintAdapter = new PlotPrintAdapter(this);
			base.AddSubClass(this.PrintAdapter);
			this.m_Background = new PlotBrush();
			base.AddSubClass(this.Background);
			this.I_Background = this.Background;
			this.m_Annotations = new PlotAnnotationBaseCollection(this);
			this.m_Labels = new PlotLabelBaseCollection(this);
			this.m_Legends = new PlotLegendBaseCollection(this);
			this.m_Tables = new PlotTableBaseCollection(this);
			this.m_ObjectList = new PlotObjectCollection();
			this.m_SorterLayer = new PlotSorterLayer();
		}

		protected override void SetComponentDefaults()
		{
			base.SetComponentDefaults();
			this.Labels.Reset();
			this.Legends.Reset();
			this.Tables.Reset();
			this.Annotations.Reset();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ImageListAnnotations = null;
			this.ImageListCommon = null;
			this.CopyToClipboardFormat = PlotCopyToClipboardFormat.Picture;
			this.XValueTextDateTimeFormat = PlotXValueTextDateTimeFormat.Double;
			this.DefaultSaveImagePath = "";
			base.ForeColor = Color.White;
			base.BackColor = Color.Black;
			base.Border.Style = BorderStyleControl.Sunken;
			base.Border.Margin = 5;
			this.ContextMenusEnabled = true;
			this.DefaultGridLineColor = Color.Green;
			this.FileDeliminator = PlotFileDeliminator.Tab;
			this.Background.Visible = false;
			this.Background.Style = PlotBrushStyle.GradientVertical;
			this.Background.SolidColor = Color.Empty;
			this.Background.GradientStartColor = Color.Blue;
			this.Background.GradientStopColor = Color.Aqua;
			this.Background.HatchForeColor = Color.Empty;
			this.Background.HatchBackColor = Color.Empty;
		}

		private bool ShouldSerializePrintAdapter()
		{
			return ((ISubClassBase)this.PrintAdapter).ShouldSerialize();
		}

		private void ResetPrintAdapter()
		{
			((ISubClassBase)this.PrintAdapter).ResetToDefault();
		}

		private bool ShouldSerializeImageListAnnotations()
		{
			return base.PropertyShouldSerialize("ImageListAnnotations");
		}

		private void ResetImageListAnnotations()
		{
			base.PropertyReset("ImageListAnnotations");
		}

		private bool ShouldSerializeImageListCommon()
		{
			return base.PropertyShouldSerialize("ImageListCommon");
		}

		private void ResetImageListCommon()
		{
			base.PropertyReset("ImageListCommon");
		}

		private bool ShouldSerializeBackground()
		{
			return ((ISubClassBase)this.Background).ShouldSerialize();
		}

		private void ResetBackground()
		{
			((ISubClassBase)this.Background).ResetToDefault();
		}

		private bool ShouldSerializeLabels()
		{
			return this.Labels.Count != 0;
		}

		private bool ShouldSerializeAnnotations()
		{
			return this.Annotations.Count != 0;
		}

		private bool ShouldSerializeLegends()
		{
			return this.Legends.Count != 0;
		}

		private bool ShouldSerializeTables()
		{
			return this.Tables.Count != 0;
		}

		private bool ShouldSerializeFileDeliminator()
		{
			return base.PropertyShouldSerialize("FileDeliminator");
		}

		private void ResetFileDeliminator()
		{
			base.PropertyReset("FileDeliminator");
		}

		private bool ShouldSerializeCopyToClipboardFormat()
		{
			return base.PropertyShouldSerialize("CopyToClipboardFormat");
		}

		private void ResetCopyToClipboardFormat()
		{
			base.PropertyReset("CopyToClipboardFormat");
		}

		private bool ShouldSerializeXValueTextDateTimeFormat()
		{
			return base.PropertyShouldSerialize("XValueTextDateTimeFormat");
		}

		private void ResetXValueTextDateTimeFormat()
		{
			base.PropertyReset("XValueTextDateTimeFormat");
		}

		private bool ShouldSerializeDefaultSaveImagePath()
		{
			return base.PropertyShouldSerialize("DefaultSaveImagePath");
		}

		private void ResetDefaultSaveImagePath()
		{
			base.PropertyReset("DefaultSaveImagePath");
		}

		private bool ShouldSerializeDefaultGridLineColor()
		{
			return base.PropertyShouldSerialize("DefaultGridLineColor");
		}

		private void ResetDefaultGridLineColor()
		{
			base.PropertyReset("DefaultGridLineColor");
		}

		private bool ShouldSerializeContextMenusEnabled()
		{
			return base.PropertyShouldSerialize("ContextMenusEnabled");
		}

		private void ResetContextMenusEnabled()
		{
			base.PropertyReset("ContextMenusEnabled");
		}

		public static bool GetNamesMatch(string s1, string s2)
		{
			if (s1 == null)
			{
				return false;
			}
			if (s2 == null)
			{
				return false;
			}
			if (s1 == Const.EmptyString)
			{
				return false;
			}
			if (s2 == Const.EmptyString)
			{
				return false;
			}
			if (s1.Trim().ToUpper() == s2.Trim().ToUpper())
			{
				return true;
			}
			return false;
		}

		public void ClearSubFocus()
		{
			this.m_UICollection.ClearFocus();
		}

		public void ReCalcLayout()
		{
			Bitmap image = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(image);
			base.PaintAll(new PaintEventArgs(graphics, new Rectangle(0, 0, base.Width, base.Height)));
			graphics.Dispose();
		}

		public Metafile GetMetaFile()
		{
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics = base.CreateGraphics();
			IntPtr hdc = graphics.GetHdc();
			Metafile metafile = new Metafile(hdc, rectangle, MetafileFrameUnit.Pixel);
			graphics.ReleaseHdc(hdc);
			graphics.Dispose();
			graphics = Graphics.FromImage(metafile);
			Brush brush = new SolidBrush(base.BackColor);
			graphics.FillRectangle(brush, rectangle);
			brush.Dispose();
			base.PaintAll(new PaintEventArgs(graphics, rectangle));
			graphics.Dispose();
			return metafile;
		}
	}
}
