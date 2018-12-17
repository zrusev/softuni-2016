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
  
      if (userN === '') {
        drawerService.showError('Username cannot be blank!')
        return;
      }

      if (userP === '') {
        drawerService.showError('Password field cannot be blank!')
        return;
      }

      if (userN.length < 3) {
        drawerService.showError('Username must be at least 3 symbols!')
        return;
      }

      if (userP.length < 6) {
        drawerService.showError('Password must be at least 6 symbols!')
        return;
      }

      userModel.postRegister(userN, userP)
        .then((res) => {
          authService.saveSession(res);
          this.redirect('#/listing');
          drawerService.showInfo('User registration successful.');
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

      if (userN.length < 3) {
        drawerService.showError('Username must be at least 3 symbols!')
        return;
      }

      if (userP.length < 6) {
        drawerService.showError('Password must be at least 6 symbols!')
        return;
      }

      userModel.postLogin(userN, userP)
        .then((res) => {
          authService.saveSession(res);
          let url = this.target.baseURI.indexOf("?ReturnUrl=") === -1 
            ? 'listing' 
            : this.target.baseURI.split('%2F')[1];
          this.redirect('#/' + url);
          drawerService.showInfo('Login successful.');
        })
        .catch(() => drawerService.showError('Wrong username or password!'));
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
        drawerService.showInfo('Logout successful.');
        this.redirect('#/');
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