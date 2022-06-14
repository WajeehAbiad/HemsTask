$(document).ready(function () {
	$(document).on('click', '.toggle-category-form-visbility', function () {
		$createCategory = $('#createCategory');
		$createCategory.toggleClass('d-none');
		if ($createCategory.attr('class').split(/\s+/).indexOf('d-none') > -1) {
			$(this).val('Add category');
			$(this).toggleClass('btn-success btn-danger');
		} else {
			$(this).val('Delete category');
			$(this).toggleClass('btn-success btn-danger');
		}
	});

	$(document).on('click', '.toggle-type-form-visbility', function () {
		$createType = $('#createType');
		$createType.toggleClass('d-none');
		if ($createType.attr('class').split(/\s+/).indexOf('d-none') > -1) {
			$(this).val('Add type');
			$(this).toggleClass('btn-success btn-danger');
		} else {
			$(this).val('Delete type');
			$(this).toggleClass('btn-success btn-danger');
		}
	});

	$(document).on('click', '.toggle-product-form-visbility', function () {
		$createProduct = $('#createProduct');
		$createProduct.toggleClass('d-none');
		if ($createProduct.attr('class').split(/\s+/).indexOf('d-none') > -1) {
			$(this).val('Add product');
			$(this).toggleClass('btn-success btn-danger');
		} else {
			$(this).val('Delete product');
			$(this).toggleClass('btn-success btn-danger');
		}
	});

	$(document).on('click', '.btn-cus-submit', function () {
		if ($(this).prop('disabled')) return;

		$form = $($(this).closest('form'));

		$.each($form.find('input, textarea'), function (index, element) {
			$(element).val($(element).val().trim());
		});

		let formData = new FormData();

		for (var pair of (new FormData($(this).closest('form')[0])).entries()) {
			formData.append(pair[0].split('.')[1], pair[1].trim())
		}

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
});