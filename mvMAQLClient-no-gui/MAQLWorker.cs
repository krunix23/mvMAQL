using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace mv.MAQL
{
    public class MAQLWorker
    {
        private ConfigHandling cfg_ = new ConfigHandling();
        private mvSQLDataHandlingBase sqldata_;
        private Logger logger_;

        public MAQLWorker( TextWriterTraceListener logger)
        {
            logger_ = logger as Logger;
            cfg_ = new ConfigHandling();
            sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());
        }

        public void DummyFunction()
        {
            sqldata_.FindData("160301893DE", "Serialnumber");
        }
    }
}
