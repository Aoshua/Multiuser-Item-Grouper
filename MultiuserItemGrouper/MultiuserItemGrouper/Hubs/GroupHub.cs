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

        public async Task SetUsername(string name)
        {
            Context.Items.Add("username", name);
        }

        public async Task GetGroupNames()
        {
            await Clients.Caller.SendAsync("ReturnGroupNames", GroupManager.GetGroupNames());
        }

        public async Task CreateGroup(string name)
        {
            switch (GroupManager.CreateGroup(name)) {
                case GroupManager.CreateGroupResult.SUCCESS:
                    await Clients.Caller.SendAsync("GroupCreated", name);
                    break;
                case GroupManager.CreateGroupResult.FAIL:
                default:
                    await SendErrorMsg(Clients.Caller, "Group " + name + " not created.");
                    break;
            }
        }
        
        public async Task GetItemsInGroup(string groupName)
        {
            string data = GroupManager.SerializeGroupForUser(groupName, Context.Items["username"].ToString());
            await Clients.Caller.SendAsync("ReturnItemsInGroup", data);
        }

        //todo : ishidden attr
        public async Task AddItem(string groupName, string itemName, string itemBody, bool IsHidden)
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

        public async Task UpdateItem(string groupName, int itemId, string itemName, string itemBody, bool isHidden)
        {
            GroupManager.UpdateItem(Context.Items["username"].ToString(),
                groupName, itemId, itemName, itemBody, isHidden);

            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        public async Task DeleteItem(string groupName, int itemId)
        {
            GroupManager.DeleteItem(Context.Items["username"].ToString(), groupName, itemId);
            await Clients.All.SendAsync("InEditedGroup", groupName);
        }

        // todo: not sure this works, must find a way to pass in the client that
        // performed the illegal operation?
        // todo: make this unavailable for clients to call, only other Hub methods
        private async Task SendErrorMsg(IClientProxy caller, string msg)
        {
            await caller.SendAsync("ErrorMsg", msg);
        }
    }
}
