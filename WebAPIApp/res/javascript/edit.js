
function load_edit_select() {
    $.ajax({
        url: "api/BookType",
        type: 'GET',
        success: function (data) {
            console.log(data);
            $.each(data, function (key, item) {
                var optionCell = document.createElement('option');
                optionCell.innerHTML = item;
                $("#edit_type").append(optionCell);
            });
        }
    });
}



function loadEditModal(bookId) {

        $("#edit_id").val(bookId);
        $("#edit_id").attr("disabled", "disabled");

        $.ajax({
            url: "api/Books/" + bookId,
            type: 'GET',
            success: function (data) {
                console.log(data);
                $("#edit_name").val(data.Name);
                $("#edit_rate").val(data.Rate);
                $("#edit_price").val(data.Price);
            }
        });

}


function edit() {
            console.log("edit function called")
            var _data = { "Id": $("#edit_id").val(), "Name": $("#edit_name").val(), "Type": $("#edit_type").val(), "Rate": $("#edit_rate").val(), "Price": $("#edit_price").val() };
            var name = $("#edit_name").val();

            $.ajax({
                url: "api/Books/",
                type: "PUT",
                data: _data,
                success: function (data) {
                    alert("edit book [" + name + "] successfully");
                    getAll();
                },
                error: function (e) {
                    alert("no this book!");
                    alert(e.responseText);
                }
            });
        }