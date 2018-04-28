using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Components
{
	[Serializable]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class ColorDialog : Component
	{
		private Color m_Color;

		private Form m_Form;

		public Color Color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		public DialogResult ShowDialog()
		{
			return this.ShowDialog(null, this.m_Color);
		}

		public DialogResult ShowDialog(Color color)
		{
			return this.ShowDialog(null, color);
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			return this.ShowDialog(owner, this.m_Color);
		}

		public DialogResult ShowDialog(IWin32Window owner, Color color)
		{
			this.m_Form = new Form();
			try
			{
				this.m_Form.FormBorderStyle = FormBorderStyle.FixedDialog;
				this.m_Form.MinimizeBox = false;
				this.m_Form.MaximizeBox = false;
				this.m_Form.Text = "Color";
				this.m_Form.Icon = null;
				this.m_Form.StartPosition = FormStartPosition.CenterScreen;
				this.m_Form.ShowInTaskbar = false;
				ColorSelector colorSelector = new ColorSelector();
				colorSelector.Color = color;
				colorSelector.ColorChangedDoubleClick += this.AColorSelector_ColorChangedDoubleClick;
				colorSelector.Location = new Point(0, 0);
				Button button = new Button();
				button.Text = "OK";
				button.Width = 70;
				Button button2 = new Button();
				button2.Text = "Cancel";
				button2.Width = 70;
				this.m_Form.Controls.Add(colorSelector);
				this.m_Form.Controls.Add(button);
				this.m_Form.Controls.Add(button2);
				this.m_Form.AcceptButton = button;
				this.m_Form.CancelButton = button2;
				button.Click += this.OkButton_Click;
				button2.Click += this.CancelButton_Click;
				this.m_Form.ClientSize = new Size(colorSelector.Width, colorSelector.Height + 2 * button.Height);
				button.Location = new Point(10, colorSelector.Height + button.Height / 2);
				button2.Location = new Point(button.Right + 10, colorSelector.Height + button.Height / 2);
				DialogResult dialogResult = this.m_Form.ShowDialog(owner);
				if (dialogResult == DialogResult.OK)
				{
					this.m_Color = colorSelector.Color;
				}
				return dialogResult;
			}
			finally
			{
				this.m_Form.Dispose();
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			this.m_Form.DialogResult = DialogResult.OK;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.m_Form.DialogResult = DialogResult.Cancel;
		}

		private void AColorSelector_ColorChangedDoubleClick(object sender, EventArgs e)
		{
			this.m_Color = (sender as ColorSelector).Color;
			this.m_Form.DialogResult = DialogResult.OK;
		}
	}
}
