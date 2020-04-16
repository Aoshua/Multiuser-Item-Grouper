var allGroups;
var selectedGroup;
var groupItems;
var username;

function receiveGroups(jString) {
    allGroups = JSON.parse(jString);
}

function selectGroup() {
    selectedGroup = $("#cboGroup").val()
    console.log("Selected group: " + selectedGroup);
}

function receiveGroupItems() {

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

// Functions that are called on page load:
$(function () {
    setUser();
    bindGroupsCbo();
});