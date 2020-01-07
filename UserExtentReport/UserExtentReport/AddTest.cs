using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;

namespace UserExtentReport
{
    public class AddTest :CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> testName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var testname = testName.Get(context);
            GenerateReport report = DriverFactory.getGenerateReport();
            report.createTest(testname);
        }
    }
}
