// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function isFormValid($form) {
	validateForm($form);

	return $form.valid();
}

function validateForm($form) {
	$.validator.unobtrusive.parse($form);
	$form.validate();

	var validator = $form.validate()
	validator.errorList
}


$(document).on('click', '.btn-submit', function () {
	if ($(this).prop('disabled')) return;

	$form = $($(this).closest('form'));

	$.each($form.find('input, textarea'), function (index, element) {
		$(element).val($(element).val().trim());
	});

	let formData = new FormData($(this).closest('form')[0])

	if (isFormValid($form)) {
		$.ajax({
			method: 'post',
			url: $form.attr('action'),
			data: formData,
			processData: false,
			contentType: false,
			cache: false,
			enctype: 'multipart/form-data',
			beforeSend: function () {
				$('#loading').removeClass('d-none');
			},
			success: function (response) {
				$.alert('Succeeded', {
					type: 'success',
					position: ['bottom-left'],
					closeTime: 3000,
				});
			},
			error: function (error) {
				console.log(error);

				$.alert(error.responseJSON.Message, {
					type: 'danger',
					position: ['bottom-left'],
					closeTime: 3000,
				});
			},
			complete: function () {
				$('#loading').addClass('d-none');
			}
		});
	}
});