using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using xmldatabase.Properties;

namespace xmldatabase;

public class Accesspage : Form
{
	private IContainer components = null;

	private GroupBox groupBox1;

	private ListView listView1;

	private MenuStrip menuStrip1;

	private ColumnHeader uname;

	private ColumnHeader accs;

	private StatusStrip statusStrip1;

	private GroupBox groupBox2;

	private ComboBox comboBox1;

	private TextBox textBox1;

	private Button button1;

	private Label label2;

	private Label label1;

	private ToolStripMenuItem accessFileToolStripMenuItem;

	private ToolStripTextBox toolStripTextBox1;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private FileSystemWatcher fileSystemWatcher1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem deleteToolStripMenuItem;

	private Button button2;

	public Accesspage()
	{
		InitializeComponent();
	}

	private void Accesspage_Load(object sender, EventArgs e)
	{
		try
		{
			fileSystemWatcher1.Path = xmldatabase.Properties.Settings.Default.access_man;
		}
		catch
		{
		}
		if (!File.Exists(xmldatabase.Properties.Settings.Default.access_man + "/access.xml"))
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", Encoding.UTF8);
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Access");
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.Close();
			xmlTextWriter.Dispose();
		}
		toolStripTextBox1.Text = xmldatabase.Properties.Settings.Default.access_man;
		Text = xmldatabase.Properties.Settings.Default.superadmin;
		loadstreams();
	}

	private void listView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count > 0)
			{
				textBox1.Text = listView1.SelectedItems[0].Text;
				comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void populate()
	{
	}

	private void loadstreams()
	{
		listView1.Items.Clear();
		FileStream fileStream = new FileStream(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", FileMode.Open);
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(fileStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("user");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				string[] array = new string[2];
				ListViewItem listViewItem = new ListViewItem();
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				array[0] = xmlElement.GetAttribute("id");
				array[1] = xmlElement.GetAttribute("access");
				listViewItem = new ListViewItem(array);
				listView1.Items.Add(listViewItem);
			}
			fileStream.Close();
			fileStream.Dispose();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error occured :\n\n" + ex.Message);
			fileStream.Close();
			fileStream.Dispose();
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		FileStream fileStream = new FileStream(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", FileMode.Open);
		try
		{
			if (textBox1.Text == null || textBox1.Text == "" || comboBox1.Text == null || comboBox1.Text == "")
			{
				toolStripStatusLabel1.Text = "Error adding user . . ";
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(fileStream);
			XmlElement xmlElement = xmlDocument.CreateElement("user");
			xmlElement.SetAttribute("id", textBox1.Text);
			xmlElement.SetAttribute("access", comboBox1.Text);
			xmlDocument.DocumentElement.AppendChild(xmlElement);
			fileStream.Close();
			xmlDocument.Save(xmldatabase.Properties.Settings.Default.access_man + "/access.xml");
			toolStripStatusLabel1.Text = "User " + textBox1.Text + " Added.";
			textBox1.Clear();
			comboBox1.ResetText();
			fileStream.Dispose();
		}
		catch (Exception)
		{
			fileStream.Close();
			fileStream.Dispose();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	}

	private void button3_Click(object sender, EventArgs e)
	{
		loadstreams();
	}

	private void toolStripMenuItem1_Click(object sender, EventArgs e)
	{
		xmldatabase.Properties.Settings.Default.access_man = toolStripTextBox1.Text;
		xmldatabase.Properties.Settings.Default.Save();
		xmldatabase.Properties.Settings.Default.Reload();
	}

	private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
	{
		loadstreams();
	}

	private void groupBox2_Enter(object sender, EventArgs e)
	{
	}

	private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			toolStripStatusLabel1.Text = "Removing " + listView1.SelectedItems[0].Text;
			FileStream fileStream = new FileStream(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", FileMode.Open);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(fileStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("user");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				if (xmlElement.Attributes["id"].Value == listView1.SelectedItems[0].Text)
				{
					xmlDocument.DocumentElement.RemoveChild(xmlElement);
					toolStripStatusLabel1.Text = listView1.SelectedItems[0].Text + " Removed...";
					break;
				}
			}
			fileStream.Close();
			xmlDocument.Save(xmldatabase.Properties.Settings.Default.access_man + "/access.xml");
		}
		catch
		{
			toolStripStatusLabel1.Text = "Error Removing " + listView1.SelectedItems[0].Text + "...";
		}
	}

	private void EncryptFile(string inputFile, string outputFile)
	{
		try
		{
			string s = "XTDL";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(outputFile, FileMode.Create);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
			FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
			int num;
			while ((num = fileStream2.ReadByte()) != -1)
			{
				cryptoStream.WriteByte((byte)num);
			}
			fileStream2.Close();
			cryptoStream.Close();
			fileStream.Close();
		}
		catch
		{
			MessageBox.Show("Encryption failed!", "Error");
		}
	}

	private void DecryptFile(string inputFile, string outputFile)
	{
		string s = "XTDL";
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(s);
		FileStream fileStream = new FileStream(inputFile, FileMode.Open);
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
		FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
		int num;
		while ((num = cryptoStream.ReadByte()) != -1)
		{
			fileStream2.WriteByte((byte)num);
		}
		fileStream2.Close();
		cryptoStream.Close();
		fileStream.Close();
	}

	private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	private void Accesspage_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
		FileStream fileStream = new FileStream(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", FileMode.Open);
		try
		{
			if (textBox1.Text == "" || textBox1.Text == null || comboBox1.Text == "" || comboBox1.Text == null)
			{
				toolStripStatusLabel1.Text = "Updating rights failed. Please check with admin..";
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(fileStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("user");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				if (xmlElement.GetAttribute("id") == textBox1.Text)
				{
					xmlElement.SetAttribute("access", comboBox1.Text);
					break;
				}
			}
			fileStream.Close();
			fileStream.Dispose();
			xmlDocument.Save(xmldatabase.Properties.Settings.Default.access_man + "/access.xml");
		}
		catch (Exception ex)
		{
			fileStream.Close();
			fileStream.Dispose();
			MessageBox.Show("Error occured..\n" + ex.Message);
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
		this.components = new System.ComponentModel.Container();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.listView1 = new System.Windows.Forms.ListView();
		this.uname = new System.Windows.Forms.ColumnHeader();
		this.accs = new System.Windows.Forms.ColumnHeader();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.accessFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
		this.button2 = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.menuStrip1.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).BeginInit();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.listView1);
		this.groupBox1.Location = new System.Drawing.Point(213, 30);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(656, 174);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Details";
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.uname, this.accs });
		this.listView1.ContextMenuStrip = this.contextMenuStrip1;
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.Location = new System.Drawing.Point(6, 19);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(644, 149);
		this.listView1.TabIndex = 1;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.SelectedIndexChanged += new System.EventHandler(listView1_SelectedIndexChanged);
		this.uname.Text = "Username";
		this.uname.Width = 88;
		this.accs.Text = "Access";
		this.accs.Width = 547;
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.deleteToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
		this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
		this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
		this.deleteToolStripMenuItem.Text = "Delete";
		this.deleteToolStripMenuItem.Click += new System.EventHandler(deleteToolStripMenuItem_Click);
		this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.accessFileToolStripMenuItem, this.toolStripTextBox1, this.toolStripMenuItem1 });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(876, 27);
		this.menuStrip1.TabIndex = 1;
		this.menuStrip1.Text = "menuStrip1";
		this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(menuStrip1_ItemClicked);
		this.accessFileToolStripMenuItem.Name = "accessFileToolStripMenuItem";
		this.accessFileToolStripMenuItem.Size = new System.Drawing.Size(82, 23);
		this.accessFileToolStripMenuItem.Text = "Access File :";
		this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Control;
		this.toolStripTextBox1.Name = "toolStripTextBox1";
		this.toolStripTextBox1.Size = new System.Drawing.Size(730, 23);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 23);
		this.toolStripMenuItem1.Text = "Save";
		this.toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
		this.statusStrip1.Location = new System.Drawing.Point(0, 211);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(876, 22);
		this.statusStrip1.TabIndex = 2;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
		this.toolStripStatusLabel1.Text = "-";
		this.groupBox2.Controls.Add(this.button2);
		this.groupBox2.Controls.Add(this.comboBox1);
		this.groupBox2.Controls.Add(this.textBox1);
		this.groupBox2.Controls.Add(this.button1);
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Location = new System.Drawing.Point(12, 30);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(195, 174);
		this.groupBox2.TabIndex = 3;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Add user";
		this.groupBox2.Enter += new System.EventHandler(groupBox2_Enter);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[3] { "Admin", "Advanced User", "Novice" });
		this.comboBox1.Location = new System.Drawing.Point(82, 85);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(100, 21);
		this.comboBox1.TabIndex = 4;
		this.textBox1.Location = new System.Drawing.Point(82, 37);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(100, 20);
		this.textBox1.TabIndex = 3;
		this.button1.Location = new System.Drawing.Point(18, 133);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 2;
		this.button1.Text = "Add";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(28, 88);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(48, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Access :";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(15, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(61, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Username :";
		this.fileSystemWatcher1.EnableRaisingEvents = true;
		this.fileSystemWatcher1.SynchronizingObject = this;
		this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher1_Changed);
		this.button2.Location = new System.Drawing.Point(107, 133);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 23);
		this.button2.TabIndex = 5;
		this.button2.Text = "Update";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(876, 233);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.menuStrip1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "Accesspage";
		this.Text = "Accesspage";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Accesspage_FormClosing);
		base.Load += new System.EventHandler(Accesspage_Load);
		this.groupBox1.ResumeLayout(false);
		this.contextMenuStrip1.ResumeLayout(false);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
