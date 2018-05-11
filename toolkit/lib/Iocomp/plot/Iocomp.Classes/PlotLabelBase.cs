using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Label Base.")]
	public abstract class PlotLabelBase : PlotLayoutFill
	{
		private string m_Text;

		private PlotAutoRotation m_TextRotation;

		private int m_ImageIndex;

		private ImageList m_ImageList;

		private bool m_ImageTransparent;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public string[] TextLines
		{
			get
			{
				return this.Text.Split('\n');
			}
			set
			{
				StringBuilder stringBuilder = new StringBuilder(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (i < value.Length - 1)
					{
						stringBuilder.Append(value[i] + "\n");
					}
					else
					{
						stringBuilder.Append(value[i]);
					}
				}
				this.Text = stringBuilder.ToString();
			}
		}

		[Description("Specifies the text for the label.")]
		[RefreshProperties(RefreshProperties.All)]
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (this.Text != value)
				{
					this.m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotAutoRotation TextRotation
		{
			get
			{
				return this.m_TextRotation;
			}
			set
			{
				base.PropertyUpdateDefault("TextRotation", value);
				if (this.TextRotation != value)
				{
					this.m_TextRotation = value;
					base.DoPropertyChange(this, "TextRotation");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public override string TitleText
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageList
		{
			get
			{
				if (this.m_ImageList == null && base.Plot != null)
				{
					return base.Plot.ImageListCommon;
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

		[Description("")]
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
		[Category("Iocomp")]
		public bool ImageTransparent
		{
			get
			{
				return this.m_ImageTransparent;
			}
			set
			{
				base.PropertyUpdateDefault("ImageTransparent", value);
				if (this.ImageTransparent != value)
				{
					this.m_ImageTransparent = value;
					base.DoPropertyChange(this, "ImageTransparent");
				}
			}
		}

		protected TextRotation ActualTextRotation
		{
			get
			{
				if (this.TextRotation == PlotAutoRotation.Auto)
				{
					if (base.DockVertical)
					{
						return Iocomp.Types.TextRotation.X000;
					}
					if (base.DockLeft)
					{
						return Iocomp.Types.TextRotation.X270;
					}
					return Iocomp.Types.TextRotation.X090;
				}
				if (this.TextRotation == PlotAutoRotation.X000)
				{
					return Iocomp.Types.TextRotation.X000;
				}
				if (this.TextRotation == PlotAutoRotation.X090)
				{
					return Iocomp.Types.TextRotation.X090;
				}
				if (this.TextRotation == PlotAutoRotation.X180)
				{
					return Iocomp.Types.TextRotation.X180;
				}
				return Iocomp.Types.TextRotation.X270;
			}
		}

		protected bool TextHorizontal
		{
			get
			{
				if (this.ActualTextRotation != 0)
				{
					return this.ActualTextRotation == Iocomp.Types.TextRotation.X180;
				}
				return true;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextLayout = new TextLayoutFull();
			base.AddSubClass(this.TextLayout);
			this.I_TextLayout = this.TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockSide = AlignmentQuadSide.Top;
			base.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.None;
			this.Text = "Label";
			this.TextRotation = PlotAutoRotation.Auto;
			this.TextLayout.Trimming = StringTrimming.None;
			this.TextLayout.LineLimit = false;
			this.TextLayout.MeasureTrailingSpaces = false;
			this.TextLayout.NoWrap = false;
			this.TextLayout.NoClip = false;
			this.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			this.TextLayout.AlignmentHorizontal.Margin = 0.5;
			this.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.TextLayout.AlignmentVertical.Margin = 0.5;
			this.ImageIndex = -1;
			this.ImageList = null;
			this.ImageTransparent = true;
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextRotation()
		{
			return base.PropertyShouldSerialize("TextRotation");
		}

		private void ResetTextRotation()
		{
			base.PropertyReset("TextRotation");
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeImageIndex()
		{
			return base.PropertyShouldSerialize("ImageIndex");
		}

		private void ResetImageIndex()
		{
			base.PropertyReset("ImageIndex");
		}

		private bool ShouldSerializeImageTransparent()
		{
			return base.PropertyShouldSerialize("ImageTransparent");
		}

		private void ResetImageTransparent()
		{
			base.PropertyReset("ImageTransparent");
		}

		protected Image GetImage()
		{
			if (this.ImageList != null && this.ImageIndex >= 0 && this.ImageIndex < this.ImageList.Images.Count)
			{
				return this.ImageList.Images[this.ImageIndex];
			}
			return null;
		}
	}
}
