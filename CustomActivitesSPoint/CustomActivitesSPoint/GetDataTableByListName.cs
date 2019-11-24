using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data;
using Microsoft.SharePoint.Client;
using System.Security;
namespace CustomActivitesSPoint
{
    public class GetDataTableByListName : CodeActivity
    {


        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> SharePointSiteUri { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> UserName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> Password { get; set; }

        [Category("Input")]
        public InArgument<String> ListName { get; set; }

        [Category("Input")]
        public InArgument<String> CamlQueryXml { get; set; }

        [Category("Output")]
        public OutArgument<DataTable> ResultListItems { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var userName = UserName.Get(context);
            var password = Password.Get(context);
            var listName = ListName.Get(context);
            var camlQueryXml = CamlQueryXml.Get(context);
            var securePassword = new SecureString();

            foreach (char c in Password.Get(context))
            {
                securePassword.AppendChar(c);
            }

            using (var clientContext = new ClientContext(SharePointSiteUri.Get(context)))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                var listItemOperations = new ListItemOperations(clientContext, listName,camlQueryXml);
                ResultListItems.Set(context, DataTableUitility.GetDataTableFromListItem(listItemOperations.GetListItems()));
            }
                

        }
    }
}
