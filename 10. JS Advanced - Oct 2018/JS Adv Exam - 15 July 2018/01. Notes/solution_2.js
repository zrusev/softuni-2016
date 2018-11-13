function addSticker() {
  let title = $('.title-input .title')[0];
  let text = $('.text-input .content')[0];

  if (title.value === '' || text.value === '') {
    return;
  }
  let li = $('<li class="note-content">')
    .append($('<a class="button">x</a>')
      .click(removeSticket))
    .append($(`<h2> ${title.value} </h2>`))
    .append($('<hr>'))
    .append($(`<p> ${text.value} </p>`));

  $('#sticker-list')
    .append(li);

  function removeSticket() {
    this.parentNode.remove()
  }

  title.value = '';
  text.value = '';
}