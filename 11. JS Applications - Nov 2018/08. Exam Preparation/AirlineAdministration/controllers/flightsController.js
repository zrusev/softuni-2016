const flightsController = (function () {
  function getAll() {
    contextService.ctxHandler(this);

    flightModel.all(this.loggedIn)
      .then((res) => {
        this.flights = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              flight: './views/flights/listing/flight.hbs'
            })
          })
          .then(function () {
            this.partial('./views/flights/listing/listingPage.hbs');
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
          createForm: './views/flights/create/createForm.hbs',
          validatorForm: './views/common/validatorForm.hbs'
        })
      })
      .then(function () {
        this.partial('./views/flights/create/createPage.hbs');
      });
  }

  function postCreate() {
    // boostrap form validation on user's side
    // TBA on server's side

    let flight = {
      destination: this.params.destination,
      origin: this.params.origin,
      departure: this.params.departureDate,
      departureTime: this.params.departureTime,
      seats: this.params.seats,
      cost: this.params.cost,
      image: this.params.img,
      isPublished: !!this.params.public
    }

    flightModel.create(flight)
      .then(() => {
        this.redirect('#/');
        drawerService.showInfo('Created flight!');
      })
      .catch((err) => drawerService.handleError(err));
  }

  function getEdit() {
    contextService.ctxHandler(this);

    // security check on post

    Handlebars.registerHelper("checkedIf", function (condition) {
      return (condition) ? "checked" : "";
    });

    flightModel.details(this.params.id.substring(1))
      .then((res) => {
        this.flight = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              editForm: './views/flights/edit/editForm.hbs',
              validatorForm: './views/common/validatorForm.hbs'
            })
          })
          .then(function () {
            this.partial('./views/flights/edit/editPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));
  }

  function putEdit() {
    flightModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/');
          return;
        }

        // boostrap form validation on user's side
        // TBA on server's side

        try {
          let flight = {
            destination: this.params.destination,
            origin: this.params.origin,
            departure: this.params.departureDate,
            departureTime: this.params.departureTime,
            seats: this.params.seats,
            cost: this.params.cost,
            image: this.params.img,
            isPublished: !!this.params.public
          }

          flightModel.edit(this.params.id.substring(1), flight)
            .then((res) => {
              drawerService.showInfo(`Listing ${res.title} updated!`);
              this.redirect('#/');
            })
        } catch (err) {
          (err) => drawerService.handleError(err);
        }
      })
  }

  function postDelete() {
    contextService.ctxHandler(this);

    flightModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        try {
          flightModel.remove(this.params.id.substring(1))
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

    flightModel.my(sessionStorage.getItem('userId'))
      .then((res) => {
        this.flights = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              flight: './views/flights/my/my.hbs'
            });
          })
          .then(function () {
            this.partial('./views/flights/my/myPage.hbs');
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

    Handlebars.registerHelper('formatDate', function (dateString) {
      return new Handlebars.SafeString(
        moment(dateString).format("MMM D").toUpperCase()
      );
    });

    this.flight = await flightModel.details(this.params.id.substring(1));

    try {
      contextService.loadCommon(this)
        .then(function () {
          this.partial('./views/flights/details/details.hbs');
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
    putEdit,
    postDelete,
    getMyListing,
    getDetails
  }
})();