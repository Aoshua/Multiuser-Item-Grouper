using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MultiuserItemGrouper.Models;

namespace MultiuserItemGrouper.Hubs
{
    public class GroupHub : Hub
    {

        public async Task GetGroupNames()
        {
            await Clients.Caller.SendAsync("ReturnGroupNames", GroupManager.GetGroupNames());
        }

        public async Task GetItemsInGroup(string groupName)
        {
            string msg = "Return Items In Group";
            string data = GroupManager.SerializeGroupForUser(groupName, Context.Items["username"].ToString());

            await Clients.Caller.SendAsync("ReturnItemsInGroup", msg, data);
        }

        public async Task AddItem(string groupName, string itemName, string itemBody)
        {
            GroupManager.AddItem(Context.Items["username"].ToString(), groupName, itemName, itemBody);
            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task LockItem(string groupName, int itemId)
        {
            GroupManager.LockItem(Context.Items["username"].ToString(), groupName, itemId);
            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task UnlockItem(string groupName, int itemId)
        {
            GroupManager.UnlockItem(Context.Items["username"].ToString(), groupName, itemId);
            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task UpdateItem(string groupName, int itemId, string itemName, string itemBody, bool hideItem)
        {
            GroupManager.UpdateItem(Context.Items["username"].ToString(),
                groupName, itemId, itemName, itemBody, hideItem);

            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task DeleteItem(string groupName, int itemId)
        {
            GroupManager.DeleteItem(Context.Items["username"].ToString(), groupName, itemId);
            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task IsInEditedGroup(string groupName)
        {
            await GetItemsInGroup(groupName);
        }

        // todo: not sure this works, must find a way to pass in the client that
        // performed the illegal operation?
        public async Task SendErrorMsg(string msg)
        {
            await Clients.Caller.SendAsync("ErrorMsg", msg);
        }
    }
}
