using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[Description("Double Edit Button")]
	[DesignerCategory("code")]
	[DefaultEvent("")]
	[Designer(typeof(DoubleEditButtonDesigner))]
	public class DoubleEditButton : Button
	{
		private EditBox m_EditBox;

		private bool m_RecursionBlock;

		protected override Size DefaultSize => new Size(24, 23);

		public EditBox EditBox
		{
			get
			{
				return this.m_EditBox;
			}
			set
			{
				if (this.m_EditBox != value)
				{
					if (this.m_EditBox != null)
					{
						this.m_EditBox.LocationChanged -= this.m_EditBox_LocationChanged;
						this.m_EditBox.SizeChanged -= this.m_EditBox_LocationChanged;
						this.m_EditBox.EnabledChanged -= this.m_EditBox_EnabledChanged;
					}
					this.m_EditBox = value;
					if (this.m_EditBox != null)
					{
						this.m_EditBox.LocationChanged += this.m_EditBox_LocationChanged;
						this.m_EditBox.SizeChanged += this.m_EditBox_LocationChanged;
						this.m_EditBox.EnabledChanged += this.m_EditBox_EnabledChanged;
						this.Align();
					}
				}
			}
		}

		[DefaultValue("...")]
		[ParenthesizePropertyName(true)]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		public DoubleEditButton()
		{
			this.Text = "...";
		}

		private void m_EditBox_LocationChanged(object sender, EventArgs e)
		{
			this.Align();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (!this.m_RecursionBlock)
			{
				this.m_RecursionBlock = true;
				try
				{
					base.OnSizeChanged(e);
					this.Align();
				}
				finally
				{
					this.m_RecursionBlock = false;
				}
			}
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			if (!this.m_RecursionBlock)
			{
				this.m_RecursionBlock = true;
				try
				{
					base.OnLocationChanged(e);
					this.Align();
				}
				finally
				{
					this.m_RecursionBlock = false;
				}
			}
		}

		public void Align()
		{
			if (this.EditBox != null)
			{
				int x = this.EditBox.Location.X + this.EditBox.Width;
				int y = this.EditBox.Location.Y + this.EditBox.Height / 2 - base.Height / 2 + -1;
				base.Location = new Point(x, y);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			DoubleEditForm doubleEditForm = new DoubleEditForm();
			try
			{
				doubleEditForm.Value = this.m_EditBox.AsDouble;
				if (doubleEditForm.ShowDialog() == DialogResult.OK)
				{
					this.m_EditBox.AsDouble = doubleEditForm.Value;
					this.m_EditBox.ForceUpdate();
				}
			}
			finally
			{
				doubleEditForm.Dispose();
			}
		}

		private void m_EditBox_EnabledChanged(object sender, EventArgs e)
		{
			base.Enabled = this.m_EditBox.Enabled;
		}
	}
}
