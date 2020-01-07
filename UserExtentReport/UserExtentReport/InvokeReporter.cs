using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;


namespace UserExtentReport
{
    public class InvokeReporter : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> reportPath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var path = reportPath.Get(context);
            GenerateReport report = DriverFactory.getGenerateReport();
            report.reportFolder = path;
            report.invokeTestReport();
        }


    }
}
