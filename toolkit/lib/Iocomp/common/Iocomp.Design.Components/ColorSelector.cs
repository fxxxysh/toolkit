using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Components
{
	[ToolboxItem(false)]
	public class ColorSelector : UserControl
	{
		private ListBox WebListBox;

		private ListBox SystemListBox;

		private TabControl TabControl1;

		private TabPage TabPageWeb;

		private TabPage TabPageSystem;

		private Container components;

		private Color m_Color;

		private int m_CalculatedActivePageindex;

		private ColorSelectorGrid ColorSelectorGrid;

		private static string[] m_SystemColorNameArray = new string[26]
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

		private TabPage TabPageCustom;

		private static string[] m_WebColorNameArray = new string[142]
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
					this.ColorSelectorGrid.Color = this.m_Color;
					this.UpdateSelections();
					this.TabControl1.SelectedIndex = this.m_CalculatedActivePageindex;
					this.OnColorChanged();
				}
			}
		}

		public event EventHandler ColorChanged;

		public event EventHandler ColorChangedDoubleClick;

		public ColorSelector()
		{
			this.InitializeComponent();
			this.ColorSelectorGrid = new ColorSelectorGrid();
			base.Controls.Add(this.ColorSelectorGrid);
			this.ColorSelectorGrid.Parent = this.TabPageCustom;
			this.ColorSelectorGrid.Dock = DockStyle.Fill;
			this.ColorSelectorGrid.ColorChanged += this.ColorSelectorGrid_ColorChanged;
			this.ColorSelectorGrid.ColorChangedDoubleClick += this.ColorSelectorGrid_ColorChangedDoubleClick;
			this.SystemListBox.Items.Clear();
			this.WebListBox.Items.Clear();
			for (int i = 0; i < ColorSelector.m_SystemColorNameArray.Length; i++)
			{
				this.SystemListBox.Items.Add(ColorSelector.m_SystemColorNameArray[i]);
			}
			for (int j = 0; j < ColorSelector.m_WebColorNameArray.Length; j++)
			{
				this.WebListBox.Items.Add(ColorSelector.m_WebColorNameArray[j]);
			}
			this.UpdateSelections();
			this.TabControl1.SelectedIndex = this.m_CalculatedActivePageindex;
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
				this.m_CalculatedActivePageindex = 0;
				if (this.Color.IsSystemColor)
				{
					int num = 0;
					while (num < this.SystemListBox.Items.Count)
					{
						string name = this.SystemListBox.Items[num].ToString();
						Color left = Color.FromName(name);
						if (!(left == this.Color))
						{
							num++;
							continue;
						}
						this.SystemListBox.SelectedIndex = num;
						this.m_CalculatedActivePageindex = 2;
						break;
					}
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < this.WebListBox.Items.Count)
					{
						string name = this.WebListBox.Items[num2].ToString();
						Color left = (!(name == "Empty")) ? Color.FromName(name) : Color.Empty;
						if (left == this.Color)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				this.WebListBox.SelectedIndex = num2;
				this.m_CalculatedActivePageindex = 1;
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
			this.WebListBox.DoubleClick += this.ColorDoubleClick;
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
			this.SystemListBox.DoubleClick += this.ColorDoubleClick;
			this.SystemListBox.DrawItem += this.WebListBox_DrawItem;
			this.BackColor = Color.Black;
			base.Controls.Add(this.TabControl1);
			base.Name = "ColorSelector";
			base.Size = new Size(206, 226);
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
			}
		}

		private void SystemListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.SystemListBox.SelectedIndex != -1)
			{
				this.Color = Color.FromName(this.SystemListBox.Items[this.SystemListBox.SelectedIndex].ToString());
			}
		}

		private void OnColorChanged()
		{
			if (this.ColorChanged != null)
			{
				this.ColorChanged(this, EventArgs.Empty);
			}
		}

		private void OnColorChangedDoubleClick()
		{
			if (this.ColorChangedDoubleClick != null)
			{
				this.ColorChangedDoubleClick(this, EventArgs.Empty);
			}
		}

		private void ColorSelectorGrid_ColorChanged(object sender, EventArgs e)
		{
			this.Color = this.ColorSelectorGrid.Color;
		}

		private void ColorSelectorGrid_ColorChangedDoubleClick(object sender, EventArgs e)
		{
			this.OnColorChangedDoubleClick();
		}

		private void ColorDoubleClick(object sender, EventArgs e)
		{
			if (sender == this.WebListBox)
			{
				if (this.WebListBox.SelectedIndex != -1)
				{
					this.OnColorChangedDoubleClick();
				}
			}
			else if (sender == this.SystemListBox)
			{
				if (this.SystemListBox.SelectedIndex != -1)
				{
					this.OnColorChangedDoubleClick();
				}
			}
			else if (sender == this.ColorSelectorGrid && this.SystemListBox.SelectedIndex != -1)
			{
				this.OnColorChangedDoubleClick();
			}
		}
	}
}
