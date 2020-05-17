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

//Make table row clickable
$(function () {
	$('.table tr[data-href]').each(function () {
		$(this).css('cursor', 'pointer').hover(
			function () {
				$(this).addClass('active');
			},
			function () {
				$(this).removeClass('active');
			}).click(function () {
				document.location = $(this).attr('data-href');
			}
			);
	});
});


//Find element with id="datetrigger" and add class="alert-danger" when date is older then 3 years
$(function () {
	$('#datetrigger').each(function () {
		let objDate = new Date($(this).html);
		let dateNow = new Date();
		if (dateNow.getFullYear() - objDate.getFullYear() > 3) {
			$(this).parrent('tr').addClass('alert-danger');
		}
	})
})