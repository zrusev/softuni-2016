const homeController = (() => {
  function getIndex() {
    contextService.ctxHandler(this);

    contextService.loadCommon(this)
      .then(function () {
        this.partial('./views/home/home.hbs');
      });
  }

  return {
    getIndex
  }
})();