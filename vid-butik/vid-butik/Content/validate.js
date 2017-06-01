function ValidateGem() {
    var txt;
    if (confirm("er du sikker på du vil gemme!") === true) {
        txt = "You pressed OK!";
    } else {
        txt = "You pressed Cancel!";
    }
}
function ValidateSlet() {
    var txt;
    if (confirm("er du sikker på du vil slette!") === true) {
        txt = "You pressed OK!";
    } else {
        txt = "You pressed Cancel!";
    }
}