using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthCode
{
    public partial class AuthCOde : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string validateNum = CreateRandomNum(4);
                CreateImg(validateNum);
                Session["ValidateNum"] = validateNum;
            }
        }


        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public string CreateRandomNum(int numCount)
        {
            string _charPool = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,O,P,Q,R,S,T,U,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,s,t,u,w,x,y,z";
            string[] _charPoolArry = _charPool.Split(',');
            string _randomStr = "";
            int _tmpint = -1;

            Random _random = new Random();
            for (int i = 0; i < numCount; i++)
            {
                if (_tmpint != -1)
                {
                    _random = new Random(i * _tmpint * (int)DateTime.Now.Ticks);
                }
                int _tmpNxtInt = _random.Next(35);
                if (_tmpint == _tmpNxtInt)
                {
                    return CreateRandomNum(numCount);
                }
                _tmpint = _tmpNxtInt;
                _randomStr += _charPoolArry[_tmpNxtInt];
            }
            return _randomStr;
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="validNum"></param>
        private void CreateImg(string validNum)
        {
            if (string.IsNullOrEmpty(validNum))
            {
                return;
            }

            System.Drawing.Bitmap _creatImg = new System.Drawing.Bitmap(validNum.Length * 12 + 12, 22);
            Graphics _graphics = Graphics.FromImage(_creatImg);

            try
            {
                Random _random = new Random();

                _graphics.Clear(Color.White);

                for (int i = 0; i < 25; i++)
                {
                    int x1 = _random.Next(_creatImg.Width);
                    int x2 = _random.Next(_creatImg.Width);
                    int y1 = _random.Next(_creatImg.Height);
                    int y2 = _random.Next(_creatImg.Height);
                    _graphics.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }

                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, _creatImg.Width, _creatImg.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                _graphics.DrawString(validNum, font, brush, 2, 2);


                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = _random.Next(_creatImg.Width);
                    int y = _random.Next(_creatImg.Height);
                    _creatImg.SetPixel(x, y, Color.FromArgb(_random.Next()));

                }

                //画图片的边框线
                _graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, _creatImg.Width - 1, _creatImg.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //将图像保存到指定流
                _creatImg.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _graphics.Dispose();
                _creatImg.Dispose();
            }
        }
    }
}