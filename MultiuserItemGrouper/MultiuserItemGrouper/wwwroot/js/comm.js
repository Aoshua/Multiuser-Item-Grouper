"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/grouphub").build();

// Server: ReturnGroupNames
connection.on("ReturnGroupNames", function (groupNames) {
    console.log("Server: ReturnGroupNames, " + groupNames);
    receiveGroups(groupNames);
});

// Server: GroupCreated
connection.on("GroupCreated", function (groupName) {
    console.log("Server: GroupCreated, " + groupName);
    selectedGroup = groupName; // set global, not sure if we need to do anything else?
    GetItemsInGroup(groupName); // call to server to get items list
});

// Server: ReturnItemsInGroup
connection.on("ReturnItemsInGroup", function (data) {
    console.log("Server: ReturnItemsInGroup, " + data);
    receiveItems(data);
});

// Server: InEditedGroup
connection.on("InEditedGroup", function (groupName) {
    console.log("Server: InEditedGroup, " + groupName);
    // todo: check if currently editing an item
    GetItemsInGroup(groupName);
})

// Server: ErrorMsg
connection.on("ErrorMsg", function (msg) {
    console.log("Server: ErrorMsg, " + msg);
    alertError(msg);
});

// Start the connection
connection.start().then(function () {
    console.log("Connection init.");
    SetUsername(username);
}).catch(function (err) {
    return console.error(err.toString());
});

// Client: SetUsername
function SetUsername(username) {
    console.log("Client: SetUsername, " + username);
    connection.invoke("SetUsername", username).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: GetGroupNames
function GetGroupNames() {
    console.log("Client: GetGroupNames");
    connection.invoke("GetGroupNames").catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: GetItemsInGroup
function GetItemsInGroup(groupName) {
    console.log("Client: GetItemsInGroup, " + groupName);
    connection.invoke("GetItemsInGroup", groupName).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: AddItem
function AddItem(groupName, itemName, itemBody, isHidden) {
    console.log("Client: AddItem, " + itemName);
    connection.invoke("AddItem", groupName, itemName, itemBody, isHidden).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: LockItem
function LockItem(groupName, itemId) {
    console.log("Client: LockItem, " + groupName + itemId);
    connection.invoke("LockItem", groupName, itemId).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: UnlockItem
function UnlockItem(groupName, itemId) {
    console.log("Client: UnlockItem, " + groupName + itemId);
    connection.invoke("UnlockItem", groupName, itemId).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: UpdateItem
function UpdateItem(groupName, itemId, itemName, itemBody, isHidden) {
    console.log("Client: UpdateItem, " + groupName + itemName);
    connection.invoke("UpdateItem", groupName, itemId, itemName, itemBody, isHidden).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: DeleteItem
function DeleteItem(groupName, itemId) {
    console.log("Client: DeleteItem, " + groupName + itemId);
    connection.invoke("DeleteItem", groupName, itemId).catch(function (err) {
        return console.error(err.toString());
    });
}

// Client: CreateGroup
function CreateGroup(name) {
    console.log("Client: CreateGroup, " + name);
    connection.invoke("CreateGroup", name).catch(function (err) {
        return console.error(err.toString());
    });
}