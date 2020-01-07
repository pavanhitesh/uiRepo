using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace UserDefinedReport
{
    public class GenerateHTMLReport
    {
        private string path { get; set; }
        private DataTable dataTable { get; set; }

        private string heading { get; set; }

        public GenerateHTMLReport(string path, DataTable dataTable,string heading)
        {
            this.path = path;
            this.dataTable = dataTable;
            this.heading = heading;
        }

        public void createHTMLReport()
        {
           
            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<body>");
            builder.Append("<div style = 'font-weight:bolder;word-wrap:break-word;text-align:left;'>");
            builder.Append(heading);
            builder.Append("</div>");
            builder.Append("</br>");
            builder.Append("</br>");
            try
            {
                if (dataTable != null)
                {
                    builder.Append("<table style='table-layout:auto; width:100%;'>");
                    builder.Append("<tr style='background: #2196f3;font-weight:bolder;'>");
                    foreach (DataColumn column in this.dataTable.Columns)
                    {
                        builder.Append("<th style='word-wrap:break-word;text-align:center;'>" + column.ColumnName.ToString() + "</th>");
                    }
                    builder.Append("</tr>");

                    foreach (DataRow row in this.dataTable.Rows)
                    {
                        builder.Append("<tr style='font-weight:bolder;'>");
                        foreach (DataColumn dc in this.dataTable.Columns)
                        {
                            var value = row[dc].ToString();
                            builder.Append("<td style='word-wrap:break-word;text-align:center;'>" + value + "</td>");
                        }
                        builder.Append("</tr>");
                    }

                    builder.Append("<tr style='background: #ffbc00;font-weight:bolder;'>");
                    builder.Append("<td style='word-wrap:break-word;text-align:center;'>Total</td>");
                    builder.Append("<td colspan='2'; style='word-wrap:break-word;text-align:center;'>" + dataTable.Rows.Count + "</td>");
                    builder.Append("</tr></table>");
                    

                }
                else
                {
                    builder.Append("<h1> No Records Found </h1>");
                }


            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                builder.Append("<div style='font-weight:bolder;word-wrap:break-word;text-align:right;'>Report Created:");
                builder.Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff"));
                builder.Append("</div>");
                builder.Append("</body>");
                builder.Append("</html>");
                File.WriteAllText(path, builder.ToString());
            }
        }

    }
}
