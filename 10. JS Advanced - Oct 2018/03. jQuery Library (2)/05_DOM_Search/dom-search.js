function domSearch() {
  let $selector = $(arguments[0]);
  let isCaseSensitive = arguments[1];

  //Enter text
  let $add = $('<div>');
  $add.addClass('add-controls');

  let $addButton = $('<a class="button" style="display: inline-block;">Add</a>');
  $addButton.on("click", function (e) {
    addToList(e);
  });

  let $textInput = $('<label>').text('Enter text: ').append('<input>');
  $add.append($textInput);
  $add.append($addButton);

  $selector.append($add);

  //Search text
  let $search = $('<div>');
  $search.addClass('search-controls');

  let $searchInput = $('<label>').text('Search: ');

  let $input = $('<input>').on('keyup', function () {
    searchList();
  });

  $searchInput.append($input);
  $search.append($searchInput);

  $selector.append($search);

  //Create list
  let $result = $("<div>");
  $result.addClass('result-controls');

  let $list = $("<ul>");
  $list.addClass('items-list');

  $result.append($list);

  $selector.append($result);


  function addToList(e) {
    e.preventDefault();
    e.stopPropagation();

    let text = ($('input')[0]).value;

    let $li = $('<li>');
    $li.addClass('list-item');

    let $anchor = $('<a>')
      .addClass('button')
      .text('X')
      .on('click', function (e) {
        deleteElement(e);
      });


    $li.append($anchor);
    $li.append(`<strong>${text}</strong>`);

    $('.items-list').append($li);

  }

  function deleteElement(e) {
    e.preventDefault();
    e.stopPropagation();

    $(e.target).parent().remove()
  }

  function searchList() {
    let text = isCaseSensitive ? $('input')[1].value : $('input')[1].value.toLowerCase();

    $('li strong').filter((index, el) => {
        return isCaseSensitive ? el.textContent.indexOf(text) > -1 : el.textContent.toLowerCase().indexOf(text) > -1;
      })
      .parent().css("display", "block");

    $('li strong').filter((index, el) => {
        return isCaseSensitive ? el.textContent.indexOf(text) === -1 : el.textContent.toLowerCase().indexOf(text) === -1;
      })
      .parent().css("display", "none");
  }
}