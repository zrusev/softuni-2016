function attachEventsListeners() {
  document.getElementById('daysBtn').addEventListener('click', converter);
  document.getElementById('hoursBtn').addEventListener('click', converter);
  document.getElementById('minutesBtn').addEventListener('click', converter);
  document.getElementById('secondsBtn').addEventListener('click', converter);

  function converter(e) {
    let inputVal;
    switch (e.target.id) {
      case 'daysBtn':
        inputVal = +document.getElementById('days').value;
        document.getElementById('hours').value = inputVal * 24;
        document.getElementById('minutes').value = inputVal * 24 * 60;
        document.getElementById('seconds').value = inputVal * 24 * 60 * 60;
        break;
      case 'hoursBtn':
        inputVal = +document.getElementById('hours').value;
        document.getElementById('days').value = inputVal / 24;
        document.getElementById('minutes').value = inputVal * 60;
        document.getElementById('seconds').value = inputVal * 60 * 60;
        break;
      case 'minutesBtn':
        inputVal = +document.getElementById('minutes').value;
        document.getElementById('days').value = inputVal / 60 / 24;
        document.getElementById('hours').value = inputVal / 60;
        document.getElementById('seconds').value = inputVal * 60;
        break;

      case 'secondsBtn':
        inputVal = +document.getElementById('seconds').value;
        document.getElementById('days').value = inputVal / 60 / 60 / 24;
        document.getElementById('hours').value = inputVal / 60 / 60;
        document.getElementById('minutes').value = inputVal / 60;
        break;
    }
  }
}