using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlHandler
{
    [Serializable]
    public class ExamScoreRlt
    {
        public string SubName { get; set; }
        public int SubScore { get; set; }
        public string SubRlt { get; set; }
    }

    [Serializable]
    public class BasicInfo
    {
        public string Name { get; set; }

        public int Age { get; set; }

    }

    public class exScore
    {
        public List<ExamScoreRlt> Score;
    }

    [Serializable]
    public class StudentInfo
    {
        public BasicInfo BasicInfo;
        public exScore Score;
    }
}
