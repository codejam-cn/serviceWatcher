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
            try
            {
                string watchServiceName = ConfigurationManager.AppSettings["watchServiceName"];
                string startServiceName = ConfigurationManager.AppSettings["startserviceName"];
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";//设置启动的应用程序  
                p.StartInfo.UseShellExecute = false;//禁止使用操作系统外壳程序启动进程  
                p.StartInfo.RedirectStandardInput = true;//应用程序的输入从流中读取  
                p.StartInfo.RedirectStandardOutput = true;//应用程序的输出写入流中  
                p.StartInfo.RedirectStandardError = true;//将错误信息写入流  
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(@"net start" + "&exit");
                bool isRunning = false;

                string output = p.StandardOutput.ReadToEnd();
                if (output.Contains(watchServiceName))
                {
                    isRunning = true;
                }
                //
                p.StandardInput.Flush();
                p.StandardInput.AutoFlush = true;
                p.Start();
                if (!isRunning)
                {
                    p.StandardInput.WriteLine("net start {0}", startServiceName);
                }
                p.WaitForExit();
                p.Close();
            }
            catch (Exception)
            {
                throw new NotSupportedException();
            }
        }

        protected override void OnStop()
        {
        }
    }
}
