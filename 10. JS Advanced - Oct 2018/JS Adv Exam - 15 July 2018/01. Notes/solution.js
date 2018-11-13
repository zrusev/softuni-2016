function addSticker() {
  let title = document.getElementsByClassName('title')[0];
  let content = document.getElementsByClassName('content')[0];

  if (title.value !== '' && content.value !== '') {
    let sticker = document.createElement('li');
    sticker.className = 'note-content';

    let link = document.createElement('a');
    link.className = 'button';
    link.textContent = 'x';
    link.addEventListener('click', removeSticker);

    let header = document.createElement('h2');
    header.textContent = title.value;

    let line = document.createElement('hr');

    let paragraph = document.createElement('p');
    paragraph.textContent = content.value;

    sticker.appendChild(link);
    sticker.appendChild(header);
    sticker.appendChild(line);
    sticker.appendChild(paragraph);

    let stickers = document.getElementById('sticker-list');
    stickers.appendChild(sticker);

    function removeSticker(e) {
      e.target.removeEventListener('click', removeSticker);
      e.target.parentElement.remove();
    }
  }

  title.value = '';
  content.value = '';
}