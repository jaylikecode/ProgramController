using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramController
{
    public partial class ProgramControllerForm : Form
    {
        private readonly Dictionary<string, string> _exeProgramDic = new Dictionary<string, string>();

        private Dictionary<string, Label> labelDic = new Dictionary<string, Label>();

        public ProgramControllerForm()
        {
            InitializeComponent();

            string exeName = ConfigurationSettings.AppSettings["ProgramName"];
            string exePath = ConfigurationSettings.AppSettings["ProgramPath"];

            this.GetDealPrograms(exeName, exePath);
            this.InitUserInterface();
        }

        private void InitUserInterface()
        {
            int pointX = 10, pointY = 20;
            foreach (KeyValuePair<string, string> exeKeyValuePair in this._exeProgramDic)
            {
                if (!exeKeyValuePair.Value.EndsWith("exe"))
                {
                    //throw new Exception("目前只支持exe程序守护");
                    continue;
                }
                Label labelName = new Label
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Text = $"{exeKeyValuePair.Key}：",
                    Location = new Point(pointX, pointY),
                    Name = "labelName",
                    Size = new Size(90, 12),
                    TabIndex = 0
                };
                this.DemoGB.Controls.Add(labelName);
                TextBox tbPath = new TextBox
                {
                    Anchor = (AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right,
                    Location = new Point(pointX + labelName.Width + 5, pointY - 4),
                    Name = "tbPath",
                    Text = exeKeyValuePair.Value,
                    Size = new Size(350, 20)
                };
                this.DemoGB.Controls.Add(tbPath);

                Label labelStatus = new Label();
                labelStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                labelStatus.Location = new Point(pointX + 350 + 80 + 50, pointY);
                labelStatus.Size = new Size(40, 12);
                labelStatus.BackColor = Color.Azure;
                labelStatus.Text = "ToDo...";
                labelStatus.Name = "labelStatus";
                string processName = exeKeyValuePair.Value.Split(@"\\").Last();
                this.labelDic.Add(processName, labelStatus);
                this.DemoGB.Controls.Add(labelStatus);

                pointY += labelName.Height + 15;
            }
            this.DemoGB.Refresh();
        }

        private void GetDealPrograms(string exeName, string exePath)
        {
            string[] exeNames = exeName.Split('|');
            string[] exePaths = exePath.Split('|');

            if (exeNames.Count() != exePaths.Count())
            {
                throw new Exception("程序与程序路径不匹配");
                return;
            }

            for (var i = 0; i < exeNames.Count(); i++)
            {
                this._exeProgramDic.Add(exeNames[i], exePaths[i]);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(this.StartProgram);
            th.Start();

            Thread thDaemon = new Thread(this.ExeProcessDaemon);
            thDaemon.Start();
        }

        private void StartProgram()
        {
            foreach (KeyValuePair<string, string> keyValuePair in _exeProgramDic)
            {
                Process.Start(keyValuePair.Value);
            }
        }

        private void ExeProcessDaemon()
        {
            while (true)
            {
                Thread th = new Thread(this.ProcessDaemon);
                th.Start();
                Thread.Sleep(1000 * 5);
            }
        }

        private void ProcessDaemon()
        {
            foreach (KeyValuePair<string, Label> pair in labelDic)
            {
                Process process = Process.GetProcessesByName(pair.Key)[0];
                Console.WriteLine("进程名称：" + process.ProcessName);
                Console.WriteLine("进程ID：" + process.Id.ToString());
                Console.WriteLine("启动时间：" + process.StartTime.ToLongDateString() + process.StartTime.ToLongTimeString());
                Console.WriteLine("是否响应：" + process.Responding.ToString());
            }
        }


    }
}
