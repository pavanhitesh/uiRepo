using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data;

namespace UserDefinedReport
{
    public class UserDefinedReportHtml : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ReportPath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> DataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> Heading { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var path = ReportPath.Get(context);
            var dataTable = DataTable.Get(context);
            var heading = Heading.Get(context);
            GenerateHTMLReport report = new GenerateHTMLReport(path,dataTable,heading);
            report.createHTMLReport();

        }
    }
}
