using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xmldatabase.Properties;

namespace xmldatabase;

public class Image1 : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	public Image1()
	{
		InitializeComponent();
	}

	private void Image1_Load(object sender, EventArgs e)
	{
		try
		{
			pictureBox1.ImageLocation = xmldatabase.Properties.Settings.Default.tempi1;
		}
		catch
		{
			MessageBox.Show("Error laoding image..");
		}
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		Close();
	}

	private void Image1_FormClosing(object sender, FormClosingEventArgs e)
	{
		File.Delete(xmldatabase.Properties.Settings.Default.tempi1);
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
		this.pictureBox1.Size = new System.Drawing.Size(319, 318);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDoubleClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(319, 318);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Name = "Image1";
		this.Text = "Image 1";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Image1_FormClosing);
		base.Load += new System.EventHandler(Image1_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
