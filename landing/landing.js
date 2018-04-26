let firebaseRef = new Firebase('https://firetime-d53fc.firebaseio.com/');
let tasksRef = firebaseRef;//.child("tasks");
let tasks_alive = [];
let tasks_complete = [];
let activeCount = 0;
let inactiveCount = 0;
let completedCount = 0;

// Load in all previous tasks! Logged key and object to console as well.
tasksRef.once("value", function(snapshot) {
  snapshot.forEach(function(child) {
    console.log(child.key());
    console.log(child.val());
    loadTask(child.val());
  });
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

function makeTaskComplete(id) {
  let element = document.getElementById(id);

  // Update visuals
  if(activeCount == 0)
    document.getElementById("ft-tasklist-finished").innerHTML = "";
  document.getElementById("ft-tasklist-finished").appendChild(element);
  document.getElementById("toggle-" + id).innerHTML = "";

  // Update firebase
  tasksRef.child(id + "/alive").transaction(() => {
    return false;
  }).then(() => { 
    tasks_complete[id] = tasks_alive[id];
    delete tasks_alive[id];
  });

  // If necessary, display 'nothing yet', and update values
  ++completedCount;
}

function makeTaskActive(id) {
  let element = document.getElementById(id);

  // Update visuals
  if(activeCount == 0)
    document.getElementById("ft-tasklist-active").innerHTML = "";
  document.getElementById("ft-tasklist-active").appendChild(element);
  document.getElementById("toggle-" + id).innerHTML =`
    <a href="javascript:makeTaskComplete('${id}'); ">
      <i class="fas fa-check fa-2x"></i></a>
    <a href="javascript:makeTaskInactive('${id}'); ">
      <i class="fas fa-minus fa-2x"></i></a>
  `;

  // Update firebase
  tasksRef.child(id + "/active").transaction(() => {
    return true;
  }).then(() => { 
    tasks_alive[id].active = true; 
  });

  // If necessary, display 'nothing yet', and update values
  if(inactiveCount <= 1) {
    inactiveCount = 0;
    document.getElementById("ft-tasklist-idle").innerHTML = `<h4><small class="text-muted">Nothing yet!</small></h4>`;
  }
  ++activeCount;
}

function deleteTask(id) {
  let element = document.getElementById(id); 
  element.parentNode.removeChild(element);

  // Update firebase
  tasksRef.child(id+"").remove().then(()=>{
    delete tasks_alive[id];
  });
}

function makeTaskInactive(id) {
  let element = document.getElementById(id);
  
  // Update visuals
  if(inactiveCount == 0)
    document.getElementById("ft-tasklist-idle").innerHTML = "";
  document.getElementById("ft-tasklist-idle").appendChild(element);
  document.getElementById("toggle-" + id).innerHTML =`
    <a href="javascript:makeTaskActive('${id}');">
      <i class="fas fa-plus fa-2x"></i></a>
    <a href="javascript:deleteTask('${id}');">
      <i class="far fa-trash-alt fa-2x"></i></a>
  `;

  // Update firebase
  tasksRef.child(id + "/active").transaction(function(oldVal) {
    return false;
  }).then(() => { tasks_alive[id].active = false; });

  // If necessary, display 'nothing yet', and update values
  if(activeCount <= 1) {
    activeCount = 0;
    document.getElementById("ft-tasklist-active").innerHTML = `<h4><small class="text-muted">Nothing yet!</small></h4>`;
  }
  ++inactiveCount;
}

// Not lovely, but could be a DOM object some other day.
function taskToHTML(task) {
  return `<div class="ft-task-item text-left" id="${task.id}" taskactive=false>
      <div class="row" style="display: flex;"> <!-- In theory, onclick could be added to the entire div. -->
        <div class="col-xs ft-task-name" id="toggle-${"" + task.id}">
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
        <div class="col-sm-2 ft-task-name align-middle">
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
      ++activeCount;
    } else {
      if(inactiveCount == 0)
        document.getElementById("ft-tasklist-idle").innerHTML = ""; 

      document.getElementById("ft-tasklist-idle").innerHTML += taskToHTML(task);
      ++inactiveCount;
    }
    
    tasks_alive[task.id] = task;
  } else {
    if(completedCount == 0)
      document.getElementById("ft-tasklist-finished").innerHTML = ""; 

    document.getElementById("ft-tasklist-finished").innerHTML += taskToHTML(task);
    tasks_complete[task.id] = task;
    ++completedCount;
  }
  
}


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
  tasks_alive[task.id] = task;
  ++inactiveCount;
  toggleTaskCreate();
}
