using System;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Jira.SDK;
using Jira.SDK.Domain;
using Microsoft.Office.Interop.Outlook;
using xmldatabase.Properties;

namespace xmldatabase;

public class add_update : Form
{
	private static string unique_id;

	private string variable_path;

	private string local_path = "C:/update_tool/" + Environment.UserName + "/data/database.xml";

	private string database_path = xmldatabase.Properties.Settings.Default.path + "/database.xml";

	private Create_log cl = new Create_log();

	private IContainer components = null;

	private GroupBox groupBox1;

	private Label label12;

	private TextBox textBox3;

	private Label label9;

	private Label label10;

	private Label label11;

	private TextBox textBox2;

	private Label label8;

	private Label label2;

	private Label label1;

	private GroupBox groupBox2;

	private TextBox textBox6;

	private TextBox textBox5;

	private Label label6;

	private Label label7;

	private Label label13;

	private ComboBox comboBox2;

	private OpenFileDialog openFileDialog1;

	private Button button3;

	private Button button4;

	private OpenFileDialog openFileDialog2;

	private DateTimePicker textBox4;

	private ComboBox textBox1;

	private TextBox textBox10;

	private Label label5;

	private CheckBox checkBox3;

	private TextBox textBox11;

	private Button button5;

	private TextBox textBox7;

	private Label label4;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ComboBox numericUpDown1;

	private BackgroundWorker backgroundWorker1;

	private DirectorySearcher directorySearcher1;

	private OpenFileDialog openFileDialog3;

	private GroupBox groupBox7;

	private ListView listView1;

	private ColumnHeader columnHeader1;

	private ColumnHeader columnHeader2;

	private ColumnHeader columnHeader3;

	private ColumnHeader columnHeader4;

	private ColumnHeader columnHeader5;

	private ColumnHeader columnHeader6;

	private ColumnHeader columnHeader7;

	private ColumnHeader columnHeader8;

	private ColumnHeader columnHeader9;

	private OpenFileDialog openFileDialog4;

	private GroupBox groupBox5;

	private GroupBox groupBox6;

	private Label label15;

	private TextBox textBox13;

	private Button button7;

	private CheckBox checkBox5;

	private Label label14;

	private TextBox textBox12;

	private Button button6;

	private CheckBox checkBox4;

	private GroupBox groupBox3;

	private PictureBox pictureBox1;

	private Label label16;

	private TextBox textBox8;

	private CheckBox checkBox1;

	private Button button1;

	private GroupBox groupBox4;

	private PictureBox pictureBox2;

	private Label label3;

	private Button button2;

	private CheckBox checkBox2;

	private TextBox textBox9;

	private Label label17;

	public add_update()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		openFileDialog1.ShowDialog();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		openFileDialog2.ShowDialog();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || comboBox2.Text == null || comboBox2.Text == "" || textBox3.Text == null || textBox3.Text == "" || textBox5.Text == null || textBox5.Text == "")
		{
			MessageBox.Show("Fields cannot be left blank.");
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		using (FileStream inStream = new FileStream(variable_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
		{
			try
			{
				xmlDocument.Load(inStream);
				XmlElement xmlElement = xmlDocument.CreateElement("data");
				XmlElement xmlElement2 = xmlDocument.CreateElement("country");
				XmlElement xmlElement3 = xmlDocument.CreateElement("wo");
				XmlElement xmlElement4 = xmlDocument.CreateElement("fc");
				XmlElement xmlElement5 = xmlDocument.CreateElement("ca");
				XmlElement xmlElement6 = xmlDocument.CreateElement("l_type");
				XmlElement xmlElement7 = xmlDocument.CreateElement("user");
				XmlElement xmlElement8 = xmlDocument.CreateElement("s_date");
				XmlElement xmlElement9 = xmlDocument.CreateElement("comments");
				XmlElement xmlElement10 = xmlDocument.CreateElement("key");
				XmlElement xmlElement11 = xmlDocument.CreateElement("pre_i");
				XmlElement xmlElement12 = xmlDocument.CreateElement("psot_i");
				XmlElement xmlElement13 = xmlDocument.CreateElement("mail");
				xmlElement.SetAttribute("id", textBox7.Text.ToLower());
				XmlText newChild = xmlDocument.CreateTextNode(textBox1.Text.ToLower());
				XmlText newChild2 = xmlDocument.CreateTextNode(textBox2.Text.ToLower());
				XmlText newChild3 = xmlDocument.CreateTextNode(numericUpDown1.Text.ToString().ToLower());
				XmlText newChild4 = xmlDocument.CreateTextNode(comboBox2.Text.ToLower());
				XmlText newChild5 = xmlDocument.CreateTextNode(textBox3.Text.Replace(" ", "_").ToLower());
				XmlText newChild6 = xmlDocument.CreateTextNode(textBox5.Text.ToLower());
				XmlText newChild7 = xmlDocument.CreateTextNode(textBox4.Text);
				XmlText newChild8 = xmlDocument.CreateTextNode(textBox6.Text.ToLower());
				XmlText newChild9 = null;
				XmlText newChild10 = null;
				XmlText newChild11 = null;
				XmlText newChild12 = null;
				if (textBox10.Text != "" || textBox10.Text != null)
				{
					newChild9 = xmlDocument.CreateTextNode(textBox10.Text.ToLower());
				}
				else if (textBox10.Text == "" || textBox10.Text == null)
				{
					newChild9 = xmlDocument.CreateTextNode("null");
				}
				if (checkBox1.Checked)
				{
					if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower()))
					{
						Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower());
						pictureBox1.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img1.jpg");
						newChild10 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img1.jpg");
					}
					else
					{
						pictureBox1.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img1.jpg");
						newChild10 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img1.jpg");
					}
				}
				else if (!checkBox1.Checked)
				{
					newChild10 = xmlDocument.CreateTextNode(null);
				}
				if (checkBox2.Checked)
				{
					if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower()))
					{
						Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower());
						pictureBox2.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img2.jpg");
						newChild11 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img2.jpg");
					}
					else
					{
						pictureBox2.Image.Save(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img2.jpg");
						newChild11 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Images/" + textBox7.Text.ToLower() + "/_img2.jpg");
					}
				}
				else if (!checkBox2.Checked)
				{
					newChild11 = xmlDocument.CreateTextNode(null);
				}
				if (checkBox4.Checked)
				{
					if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower()))
					{
						Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower());
						File.Copy(textBox12.Text, xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower() + "/_trail.msg");
						newChild12 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower() + "/_trail.msg");
					}
					else
					{
						File.Copy(textBox12.Text, xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower() + "/_trail.msg");
						newChild12 = xmlDocument.CreateTextNode(xmldatabase.Properties.Settings.Default.path + "/Mails/" + textBox7.Text.ToLower() + "/_trail.msg");
					}
				}
				else if (!checkBox4.Checked)
				{
					newChild12 = xmlDocument.CreateTextNode(null);
				}
				xmlElement2.AppendChild(newChild);
				xmlElement3.AppendChild(newChild2);
				xmlElement4.AppendChild(newChild3);
				xmlElement5.AppendChild(newChild4);
				xmlElement6.AppendChild(newChild5);
				xmlElement7.AppendChild(newChild6);
				xmlElement8.AppendChild(newChild7);
				xmlElement9.AppendChild(newChild8);
				xmlElement10.AppendChild(newChild9);
				xmlElement11.AppendChild(newChild10);
				xmlElement12.AppendChild(newChild11);
				xmlElement13.AppendChild(newChild12);
				xmlElement.AppendChild(xmlElement2);
				xmlElement.AppendChild(xmlElement3);
				xmlElement.AppendChild(xmlElement4);
				xmlElement.AppendChild(xmlElement5);
				xmlElement.AppendChild(xmlElement6);
				xmlElement.AppendChild(xmlElement7);
				xmlElement.AppendChild(xmlElement8);
				xmlElement.AppendChild(xmlElement9);
				xmlElement.AppendChild(xmlElement10);
				xmlElement.AppendChild(xmlElement11);
				xmlElement.AppendChild(xmlElement12);
				xmlElement.AppendChild(xmlElement13);
				string[] array = new string[9];
				ListViewItem listViewItem = new ListViewItem();
				array[0] = textBox1.Text.ToLower();
				array[1] = textBox2.Text.ToUpper();
				array[2] = numericUpDown1.Text;
				array[3] = comboBox2.Text.ToUpper();
				array[4] = textBox3.Text;
				array[5] = textBox5.Text;
				array[6] = textBox4.Text;
				if (textBox10.Text == "" || textBox10.Text == null)
				{
					array[7] = "null";
				}
				else
				{
					array[7] = textBox10.Text;
				}
				array[8] = textBox6.Text;
				listViewItem = new ListViewItem(array);
				listView1.Items.Add(listViewItem);
				xmlDocument.DocumentElement.AppendChild(xmlElement);
				if (email.Default.sendsave)
				{
					CreateMailItem();
				}
				MessageBox.Show("Update Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox7.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Occured : \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		xmlDocument.Save(variable_path);
	}

	private void add_update_Load(object sender, EventArgs e)
	{
		if (xmldatabase.Properties.Settings.Default.pcache)
		{
			variable_path = local_path;
		}
		else if (!xmldatabase.Properties.Settings.Default.pcache)
		{
			variable_path = database_path;
		}
		label17.Text = "Auto E-Mail : " + email.Default.sendsave;
		if (!File.Exists(variable_path))
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(local_path, Encoding.UTF8);
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Repo");
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.Close();
			xmlTextWriter.Dispose();
		}
		if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Images"))
		{
			Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Images");
		}
		if (!Directory.Exists(xmldatabase.Properties.Settings.Default.path + "/Mails"))
		{
			Directory.CreateDirectory(xmldatabase.Properties.Settings.Default.path + "/Mails");
		}
		getcountrybyregion();
		unique_id = Guid.NewGuid().ToString().GetHashCode()
			.ToString("x");
		textBox5.Text = Environment.UserName;
		textBox7.Text = unique_id;
		checkBox1.Checked = true;
		checkBox2.Checked = true;
		checkBox4.Checked = true;
	}

	private void getcountrybyregion()
	{
		try
		{
			switch (xmldatabase.Properties.Settings.Default.region)
			{
			case "WEU":
			{
				textBox1.Items.Clear();
				string[] items5 = new string[32]
				{
					"Andorra", "België", "Channel Islands", "Danmark", "Deutschland", "England", "España", "France", "Føroyar", "Gibraltar",
					"Greenland", "Ireland", "Isle of Man", "Italia", "Liechtenstein", "Luxembourg", "Malta", "Monaco", "Nederland", "Norge",
					"Northern Ireland", "Portugal", "San Marino", "Schweiz", "Scotland", "Stato della Città del Vaticano", "Suomi", "Svalbard", "Sverige", "Wales",
					"Ísland", "Österreich"
				};
				textBox1.Items.AddRange(items5);
				break;
			}
			case "NA":
			{
				textBox1.Items.Clear();
				string[] items4 = new string[23]
				{
					"Bahamas", "Belize", "Bermuda", "British Virgin Islands", "Canada", "Cayman Islands", "Costa Rica", "Cuba", "El Salvador", "Guatemala",
					"Haiti", "Honduras", "Jamaica", "México", "Nicaragua", "Panamá", "Puerto Rico", "República Dominicana", "Saint Pierre and Miquelon", "Turks and Caicos Islands",
					"US Virgin Islands", "Uninhabited Island", "United States"
				};
				textBox1.Items.AddRange(items4);
				xmldatabase.Properties.Settings.Default.region = "NA";
				break;
			}
			case "MEA":
			{
				textBox1.Items.Clear();
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
				textBox1.Items.AddRange(items3);
				break;
			}
			case "APAC":
			{
				textBox1.Items.Clear();
				string[] items2 = new string[26]
				{
					"Brunei Darussalam", "Cambodia", "China", "Guam", "Canada", "Indonesia", "Japan", "Laos", "Malaysia", "Mongolia",
					"Myanmar", "North Korea", "Northern Mariana Islands", "Palau", "Papua New Guinea", "Paracel Islands", "Philippines", "Singapore", "Solomon Islands", "South Korea",
					"Spratly Islands", "Timor-Leste", "Việt Nam", "ประเทศไทย", "澳門-中國", "香港-中國"
				};
				textBox1.Items.AddRange(items2);
				break;
			}
			case "EEU":
			{
				textBox1.Items.Clear();
				string[] items = new string[35]
				{
					"Azərbaycan", "Bosna i Hercegovina", "British Sovereign Base Areas", "Crna Gora", "Eesti", "Hrvatska", "Kosovë", "Kyrgyzstan", "Kıbrıs Türk Yönetimi", "Latvija",
					"Lietuva", "Magyarország", "Moldova", "O'zbekiston", "Polska", "România", "Shqipëria", "Slovenija", "Slovenská republika", "Tajikistan",
					"Turkmenistan", "Türkiye", "Česká republika", "Ελλάδα", "Κυπρος", "Παρεμβαλλομενη γραμμη Ο.Η.Ε. Κυπρου", "Беларусь", "България", "П. Југословенска Репуб. Македонија", "Россия",
					"Србија", "Україна", "Қазақстан", "Հայաստան", "საქართველო"
				};
				textBox1.Items.AddRange(items);
				break;
			}
			}
		}
		catch
		{
			MessageBox.Show("Error getting country names..");
		}
	}

	private void button4_MouseEnter(object sender, EventArgs e)
	{
		textBox7.Clear();
		textBox7.Text = textBox3.Text.Replace(" ", "_") + "_" + textBox1.Text + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + textBox4.Text.Replace("/", "");
	}

	private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
	{
		textBox8.Text = openFileDialog1.FileName;
		pictureBox1.ImageLocation = textBox8.Text;
	}

	private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
	{
		textBox9.Text = openFileDialog2.FileName;
		pictureBox2.ImageLocation = textBox9.Text;
	}

	private void button3_Click(object sender, EventArgs e)
	{
		textBox1.ResetText();
		textBox2.ResetText();
		textBox3.ResetText();
		textBox4.ResetText();
		textBox5.Text = Environment.UserName;
		textBox6.ResetText();
		textBox7.ResetText();
		textBox8.ResetText();
		textBox9.ResetText();
		textBox10.ResetText();
		comboBox2.ResetText();
		numericUpDown1.ResetText();
		pictureBox1.Image = null;
		pictureBox2.Image = null;
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox1.Checked)
		{
			button1.Enabled = false;
			pictureBox1.Enabled = false;
			pictureBox1.Image = null;
		}
		else
		{
			button1.Enabled = true;
			pictureBox1.Enabled = true;
		}
	}

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox2.Checked)
		{
			button2.Enabled = false;
			pictureBox2.Enabled = false;
			pictureBox2.Image = null;
		}
		else
		{
			button2.Enabled = true;
			pictureBox2.Enabled = true;
		}
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox3.Checked)
		{
			textBox11.ReadOnly = false;
			textBox10.ReadOnly = true;
			button5.Enabled = true;
		}
		else
		{
			textBox11.ReadOnly = true;
			textBox10.ReadOnly = false;
			button5.Enabled = false;
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		try
		{
			Jira val = new Jira();
			val.Connect("http://pfarmapopsjira1.core.in.here.com", xmldatabase.Properties.Settings.Default.jirauser, xmldatabase.Properties.Settings.Default.jirapass);
			Issue issue = val.GetIssue(textBox11.Text.TrimEnd(' '));
			string name = issue.get_Project().get_Name();
			string text = issue.get_Summary().Replace(' ', '_');
			string text2 = text.Substring(text.IndexOf(':') + 1);
			textBox1.Text = name.Substring(name.IndexOf('_') + 1);
			textBox2.Text = issue.GetCustomFieldValue("Work Order");
			numericUpDown1.Text = issue.GetCustomFieldValue("Functional Class");
			textBox3.Text = text2.Substring(text2.IndexOf('-') + 1).TrimStart('_');
			textBox5.Text = issue.get_Fields().get_Reporter().get_Fullname();
			textBox6.Text = issue.get_Description() + "\nExpert Resolution :\n" + issue.GetCustomFieldValue("Expert Resolution");
			textBox4.Text = issue.get_Created().Date.ToShortDateString();
			textBox10.Text = textBox11.Text;
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			checkBox4.Checked = false;
			pictureBox1.Image = null;
			pictureBox2.Image = null;
			textBox8.ResetText();
			textBox9.ResetText();
			toolStripStatusLabel1.Text = "JIRA details for " + textBox11.Text.ToUpper() + " fetched successfully";
		}
		catch (Exception ex)
		{
			toolStripStatusLabel1.Text = "Error fetching data from jira.. " + ex.Message;
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
			if (email.Default.subject != null || email.Default.subject != "")
			{
				mailItem.Subject = dynamictext(email.Default.subject);
			}
			mailItem.To = dynamictext(email.Default.to);
			mailItem.CC = dynamictext(email.Default.cc);
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
				if (textBox12.Text != null && textBox12.Text != "")
				{
					mailItem.Attachments.Add(textBox12.Text, Missing.Value, Missing.Value, Missing.Value);
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
		text = text.Replace("@-id", textBox5.Text);
		text = text.Replace("@-attributetype", textBox3.Text);
		text = text.Replace("@-jira", textBox10.Text);
		text = text.Replace("@-workorder", textBox2.Text);
		text = text.Replace("@-country", textBox1.Text);
		text = text.Replace("@-fc", numericUpDown1.Text);
		text = text.Replace("@-ca", comboBox2.Text);
		text = text.Replace("@-sdate", textBox4.Text);
		text = text.Replace("@-comments", textBox6.Text);
		return text;
	}

	private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			string tempFileName = Path.GetTempFileName();
			Clipboard.GetImage().Save(tempFileName);
			textBox8.Text = tempFileName;
			pictureBox1.ImageLocation = tempFileName;
		}
		catch
		{
		}
	}

	private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			string tempFileName = Path.GetTempFileName();
			Clipboard.GetImage().Save(tempFileName);
			textBox9.Text = tempFileName;
			pictureBox2.ImageLocation = tempFileName;
		}
		catch
		{
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		openFileDialog3.ShowDialog();
	}

	private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
	{
		textBox12.Text = openFileDialog3.FileName;
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox4.Checked)
		{
			button6.Enabled = true;
			return;
		}
		button6.Enabled = false;
		textBox12.Clear();
	}

	private void add_update_DragEnter(object sender, DragEventArgs e)
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

	private void add_update_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, autoConvert: false);
			if (Path.GetExtension(array[0]) == ".msg")
			{
				textBox12.Text = array[0];
			}
			else
			{
				textBox12.Text = "";
			}
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		openFileDialog4.ShowDialog();
	}

	private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
	{
	}

	private void textBox12_MouseDoubleClick(object sender, MouseEventArgs e)
	{
	}

	private void textBox12_TextChanged(object sender, EventArgs e)
	{
	}

	private void textBox3_TextChanged(object sender, EventArgs e)
	{
	}

	private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmldatabase.add_update));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.numericUpDown1 = new System.Windows.Forms.ComboBox();
		this.button4 = new System.Windows.Forms.Button();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.label15 = new System.Windows.Forms.Label();
		this.textBox13 = new System.Windows.Forms.TextBox();
		this.button7 = new System.Windows.Forms.Button();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.label14 = new System.Windows.Forms.Label();
		this.textBox12 = new System.Windows.Forms.TextBox();
		this.button6 = new System.Windows.Forms.Button();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label16 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.button1 = new System.Windows.Forms.Button();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label3 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.button3 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.textBox1 = new System.Windows.Forms.ComboBox();
		this.textBox4 = new System.Windows.Forms.DateTimePicker();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label12 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
		this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
		this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
		this.label17 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.groupBox4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		this.groupBox2.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.groupBox7.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.numericUpDown1);
		this.groupBox1.Controls.Add(this.button4);
		this.groupBox1.Controls.Add(this.groupBox5);
		this.groupBox1.Controls.Add(this.button3);
		this.groupBox1.Controls.Add(this.button5);
		this.groupBox1.Controls.Add(this.textBox10);
		this.groupBox1.Controls.Add(this.textBox11);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.checkBox3);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.textBox4);
		this.groupBox1.Controls.Add(this.groupBox2);
		this.groupBox1.Controls.Add(this.textBox5);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.label13);
		this.groupBox1.Controls.Add(this.comboBox2);
		this.groupBox1.Controls.Add(this.label12);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(12, 10);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(1039, 636);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Details";
		this.numericUpDown1.FormattingEnabled = true;
		this.numericUpDown1.Items.AddRange(new object[6] { "1", "2", "3", "4", "5", "All" });
		this.numericUpDown1.Location = new System.Drawing.Point(102, 205);
		this.numericUpDown1.Name = "numericUpDown1";
		this.numericUpDown1.Size = new System.Drawing.Size(50, 22);
		this.numericUpDown1.TabIndex = 44;
		this.button4.Location = new System.Drawing.Point(957, 602);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(75, 25);
		this.button4.TabIndex = 2;
		this.button4.Text = "Save";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button4.MouseEnter += new System.EventHandler(button4_MouseEnter);
		this.groupBox5.Controls.Add(this.groupBox6);
		this.groupBox5.Controls.Add(this.groupBox3);
		this.groupBox5.Controls.Add(this.groupBox4);
		this.groupBox5.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox5.Location = new System.Drawing.Point(307, 16);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(723, 422);
		this.groupBox5.TabIndex = 43;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Attachments";
		this.groupBox6.Controls.Add(this.label15);
		this.groupBox6.Controls.Add(this.textBox13);
		this.groupBox6.Controls.Add(this.button7);
		this.groupBox6.Controls.Add(this.checkBox5);
		this.groupBox6.Controls.Add(this.label14);
		this.groupBox6.Controls.Add(this.textBox12);
		this.groupBox6.Controls.Add(this.button6);
		this.groupBox6.Controls.Add(this.checkBox4);
		this.groupBox6.Location = new System.Drawing.Point(6, 352);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(705, 64);
		this.groupBox6.TabIndex = 45;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Mail";
		this.label15.AutoSize = true;
		this.label15.Enabled = false;
		this.label15.Location = new System.Drawing.Point(365, 29);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(81, 14);
		this.label15.TabIndex = 44;
		this.label15.Text = "Attachments :";
		this.textBox13.Location = new System.Drawing.Point(452, 26);
		this.textBox13.Name = "textBox13";
		this.textBox13.ReadOnly = true;
		this.textBox13.Size = new System.Drawing.Size(178, 22);
		this.textBox13.TabIndex = 45;
		this.button7.Location = new System.Drawing.Point(636, 24);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(33, 25);
		this.button7.TabIndex = 46;
		this.button7.Text = "...";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click);
		this.checkBox5.AutoSize = true;
		this.checkBox5.Enabled = false;
		this.checkBox5.Location = new System.Drawing.Point(675, 29);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(15, 14);
		this.checkBox5.TabIndex = 47;
		this.checkBox5.UseVisualStyleBackColor = true;
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(9, 29);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(66, 14);
		this.label14.TabIndex = 40;
		this.label14.Text = "Mail Item :";
		this.textBox12.Location = new System.Drawing.Point(81, 25);
		this.textBox12.Name = "textBox12";
		this.textBox12.ReadOnly = true;
		this.textBox12.Size = new System.Drawing.Size(178, 22);
		this.textBox12.TabIndex = 41;
		this.textBox12.TextChanged += new System.EventHandler(textBox12_TextChanged);
		this.textBox12.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(textBox12_MouseDoubleClick);
		this.button6.Location = new System.Drawing.Point(265, 23);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(33, 25);
		this.button6.TabIndex = 42;
		this.button6.Text = "...";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.checkBox4.AutoSize = true;
		this.checkBox4.Location = new System.Drawing.Point(304, 28);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(15, 14);
		this.checkBox4.TabIndex = 43;
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox4.CheckedChanged += new System.EventHandler(checkBox4_CheckedChanged);
		this.groupBox3.Controls.Add(this.pictureBox1);
		this.groupBox3.Controls.Add(this.label16);
		this.groupBox3.Controls.Add(this.textBox8);
		this.groupBox3.Controls.Add(this.checkBox1);
		this.groupBox3.Controls.Add(this.button1);
		this.groupBox3.Location = new System.Drawing.Point(6, 20);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(351, 325);
		this.groupBox3.TabIndex = 30;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Image - 1";
		this.pictureBox1.Location = new System.Drawing.Point(6, 18);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(339, 265);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDoubleClick);
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(9, 295);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(83, 14);
		this.label16.TabIndex = 25;
		this.label16.Text = "Select Image :";
		this.textBox8.Location = new System.Drawing.Point(98, 292);
		this.textBox8.Name = "textBox8";
		this.textBox8.ReadOnly = true;
		this.textBox8.Size = new System.Drawing.Size(187, 22);
		this.textBox8.TabIndex = 28;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(330, 295);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(15, 14);
		this.checkBox1.TabIndex = 39;
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.button1.Location = new System.Drawing.Point(291, 290);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(33, 25);
		this.button1.TabIndex = 31;
		this.button1.Text = "...";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.groupBox4.Controls.Add(this.pictureBox2);
		this.groupBox4.Controls.Add(this.label3);
		this.groupBox4.Controls.Add(this.button2);
		this.groupBox4.Controls.Add(this.checkBox2);
		this.groupBox4.Controls.Add(this.textBox9);
		this.groupBox4.Location = new System.Drawing.Point(363, 20);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(354, 325);
		this.groupBox4.TabIndex = 31;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Image - 2";
		this.pictureBox2.Location = new System.Drawing.Point(6, 18);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(342, 265);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 1;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pictureBox2_MouseDoubleClick);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(6, 295);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(83, 14);
		this.label3.TabIndex = 32;
		this.label3.Text = "Select Image :";
		this.button2.Location = new System.Drawing.Point(294, 290);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(33, 25);
		this.button2.TabIndex = 34;
		this.button2.Text = "...";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(333, 295);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(15, 14);
		this.checkBox2.TabIndex = 40;
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
		this.textBox9.Location = new System.Drawing.Point(95, 292);
		this.textBox9.Name = "textBox9";
		this.textBox9.ReadOnly = true;
		this.textBox9.Size = new System.Drawing.Size(193, 22);
		this.textBox9.TabIndex = 33;
		this.button3.Location = new System.Drawing.Point(957, 571);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(75, 25);
		this.button3.TabIndex = 1;
		this.button3.Text = "Clear";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button5.Enabled = false;
		this.button5.Location = new System.Drawing.Point(262, 16);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(27, 24);
		this.button5.TabIndex = 39;
		this.button5.Text = "..";
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.textBox10.Location = new System.Drawing.Point(83, 393);
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(180, 22);
		this.textBox10.TabIndex = 42;
		this.textBox11.Location = new System.Drawing.Point(157, 18);
		this.textBox11.Name = "textBox11";
		this.textBox11.ReadOnly = true;
		this.textBox11.Size = new System.Drawing.Size(99, 22);
		this.textBox11.TabIndex = 38;
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(9, 396);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(56, 14);
		this.label5.TabIndex = 41;
		this.label5.Text = "JIRA No. :";
		this.checkBox3.AutoSize = true;
		this.checkBox3.Location = new System.Drawing.Point(21, 21);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(135, 18);
		this.checkBox3.TabIndex = 37;
		this.checkBox3.Text = "Create from JIRA No.";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged);
		this.textBox1.FormattingEnabled = true;
		this.textBox1.Items.AddRange(new object[32]
		{
			"Andorra", "België", "Channel Islands", "Danmark", "Deutschland", "England", "España", "France", "Føroyar", "Gibraltar",
			"Greenland", "Ireland", "Isle of Man", "Italia", "Liechtenstein", "Luxembourg", "Malta", "Monaco", "Nederland", "Norge",
			"Northern Ireland", "Portugal", "San Marino", "Schweiz", "Scotland", "Stato della Città del Vaticano", "Suomi", "Svalbard", "Sverige", "Wales",
			"Ísland", "Österreich"
		});
		this.textBox1.Location = new System.Drawing.Point(79, 100);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(184, 22);
		this.textBox1.TabIndex = 38;
		this.textBox4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
		this.textBox4.Location = new System.Drawing.Point(83, 355);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(177, 22);
		this.textBox4.TabIndex = 37;
		this.groupBox2.Controls.Add(this.textBox6);
		this.groupBox2.Location = new System.Drawing.Point(9, 445);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(942, 185);
		this.groupBox2.TabIndex = 24;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Comments :";
		this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBox6.Location = new System.Drawing.Point(3, 18);
		this.textBox6.Multiline = true;
		this.textBox6.Name = "textBox6";
		this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.textBox6.Size = new System.Drawing.Size(936, 164);
		this.textBox6.TabIndex = 0;
		this.textBox5.Location = new System.Drawing.Point(83, 322);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(177, 22);
		this.textBox5.TabIndex = 22;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(9, 298);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(123, 13);
		this.label6.TabIndex = 21;
		this.label6.Text = "User / Coder Details";
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(9, 362);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(80, 14);
		this.label7.TabIndex = 20;
		this.label7.Text = "Submit Date :";
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(9, 325);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(45, 14);
		this.label13.TabIndex = 19;
		this.label13.Text = "Name :";
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Items.AddRange(new object[3] { "Yes", "No", "Both" });
		this.comboBox2.Location = new System.Drawing.Point(262, 205);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(39, 22);
		this.comboBox2.TabIndex = 17;
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(162, 208);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(109, 14);
		this.label12.TabIndex = 16;
		this.label12.Text = "Controlled Access :";
		this.textBox3.AutoCompleteCustomSource.AddRange(new string[37]
		{
			"Acceleration", "Auxiliary", "Center Turn", "Deccelration", "Shoulder", "Express", "HOV", "Passing", "Regular", "Regulated Access",
			"Reversible", "Slow", "Truck Parking", "Turn", "Express plus Accelration", "Express plus Deccelration", "HOV plus Accelration", "HOV plus Deccelration", "HOV Express", "HOV Reversible Express",
			"HOV Plus Reversible", "Variable Driving", "Parking", "Bicycle", "Connectivity", "Lane Traversals", "Traffic Signals", "Toll Structure", "Access Restriction", "DCM",
			"RDM", "Height/Weight Restriction", "TAR", "Stop Sign", "Divider", "LDM", "CDM"
		});
		this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
		this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.textBox3.Location = new System.Drawing.Point(137, 243);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(164, 22);
		this.textBox3.TabIndex = 14;
		this.textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(9, 180);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(104, 13);
		this.label9.TabIndex = 12;
		this.label9.Text = "Attributes Details";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(6, 247);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(125, 14);
		this.label10.TabIndex = 11;
		this.label10.Text = "Lane Type / Attribute :";
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(6, 208);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(102, 14);
		this.label11.TabIndex = 10;
		this.label11.Text = "Functional Class :";
		this.textBox2.Location = new System.Drawing.Point(79, 132);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(184, 22);
		this.textBox2.TabIndex = 9;
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(9, 72);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(90, 13);
		this.label8.TabIndex = 7;
		this.label8.Text = "Project Details";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 136);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(70, 14);
		this.label2.TabIndex = 1;
		this.label2.Text = "WorkOrder :";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 103);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(53, 14);
		this.label1.TabIndex = 0;
		this.label1.Text = "Country :";
		this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
		this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
		this.openFileDialog2.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
		this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog2_FileOk);
		this.textBox7.Location = new System.Drawing.Point(64, 10);
		this.textBox7.Name = "textBox7";
		this.textBox7.ReadOnly = true;
		this.textBox7.Size = new System.Drawing.Size(168, 22);
		this.textBox7.TabIndex = 36;
		this.textBox7.Visible = false;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(18, 10);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(40, 13);
		this.label4.TabIndex = 35;
		this.label4.Text = "Title :";
		this.label4.Visible = false;
		this.statusStrip1.BackColor = System.Drawing.Color.DimGray;
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
		this.statusStrip1.Location = new System.Drawing.Point(0, 808);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(1061, 22);
		this.statusStrip1.SizingGrip = false;
		this.statusStrip1.TabIndex = 37;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
		this.toolStripStatusLabel1.Text = "..";
		this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
		this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
		this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
		this.openFileDialog3.FileName = "openFileDialog3";
		this.openFileDialog3.Filter = "MSG FILES|*.msg";
		this.openFileDialog3.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog3_FileOk);
		this.groupBox7.Controls.Add(this.listView1);
		this.groupBox7.Location = new System.Drawing.Point(12, 653);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Size = new System.Drawing.Size(1039, 151);
		this.groupBox7.TabIndex = 38;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Last Added";
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[9] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5, this.columnHeader6, this.columnHeader7, this.columnHeader8, this.columnHeader9 });
		this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView1.GridLines = true;
		this.listView1.Location = new System.Drawing.Point(3, 18);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(1033, 130);
		this.listView1.TabIndex = 0;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.SelectedIndexChanged += new System.EventHandler(listView1_SelectedIndexChanged);
		this.columnHeader1.Text = "Country";
		this.columnHeader1.Width = 143;
		this.columnHeader2.Text = "Work Order";
		this.columnHeader2.Width = 160;
		this.columnHeader3.Text = "FC";
		this.columnHeader3.Width = 58;
		this.columnHeader4.Text = "CA";
		this.columnHeader4.Width = 54;
		this.columnHeader5.Text = "Lane Type/Attribute";
		this.columnHeader5.Width = 201;
		this.columnHeader6.Text = "Name";
		this.columnHeader6.Width = 86;
		this.columnHeader7.Text = "Submit Date";
		this.columnHeader7.Width = 72;
		this.columnHeader8.Text = "JIRA No.";
		this.columnHeader8.Width = 77;
		this.columnHeader9.Text = "Comments";
		this.columnHeader9.Width = 178;
		this.openFileDialog4.Filter = "MP4 Files | *.mp4";
		this.openFileDialog4.Multiselect = true;
		this.openFileDialog4.Title = "Select Recording";
		this.openFileDialog4.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog4_FileOk);
		this.label17.AutoSize = true;
		this.label17.BackColor = System.Drawing.Color.DimGray;
		this.label17.Location = new System.Drawing.Point(953, 812);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(48, 14);
		this.label17.TabIndex = 39;
		this.label17.Text = "label17";
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1061, 830);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.groupBox7);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.textBox7);
		this.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "add_update";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add New Update";
		base.Load += new System.EventHandler(add_update_Load);
		base.DragDrop += new System.Windows.Forms.DragEventHandler(add_update_DragDrop);
		base.DragEnter += new System.Windows.Forms.DragEventHandler(add_update_DragEnter);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
