function attachEvents() {
  const userName = 'guest';
  const userPass = 'pass';
  const serviceUrl = 'https://baas.kinvey.com/appdata/kid_HyAiCdTR7/biggestCatches';

  $('#addForm .add').click(async () => {
    let data = {
      angler: $('#addForm .angler').val(),
      weight: +$('#addForm .weight').val(),
      species: $('#addForm .species').val(),
      location: $('#addForm .location').val(),
      bait: $('#addForm .bait').val(),
      captureTime: +$('#addForm .captureTime').val()
    };

    await insertRecord(data);

    $('#addForm input').val('');

    await refresh();
  });

  $('#aside .load').click(refresh);

  async function refresh() {
    $('#catches').empty();

    let all = await loadAll();

    all.forEach((el) => {
      $('#catches').append(
        `<div class="catch" data-id="${el._id}">
        <label>Angler</label>
        <input type="text" class="angler" value="${el.angler}" />
        <label>Weight</label>
        <input type="number" class="weight" value="${el.weight}" />
        <label>Species</label>
        <input type="text" class="species" value="${el.species}" />
        <label>Location</label>
        <input type="text" class="location" value="${el.location}" />
        <label>Bait</label>
        <input type="text" class="bait" value="${el.bait}" />
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${el.captureTime}" />
      </div>`
      )

      $(`div[data-id=${el._id}]`)
        .append($('<button>').addClass('update').text('Update').click(async (a) => {
          let inputs = $(a.target).parent().find('input');
          let data = {
            angler: $(inputs[0]).val(),
            weight: +($(inputs[1]).val()),
            species: $(inputs[2]).val(),
            location: $(inputs[3]).val(),
            bait: $(inputs[4]).val(),
            captureTime: +($(inputs[5]).val())
          }

          await updateRecord(el._id, data);
          await refresh();
        }))
        .append($('<button>').addClass('delete').text('Delete').click(async () => {
          console.log(await deleteRecord(el._id));
          await refresh();
        }));
    })
  }

  function updateRecord(recordId, data) {
    return $.ajax({
      type: "PUT",
      url: serviceUrl + '/' + recordId,
      contentType: 'application/json',
      data: JSON.stringify(data),
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    })
  }

  function deleteRecord(recordId) {
    return $.ajax({
      type: "DELETE",
      url: serviceUrl + '/' + recordId,
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    });
  }

  function loadAll() {
    return $.ajax({
      type: "GET",
      url: serviceUrl,
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    });
  }

  function insertRecord(data) {
    return $.ajax({
      type: "POST",
      url: serviceUrl,
      data: data,
      dataType: 'JSON',
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    });
  }

  function make_base_auth(user, password) {
    var tok = user + ':' + password;
    var hash = btoa(tok);
    return "Basic " + hash;
  }
}