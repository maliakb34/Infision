
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
                List<Configure.HubUser> hubUsers = new List<Configure.HubUser>();
                 
                hubUsers = Configure.RootSetting.Roots.AppSettings.HubUsers;
                if (hubUsers != null)
                    {
                        List<Configure.HubUser> search_hubUsers = hubUsers.Where(P => P.ConnectionID == id).ToList();
                        if (search_hubUsers != null)
                        {
                            if (search_hubUsers.Count() > 0)
                            {
                                foreach (var item2 in search_hubUsers)
                                {
                                    if (hubUsers.Where(P => P == item2).Count() > 0)
                                    {
                                        hubUsers.Remove(item2);
                                    }
                                }
                            Configure.RootSetting.Roots.AppSettings.HubUsers= hubUsers;
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                 
            }

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
        public async Task<string> Connect(int userid,int companyid)
        {
            string id = "";
            try
            {
                id = Context.ConnectionId;
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
                    UpdateHubUser(new Configure.HubUser() { UserID=userid,CompanyID =companyid,ConnectionID=id});
                     
                }

            }
            catch (Exception ex)
            {
               // Factory.SystemErrorLog.InsertRow(ex, "Connect", "", 0, "", 0);

            }
            return id;
        }

        

        public async void SendData(int companyID,string messagingData)
        {


                string fromUserId = Context.ConnectionId;
                 
                List<Configure.HubUser> users = Configure.RootSetting.Roots.AppSettings.HubUsers;

                users = users.Where(P => P.CompanyID == companyID).ToList();
                    if (users != null)
                        foreach (var item in users)
                        {
                            Clients.Client(item.ConnectionID).SendAsync("ReceiveMessage",  messagingData);
                        }
                 
                 
             
        }

       
 






        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {

        }

        #endregion
    }
}
