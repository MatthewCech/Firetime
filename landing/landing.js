  ///////////////////////////////////////////////
 // JavaScript that really needs to run first //
///////////////////////////////////////////////
// Show the loading overlay until we turn it off later.
showLoading();




  //////////////////////////////////////////////////////////////////////
 // General functionality: System initialization, task loading, etc. //
//////////////////////////////////////////////////////////////////////
// Firebase config
let firebaseRef = new Firebase('https://firetime-d53fc.firebaseio.com/');
let tasksRef = firebaseRef;//.child("tasks");
let startupComplete = false;

// Local data
let tasks = [];
let activeCount = 0;
let inactiveCount = 0;
let completedCount = 0;

// Enums
const statuses = { inactive:0, active:1, finished:2 };




  ////////////////////////////
 // Firebase event binding //
////////////////////////////
// Load in all previous tasks! When done, toggle the loading overlay off.
tasksRef.once("value", function(snapshot) {
  snapshot.forEach(function(child) {
    loadTaskLocally(child.val());
  });
}).then(()=>{
  startupComplete = true; //!!! Could create a dead zone moment
  hideLoading();
});


// A new task was created, either locally or remotely! Lets load it.
tasksRef.on('child_added', (snapshot) => {
  if(startupComplete)
    loadTaskLocally(snapshot.val());
});


// A task was updated either locally or remotely - lets update it by 
// removing the old version we have, then loading it back in again!
tasksRef.on('child_changed', (snapshot) => {
  removeIDLocally(snapshot.key());
  loadTaskLocally(snapshot.val());
});


// A remote task was loaded
tasksRef.on('child_removed', (snapshot) => {
  removeIDLocally(snapshot.key());
});




  //////////////////////////////////////////
 // Task creation and management section //
//////////////////////////////////////////
// Creates the data associated with a task, and sends it off. 
function createTask(e) {
  // Stop us from navigating by default with a form
  e.preventDefault();

  // Parse all info out of the form
  let task = {
    id: makeID(),
    name: document.getElementById("ft-name").value,
    description: document.getElementById("ft-description").value,
    timeEstimated: parseInt(document.getElementById("ft-estimated").value),
    color: document.getElementById("ft-color").value,
    timeCreated: Date.now(),
    timeEnded: 0,
    status: statuses.inactive,
  };

  tasksRef.child(task.id).set(task);
  $('#modalCreateTask').modal('hide'); // hide the task creation modal
}


// This is marking a task as completely done! From here, the task goes in history.
function makeTaskComplete(id) {
  // Update firebase
  tasksRef.child(id + "/status").transaction(() => {
    return statuses.finished;
  });
}


// Marks a task as active.
function makeTaskActive(id) {
  // Update firebase first!
  tasksRef.child(id + "/status").transaction(() => {
    return statuses.active;
  });
}


// Updates task to be no longer marked as what it was.
function makeTaskInactive(id) {
  // Update firebase. Once updated, do all visal and local updates.
  tasksRef.child(id + "/status").transaction((oldVal) => {
    return statuses.inactive;
  })
}


// Deletes the task with the specified ID. This is
// rather permanent, and deletes it on the server too.
function deleteTask(id) {
  tasksRef.child(id+"").remove();
}




  ///////////////////////////////
 // General utility functions //
///////////////////////////////
// Makes a unique id string for this app by combining some random numbers with the 
// current time. This will basically always be unique for the purposes of this 
// application, if there are two items with the same ID then you've caused a cosmic 
// anomaly, and the universe is just a complete lie. This is a trash sandwich.
function makeID() {
  function trash() {
    return Math.floor((1 + Math.random()) * 0x10000);
  }
  return `${trash()}${Date.now()}${trash()}`;
}

// Modal showing and hiding
function showTaskCreate() {
  $('#modalCreateTask').modal('show');
}
function hideTaskCreate() {
  $('#modalCreateTask').modal('hide');
}
function showLoading() {
  $('#modalLoading').modal('show');
}
function hideLoading() {
  $('#modalLoading').modal('hide');
}


// Debug stats, for dumping to console. Vaguely formatted intentionally,
// also formatting is kinda like this to make the string more spaced in code.
function debugStats() {
  return `
    Active:${activeCount}
    Inactive:${inactiveCount}
    Completed:${completedCount}
  `
}




  /////////////////////////////////////////////
 // Client-side data and task visualization //
/////////////////////////////////////////////
// Display text in the active task section about it being empty
function displayEmptyActive() {
  if(activeCount <= 1) {
    document.getElementById("ft-tasklist-active").innerHTML = `<h4><small class="text-muted">Nothing yet!</small></h4>`;
  }
}


// Display text in the inactive task section about it being empty
function displayEmptyInactive() {
  if(inactiveCount <= 1) {
    document.getElementById("ft-tasklist-idle").innerHTML = `<h4><small class="text-muted">Nothing yet!</small></h4>`;
  }
}


// Not lovely, but could be a DOM object some other day in a less trash way. But hey, at 
// least this isn't a complete mess spread out across functions like it used to be! :D
function taskToHTML(task) {
  if(task.status == statuses.active)
    ++activeCount;
  else if(task.status == statuses.inactive)
    ++inactiveCount;
  else if(task.status == statuses.finished)
    ++completedCount;
  else
    console.warn("Task did not have a status we recognized: " + task.status + ". Will attempt to parse as usual.");


  return `<div class="ft-task-item text-left" id="${task.id}" taskactive=false>
        <div class="ft-task-button" style="position: absolute; width: 100%;" id="toggle-${"" + task.id}">
        ${(task.status == statuses.finished) ? "" : (task.status == statuses.active ? 
         `<a style="margin-left: -25px;" href="javascript:makeTaskComplete('${task.id}'); ">
            <i class="fas fa-check fa-2x"></i></a>
          <a style="" href="javascipt:makeTaskInactive('${task.id}'); ">
            <i class="fas fa-minus fa-2x"></i></a>`
          :
         `<a style="margin-left: -25px;" href="javascript:makeTaskActive('${task.id}');">
            <i class="fas fa-plus fa-2x"></i></a>
          <a href="javascript:deleteTask('${task.id}');">
            <i class="far fa-trash-alt fa-2x"></i></a>` 
        )}
        </div>
      <div class="row" style="display: flex;"> <!-- In theory, onclick could be added to the entire div. -->
        <div class="col-sm-3 ft-task-name align-middle">
          <strong style="color: ${task.color}; ">${task.name}</strong>
        </div>
        <div class="col-sm-7 ft-task-desc align-middle">
          <p>${task.description}</p>
        </div>
        <div class="col-sm-1 ft-task-time align-middle">
          <p>${task.timeEstimated}</p>
        </div>
      </div>
    </div>
  `;
}


// Loads a task from firebase into the appropriate
function loadTaskLocally(task) {
  if(task.status == statuses.active) {
    if(activeCount == 0)
      document.getElementById("ft-tasklist-active").innerHTML = ""; 
    document.getElementById("ft-tasklist-active").innerHTML += taskToHTML(task);
  } else if(task.status == statuses.inactive) {
      if(inactiveCount == 0)
        document.getElementById("ft-tasklist-idle").innerHTML = ""; 
      document.getElementById("ft-tasklist-idle").innerHTML += taskToHTML(task);
  } else if(task.status == statuses.finished) {
    if(completedCount == 0)
      document.getElementById("ft-tasklist-finished").innerHTML = ""; 
    document.getElementById("ft-tasklist-finished").innerHTML += taskToHTML(task);
  } else {
    console.error("We got a misconfigured task with the following status: " + task.status);
    return;
  }
  
  tasks[task.id] = task;
}


// Locally removes the specified ID and updates variables appropriately.
function removeIDLocally(id) {
  let element = document.getElementById(id);
  element.parentNode.removeChild(element);
  if(tasks[id].status == statuses.inactive) {
    displayEmptyInactive();
    --inactiveCount;
  } 
  else if(tasks[id].status == statuses.active) {
    displayEmptyActive();
    --activeCount;
  }
  else if(tasks[id].status == statuses.finished) {
    --completedCount;
  }
  else {
    console.error("Tried to delete something without a known status. Status seen: " + tasks[id].status);
    return;
  }

  delete tasks[id];
}