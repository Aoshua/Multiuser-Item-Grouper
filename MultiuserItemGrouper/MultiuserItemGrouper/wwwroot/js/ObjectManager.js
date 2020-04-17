// Global variables:
var allGroups;
var selectedGroup;
var groupItems;
var username;

// Functions that are called on page load:
$(function () {
    setUser();
    bindGroupsCbo();
    receiveItems(); // Only calling here for testing
    drawItems();
});

// These two functions might just be in comm.js
function receiveGroups(jString) {
    allGroups = JSON.parse(jString);
}
function receiveItems() {
    groupItems = {
        "Name": "group1",
        "Items": [
            {
                "Name": "item1",
                "Body": "Let's pretend that this card really has a lot of text. It was really rainy this morning. I got a lot done today. Work was fun. This thing seems to work so that is nice.",
                "IsLocked": true,
                "IsHidden": false
            },
            {
                "Name": "item2",
                "Body": "more text, this time about item2",
                "IsLocked": false,
                "IsHidden": true
            },
            {
                "Name": "Item 3",
                "Body": "If this goes to next next row, I will be so happy",
                "IsLocked": false,
                "IsHidden": true
            }
        ]
    }; // Hardcoding items for now
}

function editItem(itemName) {
    console.log("Edit item: " + itemName);
}

function deleteItem(itemName) {
    if (confirm(`Are you sure you want to delete "${itemName}"?`)) {
        console.log("Delete item: " + itemName);
    }
}

function addGroup() {
    console.log("Add group");
}

// Sets our selected group
function selectGroup() {
    selectedGroup = $("#cboGroup").val()
}

// Retrieves the username from ViewBag:
function setUser() {
    username = $('#hidUser').val();
}

// Binds our list of group names to the group combo box:
function bindGroupsCbo() {
    allGroups = ["Fake Group A", "Fake Group B", "Fake Group C"]; // Hardcoding groups for now
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