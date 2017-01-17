using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
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
            timer.Elapsed += Get;
            timer.Start();
        }


        public static void Get(object sender, ElapsedEventArgs e)
        {
            string[] secondRangeArr = ConfigurationManager.AppSettings["secondRange"].Split(new char[] { ',' });
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
            string url =  ConfigurationManager.AppSettings["watchIpAndPort"];

            using (var myPro = new Process())
            {
                myPro.StartInfo.FileName = "netstat -a";
                myPro.StartInfo.UseShellExecute = false;
                myPro.StartInfo.RedirectStandardInput = true;
                myPro.StartInfo.RedirectStandardOutput = true;
                myPro.StartInfo.RedirectStandardError = true;
                myPro.StartInfo.CreateNoWindow = true;
                myPro.Start();
                const string str = @"shutdown -f -s -t 300";
                myPro.StandardInput.WriteLine(str);
                myPro.StandardInput.AutoFlush = true;
                myPro.WaitForExit();
            }


            Process p = new Process
            {
                StartInfo = new ProcessStartInfo("netstat", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true
                }
            };
            p.Start();
            string result = p.StandardOutput.ReadToEnd();
            if (result.IndexOf(url, StringComparison.Ordinal) < 0)
            {
                using (var myPro = new Process())
                {
                    myPro.StartInfo.FileName = "net start FreeProxy";
                    myPro.StartInfo.UseShellExecute = false;
                    myPro.StartInfo.RedirectStandardInput = true;
                    myPro.StartInfo.RedirectStandardOutput = true;
                    myPro.StartInfo.RedirectStandardError = true;
                    myPro.StartInfo.CreateNoWindow = true;
                    myPro.Start();

                }
            }
        }


        protected override void OnStop()
        {
        }
    }
}
