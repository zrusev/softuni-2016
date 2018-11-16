function createBook() {
  let $selector = $(arguments[0]);
  let title = arguments[1];
  let author = arguments[2];
  let isbn = +arguments[3];

  let currentNumber = $('#wrapper div').length + 1;
  let bookId = "book" + currentNumber;

  $selector.append(`<div id="${bookId}" style="border: medium none;">
  <p class="title">${title}</p>
  <p class="author">${author}</p>
  <p class="isbn">${isbn}</p>
  <button>Select</button>
  <button>Deselect</button>
  </div>`);

  $($(`#${bookId} button`)[0]).on('click', ()=> {
    $(`#${bookId}`).css('border', '2px solid blue');
  });

  $($(`#${bookId} button`)[1]).on('click', ()=> {
    $(`#${bookId}`).css('border', 'none');
  });
}