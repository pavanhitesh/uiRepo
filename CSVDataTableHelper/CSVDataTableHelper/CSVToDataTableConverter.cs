using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace CSVDataTableHelper
{
    class CSVToDataTableConverter
    {
        string csvPath;
        Boolean isHeader;

        public CSVToDataTableConverter(string csvPath,Boolean isHeader)
        {
            this.csvPath = csvPath;
            this.isHeader = isHeader;
        }

        public DataTable getDataTableCSVFile()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using(StreamReader sr = new StreamReader(this.csvPath))
                {
                    if (this.isHeader)
                    {
                        string[] headers = sr.ReadLine().Split(',');
                        for(int i = 0; i < headers.Count(); i++)
                        {
                            dataTable.Columns.Add(headers[i]);
                        }
                    }
                    else
                    {
                        string[] headers = sr.ReadLine().Split(',');
                        for (int i = 0; i < headers.Count(); i++)
                        {
                            dataTable.Columns.Add();
                        }
                    }

                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dataTable.NewRow();
                        for(int j = 0; j < rows.Count(); j++)
                        {
                            dr[j] = rows[j];
                        }
                        dataTable.Rows.Add(dr);
                    }
                }


            }catch(Exception ex)
            {
                throw (ex);
            }

            return dataTable;
        }
    }
}
