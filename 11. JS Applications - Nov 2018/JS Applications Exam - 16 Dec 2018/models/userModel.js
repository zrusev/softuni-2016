const userModel = (() => {
  function postRegister(userN, userP) {
    return authService.register(userN, userP);
  }

  function postLogin(userN, userP) {
    return authService.login(userN, userP);
  }

  return {
    postRegister,
    postLogin
  }
})();