using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Jira.SDK;
using Jira.SDK.Domain;
using xmldatabase.Properties;

namespace xmldatabase;

public class jira : Form
{
	private delegate void SetTextCallback(string text1, string text2, string text3, string text4, string text5, string text6, string text7);

	private IContainer components = null;

	private Label label1;

	private Label label5;

	private Label label13;

	private TextBox textBox1;

	private TextBox textBox5;

	private TextBox textBox11;

	private TextBox textBox13;

	private TextBox textBox2;

	private Label label2;

	private TextBox textBox3;

	private Label label3;

	private Button button2;

	private TextBox textBox4;

	private Label label4;

	private BackgroundWorker backgroundWorker1;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private Label label11;

	public jira()
	{
		try
		{
			InitializeComponent();
		}
		catch
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void jira_Load(object sender, EventArgs e)
	{
		Text = xmldatabase.Properties.Settings.Default.lastkey.ToUpper();
		toolStripStatusLabel1.Text = "Fetching data for " + xmldatabase.Properties.Settings.Default.lastkey.ToUpper() + "..";
		backgroundWorker1.RunWorkerAsync();
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(textBox3.Text);
	}

	private void SetText(string text1, string text2, string text3, string text4, string text5, string text6, string text7)
	{
		if (textBox1.InvokeRequired && textBox2.InvokeRequired && textBox3.InvokeRequired && textBox4.InvokeRequired && textBox5.InvokeRequired && textBox11.InvokeRequired && textBox13.InvokeRequired)
		{
			SetTextCallback method = SetText;
			Invoke(method, text1, text2, text3, text4, text5, text6, text7);
		}
		else
		{
			textBox1.Text = text1;
			textBox2.Text = text2;
			textBox3.Text = text3;
			textBox4.Text = text4;
			textBox5.Text = text5;
			textBox13.Text = text6;
			textBox11.Text = text7;
			toolStripStatusLabel1.Text = "Data Fetched Successfully..";
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		try
		{
			if (xmldatabase.Properties.Settings.Default.lastkey != null || xmldatabase.Properties.Settings.Default.lastkey != "")
			{
				Jira val = new Jira();
				val.Connect("http://pfarmapopsjira1.core.in.here.com", xmldatabase.Properties.Settings.Default.jirauser, xmldatabase.Properties.Settings.Default.jirapass);
				Issue issue = val.GetIssue(xmldatabase.Properties.Settings.Default.lastkey);
				SetText(issue.get_Fields().get_IssueType().get_Name(), issue.get_Fields().get_Reporter().get_Fullname(), issue.GetCustomFieldValue("PVID"), issue.get_Fields().get_Assignee().get_Fullname(), issue.GetCustomFieldValue("Work Order"), issue.get_Description(), issue.GetCustomFieldValue("Expert Resolution"));
			}
			else
			{
				MessageBox.Show("Fetching data failed..\nPlease make sure data is selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Fetching data failed..\n" + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
		this.label1 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.textBox13 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.label11 = new System.Windows.Forms.Label();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 19);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(31, 14);
		this.label1.TabIndex = 0;
		this.label1.Text = "Type";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(262, 19);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(67, 14);
		this.label5.TabIndex = 4;
		this.label5.Text = "Work Order";
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(14, 142);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(69, 14);
		this.label13.TabIndex = 12;
		this.label13.Text = "Description";
		this.textBox1.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox1.Location = new System.Drawing.Point(77, 16);
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.Size = new System.Drawing.Size(170, 21);
		this.textBox1.TabIndex = 16;
		this.textBox1.TabStop = false;
		this.textBox5.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox5.Location = new System.Drawing.Point(340, 16);
		this.textBox5.Name = "textBox5";
		this.textBox5.ReadOnly = true;
		this.textBox5.Size = new System.Drawing.Size(182, 21);
		this.textBox5.TabIndex = 20;
		this.textBox5.TabStop = false;
		this.textBox11.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox11.Location = new System.Drawing.Point(17, 299);
		this.textBox11.Multiline = true;
		this.textBox11.Name = "textBox11";
		this.textBox11.ReadOnly = true;
		this.textBox11.Size = new System.Drawing.Size(505, 105);
		this.textBox11.TabIndex = 26;
		this.textBox11.TabStop = false;
		this.textBox13.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox13.Location = new System.Drawing.Point(17, 159);
		this.textBox13.Multiline = true;
		this.textBox13.Name = "textBox13";
		this.textBox13.ReadOnly = true;
		this.textBox13.Size = new System.Drawing.Size(505, 104);
		this.textBox13.TabIndex = 28;
		this.textBox13.TabStop = false;
		this.textBox2.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox2.Location = new System.Drawing.Point(340, 52);
		this.textBox2.Name = "textBox2";
		this.textBox2.ReadOnly = true;
		this.textBox2.Size = new System.Drawing.Size(182, 21);
		this.textBox2.TabIndex = 30;
		this.textBox2.TabStop = false;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(262, 55);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(54, 14);
		this.label2.TabIndex = 29;
		this.label2.Text = "Reporter";
		this.textBox3.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox3.Location = new System.Drawing.Point(77, 92);
		this.textBox3.Name = "textBox3";
		this.textBox3.ReadOnly = true;
		this.textBox3.Size = new System.Drawing.Size(393, 21);
		this.textBox3.TabIndex = 32;
		this.textBox3.TabStop = false;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(14, 99);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(32, 14);
		this.label3.TabIndex = 31;
		this.label3.Text = "PVID";
		this.button2.Location = new System.Drawing.Point(476, 88);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(46, 25);
		this.button2.TabIndex = 33;
		this.button2.TabStop = false;
		this.button2.Text = "Copy";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.textBox4.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox4.Location = new System.Drawing.Point(77, 52);
		this.textBox4.Name = "textBox4";
		this.textBox4.ReadOnly = true;
		this.textBox4.Size = new System.Drawing.Size(170, 21);
		this.textBox4.TabIndex = 35;
		this.textBox4.TabStop = false;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(14, 55);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(57, 14);
		this.label4.TabIndex = 34;
		this.label4.Text = "Assignee";
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
		this.statusStrip1.Location = new System.Drawing.Point(0, 415);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(534, 22);
		this.statusStrip1.TabIndex = 36;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
		this.toolStripStatusLabel1.Text = "..";
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(14, 282);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(102, 14);
		this.label11.TabIndex = 10;
		this.label11.Text = "Expert Resolution";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(534, 437);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBox13);
		base.Controls.Add(this.textBox11);
		base.Controls.Add(this.textBox5);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label1);
		this.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "jira";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "jira";
		base.Load += new System.EventHandler(jira_Load);
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
