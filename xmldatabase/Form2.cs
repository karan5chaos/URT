using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Jira.SDK;
using xmldatabase.Properties;

namespace xmldatabase;

public class Form2 : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private TextBox textBox1;

	private Button button1;

	private TextBox textBox3;

	private MaskedTextBox textBox2;

	private GroupBox groupBox1;

	private TextBox textBox4;

	private GroupBox groupBox2;

	private Label label3;

	private CheckBox checkBox1;

	public Form2()
	{
		InitializeComponent();
	}

	private void Form2_Load(object sender, EventArgs e)
	{
		textBox1.Text = xmldatabase.Properties.Settings.Default.jirauser;
		textBox2.Text = xmldatabase.Properties.Settings.Default.jirapass;
		textBox4.Text = xmldatabase.Properties.Settings.Default.mapops;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if ((textBox1.Text != null || textBox1.Text != "") && (textBox2.Text != null || textBox2.Text != "") && textBox3.BackColor != Color.Crimson)
		{
			xmldatabase.Properties.Settings.Default.jirauser = textBox1.Text;
			xmldatabase.Properties.Settings.Default.jirapass = textBox2.Text;
			xmldatabase.Properties.Settings.Default.mapops = textBox4.Text;
			xmldatabase.Properties.Settings.Default.Save();
			xmldatabase.Properties.Settings.Default.Reload();
			Close();
		}
		else
		{
			MessageBox.Show("Check credentials..");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
	}

	private void button1_MouseEnter(object sender, EventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		try
		{
			Jira val = new Jira();
			val.Connect(xmldatabase.Properties.Settings.Default.mapops, textBox1.Text, textBox2.Text);
			textBox3.BackColor = Color.LimeGreen;
		}
		catch
		{
			textBox3.BackColor = Color.Crimson;
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			textBox4.ReadOnly = false;
		}
		else
		{
			textBox4.ReadOnly = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.Form2));
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.MaskedTextBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label3 = new System.Windows.Forms.Label();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 21);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(63, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "User name :";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 48);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(58, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Password :";
		this.textBox1.Location = new System.Drawing.Point(75, 18);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(127, 21);
		this.textBox1.TabIndex = 1;
		this.button1.Location = new System.Drawing.Point(171, 152);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(43, 23);
		this.button1.TabIndex = 3;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button1.MouseEnter += new System.EventHandler(button1_MouseEnter);
		this.textBox3.Location = new System.Drawing.Point(51, 154);
		this.textBox3.Name = "textBox3";
		this.textBox3.ReadOnly = true;
		this.textBox3.Size = new System.Drawing.Size(19, 21);
		this.textBox3.TabIndex = 5;
		this.textBox3.TabStop = false;
		this.textBox2.Location = new System.Drawing.Point(75, 45);
		this.textBox2.Name = "textBox2";
		this.textBox2.PasswordChar = '*';
		this.textBox2.Size = new System.Drawing.Size(127, 21);
		this.textBox2.TabIndex = 2;
		this.groupBox1.Controls.Add(this.checkBox1);
		this.groupBox1.Controls.Add(this.textBox4);
		this.groupBox1.Location = new System.Drawing.Point(6, 6);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(208, 53);
		this.groupBox1.TabIndex = 6;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "URL";
		this.textBox4.Location = new System.Drawing.Point(27, 20);
		this.textBox4.Name = "textBox4";
		this.textBox4.ReadOnly = true;
		this.textBox4.Size = new System.Drawing.Size(175, 21);
		this.textBox4.TabIndex = 0;
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.textBox2);
		this.groupBox2.Controls.Add(this.textBox1);
		this.groupBox2.Location = new System.Drawing.Point(6, 65);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(208, 81);
		this.groupBox2.TabIndex = 7;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Credentials";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(3, 157);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(42, 13);
		this.label3.TabIndex = 8;
		this.label3.Text = "Status :";
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(6, 23);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(15, 14);
		this.checkBox1.TabIndex = 1;
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(220, 184);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.button1);
		this.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Maps-Ops Settings";
		base.Load += new System.EventHandler(Form2_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
