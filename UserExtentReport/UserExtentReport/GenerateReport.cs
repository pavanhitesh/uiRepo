using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace UserExtentReport
{
    class GenerateReport
    {
        public string reportFolder { get; set; }
        private ExtentReports extent { get; set; }

        private ExtentTest test { get; set; }
       

        public void invokeTestReport()
        {
            this.reportFolder = reportFolder;
            var reporter = new ExtentHtmlReporter(this.reportFolder);
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }
        public void createTest(string testName)
        {
            test = extent.CreateTest(testName);
            test.Log(Status.Info, "Started Execution");
        }

        public void insertStatus(string value)
        {
            test.Log(Status.Info, value);
        }

        public void updateStatus(string status,string value)
        {
            switch (status)
            {
                case "pass":
                    test.Pass(value);
                    extent.Flush();
                    break;
                case "fail":
                    test.Fail(value);
                    extent.Flush();
                    break;
            }
           
        }


    }

}
