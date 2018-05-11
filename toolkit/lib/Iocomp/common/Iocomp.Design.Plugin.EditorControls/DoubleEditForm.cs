using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class DoubleEditForm : Form
	{
		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private Container components;

		private System.Windows.Forms.NumericUpDown MilisecondsUpDown;

		private System.Windows.Forms.NumericUpDown SecondsUpDown;

		private System.Windows.Forms.NumericUpDown MinutesUpDown;

		private System.Windows.Forms.NumericUpDown HoursUpDown;

		private FocusLabel focusLabel5;

		private System.Windows.Forms.NumericUpDown DaysUpDown;

		private Button button2;

		private Button button3;

		private Button ZeroAllButton;

		private double m_Value;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
				if (this.m_Value > DateTime.MaxValue.ToOADate())
				{
					this.m_Value = DateTime.MaxValue.ToOADate();
				}
				if (this.m_Value < DateTime.MinValue.ToOADate())
				{
					this.m_Value = DateTime.MinValue.ToOADate();
				}
				this.MilisecondsUpDown.ValueChanged -= this.UpDown_ValueChanged;
				this.SecondsUpDown.ValueChanged -= this.UpDown_ValueChanged;
				this.MinutesUpDown.ValueChanged -= this.UpDown_ValueChanged;
				this.HoursUpDown.ValueChanged -= this.UpDown_ValueChanged;
				this.DaysUpDown.ValueChanged -= this.UpDown_ValueChanged;
				DateTime dateTime = DateTime.FromOADate(this.m_Value);
				this.MilisecondsUpDown.Value = dateTime.Millisecond;
				this.SecondsUpDown.Value = dateTime.Second;
				this.MinutesUpDown.Value = dateTime.Minute;
				this.HoursUpDown.Value = dateTime.Hour;
				this.DaysUpDown.Value = (int)this.m_Value;
				this.MilisecondsUpDown.ValueChanged += this.UpDown_ValueChanged;
				this.SecondsUpDown.ValueChanged += this.UpDown_ValueChanged;
				this.MinutesUpDown.ValueChanged += this.UpDown_ValueChanged;
				this.HoursUpDown.ValueChanged += this.UpDown_ValueChanged;
				this.DaysUpDown.ValueChanged += this.UpDown_ValueChanged;
			}
		}

		public DoubleEditForm()
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

		private void InitializeComponent()
		{
			this.MilisecondsUpDown = new System.Windows.Forms.NumericUpDown();
			this.focusLabel1 = new FocusLabel();
			this.focusLabel2 = new FocusLabel();
			this.SecondsUpDown = new System.Windows.Forms.NumericUpDown();
			this.focusLabel3 = new FocusLabel();
			this.MinutesUpDown = new System.Windows.Forms.NumericUpDown();
			this.focusLabel4 = new FocusLabel();
			this.HoursUpDown = new System.Windows.Forms.NumericUpDown();
			this.ZeroAllButton = new Button();
			this.focusLabel5 = new FocusLabel();
			this.DaysUpDown = new System.Windows.Forms.NumericUpDown();
			this.button2 = new Button();
			this.button3 = new Button();
			base.SuspendLayout();
			this.MilisecondsUpDown.Location = new Point(72, 48);
			this.MilisecondsUpDown.Maximum = new decimal(new int[4]
			{
				999,
				0,
				0,
				0
			});
			this.MilisecondsUpDown.Name = "MilisecondsUpDown";
			this.MilisecondsUpDown.Size = new Size(64, 20);
			this.MilisecondsUpDown.TabIndex = 0;
			this.MilisecondsUpDown.Leave += this.UpDownLeave;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.MilisecondsUpDown;
			this.focusLabel1.Location = new Point(9, 51);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(63, 14);
			this.focusLabel1.Text = "Miliseconds";
			this.focusLabel1.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.SecondsUpDown;
			this.focusLabel2.Location = new Point(24, 75);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(48, 14);
			this.focusLabel2.Text = "Seconds";
			this.focusLabel2.LoadingEnd();
			this.SecondsUpDown.Location = new Point(72, 72);
			this.SecondsUpDown.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			this.SecondsUpDown.Name = "SecondsUpDown";
			this.SecondsUpDown.Size = new Size(64, 20);
			this.SecondsUpDown.TabIndex = 3;
			this.SecondsUpDown.Leave += this.UpDownLeave;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.MinutesUpDown;
			this.focusLabel3.Location = new Point(28, 99);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(44, 14);
			this.focusLabel3.Text = "Minutes";
			this.focusLabel3.LoadingEnd();
			this.MinutesUpDown.Location = new Point(72, 96);
			this.MinutesUpDown.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			this.MinutesUpDown.Name = "MinutesUpDown";
			this.MinutesUpDown.Size = new Size(64, 20);
			this.MinutesUpDown.TabIndex = 6;
			this.MinutesUpDown.Leave += this.UpDownLeave;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.HoursUpDown;
			this.focusLabel4.Location = new Point(37, 123);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(35, 14);
			this.focusLabel4.Text = "Hours";
			this.focusLabel4.LoadingEnd();
			this.HoursUpDown.Location = new Point(72, 120);
			this.HoursUpDown.Maximum = new decimal(new int[4]
			{
				23,
				0,
				0,
				0
			});
			this.HoursUpDown.Name = "HoursUpDown";
			this.HoursUpDown.Size = new Size(64, 20);
			this.HoursUpDown.TabIndex = 9;
			this.HoursUpDown.Leave += this.UpDownLeave;
			this.ZeroAllButton.Location = new Point(72, 16);
			this.ZeroAllButton.Name = "ZeroAllButton";
			this.ZeroAllButton.Size = new Size(64, 23);
			this.ZeroAllButton.TabIndex = 11;
			this.ZeroAllButton.Text = "Zero All";
			this.ZeroAllButton.Click += this.ZeroAllButton_Click;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.DaysUpDown;
			this.focusLabel5.Location = new Point(41, 147);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(31, 14);
			this.focusLabel5.Text = "Days";
			this.focusLabel5.LoadingEnd();
			this.DaysUpDown.Location = new Point(72, 144);
			this.DaysUpDown.Maximum = new decimal(new int[4]
			{
				-1304428544,
				434162106,
				542,
				0
			});
			this.DaysUpDown.Name = "DaysUpDown";
			this.DaysUpDown.Size = new Size(64, 20);
			this.DaysUpDown.TabIndex = 13;
			this.DaysUpDown.Leave += this.UpDownLeave;
			this.button2.DialogResult = DialogResult.OK;
			this.button2.Location = new Point(16, 184);
			this.button2.Name = "button2";
			this.button2.TabIndex = 18;
			this.button2.Text = "OK";
			this.button3.DialogResult = DialogResult.Cancel;
			this.button3.Location = new Point(104, 184);
			this.button3.Name = "button3";
			this.button3.TabIndex = 19;
			this.button3.Text = "Cancel";
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(194, 224);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.DaysUpDown);
			base.Controls.Add(this.ZeroAllButton);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.HoursUpDown);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.MinutesUpDown);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.SecondsUpDown);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.MilisecondsUpDown);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Name = "DoubleEditForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Time Span";
			base.ResumeLayout(false);
		}

		private void UpDown_ValueChanged(object sender, EventArgs e)
		{
			double num = new DateTime(2000, 1, 1, (int)this.HoursUpDown.Value, (int)this.MinutesUpDown.Value, (int)this.SecondsUpDown.Value, (int)this.MilisecondsUpDown.Value).ToOADate();
			num -= (double)(int)num;
			this.m_Value = num + (double)(int)this.DaysUpDown.Value;
		}

		private void ZeroAllButton_Click(object sender, EventArgs e)
		{
			this.MilisecondsUpDown.ValueChanged -= this.UpDown_ValueChanged;
			this.SecondsUpDown.ValueChanged -= this.UpDown_ValueChanged;
			this.MinutesUpDown.ValueChanged -= this.UpDown_ValueChanged;
			this.HoursUpDown.ValueChanged -= this.UpDown_ValueChanged;
			this.DaysUpDown.ValueChanged -= this.UpDown_ValueChanged;
			this.MilisecondsUpDown.Value = 0m;
			this.SecondsUpDown.Value = 0m;
			this.MinutesUpDown.Value = 0m;
			this.HoursUpDown.Value = 0m;
			this.DaysUpDown.Value = 0m;
			this.m_Value = 0.0;
			this.MilisecondsUpDown.ValueChanged += this.UpDown_ValueChanged;
			this.SecondsUpDown.ValueChanged += this.UpDown_ValueChanged;
			this.MinutesUpDown.ValueChanged += this.UpDown_ValueChanged;
			this.HoursUpDown.ValueChanged += this.UpDown_ValueChanged;
			this.DaysUpDown.ValueChanged += this.UpDown_ValueChanged;
		}

		private void UpDownLeave(object sender, EventArgs e)
		{
			this.UpDown_ValueChanged(null, null);
		}
	}
}
