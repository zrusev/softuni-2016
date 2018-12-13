$(() => {
  const app = Sammy('#container', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/', homeController.getIndex);

      this.get('/index.html', homeController.getIndex);

      this.get('#/register', usersController.getRegister);

      this.post('#/register', usersController.postRegister);

      this.get('#/login', usersController.getLogin);

      this.post('#/login', usersController.postLogin);

      this.get('#/logout', usersController.getLogout);

      this.get('#/listing', carsController.getAll);
      
      this.get('#/create', carsController.getCreate);

      this.post('#/create', carsController.postCreate);

      this.get('#/edit:id', carsController.getEdit);

      this.post('#/edit:id', carsController.postEdit);

      this.get('#/delete:id', carsController.postDelete);

      this.get('#/mylisting', carsController.getMyListing);

      this.get('#/details:id', carsController.getDetails);
  });

  app.run('#/');
});