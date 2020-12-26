
function load_add_select(){

	$.ajax({
            	url: "api/BookType",
            	type: 'GET',
            	success: function (data) {
                	$.each(data, function (key, item) {
                    	var optionCell = document.createElement('option');
                    	optionCell.innerHTML = item;
                        $("#add_type").append(optionCell);
                	});
            	}
        });

}



function create() {
    var _data = { Name: $("#add_name").val(), Type: $("#add_type").val(), Rate: $("#add_rate").val(), Price: $("#add_price").val() };
    var name = $("#add_name").val();
    console.log(_data);

    $.ajax({
        url: "api/Books/Post",
        type: "POST",
        data: _data,
        success: function (data) {
            alert("add book [" + name + "] successfully");
            getAll();
        },
        error: function (e) {
            alert("add book [" + name + "] fail");
            alert(e.responseText);
        }
    });
}