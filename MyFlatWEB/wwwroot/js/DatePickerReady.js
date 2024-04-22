function SetMe() {

    var inputdatefrom = $('#datefrom').value;
    var inputdateto = $('#dateto').value;
    var inputvalidate = $('#validate').value;

    if (inputdatefrom.value == "" || inputdateto.value == "") {
        inputvalidate.value = "Fill dates";
    }
    else {
        inputvalidate.value = "";
    }
    return false;
}