using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using xmldatabase.Properties;

namespace xmldatabase;

public class backup_ : Form
{
	private string database_path = xmldatabase.Properties.Settings.Default.path + "/database.xml";

	private IContainer components = null;

	public GroupBox groupBox1;

	public Label label1;

	public TextBox textBox1;

	public Button button1;

	public CheckBox checkBox1;

	public StatusStrip statusStrip1;

	public BackgroundWorker backgroundWorker1;

	private Button button2;

	private FolderBrowserDialog folderBrowserDialog1;

	public backup_()
	{
		InitializeComponent();
	}

	public void backup__Load(object sender, EventArgs e)
	{
		if (backup.Default.autobak)
		{
			checkBox1.Checked = true;
		}
		else if (!backup.Default.autobak)
		{
			checkBox1.Checked = false;
		}
		textBox1.Text = backup.Default.path;
	}

	public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	public void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	public void groupBox2_Enter(object sender, EventArgs e)
	{
	}

	public void backup__FormClosing(object sender, FormClosingEventArgs e)
	{
		backup.Default.path = textBox1.Text;
		if (checkBox1.Checked)
		{
			backup.Default.autobak = true;
		}
		else
		{
			backup.Default.autobak = false;
		}
		backup.Default.Save();
		backup.Default.Reload();
	}

	public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			File.Copy(database_path, backup.Default.path + "/backup/database.xml");
			if (Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Images"))
			{
				Directory.CreateDirectory(backup.Default.path + "/backup/Images");
				FileSystem.CopyDirectory(xmldatabase.Properties.Settings.Default.path + "/Images", backup.Default.path + "/backup/Images");
			}
			if (Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails"))
			{
				Directory.CreateDirectory(backup.Default.path + "/backup/Mails");
				FileSystem.CopyDirectory(xmldatabase.Properties.Settings.Default.path + "/Mails", backup.Default.path + "/backup/Mails");
			}
			File.AppendAllText(backup.Default.path + "/backup/env_path.pth", xmldatabase.Properties.Settings.Default.path);
			ZipFile.CreateFromDirectory(backup.Default.path + "/backup", backup.Default.path + "/Databackup-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".zip");
			DialogResult dialogResult = MessageBox.Show("Local Backup Generated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			if (dialogResult == DialogResult.OK)
			{
				Directory.Delete(backup.Default.path + "/backup", recursive: true);
			}
		}
		catch
		{
			MessageBox.Show("Error Generating Backup..");
		}
	}

	public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		backgroundWorker1.Dispose();
		button1.Enabled = true;
	}

	public void button1_Click(object sender, EventArgs e)
	{
		MessageBox.Show("Backup generation task started in background..\nYou may resume your operations", "Backup Generation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		try
		{
			if (Directory.Exists(backup.Default.path + "/backup"))
			{
				Directory.Delete(backup.Default.path + "/backup", recursive: true);
			}
			Directory.CreateDirectory(backup.Default.path + "/backup");
			if (!backgroundWorker1.IsBusy)
			{
				button1.Enabled = false;
				backgroundWorker1.RunWorkerAsync();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error generating backup .. \n" + ex.Message);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			textBox1.Text = folderBrowserDialog1.SelectedPath;
			backup.Default.path = folderBrowserDialog1.SelectedPath;
		}
	}

	private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
	{
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void label1_Click(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.backup_));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.button2);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.checkBox1);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(7, 4);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(276, 129);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Settings";
		this.button2.Location = new System.Drawing.Point(227, 29);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(29, 23);
		this.button2.TabIndex = 4;
		this.button2.Text = "...";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(19, 95);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(64, 25);
		this.button1.TabIndex = 2;
		this.button1.Text = "Generate";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(19, 64);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(119, 17);
		this.checkBox1.TabIndex = 3;
		this.checkBox1.Text = "Enable Auto-Backup";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
		this.textBox1.Location = new System.Drawing.Point(57, 31);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(164, 21);
		this.textBox1.TabIndex = 1;
		this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(16, 34);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(34, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Path :";
		this.label1.Click += new System.EventHandler(label1_Click);
		this.statusStrip1.BackColor = System.Drawing.Color.DimGray;
		this.statusStrip1.Location = new System.Drawing.Point(0, 143);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(293, 22);
		this.statusStrip1.SizingGrip = false;
		this.statusStrip1.TabIndex = 1;
		this.statusStrip1.Text = "statusStrip1";
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.folderBrowserDialog1.Description = "Select backup path";
		this.folderBrowserDialog1.HelpRequest += new System.EventHandler(folderBrowserDialog1_HelpRequest);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(293, 165);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.groupBox1);
		this.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "backup_";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Backup";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(backup__FormClosing);
		base.Load += new System.EventHandler(backup__Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
