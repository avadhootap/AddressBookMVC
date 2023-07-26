function AddPerson() {
    window.location.href = '@Url.Action("AddPerson", "Person")';
}

function DeletePerson(id) {
    var Id = id;
    $("#deletePerson").data("personId", Id).dialog("open");
}

function backPerson() {
    window.location.href = '@Url.Action("GetPerson", "Person")'
}

$(document).ready(function () {

    $("#deletePerson").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            "Delete": function () {
                var personId = $(this).data("personId");
                $.ajax({
                    type: "POST",
                    url: "/Person/DeletePerson",
                    data: { personId: personId },
                    success: function (response) {
                        if (response) {
                            location.reload();
                        } else {
                            alert("Failed to Delete Person");
                        }
                    },
                    error: function () {
                        alert("Failed to Delete...");
                    }
                });
                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });
});