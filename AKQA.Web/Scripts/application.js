$(document).ready(function () {
    
    $("#btnSubmit").click(function () {
        var data = parseFloat($("#txtNumericValue").val()).toFixed(2);
        GetWordString(data);
    });
});

function GetWordString(value) {
    var endpoint = $("#hdnEndPoint").val();
    $.ajax({
        type: 'GET',
        url: endpoint + "?numericValue=" + value,
        contentType: 'text/plain',
        xhrFields: {
            withCredentials: false
        },
        headers: {
        },
        success: function (data) {
            var name = $("#txtName").val();
            $("#strName").html(name);
            $("#strWordConvertion").html(data);
        },

        error: function (data) {
            var name = $("#txtName").val();
            $("#strName").html(name);
            $("#strWordConvertion").html(data.responseText);
        }
    });
}