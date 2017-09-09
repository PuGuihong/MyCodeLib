using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class TestJob : IJob
    {
        private readonly Common.Logging.ILog _logger = LogManager.GetLogger(typeof(TestJob));
        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("TestJob 测试");
        }
    }
}
