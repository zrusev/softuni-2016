$(() => {
  const app = Sammy('#container', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/', homeController.getIndex);

      this.get('#/index.html', homeController.getIndex);

      this.get('#/register', usersController.getRegister);

      this.post('#/register', usersController.postRegister);

      this.get('#/login', usersController.getLogin);

      this.post('#/login', usersController.postLogin);

      this.get('#/logout', usersController.getLogout);

      this.get('#/listing', petsController.getAll);

      this.get('#/listing:key', petsController.getAllFiltered);
      
      this.get('#/create', petsController.getCreate);

      this.post('#/create', petsController.postCreate);

      this.get('#/edit:id', petsController.getEdit);

      this.put('#/edit:id', petsController.putEdit);

      this.get('#/delete:id', petsController.getDelete);
      
      this.post('#/delete:id', petsController.postDelete);

      this.get('#/mylisting', petsController.getMyListing);

      this.get('#/details:id', petsController.getDetails);

      this.get('#/like:id', petsController.getLike);
  });

  app.run('#/');
});

