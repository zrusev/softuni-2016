function attachEvents() {
  $('#getVenues').click(getVenues);

  async function getVenues() {
    $('#venue-info').empty();

    const selectedDate = $('#venueDate').val();
    const serviceUrl = `https://baas.kinvey.com/`;
    const userName = 'guest';
    const userPass = 'pass';

    const venueIds = await $.ajax({
      type: "POST",
      url: serviceUrl + `rpc/kid_BJ_Ke8hZg/custom/calendar?query=${selectedDate}`,
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    });


    Promise.all(venueIds.map((pr) => $.ajax({
        type: "GET",
        url: serviceUrl + `appdata/kid_BJ_Ke8hZg/venues/${pr}`,
        beforeSend: function (xhr) {
          xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
        }
      })))
      .then((data) => {
        data.forEach((venue) => {
          $('#venue-info').append(`<div class="venue" id="${venue._id}">
            <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
            <div class="venue-details" style="display: none;">
              <table>
                <tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>
                <tr>
                  <td class="venue-price">${venue.price} lv</td>
                  <td><select class="quantity">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                  </select></td>
                  <td><input class="purchase" type="button" value="Purchase"></td>
                </tr>
              </table>
              <span class="head">Venue description:</span>
              <p class="description">${venue.description}</p>
              <p class="description">Starting time: ${venue.startingHour}</p>
            </div>
          </div>`)

          $(`#${venue._id} .purchase`).click(function (e) {
            let qty = +$(e.target).parent().prev().children(0)[0].value;

            $('#venue-info').empty();

            $('#venue-info').append(`<span class="head">Confirm purchase</span>`);
            let $div = $('<div>')
              .addClass('purchase-info')
              .append(`<span>${venue.name}</span>
                      <span>${qty} x ${venue.price}</span>
                      <span>Total: ${qty * venue.price} lv</span>`);

            let $button = $('<input type="button" value="Confirm">').on('click', async () => {
              await $.ajax({
                type: "POST",
                url: serviceUrl + `rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${venue._id}&qty=${qty} `,
                beforeSend: function (xhr) {
                  xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
                }
              }).done((data) => {
                $('#venue-info').empty();
                $('#venue-info').html('You may print this page as your ticket' + data.html);
              });
            });

            $div.append($button);
            $('#venue-info').append($div);
          });

          $('.info').each(function () {
            $(this).click(function (e) {
              $('.venue-details').hide();

              $(e.target).parent().next().show();
            });
          });
        });
      });
  }

  function make_base_auth(user, password) {
    var tok = user + ':' + password;
    var hash = btoa(tok);
    return "Basic " + hash;
  }
}