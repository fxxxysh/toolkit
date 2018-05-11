using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationImage : PlotAnnotationBase
	{
		private int m_ImageIndex;

		private bool m_FixedSize;

		private ImageList m_ImageList;

		private Image m_Image;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageList
		{
			get
			{
				if (this.m_ImageList == null && base.Plot != null)
				{
					return base.Plot.ImageListAnnotations;
				}
				return this.m_ImageList;
			}
			set
			{
				base.PropertyUpdateDefault("ImageList", value);
				if (!GPFunctions.Equals(this.ImageList, value))
				{
					this.m_ImageList = value;
					base.DoPropertyChange(this, "ImageList");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public bool FixedSize
		{
			get
			{
				return this.m_FixedSize;
			}
			set
			{
				base.PropertyUpdateDefault("FixedSize", value);
				if (this.FixedSize != value)
				{
					this.m_FixedSize = value;
					base.DoPropertyChange(this, "FixedSize");
				}
				if (this.m_FixedSize)
				{
					base.GrabHandle1.Enabled = false;
					base.GrabHandle5.Enabled = false;
				}
				else
				{
					base.GrabHandle1.Enabled = true;
					base.GrabHandle5.Enabled = true;
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int ImageIndex
		{
			get
			{
				return this.m_ImageIndex;
			}
			set
			{
				base.PropertyUpdateDefault("ImageIndex", value);
				if (this.ImageIndex != value)
				{
					this.m_ImageIndex = value;
					base.DoPropertyChange(this, "ImageIndex");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Image Image
		{
			get
			{
				return this.m_Image;
			}
			set
			{
				if (this.Image != value)
				{
					this.m_Image = value;
					base.DoPropertyChange(this, "Image");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationImageEditorPlugIn";
		}

		public PlotAnnotationImage()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Image";
			this.ImageIndex = 0;
			this.ImageList = null;
			this.FixedSize = true;
			base.GrabHandle0.Enabled = true;
			base.GrabHandle1.Enabled = true;
			base.GrabHandle2.Enabled = true;
			base.GrabHandle3.Enabled = true;
			base.GrabHandle4.Enabled = true;
			base.GrabHandle5.Enabled = true;
			base.GrabHandle6.Enabled = true;
			base.GrabHandle7.Enabled = true;
		}

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		private bool ShouldSerializeImageIndex()
		{
			return base.PropertyShouldSerialize("ImageIndex");
		}

		private void ResetImageIndex()
		{
			base.PropertyReset("ImageIndex");
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Image image;
			if (this.Image != null)
			{
				image = this.Image;
				goto IL_0054;
			}
			if (this.ImageList != null && this.ImageIndex >= 0 && this.ImageIndex < this.ImageList.Images.Count)
			{
				image = this.ImageList.Images[this.ImageIndex];
				goto IL_0054;
			}
			return;
			IL_0054:
			int num;
			int num2;
			if (!this.FixedSize)
			{
				if (!base.XYSwapped)
				{
					num = base.WidthPixels;
					num2 = base.HeightPixels;
				}
				else
				{
					num = base.HeightPixels;
					num2 = base.WidthPixels;
				}
			}
			else
			{
				num2 = image.Height;
				num = image.Width;
			}
			Point point = base.XYSwapped ? new Point(base.YPixels, base.XPixels) : new Point(base.XPixels, base.YPixels);
			Rectangle rectangle = iRectangle.FromLTWH(point.X - num / 2, point.Y - num2 / 2, num + 1, num2 + 1);
			if (!base.BoundsClip.IntersectsWith(rectangle))
			{
				base.ClickRegion = null;
			}
			else
			{
				p.Graphics.DrawImageTransparent(image, rectangle);
				base.ClickRegion = this.ToClickRegion(rectangle);
				base.UpdateGrabHandles(rectangle);
			}
		}
	}
}
