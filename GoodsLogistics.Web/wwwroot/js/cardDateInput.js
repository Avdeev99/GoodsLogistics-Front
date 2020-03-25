var a = 0;
form.cardDateInput.onkeypress = function () {
    if (event.charCode >= 48 && event.charCode <= 57) {
        if (a == 2 && form.cardDateInput.value.length < 4) {
            a = 0;
            form.cardDateInput.value += "/";
        }
        a++;

        if (form.cardDateInput.value.length == 5) {
            a = 0;
        }
        return true;
    } else {
        return false;
    }
}