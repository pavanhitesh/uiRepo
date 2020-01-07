using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomActivitesSPoint
{
   
    class ListItemOperations
    {
        ClientContext clientContext;
        List list;
        string camlQueryXml;
        public ListItemOperations(ClientContext clientContext, string listName,string camlQueryXml)
        {
            this.clientContext = clientContext;
            this.camlQueryXml = camlQueryXml;
            Console.WriteLine(this.camlQueryXml);
            if (!string.IsNullOrWhiteSpace(listName))
            {
                this.list = clientContext.Web.Lists.GetByTitle(listName);
            }
        }

        public ListItemCollection GetListItems()
        {
            CamlQuery camlQuery = new CamlQuery();
            if (!string.IsNullOrWhiteSpace(this.camlQueryXml)){
                camlQuery.ViewXml = this.camlQueryXml;
                Console.WriteLine("Added camlQueryXml");
            }
            ListItemCollection collListItem = list.GetItems(camlQuery);
            clientContext.Load(collListItem);
            clientContext.ExecuteQuery();
            return collListItem;
        }

        public Boolean updateListItemColumn(string column,string value)
        {
            Boolean isUpdated = false;
            try
            {
                CamlQuery camlQuery = new CamlQuery();
                if (!string.IsNullOrWhiteSpace(this.camlQueryXml))
                {
                    camlQuery.ViewXml = this.camlQueryXml;
                    Console.WriteLine("Added camlQueryXml");
                }
                ListItemCollection collListItem = list.GetItems(camlQuery);
                clientContext.Load(collListItem);
                clientContext.ExecuteQuery();

                foreach (ListItem item in collListItem)
                {
                    item[column] = value;
                    item.Update();
                }
       
                clientContext.ExecuteQuery();
                isUpdated = true;
                Console.WriteLine("Updated");
            }
            catch(Exception e)
            {
                isUpdated = false;
                throw (e);
            }
            return isUpdated;
        }

    }
}
