using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
using Quartz.Core;
using System.Threading;
using Topshelf;
using System.IO;

namespace QuartzDemo
{
    public partial class QuartzForm : Form
    {
        public QuartzForm()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.Service<ServiceRunner>();

                x.SetDescription("QuartzDemo服务描述");
                x.SetDisplayName("QuartzDemo服务显示名称");
                x.SetServiceName("QuartzDemo服务名称");
                x.EnablePauseAndContinue();
            });
        }

        public void SendMsg()
        {
            rtbMsg.AppendText("send msg.");
        }
    }
}
