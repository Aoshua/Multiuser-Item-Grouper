// Global variables:
var allGroups;
var selectedGroup;
var groupItems;
var username;
var isEditing;



/*======================
 * Functions to Draw UI:
 *=====================*/

// Page load function:
$(function () {
    setLocalUser();
});


// Binds our list of group names to the group combo box:
function bindGroupsCbo() {

    $('#cboGroup').empty();

    for (group of allGroups) {
        $('#cboGroup').append($('<option></option>').attr("value", group).text(group));
    }

    // For intial load:
    if (allGroups.names.length > 0) {
        selectedGroup = allGroups.names[0];
        requestItems(selectedGroup);
    }
}

// Dynamically draws our items
function drawItems() {
    console.log("UI: Drawing Items!!")
    var cont = $('#itemsContainer');
    cont.empty(); // Clear out old items
    console.log("GroupItems length: " + groupItems.Items.length);
    if (groupItems.items.length > 0) {
        for (var i = 0; i < groupItems.Items.length; i++) {
            if (i % 2 == 0) { // Add a new row if we have an even number (0 based)
                cont.append("<div class='row'></div>");
                cont = $('#itemsContainer > div');
            }
            // Append Card:
            cont.append(`
                        <div class='col-sm-6'>
                            <div class= 'card mar-btm-10' >
                                <div class='card-body'>
                                    <div class='btn-container' title='Delete Item' style='float: right;' onclick='deleteItem("${groupItems.Items[i].Id}")'>
                                        <div class='btn-delete'>
                                            <i class='fa fa-times'></i>
                                        </div>
                                    </div>
                                    <div id="btnHidden_${groupItems.Items[i].Id}" data-toggle="modal" data-target="#editItemModal_${groupItems.Items[i].Id}"></div>
                                    <div class='btn-container' title='Edit Item' style='float: right;' onclick="showEditItem(${groupItems.Items[i].Id}, '${groupItems.Items[i].Name}', '${groupItems.Items[i].Body}', ${groupItems.Items[i].IsHidden})" >
                                        <div class='btn-edit'>
                                            <i class='fa fa-pencil'></i>
                                        </div>
                                    </div>
                                    <h5 class='card-title'>${groupItems.Items[i].Name}</h5>
                                    <p class='card-text'>${groupItems.Items[i].Body}</p>
                                </div>
                            </div>
                        </div>
            `);
        }
    }
}



/*========================
 * CRUD Functions for  UI:
 *=======================*/

function addGroup() {
    var newGroupName = $('#txtNewGroupName').val();
    CreateGroup(newGroupName);
}
function addItem() {
    var newItemName = $('#txtItemName').val();
    var newItemBody = $('#txtItemBody').val();
    var newItemHidden = $('#chkItemHidden').prop('checked');
    AddItem(selectedGroup, newItemName, newItemBody, newItemHidden);
}
function showEditItem(itemId, itemName, itemBody, itemHidden) {
    LockItem(selectedGroup, itemId); // Lock Item for edit

    // Append Edit Modal:
    var isHidden = "";
    if (itemHidden)
        isHidden = 'checked=""';
    $('body').append(`
        <div class="modal fade" id="editItemModal_${itemId}" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="itemModalTitle">Edit Item</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtNewGroupName">Item Name:</label>
                            <input type="text" class="form-control" id="txtItemName_${itemId}" value="${itemName}">
                        </div>
                        <div class="form-group">
                            <label for="txtItemBody">Item Content:</label>
                            <textarea class="form-control" id="txtItemBody_${itemId}" rows="3">${itemBody}</textarea>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" value="" id="chkItemHidden_${itemId}" ${isHidden}>
                            <label class="form-check-label" for="chkItemHidden">
                                Hidden
                            </label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal" onclick="editItem(${itemId})">Save</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    `);
    $('#btnHidden_' + itemId).click(); // Sneakily call my hidden button ;)
}
function editItem(itemId) {
    var newItemName = $('#txtItemName_' + itemId).val();
    var newItemBody = $('#txtItemBody_' + itemId).val();
    var newItemHidden = $('#chkItemHidden_' + itemId).prop('checked');

    // todo? Remove the modal from body (currently seems like there is no need)

    UpdateItem(selectedGroup, itemId, newItemName, newItemBody, newItemHidden);
    UnlockItem(selectedGroup, itemId);
}
function deleteItem(itemId) {
    if (confirm("Are you sure you want to delete this item?")) {
        DeleteItem(selectedGroup, itemId);
    }
}



/*===============================================
 * Functions to Receive and Request from comm.js:
 *==============================================*/

// Sets our selected group:
function selectGroup() {
    selectedGroup = $("#cboGroup").val();
    GetItemsInGroup(selectedGroup);
}
// Sends user to comm.js
function setLocalUser() {
    username = $('#hidUser').val();
}
// Receives groups:
function receiveGroups(jGroups) {
    allGroups = JSON.parse(jGroups);
    console.log("allGroups: " + allGroups);
    bindGroupsCbo();
}
// Receives items:
function receiveItems(jGroupItems) {
    groupItems = JSON.parse(jGroupItems)
    console.log(groupItems);
    drawItems();
}
// Request groups:
function requestGroups() {
    allGroups = GetGroupNames(); 
    bindGroupsCbo();
    //allGroups = {
    //    "names": [
    //        "group1",
    //        "group2",
    //        "group3"
    //    ]
    //};
}
// Request items:
function requestItems(selectedGroup) {
    groupItems = GetItemsInGroup(selectedGroup);
    //groupItems = {
    //    "name": "picnicGroup",
    //    "items": [
    //        {
    //            "id": 2,
    //            "name": "basket",
    //            "body": "A nice, woven basket.",
    //            "isLocked": false,
    //            "isHidden": true
    //        },
    //        {
    //            "id": 3,
    //            "name": "ugly basket",
    //            "body": "A cheap basket we got on Craigslist.",
    //            "isLocked": false,
    //            "isHidden": true
    //        },
    //        {
    //            "id": 5,
    //            "name": "grapes",
    //            "body": "Delicious, imported red grapes.",
    //            "isLocked": true,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 15,
    //            "name": "bleu cheese",
    //            "body": "Josh's favorite Floridian bleu cheese.",
    //            "isLocked": false,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 7000,
    //            "name": "candy",
    //            "body": "Tanner's favorite Reese's Pieces.",
    //            "isLocked": true,
    //            "isHidden": true
    //        },
    //        {
    //            "id": 2,
    //            "name": "basket 2",
    //            "body": "A nice, woven basket.",
    //            "isLocked": false,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 3,
    //            "name": "ugly basket 2",
    //            "body": "A cheap basket we got on Craigslist.",
    //            "isLocked": false,
    //            "isHidden": true
    //        },
    //        {
    //            "id": 5,
    //            "name": "grapes 2",
    //            "body": "Delicious, imported red grapes.",
    //            "isLocked": true,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 15,
    //            "name": "bleu cheese 2",
    //            "body": "Josh's favorite Floridian bleu cheese.",
    //            "isLocked": false,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 7000,
    //            "name": "candy 2",
    //            "body": "Tanner's favorite Reese's Pieces.",
    //            "isLocked": true,
    //            "isHidden": true
    //        },
    //        {
    //            "id": 15,
    //            "name": "bleu cheese 3",
    //            "body": "Josh's favorite Floridian bleu cheese.",
    //            "isLocked": false,
    //            "isHidden": false
    //        },
    //        {
    //            "id": 7000,
    //            "name": "candy 3",
    //            "body": "Tanner's favorite Reese's Pieces.",
    //            "isLocked": true,
    //            "isHidden": true
    //        }
    //    ]
    //};
}