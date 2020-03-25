var pricePerNight = 1500;
let days = getDaysCount();
let totalPrice = document.getElementById("preview_price");
totalPrice.value = "$" + days * 1500;

$(document).ready(function () {
    $('#preview_form').change(function () {
        let pricePerNight = 1500;
        let days = getDaysCount();
        let childrenCount = document.getElementById("childrenCount").value;
        if (childrenCount > 0 && childrenCount < 3)
            pricePerNight *= 0.9;
        else if (childrenCount > 2)
            pricePerNight *= 0.8;
        let totalPrice = document.getElementById("preview_price");
        totalPrice.value = "$" + days * pricePerNight;

    });
});

function getDaysCount() {
    let twoDates = document.getElementById("datePicker").value;
    twoDates = twoDates.split(' - ');
    let dateFrom = twoDates[0].split('/');
    dateFrom = dateFrom[1] + '/' + dateFrom[0] + '/' + dateFrom[2];
    dateFrom = new Date(dateFrom);
    let dateTo = twoDates[1].split('/');
    dateTo = dateTo[1] + '/' + dateTo[0] + '/' + dateTo[2];
    dateTo = new Date(dateTo);
    dateFrom = dateFrom.getTime();
    dateTo = dateTo.getTime();
    let days = parseInt((dateTo - dateFrom) / (24 * 3600 * 1000));
    return days;
}