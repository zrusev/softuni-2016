function increment(selector) {
  let container = $(selector);
  let fragment = document.createDocumentFragment();
  let textArea = $('<textarea>');
  let incremetBtn = $('<button>Increment</button>');
  let addBtn = $('<button>Add</button>');
  let list = $('<ul>');

  textArea.val(0);
  textArea.addClass('counter');
  textArea.attr('disabled', true);

  incremetBtn.addClass('btn');
  incremetBtn.attr('id', 'incrementBtn');
  addBtn.addClass('btn');
  addBtn.attr('id', 'addBtn');

  list.addClass('results');

  $(incremetBtn).on('click', function() {
    textArea.val(+textArea.val() + 1);
  })

  $(addBtn).on('click', function() {
    let li = $(`<li>${textArea.val()}</li>`);
    li.appendTo(list);
  })

  textArea.appendTo(fragment);
  incremetBtn.appendTo(fragment);
  addBtn.appendTo(fragment);
  list.appendTo(fragment);
  
  container.append(fragment);
}
