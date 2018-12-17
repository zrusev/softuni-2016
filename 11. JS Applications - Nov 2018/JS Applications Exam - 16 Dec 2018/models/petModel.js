const petModel = (function () {
  function all() {
    return requesterService.get('appdata', 'pets?query={}&sort={"likes": -1}', 'kinvey');
  }

  function filtered(key) {
    return requesterService.get('appdata', `pets?query={"category": "${key}"}&sort={"likes": -1}`, 'kinvey');
  }
  
  function create(pet) {
    return requesterService.post('appdata', 'pets', 'kinvey', pet);
  }

  function details(id) { 
    return requesterService.get('appdata', 'pets/' + id, 'kinvey');
  }

  function edit(id, pet) {
    return requesterService.update('appdata', 'pets/' + id, 'kinvey', pet);
  }

  function remove(id) {
    return requesterService.remove('appdata', 'pets/' + id, 'kinvey');
  }

  function my(user_id) {
    return requesterService.get('appdata', `pets?query={"_acl.creator":"${user_id}"}`, 'kinvey');
  }

  return {
    all,
    filtered,
    create,
    details,
    edit,
    remove,
    my
  }
})();