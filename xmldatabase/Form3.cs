using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace xmldatabase;

public class Form3 : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private Label label3;

	private Button button1;

	private Label label4;

	private GroupBox groupBox1;

	private Label label9;

	private Label label8;

	private LinkLabel linkLabel4;

	private LinkLabel linkLabel3;

	private LinkLabel linkLabel2;

	private LinkLabel linkLabel1;

	private Label label7;

	private Label label6;

	private Label label5;

	private Label label10;

	private LinkLabel linkLabel5;

	private Label label11;

	private GroupBox groupBox2;

	public Form3()
	{
		InitializeComponent();
	}

	private void Form3_Load(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OUTLOOK");
			Microsoft.Office.Interop.Outlook.Application application = (Microsoft.Office.Interop.Outlook.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
			if (processesByName.Length != 0)
			{
				application = Marshal.GetActiveObject("Outlook.Application") as Microsoft.Office.Interop.Outlook.Application;
			}
			MailItem mailItem = (dynamic)application.CreateItem(OlItemType.olMailItem);
			mailItem.Recipients.Add("karan.piprani@here.com");
			mailItem.Recipients.Add("gaurav.gawade@here.com");
			mailItem.Recipients.Add("yogesh.patil@here.com");
			mailItem.Recipients.Add("mrinmoy.chatterjee@here.com");
			mailItem.Subject = "Update tool feedback";
			mailItem.Body = "Thank you!";
			mailItem.Importance = OlImportance.olImportanceHigh;
			mailItem.Display(false);
			if (mailItem.Recipients.ResolveAll())
			{
				mailItem.Send();
				MessageBox.Show("Thank you for your feedback :)");
			}
		}
		catch
		{
			MessageBox.Show("feedback sending failed . .");
		}
	}

	private void label9_Click(object sender, EventArgs e)
	{
	}

	private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://docs.google.com/spreadsheets/u/1/d/1E8X2_xmJkkoeZwa1HPNG6jT3ytAZlcAgzTDRX0jDF-Q/pubhtml?gid=0&single=true");
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(linkLabel1.Text);
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(linkLabel2.Text);
	}

	private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(linkLabel3.Text);
	}

	private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(linkLabel4.Text);
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
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.linkLabel5 = new System.Windows.Forms.LinkLabel();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.linkLabel4 = new System.Windows.Forms.LinkLabel();
		this.linkLabel3 = new System.Windows.Forms.LinkLabel();
		this.linkLabel2 = new System.Windows.Forms.LinkLabel();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.label7 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Calibri", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(5, -1);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(191, 29);
		this.label1.TabIndex = 0;
		this.label1.Text = "Update Repo Tool";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(7, 28);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(95, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Version - 4.0 (Final)";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(6, 17);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(271, 39);
		this.label3.TabIndex = 2;
		this.label3.Text = "> Concept/Idea - Yogesh Patil.\r\n> Developer - Karan Piprani.\r\n> User Testing - Mrinmoy Chatterjee and Gaurav Gawade.";
		this.button1.Location = new System.Drawing.Point(212, 407);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(76, 28);
		this.button1.TabIndex = 3;
		this.button1.Text = "Thanks!";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(2, 415);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(140, 13);
		this.label4.TabIndex = 4;
		this.label4.Text = "Liked our work ? Thank Us ! :)";
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.linkLabel5);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.linkLabel4);
		this.groupBox1.Controls.Add(this.linkLabel3);
		this.groupBox1.Controls.Add(this.linkLabel2);
		this.groupBox1.Controls.Add(this.linkLabel1);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Location = new System.Drawing.Point(5, 115);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(283, 288);
		this.groupBox1.TabIndex = 5;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Additional Information";
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.Location = new System.Drawing.Point(7, 21);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(49, 14);
		this.label11.TabIndex = 11;
		this.label11.Text = "Libraries";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(6, 228);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(260, 39);
		this.label10.TabIndex = 10;
		this.label10.Text = "Icons were downloaded and used from iconfinder.com\r\n(All Icons used are distributed under Free for\r\nCommercial Use Licence).";
		this.linkLabel5.AutoSize = true;
		this.linkLabel5.Location = new System.Drawing.Point(6, 267);
		this.linkLabel5.Name = "linkLabel5";
		this.linkLabel5.Size = new System.Drawing.Size(180, 13);
		this.linkLabel5.TabIndex = 9;
		this.linkLabel5.TabStop = true;
		this.linkLabel5.Text = "Click Here For Licence Overview Page";
		this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel5_LinkClicked);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(7, 214);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(32, 14);
		this.label9.TabIndex = 8;
		this.label9.Text = "Icons";
		this.label9.Click += new System.EventHandler(label9_Click);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(7, 156);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(55, 13);
		this.label8.TabIndex = 7;
		this.label8.Text = "RestSharp";
		this.linkLabel4.AutoSize = true;
		this.linkLabel4.Location = new System.Drawing.Point(7, 169);
		this.linkLabel4.Name = "linkLabel4";
		this.linkLabel4.Size = new System.Drawing.Size(197, 13);
		this.linkLabel4.TabIndex = 6;
		this.linkLabel4.TabStop = true;
		this.linkLabel4.Text = "https://github.com/restsharp/RestSharp";
		this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel4_LinkClicked);
		this.linkLabel3.AutoSize = true;
		this.linkLabel3.Location = new System.Drawing.Point(6, 127);
		this.linkLabel3.Name = "linkLabel3";
		this.linkLabel3.Size = new System.Drawing.Size(225, 13);
		this.linkLabel3.TabIndex = 5;
		this.linkLabel3.TabStop = true;
		this.linkLabel3.Text = "https://github.com/JamesNK/Newtonsoft.Json";
		this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
		this.linkLabel2.AutoSize = true;
		this.linkLabel2.Location = new System.Drawing.Point(6, 87);
		this.linkLabel2.Name = "linkLabel2";
		this.linkLabel2.Size = new System.Drawing.Size(206, 13);
		this.linkLabel2.TabIndex = 4;
		this.linkLabel2.TabStop = true;
		this.linkLabel2.Text = "https://github.com/Sicos1977/MSGReader";
		this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Location = new System.Drawing.Point(6, 48);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(246, 13);
		this.linkLabel1.TabIndex = 3;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "https://bitbucket.org/farmas/atlassian.net-sdk/src";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(6, 114);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(86, 13);
		this.label7.TabIndex = 2;
		this.label7.Text = "Newtonsoft.Json";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(6, 74);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(62, 13);
		this.label6.TabIndex = 1;
		this.label6.Text = "MSGReader";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(6, 35);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(91, 13);
		this.label5.TabIndex = 0;
		this.label5.Text = "Atlassian.Net SDK";
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Location = new System.Drawing.Point(5, 44);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(283, 65);
		this.groupBox2.TabIndex = 6;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Credits";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(293, 440);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		this.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form3";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "About";
		base.Load += new System.EventHandler(Form3_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
