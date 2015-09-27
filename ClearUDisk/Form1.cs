using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTool.Common.WindowsForm;

namespace ClearUDisk
{
    public partial class Form1 : Form
    {
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;

        public Form1()
        {
            InitializeComponent();

            InitDeviceList();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入
                            DeviceArrival();
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                            DeviceRemoved();
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            base.WndProc(ref m);
        }

        private void InitDeviceList()
        {
            DeviceArrival();
        }

        private void DeviceArrival()
        {
            UDiskItem currentItem = listBox1.SelectedItem as UDiskItem;
            listBox1.ClearSelected();
            listBox1.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    UDiskItem uItem = new UDiskItem()
                    {
                        Name = drive.Name,
                        VolumeLabel = drive.VolumeLabel,
                        TotalSize = drive.TotalSize,
                        TotalFreeSpace = drive.TotalFreeSpace
                    };

                    listBox1.Items.Add(uItem);

                    if (currentItem != null
                        && currentItem.VolumeLabel == uItem.VolumeLabel
                        && currentItem.TotalSize == uItem.TotalSize)
                    {
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                }
            }
        }

        private void DeviceRemoved()
        {
            DeviceArrival();
        }

        private CancellationTokenSource cancelTokenSource;

        private void startAndStopButton1_OnStartButtonClick(object sender, EventArgs e)
        {
            UDiskItem currentItem = listBox1.SelectedItem as UDiskItem;
            if (currentItem == null)
            {
                MessageBox.Show("请先选中一个可移动磁盘。");
                return;
            }

            long freeSpace = currentItem.TotalFreeSpace;
            if (freeSpace > 0) 
            {
                cancelTokenSource = new CancellationTokenSource();
                Task.Factory.StartNew(() =>
                {
                    string file = Path.Combine(currentItem.Name, "Fill_File.dat");
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate)) 
                    {
                        fs.SetLength(freeSpace/2);
                        using(StreamWriter sw = new StreamWriter(fs))
                        {
                            while(fs.CanWrite)
                            {
                                sw.Write("A");
                            }
                        }
                    }
                }, cancelTokenSource.Token);
            }
        }

        private void startAndStopButton1_OnCancelButtonClick(object sender, EventArgs e)
        {
            if (cancelTokenSource != null && !cancelTokenSource.IsCancellationRequested) 
            {
                cancelTokenSource.Cancel();
            }
        }
    }

    public class UDiskItem
    {
        public long TotalSize { get; set; }
        public String VolumeLabel { get; set; }

        public String Name { get; set; }

        public long TotalFreeSpace { get; set; }

        public override string ToString()
        {
            return String.Format("{0}({1})", this.Name ?? String.Empty, !String.IsNullOrWhiteSpace(this.VolumeLabel) ? this.VolumeLabel : "可移动磁盘");
        }
    }
}
