using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace xmldatabase;

public class c_log : Form
{
	private IContainer components = null;

	private GroupBox groupBox1;

	public c_log()
	{
		InitializeComponent();
	}

	private void c_log_Load(object sender, EventArgs e)
	{
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		base.SuspendLayout();
		this.groupBox1.Location = new System.Drawing.Point(12, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(307, 558);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Change Log :";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(331, 573);
		base.Controls.Add(this.groupBox1);
		base.Name = "c_log";
		this.Text = "c_log";
		base.Load += new System.EventHandler(c_log_Load);
		base.ResumeLayout(false);
	}
}
