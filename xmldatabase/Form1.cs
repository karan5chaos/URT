using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Jira.SDK;
using Jira.SDK.Domain;
using Microsoft.Office.Interop.Outlook;
using MsgReader.Outlook;
using xmldatabase.Properties;

namespace xmldatabase;

public class Form1 : Form
{
	private delegate void SetTextCallback(string text, string text2, string text3);

	private delegate void Setcountrynames(string[] text);

	private delegate void SetListtCallback(string[] text);

	private delegate void SetTextCallback2(string text1, string text2, string text3, string text4, string text5, string text6, string text7);

	private delegate void SetwebCallback2(string text1);

	private delegate void SetsearchtCallback(List<string> text);

	private delegate void SetListtCallbackup(string[] text);

	private Values val = new Values();

	private Update_vals ua = new Update_vals();

	private Loading_data ld = new Loading_data();

	private string variable_path;

	private string database_path = xmldatabase.Properties.Settings.Default.path + "/database.xml";

	private string localpath = "C:/update_tool/" + Environment.UserName + "/data/database.xml";

	private string scanpath = "C:/update_tool/" + Environment.UserName + "/data";

	private bool onload = false;

	private string search_text;

	private bool search_flag = false;

	private bool systemwatcherflah = false;

	private bool delflag = false;

	private bool isexit = false;

	private List<string> dlist = new List<string>();

	private IContainer components = null;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem searchToolStripMenuItem;

	private GroupBox groupBox1;

	private GroupBox groupBox3;

	private Button button3;

	private Label label5;

	private Label label4;

	private TextBox textBox2;

	private ComboBox comboBox1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem shareWithTeamToolStripMenuItem;

	private ToolTip toolTip1;

	private ToolStripMenuItem advancedToolStripMenuItem;

	private NotifyIcon notifyIcon1;

	private TextBox textBox11;

	private Label label13;

	private ComboBox comboBox2;

	private SplitContainer splitContainer1;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	private FileSystemWatcher fileSystemWatcher1;

	private ToolStripMenuItem deleteSelectedToolStripMenuItem;

	private ComboBox textBox1;

	private Button button1;

	private ToolStripMenuItem aboutToolStripMenuItem1;

	private ToolStripMenuItem changeRegionToolStripMenuItem;

	private ToolStripComboBox toolStripComboBox1;

	private GroupBox groupBox4;

	private ToolStripMenuItem changeRegionToolStripMenuItem1;

	private ToolStripSeparator toolStripSeparator1;

	private BackgroundWorker backgroundWorker1;

	private ToolStripMenuItem exportToolStripMenuItem;

	private SaveFileDialog saveFileDialog1;

	private GroupBox groupBox6;

	private ToolStripTextBox toolStripTextBox1;

	private GroupBox groupBox2;

	private GroupBox groupBox5;

	private BackgroundWorker backgroundWorker2;

	private StatusStrip statusStrip2;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private GroupBox groupBox8;

	private StatusStrip statusStrip1;

	private TextBox wotex;

	private TextBox type;

	private Label label1;

	private Label label2;

	private TextBox addign;

	private Label label3;

	private TextBox reporter;

	private Label label6;

	private Button button2;

	private TextBox pvid;

	private Label label7;

	private TextBox desc;

	private Label label8;

	private Label label9;

	private TextBox exres;

	private BackgroundWorker getjira;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private TabPage tabPage3;

	private TextBox textBox7;

	private Label label15;

	private TextBox textBox6;

	private Label label14;

	private TextBox textBox5;

	private Label label12;

	private TextBox textBox4;

	private Label label11;

	private TextBox textBox3;

	private Label label10;

	private GroupBox groupBox10;

	private TabControl tabControl2;

	private TabPage tabPage4;

	private PictureBox pictureBox3;

	private TextBox textBox13;

	private Label label20;

	private TabPage tabPage5;

	private GroupBox groupBox9;

	private TextBox textBox12;

	private Label label19;

	private TextBox textBox10;

	private Label label18;

	private TextBox textBox9;

	private Label label17;

	private TextBox textBox8;

	private Label label16;

	private Button button4;

	private Button button5;

	private PictureBox pictureBox4;

	private TextBox textBox14;

	private Label label21;

	private BackgroundWorker update_details_worker;

	private Button button6;

	private DateTimePicker dateTimePicker1;

	private Label label22;

	private BackgroundWorker af_update;

	private OpenFileDialog openFileDialog1;

	private OpenFileDialog openFileDialog2;

	private Button button7;

	private Button button8;

	private TabPage tabPage6;

	private GroupBox groupBox11;

	private BackgroundWorker backgroundWorker3;

	private BackgroundWorker getmaildets;

	private StatusStrip statusStrip3;

	private ToolStripStatusLabel toolStripStatusLabel3;

	private RichTextBox richTextBox1;

	private TabPage tabPage7;

	private RichTextBox richTextBox2;

	private Button button9;

	private Button button10;

	private TextBox textBox15;

	private Label label23;

	private OpenFileDialog openFileDialog3;

	private FileSystemWatcher fileSystemWatcher2;

	private ContextMenuStrip contextMenuStrip2;

	private ToolStripMenuItem searchToolStripMenuItem1;

	private ToolStripMenuItem settingsToolStripMenuItem;

	private ToolStripMenuItem dataToolStripMenuItem;

	private ToolStripMenuItem importToolStripMenuItem;

	private OpenFileDialog openFileDialog4;

	private ToolStripMenuItem settingsToolStripMenuItem1;

	private SaveFileDialog saveFileDialog2;

	private OpenFileDialog openFileDialog5;

	private ToolTip toolTip2;

	private HelpProvider helpProvider1;

	private Label label24;

	private ToolStripMenuItem copyUIDToolStripMenuItem;

	private ToolStripMenuItem backupToolStripMenuItem1;

	private ToolStripMenuItem mapOpsJIRAToolStripMenuItem1;

	private ToolStripMenuItem eMailToolStripMenuItem;

	private ToolStripMenuItem accessToolStripMenuItem1;

	private ToolStripMenuItem logToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip3;

	private ToolStripMenuItem copyImage1ToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip4;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem copyToStickyNotesToolStripMenuItem;

	private ToolStripMenuItem createTextFileToolStripMenuItem;

	private FontDialog fontDialog1;

	private DataGridView dataGridView1;

	private DataGridView dataGridView2;

	private DataGridViewTextBoxColumn param;

	private DataGridViewTextBoxColumn value;

	private ToolStripMenuItem exitToolStripMenuItem;

	private PictureBox pictureBox5;

	private BackgroundWorker backgroundWorker4;

	private BackgroundWorker backgroundWorker5;

	private DataGridView dataGridView3;

	private DataGridViewTextBoxColumn id;

	private ContextMenuStrip contextMenuStrip5;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem4;

	private ToolStripMenuItem toolStripMenuItem5;

	private ToolStripMenuItem toolStripMenuItem6;

	private GroupBox groupBox7;

	private DataGridViewTextBoxColumn country;

	private DataGridViewTextBoxColumn attrib;

	private DataGridViewTextBoxColumn udi;

	private Button button11;

	private TextBox textBox16;

	public Form1()
	{
		InitializeComponent();
	}

	public void Form1_Load(object sender, EventArgs e)
	{
		onload = true;
		try
		{
			File.AppendAllText(xmldatabase.Properties.Settings.Default.access_man + "/log/log.txt", string.Concat(Environment.UserName, " : ", DateTime.Now, Environment.NewLine));
		}
		catch
		{
		}
		if (backup.Default.autobak)
		{
			backup_ backup_2 = new backup_();
			backup_2.button1_Click(null, null);
		}
		if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/settings.xmls") && xmldatabase.Properties.Settings.Default.set_con)
		{
			switch (MessageBox.Show("Settings file found.\nImport Settings?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Yes:
				loadsettings(xmldatabase.Properties.Settings.Default.path + "/settings.xmls");
				xmldatabase.Properties.Settings.Default.set_con = false;
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			case DialogResult.Cancel:
				xmldatabase.Properties.Settings.Default.set_con = false;
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
		}
		accessToolStripMenuItem1.Enabled = true;
		if (xmldatabase.Properties.Settings.Default.path.Contains("c:/"))
		{
			notifyIcon1.Icon = SystemIcons.Application;
			notifyIcon1.BalloonTipTitle = "Local Path Detected";
			notifyIcon1.BalloonTipText = "Local Path in use.";
			notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
			notifyIcon1.Visible = true;
			notifyIcon1.ShowBalloonTip(500);
		}
		try
		{
			check_access();
		}
		catch
		{
		}
		if (!Directory.Exists("C:/update_tool/"))
		{
			Directory.CreateDirectory("C:/update_tool/");
		}
		if (!xmldatabase.Properties.Settings.Default.pcache)
		{
			variable_path = database_path;
			if (!File.Exists(database_path))
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(database_path, Encoding.UTF8);
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("Repo");
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Close();
				xmlTextWriter.Dispose();
				notifyIcon1.Text = "Config success";
				notifyIcon1.Icon = SystemIcons.Application;
				notifyIcon1.BalloonTipTitle = "First time setup";
				notifyIcon1.BalloonTipText = "Configuration success.";
				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				notifyIcon1.Visible = true;
				notifyIcon1.ShowBalloonTip(500);
			}
			try
			{
				fileSystemWatcher1.Path = xmldatabase.Properties.Settings.Default.path;
			}
			catch
			{
				MessageBox.Show("Error starting fwscanner");
			}
		}
		xmldatabase.Properties.Settings.Default.varpath = variable_path;
		xmldatabase.Properties.Settings.Default.Save();
		xmldatabase.Properties.Settings.Default.Reload();
		Text = "Update Repo Tool - Region : " + xmldatabase.Properties.Settings.Default.region;
		xmldatabase.Properties.Settings.Default.lastkey = "null";
		backgroundWorker2.RunWorkerAsync();
		toolStripComboBox1.Text = xmldatabase.Properties.Settings.Default.region;
		backgroundWorker1.RunWorkerAsync();
	}

	private void loadsettings(string path)
	{
		try
		{
			FileStream fileStream = new FileStream(path, FileMode.Open);
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(fileStream);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("setting");
				int num = 0;
				if (num < elementsByTagName.Count)
				{
					XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("setting")[num];
					XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("path")[num];
					XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("group")[num];
					XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("mail_c")[num];
					XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("region")[num];
					xmldatabase.Properties.Settings.Default.path = xmlElement2.InnerText;
					email.Default.to = xmlElement3.InnerText;
					xmldatabase.Properties.Settings.Default.emailconfirm = Convert.ToBoolean(xmlElement4.InnerText);
					xmldatabase.Properties.Settings.Default.region = xmlElement5.InnerText;
					backup.Default.Save();
					backup.Default.Reload();
					xmldatabase.Properties.Settings.Default.Save();
					xmldatabase.Properties.Settings.Default.Reload();
					email.Default.Save();
					email.Default.Reload();
					MessageBox.Show("Settings Loaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				fileStream.Close();
				fileStream.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Settings not loaded :\n\n" + ex.Message);
				fileStream.Close();
				fileStream.Dispose();
			}
		}
		catch
		{
		}
	}

	private void check_access()
	{
		if (Environment.UserName == xmldatabase.Properties.Settings.Default.superadmin || Environment.UserName == "gawade" || Environment.UserName == "mchatter" || Environment.UserName == "yopatil")
		{
			return;
		}
		using FileStream inStream = new FileStream(xmldatabase.Properties.Settings.Default.access_man + "/access.xml", FileMode.Open);
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(inStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("user");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				if (xmlElement.GetAttribute("id") == Environment.UserName)
				{
					contextMenuStrip1.Enabled = false;
					fileToolStripMenuItem.Enabled = false;
					exportToolStripMenuItem.Enabled = true;
					eMailToolStripMenuItem.Enabled = false;
					backupToolStripMenuItem1.Enabled = false;
					mapOpsJIRAToolStripMenuItem1.Enabled = true;
					searchToolStripMenuItem.Enabled = true;
					accessToolStripMenuItem1.Enabled = false;
					logToolStripMenuItem.Enabled = false;
					toolStripTextBox1.BackColor = Color.Gray;
					toolStripTextBox1.Text = "No access";
					switch (xmlElement.GetAttribute("access"))
					{
					case "Admin":
						toolStripTextBox1.BackColor = Color.SkyBlue;
						toolStripTextBox1.Text = "Admin";
						contextMenuStrip1.Enabled = true;
						fileToolStripMenuItem.Enabled = true;
						exportToolStripMenuItem.Enabled = true;
						eMailToolStripMenuItem.Enabled = true;
						backupToolStripMenuItem1.Enabled = true;
						mapOpsJIRAToolStripMenuItem1.Enabled = true;
						searchToolStripMenuItem.Enabled = true;
						accessToolStripMenuItem1.Enabled = true;
						logToolStripMenuItem.Enabled = true;
						break;
					case "Advanced User":
						break;
					case "Novice":
						toolStripTextBox1.BackColor = Color.LightGray;
						toolStripTextBox1.Text = "Novice";
						contextMenuStrip1.Enabled = false;
						fileToolStripMenuItem.Enabled = false;
						importToolStripMenuItem.Enabled = true;
						exportToolStripMenuItem.Enabled = true;
						eMailToolStripMenuItem.Enabled = false;
						backupToolStripMenuItem1.Enabled = false;
						mapOpsJIRAToolStripMenuItem1.Enabled = true;
						searchToolStripMenuItem.Enabled = true;
						accessToolStripMenuItem1.Enabled = false;
						logToolStripMenuItem.Enabled = false;
						tabControl1.TabPages.Remove(tabPage3);
						contextMenuStrip1.Enabled = false;
						email.Default.sendsave = false;
						email.Default.sendconfirm = false;
						email.Default.cc = "";
						email.Default.message = "";
						email.Default.to = "";
						email.Default.Save();
						email.Default.Reload();
						break;
					default:
						menuStrip1.Enabled = false;
						accessToolStripMenuItem1.Enabled = true;
						tabControl1.TabPages.Remove(tabPage3);
						contextMenuStrip1.Enabled = false;
						toolStripTextBox1.BackColor = Color.Gray;
						toolStripTextBox1.Text = "No Access";
						tabPage3.Hide();
						break;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error occured :\n\n" + ex.Message);
		}
	}

	private void loadstreams2()
	{
		using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(inStream);
			dataGridView1.Visible = false;
			dataGridView1.SuspendLayout();
			pictureBox5.Visible = true;
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
				XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
				XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
				XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
				XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
				XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
				XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
				XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
				XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
				dataGridView1.Rows.Insert(0, xmlElement.GetAttribute("id"));
			}
			dataGridView1.ResumeLayout();
			dataGridView1.Visible = true;
			pictureBox5.Visible = false;
			toolStripStatusLabel1.Text = "Returned : " + elementsByTagName.Count + " Entry(s)";
			search_flag = false;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error occured :\n\n" + ex.Message);
		}
	}

	private void CreateMailItem()
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
			mailItem.To = email.Default.to;
			mailItem.CC = email.Default.cc;
			if (email.Default.subject != null || email.Default.subject != "")
			{
				mailItem.Subject = dynamictext(email.Default.subject);
			}
			if (email.Default.attachments)
			{
				if (pictureBox1.Image != null)
				{
					pictureBox1.Image.Save(System.Windows.Forms.Application.StartupPath + "/img1.jpg", ImageFormat.Jpeg);
					mailItem.Attachments.Add(System.Windows.Forms.Application.StartupPath + "/img1.jpg", Missing.Value, Missing.Value, Missing.Value);
				}
				if (pictureBox2.Image != null)
				{
					pictureBox2.Image.Save(System.Windows.Forms.Application.StartupPath + "/img2.jpg", ImageFormat.Jpeg);
					mailItem.Attachments.Add(System.Windows.Forms.Application.StartupPath + "/img2.jpg", Missing.Value, Missing.Value, Missing.Value);
				}
				if (val.mail != null && val.mail != "")
				{
					mailItem.Attachments.Add(val.mail, Missing.Value, Missing.Value, Missing.Value);
				}
			}
			mailItem.Body = dynamictext(email.Default.message);
			if (email.Default.priority)
			{
				mailItem.Importance = OlImportance.olImportanceHigh;
			}
			if (email.Default.readr)
			{
				mailItem.ReadReceiptRequested = true;
			}
			mailItem.Display(false);
			toolStripStatusLabel1.Text = "Mail Generated.";
			if (!mailItem.Recipients.ResolveAll())
			{
				return;
			}
			if (!email.Default.sendconfirm)
			{
				mailItem.Recipients.ResolveAll();
				mailItem.Send();
				toolStripStatusLabel1.Text = "Mail Shared with " + xmldatabase.Properties.Settings.Default.group;
			}
			else if (email.Default.sendconfirm)
			{
				DialogResult dialogResult = MessageBox.Show("Share details with team ?\n\n" + mailItem.Subject, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
				if (dialogResult == DialogResult.Yes)
				{
					mailItem.Recipients.ResolveAll();
					mailItem.Send();
					toolStripStatusLabel1.Text = "Mail Shared with " + xmldatabase.Properties.Settings.Default.group;
				}
			}
			File.Delete(System.Windows.Forms.Application.StartupPath + "/img1.jpg");
			File.Delete(System.Windows.Forms.Application.StartupPath + "/img2.jpg");
		}
		catch
		{
			MessageBox.Show("Error creating mail.\nPlease check if outlook is configured properly or if email group is provided.");
		}
	}

	private string dynamictext(string text)
	{
		text = text.Replace("@-id", val.user);
		text = text.Replace("@-attributetype", val.lane);
		text = text.Replace("@-jira", val.key);
		text = text.Replace("@-workorder", val.wo);
		text = text.Replace("@-country", val.country);
		text = text.Replace("@-fc", val.fc);
		text = text.Replace("@-ca", val.ca);
		text = text.Replace("@-sdate", val.sdate);
		text = text.Replace("@-comments", val.comment);
		text = text.Replace("@-uid", val.uid);
		return text;
	}

	private void shareWithTeamToolStripMenuItem_Click(object sender, EventArgs e)
	{
		toolStripStatusLabel1.Text = "Creating new mail item...";
		CreateMailItem();
	}

	private void textBox2_TextChanged(object sender, EventArgs e)
	{
		search_flag = true;
		search_text = textBox2.Text;
		if (search_text != "" && search_text != null)
		{
			OnTextChanged(e);
			if (!backgroundWorker4.CancellationPending)
			{
				if (!backgroundWorker4.IsBusy)
				{
					pictureBox5.Visible = true;
					dataGridView1.Rows.Clear();
					backgroundWorker4.RunWorkerAsync();
				}
				else
				{
					backgroundWorker4.CancelAsync();
				}
			}
		}
		else
		{
			dataGridView1.Rows.Clear();
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Form3 form = new Form3();
		form.Show();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		search_flag = true;
		if (textBox1.Text == null || textBox1.Text == "")
		{
			return;
		}
		using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			dataGridView1.Rows.Clear();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(inStream);
			string text = textBox1.Text;
			string text2 = "";
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
			XmlElement xmlElement = null;
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				ListViewItem listViewItem = new ListViewItem();
				string[] array = new string[9];
				XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
				XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
				XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
				XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
				XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
				XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
				XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
				XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
				array[0] = xmlElement2.GetAttribute("id");
				array[1] = xmlElement7.InnerText;
				array[2] = xmlElement3.InnerText;
				array[3] = xmlElement4.InnerText;
				array[4] = xmlElement8.InnerText;
				array[5] = xmlElement9.InnerText;
				array[6] = xmlElement6.InnerText;
				array[7] = xmlElement5.InnerText;
				array[8] = xmlElement10.InnerText;
				switch (comboBox1.Text)
				{
				case "Workorder":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
					text2 = "wo";
					break;
				case "Functional Class":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
					text2 = "fc";
					break;
				case "User":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
					text2 = "user";
					break;
				case "Comments":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
					break;
				case "Controlled Access":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
					text2 = "ca";
					break;
				case "Lane Type/Attribute":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
					break;
				case "JIRA No.":
					xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
					break;
				}
				string text3 = textBox1.Text.Replace(" ", "_").ToLower();
				int num = xmlElement2.GetAttribute("id").LastIndexOf("_") + 1;
				if (xmlElement.InnerText.Contains(text3) && xmlElement3.InnerText.Contains(comboBox2.Text.ToLower()))
				{
					dataGridView1.Rows.Add(xmlElement2.GetAttribute("id").Substring(num, xmlElement2.GetAttribute("id").Length - num));
				}
			}
			toolStripStatusLabel1.Text = "Returned " + dataGridView1.Rows.Count + " Result(s)..";
			dataGridView1.ClearSelection();
			search_flag = false;
		}
		catch (Exception ex)
		{
			toolStripStatusLabel1.Text = "Error occured " + ex.Message;
		}
	}

	private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
		}
	}

	private void textBox2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
		}
	}

	private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
		}
	}

	private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
	{
		systemwatcherflah = true;
		if (!backgroundWorker2.IsBusy)
		{
			dataGridView3.Rows.Clear();
			backgroundWorker2.RunWorkerAsync();
		}
		if (dataGridView1.Rows.Count < 1)
		{
			contextMenuStrip1.Items[1].Enabled = false;
		}
		else
		{
			contextMenuStrip1.Items[1].Enabled = true;
		}
	}

	private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = DialogResult.None;
		string text = dataGridView1.SelectedCells[0].Value.ToString();
		dialogResult = MessageBox.Show("Delete Update - " + text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		try
		{
			delflag = true;
			XmlDocument xmlDocument = new XmlDocument();
			using (FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.ReadWrite))
			{
				xmlDocument.Load(inStream);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
				for (int i = 0; i < elementsByTagName.Count; i++)
				{
					XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
					int num = xmlElement.GetAttribute("id").LastIndexOf("_") + 1;
					if (xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num) == text)
					{
						xmlDocument.DocumentElement.RemoveChild(xmlElement);
						pictureBox1.Image = null;
						pictureBox2.Image = null;
						break;
					}
				}
			}
			xmlDocument.Save(variable_path);
			MessageBox.Show(text + " Removed.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			delflag = false;
		}
		catch (Exception)
		{
			toolStripStatusLabel1.Text = "Error Removing " + text + "...";
		}
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
		AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
		AutoCompleteStringCollection autoCompleteStringCollection3 = new AutoCompleteStringCollection();
		switch (comboBox1.SelectedIndex)
		{
		case 2:
			textBox1.Items.Clear();
			textBox1.Items.Add("1");
			textBox1.Items.Add("2");
			textBox1.Items.Add("3");
			textBox1.Items.Add("4");
			textBox1.Items.Add("5");
			textBox1.Items.Add("6");
			break;
		case 3:
			textBox1.Items.Clear();
			textBox1.Items.Add("Acceleration");
			textBox1.Items.Add("Auxiliary");
			textBox1.Items.Add("Center Turn");
			textBox1.Items.Add("Deccelration");
			textBox1.Items.Add("Shoulder");
			textBox1.Items.Add("Express");
			textBox1.Items.Add("HOV");
			textBox1.Items.Add("Passing");
			textBox1.Items.Add("Regular");
			textBox1.Items.Add("Regulated Access");
			textBox1.Items.Add("Reversible");
			textBox1.Items.Add("Slow");
			textBox1.Items.Add("Truck Parking");
			textBox1.Items.Add("Turn");
			textBox1.Items.Add("Express plus Acceleration");
			textBox1.Items.Add("Express plus Deccelration");
			textBox1.Items.Add("HOV plus Acceleration");
			textBox1.Items.Add("HOV plus Decceleration");
			textBox1.Items.Add("HOV Express");
			textBox1.Items.Add("HOV Reversible Express");
			textBox1.Items.Add("HOV Plus Reversible");
			textBox1.Items.Add("Variable Driving");
			textBox1.Items.Add("Parking");
			textBox1.Items.Add("Bicycle");
			break;
		case 4:
			textBox1.Items.Clear();
			textBox1.Items.Add("yes");
			textBox1.Items.Add("no");
			textBox1.Items.Add("both");
			break;
		default:
			textBox1.Items.Clear();
			break;
		}
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		systemwatcherflah = true;
		comboBox1.ResetText();
		comboBox2.ResetText();
		textBox1.ResetText();
		dataGridView1.Rows.Clear();
	}

	private void comboBox2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			dataGridView1.Rows.Clear();
			XmlDocument xmlDocument = new XmlDocument();
			string text = "";
			xmlDocument.Load(inStream);
			ListViewItem listViewItem = new ListViewItem();
			string[] array = new string[9];
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
				XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
				array[0] = xmlElement.GetAttribute("id");
				array[2] = xmlElement2.InnerText;
				if (xmlElement2.InnerText.Contains(comboBox2.Text.ToLower()))
				{
					dataGridView1.Rows.Add(xmlElement.GetAttribute("id"));
				}
			}
		}
		catch
		{
		}
	}

	private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button3_Click(null, null);
		}
		else if (e.KeyCode == Keys.Delete)
		{
			button1_Click_1(null, null);
		}
	}

	private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Form3 form = new Form3();
		form.ShowDialog(this);
	}

	private void getcountrybyregion(string text)
	{
		try
		{
			switch (text)
			{
			case "WEU":
			{
				comboBox2.Items.Clear();
				string[] items5 = new string[32]
				{
					"Andorra", "België", "Channel Islands", "Danmark", "Deutschland", "England", "España", "France", "Føroyar", "Gibraltar",
					"Greenland", "Ireland", "Isle of Man", "Italia", "Liechtenstein", "Luxembourg", "Malta", "Monaco", "Nederland", "Norge",
					"Northern Ireland", "Portugal", "San Marino", "Schweiz", "Scotland", "Stato della Città del Vaticano", "Suomi", "Svalbard", "Sverige", "Wales",
					"Ísland", "Österreich"
				};
				comboBox2.Items.AddRange(items5);
				xmldatabase.Properties.Settings.Default.region = "WEU";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
			case "NA":
			{
				comboBox2.Items.Clear();
				string[] items4 = new string[23]
				{
					"Bahamas", "Belize", "Bermuda", "British Virgin Islands", "Canada", "Cayman Islands", "Costa Rica", "Cuba", "El Salvador", "Guatemala",
					"Haiti", "Honduras", "Jamaica", "México", "Nicaragua", "Panamá", "Puerto Rico", "República Dominicana", "Saint Pierre and Miquelon", "Turks and Caicos Islands",
					"US Virgin Islands", "Uninhabited Island", "United States"
				};
				comboBox2.Items.AddRange(items4);
				xmldatabase.Properties.Settings.Default.region = "NA";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
			case "MEA":
			{
				comboBox2.Items.Clear();
				string[] items3 = new string[75]
				{
					"Afghanistan", "Angola", "Botswana", "Burkina Faso", "Burundi", "Bénin", "Cabo Verde", "Comores", "Côte d'Ivoire", "Eritrea",
					"Ethiopia", "Gabon", "Gambia", "Ghana", "Guiné-Bissau", "Guinée Équatoriale", "Guinée", "Iran", "Kenya", "Lesotho",
					"Liberia", "Madagascar", "Malawi", "Mali", "Mauritius", "Mayotte", "Moçambique", "Namibia", "Niger", "Nigeria",
					"Rwanda", "République Centrafricaine", "République Dém. du Congo", "République du Cameroun", "République du Congo", "Réunion", "Seychelles", "Sierra Leone", "South Africa", "South Sudan",
					"St Helena, Ascension, and T. Cunha", "Sudan", "Swaziland", "Syria", "São Tomé e Príncipe", "Sénégal", "Tanzania", "Tchad", "Togo", "Uganda",
					"Uninhabited Island", "Western Sahara", "Yemen", "Zambia", "Zimbabwe", "ישראל", "الأردن", "الإمارات العربية المتحدة", "البحرين", "الجزائر",
					"السعودية", "الصومال", "العراق", "الكويت", "المغرب", "تونس", "جيبوتي", "عمان", "فلسطين", "قطاع غزة",
					"قطر", "لبنان", "ليبيا", "مصر", "موريتانيا"
				};
				comboBox2.Items.AddRange(items3);
				xmldatabase.Properties.Settings.Default.region = "MEA";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
			case "APAC":
			{
				comboBox2.Items.Clear();
				string[] items2 = new string[26]
				{
					"Brunei Darussalam", "Cambodia", "China", "Guam", "Canada", "Indonesia", "Japan", "Laos", "Malaysia", "Mongolia",
					"Myanmar", "North Korea", "Northern Mariana Islands", "Palau", "Papua New Guinea", "Paracel Islands", "Philippines", "Singapore", "Solomon Islands", "South Korea",
					"Spratly Islands", "Timor-Leste", "Việt Nam", "ประเทศไทย", "澳門-中國", "香港-中國"
				};
				comboBox2.Items.AddRange(items2);
				xmldatabase.Properties.Settings.Default.region = "APAC";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
			case "EEU":
			{
				comboBox2.Items.Clear();
				string[] items = new string[35]
				{
					"Azərbaycan", "Bosna i Hercegovina", "British Sovereign Base Areas", "Crna Gora", "Eesti", "Hrvatska", "Kosovë", "Kyrgyzstan", "Kıbrıs Türk Yönetimi", "Latvija",
					"Lietuva", "Magyarország", "Moldova", "O'zbekiston", "Polska", "România", "Shqipëria", "Slovenija", "Slovenská republika", "Tajikistan",
					"Turkmenistan", "Türkiye", "Česká republika", "Ελλάδα", "Κυπρος", "Παρεμβαλλομενη γραμμη Ο.Η.Ε. Κυπρου", "Беларусь", "България", "П. Југословенска Репуб. Македонија", "Россия",
					"Србија", "Україна", "Қазақстан", "Հայաստան", "საქართველო"
				};
				comboBox2.Items.AddRange(items);
				xmldatabase.Properties.Settings.Default.region = "EEU";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				break;
			}
			}
			Text = "Update Repo Tool - Region : " + xmldatabase.Properties.Settings.Default.region;
		}
		catch
		{
			MessageBox.Show("Error fetching country names..");
		}
	}

	private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		getcountrybyregion(toolStripComboBox1.Text);
		toolStripStatusLabel1.Text = "Selected Region - " + xmldatabase.Properties.Settings.Default.region;
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!isexit && e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			base.WindowState = FormWindowState.Minimized;
		}
		xmldatabase.Properties.Settings.Default.Save();
		xmldatabase.Properties.Settings.Default.Reload();
	}

	private void button2_Click_2(object sender, EventArgs e)
	{
	}

	private void fileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		add_update add_update2 = new add_update();
		add_update2.Show();
	}

	private void exportToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void changeRegionToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Settings settings = new Settings();
		settings.Show();
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			switch (xmldatabase.Properties.Settings.Default.region)
			{
			case "WEU":
			{
				string[] range5 = new string[32]
				{
					"Andorra", "België", "Channel Islands", "Danmark", "Deutschland", "England", "España", "France", "Føroyar", "Gibraltar",
					"Greenland", "Ireland", "Isle of Man", "Italia", "Liechtenstein", "Luxembourg", "Malta", "Monaco", "Nederland", "Norge",
					"Northern Ireland", "Portugal", "San Marino", "Schweiz", "Scotland", "Stato della Città del Vaticano", "Suomi", "Svalbard", "Sverige", "Wales",
					"Ísland", "Österreich"
				};
				xmldatabase.Properties.Settings.Default.region = "WEU";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				Setrange(range5);
				break;
			}
			case "NA":
			{
				string[] range4 = new string[23]
				{
					"Bahamas", "Belize", "Bermuda", "British Virgin Islands", "Canada", "Cayman Islands", "Costa Rica", "Cuba", "El Salvador", "Guatemala",
					"Haiti", "Honduras", "Jamaica", "México", "Nicaragua", "Panamá", "Puerto Rico", "República Dominicana", "Saint Pierre and Miquelon", "Turks and Caicos Islands",
					"US Virgin Islands", "Uninhabited Island", "United States"
				};
				xmldatabase.Properties.Settings.Default.region = "NA";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				Setrange(range4);
				break;
			}
			case "MEA":
			{
				string[] range3 = new string[75]
				{
					"Afghanistan", "Angola", "Botswana", "Burkina Faso", "Burundi", "Bénin", "Cabo Verde", "Comores", "Côte d'Ivoire", "Eritrea",
					"Ethiopia", "Gabon", "Gambia", "Ghana", "Guiné-Bissau", "Guinée Équatoriale", "Guinée", "Iran", "Kenya", "Lesotho",
					"Liberia", "Madagascar", "Malawi", "Mali", "Mauritius", "Mayotte", "Moçambique", "Namibia", "Niger", "Nigeria",
					"Rwanda", "République Centrafricaine", "République Dém. du Congo", "République du Cameroun", "République du Congo", "Réunion", "Seychelles", "Sierra Leone", "South Africa", "South Sudan",
					"St Helena, Ascension, and T. Cunha", "Sudan", "Swaziland", "Syria", "São Tomé e Príncipe", "Sénégal", "Tanzania", "Tchad", "Togo", "Uganda",
					"Uninhabited Island", "Western Sahara", "Yemen", "Zambia", "Zimbabwe", "ישראל", "الأردن", "الإمارات العربية المتحدة", "البحرين", "الجزائر",
					"السعودية", "الصومال", "العراق", "الكويت", "المغرب", "تونس", "جيبوتي", "عمان", "فلسطين", "قطاع غزة",
					"قطر", "لبنان", "ليبيا", "مصر", "موريتانيا"
				};
				xmldatabase.Properties.Settings.Default.region = "MEA";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				Setrange(range3);
				break;
			}
			case "APAC":
			{
				string[] range2 = new string[26]
				{
					"Brunei Darussalam", "Cambodia", "China", "Guam", "Canada", "Indonesia", "Japan", "Laos", "Malaysia", "Mongolia",
					"Myanmar", "North Korea", "Northern Mariana Islands", "Palau", "Papua New Guinea", "Paracel Islands", "Philippines", "Singapore", "Solomon Islands", "South Korea",
					"Spratly Islands", "Timor-Leste", "Việt Nam", "ประเทศไทย", "澳門-中國", "香港-中國"
				};
				xmldatabase.Properties.Settings.Default.region = "APAC";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				Setrange(range2);
				break;
			}
			case "EEU":
			{
				string[] range = new string[35]
				{
					"Azərbaycan", "Bosna i Hercegovina", "British Sovereign Base Areas", "Crna Gora", "Eesti", "Hrvatska", "Kosovë", "Kyrgyzstan", "Kıbrıs Türk Yönetimi", "Latvija",
					"Lietuva", "Magyarország", "Moldova", "O'zbekiston", "Polska", "România", "Shqipëria", "Slovenija", "Slovenská republika", "Tajikistan",
					"Turkmenistan", "Türkiye", "Česká republika", "Ελλάδα", "Κυπρος", "Παρεμβαλλομενη γραμμη Ο.Η.Ε. Κυπρου", "Беларусь", "България", "П. Југословенска Репуб. Македонија", "Россия",
					"Србија", "Україна", "Қазақстан", "Հայաստան", "საქართველო"
				};
				xmldatabase.Properties.Settings.Default.region = "EEU";
				xmldatabase.Properties.Settings.Default.Save();
				xmldatabase.Properties.Settings.Default.Reload();
				Setrange(range);
				break;
			}
			}
		}
		catch
		{
			MessageBox.Show("Error fetching country names..");
		}
	}

	public void populatecombobox(string[] arr)
	{
		comboBox2.Items.Clear();
		comboBox2.BeginUpdate();
		comboBox2.Items.AddRange(arr);
		comboBox2.EndUpdate();
		Text = "Update Repo Tool - Region : " + xmldatabase.Properties.Settings.Default.region;
	}

	private void Calculate(int i)
	{
		double num = Math.Pow(i, i);
	}

	private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
	{
		try
		{
			File.Copy(variable_path, saveFileDialog1.FileName);
			Process.Start("excel.exe", saveFileDialog1.FileName);
		}
		catch (Exception ex)
		{
			toolStripStatusLabel1.Text = "Error exporting data.. " + ex.Message;
		}
	}

	public void SendLyncMessage()
	{
	}

	private void button5_Click(object sender, EventArgs e)
	{
		loadstreams2();
	}

	private void Setrange(string[] range)
	{
		if (comboBox2.InvokeRequired)
		{
			Setcountrynames method = Setrange;
			Invoke(method, new object[1] { range });
		}
		else
		{
			comboBox2.Enabled = false;
			comboBox2.Items.AddRange(range);
		}
	}

	private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(inStream);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
				int count = elementsByTagName.Count;
				while (count-- > 0)
				{
					if (count >= elementsByTagName.Count - 5)
					{
						XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[count];
						XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[count];
						XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[count];
						int num = xmlElement.GetAttribute("id").LastIndexOf("_") + 1;
						string text = xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num);
						string innerText = xmlElement3.InnerText;
						string innerText2 = xmlElement2.InnerText;
						Setlist(text, innerText, innerText2);
						continue;
					}
					dataGridView3.ClearSelection();
					break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error occured :\n\n" + ex.Message);
			}
		}
		catch
		{
		}
	}

	private void Setlist(string text, string text2, string text3)
	{
		if (dataGridView3.InvokeRequired)
		{
			SetTextCallback method = Setlist;
			Invoke(method, text, text2, text3);
		}
		else
		{
			pictureBox5.Visible = true;
			dataGridView3.Rows.Add(text3, text2, text);
		}
	}

	private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		backgroundWorker2.Dispose();
		systemwatcherflah = false;
		pictureBox5.Visible = false;
		dataGridView1.Visible = true;
		onload = false;
		dataGridView1.Enabled = true;
		toolStripStatusLabel1.Text = "Fetched " + dataGridView1.Rows.Count + " Update(s). Last Sync time - " + DateTime.Now.ToShortTimeString();
		notifyIcon1.ShowBalloonTip(500, "URT Synced Successfully", "Update(s) Fetched - " + dataGridView1.Rows.Count + "\nLast Sync Time - " + DateTime.Now.ToShortTimeString(), ToolTipIcon.Info);
		textBox2.Enabled = true;
		notifyIcon1.Visible = false;
		notifyIcon1.Dispose();
		if (dataGridView1.Rows.Count == 0)
		{
			contextMenuStrip1.Items[1].Enabled = false;
		}
		else
		{
			contextMenuStrip1.Items[1].Enabled = true;
		}
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		backgroundWorker1.CancelAsync();
		backgroundWorker1.Dispose();
		comboBox2.Enabled = true;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(pvid.Text);
	}

	private void jira_work()
	{
	}

	private void getjira_DoWork(object sender, DoWorkEventArgs e)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		try
		{
			if (this.val.key != "null" && this.val.key != "")
			{
				Jira val = new Jira();
				val.Connect(xmldatabase.Properties.Settings.Default.mapops, xmldatabase.Properties.Settings.Default.jirauser, xmldatabase.Properties.Settings.Default.jirapass);
				Issue issue = val.GetIssue(this.val.key);
				SetText2(issue.get_Fields().get_IssueType().get_Name(), issue.get_Fields().get_Reporter().get_Fullname(), issue.GetCustomFieldValue("PVID"), issue.get_Fields().get_Assignee().get_Fullname(), issue.GetCustomFieldValue("Work Order"), issue.get_Description(), issue.GetCustomFieldValue("Expert Resolution"));
			}
			else
			{
				toolStripStatusLabel2.Text = "No Data Fetched..";
				this.val.key = "";
			}
		}
		catch (Exception ex)
		{
			toolStripStatusLabel2.Text = "No Data Fetched.." + ex.Message;
		}
	}

	private void SetText2(string text1, string text2, string text3, string text4, string text5, string text6, string text7)
	{
		if (type.InvokeRequired && wotex.InvokeRequired && addign.InvokeRequired && reporter.InvokeRequired && pvid.InvokeRequired && desc.InvokeRequired && exres.InvokeRequired)
		{
			SetTextCallback2 method = SetText2;
			Invoke(method, text1, text2, text3, text4, text5, text6, text7);
		}
		else
		{
			type.Text = text1;
			wotex.Text = text5;
			addign.Text = text4;
			reporter.Text = text2;
			pvid.Text = text3;
			desc.Text = text6;
			exres.Text = text7;
			toolStripStatusLabel2.Text = "Data Fetched Successfully..";
		}
	}

	private void getjira_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		getjira.CancelAsync();
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (pictureBox1.Image != null)
		{
			string tempFileName = Path.GetTempFileName();
			xmldatabase.Properties.Settings.Default.tempi1 = tempFileName;
			pictureBox1.Image.Save(tempFileName);
			Image1 image = new Image1();
			image.Show();
		}
	}

	private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (pictureBox2.Image != null)
		{
			string tempFileName = Path.GetTempFileName();
			xmldatabase.Properties.Settings.Default.tempi2 = tempFileName;
			pictureBox2.Image.Save(tempFileName);
			Image2 image = new Image2();
			image.Show();
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		if (dataGridView1.Rows.Count > 0)
		{
			ua.country = textBox4.Text;
			ua.wo = textBox5.Text;
			ua.lane = textBox9.Text;
			ua.user = textBox6.Text;
			ua.fc = textBox7.Text;
			ua.ca = textBox8.Text;
			ua.key = textBox10.Text;
			ua.comment = textBox12.Text;
			ua.sdate = dateTimePicker1.Text;
			try
			{
				if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower()))
				{
					Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower());
				}
				if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower()))
				{
					Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower());
				}
				if (textBox13.Text != null && textBox13.Text != "" && pictureBox3.Image != null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg");
					}
					ua.pre = xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg";
					pictureBox3.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg");
				}
				else if (val.pre == null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img1.jpg");
					}
					ua.pre = null;
				}
				if (textBox14.Text != null && textBox14.Text != "" && pictureBox4.Image != null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg");
					}
					ua.post = xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg";
					pictureBox4.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg");
				}
				else if (val.post == null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox3.Text.ToLower() + "/_img2.jpg");
					}
					ua.post = null;
				}
				if (textBox15.Text != null && textBox15.Text != "" && richTextBox2.Text != null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg");
					}
					ua.mail = xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg";
					File.Copy(openFileDialog3.FileName, xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg");
				}
				else if (val.mail == null)
				{
					if (File.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg"))
					{
						File.Delete(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox3.Text.ToLower() + "/_trail.msg");
					}
					ua.mail = null;
				}
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					using (FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
					{
						try
						{
							xmlDocument.Load(inStream);
							XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
							for (int i = 0; i < elementsByTagName.Count; i++)
							{
								XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
								XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
								XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
								XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
								XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
								XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
								XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
								XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
								XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
								XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
								XmlElement xmlElement11 = (XmlElement)xmlDocument.GetElementsByTagName("pre_i")[i];
								XmlElement xmlElement12 = (XmlElement)xmlDocument.GetElementsByTagName("psot_i")[i];
								XmlElement xmlElement13 = (XmlElement)xmlDocument.GetElementsByTagName("mail")[i];
								int num = xmlElement.GetAttribute("id").LastIndexOf("_") + 1;
								textBox16.Text = xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num);
								if (xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num) == ua.id)
								{
									xmlElement2.InnerText = ua.country;
									xmlElement3.InnerText = ua.wo;
									xmlElement4.InnerText = ua.fc;
									xmlElement10.InnerText = ua.key;
									xmlElement6.InnerText = ua.lane;
									xmlElement8.InnerText = ua.sdate;
									xmlElement9.InnerText = ua.comment;
									xmlElement5.InnerText = ua.ca;
									xmlElement7.InnerText = ua.user;
									if (ua.pre != null)
									{
										xmlElement11.InnerText = ua.pre;
									}
									else
									{
										xmlElement11.InnerText = val.pre;
									}
									if (ua.post != null)
									{
										xmlElement12.InnerText = ua.post;
									}
									else
									{
										xmlElement12.InnerText = val.post;
									}
									if (ua.mail != null)
									{
										xmlElement13.InnerText = ua.mail;
									}
									else
									{
										xmlElement13.InnerText = val.mail;
									}
									break;
								}
							}
							MessageBox.Show(ua.id + " Updated..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					xmlDocument.Save(variable_path);
					return;
				}
				catch
				{
					return;
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				return;
			}
		}
		MessageBox.Show("no item selected");
	}

	private void update_details_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		update_details_worker.CancelAsync();
	}

	private void button4_Click_1(object sender, EventArgs e)
	{
		openFileDialog1.ShowDialog();
	}

	private void button5_Click_1(object sender, EventArgs e)
	{
		openFileDialog2.ShowDialog();
	}

	private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
	{
		textBox13.Text = openFileDialog1.FileName;
		pictureBox3.ImageLocation = openFileDialog1.FileName;
	}

	private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
	{
		textBox14.Text = openFileDialog2.FileName;
		pictureBox4.ImageLocation = openFileDialog2.FileName;
	}

	private void button7_Click(object sender, EventArgs e)
	{
		pictureBox3.Image = null;
		val.pre = null;
		ua.pre = null;
	}

	private void button8_Click(object sender, EventArgs e)
	{
		pictureBox4.Image = null;
		val.post = null;
		ua.post = null;
	}

	private void Setweb(string text1)
	{
		if (richTextBox1.InvokeRequired && richTextBox2.InvokeRequired)
		{
			SetwebCallback2 method = Setweb;
			Invoke(method, text1);
		}
		else
		{
			richTextBox1.Text = text1;
			richTextBox2.Text = text1;
			toolStripStatusLabel3.Text = "Mail data fetched Successfully..";
		}
	}

	private void getmaildets_DoWork(object sender, DoWorkEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		try
		{
			Message val = new Message(this.val.mail, FileAccess.Read);
			Setweb(val.get_BodyText());
			((Storage)val).Dispose();
		}
		catch
		{
		}
	}

	private void button10_Click(object sender, EventArgs e)
	{
		openFileDialog3.ShowDialog();
	}

	private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		Message val = new Message(openFileDialog3.FileName, FileAccess.Read);
		textBox15.Text = openFileDialog3.FileName;
		richTextBox2.Text = val.get_BodyText();
		((Storage)val).Dispose();
	}

	private void button9_Click(object sender, EventArgs e)
	{
		richTextBox2.Text = "";
		val.mail = null;
		ua.mail = null;
	}

	private void fileSystemWatcher2_Changed(object sender, FileSystemEventArgs e)
	{
		try
		{
		}
		catch
		{
		}
	}

	private void listView1_MouseEnter(object sender, EventArgs e)
	{
	}

	private void quickSearchToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		toolStripStatusLabel1.Text = "Q-Search Enabled. Enter characters to start searching..";
		textBox2.Clear();
		textBox2.Focus();
	}

	private void dataToolStripMenuItem_Click(object sender, EventArgs e)
	{
		saveFileDialog1.ShowDialog();
	}

	private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		saveFileDialog2.ShowDialog();
	}

	private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
	{
		if (!File.Exists(saveFileDialog2.FileName))
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(saveFileDialog2.FileName, Encoding.UTF8);
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Settings");
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.Close();
			xmlTextWriter.Dispose();
			FileStream fileStream = new FileStream(saveFileDialog2.FileName, FileMode.Open);
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(fileStream);
				XmlElement xmlElement = xmlDocument.CreateElement("setting");
				XmlElement xmlElement2 = xmlDocument.CreateElement("path");
				XmlElement xmlElement3 = xmlDocument.CreateElement("group");
				XmlElement xmlElement4 = xmlDocument.CreateElement("mail_c");
				XmlElement xmlElement5 = xmlDocument.CreateElement("region");
				XmlText newChild = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path);
				XmlText newChild2 = xmlDocument.CreateTextNode(email.Default.to);
				XmlText newChild3 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.emailconfirm.ToString());
				XmlText newChild4 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.region);
				xmlElement2.AppendChild(newChild);
				xmlElement3.AppendChild(newChild2);
				xmlElement4.AppendChild(newChild3);
				xmlElement5.AppendChild(newChild4);
				xmlElement.AppendChild(xmlElement2);
				xmlElement.AppendChild(xmlElement3);
				xmlElement.AppendChild(xmlElement4);
				xmlElement.AppendChild(xmlElement5);
				xmlDocument.DocumentElement.AppendChild(xmlElement);
				fileStream.Close();
				fileStream.Dispose();
				xmldatabase.Properties.Settings.Default.Save();
				email.Default.Save();
				backup.Default.Save();
				xmlDocument.Save(saveFileDialog2.FileName);
				MessageBox.Show("Settings Exported Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Occured : \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				fileStream.Close();
				fileStream.Dispose();
			}
		}
	}

	private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		openFileDialog5.ShowDialog();
	}

	private void openFileDialog5_FileOk(object sender, CancelEventArgs e)
	{
		loadsettings(openFileDialog5.FileName);
	}

	private void dataToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = MessageBox.Show("Importing backup zip replaces existing entries.\nThis feature is to be used when existing data needs to be migrated to different path.\n\nProcced with CAUTION!\nImport Backup Zip ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult == DialogResult.Yes)
		{
			openFileDialog4.ShowDialog();
		}
	}

	private void Form1_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Move;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void Form1_DragDrop(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, autoConvert: false);
		if (Path.GetExtension(array[0]) == ".xmls")
		{
			DialogResult dialogResult = MessageBox.Show("Import Settings file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				loadsettings(array[0]);
			}
		}
	}

	private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (tabControl1.SelectedTab == tabPage2)
		{
			try
			{
				Process.Start(xmldatabase.Properties.Settings.Default.mapops + "/browse/" + val.key);
			}
			catch
			{
			}
		}
		if (tabControl1.SelectedTab == tabPage6)
		{
			try
			{
				Process.Start(val.mail);
			}
			catch
			{
			}
		}
	}

	private void button11_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(textBox16.Text);
		toolStripStatusLabel1.Text = "UID Copied";
	}

	private void copyUIDToolStripMenuItem_Click(object sender, EventArgs e)
	{
		button11_Click(null, null);
	}

	private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		backup_ backup_2 = new backup_();
		backup_2.ShowDialog(this);
	}

	private void mapOpsJIRAToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Form2 form = new Form2();
		form.ShowDialog();
	}

	private void logToolStripMenuItem_Click(object sender, EventArgs e)
	{
		monitor monitor2 = new monitor();
		monitor2.Show();
	}

	private void accessToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		signin signin2 = new signin();
		signin2.ShowDialog(this);
	}

	private void eMailToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Update_existing update_existing = new Update_existing();
		update_existing.ShowDialog(this);
	}

	private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void copyImage1ToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Clipboard.SetImage(pictureBox1.Image);
	}

	private void copyImage2ToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void toolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Clipboard.SetImage(pictureBox2.Image);
	}

	private void copyToStickyNotesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
		}
		catch
		{
			MessageBox.Show("Error occured while starting Sticky notes..");
		}
	}

	private void access_DoWork(object sender, DoWorkEventArgs e)
	{
		check_access();
	}

	private void wordToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void createTextFileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			Process.Start("C:\\Windows\\Sysnative\\notepad.exe");
			Thread.Sleep(500);
			SendKeys.SendWait("^n");
			Clipboard.SetText("Country : " + val.country + Environment.NewLine + "Attribute : " + val.lane + Environment.NewLine + "Workorder : " + val.wo + Environment.NewLine + "UID : " + val.uid + Environment.NewLine + Environment.NewLine + "Comments : " + Environment.NewLine + val.comment);
			SendKeys.SendWait("^v");
		}
		catch
		{
			MessageBox.Show("Error occured while starting notepad..");
		}
	}

	private void fontToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void fontDialog1_Apply(object sender, EventArgs e)
	{
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void dataGridView1_SelectionChanged(object sender, EventArgs e)
	{
		dataGridView1.Refresh();
		dataGridView2.Rows.Clear();
		try
		{
			if (dataGridView1.SelectedCells.Count >= 2 || onload || search_flag || systemwatcherflah || delflag)
			{
				return;
			}
			toolStripStatusLabel1.Text = "-";
			using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
			pictureBox1.Image = Resources.demo_wait;
			pictureBox2.Image = Resources.demo_wait;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(inStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
			Access.Default.id = dataGridView1.SelectedCells[0].Value.ToString();
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				bool flag = false;
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
				XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
				XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
				XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
				XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
				XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
				XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
				XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
				XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
				XmlElement xmlElement11 = (XmlElement)xmlDocument.GetElementsByTagName("pre_i")[i];
				XmlElement xmlElement12 = (XmlElement)xmlDocument.GetElementsByTagName("psot_i")[i];
				XmlElement xmlElement13 = (XmlElement)xmlDocument.GetElementsByTagName("mail")[i];
				int num = xmlElement.GetAttribute("id").LastIndexOf("_") + 1;
				textBox16.Text = xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num);
				if (xmlElement11.InnerText == null || xmlElement12.InnerText == null || !(xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num) == dataGridView1.SelectedCells[0].Value.ToString()))
				{
					continue;
				}
				val.uid = xmlElement.GetAttribute("id").Substring(num, xmlElement.GetAttribute("id").Length - num);
				ua.id = dataGridView1.SelectedCells[0].Value.ToString();
				val.country = xmlElement2.InnerText;
				val.wo = xmlElement3.InnerText;
				val.fc = xmlElement4.InnerText;
				val.ca = xmlElement5.InnerText;
				val.lane = xmlElement6.InnerText;
				val.user = xmlElement7.InnerText;
				val.sdate = xmlElement8.InnerText;
				val.comment = xmlElement9.InnerText;
				val.mail = xmlElement13.InnerText;
				string[] array = new string[7] { xmlElement2.InnerText, xmlElement3.InnerText, xmlElement7.InnerText, xmlElement8.InnerText, xmlElement5.InnerText, xmlElement4.InnerText, xmlElement10.InnerText };
				dataGridView2.Rows.Add("Country", xmlElement2.InnerText);
				dataGridView2.Rows.Add("Work Order", xmlElement3.InnerText);
				dataGridView2.Rows.Add("User", xmlElement7.InnerText);
				dataGridView2.Rows.Add("Submit Date", xmlElement8.InnerText);
				dataGridView2.Rows.Add("Controlled Access", xmlElement5.InnerText);
				dataGridView2.Rows.Add("Functional Class", xmlElement4.InnerText);
				dataGridView2.Rows.Add("JIRA Key", xmlElement10.InnerText);
				textBox11.Text = val.comment;
				textBox3.Text = ua.id;
				textBox5.Text = val.wo;
				textBox4.Text = val.country;
				textBox7.Text = val.fc;
				textBox8.Text = val.ca;
				textBox9.Text = val.lane;
				textBox6.Text = val.user;
				dateTimePicker1.Text = val.sdate;
				if (val.mail != null && val.mail != "")
				{
					xmldatabase.Properties.Settings.Default.lastmailpath = val.mail;
					xmldatabase.Properties.Settings.Default.Save();
					xmldatabase.Properties.Settings.Default.Reload();
					if (!getmaildets.IsBusy)
					{
						getmaildets.RunWorkerAsync();
					}
				}
				else
				{
					richTextBox1.Text = "";
					richTextBox2.Text = "";
					toolStripStatusLabel3.Text = "-";
				}
				textBox12.Text = val.comment;
				type.ResetText();
				wotex.ResetText();
				addign.ResetText();
				reporter.ResetText();
				desc.ResetText();
				exres.ResetText();
				pvid.ResetText();
				toolStripStatusLabel2.Text = "";
				if (xmlElement10.InnerText != "null" && xmlElement10.InnerText != "" && xmlElement10.InnerText != null)
				{
					flag = true;
					val.key = xmlElement10.InnerText;
					toolStripStatusLabel2.Text = "Fetching data for " + xmlElement10.InnerText + "..";
					textBox10.Text = val.key;
					xmldatabase.Properties.Settings.Default.Save();
					xmldatabase.Properties.Settings.Default.Reload();
					if (!getjira.IsBusy && flag)
					{
						getjira.RunWorkerAsync();
					}
				}
				else if (xmlElement10.InnerText == "null")
				{
					val.key = "null";
				}
				if (xmlElement11.InnerText != null && xmlElement11.InnerText != "")
				{
					pictureBox1.ImageLocation = xmlElement11.InnerText;
					val.pre = xmlElement11.InnerText;
					pictureBox3.ImageLocation = val.pre;
				}
				else if (xmlElement11.InnerText == null || xmlElement11.InnerText == "")
				{
					pictureBox1.Image = null;
				}
				if (xmlElement12.InnerText != null && xmlElement12.InnerText != "")
				{
					pictureBox2.ImageLocation = xmlElement12.InnerText;
					val.post = xmlElement12.InnerText;
					pictureBox4.ImageLocation = val.post;
				}
				else if (xmlElement12.InnerText == null || xmlElement12.InnerText == "")
				{
					pictureBox2.Image = null;
				}
				break;
			}
			if (dataGridView1.Rows.Count < 1)
			{
				contextMenuStrip1.Items[1].Enabled = false;
			}
			else if (dataGridView1.Rows.Count > 0)
			{
				contextMenuStrip1.Items[1].Enabled = true;
			}
		}
		catch (Exception ex)
		{
			toolStripStatusLabel1.Text = "Error occured " + ex.Message;
		}
	}

	private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult dialogResult = MessageBox.Show("Exit Application ?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			isexit = true;
			Close();
		}
	}

	private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
	{
		using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(inStream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
				XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
				XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
				XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
				XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
				XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
				XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
				XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
				XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
				XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
				string attribute = xmlElement.GetAttribute("id");
				string text = search_text.Replace(" ", "_").ToLower();
				if (xmlElement.GetAttribute("id").Contains(text) || xmlElement10.InnerText.Contains(text) || xmlElement6.InnerText.Contains(text) || xmlElement7.InnerText.Contains(text) || xmlElement9.InnerText.Contains(text) || xmlElement8.InnerText.Contains(text) || xmlElement10.InnerText.Contains(text))
				{
					dlist.Add(attribute);
					num++;
				}
			}
			Setsearch(dlist);
		}
		catch
		{
		}
	}

	private void Setsearch(List<string> text)
	{
		if (dataGridView1.InvokeRequired)
		{
			SetsearchtCallback method = Setsearch;
			Invoke(method, text);
			return;
		}
		pictureBox5.Visible = true;
		foreach (string item in text)
		{
			string text2 = item;
			int num = item.LastIndexOf("_") + 1;
			dataGridView1.Rows.Insert(0, item.Substring(num, item.Length - num));
		}
	}

	private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		dlist.Clear();
		backgroundWorker4.Dispose();
		pictureBox5.Visible = false;
		toolStripStatusLabel1.Text = "Returned : " + dataGridView1.Rows.Count + " Entry(s)";
		search_text = "";
		dataGridView1.ClearSelection();
		search_flag = false;
	}

	private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			using FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(inStream);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
				for (int i = 0; i < elementsByTagName.Count; i++)
				{
					string[] array = new string[1];
					XmlElement xmlElement = (XmlElement)xmlDocument.GetElementsByTagName("data")[i];
					XmlElement xmlElement2 = (XmlElement)xmlDocument.GetElementsByTagName("country")[i];
					XmlElement xmlElement3 = (XmlElement)xmlDocument.GetElementsByTagName("wo")[i];
					XmlElement xmlElement4 = (XmlElement)xmlDocument.GetElementsByTagName("fc")[i];
					XmlElement xmlElement5 = (XmlElement)xmlDocument.GetElementsByTagName("ca")[i];
					XmlElement xmlElement6 = (XmlElement)xmlDocument.GetElementsByTagName("l_type")[i];
					XmlElement xmlElement7 = (XmlElement)xmlDocument.GetElementsByTagName("user")[i];
					XmlElement xmlElement8 = (XmlElement)xmlDocument.GetElementsByTagName("s_date")[i];
					XmlElement xmlElement9 = (XmlElement)xmlDocument.GetElementsByTagName("comments")[i];
					XmlElement xmlElement10 = (XmlElement)xmlDocument.GetElementsByTagName("key")[i];
					array[0] = xmlElement.GetAttribute("id");
					Setlistup(array);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error occured :\n\n" + ex.Message);
			}
		}
		catch
		{
		}
	}

	private void Setlistup(string[] text)
	{
		if (dataGridView1.InvokeRequired)
		{
			SetListtCallbackup method = Setlistup;
			Invoke(method, new object[1] { text });
		}
		else
		{
			pictureBox5.Visible = true;
			dataGridView1.Rows.Insert(0, text);
		}
	}

	private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		backgroundWorker5.Dispose();
		systemwatcherflah = false;
		pictureBox5.Visible = false;
		dataGridView1.Visible = true;
		onload = false;
		dataGridView1.Enabled = true;
		toolStripStatusLabel1.Text = "Fetched " + dataGridView1.Rows.Count + " Update(s). Last Sync time - " + DateTime.Now.ToShortTimeString();
		notifyIcon1.ShowBalloonTip(500, "URT Synced Successfully", "Update(s) Fetched - " + dataGridView1.Rows.Count + "\nLast Sync Time - " + DateTime.Now.ToShortTimeString(), ToolTipIcon.Info);
		textBox2.Enabled = true;
		notifyIcon1.Visible = false;
		notifyIcon1.Dispose();
		if (dataGridView1.Rows.Count == 0)
		{
			contextMenuStrip1.Items[1].Enabled = false;
		}
		else
		{
			contextMenuStrip1.Items[1].Enabled = true;
		}
	}

	private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
	{
	}

	private void dataGridView1_MouseEnter(object sender, EventArgs e)
	{
		search_flag = false;
		systemwatcherflah = false;
	}

	private void dataGridView1_MouseLeave(object sender, EventArgs e)
	{
	}

	private void textBox2_Enter(object sender, EventArgs e)
	{
		search_flag = true;
	}

	private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		textBox2.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
	}

	private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		dataGridView2.ClearSelection();
	}

	private void Form1_KeyDown(object sender, KeyEventArgs e)
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.Form1));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.changeRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
		this.changeRegionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.backupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.mapOpsJIRAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.eMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.accessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
		this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.dataGridView3 = new System.Windows.Forms.DataGridView();
		this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.attrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.udi = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.exres = new System.Windows.Forms.TextBox();
		this.desc = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.pvid = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.addign = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.reporter = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.wotex = new System.Windows.Forms.TextBox();
		this.type = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.tabPage6 = new System.Windows.Forms.TabPage();
		this.groupBox11 = new System.Windows.Forms.GroupBox();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.statusStrip3 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.groupBox10 = new System.Windows.Forms.GroupBox();
		this.tabControl2 = new System.Windows.Forms.TabControl();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.button7 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.textBox13 = new System.Windows.Forms.TextBox();
		this.label20 = new System.Windows.Forms.Label();
		this.tabPage5 = new System.Windows.Forms.TabPage();
		this.button8 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.textBox14 = new System.Windows.Forms.TextBox();
		this.label21 = new System.Windows.Forms.Label();
		this.tabPage7 = new System.Windows.Forms.TabPage();
		this.richTextBox2 = new System.Windows.Forms.RichTextBox();
		this.button9 = new System.Windows.Forms.Button();
		this.button10 = new System.Windows.Forms.Button();
		this.textBox15 = new System.Windows.Forms.TextBox();
		this.label23 = new System.Windows.Forms.Label();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		this.label22 = new System.Windows.Forms.Label();
		this.button6 = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.textBox12 = new System.Windows.Forms.TextBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label19 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label18 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label17 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.label16 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.copyImage1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.dataGridView2 = new System.Windows.Forms.DataGridView();
		this.param = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.shareWithTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.copyUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.copyToStickyNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.createTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.button1 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.button3 = new System.Windows.Forms.Button();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.statusStrip2 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
		this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
		this.getjira = new System.ComponentModel.BackgroundWorker();
		this.update_details_worker = new System.ComponentModel.BackgroundWorker();
		this.af_update = new System.ComponentModel.BackgroundWorker();
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
		this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
		this.getmaildets = new System.ComponentModel.BackgroundWorker();
		this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
		this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
		this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
		this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
		this.openFileDialog5 = new System.Windows.Forms.OpenFileDialog();
		this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
		this.helpProvider1 = new System.Windows.Forms.HelpProvider();
		this.label24 = new System.Windows.Forms.Label();
		this.fontDialog1 = new System.Windows.Forms.FontDialog();
		this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
		this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
		this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.textBox16 = new System.Windows.Forms.TextBox();
		this.button11 = new System.Windows.Forms.Button();
		this.menuStrip1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.groupBox7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView3).BeginInit();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.tabPage6.SuspendLayout();
		this.groupBox11.SuspendLayout();
		this.statusStrip3.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.groupBox10.SuspendLayout();
		this.tabControl2.SuspendLayout();
		this.tabPage4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		this.tabPage5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		this.tabPage7.SuspendLayout();
		this.groupBox9.SuspendLayout();
		this.groupBox5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.contextMenuStrip3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		this.contextMenuStrip4.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.statusStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher2).BeginInit();
		this.contextMenuStrip2.SuspendLayout();
		this.contextMenuStrip5.SuspendLayout();
		base.SuspendLayout();
		this.menuStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
		this.menuStrip1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.fileToolStripMenuItem, this.importToolStripMenuItem, this.exportToolStripMenuItem, this.searchToolStripMenuItem, this.aboutToolStripMenuItem1, this.toolStripTextBox1, this.exitToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.ShowItemToolTips = true;
		this.menuStrip1.Size = new System.Drawing.Size(1112, 27);
		this.menuStrip1.TabIndex = 3;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fileToolStripMenuItem.Image");
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control;
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
		this.fileToolStripMenuItem.Text = "New Update";
		this.fileToolStripMenuItem.ToolTipText = "Add a new update";
		this.fileToolStripMenuItem.Click += new System.EventHandler(fileToolStripMenuItem_Click);
		this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.settingsToolStripMenuItem1 });
		this.importToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("importToolStripMenuItem.Image");
		this.importToolStripMenuItem.Name = "importToolStripMenuItem";
		this.importToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
		this.importToolStripMenuItem.Text = "Import";
		this.importToolStripMenuItem.ToolTipText = "Provides import functionalities";
		this.settingsToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("settingsToolStripMenuItem1.Image");
		this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
		this.settingsToolStripMenuItem1.ShortcutKeyDisplayString = "";
		this.settingsToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control;
		this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
		this.settingsToolStripMenuItem1.Text = "Settings";
		this.settingsToolStripMenuItem1.Click += new System.EventHandler(settingsToolStripMenuItem1_Click);
		this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.settingsToolStripMenuItem, this.dataToolStripMenuItem });
		this.exportToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("exportToolStripMenuItem.Image");
		this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
		this.exportToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
		this.exportToolStripMenuItem.Text = "Export";
		this.exportToolStripMenuItem.ToolTipText = "Provides various export functionalities";
		this.settingsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("settingsToolStripMenuItem.Image");
		this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
		this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control;
		this.settingsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
		this.settingsToolStripMenuItem.Text = "Settings";
		this.settingsToolStripMenuItem.Click += new System.EventHandler(settingsToolStripMenuItem_Click);
		this.dataToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("dataToolStripMenuItem.Image");
		this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
		this.dataToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.D | System.Windows.Forms.Keys.Control;
		this.dataToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
		this.dataToolStripMenuItem.Text = "Data (Excel)";
		this.dataToolStripMenuItem.Click += new System.EventHandler(dataToolStripMenuItem_Click);
		this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.advancedToolStripMenuItem, this.changeRegionToolStripMenuItem1, this.backupToolStripMenuItem1, this.mapOpsJIRAToolStripMenuItem1, this.eMailToolStripMenuItem, this.toolStripSeparator1, this.accessToolStripMenuItem1, this.logToolStripMenuItem });
		this.searchToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("searchToolStripMenuItem.Image");
		this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
		this.searchToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
		this.searchToolStripMenuItem.Text = "Settings";
		this.searchToolStripMenuItem.ToolTipText = "Change tool settings";
		this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.changeRegionToolStripMenuItem });
		this.advancedToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("advancedToolStripMenuItem.Image");
		this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
		this.advancedToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
		this.advancedToolStripMenuItem.Text = "Region";
		this.changeRegionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripComboBox1 });
		this.changeRegionToolStripMenuItem.Name = "changeRegionToolStripMenuItem";
		this.changeRegionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.changeRegionToolStripMenuItem.Text = "Change Region";
		this.toolStripComboBox1.Items.AddRange(new object[5] { "WEU", "NA", "MEA", "APAC", "EEU" });
		this.toolStripComboBox1.Name = "toolStripComboBox1";
		this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
		this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(toolStripComboBox1_SelectedIndexChanged);
		this.changeRegionToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("changeRegionToolStripMenuItem1.Image");
		this.changeRegionToolStripMenuItem1.Name = "changeRegionToolStripMenuItem1";
		this.changeRegionToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;
		this.changeRegionToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
		this.changeRegionToolStripMenuItem1.Text = "Path";
		this.changeRegionToolStripMenuItem1.ToolTipText = "Change Path";
		this.changeRegionToolStripMenuItem1.Click += new System.EventHandler(changeRegionToolStripMenuItem1_Click);
		this.backupToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("backupToolStripMenuItem1.Image");
		this.backupToolStripMenuItem1.Name = "backupToolStripMenuItem1";
		this.backupToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control;
		this.backupToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
		this.backupToolStripMenuItem1.Text = "Backup";
		this.backupToolStripMenuItem1.ToolTipText = "Change Data backup settings";
		this.backupToolStripMenuItem1.Click += new System.EventHandler(backupToolStripMenuItem1_Click);
		this.mapOpsJIRAToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("mapOpsJIRAToolStripMenuItem1.Image");
		this.mapOpsJIRAToolStripMenuItem1.Name = "mapOpsJIRAToolStripMenuItem1";
		this.mapOpsJIRAToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.J | System.Windows.Forms.Keys.Control;
		this.mapOpsJIRAToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
		this.mapOpsJIRAToolStripMenuItem1.Text = "Map-Ops JIRA";
		this.mapOpsJIRAToolStripMenuItem1.ToolTipText = "Manage/Change Map-Ops Credentials";
		this.mapOpsJIRAToolStripMenuItem1.Click += new System.EventHandler(mapOpsJIRAToolStripMenuItem1_Click);
		this.eMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("eMailToolStripMenuItem.Image");
		this.eMailToolStripMenuItem.Name = "eMailToolStripMenuItem";
		this.eMailToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Alt;
		this.eMailToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
		this.eMailToolStripMenuItem.Text = "E-Mail";
		this.eMailToolStripMenuItem.ToolTipText = "Change E-Mail Settings";
		this.eMailToolStripMenuItem.Click += new System.EventHandler(eMailToolStripMenuItem_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
		this.accessToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("accessToolStripMenuItem1.Image");
		this.accessToolStripMenuItem1.Name = "accessToolStripMenuItem1";
		this.accessToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control;
		this.accessToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
		this.accessToolStripMenuItem1.Text = "Access";
		this.accessToolStripMenuItem1.ToolTipText = "Grant/Revoke Access";
		this.accessToolStripMenuItem1.Click += new System.EventHandler(accessToolStripMenuItem1_Click);
		this.logToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("logToolStripMenuItem.Image");
		this.logToolStripMenuItem.Name = "logToolStripMenuItem";
		this.logToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.L | System.Windows.Forms.Keys.Control;
		this.logToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
		this.logToolStripMenuItem.Text = "Log";
		this.logToolStripMenuItem.ToolTipText = "Activity Log";
		this.logToolStripMenuItem.Click += new System.EventHandler(logToolStripMenuItem_Click);
		this.aboutToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("aboutToolStripMenuItem1.Image");
		this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
		this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(67, 23);
		this.aboutToolStripMenuItem1.Text = "About";
		this.aboutToolStripMenuItem1.ToolTipText = "About tool";
		this.aboutToolStripMenuItem1.Click += new System.EventHandler(aboutToolStripMenuItem1_Click);
		this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
		this.toolStripTextBox1.Name = "toolStripTextBox1";
		this.toolStripTextBox1.ReadOnly = true;
		this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
		this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Firebrick;
		this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 23);
		this.exitToolStripMenuItem.Text = "Exit";
		this.exitToolStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.groupBox7);
		this.groupBox1.Controls.Add(this.tabControl1);
		this.groupBox1.Controls.Add(this.groupBox5);
		this.groupBox1.Controls.Add(this.groupBox2);
		this.groupBox1.Controls.Add(this.groupBox6);
		this.groupBox1.Controls.Add(this.groupBox3);
		this.groupBox1.Location = new System.Drawing.Point(9, 27);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(1091, 683);
		this.groupBox1.TabIndex = 4;
		this.groupBox1.TabStop = false;
		this.groupBox7.Controls.Add(this.dataGridView3);
		this.groupBox7.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox7.Location = new System.Drawing.Point(6, 191);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Size = new System.Drawing.Size(334, 130);
		this.groupBox7.TabIndex = 27;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Recently Added";
		this.dataGridView3.AllowUserToAddRows = false;
		this.dataGridView3.AllowUserToDeleteRows = false;
		this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
		this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView3.Columns.AddRange(this.country, this.attrib, this.udi);
		this.dataGridView3.Cursor = System.Windows.Forms.Cursors.Cross;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView3.Location = new System.Drawing.Point(3, 18);
		this.dataGridView3.MultiSelect = false;
		this.dataGridView3.Name = "dataGridView3";
		this.dataGridView3.ReadOnly = true;
		this.dataGridView3.RowHeadersVisible = false;
		this.dataGridView3.RowHeadersWidth = 25;
		this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView3.ShowCellErrors = false;
		this.dataGridView3.ShowCellToolTips = false;
		this.dataGridView3.ShowEditingIcon = false;
		this.dataGridView3.ShowRowErrors = false;
		this.dataGridView3.Size = new System.Drawing.Size(328, 109);
		this.dataGridView3.TabIndex = 15;
		this.dataGridView3.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView3_CellContentDoubleClick);
		this.country.HeaderText = "Country";
		this.country.Name = "country";
		this.country.ReadOnly = true;
		this.attrib.HeaderText = "Attribute";
		this.attrib.Name = "attrib";
		this.attrib.ReadOnly = true;
		this.udi.HeaderText = "UID";
		this.udi.Name = "udi";
		this.udi.ReadOnly = true;
		this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage6);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.tabControl1.Location = new System.Drawing.Point(346, 418);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(735, 259);
		this.tabControl1.TabIndex = 26;
		this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(tabControl1_MouseDoubleClick);
		this.tabPage1.Controls.Add(this.groupBox4);
		this.tabPage1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tabPage1.Location = new System.Drawing.Point(4, 23);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(727, 232);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Description";
		this.toolTip2.SetToolTip(this.tabPage1, "Provides a detailed view for the selected entry");
		this.groupBox4.Controls.Add(this.textBox11);
		this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox4.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox4.Location = new System.Drawing.Point(3, 3);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(721, 226);
		this.groupBox4.TabIndex = 22;
		this.groupBox4.TabStop = false;
		this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox11.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBox11.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox11.Location = new System.Drawing.Point(3, 18);
		this.textBox11.Multiline = true;
		this.textBox11.Name = "textBox11";
		this.textBox11.ReadOnly = true;
		this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.textBox11.Size = new System.Drawing.Size(715, 205);
		this.textBox11.TabIndex = 15;
		this.textBox11.TabStop = false;
		this.tabPage2.Controls.Add(this.groupBox8);
		this.tabPage2.Location = new System.Drawing.Point(4, 23);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(727, 232);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "JIRA";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.groupBox8.Controls.Add(this.exres);
		this.groupBox8.Controls.Add(this.desc);
		this.groupBox8.Controls.Add(this.label8);
		this.groupBox8.Controls.Add(this.button2);
		this.groupBox8.Controls.Add(this.pvid);
		this.groupBox8.Controls.Add(this.label7);
		this.groupBox8.Controls.Add(this.addign);
		this.groupBox8.Controls.Add(this.label3);
		this.groupBox8.Controls.Add(this.reporter);
		this.groupBox8.Controls.Add(this.label6);
		this.groupBox8.Controls.Add(this.wotex);
		this.groupBox8.Controls.Add(this.type);
		this.groupBox8.Controls.Add(this.label1);
		this.groupBox8.Controls.Add(this.label2);
		this.groupBox8.Controls.Add(this.label9);
		this.groupBox8.Controls.Add(this.statusStrip1);
		this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox8.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox8.Location = new System.Drawing.Point(3, 3);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Size = new System.Drawing.Size(721, 226);
		this.groupBox8.TabIndex = 25;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "JIRA Details";
		this.exres.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.exres.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.exres.Location = new System.Drawing.Point(387, 129);
		this.exres.Multiline = true;
		this.exres.Name = "exres";
		this.exres.ReadOnly = true;
		this.exres.Size = new System.Drawing.Size(331, 60);
		this.exres.TabIndex = 45;
		this.exres.TabStop = false;
		this.desc.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.desc.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.desc.Location = new System.Drawing.Point(9, 129);
		this.desc.Multiline = true;
		this.desc.Name = "desc";
		this.desc.ReadOnly = true;
		this.desc.Size = new System.Drawing.Size(372, 60);
		this.desc.TabIndex = 44;
		this.desc.TabStop = false;
		this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(6, 110);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(69, 14);
		this.label8.TabIndex = 43;
		this.label8.Text = "Description";
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(625, 67);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(46, 25);
		this.button2.TabIndex = 42;
		this.button2.TabStop = false;
		this.button2.Text = "Copy";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.pvid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pvid.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.pvid.Location = new System.Drawing.Point(43, 70);
		this.pvid.Name = "pvid";
		this.pvid.ReadOnly = true;
		this.pvid.Size = new System.Drawing.Size(576, 21);
		this.pvid.TabIndex = 41;
		this.pvid.TabStop = false;
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(6, 75);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(32, 14);
		this.label7.TabIndex = 40;
		this.label7.Text = "PVID";
		this.addign.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.addign.Location = new System.Drawing.Point(449, 39);
		this.addign.Name = "addign";
		this.addign.ReadOnly = true;
		this.addign.Size = new System.Drawing.Size(170, 21);
		this.addign.TabIndex = 39;
		this.addign.TabStop = false;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(446, 22);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(57, 14);
		this.label3.TabIndex = 38;
		this.label3.Text = "Assignee";
		this.reporter.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.reporter.Location = new System.Drawing.Point(263, 39);
		this.reporter.Name = "reporter";
		this.reporter.ReadOnly = true;
		this.reporter.Size = new System.Drawing.Size(180, 21);
		this.reporter.TabIndex = 37;
		this.reporter.TabStop = false;
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(260, 22);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(54, 14);
		this.label6.TabIndex = 36;
		this.label6.Text = "Reporter";
		this.wotex.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.wotex.Location = new System.Drawing.Point(138, 39);
		this.wotex.Name = "wotex";
		this.wotex.ReadOnly = true;
		this.wotex.Size = new System.Drawing.Size(118, 21);
		this.wotex.TabIndex = 24;
		this.wotex.TabStop = false;
		this.type.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.type.Location = new System.Drawing.Point(13, 39);
		this.type.Name = "type";
		this.type.ReadOnly = true;
		this.type.Size = new System.Drawing.Size(116, 21);
		this.type.TabIndex = 23;
		this.type.TabStop = false;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(135, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(67, 14);
		this.label1.TabIndex = 22;
		this.label1.Text = "Work Order";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(10, 22);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(31, 14);
		this.label2.TabIndex = 21;
		this.label2.Text = "Type";
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(384, 112);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(102, 14);
		this.label9.TabIndex = 10;
		this.label9.Text = "Expert Resolution";
		this.statusStrip1.BackColor = System.Drawing.Color.DarkGray;
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel2 });
		this.statusStrip1.Location = new System.Drawing.Point(3, 201);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(715, 22);
		this.statusStrip1.TabIndex = 0;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
		this.toolStripStatusLabel2.Text = "-";
		this.tabPage6.Controls.Add(this.groupBox11);
		this.tabPage6.Location = new System.Drawing.Point(4, 23);
		this.tabPage6.Name = "tabPage6";
		this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage6.Size = new System.Drawing.Size(727, 232);
		this.tabPage6.TabIndex = 3;
		this.tabPage6.Text = "Mail";
		this.groupBox11.Controls.Add(this.richTextBox1);
		this.groupBox11.Controls.Add(this.statusStrip3);
		this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox11.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox11.Location = new System.Drawing.Point(3, 3);
		this.groupBox11.Name = "groupBox11";
		this.groupBox11.Size = new System.Drawing.Size(721, 226);
		this.groupBox11.TabIndex = 2;
		this.groupBox11.TabStop = false;
		this.groupBox11.Text = "Details";
		this.richTextBox1.AutoWordSelection = true;
		this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.richTextBox1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.richTextBox1.Location = new System.Drawing.Point(3, 18);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.ReadOnly = true;
		this.richTextBox1.Size = new System.Drawing.Size(715, 183);
		this.richTextBox1.TabIndex = 2;
		this.richTextBox1.Text = "";
		this.statusStrip3.BackColor = System.Drawing.Color.DarkGray;
		this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel3 });
		this.statusStrip3.Location = new System.Drawing.Point(3, 201);
		this.statusStrip3.Name = "statusStrip3";
		this.statusStrip3.Size = new System.Drawing.Size(715, 22);
		this.statusStrip3.TabIndex = 1;
		this.statusStrip3.Text = "statusStrip3";
		this.toolStripStatusLabel3.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
		this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
		this.toolStripStatusLabel3.Text = "-";
		this.tabPage3.Controls.Add(this.groupBox10);
		this.tabPage3.Controls.Add(this.groupBox9);
		this.tabPage3.Location = new System.Drawing.Point(4, 23);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage3.Size = new System.Drawing.Size(727, 232);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Update";
		this.groupBox10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox10.Controls.Add(this.tabControl2);
		this.groupBox10.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox10.Location = new System.Drawing.Point(430, 6);
		this.groupBox10.Name = "groupBox10";
		this.groupBox10.Size = new System.Drawing.Size(291, 218);
		this.groupBox10.TabIndex = 19;
		this.groupBox10.TabStop = false;
		this.groupBox10.Text = "Attachments";
		this.tabControl2.Controls.Add(this.tabPage4);
		this.tabControl2.Controls.Add(this.tabPage5);
		this.tabControl2.Controls.Add(this.tabPage7);
		this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl2.Location = new System.Drawing.Point(3, 18);
		this.tabControl2.Name = "tabControl2";
		this.tabControl2.SelectedIndex = 0;
		this.tabControl2.Size = new System.Drawing.Size(285, 197);
		this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
		this.tabControl2.TabIndex = 0;
		this.tabPage4.Controls.Add(this.button7);
		this.tabPage4.Controls.Add(this.button4);
		this.tabPage4.Controls.Add(this.pictureBox3);
		this.tabPage4.Controls.Add(this.textBox13);
		this.tabPage4.Controls.Add(this.label20);
		this.tabPage4.Location = new System.Drawing.Point(4, 23);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage4.Size = new System.Drawing.Size(277, 170);
		this.tabPage4.TabIndex = 0;
		this.tabPage4.Text = "Image 1";
		this.button7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button7.Location = new System.Drawing.Point(222, 141);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(49, 23);
		this.button7.TabIndex = 4;
		this.button7.Text = "Del";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click);
		this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button4.Location = new System.Drawing.Point(166, 141);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(50, 23);
		this.button4.TabIndex = 3;
		this.button4.Text = "...";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click_1);
		this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pictureBox3.Location = new System.Drawing.Point(6, 5);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(265, 130);
		this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox3.TabIndex = 2;
		this.pictureBox3.TabStop = false;
		this.textBox13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox13.Location = new System.Drawing.Point(50, 142);
		this.textBox13.Name = "textBox13";
		this.textBox13.ReadOnly = true;
		this.textBox13.Size = new System.Drawing.Size(110, 22);
		this.textBox13.TabIndex = 1;
		this.label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label20.AutoSize = true;
		this.label20.Location = new System.Drawing.Point(6, 145);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(38, 14);
		this.label20.TabIndex = 0;
		this.label20.Text = "Path -";
		this.tabPage5.Controls.Add(this.button8);
		this.tabPage5.Controls.Add(this.button5);
		this.tabPage5.Controls.Add(this.pictureBox4);
		this.tabPage5.Controls.Add(this.textBox14);
		this.tabPage5.Controls.Add(this.label21);
		this.tabPage5.Location = new System.Drawing.Point(4, 23);
		this.tabPage5.Name = "tabPage5";
		this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage5.Size = new System.Drawing.Size(277, 170);
		this.tabPage5.TabIndex = 1;
		this.tabPage5.Text = "Image 2";
		this.button8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button8.Location = new System.Drawing.Point(222, 141);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(49, 23);
		this.button8.TabIndex = 8;
		this.button8.Text = "Del";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(button8_Click);
		this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button5.Location = new System.Drawing.Point(166, 141);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(50, 23);
		this.button5.TabIndex = 7;
		this.button5.Text = "...";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click_1);
		this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pictureBox4.Location = new System.Drawing.Point(6, 5);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(265, 130);
		this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox4.TabIndex = 6;
		this.pictureBox4.TabStop = false;
		this.textBox14.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox14.Location = new System.Drawing.Point(50, 142);
		this.textBox14.Name = "textBox14";
		this.textBox14.ReadOnly = true;
		this.textBox14.Size = new System.Drawing.Size(110, 22);
		this.textBox14.TabIndex = 5;
		this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.label21.AutoSize = true;
		this.label21.Location = new System.Drawing.Point(6, 145);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(38, 14);
		this.label21.TabIndex = 4;
		this.label21.Text = "Path -";
		this.tabPage7.Controls.Add(this.richTextBox2);
		this.tabPage7.Controls.Add(this.button9);
		this.tabPage7.Controls.Add(this.button10);
		this.tabPage7.Controls.Add(this.textBox15);
		this.tabPage7.Controls.Add(this.label23);
		this.tabPage7.Location = new System.Drawing.Point(4, 23);
		this.tabPage7.Name = "tabPage7";
		this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage7.Size = new System.Drawing.Size(277, 170);
		this.tabPage7.TabIndex = 2;
		this.tabPage7.Text = "Mail";
		this.richTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.richTextBox2.Location = new System.Drawing.Point(6, 5);
		this.richTextBox2.Name = "richTextBox2";
		this.richTextBox2.ReadOnly = true;
		this.richTextBox2.Size = new System.Drawing.Size(265, 131);
		this.richTextBox2.TabIndex = 13;
		this.richTextBox2.Text = "";
		this.button9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button9.Location = new System.Drawing.Point(222, 141);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(49, 23);
		this.button9.TabIndex = 12;
		this.button9.Text = "Del";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(button9_Click);
		this.button10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button10.Location = new System.Drawing.Point(166, 141);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(50, 23);
		this.button10.TabIndex = 11;
		this.button10.Text = "...";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(button10_Click);
		this.textBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox15.Location = new System.Drawing.Point(50, 142);
		this.textBox15.Name = "textBox15";
		this.textBox15.ReadOnly = true;
		this.textBox15.Size = new System.Drawing.Size(110, 22);
		this.textBox15.TabIndex = 10;
		this.label23.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label23.AutoSize = true;
		this.label23.Location = new System.Drawing.Point(6, 145);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(38, 14);
		this.label23.TabIndex = 9;
		this.label23.Text = "Path -";
		this.groupBox9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox9.Controls.Add(this.dateTimePicker1);
		this.groupBox9.Controls.Add(this.label22);
		this.groupBox9.Controls.Add(this.button6);
		this.groupBox9.Controls.Add(this.label10);
		this.groupBox9.Controls.Add(this.textBox12);
		this.groupBox9.Controls.Add(this.textBox3);
		this.groupBox9.Controls.Add(this.label19);
		this.groupBox9.Controls.Add(this.label11);
		this.groupBox9.Controls.Add(this.textBox10);
		this.groupBox9.Controls.Add(this.textBox4);
		this.groupBox9.Controls.Add(this.label18);
		this.groupBox9.Controls.Add(this.label12);
		this.groupBox9.Controls.Add(this.textBox9);
		this.groupBox9.Controls.Add(this.textBox5);
		this.groupBox9.Controls.Add(this.label17);
		this.groupBox9.Controls.Add(this.label14);
		this.groupBox9.Controls.Add(this.textBox8);
		this.groupBox9.Controls.Add(this.textBox6);
		this.groupBox9.Controls.Add(this.label16);
		this.groupBox9.Controls.Add(this.label15);
		this.groupBox9.Controls.Add(this.textBox7);
		this.groupBox9.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox9.Location = new System.Drawing.Point(6, 3);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Size = new System.Drawing.Size(418, 221);
		this.groupBox9.TabIndex = 18;
		this.groupBox9.TabStop = false;
		this.groupBox9.Text = "Details";
		this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
		this.dateTimePicker1.Location = new System.Drawing.Point(95, 176);
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Size = new System.Drawing.Size(159, 22);
		this.dateTimePicker1.TabIndex = 20;
		this.label22.AutoSize = true;
		this.label22.Location = new System.Drawing.Point(19, 182);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(40, 14);
		this.label22.TabIndex = 19;
		this.label22.Text = "Date -";
		this.button6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button6.Location = new System.Drawing.Point(332, 189);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(75, 23);
		this.button6.TabIndex = 18;
		this.button6.Text = "Update";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(19, 18);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(26, 14);
		this.label10.TabIndex = 0;
		this.label10.Text = "ID -";
		this.textBox12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox12.Location = new System.Drawing.Point(263, 35);
		this.textBox12.Multiline = true;
		this.textBox12.Name = "textBox12";
		this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.textBox12.Size = new System.Drawing.Size(143, 148);
		this.textBox12.TabIndex = 17;
		this.textBox3.Location = new System.Drawing.Point(95, 15);
		this.textBox3.Name = "textBox3";
		this.textBox3.ReadOnly = true;
		this.textBox3.Size = new System.Drawing.Size(159, 22);
		this.textBox3.TabIndex = 1;
		this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.label19.AutoSize = true;
		this.label19.Location = new System.Drawing.Point(260, 18);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(71, 14);
		this.label19.TabIndex = 16;
		this.label19.Text = "Comments -";
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(19, 41);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(54, 14);
		this.label11.TabIndex = 2;
		this.label11.Text = "Country -";
		this.textBox10.Location = new System.Drawing.Point(95, 153);
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(159, 22);
		this.textBox10.TabIndex = 15;
		this.textBox4.Location = new System.Drawing.Point(95, 38);
		this.textBox4.Name = "textBox4";
		this.textBox4.ReadOnly = true;
		this.textBox4.Size = new System.Drawing.Size(159, 22);
		this.textBox4.TabIndex = 3;
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(19, 156);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(54, 14);
		this.label18.TabIndex = 14;
		this.label18.Text = "JIRA No -";
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(19, 64);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(70, 14);
		this.label12.TabIndex = 4;
		this.label12.Text = "Workorder -";
		this.textBox9.Location = new System.Drawing.Point(95, 84);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(159, 22);
		this.textBox9.TabIndex = 13;
		this.textBox5.Location = new System.Drawing.Point(95, 61);
		this.textBox5.Name = "textBox5";
		this.textBox5.ReadOnly = true;
		this.textBox5.Size = new System.Drawing.Size(159, 22);
		this.textBox5.TabIndex = 5;
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(19, 87);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(62, 14);
		this.label17.TabIndex = 12;
		this.label17.Text = "Attribute -";
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(19, 110);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(39, 14);
		this.label14.TabIndex = 6;
		this.label14.Text = "User -";
		this.textBox8.Location = new System.Drawing.Point(205, 130);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(49, 22);
		this.textBox8.TabIndex = 11;
		this.textBox6.Location = new System.Drawing.Point(95, 107);
		this.textBox6.Name = "textBox6";
		this.textBox6.ReadOnly = true;
		this.textBox6.Size = new System.Drawing.Size(159, 22);
		this.textBox6.TabIndex = 7;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(172, 133);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(27, 14);
		this.label16.TabIndex = 10;
		this.label16.Text = "CA -";
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(19, 133);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(26, 14);
		this.label15.TabIndex = 8;
		this.label15.Text = "FC -";
		this.textBox7.Location = new System.Drawing.Point(95, 130);
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(45, 22);
		this.textBox7.TabIndex = 9;
		this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox5.Controls.Add(this.splitContainer1);
		this.groupBox5.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox5.Location = new System.Drawing.Point(346, 9);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(735, 401);
		this.groupBox5.TabIndex = 24;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Snapshots";
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.splitContainer1.Location = new System.Drawing.Point(6, 17);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
		this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
		this.splitContainer1.Size = new System.Drawing.Size(723, 378);
		this.splitContainer1.SplitterDistance = 371;
		this.splitContainer1.TabIndex = 9;
		this.pictureBox1.ContextMenuStrip = this.contextMenuStrip3;
		this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox1.Location = new System.Drawing.Point(0, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(369, 376);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDoubleClick);
		this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.copyImage1ToolStripMenuItem });
		this.contextMenuStrip3.Name = "contextMenuStrip3";
		this.contextMenuStrip3.Size = new System.Drawing.Size(139, 26);
		this.copyImage1ToolStripMenuItem.Name = "copyImage1ToolStripMenuItem";
		this.copyImage1ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
		this.copyImage1ToolStripMenuItem.Text = "Copy Image";
		this.copyImage1ToolStripMenuItem.Click += new System.EventHandler(copyImage1ToolStripMenuItem_Click);
		this.pictureBox2.ContextMenuStrip = this.contextMenuStrip4;
		this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureBox2.Location = new System.Drawing.Point(0, 0);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(346, 376);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 0;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox2_MouseDoubleClick);
		this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripMenuItem1 });
		this.contextMenuStrip4.Name = "contextMenuStrip3";
		this.contextMenuStrip4.Size = new System.Drawing.Size(139, 26);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
		this.toolStripMenuItem1.Text = "Copy Image";
		this.toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
		this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupBox2.Controls.Add(this.pictureBox5);
		this.groupBox2.Controls.Add(this.dataGridView2);
		this.groupBox2.Controls.Add(this.dataGridView1);
		this.groupBox2.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox2.Location = new System.Drawing.Point(6, 324);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(334, 353);
		this.groupBox2.TabIndex = 23;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Details";
		this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
		this.pictureBox5.Location = new System.Drawing.Point(7, 38);
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.Size = new System.Drawing.Size(320, 147);
		this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.pictureBox5.TabIndex = 13;
		this.pictureBox5.TabStop = false;
		this.dataGridView2.AllowUserToAddRows = false;
		this.dataGridView2.AllowUserToDeleteRows = false;
		this.dataGridView2.AllowUserToOrderColumns = true;
		this.dataGridView2.AllowUserToResizeRows = false;
		this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
		this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView2.Columns.AddRange(this.param, this.value);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView2.Location = new System.Drawing.Point(6, 192);
		this.dataGridView2.Name = "dataGridView2";
		this.dataGridView2.RowHeadersVisible = false;
		this.dataGridView2.RowHeadersWidth = 60;
		this.dataGridView2.Size = new System.Drawing.Size(322, 153);
		this.dataGridView2.TabIndex = 12;
		this.dataGridView2.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dataGridView2_RowsAdded);
		this.param.HeaderText = "Parameter";
		this.param.Name = "param";
		this.param.ReadOnly = true;
		this.value.HeaderText = "Value";
		this.value.Name = "value";
		this.value.ReadOnly = true;
		this.dataGridView1.AllowUserToAddRows = false;
		this.dataGridView1.AllowUserToDeleteRows = false;
		this.dataGridView1.AllowUserToResizeRows = false;
		this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Columns.AddRange(this.id);
		this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
		this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Cross;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView1.Location = new System.Drawing.Point(6, 15);
		this.dataGridView1.MultiSelect = false;
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.ReadOnly = true;
		this.dataGridView1.RowHeadersVisible = false;
		this.dataGridView1.RowHeadersWidth = 25;
		this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView1.ShowCellErrors = false;
		this.dataGridView1.ShowCellToolTips = false;
		this.dataGridView1.ShowEditingIcon = false;
		this.dataGridView1.ShowRowErrors = false;
		this.dataGridView1.Size = new System.Drawing.Size(322, 171);
		this.dataGridView1.TabIndex = 12;
		this.dataGridView1.Visible = false;
		this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
		this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		this.dataGridView1.SelectionChanged += new System.EventHandler(dataGridView1_SelectionChanged);
		this.dataGridView1.MouseEnter += new System.EventHandler(dataGridView1_MouseEnter);
		this.dataGridView1.MouseLeave += new System.EventHandler(dataGridView1_MouseLeave);
		this.id.HeaderText = "Search Results";
		this.id.Name = "id";
		this.id.ReadOnly = true;
		this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.shareWithTeamToolStripMenuItem, this.deleteSelectedToolStripMenuItem, this.copyUIDToolStripMenuItem, this.copyToStickyNotesToolStripMenuItem, this.createTextFileToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(218, 114);
		this.shareWithTeamToolStripMenuItem.Name = "shareWithTeamToolStripMenuItem";
		this.shareWithTeamToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Control;
		this.shareWithTeamToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
		this.shareWithTeamToolStripMenuItem.Text = "Share";
		this.shareWithTeamToolStripMenuItem.Click += new System.EventHandler(shareWithTeamToolStripMenuItem_Click);
		this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
		this.deleteSelectedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
		this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
		this.deleteSelectedToolStripMenuItem.Text = "Delete";
		this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(deleteSelectedToolStripMenuItem_Click);
		this.copyUIDToolStripMenuItem.Name = "copyUIDToolStripMenuItem";
		this.copyUIDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Control;
		this.copyUIDToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
		this.copyUIDToolStripMenuItem.Text = "Copy UID";
		this.copyUIDToolStripMenuItem.Click += new System.EventHandler(copyUIDToolStripMenuItem_Click);
		this.copyToStickyNotesToolStripMenuItem.Name = "copyToStickyNotesToolStripMenuItem";
		this.copyToStickyNotesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.copyToStickyNotesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
		this.copyToStickyNotesToolStripMenuItem.Text = "Copy to Sticky Notes";
		this.copyToStickyNotesToolStripMenuItem.Visible = false;
		this.copyToStickyNotesToolStripMenuItem.Click += new System.EventHandler(copyToStickyNotesToolStripMenuItem_Click);
		this.createTextFileToolStripMenuItem.Name = "createTextFileToolStripMenuItem";
		this.createTextFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control;
		this.createTextFileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
		this.createTextFileToolStripMenuItem.Text = "Create Text File";
		this.createTextFileToolStripMenuItem.Click += new System.EventHandler(createTextFileToolStripMenuItem_Click);
		this.groupBox6.Controls.Add(this.textBox2);
		this.groupBox6.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox6.Location = new System.Drawing.Point(6, 9);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(334, 55);
		this.groupBox6.TabIndex = 10;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Quick Search";
		this.textBox2.AutoCompleteCustomSource.AddRange(new string[4] { ">country=", ">uid=", ">att=", ">user=" });
		this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.textBox2.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox2.Location = new System.Drawing.Point(13, 21);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(308, 22);
		this.textBox2.TabIndex = 3;
		this.toolTip2.SetToolTip(this.textBox2, "Type directly to use quick search feature");
		this.textBox2.TextChanged += new System.EventHandler(textBox2_TextChanged);
		this.textBox2.Enter += new System.EventHandler(textBox2_Enter);
		this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox2_KeyDown);
		this.groupBox3.Controls.Add(this.button1);
		this.groupBox3.Controls.Add(this.textBox1);
		this.groupBox3.Controls.Add(this.label13);
		this.groupBox3.Controls.Add(this.comboBox2);
		this.groupBox3.Controls.Add(this.button3);
		this.groupBox3.Controls.Add(this.label5);
		this.groupBox3.Controls.Add(this.label4);
		this.groupBox3.Controls.Add(this.comboBox1);
		this.groupBox3.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox3.Location = new System.Drawing.Point(6, 70);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(334, 115);
		this.groupBox3.TabIndex = 0;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Advanced Search";
		this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(293, 49);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(28, 22);
		this.button1.TabIndex = 5;
		this.button1.Text = "X";
		this.toolTip2.SetToolTip(this.button1, "Clear Filter");
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click_1);
		this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox1.FormattingEnabled = true;
		this.textBox1.Location = new System.Drawing.Point(101, 77);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(186, 22);
		this.textBox1.TabIndex = 3;
		this.textBox1.SelectedIndexChanged += new System.EventHandler(textBox1_SelectedIndexChanged);
		this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox1_KeyDown_1);
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.Location = new System.Drawing.Point(10, 24);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(55, 14);
		this.label13.TabIndex = 9;
		this.label13.Text = "Country :";
		this.comboBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(101, 21);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(220, 22);
		this.comboBox2.TabIndex = 1;
		this.toolTip2.SetToolTip(this.comboBox2, "Select a country");
		this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox2_KeyDown);
		this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.Image = (System.Drawing.Image)resources.GetObject("button3.Image");
		this.button3.Location = new System.Drawing.Point(293, 78);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(28, 22);
		this.button3.TabIndex = 4;
		this.toolTip2.SetToolTip(this.button3, "Execute Filtered Search");
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(10, 84);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(85, 14);
		this.label5.TabIndex = 6;
		this.label5.Text = "Sub-Attribute :";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(10, 52);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(60, 14);
		this.label4.TabIndex = 5;
		this.label4.Text = "Attribute :";
		this.comboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[7] { "Workorder", "User", "Functional Class", "Lane Type/Attribute", "Controlled Access", "Comments", "JIRA No." });
		this.comboBox1.Location = new System.Drawing.Point(101, 49);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(186, 22);
		this.comboBox1.TabIndex = 2;
		this.toolTip2.SetToolTip(this.comboBox1, "Select the desired attribute");
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox2_KeyDown);
		this.statusStrip2.BackColor = System.Drawing.Color.DimGray;
		this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
		this.statusStrip2.Location = new System.Drawing.Point(0, 719);
		this.statusStrip2.Name = "statusStrip2";
		this.statusStrip2.Size = new System.Drawing.Size(1112, 22);
		this.statusStrip2.TabIndex = 25;
		this.statusStrip2.Text = "statusStrip2";
		this.toolStripStatusLabel1.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
		this.toolStripStatusLabel1.Text = "-";
		this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
		this.notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
		this.notifyIcon1.Visible = true;
		this.fileSystemWatcher1.EnableRaisingEvents = true;
		this.fileSystemWatcher1.SynchronizingObject = this;
		this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher1_Changed);
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.saveFileDialog1.DefaultExt = "xml";
		this.saveFileDialog1.Title = "Export path";
		this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(saveFileDialog1_FileOk);
		this.backgroundWorker2.WorkerSupportsCancellation = true;
		this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker2_DoWork);
		this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
		this.getjira.WorkerSupportsCancellation = true;
		this.getjira.DoWork += new System.ComponentModel.DoWorkEventHandler(getjira_DoWork);
		this.getjira.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(getjira_RunWorkerCompleted);
		this.update_details_worker.WorkerSupportsCancellation = true;
		this.update_details_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(update_details_worker_RunWorkerCompleted);
		this.af_update.WorkerSupportsCancellation = true;
		this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
		this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
		this.openFileDialog2.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
		this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog2_FileOk);
		this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker3_DoWork);
		this.getmaildets.DoWork += new System.ComponentModel.DoWorkEventHandler(getmaildets_DoWork);
		this.openFileDialog3.Filter = "MSG FILES|*.msg";
		this.openFileDialog3.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog3_FileOk);
		this.fileSystemWatcher2.EnableRaisingEvents = true;
		this.fileSystemWatcher2.SynchronizingObject = this;
		this.fileSystemWatcher2.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher2_Changed);
		this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.searchToolStripMenuItem1 });
		this.contextMenuStrip2.Name = "contextMenuStrip2";
		this.contextMenuStrip2.Size = new System.Drawing.Size(150, 26);
		this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
		this.searchToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.searchToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
		this.searchToolStripMenuItem1.Text = "Search";
		this.searchToolStripMenuItem1.Click += new System.EventHandler(searchToolStripMenuItem1_Click);
		this.openFileDialog4.Filter = "ZIP|*.zip";
		this.openFileDialog4.Title = "Select a backup Zip";
		this.saveFileDialog2.DefaultExt = "xmls";
		this.saveFileDialog2.FileName = "settings";
		this.saveFileDialog2.Filter = "Settings XML File|*XMLS";
		this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(saveFileDialog2_FileOk);
		this.openFileDialog5.FileName = "settings.xmls";
		this.openFileDialog5.Filter = "Settings XML File|*.xmls";
		this.openFileDialog5.Title = "Selecting a settings file";
		this.openFileDialog5.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog5_FileOk);
		this.label24.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label24.AutoSize = true;
		this.label24.BackColor = System.Drawing.Color.DimGray;
		this.label24.Location = new System.Drawing.Point(892, 786);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(34, 14);
		this.label24.TabIndex = 27;
		this.label24.Text = "UID -";
		this.fontDialog1.Apply += new System.EventHandler(fontDialog1_Apply);
		this.backgroundWorker4.WorkerSupportsCancellation = true;
		this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker4_DoWork);
		this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker4_RunWorkerCompleted);
		this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker5_DoWork);
		this.backgroundWorker5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker5_RunWorkerCompleted);
		this.contextMenuStrip5.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripMenuItem2, this.toolStripMenuItem3, this.toolStripMenuItem4, this.toolStripMenuItem5, this.toolStripMenuItem6 });
		this.contextMenuStrip5.Name = "contextMenuStrip1";
		this.contextMenuStrip5.Size = new System.Drawing.Size(218, 114);
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 22);
		this.toolStripMenuItem2.Text = "Share";
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.Delete;
		this.toolStripMenuItem3.Size = new System.Drawing.Size(217, 22);
		this.toolStripMenuItem3.Text = "Delete";
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem4.Size = new System.Drawing.Size(217, 22);
		this.toolStripMenuItem4.Text = "Copy UID";
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem5.Size = new System.Drawing.Size(217, 22);
		this.toolStripMenuItem5.Text = "Copy to Sticky Notes";
		this.toolStripMenuItem5.Visible = false;
		this.toolStripMenuItem6.Name = "toolStripMenuItem6";
		this.toolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem6.Size = new System.Drawing.Size(217, 22);
		this.toolStripMenuItem6.Text = "Create Text File";
		this.textBox16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.textBox16.BackColor = System.Drawing.Color.DimGray;
		this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox16.Cursor = System.Windows.Forms.Cursors.Default;
		this.textBox16.Location = new System.Drawing.Point(925, 721);
		this.textBox16.Multiline = true;
		this.textBox16.Name = "textBox16";
		this.textBox16.ReadOnly = true;
		this.textBox16.Size = new System.Drawing.Size(114, 19);
		this.textBox16.TabIndex = 27;
		this.button11.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button11.BackColor = System.Drawing.Color.DimGray;
		this.button11.FlatAppearance.BorderSize = 0;
		this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button11.Location = new System.Drawing.Point(1045, 719);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(45, 22);
		this.button11.TabIndex = 29;
		this.button11.Text = "Copy";
		this.button11.UseVisualStyleBackColor = false;
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1112, 741);
		this.ContextMenuStrip = this.contextMenuStrip2;
		base.Controls.Add(this.button11);
		base.Controls.Add(this.textBox16);
		base.Controls.Add(this.label24);
		base.Controls.Add(this.statusStrip2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.menuStrip1);
		this.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.HelpButton = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "Form1";
		this.Text = "Update Repo Tool";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
		base.Load += new System.EventHandler(Form1_Load);
		base.DragDrop += new System.Windows.Forms.DragEventHandler(Form1_DragDrop);
		base.DragEnter += new System.Windows.Forms.DragEventHandler(Form1_DragEnter);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(Form1_KeyDown);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox7.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView3).EndInit();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.tabPage6.ResumeLayout(false);
		this.groupBox11.ResumeLayout(false);
		this.groupBox11.PerformLayout();
		this.statusStrip3.ResumeLayout(false);
		this.statusStrip3.PerformLayout();
		this.tabPage3.ResumeLayout(false);
		this.groupBox10.ResumeLayout(false);
		this.tabControl2.ResumeLayout(false);
		this.tabPage4.ResumeLayout(false);
		this.tabPage4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		this.tabPage5.ResumeLayout(false);
		this.tabPage5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		this.tabPage7.ResumeLayout(false);
		this.tabPage7.PerformLayout();
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.contextMenuStrip3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		this.contextMenuStrip4.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.statusStrip2.ResumeLayout(false);
		this.statusStrip2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.fileSystemWatcher2).EndInit();
		this.contextMenuStrip2.ResumeLayout(false);
		this.contextMenuStrip5.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
