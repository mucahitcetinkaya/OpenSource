"use strict"
const inputTaskName = document.querySelector("#input-new-task");
const btnNewTask = document.querySelector("#btn-new-task");
const btnClear = document.querySelector("#btn-clear");
const taskList = document.querySelector("#task-list");

let isEditMode = false; //Eğer bu false ise Yeni Kayıt modundayız, true ise Düzeltme modundayız.
let editedTaskId;//O anda hangi görevi düzenliyoruz bilgisini uygulama boyunca kullanmak için
let filterMode = "all";

let taskListArray = [];
getLocalStorage();

btnNewTask.addEventListener("click", addNewTask);
btnClear.addEventListener("click", clearAll);

function addNewTask(e) {
    e.preventDefault();
    let value = inputTaskName.value.trim();
    if (value != "") {
        let id = taskListArray.length == 0 ? 1 : taskListArray[taskListArray.length - 1].id + 1;
        taskListArray.push(
            {
                "id": id,
                "name": value,
                "status": "pending"
            });
        saveLocalStorage();
    } else {
        alert("Lütfen görev adını boş bırakmayınız!");
    }
    inputTaskName.value = "";
    inputTaskName.focus();
    displayTasks();
}

function clearAll() {
    taskListArray=[];
    saveLocalStorage();
    displayTasks();
}

function displayTasks() {
    //Bu function, her ihtiyaç duyulduğunda tüm görevleri yeniden ekranda göstermek için kullanılacak
    taskList.innerHTML = "";
    if (taskListArray.length == 0) {
        taskList.innerHTML = '<div class="alert">Burada görev bulunmamaktadır!</div>';
    } else {
        for (let task of taskListArray) {
            let completed = task.status == "completed" ? "checked" : "";
            if (filterMode == "all") {
                let taskLi = `
            <li class="task-container" id="${task.id}">
                <div class="task-header">
                    <input onclick="updateStatus(this);" class="task-check" type="checkbox" id="${task.id}" ${completed}>
                    <input id="_${task.id}" class="task-name ${completed}" type="text" value="${task.name}" disabled>
                </div>
                <div class="btn-group">
                    <button id="${task.id}" onclick="updateTask(this);" class="btn-edit">Düzenle</button>
                    <button id="${task.id}" onclick="deleteTask(this);" class="btn-delete">Sil</button>
                </div>
            </li>
        `;
                taskList.insertAdjacentHTML("beforeend", taskLi);
            }

        }
    }

}


function updateStatus(selectedTask) {

    let newStatus = selectedTask.checked ? "completed" : "pending";
    console.log(newStatus);
    for (const i in taskListArray) {
        if (selectedTask.id == taskListArray[i].id) {
            taskListArray[i].status = newStatus;
            saveLocalStorage();
        }
    }
    displayTasks();
}

function updateTask(clickedButton) {

    let editedTask = clickedButton.parentElement.previousElementSibling.lastElementChild;
    const liList = document.querySelectorAll(".task-container");
    for (const li of liList) {
        if (clickedButton.id != li.id) {
            li.firstElementChild.lastElementChild.setAttribute("disabled", "disabled");
            li.lastElementChild.firstElementChild.innerText = "Düzenle";
            li.lastElementChild.firstElementChild.classList.remove("clicked-button");
        } else {
            if (li.lastElementChild.firstElementChild.innerText == "Kaydet") {
                li.firstElementChild.lastElementChild.setAttribute("disabled", "disabled");
                li.lastElementChild.firstElementChild.innerText = "Düzenle";
                li.lastElementChild.firstElementChild.classList.remove("clicked-button");
                for (let i = 0; i < taskListArray.length; i++) {
                    if (clickedButton.id == taskListArray[i].id) {
                        taskListArray[i].name = editedTask.value;
                        saveLocalStorage();
                        // displayTasks();
                    }
                }
            } else {
                li.firstElementChild.lastElementChild.removeAttribute("disabled");
                li.lastElementChild.firstElementChild.innerText = "Kaydet";
                li.lastElementChild.firstElementChild.classList.add("clicked-button");
            }
        }
    }
    console.log(taskListArray);
    editedTask.focus();
}

function getLocalStorage() {
    if (localStorage.getItem("tasks") != null) {
        taskListArray = JSON.parse(localStorage.getItem("tasks"));
    }
}

function saveLocalStorage() {
    localStorage.setItem("tasks", JSON.stringify(taskListArray));
}

displayTasks();