using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Yahoo.Yui.Compressor;

namespace jsZip
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.cnblogs.com/zjfree");
		}

		private string strFilePath = "";
		private void btnCompressor_Click(object sender, EventArgs e)
		{
			if (this.ListFile.Items.Count == 0)
			{
				return;
			}
			DirectoryInfo oldDir = new DirectoryInfo(strFilePath);
			DirectoryInfo newDir = new DirectoryInfo(oldDir.FullName.Substring(0, oldDir.FullName.Length - 1) + "_bak");
			if (!newDir.Exists)
			{
				newDir.Create();
			}

			Encoding encoder = GetEncoding();
			int errorCount = 0;
			long oldSize = 0;
			long newSize = 0;
			for (int i = 0; i < this.fileList.Count; i++)
			{
				try
				{
					FileInfo file = this.fileList[i];
					FileInfo newFile = new FileInfo(file.FullName.Replace(oldDir.FullName, newDir.FullName));
					if (!newFile.Directory.Exists)
					{
						newFile.Directory.Create();
					}
					string strContent = File.ReadAllText(file.FullName, encoder);
					if (file.Extension.ToLower() == ".js")
					{
						JavaScriptCompressor js = new JavaScriptCompressor(strContent, false, encoder, System.Globalization.CultureInfo.CurrentCulture);
						strContent = js.Compress();
					}
					else if (file.Extension.ToLower() == ".css")
					{
						strContent = CssCompressor.Compress(strContent);
					}
					File.WriteAllText(newFile.FullName, strContent);
					this.ListFile.Items[i].ForeColor = Color.Blue;
					this.ListFile.Items[i].SubItems[2].Text = FormatSize(strContent.Length);
					this.ListFile.Items[i].SubItems[3].Text = "完成";
					oldSize += file.Length;
					newSize += strContent.Length;
				}
				catch (Exception ex)
				{
					this.ListFile.Items[i].ForeColor = Color.Red;
					this.ListFile.Items[i].SubItems[2].Text = "0";
					this.ListFile.Items[i].SubItems[3].Text = "错误:" + ex.Message;
					errorCount++;
				}
				int ii = i + 1;
				this.txtInfo.Text = "共" + this.fileList.Count.ToString() + "个文件！正处理第" + ii.ToString() + "个文件！";
				Application.DoEvents();
			}

			string strInfo = "压缩完成！\r\n";
			if (errorCount > 0)
			{
				strInfo += errorCount.ToString() + "个文件压缩发生错误！\r\n";
			}
			strInfo += "总体压缩：";
			double rate = 1.0 * newSize / oldSize * 100;
			strInfo += rate.ToString() + "%";
			this.txtInfo.Text = strInfo.Replace("\r\n", " ");
			if (errorCount > 0)
			{
				MessageBox.Show(strInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show(strInfo, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			System.Diagnostics.Process.Start(newDir.FullName);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.cbEncoder.Items.Add("UTF8");
			this.cbEncoder.Items.Add("ASCII");
			this.cbEncoder.Items.Add("Default");
			this.cbEncoder.Items.Add("Unicode");
			this.cbEncoder.SelectedIndex = 0;
		}

		/// <summary>
		/// 获取编码
		/// </summary>
		/// <returns></returns>
		private Encoding GetEncoding()
		{
			Encoding encoder = Encoding.Default;
			switch (this.cbEncoder.SelectedItem.ToString())
			{
				case "UTF8":
					encoder = Encoding.UTF8;
					break;
				case "ASCII":
					encoder = Encoding.ASCII;
					break;
				case "Default":
					encoder = Encoding.Default;
					break;
				case "Unicode":
					encoder = Encoding.Unicode;
					break;
				default:
					break;
			}

			return encoder;
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(this.txtPath.Text))
			{
				MessageBox.Show("路径不存在，请重新选择！");
				btnSelect.PerformClick();
				return;
			}
			strFilePath = this.txtPath.Text;
			jsCount = 0;
			cssCount = 0;
			fileList.Clear();
			this.ListFile.Items.Clear();
			GetDirList(new DirectoryInfo(this.txtPath.Text));
			if (fileList.Count == 0)
			{
				this.btnCompressor.Enabled = false;
				MessageBox.Show("未找到js或css文件！");
				return;
			}

			this.txtInfo.Text = "共加载了" + jsCount.ToString() + "个JS文件、" + cssCount.ToString() + "个CSS文件！";
			this.ListFile.BeginUpdate();
			foreach (FileInfo file in fileList)
			{
				ListViewItem item = new ListViewItem(file.FullName.Replace(this.txtPath.Text,""), 0);
				item.SubItems.Add(FormatSize(file.Length));
				item.SubItems.Add("");
				item.SubItems.Add("就绪");
				this.ListFile.Items.Add(item);
			}
			this.ListFile.EndUpdate();
			this.btnCompressor.Enabled = true;
		}

		private IList<FileInfo> fileList = new List<FileInfo>();
		private int jsCount = 0;
		private int cssCount = 0;
		private void GetDirList(DirectoryInfo dir)
		{
			FileInfo[] files = dir.GetFiles("*.js");
			foreach (FileInfo r in files)
			{
				jsCount++;
				fileList.Add(r);
			}
			files = dir.GetFiles("*.css");
			foreach (FileInfo file in files)
			{
				cssCount++;
				fileList.Add(file);
			}
			DirectoryInfo[] dirs = dir.GetDirectories();
			if (dirs.Length > 0)
			{
				foreach (DirectoryInfo r in dirs)
				{
					GetDirList(r);
				}
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				this.txtPath.Text = this.folderBrowserDialog1.SelectedPath;
			}
		}
		/// <summary>
		/// 格式化空间大小 形如：[2.63M]
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		private string FormatSize(long size)
		{
			string strReturn = "";
			double tempSize = size * 1.0 * (size < 0 ? -1 : 1);
			if (tempSize < 1024)
			{
				strReturn += tempSize.ToString() + "B";
			}
			else if (tempSize < 1024 * 1024)
			{
				tempSize = tempSize / 1024;
				strReturn += tempSize.ToString("0.##") + "K";
			}
			else if (tempSize < 1024 * 1024 * 1024)
			{
				tempSize = tempSize / 1024 / 1024;
				strReturn += tempSize.ToString("0.##") + "M";
			}
			else
			{
				tempSize = tempSize / 1024 / 1024 / 1024;
				strReturn += tempSize.ToString("0.##") + "G";
			}

			if (size < 0)
			{
				strReturn = "-" + strReturn;
			}

			return strReturn;
		}
	}
}