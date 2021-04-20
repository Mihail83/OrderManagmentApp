var selectedtd = "";
$(document).ready(function () {
    getandreplaceitem("/Manager/ManagerList", ".item-manager", false);
});

$("#shipmentdestination").click(function () {
    getandreplaceitem("/ShipmentDestination/ShipmentDestinationList", ".item-destination", true);
});
$("#managerbutton").click(function () {
    getandreplaceitem("/Manager/ManagerList", ".item-manager", true);
});
$("#shipmentspecialist").click(function () {
    getandreplaceitem("/ShipmentSpecialist/ShipmentSpecialistList", ".item-specialist", true);
});

$("#managers-button input:last-child").click(function () {
    if (selectedtd != "") {
        $.ajax({
            type: "Get",
            url: "/Manager/ToggleBlock/" + $(selectedtd).attr("id"),
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/Manager/ManagerList", ".item-manager", false);
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });
    }    
});
$("#managers-button input:first-child").click(function () {
    var newManagerName = $(".item-manager>input").val()
    if (newManagerName.length > 2) {
        $.ajax({
            type: "Get",
            url: "/Manager/Create",
            data: { NewManagerName : newManagerName },
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/Manager/ManagerList", ".item-manager", false);
                    $(".item-manager>input").val("");
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });

    }
    
});

$("#destinations-button>input:last-child").click(function () {
    if (selectedtd != "") {
        $.ajax({
            type: "Get",
            url: "/ShipmentDestination/ToggleBlock/" + $(selectedtd).attr("id"),
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/ShipmentDestination/ShipmentDestinationList", ".item-destination", false);
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });
    }
});
$("#destinations-button>input:first-child").click(function () {
    var newDestinationName = $(".item-destination>input").val()
    if (newDestinationName.length > 2) {
        $.ajax({
            type: "Get",
            url: "/ShipmentDestination/Create",
            data: { newDestinationName: newDestinationName },
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/ShipmentDestination/ShipmentDestinationList", ".item-destination", false);
                    $(".item-destination>input").val("");
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });
    }
    else {
        alert("Минимум 2 символа");
    }
});

$("#specialists-button>input:last-child").click(function () {
    if (selectedtd != "") {
        $.ajax({
            type: "Get",
            url: "/ShipmentSpecialist/ToggleBlock/" + $(selectedtd).attr("id"),
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/ShipmentSpecialist/ShipmentSpecialistList", ".item-specialist", false);
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });
    }
});
$("#specialists-button>input:first-child").click(function () {
    var newSpecialistName = $(".item-specialist>input").val()
    if (newSpecialistName.length > 2) {
        $.ajax({
            type: "Get",
            url: "/ShipmentSpecialist/Create",
            data: { newShipmentSpecialist: newSpecialistName },
            success: function (response) {
                if (response == true) {
                    getandreplaceitem("/ShipmentSpecialist/ShipmentSpecialistList", ".item-specialist", false);
                    $(".item-specialist>input").val("");
                }
                else { alert(response) }
            },
            error: function (response) {
                alert(response.responseText + "error");
            },
            failure: function (response) {
                alert("failure");
            }
        });
    }
    else {
        alert("Минимум 2 символа");
    }
});

function sethandlertd(selektor) {
    $(selektor + " td").click(function () {
        if (selectedtd == this) {
            $(this).removeClass("selected-td");
            selectedtd = "";
        }
        else {
            if (!(selectedtd == "")) {
                $(selectedtd).removeClass("selected-td");                
            }
            $(this).addClass("selected-td");
            selectedtd = this;
            changeBlockButton(selektor)
        }        
    });
}

function changeBlockButton(itemSelektor) {
    if ($(selectedtd).hasClass("gray-row")) {
        $(itemSelektor +" div input:last-child").attr("value", "UnBlock")
    }
    else {
        $(itemSelektor + " div input:last-child").attr("value", "Block")
    }    
}

function disablewithout(selektor) {
    $(".grid-level2").find('*').attr("disabled","");
    $(selektor).find('*').removeAttr("disabled");
    $('td').off("click");
    if (selectedtd != "") {
        $(selectedtd).removeClass("selected-td");
    }
}

function getandreplaceitem(url, itemSelector, useDisableWitout) {
    $.ajax({
        type: "GET",
        url: url,

        success: function (response) {
            if (useDisableWitout == true) {
                disablewithout(itemSelector);
            }
            $(itemSelector + " table").replaceWith(response)
            sethandlertd(itemSelector, );
        },
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
}
