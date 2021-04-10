// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#ContractSum").rules("remove", "number"); 
    $("#Advance").rules("remove", "number"); 
});

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
        autoFocus: true,
        delay: 500,
        select: function (e, i) {
            $("#Customerid").val(i.item.val);

            $.ajax({
                url: '/api/GetAgreementsOfCustomer',
                data: { "Id": i.item.val },
                type: "GET",                
                success: function (data) {
                    $('#selectCurrentAgreementId').find('option').remove();
                    $("#selectCurrentAgreementId").append($("<option></option>").attr("value", "").text("Клиент выбран"));                    
                    $.each(data, function (index, item)                    {
                        $("#selectCurrentAgreementId").append($("<option></option>").attr("value", item.id).text(item.id + "/" + item.date));
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
        minLength: 2
    });
});

