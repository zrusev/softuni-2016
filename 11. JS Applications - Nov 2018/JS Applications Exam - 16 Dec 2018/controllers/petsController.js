const petsController = (function () {
  function getAll() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    petModel.all()
      .then((res) => {

        // Uncomment to display them all
        // Author's buttons changed within the view
        // res.forEach((a) => {
        //   if (a._acl.creator === sessionStorage.getItem('userId')) {
        //     a.isAuthor = true;
        //   }
        // });

        let allOthers = res.filter((cr) => cr._acl.creator !== sessionStorage.getItem('userId'));
        this.pets = allOthers.sort((a, b) => b.likes - a.likes );

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              pet: './views/pets/listing/pet.hbs'
            })
          })
          .then(function () {
            this.partial('./views/pets/listing/listingPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));

  }

  function getAllFiltered() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    petModel.filtered(this.params.key.substring(1))
      .then((res) => {

        // Uncomment to display them all
        // Author's buttons changed within the view
        // res.forEach((a) => {
        //   if (a._acl.creator === sessionStorage.getItem('userId')) {
        //     a.isAuthor = true;
        //   }
        // });

        let allOthers = res.filter((cr) => cr._acl.creator !== sessionStorage.getItem('userId'));
        this.pets = allOthers;

        // if needed
        //.sort((a, b) => b.likes - a.likes );

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              pet: './views/pets/listing/pet.hbs'
            })
          })
          .then(function () {
            this.partial('./views/pets/listing/listingPage.hbs');
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
          createForm: './views/pets/create/createForm.hbs'
        })
      })
      .then(function () {
        this.partial('./views/pets/create/createPage.hbs');
      });
  }

  function postCreate() {

    //form validation
    const categoryArray = ['Cat', 'Dog', 'Parrot', 'Reptile', 'Other'];
    if (!categoryArray.includes(this.params.category)) {
      drawerService.showError('You have submitted wrong category!');
      this.redirect('#/');
      return;
    }

    if (this.params.name === '' ||
      this.params.description === '' ||
      this.params.imageURL === '' ||
      this.params.category === '') {
      drawerService.showError('All fieds are required!');
      this.redirect('#/');
      return;
    }

    let pet = {
      name: this.params.name,
      description: this.params.description,
      imageURL: this.params.imageURL,
      category: this.params.category,
      likes: 0
    }

    petModel.create(pet)
      .then(() => {
        this.redirect('#/listing');
        drawerService.showInfo('Pet created.');
      })
      .catch((err) => drawerService.handleError(err));
  }

  function getEdit() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    petModel.details(this.params.id.substring(1))
      .then((res) => {
        this.pet = res;

        //security check
        if (this.pet._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              editForm: './views/pets/edit/editForm.hbs'
            })
          })
          .then(function () {
            this.partial('./views/pets/edit/editPage.hbs');
          });
      })
      .catch((err) => drawerService.handleError(err));
  }

  function putEdit() {
    petModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        // form validation
        if (this.params.name === '' ||
          this.params.description === '' ||
          this.params.imageURL === '' ||
          this.params.category === '' ||
          this.params.likes === '') {
          drawerService.showError('All fieds are required!');
          this.redirect('#/');
          return;
        }

        try {
          let pet = {
            name: this.params.name,
            description: this.params.description,
            imageURL: this.params.imageURL,
            category: this.params.category,
            likes: this.params.likes
          }

          petModel.edit(this.params.id.substring(1), pet)
            .then(() => {
              drawerService.showInfo('Updated successfully!');
              this.redirect('#/listing');
            })
        } catch (err) {
          (err) => drawerService.handleError(err);
        }
      })
  }

  async function getDelete() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    this.pet = await petModel.details(this.params.id.substring(1));

    try {
      contextService.loadCommon(this)
        .then(function () {
          this.loadPartials({
            deleteForm: './views/pets/delete/deleteForm.hbs'
          })
        })
        .then(function () {
          this.partial('./views/pets/delete/deletePage.hbs');
        })
    } catch (err) {
      (err) => drawerService.handleError(err)
    }
  }

  function postDelete() {
    contextService.ctxHandler(this);

    petModel.details(this.params.id.substring(1))
      .then((res) => {
        // security check
        if (res._acl.creator !== sessionStorage.getItem('userId')) {
          drawerService.showError("You don't have access to this resource!");
          this.redirect('#/listing');
          return;
        }

        try {
          petModel.remove(this.params.id.substring(1))
            .then(() => {
              drawerService.showInfo('Pet removed successfully!');
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

    petModel.my(sessionStorage.getItem('userId'))
      .then((res) => {
        this.pets = res;

        contextService.loadCommon(this)
          .then(function () {
            this.loadPartials({
              pet: './views/pets/my/my.hbs'
            });
          })
          .then(function () {
            this.partial('./views/pets/my/myPage.hbs');
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

    this.pet = await petModel.details(this.params.id.substring(1));

    try {
      contextService.loadCommon(this)
        .then(function () {
          this.partial('./views/pets/details/details.hbs');
        })
    } catch (err) {
      (err) => drawerService.handleError(err)
    }
  }

  async function getLike() {
    contextService.ctxHandler(this);

    //security check
    if (!this.loggedIn) {
      let action = this.path.split('/#/')[1];
      this.redirect(`#/login?ReturnUrl=%2F${action}%2F`);
      drawerService.showInfo('You need to login first!');
      return;
    }

    let pet = await petModel.details(this.params.id.substring(1));
    pet.likes++;

    petModel.edit(pet._id, pet)
      .then(() => {
        this.redirect('#/listing');
      })
      .catch((err) => drawerService.handleError(err));
  }

  return {
    getAll,
    getAllFiltered,
    getCreate,
    postCreate,
    getEdit,
    putEdit,
    getDelete,
    postDelete,
    getMyListing,
    getDetails,
    getLike
  }
})();