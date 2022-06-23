using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xmldatabase.Properties;

namespace xmldatabase;

public class Image2 : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	public Image2()
	{
		InitializeComponent();
	}

	private void Image2_Load(object sender, EventArgs e)
	{
		try
		{
			pictureBox1.ImageLocation = xmldatabase.Properties.Settings.Default.tempi2;
		}
		catch
		{
			MessageBox.Show("Error loading image..");
		}
	}

	private void Image2_FormClosing(object sender, FormClosingEventArgs e)
	{
		File.Delete(xmldatabase.Properties.Settings.Default.tempi2);
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox1.Location = new System.Drawing.Point(0, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(316, 307);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDoubleClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(316, 307);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Name = "Image2";
		this.Text = "Image 2";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Image2_FormClosing);
		base.Load += new System.EventHandler(Image2_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
