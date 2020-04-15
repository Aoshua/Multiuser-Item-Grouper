var groups;
var group;
var groupItems;

function receiveGroups(jString) {
    //groups = JSON.parse(jString);
    groups = ["Group A", "Group B"];
}

function selectGroup() {

}

function receiveGroupItems() {

}

$(function () {
    for (var i = 0; i <= groups.length; i++) {
        $('#cboGroup').append('<option value=' + groups[i] + '">' + groups[i] + '</option>');
    }
});