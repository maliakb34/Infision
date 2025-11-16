using Infision.HubConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infision
{
     
    public class MyHub : Hub
    {
         
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                String id = Context.ConnectionId;
                List<Configure.HubUser> hubUsers = Configure.RootSetting.Roots.AppSettings.HubUsers ?? new List<Configure.HubUser>();

                var search_hubUsers = hubUsers.Where(P => P.ConnectionID == id).ToList();
                foreach (var hubUser in search_hubUsers)
                {
                    if (!string.IsNullOrWhiteSpace(hubUser.SignalRKey))
                    {
                        await Groups.RemoveFromGroupAsync(id, hubUser.SignalRKey);
                    }
                    hubUsers.Remove(hubUser);
                }

                Configure.RootSetting.Roots.AppSettings.HubUsers = hubUsers;
            }
            catch (Exception ex)
            {
                 
            }

            await base.OnDisconnectedAsync(exception);
        }


        public override async Task OnConnectedAsync()
        {
            try
            {
                await Clients.Client(Context.ConnectionId).SendAsync("UpdateConnectionID","0");
            }
            catch (Exception ex)
            {
                //Factory.SystemErrorLog.InsertRow(ex, "Connect", "", 0, "", 0);
            }

        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", "sfs", message);
        }

         
        public void UpdateHubUser(Configure.HubUser newhubuser)
        {
            List<Configure.HubUser> hubUsers = new List<Configure.HubUser>();
             
             
            hubUsers = Configure.RootSetting.Roots.AppSettings.HubUsers;
            if (hubUsers == null)
            {
                hubUsers = new List<Configure.HubUser>();
                hubUsers.Add(newhubuser);
            }
            else
            {
                if (hubUsers.Where(P => P.UserID == newhubuser.UserID).Count() > 0)
                    hubUsers.Remove(hubUsers.Where(P => P.UserID == newhubuser.UserID).FirstOrDefault());

                hubUsers.Add(newhubuser);
            }
            Configure.RootSetting.Roots.AppSettings.HubUsers=hubUsers;

        }





        #region Data Members
        #endregion
        #region Methods
        public async Task<string> Connect(int userid,int companyid,string signalrKey)
        {
            string id = "";
            try
            {
                id = Context.ConnectionId;
                string normalizedKey = NormalizeSignalRKey(signalrKey);
                await Groups.AddToGroupAsync(id, normalizedKey);
                {
                     
                    List<Configure.HubUser> hubUsers = Configure.RootSetting.Roots.AppSettings.HubUsers;
                    if (hubUsers != null)
                    {
                        List<Configure.HubUser> search_hubUsers = hubUsers.Where(P => P.UserID == userid).ToList();
                        if (search_hubUsers != null)
                        {
                            if (search_hubUsers.Count() > 0)
                            {
                                foreach (var item2 in search_hubUsers)
                                {
                                    if (hubUsers.Where(P => P == item2).Count() > 0)
                                    {
                                        await Clients.Client(item2.ConnectionID).SendAsync("LogOutConnection", "0");
                                        hubUsers.Remove(item2);
                                    }
                                }
                                Configure.RootSetting.Roots.AppSettings.HubUsers= hubUsers;
                            }
                        }
                    }
                    UpdateHubUser(new Configure.HubUser() { UserID=userid,CompanyID =companyid,ConnectionID=id,SignalRKey=normalizedKey});
                     
                }

            }
            catch (Exception ex)
            {
               // Factory.SystemErrorLog.InsertRow(ex, "Connect", "", 0, "", 0);

            }
            return id;
        }

        

        public async Task SendData(string signalrKey,string messagingData)
        {
            string normalizedKey = NormalizeSignalRKey(signalrKey);
            await Clients.Group(normalizedKey).SendAsync("ReceiveMessage",  messagingData);
        }

       
 






        #endregion

        #region private Messages

        private static string NormalizeSignalRKey(string signalrKey)
        {
            return string.IsNullOrWhiteSpace(signalrKey)
                ? SignalRDefaults.UdpRealtimeKey
                : signalrKey.Trim();
        }

        private void AddMessageinCache(string userName, string message)
        {

        }

        #endregion
    }
}
