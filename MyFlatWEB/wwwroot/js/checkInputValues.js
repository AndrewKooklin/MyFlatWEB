function getInputsVal() {
    var btnSubmitOrder = document.getElementById('submitOrder');
    var name = document.getElementById('name').value.length;
    var email = document.getElementById('mail').value;
    var mobile = document.getElementById('mobile').value.length;
    var service = document.getElementById('service');
    var serviceIndex = service.selectedIndex;
    var message = document.getElementById('message').value.length;
    if (name >= 3 && validateEmail(email) && mobile >= 11 && serviceIndex != 0 && message >= 5) {
        btnSubmitOrder.disabled = false;
    }
    else{
        btnSubmitOrder.disabled = true;
    }
}

function validateEmail(value) {
    const exp = /\S+@\S+\.\S+/;
    return exp.test(value);
}