using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlHandler
{
    public partial class Form1 : Form
    {
        protected string _strXmlFile;
        protected XmlDocument _objXmlDoc = new XmlDocument();

        protected string _strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><detectdatas><visualdatas><body_der1>0</body_der1><body_der2>0</body_der2><body_daub1>0</body_daub1><body_daub2>0</body_daub2><pos_fnt_lft>0.0</pos_fnt_lft><pos_fnt_rgt>0.0</pos_fnt_rgt><pos_bk_lft>0.0</pos_bk_lft><pos_bk_rgt>0.0</pos_bk_rgt><door1>0</door1><door2>0</door2><door3>0</door3><turn_num>5.0</turn_num><body_size_l>0</body_size_l><body_size_w>0</body_size_w><body_size_h>0</body_size_h><bbbh>0</bbbh><inspect_xml><inspect_xml><Detect_item><id>1</id><item/><type>0</type><memo/><necessary>4</necessary></Detect_item><Detect_item><id>6</id><item/><type>0</type><memo/><necessary>6</necessary></Detect_item></inspect_xml></inspect_xml><only_xml><only_xml><Detect_item><id>14</id><item/><type>0</type><memo/><necessary>4</necessary></Detect_item></only_xml></only_xml><error_xml><error_xml><Detect_item><id>19</id><item/><type>0</type><memo/><necessary>4</necessary></Detect_item></error_xml></error_xml><surface_xml><surface_xml><Detect_item><id>26</id><item/><type>0</type><memo/><necessary>4</necessary></Detect_item><Detect_item><id>31</id><item/><type>0</type><memo/><necessary>4</necessary></Detect_item><Detect_item><id>48</id><item/><type>0</type><memo/><necessary>5</necessary></Detect_item></surface_xml></surface_xml><run_xml/><chassis_xml/><rank_xml/><survey_xml/><miles>12345</miles><trailer_body_size_l>0</trailer_body_size_l><trailer_body_size_w>0</trailer_body_size_w><trailer_body_size_h>0</trailer_body_size_h><trailer_bbbh>0</trailer_bbbh><trye_streak_turn_left1>0.0</trye_streak_turn_left1><trye_streak_turn_right1>0.0</trye_streak_turn_right1><trye_streak_turn_left2>0.0</trye_streak_turn_left2><trye_streak_turn_right2>0.0</trye_streak_turn_right2><trye_streak_other_left3>0.0</trye_streak_other_left3><trye_streak_other_right3>0.0</trye_streak_other_right3><trye_streak_other_left4>0.0</trye_streak_other_left4><trye_streak_other_right4>0.0</trye_streak_other_right4><trye_streak_other_left5>0.0</trye_streak_other_left5><trye_streak_other_right5>0.0</trye_streak_other_right5><pos_half_lft>0</pos_half_lft><pos_half_rgt>0</pos_half_rgt><pos_full_fnt_lft>0</pos_full_fnt_lft><pos_full_fnt_rgt>0</pos_full_fnt_rgt><pos_full_bk_lft>0</pos_full_bk_lft><pos_full_bk_rgt>0</pos_full_bk_rgt><train_body_size_l>0</train_body_size_l><train_body_size_w>0</train_body_size_w><train_body_size_h>0</train_body_size_h></visualdatas></detectdatas>";

        public Form1()
        {
            InitializeComponent();
            _strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><StudentInfo>	<BasicInfo><Name></Name><Age></Age>	</BasicInfo><ExScoreRlt><SubName>语文</SubName><SubScore>89</SubScore><SubRlt>通过</SubRlt>	</ExScoreRlt></StudentInfo>";
            try
            {
                //_objXmlDoc.LoadXml(_strXml);
                XmlReader _xReader = new XmlTextReader(new StringReader(_strXml));
                //DataView _dt = GetData("detectdatas");

                //XmlNodeList _nodeLst = GetXmlNote("detectdatas", "visualdatas", "");

                StudentInfo _s = new StudentInfo();

                _s.BasicInfo = new BasicInfo();
                _s.BasicInfo.Name = "小王";
                _s.BasicInfo.Age = 12;

                _s.Score = new exScore();
                ExamScoreRlt _exRlt = new ExamScoreRlt();
                _s.Score.Score = new List<ExamScoreRlt>();
                _exRlt.SubName = "数学";
                _exRlt.SubScore = 99;
                _exRlt.SubRlt = "通过";
                _s.Score.Score.Add(_exRlt);



                string _rlt = XmlSerializeHelper.Instance.XmlSerialize<StudentInfo>(_s);

                //StudentInfo _info = XmlSerializeHelper.Instance.XmlDeserialize<StudentInfo>(_strXml);


                #region 序列化xml格式测试
                Performance _perInfo = new Performance();
                //List<PerformanceItem> Performance = new List<PerformanceItem>();
                _perInfo.PerformanceItem = new List<PerformanceItem>();
                PerformanceItem _Item = new PerformanceItem();
                _Item.Id = 1;
                _Item.Itemname = "动力性";
                _Item.Limit = "45.3";
                _Item.Judgement = "≥41.8";
                _perInfo.PerformanceItem.Add(_Item);

                string _strJgXml = XmlSerializeHelper.Instance.XmlSerialize<Performance>(_perInfo);


                DetectDatas _modelDetectDatas = new DetectDatas();
                Detect_item _detItem = new Detect_item();
                _modelDetectDatas.VisualDatas = new VisualDatas();
                _modelDetectDatas.VisualDatas.Chassis_Xml = new List<Detect_item>();
                _modelDetectDatas.VisualDatas.Chassis_Xml.Add(_detItem);
                _modelDetectDatas.VisualDatas.Error_Xml = new List<Detect_item>();
                _modelDetectDatas.VisualDatas.Error_Xml.Add(_detItem);
                _modelDetectDatas.VisualDatas.Run_Xml = new List<Detect_item>();
                _modelDetectDatas.VisualDatas.Run_Xml.Add(_detItem);
                _modelDetectDatas.Roaddatas = new Roaddatas();

                _modelDetectDatas.VisualDatas.Survey_Xml = new Survey_Xml2();
                _modelDetectDatas.VisualDatas.Survey_Xml.Survey_Xml = new List<Detect_item>();
                _modelDetectDatas.VisualDatas.Survey_Xml.Survey_Xml.Add(_detItem);
                _modelDetectDatas.Roaddatas = new Roaddatas();

                string _strLsXml = XmlSerializeHelper.Instance.XmlSerialize<DetectDatas>(_modelDetectDatas);
                #endregion

                //if (_objXmlDoc.HasChildNodes)
                //    GetALLNode(_objXmlDoc.ChildNodes);
                //foreach (var item in _objXmlDoc.ChildNodes)
                //    {

                //    }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataView GetData(string XmlPathNode)
        {
            //查找数据。返回一个DataView 
            DataSet ds = new DataSet();
            StringReader read = new StringReader(_objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// <param name="_rootNode"></param>
        /// <param name="_2Node"></param>
        /// <param name="_3Node"></param>
        /// <returns></returns>
        public XmlNodeList GetXmlNote(string _rootNode, string _2Node, string _3Node)
        {
            //读取根节点的所有子节点，放到xn0中
            XmlNodeList _nodeList = _objXmlDoc.SelectSingleNode(_rootNode).ChildNodes;

            //查找二级节点的内容或属性
            foreach (XmlNode node in _nodeList)

            {

                if (node.Name == _2Node)
                {
                    string innertext = node.InnerText.Trim(); //匹配二级节点的内容
                    string attr = node.Attributes[0].ToString(); //属性
                }
            }

            return _nodeList;
        }

        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <param name="lst"></param>
        public void GetALLNode(XmlNodeList lst)
        {
            if (lst == null || lst.Count == 0) return;
            foreach (XmlNode node in lst)
            {
                //Console.WriteLine(node.Name + ":" + node.InnerText);//输入当前节点
                //tBReslt.AppendText(node.Name + ":" + node.InnerText + "\n");
                rtBRlt.AppendText(node.LocalName + "\n");
                if (node.HasChildNodes)
                {
                    GetALLNode(node.ChildNodes);
                }
            }
        }
    }


}
