$(document).ready(function () {
    $("#tblDictionaries").DataTable({
        "ajax": {
            "url": "/api/Dictionaries",
            "dataSrc": ""
        },
        "columns": [
            {"data": "WordEng" },
            {"data": "WordRus" },
            {
               "data": "id", "render": function (data, type, row, meta) {
                    return "<button class ='btn btn-primary' style='margin-right:5px;' onclick='Edit(" + JSON.stringify(row) + ")'>Edit</button>" +
                        "<button class ='btn btn-danger' onclick='Delete(" + JSON.stringify(row) + ")'>Delete</button>";
                }
            },
        ]
    });

    $("#btnSave").click(function () {
        var dictionary = {
            DictionaryId: $("#txtDictionaryId").val(),
            WordEng: $("#txtWordEng").val(),
            WordRus: $("#txtWordRus").val()
        };

        $.post("api/Dictionaries", { dictionary: dictionary })
            .done(function (data) {
                Reset();
                ReloadGrid();
                alert("saved");              
            });
    });

    $("#btnAddNew").click(function () {
        Reset();
    });
});
function Edit(oDictionary) {
    $("#txtDictionaryId").val(oDictionary.DictionaryId);
    $("#txtWordEng").val(oDictionary.WordEng);
    $("#txtWordRus").val(oDictionary.WordRus);
}
function Delete(oDictionary) {
    $.ajax({
        url: "api/Dictionaries/" + oDictionary.DictionaryId,
        type: "DELETE",
        success: function (result) {
            alert("Deleted");
            ReloadGrid();
        }
    });
}
function Reset() {
    $("#txtDictionaryId").val(0);
    $("#txtWordEng").val("");
    $("#txtWordRus").val("");
}
function ReloadGrid() {
    $("#tblDictionaries").DataTable().clear();
    $("#tblDictionaries").DataTable().ajax.reload();
}