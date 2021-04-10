$(function () {
    $("#CustAutocomplete").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/api/customersuggestion',
                data: { "prefix": request.term },
                type: "GET",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $("#Customerid").val(i.item.val);

            $.ajax({
                url: '/api/GetOrdersThisCustomer',
                data: { "Id": i.item.val },
                type: "GET",                
                success: function (data) {
                    $('#selectCurrentOrderId').find('option').remove();
                    $("#selectCurrentOrderId").append($("<option></option>").attr("value", "").text("Выберите договор"));
                    $.each(data, function (index, item) {
                        $("#selectCurrentOrderId").append($("<option></option>").attr("value", item.id).text(item.id + " от " + item.date));
                    });
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });

        },
        minLength: 2,
        autoFocus: true,
    });
});

$(document).ready(function () {
    $("#Sum").rules("remove", "number");    
});

