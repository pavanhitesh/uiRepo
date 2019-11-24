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
            if (!string.IsNullOrWhiteSpace(listName))
                this.list = clientContext.Web.Lists.GetByTitle(listName);
        }

        public ListItemCollection GetListItems()
        {
            Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
            if (!string.IsNullOrWhiteSpace(this.camlQueryXml)){
                camlQuery.ViewXml = this.camlQueryXml;
            }
            ListItemCollection collListItem = list.GetItems(camlQuery);
            clientContext.Load(collListItem);
            clientContext.ExecuteQuery();
            return collListItem;
        }

    }
}
