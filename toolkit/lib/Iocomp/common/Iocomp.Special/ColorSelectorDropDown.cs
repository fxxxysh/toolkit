using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Special
{
	[ToolboxItem(false)]
	public class ColorSelectorDropDown : UserControl
	{
		private ListBox WebListBox;

		private ListBox SystemListBox;

		private TabControl TabControl1;

		private TabPage TabPageCustom;

		private TabPage TabPageWeb;

		private TabPage TabPageSystem;

		private Container components;

		private Color m_Color;

		private int m_CustomSelectedIndex;

		private int m_InitialActivePageindex;

		private string[] m_SystemColorNameArray = new string[26]
		{
			"ActiveBorder",
			"ActiveCaption",
			"ActiveCaptionText",
			"AppWorkspace",
			"Control",
			"ControlDark",
			"ControlDarkDark",
			"ControlLight",
			"ControlLightLight",
			"ControlText",
			"Desktop",
			"GrayText",
			"Highlight",
			"HighlightText",
			"HotTrack",
			"InactiveBorder",
			"InactiveCaption",
			"InactiveCaptionText",
			"Info",
			"InfoText",
			"Menu",
			"MenuText",
			"ScrollBar",
			"Window",
			"WindowFrame",
			"WindowText"
		};

		private string[] m_WebColorNameArray = new string[142]
		{
			"Empty",
			"Transparent",
			"Black",
			"DimGray",
			"Gray",
			"DarkGray",
			"Silver",
			"LightGray",
			"Gainsboro",
			"WhiteSmoke",
			"White",
			"RosyBrown",
			"IndianRed",
			"Brown",
			"Firebrick",
			"LightCoral",
			"Maroon",
			"DarkRed",
			"Red",
			"Snow",
			"MistyRose",
			"Salmon",
			"Tomato",
			"DarkSalmon",
			"Coral",
			"OrangeRed",
			"LightSalmon",
			"Sienna",
			"SeaShell",
			"Chocolate",
			"SaddleBrown",
			"SandyBrown",
			"PeachPuff",
			"Peru",
			"Linen",
			"Bisque",
			"DarkOrange",
			"BurlyWood",
			"Tan",
			"AntiqueWhite",
			"NavajoWhite",
			"BlanchedAlmond",
			"PapayaWhip",
			"Moccasin",
			"Orange",
			"Wheat",
			"OldLace",
			"FloralWhite",
			"DarkGoldenrod",
			"Goldenrod",
			"Cornsilk",
			"Gold",
			"Khaki",
			"LemonChiffon",
			"PaleGoldenrod",
			"DarkKhaki",
			"Beige",
			"LightGoldenrodYellow",
			"Olive",
			"Yellow",
			"LightYellow",
			"Ivory",
			"OliveDrab",
			"YellowGreen",
			"DarkOliveGreen",
			"GreenYellow",
			"Chartreuse",
			"LawnGreen",
			"DarkSeaGreen",
			"ForestGreen",
			"LimeGreen",
			"LightGreen",
			"PaleGreen",
			"DarkGreen",
			"Green",
			"Lime",
			"Honeydew",
			"SeaGreen",
			"MediumSeaGreen",
			"SpringGreen",
			"MintCream",
			"MediumSpringGreen",
			"MediumAquamarine",
			"Aquamarine",
			"Turquoise",
			"LightSeaGreen",
			"MediumTurquoise",
			"DarkSlateGray",
			"PaleTurquoise",
			"Teal",
			"DarkCyan",
			"Aqua",
			"Cyan",
			"LightCyan",
			"Azure",
			"DarkTurquoise",
			"CadetBlue",
			"PowderBlue",
			"LightBlue",
			"DeepSkyBlue",
			"SkyBlue",
			"LightSkyBlue",
			"SteelBlue",
			"AliceBlue",
			"DodgerBlue",
			"SlateGray",
			"LightSlateGray",
			"LightSteelBlue",
			"CornflowerBlue",
			"RoyalBlue",
			"MidnightBlue",
			"Lavender",
			"Navy",
			"DarkBlue",
			"MediumBlue",
			"Blue",
			"GhostWhite",
			"SlateBlue",
			"DarkSlateBlue",
			"MediumSlateBlue",
			"MediumPurple",
			"BlueViolet",
			"Indigo",
			"DarkOrchid",
			"DarkViolet",
			"MediumOrchid",
			"Thistle",
			"Plum",
			"Violet",
			"Purple",
			"DarkMagenta",
			"Magenta",
			"Fuchsia",
			"Orchid",
			"MediumVioletRed",
			"DeepPink",
			"HotPink",
			"LavenderBlush",
			"PaleVioletRed",
			"Crimson",
			"Pink",
			"LightPink"
		};

		private Color[] m_CustomColorArray = new Color[64]
		{
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 192, 192),
			Color.FromArgb(255, 224, 192),
			Color.FromArgb(255, 255, 192),
			Color.FromArgb(192, 255, 192),
			Color.FromArgb(192, 255, 255),
			Color.FromArgb(192, 192, 255),
			Color.FromArgb(255, 192, 255),
			Color.FromArgb(224, 244, 244),
			Color.FromArgb(255, 128, 128),
			Color.FromArgb(255, 192, 128),
			Color.FromArgb(255, 255, 128),
			Color.FromArgb(128, 255, 128),
			Color.FromArgb(128, 255, 255),
			Color.FromArgb(128, 128, 255),
			Color.FromArgb(255, 128, 255),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 128, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(128, 128, 128),
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(192, 64, 0),
			Color.FromArgb(192, 192, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 192, 192),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(192, 0, 192),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(128, 0, 0),
			Color.FromArgb(128, 64, 0),
			Color.FromArgb(128, 128, 0),
			Color.FromArgb(0, 128, 0),
			Color.FromArgb(0, 128, 128),
			Color.FromArgb(0, 0, 128),
			Color.FromArgb(128, 0, 128),
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(64, 0, 0),
			Color.FromArgb(128, 64, 64),
			Color.FromArgb(64, 64, 0),
			Color.FromArgb(0, 64, 0),
			Color.FromArgb(0, 64, 64),
			Color.FromArgb(0, 0, 64),
			Color.FromArgb(64, 0, 64),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255)
		};

		public Color Color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				if (this.m_Color != value)
				{
					this.m_Color = value;
					this.UpdateSelections();
				}
			}
		}

		public event EventHandler Changed;

		public ColorSelectorDropDown()
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

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.TabControl1.Location = new Point(1, 1);
			this.TabControl1.Size = new Size(base.Width - 2, base.Height - 2);
		}

		protected void UpdateSelections()
		{
			this.WebListBox.SelectedIndexChanged -= this.WebListBox_SelectedIndexChanged;
			this.SystemListBox.SelectedIndexChanged -= this.SystemListBox_SelectedIndexChanged;
			try
			{
				this.WebListBox.SelectedIndex = -1;
				this.SystemListBox.SelectedIndex = -1;
				this.m_CustomSelectedIndex = -1;
				this.m_InitialActivePageindex = 0;
				int num = 0;
				while (num < this.m_CustomColorArray.Length)
				{
					if (this.m_CustomColorArray[num].ToArgb() != this.Color.ToArgb())
					{
						num++;
						continue;
					}
					this.m_CustomSelectedIndex = num;
					this.m_InitialActivePageindex = 0;
					break;
				}
				Color left;
				if (this.Color.IsSystemColor)
				{
					int num2 = 0;
					while (num2 < this.SystemListBox.Items.Count)
					{
						string name = this.SystemListBox.Items[num2].ToString();
						left = Color.FromName(name);
						if (!(left == this.Color))
						{
							num2++;
							continue;
						}
						this.SystemListBox.SelectedIndex = num2;
						this.m_InitialActivePageindex = 2;
						break;
					}
				}
				int num3 = 0;
				while (true)
				{
					if (num3 < this.WebListBox.Items.Count)
					{
						string name = this.WebListBox.Items[num3].ToString();
						left = Color.FromName(name);
						if (left.ToArgb() != this.Color.ToArgb())
						{
							num3++;
							continue;
						}
						break;
					}
					return;
				}
				this.WebListBox.SelectedIndex = num3;
				this.m_InitialActivePageindex = 1;
			}
			finally
			{
				this.WebListBox.SelectedIndexChanged += this.WebListBox_SelectedIndexChanged;
				this.SystemListBox.SelectedIndexChanged += this.SystemListBox_SelectedIndexChanged;
			}
		}

		private void InitializeComponent()
		{
			this.TabControl1 = new TabControl();
			this.TabPageCustom = new TabPage();
			this.TabPageWeb = new TabPage();
			this.WebListBox = new ListBox();
			this.TabPageSystem = new TabPage();
			this.SystemListBox = new ListBox();
			this.TabControl1.SuspendLayout();
			this.TabPageWeb.SuspendLayout();
			this.TabPageSystem.SuspendLayout();
			base.SuspendLayout();
			this.TabControl1.Controls.Add(this.TabPageCustom);
			this.TabControl1.Controls.Add(this.TabPageWeb);
			this.TabControl1.Controls.Add(this.TabPageSystem);
			this.TabControl1.Location = new Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new Size(180, 200);
			this.TabControl1.TabIndex = 148;
			this.TabControl1.SelectedIndexChanged += this.TabControl1_SelectedIndexChanged;
			this.TabPageCustom.Location = new Point(4, 22);
			this.TabPageCustom.Name = "TabPageCustom";
			this.TabPageCustom.Size = new Size(172, 174);
			this.TabPageCustom.TabIndex = 0;
			this.TabPageCustom.Text = "Custom";
			this.TabPageCustom.Paint += this.TabPageCustom_Paint;
			this.TabPageCustom.MouseDown += this.TabPageCustom_MouseDown;
			this.TabPageWeb.Controls.Add(this.WebListBox);
			this.TabPageWeb.Location = new Point(4, 22);
			this.TabPageWeb.Name = "TabPageWeb";
			this.TabPageWeb.Size = new Size(172, 174);
			this.TabPageWeb.TabIndex = 1;
			this.TabPageWeb.Text = "Web";
			this.TabPageWeb.Visible = false;
			this.WebListBox.BorderStyle = BorderStyle.FixedSingle;
			this.WebListBox.Dock = DockStyle.Fill;
			this.WebListBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.WebListBox.IntegralHeight = false;
			this.WebListBox.ItemHeight = 14;
			this.WebListBox.Location = new Point(0, 0);
			this.WebListBox.Name = "WebListBox";
			this.WebListBox.Size = new Size(172, 174);
			this.WebListBox.TabIndex = 0;
			this.WebListBox.DrawItem += this.WebListBox_DrawItem;
			this.TabPageSystem.Controls.Add(this.SystemListBox);
			this.TabPageSystem.Location = new Point(4, 22);
			this.TabPageSystem.Name = "TabPageSystem";
			this.TabPageSystem.Size = new Size(172, 174);
			this.TabPageSystem.TabIndex = 2;
			this.TabPageSystem.Text = "System";
			this.TabPageSystem.Visible = false;
			this.SystemListBox.BorderStyle = BorderStyle.FixedSingle;
			this.SystemListBox.Dock = DockStyle.Fill;
			this.SystemListBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.SystemListBox.IntegralHeight = false;
			this.SystemListBox.ItemHeight = 14;
			this.SystemListBox.Location = new Point(0, 0);
			this.SystemListBox.Name = "SystemListBox";
			this.SystemListBox.Size = new Size(172, 174);
			this.SystemListBox.TabIndex = 0;
			this.SystemListBox.DrawItem += this.WebListBox_DrawItem;
			this.BackColor = Color.Black;
			base.Controls.Add(this.TabControl1);
			base.Name = "ColorSelectorDropDown";
			base.Size = new Size(205, 226);
			base.Load += this.ColorSelectorDropdown_Load;
			this.TabControl1.ResumeLayout(false);
			this.TabPageWeb.ResumeLayout(false);
			this.TabPageSystem.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void WebListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			string text = ((ListBox)sender).Items[e.Index].ToString();
			Color color = Color.FromName(text);
			if (text == "Empty")
			{
				text = "Empty (Reset)";
			}
			Brush brush = ((e.State & DrawItemState.Selected) != DrawItemState.Selected) ? SystemBrushes.WindowText : SystemBrushes.HighlightText;
			e.DrawBackground();
			Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 21, e.Bounds.Height - 4 - 1);
			Rectangle r = new Rectangle(rect.Right + 2, e.Bounds.Top, e.Bounds.Width - 4 - rect.Width, e.Bounds.Height);
			e.Graphics.FillRectangle(new SolidBrush(color), rect);
			e.Graphics.DrawRectangle(Pens.Black, rect);
			e.Graphics.DrawString(text, this.WebListBox.Font, brush, r);
		}

		private void ColorSelectorDropdown_Load(object sender, EventArgs e)
		{
			this.SystemListBox.Items.Clear();
			this.WebListBox.Items.Clear();
			for (int i = 0; i < this.m_SystemColorNameArray.Length; i++)
			{
				this.SystemListBox.Items.Add(this.m_SystemColorNameArray[i]);
			}
			for (int j = 0; j < this.m_WebColorNameArray.Length; j++)
			{
				this.WebListBox.Items.Add(this.m_WebColorNameArray[j]);
			}
			this.UpdateSelections();
			this.TabControl1.SelectedIndex = this.m_InitialActivePageindex;
		}

		private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.TabControl1.SelectedIndex == 1)
			{
				this.WebListBox.Focus();
			}
			else if (this.TabControl1.SelectedIndex == 2)
			{
				this.SystemListBox.Focus();
			}
		}

		private Rectangle GetCustomRect(int index)
		{
			int num = (int)(index / 8L);
			int num2 = (int)(index % 8L);
			return new Rectangle(3 + num2 * 24, 5 + num * 24, 21, 21);
		}

		private void TabPageCustom_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int num = i * 8 + j;
					Rectangle customRect = this.GetCustomRect(num);
					Brush brush = new SolidBrush(this.m_CustomColorArray[num]);
					e.Graphics.FillRectangle(brush, customRect);
					brush.Dispose();
					ControlPaint.DrawBorder3D(e.Graphics, customRect, Border3DStyle.Sunken);
					if (this.m_CustomSelectedIndex == num)
					{
						customRect.Inflate(1, 2);
						ControlPaint.DrawFocusRectangle(e.Graphics, customRect, Color.White, this.TabPageCustom.BackColor);
					}
				}
			}
		}

		private void TabPageCustom_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 64; i++)
			{
				if (this.GetCustomRect(i).Contains(e.X, e.Y))
				{
					this.Color = this.m_CustomColorArray[i];
					this.TabPageCustom.Invalidate();
					this.OnColorChanged();
				}
			}
		}

		private void WebListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.WebListBox.SelectedIndex != -1)
			{
				string a = this.WebListBox.Items[this.WebListBox.SelectedIndex].ToString();
				if (a == "Empty")
				{
					this.Color = Color.Empty;
				}
				else
				{
					this.Color = Color.FromName(this.WebListBox.Items[this.WebListBox.SelectedIndex].ToString());
				}
				this.OnColorChanged();
			}
		}

		private void SystemListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.SystemListBox.SelectedIndex != -1)
			{
				this.Color = Color.FromName(this.SystemListBox.Items[this.SystemListBox.SelectedIndex].ToString());
				this.OnColorChanged();
			}
		}

		private void OnColorChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, new EventArgs());
			}
		}
	}
}
