using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlHandler
{
    [Serializable]
    public class DetectDatas
    {

        public VisualDatas VisualDatas;
        public Roaddatas Roaddatas;
    }


    /// <summary>
    /// 人工检验结果信息
    /// </summary>
    [Serializable]
    public class VisualDatas
    {
        private int _body_der1;
        //车身与驾驶室轻微开裂，锈蚀和明显变形处数--
        public int Body_Der1 { set { _body_der1 = value; } get { return _body_der1; } }
        private int _body_der2;
        //车身与驾驶室缺陷部位是否影响安全性和密封性,0为 
        public int Body_Der2 { set { _body_der2 = value; } get { return _body_der2; } }
        private int _body_daub1;
        //车身表面涂装-有无明显破损,0为有，1为无--
        public int Body_Daub1 { set { _body_daub1 = value; } get { return _body_daub1; } }
        private int _body_daub2;
        //车身表面涂装-补漆颜色与原色是否一致,0为是，1为 
        public int Body_Daub2 { set { _body_daub2 = value; } get { return _body_daub2; } }
        private float _pos_fnt_lft;
        //单车对称部位高度差-前左--
        public float Pos_Fnt_lft { set { _pos_fnt_lft = value; } get { return _pos_fnt_lft; } }
        private float _pos_fnt_rgt;
        //单车对称部位高度差-前右--
        public float Pos_Fnt_rgt { set { _pos_fnt_rgt = value; } get { return _pos_fnt_rgt; } }
        private float _pos_bk_lft;
        //单车对称部位高度差-后左--
        public float Pos_Bk_lft { set { _pos_bk_lft = value; } get { return _pos_bk_lft; } }
        private float _pos_bk_rgt;
        //单车对称部位高度差-后右--
        public float Pos_Bk_rgt { set { _pos_bk_rgt = value; } get { return _pos_bk_rgt; } }
        private int _pos_half_lft;
        //对称部位高度差(mm)半挂左--
        public int Pos_Half_lft { set { _pos_half_lft = value; } get { return _pos_half_lft; } }
        private int _pos_half_rgt;
        //对称部位高度差(mm)半挂右--
        public int Pos_Half_rgt { set { _pos_half_rgt = value; } get { return _pos_half_rgt; } }
        private int _pos_full_fnt_lft;
        //对称部位高度差(mm)全挂前左--
        public int Pos_Full_fnt_lft { set { _pos_full_fnt_lft = value; } get { return _pos_full_fnt_lft; } }
        private int _pos_full_fnt_rgt;
        //对称部位高度差(mm)全挂前右--
        public int Pos_Full_fnt_rgt { set { _pos_full_fnt_rgt = value; } get { return _pos_full_fnt_rgt; } }
        private int _pos_full_bk_lft;
        //对称部位高度差(mm)全挂后左--
        public int Pos_Full_bk_lft { set { _pos_full_bk_lft = value; } get { return _pos_full_bk_lft; } }
        private int _pos_full_bk_rgt;
        //对称部位高度差(mm)全挂后右--
        public int Pos_Full_bk_rgt { set { _pos_full_bk_rgt = value; } get { return _pos_full_bk_rgt; } }
        private int _door1;
        //门窗玻璃-是否完全完好,0为是，1为否--
        public int Door1 { set { _door1 = value; } get { return _door1; } }
        private int _door2;
        //门窗玻璃-有无大于25mm且易破碎的裂纹和穿孔,0为有   
        public int Door2 { set { _door2 = value; } get { return _door2; } }
        private int _door3;
        //门窗玻璃-是否密封良好,0为是，1为否--
        public int Door3 { set { _door3 = value; } get { return _door3; } }
        private float _turn_num;
        //转向盘最大自由转运量--
        public float Turn_Num { set { _turn_num = value; } get { return _turn_num; } }
        private int _turn_num_jus;
        //转向盘最大自由转运量判定--
        public int Turn_Num_jus { set { _turn_num_jus = value; } get { return _turn_num_jus; } }
        private float _trye_streak_turn_left1;
        //轮胎花纹深度(mm)转向轮1左--
        public float Trye_Streak_turn_left1 { set { _trye_streak_turn_left1 = value; } get { return _trye_streak_turn_left1; } }
        private float _trye_streak_turn_right1;
        //轮胎花纹深度(mm)转向轮1右--
        public float Trye_Streak_turn_right1 { set { _trye_streak_turn_right1 = value; } get { return _trye_streak_turn_right1; } }
        private float _trye_streak_turn_left2;
        //轮胎花纹深度(mm)转向轮2左--
        public float Trye_Streak_turn_left2 { set { _trye_streak_turn_left2 = value; } get { return _trye_streak_turn_left2; } }
        private float _trye_streak_turn_right2;
        //轮胎花纹深度(mm)转向轮2右--
        public float Trye_Streak_turn_right2 { set { _trye_streak_turn_right2 = value; } get { return _trye_streak_turn_right2; } }
        private float _trye_streak_other_left3;
        //轮胎花纹深度(mm)其他轮3左--
        public float Trye_Streak_other_left3 { set { _trye_streak_other_left3 = value; } get { return _trye_streak_other_left3; } }
        private float _trye_streak_other_right3;
        //轮胎花纹深度(mm)其他轮3右--
        public float Trye_Streak_other_right3 { set { _trye_streak_other_right3 = value; } get { return _trye_streak_other_right3; } }
        private float _trye_streak_other_left4;
        //轮胎花纹深度(mm)其他轮4左--
        public float Trye_Streak_other_left4 { set { _trye_streak_other_left4 = value; } get { return _trye_streak_other_left4; } }
        private float _trye_streak_other_right4;
        //轮胎花纹深度(mm)其他轮4右--
        public float Trye_Streak_other_right4 { set { _trye_streak_other_right4 = value; } get { return _trye_streak_other_right4; } }
        private float _trye_streak_other_left5;
        //轮胎花纹深度(mm)其他轮5左--
        public float Trye_Streak_other_left5 { set { _trye_streak_other_left5 = value; } get { return _trye_streak_other_left5; } }
        private float _trye_streak_other_right5;
        //轮胎花纹深度(mm)其他轮5右--
        public float Trye_Streak_other_right5 { set { _trye_streak_other_right5 = value; } get { return _trye_streak_other_right5; } }
        private int _body_size_l;
        //单车外廓尺寸长--
        public int Body_Size_l { set { _body_size_l = value; } get { return _body_size_l; } }
        private int _body_size_w;
        //单车外廓尺寸宽--
        public int Body_Size_w { set { _body_size_w = value; } get { return _body_size_w; } }
        private int _body_size_h;
        //单车外廓尺寸高--
        public int Body_Size_h { set { _body_size_h = value; } get { return _body_size_h; } }
        private int _bbbh;
        //单车车厢栏板高度--
        public int Bbbh { set { _bbbh = value; } get { return _bbbh; } }
        private int _trailer_body_size_l;
        //挂车外廓长度--
        public int Trailer_Body_size_l { set { _trailer_body_size_l = value; } get { return _trailer_body_size_l; } }
        private int _trailer_body_size_w;
        //挂车外廓宽度--
        public int Trailer_Body_size_w { set { _trailer_body_size_w = value; } get { return _trailer_body_size_w; } }
        private int _trailer_body_size_h;
        //挂车外廓高度--
        public int Trailer_Body_size_h { set { _trailer_body_size_h = value; } get { return _trailer_body_size_h; } }
        private int _train_body_size_l;
        //列车外廓尺寸(mm)长--
        public int Train_Body_size_l { set { _train_body_size_l = value; } get { return _train_body_size_l; } }
        private int _train_body_size_w;
        //列车外廓尺寸(mm)宽--
        public int Train_Body_size_w { set { _train_body_size_w = value; } get { return _train_body_size_w; } }
        private int _train_body_size_h;
        //列车外廓尺寸(mm)高--
        public int Train_Body_size_h { set { _train_body_size_h = value; } get { return _train_body_size_h; } }
        private int _trailer_bbbh;
        //挂车车厢栏板高度--
        public int Trailer_Bbbh { set { _trailer_bbbh = value; } get { return _trailer_bbbh; } }
        private List<Detect_item> _inspect_xml;
        //核查评定xml,内容见下方检验项目结果说明--
        public List<Detect_item> Inspect_Xml { set { _inspect_xml = value; } get { return _inspect_xml; } }
        private List<Detect_item> _only_xml;
        //唯一性xml,内容见下方检验项目结果说明--
        public List<Detect_item> Only_Xml { set { _only_xml = value; } get { return _only_xml; } }
        private List<Detect_item> _error_xml;
        //故障信息诊断xml,内容见下方检验项目结果说明--
        public List<Detect_item> Error_Xml { set { _error_xml = value; } get { return _error_xml; } }
        private List<Detect_item> _surface_xml;
        //外观检查xml,内容见下方说明--
        public List<Detect_item> Surface_Xml { set { _surface_xml = value; } get { return _surface_xml; } }
        //private List<Detect_item> _run_xml;
        //运行检查xml, 内容见下方检验项目结果说明   
        //public List<Detect_item> Run_Xml { set { _run_xml = value; } get { return _run_xml; } }
        public List<Detect_item> Run_Xml { get; set; }
        private List<Detect_item> _chassis_xml;
        //底盘检查xml,内容见下方检验项目结果说明--
        public List<Detect_item> Chassis_Xml { set { _chassis_xml = value; } get { return _chassis_xml; } }
        private string _rank_xml;
        //分级项xml,内容见下方检验项目结果说明--
        public string Rank_Xml { set { _rank_xml = value; } get { return _rank_xml; } }
        private Survey_Xml2 _survey_xml;
        //测量项xml,内容见下方检验项目结果说明--
        public Survey_Xml2 Survey_Xml { set { _survey_xml = value; } get { return _survey_xml; } }
        private int _miles;
        //里程数--
        public int Miles { set { _miles = value; } get { return _miles; } }
    }

    public class Survey_Xml2
    {
        public List<Detect_item> Survey_Xml { get; set; }
    }

    /// <summary>
    /// 路度数据，判定值参照文档约定中的说明
    /// </summary>
    [Serializable]
    public class Roaddatas
    {
        private float _init_speed;
        //初速度--
        public float Init_Speed { set { _init_speed = value; } get { return _init_speed; } }
        private float _road_width;
        //试车道宽度--
        public float Road_Width { set { _road_width = value; } get { return _road_width; } }
        private float _brake_dis;
        //制动距离--
        public float Brake_Dis { set { _brake_dis = value; } get { return _brake_dis; } }
        private float _mfdd;
        //mfdd--
        public float Mfdd { set { _mfdd = value; } get { return _mfdd; } }
        private String _brake_fixed;
        //制动稳定性，值：稳定，不稳定--
        public String Brake_Fixed { set { _brake_fixed = value; } get { return _brake_fixed; } }
        private float _brake_time;
        //制动协调时间--
        public float Brake_Time { set { _brake_time = value; } get { return _brake_time; } }
        private int _trav_brake_jus;
        //行车制动判定--
        public int Trav_Brake_jus { set { _trav_brake_jus = value; } get { return _trav_brake_jus; } }
        private float _park_grade;
        //驻车坡度--
        public float Park_Grade { set { _park_grade = value; } get { return _park_grade; } }
        private String _parking5;
        //不少于5min坡道驻车情况，值：不溜坡，溜坡--
        public String Parking5 { set { _parking5 = value; } get { return _parking5; } }
        private int _park_brake_jus;
        //驻车制动判定--
        public int Park_Brake_jus { set { _park_brake_jus = value; } get { return _park_brake_jus; } }
        private int _mfdd_jus;
        //mfdd判定--
        public int Mfdd_Jus { set { _mfdd_jus = value; } get { return _mfdd_jus; } }
        private int _brake_fixed_jus;
        //制动稳定型判定--
        public int Brake_Fixed_jus { set { _brake_fixed_jus = value; } get { return _brake_fixed_jus; } }
    }






    /// <summary>
    /// 检验项结果
    /// </summary>
    [Serializable]
    public class Detect_item
    {
        private int _id;
        //检验项目编号--
        public int Id { set { _id = value; } get { return _id; } }
        private int _necessary;
        //检验项目判定--
        public int Necessary { set { _necessary = value; } get { return _necessary; } }
    }
}
