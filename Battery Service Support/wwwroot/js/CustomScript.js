﻿// DeleteConfirmation
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

