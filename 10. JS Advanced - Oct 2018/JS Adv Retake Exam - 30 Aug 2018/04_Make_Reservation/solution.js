function makeReservation() {
  let $container = $(arguments[0]);

  $('#submit').on('click', function (e) {
    addItem(e)
  });

  function addItem(e) {
    e.preventDefault();
    e.stopPropagation();

    let $fullName = $('#fullName');
    let $email = $('#email');
    let $phoneNumber = $('#phoneNumber');
    let $address = $('#address');
    let $postalCode = $('#postalCode');

    if ($fullName.val() !== '' && $email.val() !== '') {
      $('#infoPreview')
        .append(`<li>Name: ${$fullName.val()}</li>`)
        .append(`<li>E-mail: ${$email.val()}</li>`);

      $phoneNumber.val() === '' || $('#infoPreview').append(`<li>Phone: ${$phoneNumber.val()}</li>`);
      $address.val() === '' || $('#infoPreview').append(`<li>Address: ${$address.val()}</li>`);
      $postalCode.val() === '' || $('#infoPreview').append(`<li>Postal Code: ${$postalCode.val()}</li>`);

      $fullName.val('');
      $email.val('');
      $phoneNumber.val('');
      $address.val('');
      $postalCode.val('');

      $('#submit').attr('disabled', true);

      $('#edit').attr('disabled', false);
      $('#continue').attr('disabled', false);

      $('#edit').on('click', function (e) {
        editInput(e);
      });

      $('#continue').on('click', function (e) {
        continueExecution(e);
      });
    }
  }

  function continueExecution(e) {
    e.preventDefault();
    e.stopPropagation();
    e.stopImmediatePropagation();

    $('#submit').attr('disabled', true);
    $('#edit').attr('disabled', true);
    $('#continue').attr('disabled', true);

    $container.append('<h2>Payment details</h2>');
    let $select = $('<select>')
      .attr('id', 'paymentOptions')
      .addClass('custom-select')
      .append('<option selected disabled hidden>Choose</option>')
      .append('<option value="creditCard">Credit Card</option>')
      .append('<option value="bankTransfer">Bank Transfer</option>');

    $container.append($select);

    $container.append('<div id="extraDetails"></div>');

    $('#paymentOptions').on('change', function (e) {
      e.preventDefault();
      e.stopPropagation();

      $('#extraDetails').children().remove();

      if ($(this).val() === 'creditCard') {
        $('#extraDetails')
          .append('<div class="inputLabel">Card Number<input></div><br>')
          .append('<div class="inputLabel">Expiration Date<input></div><br>')
          .append('<div class="inputLabel">Security Numbers<input></div><br>');
      } else if ($(this).val() === 'bankTransfer') {
        $('#extraDetails')
          .append('<p>You have 48 hours to transfer the amount to:<br>IBAN: GR96 0810 0010 0000 0123 4567 890</p>');
      }

      let $submitButton = $('<button>')
        .attr('id', 'checkOut')
        .text('Check Out')
        .on('click', function (e) {
          e.preventDefault();
          e.stopPropagation();

          $('#wrapper').children().remove();
          $('#wrapper').append('<h4>Thank you for your reservation!</h4>');
        });

      $('#extraDetails').append($submitButton);
    });
  }

  function editInput(e) {
    e.preventDefault();
    e.stopPropagation();

    $('#infoPreview li').toArray().forEach((el) => {
      let indexOfColon = $(el).text().indexOf(':');
      let text = $(el).text().substring(indexOfColon + 2);
      let selector = $(el).text().substring(0, indexOfColon);

      switch (selector) {
        case 'Name':
          $('#fullName').val(text);
          break;
        case 'E-mail':
          $('#email').val(text);
          break;
        case 'Phone':
          $('#phoneNumber').val(text);
          break;
        case 'Address':
          $('#address').val(text);
          break;
        case 'Postal Code':
          $('#postalCode').val(text);
          break;
      }
    })

    $('#infoPreview li').remove();
    $('#submit').attr('disabled', false);

    $('#edit').attr('disabled', true);
    $('#continue').attr('disabled', true);
  }
}