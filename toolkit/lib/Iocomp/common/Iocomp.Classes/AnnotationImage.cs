using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationImage : AnnotationBase, IAnnotationImage
	{
		private ImageListStyle m_ImageListStyle;

		private int m_ImageIndex;

		private ImageList m_ImageListSmall;

		private ImageList m_ImageListLarge;

		private ImageList m_ImageListCustom;

		private bool m_FixedSize;

		private ImageList ImageListActive
		{
			get
			{
				if (this.ImageListStyle == ImageListStyle.ImageListLarge)
				{
					return this.m_ImageListLarge;
				}
				if (this.ImageListStyle == ImageListStyle.ImageListSmall)
				{
					return this.m_ImageListSmall;
				}
				return this.m_ImageListCustom;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public ImageListStyle ImageListStyle
		{
			get
			{
				return this.m_ImageListStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListStyle", value);
				if (this.ImageListStyle != value)
				{
					this.m_ImageListStyle = value;
					base.DoPropertyChange(this, "ImageListStyle");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public ImageList ImageListSmall
		{
			get
			{
				return this.m_ImageListSmall;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public ImageList ImageListLarge
		{
			get
			{
				return this.m_ImageListLarge;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public ImageList ImageListCustom
		{
			get
			{
				return this.m_ImageListCustom;
			}
			set
			{
				this.m_ImageListCustom = value;
			}
		}

		[Description("Specifies the MotorBase style.")]
		[Category("Iocomp")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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
					base.GrabHandle0.Enabled = false;
					base.GrabHandle1.Enabled = false;
					base.GrabHandle2.Enabled = false;
					base.GrabHandle3.Enabled = false;
					base.GrabHandle4.Enabled = false;
					base.GrabHandle5.Enabled = false;
					base.GrabHandle6.Enabled = false;
					base.GrabHandle7.Enabled = false;
				}
				else
				{
					base.GrabHandle0.Enabled = true;
					base.GrabHandle1.Enabled = true;
					base.GrabHandle2.Enabled = true;
					base.GrabHandle3.Enabled = true;
					base.GrabHandle4.Enabled = true;
					base.GrabHandle5.Enabled = true;
					base.GrabHandle6.Enabled = true;
					base.GrabHandle7.Enabled = true;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationImageEditorPlugIn";
		}

		void IAnnotationImage.SetImageListSmall(ImageList value)
		{
			this.m_ImageListSmall = value;
		}

		void IAnnotationImage.SetImageListLarge(ImageList value)
		{
			this.m_ImageListLarge = value;
		}

		public AnnotationImage()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ImageListStyle = ImageListStyle.ImageListLarge;
			this.ImageIndex = -1;
			this.FixedSize = false;
		}

		private bool ShouldSerializeImageListStyle()
		{
			return base.PropertyShouldSerialize("ImageListStyle");
		}

		private void ResetImageListStyle()
		{
			base.PropertyReset("ImageListStyle");
		}

		private bool ShouldSerializeImageIndex()
		{
			return base.PropertyShouldSerialize("ImageIndex");
		}

		private void ResetImageIndex()
		{
			base.PropertyReset("ImageIndex");
		}

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		protected override void DrawCustom(PaintArgs p)
		{
			float num = (float)this.Scale.ConvertHeightUnitsToPixels(this.Height);
			float num2 = (float)this.Scale.ConvertWidthUnitsToPixels(this.Width);
			if (this.ImageListActive != null && this.ImageIndex > -1 && this.ImageIndex < this.ImageListActive.Images.Count)
			{
				Image image = this.ImageListActive.Images[this.ImageIndex];
				float num3;
				float num4;
				if (!this.FixedSize)
				{
					num3 = num / (float)image.Height * (float)image.Height;
					num4 = num2 / (float)image.Width * (float)image.Width;
				}
				else
				{
					num3 = (float)image.Height;
					num4 = (float)image.Width;
				}
				Rectangle r = new Rectangle((int)((float)this.Scale.ConvertUnitsToPixelsX(this.X) - num4 / 2f), (int)((float)this.Scale.ConvertUnitsToPixelsY(this.Y) - num3 / 2f), (int)num4 + 1, (int)num3 + 1);
				base.ClickRegion = this.ToClickRegion(r);
				base.UpdateGrabHandles(r);
				p.Graphics.DrawImageTransparent(image, r);
			}
		}

		public override string ToString()
		{
			return "Annotation Image";
		}
	}
}
