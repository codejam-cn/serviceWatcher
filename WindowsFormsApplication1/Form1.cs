using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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

        private async void ClickMeBtn_Click(object sender, EventArgs e)
        {
            //this.ClickMeBtn.Enabled = false;

            long length = AccessWeb();
            
            //long length = await AsyncAccessWeb();
            OtherWork();
            //this.ClickMeBtn.Enabled = true;
            
            this.richTextBox1.Text += string.Format("\n 回复的字节长度为:  {0}.\r\n", length);
            
            this.MaintextBox1.Text = Thread.CurrentThread.ManagedThreadId.ToString();
        }

        private void OtherWork()
        {
            this.richTextBox1.Text = "\r\n等待服务器回复中.................\n";
        }

        private long AccessWeb()
        {
            MemoryStream content = new MemoryStream();

            const string url = "http://msdn.microsoft.com/zh-cn/";

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        Debug.Assert(responseStream != null, "responseStream != null");
                        responseStream.CopyTo(content);
                    }
                }
            }
            SlavetextBox2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            return content.Length;
        }


        private async Task<long>  AsyncAccessWeb()
        {
            MemoryStream content = new MemoryStream();

            const string url = "http://msdn.microsoft.com/zh-cn/";

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                using (WebResponse response = await webRequest.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        Debug.Assert(responseStream != null, "responseStream != null");
                        await responseStream.CopyToAsync(content);
                    }
                }
            }
            SlavetextBox2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            return content.Length;
        }

        
    }
}
