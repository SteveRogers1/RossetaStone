$(document).ready(function () {
    $("#tblDictionaries").DataTable({
        "ajax": {
            "url": "/api/Dictionaries",
            "dataSrc": ""
        },
        "columns": [
            {"data": "WordEng" },
            {"data": "WordRus" },
        ]
    });
});
