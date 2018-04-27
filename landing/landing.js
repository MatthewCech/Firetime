  ///////////////////////////////////////////////
 // JavaScript that really needs to run first //
///////////////////////////////////////////////
$('#modalLoading').modal('show');



  //////////////////////////////////////////////////////////////////////
 // General functionality: System initialization, task loading, etc. //
//////////////////////////////////////////////////////////////////////
let firebaseRef = new Firebase('https://firetime-d53fc.firebaseio.com/');
let tasksRef = firebaseRef;//.child("tasks");
let tasks = [];
let activeCount = 0;
let inactiveCount = 0;
let completedCount = 0;



// Load in all previous tasks! Logged key and object to console as well.
tasksRef.once("value", function(snapshot) {
  snapshot.forEach(function(child) {
    //console.log(child.key());
    //console.log(child.val());
    loadTask(child.val());
  });
}).then(()=>{
  // When we're done, toggle the loading overlay off.
  $('#modalLoading').modal('hide');
});


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


// Toggles the task creation thing
function toggleTaskCreate() {
  $('#modalCreateTask').modal('toggle');
}


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
  if(task.alive) {
    if(task.active) 
      ++activeCount;
    else
      ++inactiveCount;
  } else {
    ++completedCount;
  }

  return `<div class="ft-task-item text-left" id="${task.id}" taskactive=false>
        <div class="ft-task-button" id="toggle-${"" + task.id}">
        ${(!task.alive) ? "" : (task.active ? 
         `<a href="javascript:makeTaskComplete('${task.id}'); ">
            <i class="fas fa-check fa-2x"></i></a>
          <a href="javascript:makeTaskInactive('${task.id}'); ">
            <i class="fas fa-minus fa-2x"></i></a>`
          :
         `<a href="javascript:makeTaskActive('${task.id}');">
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
function loadTask(task) {
  // update variables
  if(task.alive) {
    if(task.active) {
      if(activeCount == 0)
        document.getElementById("ft-tasklist-active").innerHTML = ""; 
      document.getElementById("ft-tasklist-active").innerHTML += taskToHTML(task);
    } else {
      if(inactiveCount == 0)
        document.getElementById("ft-tasklist-idle").innerHTML = ""; 
      document.getElementById("ft-tasklist-idle").innerHTML += taskToHTML(task);
    }
    tasks[task.id] = task;
  } else {
    if(completedCount == 0)
      document.getElementById("ft-tasklist-finished").innerHTML = ""; 
    document.getElementById("ft-tasklist-finished").innerHTML += taskToHTML(task);
    tasks[task.id] = task;
  }
  
}






function somethingHappened (snapshot, context) {
  console.log(context);
}
firebaseRef.on('child_changed', somethingHappened);




  //////////////////////////////////////////
 // TASK CREATION AND MANAGEMENT SECTION //
//////////////////////////////////////////
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
    alive: true,
    active: false,
  };

  tasksRef.child(task.id).set(task);

  if(inactiveCount == 0)
    document.getElementById("ft-tasklist-idle").innerHTML = "";
  document.getElementById("ft-tasklist-idle").innerHTML += taskToHTML(task);
  
  // update variables
  tasks[task.id] = task;
  toggleTaskCreate();
}


// This is marking a task as completely done! From here, the task goes in history. There
// aren't many 
function makeTaskComplete(id) {
  // Update firebase
  tasksRef.child(id + "/alive").transaction(() => {
    return false;
  }).then(() => { 
    // Update local data
    tasks[id].alive = false;
    tasks[id].active = false;

    // Update visuals
    let element = document.getElementById(id);
    if(activeCount == 0)
      document.getElementById("ft-tasklist-finished").innerHTML = "";
    document.getElementById("ft-tasklist-finished").innerHTML += taskToHTML(tasks[id]);

    // Update display counter and see if we need to display active as empty.
    displayEmptyActive();
    --activeCount;
  });
}


// Marks a task as active.
function makeTaskActive(id) {
  // Update firebase first!
  tasksRef.child(id + "/active").transaction(() => {
    return true;
  }).then(() => { 
    visual_makeTaskActive(id);
  });
}
function visual_makeTaskActive(id) {
// Update local data
  tasks[id].active = true; 
  
  // Update visuals, clearing out placeholder as necessary.
  let element = document.getElementById(id);
  element.parentNode.removeChild(element);
  if(activeCount == 0)
    document.getElementById("ft-tasklist-active").innerHTML = "";
  document.getElementById("ft-tasklist-active").innerHTML += taskToHTML(tasks[id]);

  // If necessary, display 'nothing yet', and update values
  displayEmptyInactive();
  --inactiveCount;
}


// Updates task to be no longer marked as what it was.
function makeTaskInactive(id) {
  // Update firebase. Once updated, do all visal and local updates.
  tasksRef.child(id + "/active").transaction((oldVal) => {
    return false;
  }).then(() => { 
    visual_makeTaskInactive(id);
  });
}
function visual_makeTaskInactive(id) {
  // Update local data
  tasks[id].active = false; 
  
  // Update visuals: Clear out the "Nothing yet" and re-create task element.
  let element = document.getElementById(id);
  element.parentNode.removeChild(element);
  if(inactiveCount == 0)
    document.getElementById("ft-tasklist-idle").innerHTML = "";
  document.getElementById("ft-tasklist-idle").innerHTML += taskToHTML(tasks[id]);

  // If necessary, display 'nothing yet', and update values
  displayEmptyActive();
  --activeCount;
}


// Deletes the task with the specified ID.
function deleteTask(id) {
  // Update firebase first
  tasksRef.child(id+"").remove().then(()=>{
    visual_deleteTask();
  });
}
function visual_deleteTask(id) {
  // Update local data
  delete tasks[id];

  // Update visuals
  let element = document.getElementById(id); 
  element.parentNode.removeChild(element);
  displayEmptyInactive();
  --inactiveCount;
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