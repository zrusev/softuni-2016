const flightModel = (function () {
  function all(isLoggedIn) {
    if (isLoggedIn) {    
      return requesterService.get('appdata', 'flights?query={"isPublished":true}', 'kinvey');
    } else {
      return requesterService.get('appdata', 'flights?query={"isPublished":true}', 'basic');
    }
  }

  function create(flight) {
    return requesterService.post('appdata', 'flights', 'kinvey', flight);
  }

  function details(id) { 
    return requesterService.get('appdata', 'flights/' + id, 'kinvey');
  }

  function edit(id, flight) {
    return requesterService.update('appdata', 'flights/' + id, 'kinvey', flight);
  }

  function remove(id) {
    return requesterService.remove('appdata', 'flights/' + id, 'kinvey');
  }

  function my(user_id) {
    return requesterService.get('appdata', `flights?query={"_acl.creator":"${user_id}"}`, 'kinvey');
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