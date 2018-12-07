let routes = (() => {
  function ctxHandler(ctx) {
    ctx.loggedIn = sessionStorage.getItem('userId') !== null;
    ctx.username = sessionStorage.getItem('username');
    ctx.teamId = sessionStorage.getItem('teamId');
  }

  function homeRoute(ctx) {
    ctxHandler(ctx);

    this.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs'
    }).then(function () {
      this.partial('./templates/home/home.hbs');
    });
  }

  function aboutRoute(ctx) {
    ctxHandler(ctx);

    this.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs'
    }).then(function () {
      this.partial('./templates/about/about.hbs');
    });
  }

  function loginRoute() {
    this.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs',
      loginForm: './templates/login/loginForm.hbs'
    }).then(function () {
      this.partial('./templates/login/loginPage.hbs');
    });
  }

  function loginRoutePost(ctx) {
    ctxHandler(ctx);

    if (!ctx.loggedIn) {
      let userN = this.params.username;
      let userP = this.params.password;

      if (userN === '') {
        auth.showError('Username cannot be blank!')
        this.redirect('#/login');
        return;
      }

      if (userP === '') {
        auth.showError('Password cannot be blank!')
        this.redirect('#/login');
        return;
      }

      auth.login(userN, userP)
        .then((res) => {
          auth.saveSession(res);
          this.redirect('#/home');
          auth.showInfo('Successfully logged in!');
        })
        .catch((err) => auth.handleError(err));
    } else {
      auth.showError('You are already logged in!')
      this.redirect('#/home');
    }
  }

  function logoutRoutePost() {
    auth.logout()
      .then(() => {
        sessionStorage.clear();
        this.redirect('#/home');
        auth.showInfo('Successfully logged out!');
      })
      .catch((err) => auth.handleError(err));

  }

  function registerRoute() {
    this.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs',
      registerForm: './templates/register/registerForm.hbs'
    }).then(function () {
      this.partial('./templates/register/registerPage.hbs');
    });
  }

  function registerRoutePost() {
    let userN = this.params.username;
    let userP = this.params.password;
    let userP2 = this.params.repeatPassword;

    if (userN === '') {
      auth.showError('Username cannot be blank!')
      this.redirect('#/register');
      return;
    }

    if (userN.length < 4 || userN.length > 10) {
      auth.showError('Username should be between 4 and 10 symbols!')
      this.redirect('#/register');
      return;
    }

    if (userP === '' || userP2 === '') {
      auth.showError('Password field cannot be blank!')
      this.redirect('#/register');
      return;
    }

    if (userP !== userP2) {
      auth.showError('Passwords missmatch!')
      this.redirect('#/register');
      return;
    }

    auth.register(userN, userP, userP2)
      .then((result) => {
        auth.saveSession(result);
        this.redirect('#/home');
        auth.showInfo(`${userN}, you have registered successfully!`);
      })
      .catch((err) => auth.handleError(err));
  }

  function catalogRoute(ctx) {
    ctxHandler(ctx);

    if (ctx.loggedIn) {
      ctx.hasNoTeam = ctx.teamId === "undefined";

      teamsService.loadTeams()
        .then((res) => {
          ctx.teams = res.reverse();

          this.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            team: './templates/catalog/team.hbs'
          }).then(function () {
            this.partial('./templates/catalog/teamCatalog.hbs');
          });
        })
        .catch((err) => auth.handleError(err));
    } else {
      auth.showError('You need to log in first!');
      this.redirect('#/login');
    }
  }

  function catalogRouteById(ctx) {
    ctxHandler(ctx);

    if (ctx.loggedIn) {
      teamsService.loadUsers()
        .then((res) => {
          let allUsers = res;

          teamsService.loadTeamDetails(this.params.id.substring(1))
            .then((res) => {
              ctx.name = res.name;
              ctx.comment = res.comment;
              ctx.isAuthor = sessionStorage.getItem('userId') === res._acl.creator;
              ctx.isOnTeam = ctx.teamId !== "undefined";

              ctx.teamId = res._id;

              ctx.members = allUsers.filter((key) => key.teamId === ctx.teamId);

              this.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                teamMember: './templates/catalog/teamMember.hbs',
                teamControls: './templates/catalog/teamControls.hbs'
              }).then(function () {
                this.partial('./templates/catalog/details.hbs');
              });
            })
            .catch((err) => auth.showError(err));
        })
        .catch((err) => auth.showError(err));
    } else {
      auth.showError('You need to log in first!');
      this.redirect('#/login');
    }
  }

  function joinRouteById(ctx) {
    ctxHandler(ctx);

    teamsService.joinTeam(this.params.teamId.substring(1))
      .then((res) => {
        sessionStorage.setItem('teamId', res.teamId.substring(1));
        auth.showInfo('Team joined successfully!');
        this.redirect(`#/catalog`);
      })
      .catch((err) => auth.showError(err));
  }

  function leaveRoute(ctx) {
    ctxHandler(ctx);

    teamsService.leaveTeam()
      .then(() => {
        sessionStorage.setItem('teamId', undefined);
        auth.showInfo('Team left successfully!');
        this.redirect(`#/catalog`);
      })
      .catch((err) => auth.showError(err));
  }

  function createRoute(ctx) {
    ctxHandler(ctx);

    this.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs',
      createForm: './templates/create/createForm.hbs'
    }).then(function () {
      this.partial('./templates/create/createPage.hbs');
    });
  }

  function createRoutePost(ctx) {
    ctxHandler(ctx);

    let isOnTeam = ctx.teamId !== "undefined";
    if (isOnTeam) {
      auth.showError('You are not allow to create until leave the current team!');
      this.redirect(`#/catalog`);
      return;
    }

    let tName = this.params.name;
    let tComment = this.params.comment;

    if (tName === '') {
      auth.showError('Team name cannot be blank!')
      this.redirect('#/create');
      return;
    }

    if (tComment === '') {
      auth.showError('Description cannot be blank!')
      this.redirect('#/create');
      return;
    }

    teamsService.createTeam(tName, tComment)
      .then((res) => {
        auth.showInfo(`Successfully created team named: ${tName}`);
        sessionStorage.setItem('teamId', res._id);
        this.redirect('#/catalog');
      }).catch((err) => auth.showError(err));
  }

  function editRouteById(ctx) {
    ctxHandler(ctx);
    ctx.teamId = this.params.id.substring(1);

    teamsService.loadTeamDetails(ctx.teamId)
      .then((res => {
        ctx.name = res.name;
        ctx.comment = res.comment;

        this.loadPartials({
          header: './templates/common/header.hbs',
          footer: './templates/common/footer.hbs',
          editForm: './templates/edit/editForm.hbs'
        }).then(function () {
          this.partial('./templates/edit/editPage.hbs');
        })
      }))
      .catch((err) => auth.showError(err));
  }

  function editRouteByIdPost(ctx) {
    ctxHandler(ctx);

    teamsService.edit(this.params.id.substring(1), this.params.name, this.params.comment)
      .then(() => {
        this.redirect('#/catalog');
        auth.showInfo('Team updated successfully!');
      })
      .catch((err) => auth.showError(err));
  }

  return {
    homeRoute,
    aboutRoute,
    loginRoute,
    loginRoutePost,
    logoutRoutePost,
    registerRoute,
    registerRoutePost,
    catalogRoute,
    catalogRouteById,
    joinRouteById,
    leaveRoute,
    createRoute,
    createRoutePost,
    editRouteById,
    editRouteByIdPost
  }
})();