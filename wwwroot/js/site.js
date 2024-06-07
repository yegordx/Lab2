const uri = 'api/Doctors';
let doctors = []; // Змінено з categories на doctors

function getDoctors() { // змінено на lowerCamelCase
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayDoctors(data))
        .catch(error => console.error('Unable to get doctors.', error));
}

function addDoctor() { // змінено на lowerCamelCase
    const addNameTextbox = document.getElementById('add-name');
    const addSecondNameTextbox = document.getElementById('add-secondname');
    const addPostTextbox = document.getElementById('add-post');
    const addInfoTextbox = document.getElementById('add-info');

    const doctor = {
        Name: addNameTextbox.value.trim(),
        SecondName: addSecondNameTextbox.value.trim(),
        Post: addPostTextbox.value.trim(),
        Info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(doctor)
    })
        .then(response => response.json())
        .then(() => {
            getDoctors(); // Виклик getDoctors для оновлення списку
            addNameTextbox.value = '';
            addSecondNameTextbox.value = '';
            addPostTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add doctor.', error));
}

function deleteDoctor(id) { // змінено на lowerCamelCase
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getDoctors()) // Виклик getDoctors для оновлення списку
        .catch(error => console.error('Unable to delete doctor from list.', error));
}

function displayEditForm(id) { // змінено на lowerCamelCase
    const doctor = doctors.find(doctor => doctor.id === id);
    document.getElementById('edit-id').value = doctor.id;
    document.getElementById('edit-name').value = doctor.name;
    document.getElementById('edit-secondname').value = doctor.secondName;
    document.getElementById('edit-post').value = doctor.post;
    document.getElementById('edit-info').value = doctor.info; // Виправлено з category.info
    document.getElementById('editForm').style.display = 'block';
}

function updateDoctor() { // змінено на lowerCamelCase
    const doctorId = document.getElementById('edit-id').value;
    const doctor = {
        id: parseInt(doctorId, 10),
        name: document.getElementById('edit-name').value.trim(),
        secondName: document.getElementById('edit-secondname').value.trim(),
        post: document.getElementById('edit-post').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${doctorId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(doctor)
    })
        .then(() => getDoctors()) // Виклик getDoctors для оновлення списку
        .catch(error => console.error('Unable to update doctor`s info.', error));
    closeInput();

    return false;
}

function closeInput() { // змінено на lowerCamelCase
    document.getElementById('editForm').style.display = 'none';
}

function _displayDoctors(data) {
    const tBody = document.getElementById('doctors');
    tBody.innerHTML = '';
    const button = document.createElement('button');

    data.forEach(doctor => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${doctor.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteDoctor(${doctor.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNodeName = document.createTextNode(doctor.name);
        td1.appendChild(textNodeName);

        let td2 = tr.insertCell(1);
        let textNodeSecondName = document.createTextNode(doctor.secondName);
        td2.appendChild(textNodeSecondName);

        let td3 = tr.insertCell(2);
        let textNodePost = document.createTextNode(doctor.post);
        td3.appendChild(textNodePost);

        let td4 = tr.insertCell(3);
        let textNodeInfo = document.createTextNode(doctor.info);
        td4.appendChild(textNodeInfo);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    doctors = data; // Зберігання отриманих даних
}


