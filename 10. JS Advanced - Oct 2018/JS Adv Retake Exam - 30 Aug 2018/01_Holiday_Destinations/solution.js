function addDestination() {
  let $city = $('.inputData')[0];
  let $country = $('.inputData')[1];
  let $selectedSeason = $('#seasons :selected');

  if ($city.value !== '' && $country.value !== '') {
    let $list = $('#destinationsList');
    let $row = $('<tr>').append(`<td>${$city.value}, ${$country.value}</td><td>${$selectedSeason.text()}</td>`);
    $list.append($row);

    let $counter = $(`#${$selectedSeason.text().toLowerCase()}`);
    $counter.val(+$counter.val() + 1);
  }

  $city.value = '';
  $country.value = '';
  debugger;
  $('#seasons')[0].selectedIndex = 0;
}