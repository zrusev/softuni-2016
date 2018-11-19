function acceptance() {
	let $company = $('#fields input')[0];
	let $product = $('#fields input')[1];
	let $quantity = $('#fields input')[2];
	let $scrape = $('#fields input')[3];

	if (typeof $company.value === 'string' &&
		typeof $product.value === 'string' &&
		$company.value !== '' &&
		$product.value !== '' &&
		Number.isInteger(+$quantity.value) &&
		Number.isInteger(+$scrape.value)) {

		if (+$quantity.value > 0 && +$quantity.value > 0 && +$quantity.value >= +$scrape.value) {
			let qResult = $quantity.value - $scrape.value;
			if (qResult > 0) {
				let $para = $(`<p>[${$company.value}] ${$product.value} - ${qResult} pieces</p>`);
				let $div = $('<div>');
				let $button = $('<button>').on('click', function (e) {
					addToList(e);
				}).text('Out of stock');

				$div.append($para).append($button);
				$('#warehouse').append($div);
			}
		}
	}

	$company.value = '';
	$product.value = '';
	$quantity.value = '';
	$scrape.value = '';

	function addToList(e) {
		$(e.target).parent().remove();
	}
}