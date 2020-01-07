using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data;

namespace CSVDataTableHelper
{
    public class CSVDataHelper : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> CSVPath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<Boolean> IsHeader { get; set; }

        [Category("Input")]
        public InArgument<List<string>> HeaderList { get; set; }


        [Category("Input")]
        [RequiredArgument]
        public InArgument<char> Delimeter { get; set; }

        [Category("Output")]
        public OutArgument<DataTable> ResultListItems { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var csvPath = CSVPath.Get(context);
            var isHeader = IsHeader.Get(context);
            char delimeter = Delimeter.Get(context);
            List<string> headerList = HeaderList.Get(context);
            CSVToDataTableConverter converter = new CSVToDataTableConverter(csvPath,isHeader, headerList,delimeter);
            ResultListItems.Set(context, converter.getDataTableCSVFile());
        }
    }
}
