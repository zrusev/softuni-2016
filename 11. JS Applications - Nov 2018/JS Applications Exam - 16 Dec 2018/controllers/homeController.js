const homeController = (() => {
  function getIndex() {
    contextService.ctxHandler(this);

    //security check
    if (this.loggedIn) {
      this.redirect(`#/listing`);
      return;
    }

    contextService.loadCommon(this)
      .then(function () {
        this.partial('./views/home/home.hbs');
      });
  }

  return {
    getIndex
  }
})();