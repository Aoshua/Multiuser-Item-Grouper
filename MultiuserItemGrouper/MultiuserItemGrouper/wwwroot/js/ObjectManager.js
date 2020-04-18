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
    setUser();
    requestGroups();
});
// Binds our list of group names to the group combo box:
function bindGroupsCbo() {     
    for (var i = 0; i < allGroups.length; i++) {
        $('#cboGroup').append($('<option></option>').attr("value", allGroups[i]).text(allGroups[i]));
    }
}
// Dynamically draws our items
function drawItems() {
    var cont = $('#itemsContainer');
    if (groupItems.Items.length > 0) {
        for (var i = 0; i < groupItems.Items.length; i++) {
            if (i % 2 == 0) { // Add a new row if we have an even number (0 based)
                cont.append("<div class='row'></div>");
                cont = $('#itemsContainer > div');
            }
            cont.append(`<div class='col-sm-6'>
                            <div class= 'card mar-btm-10' >
                                <div class='card-body'>
                                    <div class='btn-container' title='Delete Item' style='float: right;' onclick='deleteItem("${groupItems.Items[i].Name}")'>
                                        <div class='btn-delete'>
                                            <i class='fa fa-times'></i>
                                        </div>
                                    </div>
                                    <div class='btn-container' title='Edit Item' style='float: right;' onclick='editItem("${groupItems.Items[i].Name}")'>
                                        <div class='btn-edit'>
                                            <i class='fa fa-pencil'></i>
                                        </div>
                                    </div>
                                    <h5 class='card-title'>${groupItems.Items[i].Name}</h5>
                                    <p class='card-text'>${groupItems.Items[i].Body}</p>
                                </div>
                            </div>
                        </div>`);
        }
    }
}



/*========================
 * CRUD Functions for  UI:
 *=======================*/

function showAddGroup() {

}
function addGroup() {
    
}
function showAddItem() {

}
function addItem() {

}
function showEditItem(itemName) {

}
function editItem(itemName) {
    
}
function deleteItem(itemName) {
    if (confirm(`Are you sure you want to delete "${itemName}"?`)) {
        console.log("Delete item: " + itemName);
    }
}



/*===============================================
 * Functions to Receive and Request from comm.js:
 *==============================================*/

// Sets our selected group:
function selectGroup() {
    selectedGroup = $("#cboGroup").val()
    requestItems(selectedGroup);
    //send selected group to comm.js?
}
// Sends user to comm.js
function setUser() {
    username = $('#hidUser').val();
    SetUsername(username);
}
// Receives groups:
function receiveGroups(jGroups) {
    allGroups = JSON.parse(jGroups);
    bindGroupsCbo();
}
// Receives items:
function receiveItems(jGroupItems) {
    groupItems = jGroupItems
    drawItems();
}
// Request groups:
function requestGroups() {
    //allGroups = GetGroupNames(); 
    allGroups = {
        "names": [
            "group1",
            "group2",
            "group3"
        ]
    };
    bindGroupsCbo();
}
// Request items:
function requestItems(selectedGroup) {
    //groupItems = GetItemsInGroup(selectedGroup)
    groupItems = {
        "name": "picnicGroup",
        "items": [
            {
                "id": 2,
                "name": "basket",
                "body": "A nice, woven basket.",
                "isLocked": false,
                "isHidden": false
            },
            {
                "id": 3,
                "name": "ugly basket",
                "body": "A cheap basket we got on Craigslist.",
                "isLocked": false,
                "isHidden": true
            },
            {
                "id": 5,
                "name": "grapes",
                "body": "Delicious, imported red grapes.",
                "isLocked": true,
                "isHidden": false
            },
            {
                "id": 15,
                "name": "bleu cheese",
                "body": "Josh's favorite Floridian bleu cheese.",
                "isLocked": false,
                "isHidden": false
            },
            {
                "id": 7000,
                "name": "candy",
                "body": "Tanner's favorite Reese's Pieces.",
                "isLocked": true,
                "isHidden": true
            }
        ]
    };
    drawItems();
}