// DeleteConfirmation
function confirmDelete(id, isDeleteClicked) {
    let deleteSpan = "deleteSpan_" + id;
    let confirmDeleteSpan = "confirmDeleteSpan_" + id;

    if (isDeleteClicked) {
        $("#" + deleteSpan).hide();
        $("#" + confirmDeleteSpan).show();
    } else {
        $("#" + deleteSpan).show();
        $("#" + confirmDeleteSpan).hide();
    }
}

// Datepicker
$('#datepicker').datepicker({
    format: "dd/mm/yyyy",
    clearBtn: true,
    autoclose: true,
    language: "nl-BE"
});
