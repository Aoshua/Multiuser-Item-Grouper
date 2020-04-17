"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/grouphub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

// Server: ReturnGroupNames

// Server: GroupCreated

// Server: ReturnItemsInGroup

// Server: InEditedGroup

// Server: ErrorMsg

// Client: SetUsername

// Client: GetGroupNames

// Client: GetItemsInGroup

// Client: AddItem

// Client: LockItem

// Client: UnlockItem

// Client: UpdateItem

// Client: DeleteItem

// Client: IsInEditedGroup
