function validate_bookname(bookname) {
    var nameReg = /^[0-9A-Za-z ]+$/;

    if (bookname != "" && bookname.search(nameReg) != -1) {
        document.getElementById("add_bookname").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("add_bookname").innerHTML = "<font color='red' size='3px'>number and letter only</font>";
    }
}


function validate_bookrate(bookrate) {

    var rateReg = /^[1-5]$/;
    if (bookrate != "" && bookrate.search(rateReg) != -1) {
        document.getElementById("add_bookrate").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("add_bookrate").innerHTML = "<font color='red' size='3px'>number 1-5 only</font>";
    }
}


function validate_bookprice(bookprice) {

    if (bookprice != "" && bookprice > 0 && bookprice <=500000) {
        document.getElementById("add_bookprice").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("add_bookprice").innerHTML = "<font color='red' size='3px'>number 1-500000 only</font>";
    }
}

function validate_bookname_edit(bookname) {
    var nameReg = /^[0-9A-Za-z ]+$/;

    if (bookname != "" && bookname.search(nameReg) != -1) {
        document.getElementById("edit_bookname").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("edit_bookname").innerHTML = "<font color='red' size='3px'>number and letter only</font>";
    }
}


function validate_bookrate_edit (bookrate) {

    var rateReg = /^[1-5]$/;
    if (bookrate != "" && bookrate.search(rateReg) != -1) {
        document.getElementById("edit_bookrate").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("edit_bookrate").innerHTML = "<font color='red' size='3px'>number 1-5 only</font>";
    }
}


function validate_bookprice_edit (bookprice) {

    if (bookprice != "" && bookprice > 0 && bookprice <= 500000) {
        document.getElementById("edit_bookprice").innerHTML = "<font color='green' size='3px'>correct</font>";
    } else {
        document.getElementById("edit_bookprice").innerHTML = "<font color='red' size='3px'>number 1-500000 only</font>";
    }
}