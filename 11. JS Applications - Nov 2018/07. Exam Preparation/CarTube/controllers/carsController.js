const carsController = (function () {
  function getAll() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    carModel.all(this)
      .then((res) => {
        if (res.length === 0) {
          this.noCarsFound = true;
        } else {
          res.forEach((a) => {
            if (a._acl.creator === sessionStorage.getItem('userId')) {
              a.isAuthor = true;
            }
          });
        }

        this.cars = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              car: './views/cars/listing/car.hbs'
            })
          })
          .then(function () {
            this.partial('./views/cars/listing/listingPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));
  }

  function getCreate() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    contextService.loadCommon(this)
      .then(function () {
        this.loadPartials({
          createForm: './views/cars/create/createForm.hbs',
          validatorForm: './views/common/validatorForm.hbs'
        })
      })
      .then(function () {
        this.partial('./views/cars/create/createPage.hbs');
      });
  }

  function postCreate() {
    // boostrap form validation on user's side
    // TBA on server's side

    let car = {
      seller: sessionStorage.getItem('username'),
      title: this.params.title,
      description: this.params.description,
      brand: this.params.brand,
      model: this.params.model,
      year: this.params.year,
      imageUrl: this.params.imageUrl,
      fuelType: this.params.fuelType,
      price: this.params.price
    }

    carModel.create(car)
      .then(() => {
        this.redirect('#/listing');
        drawerService.showInfo('Car created successfully!');
      })
      .catch((err) => drawerService.handleError(err));
  }

  function getEdit() {
    contextService.ctxHandler(this);

    // security check on post

    carModel.details(this.params.id.substring(1))
      .then((res) => {
        this.id = res._id;
        this.title = res.title;
        this.description = res.description;
        this.brand = res.brand;
        this.model = res.model;
        this.year = res.year;
        this.imageUrl = res.imageUrl;
        this.fuelType = res.fuelType;
        this.price = res.price;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              editForm: './views/cars/edit/editForm.hbs',
              validatorForm: './views/common/validatorForm.hbs'
            })
          })
          .then(function () {
            this.partial('./views/cars/edit/editPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));
  }

  function postEdit() {
    carModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        // boostrap form validation on user's side
        // TBA on server's side

        try {
          let car = {
            seller: sessionStorage.getItem('username'),
            title: this.params.title,
            description: this.params.description,
            brand: this.params.brand,
            model: this.params.model,
            year: this.params.year,
            imageUrl: this.params.imageUrl,
            fuelType: this.params.fuelType,
            price: this.params.price
          }

          carModel.edit(this.params.id.substring(1), car)
            .then((res) => {
              drawerService.showInfo(`Listing ${res.title} updated!`);
              this.redirect('#/listing');
            })
        } catch (err) {
          (err) => drawerService.handleError(err);
        }
      })
  }

  function postDelete() {
    contextService.ctxHandler(this);

    carModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        try {
          carModel.remove(this.params.id.substring(1))
            .then(() => {
              drawerService.showInfo('Listing deleted!');
              this.redirect('#/listing');
            })
        } catch (err) {
          (err) => drawerService.handleError(err);
        }
      });
  }

  function getMyListing() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    carModel.my(sessionStorage.getItem('username'))
      .then((res) => {
        if (res.length === 0) {
          this.noCarsFound = true;
        }

        this.cars = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              car: './views/cars/my/my.hbs'
            });
          })
          .then(function () {
            this.partial('./views/cars/my/myPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));
  }

  async function getDetails() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    let car = await carModel.details(this.params.id.substring(1));

    this.id = car._id;
    this.title = car.title;
    this.description = car.description;
    this.brand = car.brand;
    this.model = car.model;
    this.year = car.year;
    this.imageUrl = car.imageUrl;
    this.fuelType = car.fuelType;
    this.price = car.price;

    if (car._acl.creator === sessionStorage.getItem('userId')) {
      this.isAuthor = true;
    }

    try {
      contextService.loadCommon(this)
        .then(function () {
          this.partial('./views/cars/details/details.hbs');
        })
    } catch (err) {
      (err) => drawerService.handleError(err)
    }
  }

  return {
    getAll,
    getCreate,
    postCreate,
    getEdit,
    postEdit,
    postDelete,
    getMyListing,
    getDetails
  }
})();