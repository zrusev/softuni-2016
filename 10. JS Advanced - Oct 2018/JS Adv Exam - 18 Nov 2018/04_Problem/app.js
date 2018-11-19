function realEstateAgency() {
	$('#findOffer button').on('click', () => {
		let $budget = $('#findOffer').children()[1];
		let $type = $('#findOffer').children()[2];
		let $name = $('#findOffer').children()[3];

		if (+$budget.value > 0 && $type.value !== '' && $name.value !== '') {
			let foundIndex = -1;

			$('.apartment').toArray().forEach((el, ind) => {
				let appPrice = $(el).children()[2].textContent.match(/\d+/g);
				if (($(el).html()).includes(`Type: ${$type.value}`) && +$budget.value >= +appPrice[0]) {
					let $element = $('.apartment').toArray()[ind];
					
					$($element).children('p').remove();
					$($element)
						.append(`<p>${$name.value}</p>`)
						.append(`<p>live here now</p>`);

					let $moveOutButton = $('<button>').text('MoveOut');
					$moveOutButton.on('click', (e) => {
						let familyName = e.target.previousSibling.previousSibling.textContent;
						$('#message').text(`They had found cockroaches in ${familyName}\'s apartment`);
						
						e.target.parentElement.remove();
					});

					$($element).append($moveOutButton);

					$($element).css('style', 'border: 2px solid red;');
					foundIndex = ind;

					$('#message').text('Enjoy your new home! :))');
				}
			})

			if (foundIndex === -1) {
				$('#message').text('We were unable to find you a home, so sorry :(');
			}
		}

		$budget.value = '';
		$type.value = '';
		$name.value = '';
	});

	$('#regOffer button').on('click', () => {
		let $price = $('#regOffer').children()[1];
		let $type = $('#regOffer').children()[2];
		let $rate = $('#regOffer').children()[3];

		let message = '';

		if (Number.isInteger(+$price.value) &&
			Number.isInteger(+$rate.value) &&
			$type.value !== '' &&
			+$price.value > 0 &&
			+$rate.value >= 0 &&
			+$rate.value <= 100 &&
			!$type.value.includes(':')) {
			$('#message').text('Your offer was created successfully.');

			let $app = $('<div>')
				.addClass('apartment')
				.append(`<p>Rent: ${$price.value}</p>`)
				.append(`<p>Type: ${	$type.value}</p>`)
				.append(`<p>Commission: ${$rate.value}</p>`);

			$('#building').append($app);
		} else {
			$('#message').text('Your offer registration went wrong, try again.');
		}

		$price.value = '';
		$rate.value = '';
		$type.value = '';
	});
}