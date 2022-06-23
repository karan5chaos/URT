using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace xmldatabase;

public class signin : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private TextBox textBox2;

	private Button button1;

	private Label label1;

	private Label label2;

	public signin()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (textBox1.Text == "piprani" && textBox2.Text == "xtdl")
		{
			Accesspage accesspage = new Accesspage();
			accesspage.Show();
			accesspage.BringToFront();
			Close();
		}
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(101, 12);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(100, 20);
		this.textBox1.TabIndex = 0;
		this.textBox2.Location = new System.Drawing.Point(101, 47);
		this.textBox2.Name = "textBox2";
		this.textBox2.PasswordChar = '*';
		this.textBox2.Size = new System.Drawing.Size(100, 20);
		this.textBox2.TabIndex = 1;
		this.button1.Location = new System.Drawing.Point(216, 44);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Log-in";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(36, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(24, 13);
		this.label1.TabIndex = 3;
		this.label1.Text = "ID :";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(36, 50);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(59, 13);
		this.label2.TabIndex = 4;
		this.label2.Text = "Password :";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(304, 79);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "signin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Manage Access";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
