$(() => {
  const app = Sammy('#container', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/', flightsController.getAll);

      this.get('/index.html', flightsController.getAll);

      this.get('#/register', usersController.getRegister);

      this.post('#/register', usersController.postRegister);

      this.get('#/login', usersController.getLogin);

      this.post('#/login', usersController.postLogin);

      this.get('#/logout', usersController.getLogout);
      
      this.get('#/create', flightsController.getCreate);

      this.post('#/create', flightsController.postCreate);

      this.get('#/edit:id', flightsController.getEdit);

      this.put('#/edit:id', flightsController.putEdit);

      this.get('#/delete:id', flightsController.postDelete);

      this.get('#/mylisting', flightsController.getMyListing);

      this.get('#/details:id', flightsController.getDetails);
  });

  app.run('#/login');
});