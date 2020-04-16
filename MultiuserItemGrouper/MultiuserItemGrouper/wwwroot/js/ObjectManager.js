var groups;
var group;
var groupItems;

function receiveGroups(jString) {
    groups = JSON.parse(jString);
}

function selectGroup() {

}

function receiveGroupItems() {

}

$(function () {
    var hardGroups = {
        "Name": "groups",
        "Items": [
            {
                "Name": "group1",
                "Items": [
                    {
                        "Name": "item1",
                        "Body": "some text about item1",
                        "IsLocked": true,
                        "IsHidden": false
                    },
                    {
                        "Name": "item2",
                        "Body": "more text, this time about item2",
                        "IsLocked": false,
                        "IsHidden": true
                    }
                ]
            },
            {
                "Name": "group2",
                "Items": [
                    {
                        "Name": "item1",
                        "Body": "some text about item1",
                        "IsLocked": true,
                        "IsHidden": false
                    },
                    {
                        "Name": "item2",
                        "Body": "more text, this time about item2",
                        "IsLocked": false,
                        "IsHidden": true
                    }
                ]
            }
        ]
    };
    var singleGroupString = JSON.stringify(singleGroup);
    console.log(singleGroup);
    console.log(singleGroupString);
    receiveGroups(singleGroupString);

    for (var i = 0; i <= groups.length; i++) {
        $('#cboGroup').append('<option value=' + groups[i] + '">' + groups[i] + '</option>');
    }
});