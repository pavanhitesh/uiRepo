using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExtentReport
{
    class  DriverFactory
    {
        private static GenerateReport report = null;
        
        
        public static GenerateReport getGenerateReport()
        {
            if (report == null)
            {
                report = new GenerateReport();
            }
            return report;
        }

    }
}
