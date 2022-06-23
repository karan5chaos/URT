using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xmldatabase.Properties;

namespace xmldatabase;

public class monitor : Form
{
	private IContainer components = null;

	private FileSystemWatcher fileSystemWatcher1;

	private DataGridView dataGridView1;

	private DataGridViewTextBoxColumn en;

	private DataGridViewTextBoxColumn date;

	public monitor()
	{
		InitializeComponent();
	}

	private void monitor_Load(object sender, EventArgs e)
	{
		try
		{
			dataGridView1.Rows.Clear();
			fileSystemWatcher1.Path = xmldatabase.Properties.Settings.Default.access_man + "/log";
			string[] array = File.ReadAllLines(xmldatabase.Properties.Settings.Default.access_man + "/log/log.txt");
			dataGridView1.SuspendLayout();
			string[] array2 = array;
			foreach (string text in array2)
			{
				dataGridView1.Rows.Insert(0, text.Remove(text.IndexOf(" :")), text.Substring(text.IndexOf(": ") + 1));
			}
			dataGridView1.ResumeLayout();
		}
		catch
		{
		}
	}

	private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
	{
		dataGridView1.Rows.Clear();
		string[] array = File.ReadAllLines(xmldatabase.Properties.Settings.Default.access_man + "/log/log.txt");
		dataGridView1.SuspendLayout();
		string[] array2 = array;
		foreach (string text in array2)
		{
			dataGridView1.Rows.Insert(0, text, text.Remove(text.IndexOf(":")));
		}
		dataGridView1.ResumeLayout();
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.monitor));
		this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.en = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.fileSystemWatcher1.EnableRaisingEvents = true;
		this.fileSystemWatcher1.SynchronizingObject = this;
		this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher1_Changed);
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.AllowUserToDeleteRows = false;
		this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Bold);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.en, this.date);
		resources.ApplyResources(this.dataGridView1, "dataGridView1");
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowHeadersVisible = false;
		this.en.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
		resources.ApplyResources(this.en, "en");
		this.en.Name = "en";
		this.en.ReadOnly = true;
		resources.ApplyResources(this.date, "date");
		this.date.Name = "date";
		this.date.ReadOnly = true;
		resources.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.dataGridView1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "monitor";
		base.TopMost = true;
		base.Load += new System.EventHandler(monitor_Load);
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
	}
}
