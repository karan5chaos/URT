using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xmldatabase.Properties;

namespace xmldatabase;

public class Settings : Form
{
	private string database_path = xmldatabase.Properties.Settings.Default.path + "/database.xml";

	private string localpath = "C:/update_tool/" + Environment.UserName + "/data/database.xml";

	private string scanpath = "C:/update_tool/" + Environment.UserName + "/data";

	private IContainer components = null;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private TextBox textBox2;

	private Button button4;

	private Label label2;

	private Button button1;

	private FolderBrowserDialog folderBrowserDialog1;

	public Settings()
	{
		InitializeComponent();
	}

	private void button4_Click(object sender, EventArgs e)
	{
	}

	private void Settings_Load(object sender, EventArgs e)
	{
		textBox2.Text = xmldatabase.Properties.Settings.Default.path;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			textBox2.Text = folderBrowserDialog1.SelectedPath;
		}
	}

	private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
	{
	}

	private void button4_Click_1(object sender, EventArgs e)
	{
		if (Directory.Exists(textBox2.Text))
		{
			xmldatabase.Properties.Settings.Default.path = textBox2.Text;
			xmldatabase.Properties.Settings.Default.Save();
			xmldatabase.Properties.Settings.Default.Reload();
			toolStripStatusLabel1.Text = "Path change success..";
		}
		else
		{
			toolStripStatusLabel1.Text = "Path couldn't be found .. Please verify if path is valid.";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.Settings));
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.button4 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.statusStrip1.BackColor = System.Drawing.Color.DimGray;
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
		this.statusStrip1.Location = new System.Drawing.Point(0, 73);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(301, 22);
		this.statusStrip1.SizingGrip = false;
		this.statusStrip1.TabIndex = 1;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
		this.toolStripStatusLabel1.Text = "..";
		this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
		this.textBox2.Location = new System.Drawing.Point(54, 12);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(206, 21);
		this.textBox2.TabIndex = 6;
		this.button4.Location = new System.Drawing.Point(54, 39);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(58, 23);
		this.button4.TabIndex = 7;
		this.button4.Text = "Save";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click_1);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(13, 15);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(34, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "Path :";
		this.button1.Location = new System.Drawing.Point(266, 10);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(26, 23);
		this.button1.TabIndex = 8;
		this.button1.Text = "...";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.folderBrowserDialog1.Description = "Select data folder";
		this.folderBrowserDialog1.HelpRequest += new System.EventHandler(folderBrowserDialog1_HelpRequest);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(301, 95);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.statusStrip1);
		this.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Settings";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Path Settings";
		base.Load += new System.EventHandler(Settings_Load);
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
