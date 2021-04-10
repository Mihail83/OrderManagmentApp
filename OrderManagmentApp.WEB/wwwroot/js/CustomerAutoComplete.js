//$(function () {
//    $("#CustAutocomplete").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: '/api/customersuggestion',
//                data: { "prefix": request.term },
//                type: "GET",
//                success: function (data) {
//                    response($.map(data, function (item) {
//                        return item;
//                    }))
//                },
//                error: function (response) {
//                    alert(response.responseText);
//                },
//                failure: function (response) {
//                    alert(response.responseText);
//                }
//            });
//        },
//        select: function (e, i) {
//            $("#Customerid").val(i.item.val);

//        },
//        minLength: 2
//    });
//});