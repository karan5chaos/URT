using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace xmldatabase;

public class Loading_data : Form
{
	private IContainer components = null;

	private ProgressBar progressBar1;

	private Label label1;

	public Loading_data()
	{
		InitializeComponent();
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
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.progressBar1.Location = new System.Drawing.Point(12, 51);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(260, 23);
		this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
		this.progressBar1.TabIndex = 0;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(9, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(75, 26);
		this.label1.TabIndex = 1;
		this.label1.Text = "Loading Data..\r\nPlease Wait.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 86);
		base.ControlBox = false;
		base.Controls.Add(this.label1);
		base.Controls.Add(this.progressBar1);
		this.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Name = "Loading_data";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Loading..";
		base.TopMost = true;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
