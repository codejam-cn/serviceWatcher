using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace FreeProxyWatcher
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string intervalMs = ConfigurationManager.AppSettings["intervalMs"];
            int interval = int.Parse(intervalMs);
            var timer = new Timer(interval);
            timer.Elapsed += Run;
            timer.Start();
        }


        public static void Run(object sender, ElapsedEventArgs e)
        {
            string[] secondRangeArr = ConfigurationManager.AppSettings["secondRange"].Split(',');
            int minSec = int.Parse(secondRangeArr[0]);
            int maxSec = int.Parse(secondRangeArr[1]);

            var second = e.SignalTime.Second;
            if (second > minSec && second < maxSec)
            {
                CheckFreeProxyServiceState();
            }
        }

        public static void CheckFreeProxyServiceState()
        {
            string url = ConfigurationManager.AppSettings["watchIpAndPort"];
            string serviceName = ConfigurationManager.AppSettings["serviceName"];
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//设置启动的应用程序  
            p.StartInfo.UseShellExecute = false;//禁止使用操作系统外壳程序启动进程  
            p.StartInfo.RedirectStandardInput = true;//应用程序的输入从流中读取  
            p.StartInfo.RedirectStandardOutput = true;//应用程序的输出写入流中  
            p.StartInfo.RedirectStandardError = true;//将错误信息写入流  
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(@"netstat -a -n");
            bool isRunning = false;
            while ((p.StandardOutput.ReadLine()) != null)
            {
                var str = p.StandardOutput.ReadLine();
                if (str != null && str.IndexOf(url, StringComparison.Ordinal) != -1 && str.IndexOf("ESTABLISHED", StringComparison.Ordinal) != -1)
                {
                    isRunning = true;
                    break;
                }
            }
            p.StandardInput.Flush();
            p.StandardInput.AutoFlush = true;
            p.Start();
            p.StandardInput.WriteLine("net {0} {1}", isRunning ? "start" : "stop", serviceName);
            p.WaitForExit();
            p.Close();
        }

        protected override void OnStop()
        {
        }
    }
}
