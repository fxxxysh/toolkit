using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class EvaluationFormSWTB : Form
	{
		private Label label2;

		private Label label3;

		private PictureBox LogoPictureBox;

		private Button OkButton;

		private Label label1;

		private Label label4;

		private Label label5;

		private LinkLabel HomeLinkLabel;

		private LinkLabel SupportLinkLabel;

		private Label label6;

		private LinkLabel SalesLinkLabel;

		private ImageList imageList1;

		private Label label7;

		private Label label8;

		private IContainer components;

		public EvaluationFormSWTB()
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
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(EvaluationFormSWTB));
			this.label2 = new Label();
			this.label3 = new Label();
			this.HomeLinkLabel = new LinkLabel();
			this.LogoPictureBox = new PictureBox();
			this.OkButton = new Button();
			this.label1 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.SupportLinkLabel = new LinkLabel();
			this.label6 = new Label();
			this.SalesLinkLabel = new LinkLabel();
			this.imageList1 = new ImageList(this.components);
			this.label7 = new Label();
			this.label8 = new Label();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 124);
			this.label2.Name = "label2";
			this.label2.Size = new Size(230, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Copyright © 1998-2014 Iocomp Software Inc.";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 84);
			this.label3.Name = "label3";
			this.label3.Size = new Size(194, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Iocomp Components Evaluation Copy";
			this.HomeLinkLabel.AutoSize = true;
			this.HomeLinkLabel.Location = new Point(264, 8);
			this.HomeLinkLabel.Name = "HomeLinkLabel";
			this.HomeLinkLabel.Size = new Size(128, 16);
			this.HomeLinkLabel.TabIndex = 3;
			this.HomeLinkLabel.TabStop = true;
			this.HomeLinkLabel.Text = " instrumentationopc.com";
			this.HomeLinkLabel.LinkClicked += this.WebsiteLabel_LinkClicked;
			this.LogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
			this.LogoPictureBox.Image = (Image)resourceManager.GetObject("LogoPictureBox.Image");
			this.LogoPictureBox.Location = new Point(8, 15);
			this.LogoPictureBox.Name = "LogoPictureBox";
			this.LogoPictureBox.Size = new Size(200, 49);
			this.LogoPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			this.LogoPictureBox.TabIndex = 6;
			this.LogoPictureBox.TabStop = false;
			this.OkButton.BackColor = SystemColors.Control;
			this.OkButton.Location = new Point(343, 160);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 7;
			this.OkButton.Text = "&OK";
			this.OkButton.Click += this.OkButton_Click;
			this.label1.Location = new Point(8, 160);
			this.label1.Name = "label1";
			this.label1.Size = new Size(304, 72);
			this.label1.TabIndex = 8;
			this.label1.Text = "Warning: This computer program is protected by copright law and international treaties. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties, and will be prosecuted to the maximum extent possible under law.\r\n";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(224, 8);
			this.label4.Name = "label4";
			this.label4.Size = new Size(44, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Home : ";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(216, 32);
			this.label5.Name = "label5";
			this.label5.Size = new Size(50, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "Support :";
			this.label5.TextAlign = ContentAlignment.MiddleRight;
			this.SupportLinkLabel.AutoSize = true;
			this.SupportLinkLabel.Location = new Point(264, 32);
			this.SupportLinkLabel.Name = "SupportLinkLabel";
			this.SupportLinkLabel.Size = new Size(149, 16);
			this.SupportLinkLabel.TabIndex = 12;
			this.SupportLinkLabel.TabStop = true;
			this.SupportLinkLabel.Text = "support.softwaretoolbox.com";
			this.SupportLinkLabel.LinkClicked += this.SupportLinkLabel_LinkClicked;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(224, 56);
			this.label6.Name = "label6";
			this.label6.Size = new Size(39, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Sales :";
			this.label6.TextAlign = ContentAlignment.MiddleRight;
			this.SalesLinkLabel.AutoSize = true;
			this.SalesLinkLabel.Location = new Point(264, 56);
			this.SalesLinkLabel.Name = "SalesLinkLabel";
			this.SalesLinkLabel.Size = new Size(169, 16);
			this.SalesLinkLabel.TabIndex = 14;
			this.SalesLinkLabel.TabStop = true;
			this.SalesLinkLabel.Text = "instrumentationopc.com/ordering";
			this.SalesLinkLabel.LinkClicked += this.SalesLinkLabel_LinkClicked;
			this.imageList1.ImageSize = new Size(197, 67);
			this.imageList1.ImageStream = (ImageListStreamer)resourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = Color.White;
			this.label7.BorderStyle = BorderStyle.Fixed3D;
			this.label7.Location = new Point(8, 144);
			this.label7.Name = "label7";
			this.label7.Size = new Size(408, 3);
			this.label7.TabIndex = 15;
			this.label7.Text = "label7";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 100);
			this.label8.Name = "label8";
			this.label8.Size = new Size(356, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "This software is a demo version and is not licensed for production use.";
			this.AutoScaleBaseSize = new Size(5, 13);
			this.BackColor = Color.DarkSeaGreen;
			base.ClientSize = new Size(426, 240);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.SalesLinkLabel);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.SupportLinkLabel);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.OkButton);
			base.Controls.Add(this.LogoPictureBox);
			base.Controls.Add(this.HomeLinkLabel);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.Fixed3D;
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "EvaluationFormSWTB";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Iocomp Evaluation";
			base.TopMost = true;
			base.Closing += this.EvaluationForm_Closing;
			base.ResumeLayout(false);
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void EvaluationForm_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}

		private void WebsiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.HomeLinkLabel.Links[this.HomeLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("http://www.instrumentationopc.com/");
		}

		private void SupportLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.SupportLinkLabel.Links[this.SupportLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("http://support.softwaretoolbox.com/");
		}

		private void SalesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.SalesLinkLabel.Links[this.SalesLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("http://www.instrumentationopc.com/ordering/");
		}
	}
}
