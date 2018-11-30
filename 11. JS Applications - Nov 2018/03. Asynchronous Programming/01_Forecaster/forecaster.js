function attachEvents() {
  $('#submit').on('click', async () => {

    $('#current').children().slice(1).remove();
    $('#upcoming').children().slice(1).remove();
    $('#forecast').hide();

    let $location = $('#location');
    let locationCode = await getLocationCodeAsync($location);

    let locCode;
    try {
      locCode = locationCode[0].code;
    } catch (error) {
      $('#forecast').show();
      $('#forecast').text('Error');
      console.log(error);
    }

    let current = await getAsync(`https://judgetests.firebaseio.com/forecast/today/${locCode}.json`);

    $('#forecast').show();
    $('#current').append(`<span class="condition symbol">${returnPicture(current.forecast["condition"])}</span>`);
    let $span = $('<span>').addClass('condition');
    $span.append(`<span class="forecast-data">${current.name}</span>`)
      .append(`<span class="forecast-data">${current.forecast["low"]}&#176;/${current.forecast["high"]}&#176;</span>`)
      .append(`<span class="forecast-data">${current.forecast["condition"]}</span>`);
    $('#current').append($span);

    let upcoming = await getAsync(`https://judgetests.firebaseio.com/forecast/upcoming/${locCode}.json`);

    upcoming.forecast.forEach((el) => {
      let $general = $('<span>')
        .addClass('upcoming')
        .append(`<span class="symbol">${returnPicture(el["condition"])}</span>`)
        .append(`<span class="forecast-data">${el["low"]}&#176;/${el["high"]}&#176;</span>`)
        .append(`<span class="forecast-data">${el["condition"]}</span>`);

      $('#upcoming').append($general);
    })

    function returnPicture(cond) {
      switch (cond.toLowerCase()) {
        case "sunny":
          return '&#x2600;';
        case "partly sunny":
          return '&#x26C5;';
        case "overcast":
          return '&#x2601;';
        case "rain":
          return '&#x2614;';
        case "degrees":
          return '&#176;';
      }
    }

    function getLocationCodeAsync(loc) {
      return new Promise(function (resolve) {
        $.ajax({
            url: 'https://judgetests.firebaseio.com/locations.json'
          })
          .done((res) => {
            let code = res.filter((el) => el.name === loc.val());
            resolve(code);
          });
      });
    }

    function getAsync(address) {
      return new Promise(function (resolve) {
        $.ajax({
            url: address
          })
          .done((res) => {
            resolve(res);
          });
      })
    }
  });
}