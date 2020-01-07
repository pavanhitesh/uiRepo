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
        List<string> headerList;
        Dictionary<string, int> headerMap;
        char delimeter;
        public CSVToDataTableConverter(string csvPath,Boolean isHeader,List<string> headerList,char delimeter)
        {
            this.csvPath = csvPath;
            this.isHeader = isHeader;
            headerMap = new Dictionary<string, int>();
            this.headerList = headerList;
            this.delimeter = delimeter;
        }

        public DataTable getDataTableCSVFile()
        {
            DataTable dataTable = new DataTable();
            try
            {
                
                using (StreamReader sr = new StreamReader(this.csvPath))
                {
                    if (this.isHeader)
                    {
                        string[] headers = sr.ReadLine().Split(delimeter);
                        for(int i = 0; i < headers.Count(); i++)
                        {
                            headerMap.Add(headers[i], i);
                        }

                        if (headerList != null)
                        {
                            for (int i = 0; i < headerList.Count(); i++)
                            {
                                dataTable.Columns.Add(headerList[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < headers.Count(); i++)
                            {
                                dataTable.Columns.Add(headers[i]);
                            }
                        }
                        

                    }
                    else
                    {
                        string[] headers = sr.ReadLine().Split(delimeter);
                        for (int i = 0; i < headers.Count(); i++)
                        {
                            dataTable.Columns.Add();
                        }
                    }

                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(delimeter);
                        DataRow dr = dataTable.NewRow();
                        if (headerList != null)
                        {
                            for (int j = 0; j < headerList.Count(); j++)
                            {
                                var key = headerList[j];
                                dr[j] = rows[headerMap[key]];
                            }
                        }
                        else
                        {
                            for(int j = 0; j < rows.Count(); j++)
                            {
                                dr[j] = rows[j];
                            }
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
