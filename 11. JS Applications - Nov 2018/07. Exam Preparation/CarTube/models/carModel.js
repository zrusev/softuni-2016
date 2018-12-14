const carModel = (function () {
  function all() {
    return requesterService.get('appdata', 'cars?query={}&sort={"_kmd.ect": -1}', 'kinvey');
  }

  function create(car) {
    return requesterService.post('appdata', 'cars', 'kinvey', car);
  }

  function details(id) { 
    return requesterService.get('appdata', 'cars/' + id, 'kinvey');
  }

  function edit(id, car) {
    return requesterService.update('appdata', 'cars/' + id, 'kinvey', car);
  }

  function remove(id) {
    return requesterService.remove('appdata', 'cars/' + id, 'kinvey');
  }

  function my(username) {
    return requesterService.get('appdata', `cars?query={"seller":"${username}"}&sort={"_kmd.ect": -1}`, 'kinvey');
  }

  return {
    all,
    create,
    details,
    edit,
    remove,
    my
  }
})();