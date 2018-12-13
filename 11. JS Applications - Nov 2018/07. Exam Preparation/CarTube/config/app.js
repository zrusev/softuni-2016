$(() => {
  const app = Sammy('#container', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/', homeController.getIndex);

      this.get('/index.html', homeController.getIndex);

      this.get('#/register', userController.getRegister);

      this.post('#/register', userController.postRegister);

      this.get('#/login', userController.getLogin);

      this.post('#/login', userController.postLogin);

      this.get('#/logout', userController.getLogout);


  });

  app.run('#/');
});