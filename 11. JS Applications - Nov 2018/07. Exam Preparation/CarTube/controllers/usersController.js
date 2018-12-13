const usersController = (() => {
  function getRegister() {
    contextService.loadCommon(this)
      .then(function () {
        this.loadPartials({
          registerForm: './views/register/registerForm.hbs',
          validatorForm: './views/common/validatorForm.hbs'
        });
      })
      .then(function () {
        this.partial('./views/register/registerPage.hbs');
      });
  }

  function postRegister() {
    let userN = this.params.username;
    let userP = this.params.password;
    let userP2 = this.params.repeatPass;

    if (userN === '') {
      drawerService.showError('Username cannot be blank!')
      return;
    }

    if (userP === '' || userP2 === '') {
      drawerService.showError('Password field cannot be blank!')
      return;
    }

    if (userN.length < 3) {
      drawerService.showError('Username should should be at least 3 characters long!')
      return;
    }

    if (!/^[a-zA-Z]*$/g.test(userN)) {
      drawerService.showError('Username should contain only english alphabet letters!')
      return;
    }

    if (userP.length < 6) {
      drawerService.showError('Password should be at least 6 characters long !')
      return;
    }

    if (userP.search(/\d/) == -1) {
      drawerService.showError('Password should contain at least one digit!')
      return;
    }

    if (userP.search(/[a-zA-Z]/) == -1) {
      drawerService.showError('Password should contain at least one letter!')
      return;
    }

    if (userP !== userP2) {
      drawerService.showError('Passwords missmatch!')
      return;
    }

    userModel.postRegister(userN, userP, userP2)
      .then((res) => {
        authService.saveSession(res);
        this.redirect('#/');
        drawerService.showInfo(`${userN}, you have registered successfully!`);
      })
      .catch((err) => drawerService.handleError(err));
  }

  function getLogin() {
    contextService.loadCommon(this)
      .then(function () {
        this.loadPartials({
          loginForm: './views/login/loginForm.hbs',
          validatorForm: './views/common/validatorForm.hbs'
        });
      })
      .then(function () {
        this.partial('./views/login/loginPage.hbs');
      });
  }

  function postLogin() {
    contextService.ctxHandler(this);

    if (!this.loggedIn) {
      let userN = this.params.username;
      let userP = this.params.password;

      if (userN === '') {
        drawerService.showError('Username cannot be blank!')
        return;
      }

      if (userP === '') {
        drawerService.showError('Password field cannot be blank!')
        return;
      }

      if (userN.length < 3) {
        drawerService.showError('Username should should be at least 3 characters long!')
        return;
      }

      if (!/^[a-zA-Z]*$/g.test(userN)) {
        drawerService.showError('Username should contain only english alphabet letters!')
        return;
      }

      if (userP.length < 6) {
        drawerService.showError('Password should be at least 6 characters long !')
        return;
      }

      if (userP.search(/\d/) == -1) {
        drawerService.showError('Password should contain at least one digit!')
        return;
      }

      if (userP.search(/[a-zA-Z]/) == -1) {
        drawerService.showError('Password should contain at least one letter!')
        return;
      }

      userModel.postLogin(userN, userP)
        .then((res) => {
          authService.saveSession(res);
          this.redirect('#/');
          drawerService.showInfo('Successfully logged in!');
        })
        .catch((err) => drawerService.handleError(err));
    } else {
      this.redirect('#/');
      drawerService.showError('You are already logged in!');
    }
  }

  function getLogout() {
    authService.logout()
      .then(() => {
        sessionStorage.clear();
        this.redirect('#/');
        drawerService.showInfo('Successfully logged out!');
      })
      .catch((err) => drawerService.handleError(err));
  }

  return {
    getRegister,
    postRegister,
    getLogin,
    postLogin,
    getLogout
  }
})();