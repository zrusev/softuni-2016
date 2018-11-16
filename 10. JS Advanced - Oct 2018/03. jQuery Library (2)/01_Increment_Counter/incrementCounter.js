function increment() {
  let $selector = $(arguments[0]);

  $selector.append(`<textarea class="counter" disabled>0</textarea>`);

  let $button = $(`<button class="btn" id="incrementBtn">Increment</button>`).on('click', (e) => {
    // e.preventDefault();
    // e.stopPropagation();

    let $text = $(e.target).prev();
    $text.val(Number($text.val()) + 1);
  });
  $selector.append($button);

  let $button2 = $(`<button class="btn" id="addBtn">Add</button>`).on('click', (e) => {
    // e.preventDefault();
    // e.stopPropagation();

    let $text = $(e.target).prev().prev().val();

    $(e.target).next().append(`<li>${$text}</li>`);
  });
  $selector.append($button2);

  $selector.append(`<ul class="results"></ul>`);
}