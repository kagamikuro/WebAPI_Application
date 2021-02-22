/*
interface Config {
    type: string;
    url: string;
    data?: string;
    dataType: string
}

function ajax(config: Config) {

    var xhr = new XMLHttpRequest()
    xhr.open(config.type, config.url, true)
    xhr.send(config.data);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            console.log('success')
        }
        else {
            console.log(xhr.responseText)
        }
    }
    */




function getAll() {
    $("#bookTable").children("thead").html("");
    $("#bookTable").children("tbody").html("");


    var row = document.createElement('tr');

    var idCell = document.createElement('th');
    idCell.innerHTML = "#";
    row.appendChild(idCell);

    var nameCell = document.createElement('th');
    nameCell.innerHTML = "Book Name";
    row.appendChild(nameCell);

    var typeCell = document.createElement('th');
    typeCell.innerHTML = "Type";
    row.appendChild(typeCell);

    var rateCell = document.createElement('th');
    rateCell.innerHTML = "Rate";
    row.appendChild(rateCell);

    var priceCell = document.createElement('th');
    priceCell.innerHTML = "Price";
    row.appendChild(priceCell);

    var actionCell = document.createElement('th');
    actionCell.innerHTML = "Action"
    row.appendChild(actionCell);


    $("#bookTable").children("thead").append(row);



    $.ajax({
        url: "api/Books",
        type: 'GET',
        success: function (data) {
            //console.log(data);
            $.each(data, function (key, item) {



                var row = document.createElement('tr');

                var idCell = document.createElement('td');
                idCell.innerHTML = item.Id;
                idCell.setAttribute("class", "bookId");
                row.appendChild(idCell);

                var nameCell = document.createElement('td');
                nameCell.innerHTML = item.Name;
                nameCell.setAttribute("class", "bookname");
                row.appendChild(nameCell);

                var typeCell = document.createElement('td');
                typeCell.innerHTML = item.Type;
                row.appendChild(typeCell);

                var rateCell = document.createElement('td');
                rateCell.innerHTML = item.Rate;
                row.appendChild(rateCell);

                var priceCell = document.createElement('td');
                priceCell.innerHTML = "$" + item.Price;
                row.appendChild(priceCell);

                var actionCell = document.createElement('td');
                row.appendChild(actionCell);
                var btnEdit = document.createElement('input');
                btnEdit.setAttribute('type', 'button');
                btnEdit.setAttribute('value', 'E');
                btnEdit.setAttribute('class', 'btn btn-info');
                btnEdit.setAttribute('id', 'btnEdit');

                btnEdit.onclick = function () {
                    var bookId = $(this).parent().parent().children(".bookId").html();
                    //console.log("edit function called with bookName:" + bookId);

                    loadEditModal(bookId); 
                    $('#editModal').modal();
                };
                actionCell.appendChild(btnEdit);

                //actionCell.innerHTML += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                var space = document.createElement('label');
                space.innerHTML = "&nbsp;&nbsp;&nbsp;&nbsp;";
                actionCell.appendChild(space);

                var btnDel = document.createElement('input');
                btnDel.setAttribute('type', 'button');
                btnDel.setAttribute('value', 'X');
                btnDel.setAttribute('class', 'btn btn-danger');
                btnDel.setAttribute('id', 'btnDel');

                btnDel.onclick = function () {
                    var id = $(this).parent().parent().children(".bookId").html();
                    var name = $(this).parent().parent().children(".bookname").html();
                    console.log("children:" + $(this).parent().parent().children(".bookId").html());


                    $.ajax({
                        url: "api/Books/" + id,
                        type: 'DELETE',
                        success: function (data) {
                            alert("delete book [" + name + "] successfully");
                            getAll();
                        }
                    });
                };

                actionCell.appendChild(btnDel);

                $("#bookTable").children("tbody").append(row);
            });
        }
    });

}


function openEditWin() {

    window.open("edit.html", "newwindow", "height=700, width=450, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no");
}


function openCreateWin() {

    window.open("create.html", "newwindow", "height=510, width=400, toolbar=no,menubar=no, scrollbars=no, resizable=no, location=no, status=no");
}

function popCreateModal() {
    $('#createModal').modal();
}


$("#btnFind").click(function () {
    var id = $('#bookName').val();
    console.log(id);
    $.ajax({
        url: "api/Books/" + id,
        type: 'GET',
        success: function (data) {
            $("#book").text(formatItem(data));
        },
        error: function (e) {
            $("#book").text("book not found!");
        }
    });
});
