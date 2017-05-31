function isRequired(t) {
    if (t == null || t === "") {
        return false;
    } else {
        return true;
    }
}

function isEmail(e) {
    var regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    return regex.test(e);
}

function isUrl(u) {
    var regex = /(http|https|ftp)?(:\/\/)?(www\.)?[A-Za-z]{1,253}\.([A-Za-z]{1,3}\.)?[A-Za-z]{1,63}/;
    return regex.test(u);
}





function validerForm(form) {

    var validate = true;
    var navn = form["navn"].value;
    var email = form["email"].value;
    var emne = form["emne"].value;
    var textbox = form["textbox"].value;

    if (!isRequired(navn)) {
        alert("Du skal skrive dit navn");
        validate = false;
        return false;
    }



    if (!isEmail(email)) {
        alert("Du skal skrive din E-mail");
        validate = false;
        return false;
    }



    if (!isRequired(emne)) {
        alert("Du skal skrive et emne");
        validate = false;
        return false;   
    }

    if (!isRequired(textbox)) {
        alert("Du skal skrive en besked");
        validate = false;
        return false;
    }

    if (validate == true) {


        document.getElementById("message").style.display = "block ";
        alert("Din besked er blevet sendt")


    }
    return false;
}


