function ShowErrorInputNameTopLink(click_id) {

    var input = document.getElementById(click_id);
    var inputValue = input.value;
    var label = input.previousElementSibling;

    if (inputValue == "") {
        label.textContent = "Fill field";
    }
    else {
        label.textContent = "";
    }
}

function DeleteError(id) {
    var input = document.getElementById(id);
    var label = input.previousElementSibling;
    label.textContent = "";
    input.value = null;
}
