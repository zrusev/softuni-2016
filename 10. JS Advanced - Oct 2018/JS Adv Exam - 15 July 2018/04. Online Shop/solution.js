function onlineShop(selector) {
  let form = `<div id="header">Online Shop Inventory</div>
  <div class="block">
      <label class="field">Product details:</label>
      <br>
      <input placeholder="Enter product" class="custom-select">
      <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
      <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
      <button id="submit" class="button" disabled>Submit</button>
      <br><br>
      <label class="field">Inventory:</label>
      <br>
      <ul class="display">
      </ul>
      <br>
      <label class="field">Capacity:</label><input id="capacity" readonly>
      <label class="field">(maximum capacity is 150 items.)</label>
      <br>
      <label class="field">Price:</label><input id="sum" readonly>
      <label class="field">BGN</label>
  </div>`;

  $(selector).html(form);

  //$('#submit')[0].addEventListener('click', submitResult);
  $('#submit').on('click', submitResult);

  $('.custom-select').on('keyup', function () {
    if (this.value.length > 1) {
      $('#submit').prop("disabled", false);
    } else {
      $('#submit').prop("disabled", true);
    }
  });

  let totalPrice = 0;
  let totalQuantity = 0;

  function submitResult() {
    let product = $('.custom-select');
    let price = $('#price');
    let quantity = $('#quantity');

    let result = `Product: ${product.val()} Price: ${price.val()} Quantity: ${quantity.val()}`;

    let li = $('<li>');
    li.text(result);
    $('.display').append(li);

    totalQuantity += Number(quantity.val());
    $('#capacity')[0].value = totalQuantity;

    totalPrice += Number(price.val());
    $('#sum')[0].value = totalPrice;

    if (totalQuantity >= 150) {
      $('#capacity').addClass('fullCapacity');
      $('#capacity').val('full');

      product.prop("disabled", true);
      price.prop("disabled", true);
      quantity.prop("disabled", true);
    }

    $('#submit').prop("disabled", true);
    $('.custom-select').val('');
    $('#price').val(1);
    $('#quantity').val(1);
  }
}