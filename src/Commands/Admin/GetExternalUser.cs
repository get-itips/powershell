﻿using Microsoft.Online.SharePoint.TenantManagement;
using Microsoft.SharePoint.Client;

using PnP.PowerShell.Commands.Base;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "ExternalUser")]
    public class GetExternalUser : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false)]
        public int Position;

        [Parameter(Mandatory = false)]
        public int PageSize = 1;

        [Parameter(Mandatory = false)]
        public string Filter;

        [Parameter(Mandatory = false)]
        public SortOrder SortOrder = SortOrder.Ascending;

        [Parameter(Mandatory = false)]
        public string SiteUrl;

        [Parameter(Mandatory = false)]
        public bool ShowOnlyUsersWithAcceptingAccountNotMatchInvitedAccount;

        protected override void ExecuteCmdlet()
        {
            var office365Tenant = new Office365Tenant(ClientContext);
            ClientContext.Load(office365Tenant);
            ClientContext.ExecuteQueryRetry();
            GetExternalUsers(office365Tenant);
        }

        private void GetExternalUsers(Office365Tenant tenant)
        {
            GetExternalUsersResults results = null;
            if (!string.IsNullOrEmpty(SiteUrl))
            {
                results = tenant.GetExternalUsersForSite(SiteUrl, Position, PageSize, Filter, SortOrder);
            }
            else
            {
                results = tenant.GetExternalUsers(Position, PageSize, Filter, SortOrder);
            }
            ClientContext.Load(results, r => r.TotalUserCount, r => r.UserCollectionPosition, r => r.ExternalUserCollection.Include(u => u.DisplayName, u => u.InvitedAs, u => u.UniqueId, u => u.AcceptedAs, u => u.WhenCreated, u => u.InvitedBy));
            ClientContext.ExecuteQueryRetry();
            foreach(var externalUser in results.ExternalUserCollection)
            {
                if(!ShowOnlyUsersWithAcceptingAccountNotMatchInvitedAccount)
                {
                    WriteObject(externalUser);
                } else if(!string.Equals(externalUser.InvitedAs, externalUser.AcceptedAs, System.StringComparison.OrdinalIgnoreCase)) {
                    WriteObject(externalUser);
                }
            }
        }
    }
}