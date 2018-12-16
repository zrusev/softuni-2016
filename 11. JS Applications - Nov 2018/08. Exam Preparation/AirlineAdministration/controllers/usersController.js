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
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
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

      if (userN.length < 5) {
        drawerService.showError('Username should should be at least 5 characters long!')
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
    } else {
      this.redirect('#/');
      drawerService.showError('Please log out and register again!');
    }
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

    //security check
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

      userModel.postLogin(userN, userP)
        .then((res) => {
          authService.saveSession(res);
          let url = this.target.baseURI.indexOf("?ReturnUrl=") === -1 
            ? '' 
            : this.target.baseURI.split('%2F')[1];
          this.redirect('#/' + url);
          drawerService.showInfo('Successfully logged in!');
        })
        .catch((err) => drawerService.handleError(err));
    } else {
      this.redirect('#/');
      drawerService.showError('You are already logged in!');
    }
  }

  function getLogout() {
    contextService.ctxHandler(this);
    
    //security check
    if (!this.loggedIn) {
      drawerService.showError('You have already logged out!');
      return;
    }
    
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