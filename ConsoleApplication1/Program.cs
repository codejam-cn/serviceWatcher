using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }



        }


    }
}
