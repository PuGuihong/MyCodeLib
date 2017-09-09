using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadApp
{
    public partial class ThreadAppForm : Form
    {
        public static int msgCount = 0;
        delegate void WritMsgCallBack(ResultMsg reMsg);
        //全局变量
        public int threadNum;

        public ThreadAppForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadAppForm_Load(object sender, EventArgs e)
        {
            //初始化 加载系统配置
            GetConstCfg();
            ThreadCreator();
        }

        /// <summary>
        /// 获取全局定义的参数
        /// </summary>
        private void GetConstCfg()
        {
            try
            {
                threadNum = string.IsNullOrEmpty(tbTheadCount.Text.Trim()) ? 1 : Convert.ToInt32(tbTheadCount.Text.Trim());
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void ThreadCreator()
        {
            for (int i = 0; i < threadNum; i++)
            {
                Thread _thread = new Thread(Fucn1);
                _thread.Start();
            }
        }

        private void Fucn1()
        {
            while (true)
            {
                ResultMsg _msg = new ResultMsg();
                _msg.num = msgCount++;
                _msg._msgDate = DateTime.Now.ToString();
                _msg._funStateDate = DateTime.Now;
                _msg._msg = "执行操作1";
                _msg._result = true;
                _msg._funEndDate = DateTime.Now;
                WriteMsg(_msg);
                Thread.Sleep(200);
            }
        }


        /// <summary>
        ///  采用回调方式，无阻塞写消息
        /// </summary>
        /// <param name="reMsg"></param>
        private void WriteMsg(ResultMsg reMsg)
        {
            StringBuilder strMsg = new StringBuilder();
            strMsg.Append("[" + reMsg.num
            + "] - [ "
            + reMsg._msgDate
            + "]:"
                //+ reMsg._msg
            + StringCut(reMsg._msg, 30, 0)
            + "       "
            + (reMsg._result == true ? "√" : "×")
            + "\n"
            );

            if (this.rtbMsg.InvokeRequired)
            {
                WritMsgCallBack _wmsgcb = new WritMsgCallBack(WriteMsg);
                this.Invoke(_wmsgcb, new object[] { reMsg });
            }
            else
            {
                rtbMsg.AppendText(strMsg.ToString());
            }
            rtbMsg.Focus();
            //rtbMsg.Select(rtbMsg.TextLength, 0);
            //rtbMsg.ScrollToCaret();
        }

        /// <summary>
        /// 消息字串截取
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="cutLenth"></param>
        /// <param name="startPo"></param>
        /// <returns></returns>
        private string StringCut(string strMsg, int cutLenth, int startPo = 0)
        {
            string strResult = "";
            strResult = strMsg;
            if (strMsg.Length - startPo > cutLenth)
            {
                strResult = strMsg.Substring(startPo, cutLenth);
            }
            return strResult;
        }

        /// <summary>
        /// 结果消息 结构体
        /// </summary>
        public struct ResultMsg
        {
            public int num;
            public string _msg;
            public bool _result;
            public DateTime _funStateDate;
            public DateTime _funEndDate;
            public string _msgDate;
        }

    }
}
