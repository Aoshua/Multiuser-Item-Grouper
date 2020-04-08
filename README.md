# Multiuser-Item-Grouper
By Tanner Law, Logan Rios, and Joshua Abbott

## Program's Purpose:
An adaptable template that can serve many purposes for organization information. This website should:
1. Allow any user to create a new group
2. Allow any user to create an item object within that group
3. Allows one user at a time to modify an item object with additional text.

## Examples:
* Example 1: A group of students want to collaberate on a software project.   Within a group project, tasks are organized.  Within a task, simple text is given to give its documentation.   New tasks can be created easily as needed.
* Example 2: A family wishes to play a simple game where each secretly writes down answers.  This family joins a group.  Each person creates his or her own item object, and sets the visible to false.  Each writes down their answers.  Each "unlocks" and leaves the item object.  Each then sets their item object to visible.  The game can then commence as each can now see what was written down.

## Additional Details Discussed in Class:
* We will avoid a database.  You can implement one if you want, but it's not required.
* The user "logs" in by simply putting in a name and clicking a submit button (example: http://slither.io (Links to an external site.))
* Any user can create a new group or select an existing group.  When a new group is created, other logged in users need to see the updated groups as well (must be asynchronous, no page refresh).
* Within a group, any user can create an item object.  That item object is "owned" by the user who created it.  The item object will need a title, some body of text, and a "visible" checkbox.   Only the owner can modify the visibility checkbox.
* When an item object is modified and "unlocked" for another user to potentially modify it, then the updated item object information needs to be asynchronously sent to all other users.  Again, no page refresh allowed.
* Any item object whose visible checkbox is unchecked should not have the internal text viewable to any other active user. 
* An item object that is locked or unlocked should have its status updated asynchronously to all users.
* Only one item object can be modified at a time.  During modification, that item object is essentially locked from modification by other users.
