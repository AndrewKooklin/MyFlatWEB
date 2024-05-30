function ShowError(id) {

    var input = document.getElementById(id);
    var inputValue = input.value;
    var label = input.previousElementSibling;

    if (inputValue == "") {
        label.textContent = "Fill field";
    }
    else {
        label.textContent = "";
    }
}

function HideError(id) {
    var input = document.getElementById(id);
    var label = input.previousElementSibling;
    label.textContent = "";
    input.value = null;
}
