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
