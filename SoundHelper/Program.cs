using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoundHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入车辆号牌：\n");
            string _iptNumStr = Console.ReadLine();

            Console.WriteLine(Play(_iptNumStr, "3", 0));
            Console.ReadLine();
        }

        static object synchLock = new object();
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="PH">号牌：A0001</param>
        /// <param name="Window">窗口号：3</param>
        /// <param name="ShortSpeak">只有叮咚声（0表示完整声音，1表示只有叮咚声）</param>
        public static bool Play(string PH, string Window, int ShortSpeak = 1)
        {
            lock (synchLock)
            {
                try
                {
                    //string RootDir = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
                    string RootDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                    sp.SoundLocation = RootDir + "\\wavLib\\DingDong_1.wav";
                    sp.Play();
                    Thread.Sleep(1500);
                    if (ShortSpeak == 1)
                    {
                        return true;
                    }
                    sp.SoundLocation = RootDir + "\\wavLib\\请.wav";
                    sp.Play();
                    Thread.Sleep(500);
                    for (int i = 0; i < PH.Length; i++)
                    {
                        sp.SoundLocation = RootDir + "\\wavLib\\" + PH[i] + ".wav";
                        sp.Play(); Thread.Sleep(500);
                    }
                    sp.SoundLocation = RootDir + "\\wavLib\\\\号顾客到.wav"; sp.Play(); Thread.Sleep(1500);
                    sp.SoundLocation = RootDir + "\\wavLib\\\\" + Window + ".wav"; sp.Play(); Thread.Sleep(500);
                    sp.SoundLocation = RootDir + "\\wavLib\\\\号窗口办理业务.wav"; sp.Play(); Thread.Sleep(2000);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
