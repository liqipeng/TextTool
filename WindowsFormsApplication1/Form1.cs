﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread cmdThread;  
        private Action<string> rf;  
  
        /// <summary>  
        /// 按CTRL+Enter键开始执行命令  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)  
        {  
            if (e.KeyCode == Keys.Enter && e.Control)  
            {  
                if (this.button3.Enabled)  
                    this.button3_Click(null, null);  
                else  
                    this.button4_Click(null, null);  
            }  
        }  
  
        private void Form2_Load(object sender, EventArgs e)  
        {  
            this.textBox1.Text = "help\r\ndir\r\nping 127.0.0.1";  
            rf = this.refreshCmdTxt;  
            this.richTextBox1.AppendText("Dos命令执行程序，支持批命令执行。按Ctrl+Enter键开始执行。如果一个命令长时间不能结束的，如ping 127.0.0.1 -t，“停止执行”按钮可强制终止执行。\r\n");
            this.richTextBox1.AppendText("\r\n你的网卡Mac地址:" + "NetCardId");
            this.richTextBox1.AppendText("，Cpu序列号:" + "CpuId");
            this.richTextBox1.AppendText("，硬盘序列号:" + "HardDiskId" + "\r\n");  
            this.richTextBox1.AppendText("\r\n常用的命令：\r\n");  
            this.richTextBox1.AppendText(@"    ASSOC          显示或修改文件扩展名关联。  
    ATTRIB         显示或更改文件属性。  
    BREAK          设置或清除扩展式 CTRL+C 检查。  
    BCDEDIT        设置启动数据库中的属性以控制启动加载。  
    CACLS          显示或修改文件的访问控制列表(ACL)。  
    CALL           从另一个批处理程序调用这一个。  
    CD             显示当前目录的名称或将其更改。  
    CHCP           显示或设置活动代码页数。  
    CHDIR          显示当前目录的名称或将其更改。  
    CHKDSK         检查磁盘并显示状态报告。  
    CHKNTFS        显示或修改启动时间磁盘检查。  
    CLS            清除屏幕。  
    CMD            打开另一个 Windows 命令解释程序窗口。  
    COLOR          设置默认控制台前景和背景颜色。  
    COMP           比较两个或两套文件的内容。  
    COMPACT        显示或更改 NTFS 分区上文件的压缩。  
    CONVERT        将 FAT 卷转换成 NTFS。您不能转换当前驱动器。  
    COPY           将至少一个文件复制到另一个位置。  
    DATE           显示或设置日期。  
    DEL            删除至少一个文件。  
    DIR            显示一个目录中的文件和子目录。  
    DISKCOMP       比较两个软盘的内容。  
    DISKCOPY       将一个软盘的内容复制到另一个软盘。  
    DISKPART       显示或配置磁盘分区属性。  
    DOSKEY         编辑命令行、调用 Windows 命令并创建宏。  
    DRIVERQUERY    显示当前设备驱动程序状态和属性。  
    ECHO           显示消息，或将命令回显打开或关上。  
    ENDLOCAL       结束批文件中环境更改的本地化。  
    ERASE          删除一个或多个文件。  
    EXIT           退出 CMD.EXE 程序(命令解释程序)。  
    FC             比较两个文件或两个文件集并显示它们之间的不同。  
    FIND           在一个或多个文件中搜索一个文本字符串。  
    FINDSTR        在多个文件中搜索字符串。  
    FOR            为一套文件中的每个文件运行一个指定的命令。  
    FORMAT         格式化磁盘，以便跟 Windows 使用。  
    FSUTIL         显示或配置文件系统的属性。  
    FTYPE          显示或修改用在文件扩展名关联的文件类型。  
    GOTO           将 Windows 命令解释程序指向批处理程序中某个带标签的行。  
    GPRESULT       显示机器或用户的组策略信息。  
    GRAFTABL       启用 Windows 在图形模式显示扩展字符集。  
    HELP           提供 Windows 命令的帮助信息。  
    ICACLS         显示、修改、备份或还原文件和目录的 ACL。  
    IF             在批处理程序中执行有条件的处理过程。  
    IPCONFIG       网络配置  
    LABEL          创建、更改或删除磁盘的卷标。  
    MD             创建一个目录。  
    MKDIR          创建一个目录。  
    MKLINK         创建符号链接和硬链接  
    MODE           配置系统设备。  
    MORE           逐屏显示输出。  
    MOVE           将一个或多个文件从一个目录移动到另一个目录。  
    NET            这个命令太强大了，net help自己看看吧  
    NETSTAT        网络状态  
    OPENFILES      显示远程用户为了文件共享而打开的文件。  
    PATH           为可执行文件显示或设置搜索路径。  
    PAUSE          停止批处理文件的处理并显示信息。  
    PING           检测网络是否通畅  
    POPD           还原由 PUSHD 保存的当前目录上一次的值。  
    PRINT          打印一个文本文件。  
    PROMPT         改变 Windows 命令提示。  
    PUSHD          保存当前目录，然后对其进行更改。  
    RD             删除目录。  
    RECOVER        从损坏的磁盘中恢复可读取的信息。  
    REM            记录批处理文件或 CONFIG.SYS 中的注释。  
    REN            重新命名文件。  
    RENAME         重新命名文件。  
    REPLACE        替换文件。  
    RMDIR          删除目录。  
    ROBOCOPY       复制文件和目录树的高级实用程序  
    ROUTE          路由命令  
    SET            显示、设置或删除 Windows 环境变量。  
    SETLOCAL       开始用批文件改变环境的本地化。  
    SC             显示或配置服务(后台处理)。  
    SCHTASKS       安排命令和程序在一部计算机上按计划运行。  
    SHIFT          调整批处理文件中可替换参数的位置。  
    SHUTDOWN       让机器在本地或远程正确关闭。  
    SORT           将输入排序。  
    START          打开单独视窗运行指定程序或命令。  
    SUBST          将驱动器号与路径关联。  
    SYSTEMINFO     显示机器的具体的属性和配置。  
    TASKLIST       显示包括服务的所有当前运行的任务。  
    TASKKILL       终止正在运行的进程或应用程序。  
    TIME           显示或设置系统时间。  
    TITLE          设置 CMD.EXE 会话的窗口标题。  
    TRACERT        用于将数据包从计算机传递到目标位置的一组IP路由器，以及每个跃点所需的时间。  
    TREE           以图形显示启动器或路径的目录结构。  
    TYPE           显示文本文件的内容。  
    VER            显示 Windows 的版本。  
    VERIFY         告诉 Windows 验证文件是否正确写入磁盘。  
    VOL            显示磁盘卷标和序列号。  
    XCOPY          复制文件和目录树。  
    WMIC           在交互命令外壳里显示 WMI 信息。");  
  
        }  
  
        private void StartCmd()  
        {  
            Cmd.InvokeCmd(this.textBox1.Text, this.refreshCmdTxt);  
        }  
  
        /// <summary>  
        /// 显示返回结果  
        /// </summary>  
        /// <param name="txt"></param>  
        private void refreshCmdTxt(string txt)  
        {  
            if (!this.Visible) return;  
            if (this.richTextBox1.InvokeRequired)  
            {  
                try  
                {  
                    this.richTextBox1.Invoke(this.rf, txt);  
                }  
                catch { }  
            }  
            else  
            {  
                this.richTextBox1.AppendText(txt);  
                this.richTextBox1.ScrollToCaret();  
            }  
        }  
        /// <summary>  
        /// 停止执行  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button1_Click(object sender, EventArgs e)  
        {  
            Cmd.InvokeCmdKilled = true;  
            this.button3.Enabled = true;  
        }  
        /// <summary>  
        /// 清空返回结果  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button2_Click(object sender, EventArgs e)  
        {  
            this.richTextBox1.Clear();  
        }  
        /// <summary>  
        /// 开始执行命令  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button3_Click(object sender, EventArgs e)  
        {  
            if (cmdThread != null && !Cmd.InvokeCmdKilled)  
            {  
                MessageBox.Show("程序正在执行中，请稍候或中止后再执行！");  
                return;  
            }  
            if (string.IsNullOrEmpty(this.textBox1.Text)) return;  
            if (cmdThread != null)  
            {  
                cmdThread.Abort();  
                cmdThread = null;  
            }  
            cmdThread = new Thread(StartCmd);  
            cmdThread.Start();  
            this.button3.Enabled = false;  
        }  
  
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)  
        {  
            if (cmdThread != null)  
            {  
                cmdThread.Abort();  
                cmdThread = null;  
            }  
        }  
        /// <summary>  
        /// 输入交互式命令  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button4_Click(object sender, EventArgs e)  
        {  
            if (cmdThread == null)  
                return;  
            Cmd.InputCmdLine(this.textBox1.Text);  
        }  
        /// <summary>  
        /// 输入退出命令  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button5_Click(object sender, EventArgs e)  
        {  
            if (cmdThread == null)  
                return;  
            Cmd.InputCmdLine("exit");  
            this.button3.Enabled = true;  
        }  
  
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)  
        {  
            Cmd.InvokeCmdKilled = true;  
        }  
    }
}
