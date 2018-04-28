using Iocomp.Delegates;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Print Adapter.")]
	public class PlotPrintAdapter : SubClassBase
	{
		private PlotBase m_PlotBase;

		private PrintDocument m_PrintDocument;

		private PageSetupDialog m_PrintPageSetupDialog;

		private PrintPreviewDialog m_PrintPreviewDialog;

		private PrintDialog m_PrintDialog;

		private bool m_ShowPrintDialog;

		private PlotPrintSizingStyle m_SizingStyle;

		private string m_DocumentName;

		private PrintOrientation m_Orientation;

		private int m_PageIndex;

		private PlotBase PlotBase => this.m_PlotBase;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PrintDocument PrintDocument
		{
			get
			{
				return this.m_PrintDocument;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PrintDialog PrintDialog
		{
			get
			{
				return this.m_PrintDialog;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DocumentName
		{
			get
			{
				return this.m_DocumentName;
			}
			set
			{
				base.PropertyUpdateDefault("DocumentName", value);
				if (this.DocumentName != value)
				{
					this.m_DocumentName = value;
					if (this.PlotBase != null && !this.PlotBase.Designing)
					{
						this.m_PrintDocument.DocumentName = value;
					}
					base.DoPropertyChange(this, "DocumentName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PrintOrientation Orientation
		{
			get
			{
				return this.m_Orientation;
			}
			set
			{
				base.PropertyUpdateDefault("Orientation", value);
				if (this.Orientation != value)
				{
					this.m_Orientation = value;
					if (this.PlotBase != null && !this.PlotBase.Designing)
					{
						if (this.Orientation == PrintOrientation.Landscape)
						{
							this.m_PrintDocument.DefaultPageSettings.Landscape = true;
						}
						else
						{
							this.m_PrintDocument.DefaultPageSettings.Landscape = false;
						}
					}
					base.DoPropertyChange(this, "Orientation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowPrintDialog
		{
			get
			{
				return this.m_ShowPrintDialog;
			}
			set
			{
				base.PropertyUpdateDefault("ShowPrintDialog", value);
				if (this.ShowPrintDialog != value)
				{
					this.m_ShowPrintDialog = value;
					base.DoPropertyChange(this, "ShowPrintDialog");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotPrintSizingStyle SizingStyle
		{
			get
			{
				return this.m_SizingStyle;
			}
			set
			{
				base.PropertyUpdateDefault("SizingStyle", value);
				if (this.SizingStyle != value)
				{
					this.m_SizingStyle = value;
					base.DoPropertyChange(this, "SizingStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginLeft
		{
			get
			{
				return (double)this.m_PrintDocument.DefaultPageSettings.Margins.Left / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginLeft", value);
				if (this.MarginLeft != value)
				{
					this.m_PrintDocument.DefaultPageSettings.Margins.Left = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginLeft");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginRight
		{
			get
			{
				return (double)this.m_PrintDocument.DefaultPageSettings.Margins.Right / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginRight", value);
				if (this.MarginRight != value)
				{
					this.m_PrintDocument.DefaultPageSettings.Margins.Right = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginRight");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double MarginTop
		{
			get
			{
				return (double)this.m_PrintDocument.DefaultPageSettings.Margins.Top / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginTop", value);
				if (this.MarginTop != value)
				{
					this.m_PrintDocument.DefaultPageSettings.Margins.Top = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginTop");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double MarginBottom
		{
			get
			{
				return (double)this.m_PrintDocument.DefaultPageSettings.Margins.Bottom / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginBottom", value);
				if (this.MarginBottom != value)
				{
					this.m_PrintDocument.DefaultPageSettings.Margins.Bottom = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginBottom");
				}
			}
		}

		public event Iocomp.Delegates.PrintEventHandler PrintBefore;

		public event Iocomp.Delegates.PrintEventHandler PrintAfter;

		public event Iocomp.Delegates.PrintPageEventHandler PrintPage;

		protected override string GetPlugInTitle()
		{
			return "Plot Print Adapter";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotPrintAdapterEditorPlugIn";
		}

		public PlotPrintAdapter()
		{
			base.DoCreate();
		}

		public PlotPrintAdapter(PlotBase value)
		{
			this.m_PlotBase = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_PrintDocument = new PrintDocument();
			this.m_PrintDocument.PrintPage += this.PrintPageHandler;
			this.m_PrintDocument.BeginPrint += this.m_PrintDocument_BeginPrint;
			this.m_PrintDocument.EndPrint += this.m_PrintDocument_EndPrint;
			this.m_PrintPreviewDialog = new PrintPreviewDialog();
			this.m_PrintPreviewDialog.Document = this.m_PrintDocument;
			this.m_PrintPageSetupDialog = new PageSetupDialog();
			this.m_PrintPageSetupDialog.Document = this.m_PrintDocument;
			this.m_PrintDialog = new PrintDialog();
			this.m_PrintDialog.Document = this.m_PrintDocument;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ShowPrintDialog = true;
			this.SizingStyle = PlotPrintSizingStyle.Proportional;
			this.DocumentName = "Document";
			this.Orientation = PrintOrientation.Portrait;
			this.MarginLeft = 1.0;
			this.MarginRight = 1.0;
			this.MarginTop = 1.0;
			this.MarginBottom = 1.0;
		}

		private bool ShouldSerializeDocumentName()
		{
			return base.PropertyShouldSerialize("DocumentName");
		}

		private void ResetDocumentName()
		{
			base.PropertyReset("DocumentName");
		}

		private bool ShouldSerializeOrientation()
		{
			return base.PropertyShouldSerialize("Orientation");
		}

		private void ResetOrientation()
		{
			base.PropertyReset("Orientation");
		}

		private bool ShouldSerializeShowPrintDialog()
		{
			return base.PropertyShouldSerialize("ShowPrintDialog");
		}

		private void ResetShowPrintDialog()
		{
			base.PropertyReset("ShowPrintDialog");
		}

		private bool ShouldSerializeSizingStyle()
		{
			return base.PropertyShouldSerialize("SizingStyle");
		}

		private void ResetSizingStyle()
		{
			base.PropertyReset("SizingStyle");
		}

		private bool ShouldSerializeMarginLeft()
		{
			return base.PropertyShouldSerialize("MarginLeft");
		}

		private void ResetMarginLeft()
		{
			base.PropertyReset("MarginLeft");
		}

		private bool ShouldSerializeMarginRight()
		{
			return base.PropertyShouldSerialize("MarginRight");
		}

		private void ResetMarginRight()
		{
			base.PropertyReset("MarginRight");
		}

		private bool ShouldSerializeMarginTop()
		{
			return base.PropertyShouldSerialize("MarginTop");
		}

		private void ResetMarginTop()
		{
			base.PropertyReset("MarginTop");
		}

		private bool ShouldSerializeMarginBottom()
		{
			return base.PropertyShouldSerialize("MarginBottom");
		}

		private void ResetMarginBottom()
		{
			base.PropertyReset("MarginBottom");
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public DialogResult Print()
		{
			try
			{
				if (!this.m_PrintDialog.PrinterSettings.IsValid)
				{
					MessageBox.Show("Printer Not Valid or Installed", "Print Error");
					return DialogResult.Cancel;
				}
				if (this.ShowPrintDialog)
				{
					if (this.m_PrintDialog.ShowDialog() == DialogResult.OK)
					{
						this.m_PrintDocument.Print();
						return DialogResult.OK;
					}
					return DialogResult.Cancel;
				}
				this.m_PrintDocument.Print();
			}
			catch
			{
				MessageBox.Show("Printing Error", "Print Error");
			}
			return DialogResult.OK;
		}

		[Description("")]
		public void PrintPreview()
		{
			if (!this.m_PrintDialog.PrinterSettings.IsValid)
			{
				MessageBox.Show("Printer Not Valid or Installed", "Print Preview Error");
			}
			else
			{
				if (PrinterSettings.InstalledPrinters.Count == 0)
				{
					this.m_PrintDialog.ShowDialog();
				}
				if (PrinterSettings.InstalledPrinters.Count != 0)
				{
					this.m_PrintPreviewDialog.ShowDialog();
				}
			}
		}

		[Description("")]
		public void PrintPageSetup()
		{
			if (!this.m_PrintDialog.PrinterSettings.IsValid)
			{
				MessageBox.Show("Printer Not Valid or Installed", "Print Page Setup Error");
			}
			else
			{
				this.m_PrintPageSetupDialog.ShowDialog();
			}
		}

		private void PrintPageHandler(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			PrintPageEventArgs printPageEventArgs = new PrintPageEventArgs(this.m_PrintDocument, this.m_PageIndex);
			if (this.PrintPage != null)
			{
				this.PrintPage(this, printPageEventArgs);
			}
			e.HasMorePages = printPageEventArgs.HasMorePages;
			Metafile metaFile = this.PlotBase.GetMetaFile();
			GraphicsUnit srcUnit = GraphicsUnit.Pixel;
			Rectangle srcRect = Rectangle.Truncate(metaFile.GetBounds(ref srcUnit));
			Rectangle destRect = default(Rectangle);
			if (this.SizingStyle == PlotPrintSizingStyle.Stretch)
			{
				destRect = e.MarginBounds;
			}
			else if (this.SizingStyle == PlotPrintSizingStyle.None)
			{
				destRect = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, srcRect.Width, srcRect.Height);
			}
			else
			{
				double num = Math.Min((double)e.MarginBounds.Width / (double)srcRect.Width, (double)e.MarginBounds.Height / (double)srcRect.Height);
				destRect = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, (int)((double)srcRect.Width * num), (int)((double)srcRect.Height * num));
			}
			e.Graphics.DrawImage(metaFile, destRect, srcRect, srcUnit);
			this.m_PageIndex++;
		}

		private void m_PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.PrintBefore != null)
			{
				this.PrintBefore(this, new PrintEventArgs(this.m_PrintDocument));
			}
			this.m_PageIndex = 1;
		}

		private void m_PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.PrintAfter != null)
			{
				this.PrintAfter(this, new PrintEventArgs(this.m_PrintDocument));
			}
		}
	}
}
