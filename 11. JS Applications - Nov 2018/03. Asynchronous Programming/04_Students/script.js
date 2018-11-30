(async function attachEvents() {
  const userName = 'guest';
  const userPass = 'guest';
  const serviceUrl = 'https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students';

  let all = await loadAll();
  let sorted = all.sort((a,b) => { return a.ID - b.ID });

  sorted.forEach((el) => {
    $('#results tbody')
      .append(`<tr>
        <th>${el.ID}</th>
        <th>${el.FirstName}</th>
        <th>${el.LastName}</th>
        <th>${el.FacultyNumber}</th>
        <th>${el.Grade}</th>
        </tr>`)
  });

  function loadAll() {
    return $.ajax({
      type: "GET",
      url: serviceUrl,
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
})()