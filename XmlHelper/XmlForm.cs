using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlHelper
{
    public partial class XmlForm : Form
    {
        public XmlForm()
        {
            InitializeComponent();
        }

        private void btn_CreateXml_Click(object sender, EventArgs e)
        {
            //这是XML文档根节点名
            string rootNodeName = "books";

            //这是XML文档物理文件名（包含物理路径）
            string xmlFileName = Application.StartupPath + @"\cfg.xml";

            XmlHelper.CreateXmlDocument(xmlFileName, rootNodeName, "1.0", "utf-8", null);
            MessageBox.Show("XML文档创建成功:" + xmlFileName);
        }

        private void btn_CreateNodes_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            string xpath = "/books";  //这是新节点的父节点路径
            string nodename = "book";　//这是新节点名称,在父节点下新增
            string nodetext = "这是新节点中的文本值";

            bool isSuccess = XmlHelper.CreateOrUpdateXmlNodeByXPath(xmlFileName, xpath, nodename, nodetext);
            MessageBox.Show("XML节点添加或更新成功:" + isSuccess.ToString());
        }

        private void btn_DeleteNodes_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            string xpath = "/books/book";  //这是新子节点的父节点路径
            string nodename = "name";　//这是新子节点名称,在父节点下新增
            string nodetext = "我的世界我的梦";

            bool isSuccess = XmlHelper.CreateOrUpdateXmlNodeByXPath(xmlFileName, xpath, nodename, nodetext);
            MessageBox.Show("XML节点添加或更新成功:" + isSuccess.ToString());
        }

        private void btn_AlertNodesVal_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            string xpath = "/books/book"; //要新增属性的节点
            string attributeName = "id";　//新属性名称,ISDN号也是这么新增的
            string attributeValue = "1";　//新属性值

            bool isSuccess = XmlHelper.CreateOrUpdateXmlAttributeByXPath(xmlFileName, xpath, attributeName, attributeValue);
            MessageBox.Show("XML属性添加或更新成功:" + isSuccess.ToString());
        }

        private void btn_DeleteChildrenNodes_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            string xpath = "/books/book[@id='1']"; //要删除的id为1的book子节点

            bool isSuccess = XmlHelper.DeleteXmlNodeByXPath(xmlFileName, xpath);
            MessageBox.Show("XML节点删除成功:" + isSuccess.ToString());
        }

        private void btn_DeleteChildrenNodesVal_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            //删除id为2的book子节点中的ISDN属性
            string xpath = "/books/book[@id='2']";
            string attributeName = "ISDN";

            bool isSuccess = XmlHelper.DeleteXmlAttributeByXPath(xmlFileName, xpath, attributeName);
            MessageBox.Show("XML属性删除成功:" + isSuccess.ToString());
        }

        private void btn_GetAllNodes_Click(object sender, EventArgs e)
        {
            string xmlFileName = Application.StartupPath + @"\cfg.xml";
            //要读的id为1的book子节点
            string xpath = "/books/book[@id='1']";

            XmlNodeList nodeList = XmlHelper.GetXmlNodeListByXpath(xmlFileName, xpath);
            string strAllNode = "";
            //遍历节点中所有的子节点
            foreach (XmlNode node in nodeList)
            {
                strAllNode += "\n name:" + node.Name + " InnerText:" + node.InnerText;
            }

            MessageBox.Show("XML节点中所有子节点有:" + strAllNode);
        }
    }
}
