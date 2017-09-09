using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1__FTPS_文件传输协议
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DownLoadFile("ftp://11.101.2.204/web.config");
        }


        public static void DownLoadFile(string addr)
        {
            var req = (FtpWebRequest)WebRequest.Create(addr);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.UseBinary = true;
            req.UsePassive = true;
            const string userName = "administrator";
            const string password = "scxd_dev";
            req.Credentials = new NetworkCredential(userName, password);

            //如果要连接的 FTP 服务器要求凭据并支持安全套接字层 (SSL)，则应将 EnableSsl 设置为 true。
            //如果不写会报出421错误（服务不可用）
            req.EnableSsl = true;

            // 首次连接FTP server时，会有一个证书分配过程。
            //如果没有下面的代码会报异常：
            //System.Security.Authentication.AuthenticationException: 根据验证过程，远程证书无效。
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            try
            {
                using (var res = (FtpWebResponse)req.GetResponse())
                {
                    const string localfile = "test.config";
                    var fs = new FileStream(localfile, FileMode.Create, FileAccess.Write);
                    const int buffer = 1024 * 1000;
                    var b = new byte[buffer];
                    var i = 0;
                    var stream = res.GetResponseStream();
                    while (stream != null && (i = stream.Read(b, 0, buffer)) > 0)
                    {
                        fs.Write(b, 0, i);
                        fs.Flush();
                    }
                }
                Console.WriteLine("下载成功!");

            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                Console.WriteLine(message);
            }
            finally
            {

            }
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
