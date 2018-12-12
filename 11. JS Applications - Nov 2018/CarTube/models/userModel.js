const userModel = (() => {
  function postRegister(userN, userP, userP2) {
    return authService.register(userN, userP, userP2);
  }

  function postLogin(userN, userP) {
    return authService.login(userN, userP);
  }

  return {
    postRegister,
    postLogin
  }
})();