(function knock() {
  const userName = 'guest';
  const userPass = 'guest';
  const serviceUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock";

  let currentMessage = "Knock Knock.";
  getMessage();

  function getMessage() {
    $.ajax({
      type: "GET",
      url: serviceUrl + `?query=${currentMessage}`,
      beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', make_base_auth(userName, userPass));
      }
    }).then((res) => {
      console.log(currentMessage);
      console.log(res.answer);

      if (res.message === undefined) {
        console.log('---END---');

        return;
      }

      currentMessage = res.message;
      getMessage();
    });

    return this;
  }

  function make_base_auth(user, password) {
    var tok = user + ':' + password;
    var hash = btoa(tok);
    return "Basic " + hash;
  }
})()