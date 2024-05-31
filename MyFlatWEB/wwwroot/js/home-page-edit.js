function ShowError(name) {

    var input = document.getElementsByClassName(name)[0];
    var inputValue = input.value;
    var label = input.previousElementSibling;

    if (inputValue == "") {
        label.textContent = "Fill field";
    }
    else {
        label.textContent = "";
    }
}

function HideError(name) {
    var input = document.getElementsByClassName(name)[0];
    var label = input.previousElementSibling;
    label.textContent = "";
    input.value = null;
}

//function BtnClickShowError(id) {

//    var button = document.getElementById(id);
//    var input = button.previousElementSibling;
//    var inputValue = button.previousElementSibling.value;
//    var label = input.previousElementSibling;

//    if (inputValue == "") {
//        label.textContent = "Fill field";
//    }
//    else {
//        label.textContent = "";
//    }
//}
