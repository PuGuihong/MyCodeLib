using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlHandler
{
    [Serializable]
    /// <summary>
    /// 性能检查结果
    /// </summary>
    public class Performance
    {
        public List<PerformanceItem> PerformanceItem;
    }

    [Serializable]
    public class PerformanceItem
    {
        private int _id;

        /// <summary>
        /// 序号
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }


        private string _itemname;

        /// <summary>
        /// 检验项目
        /// </summary>
        public string Itemname
        {
            get
            {
                return _itemname;
            }

            set
            {
                _itemname = value;
            }
        }


        private string _data;
        /// <summary>
        /// 数据
        /// </summary>
        public string Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }


        private string _limit;
        /// <summary>
        /// 标准限值
        /// </summary>
        public string Limit
        {
            get
            {
                return _limit;
            }

            set
            {
                _limit = value;
            }
        }


        private string _judgement;
        /// <summary>
        /// 判定
        /// </summary>
        public string Judgement
        {
            get
            {
                return _judgement;
            }

            set
            {
                _judgement = value;
            }
        }
    }
}
