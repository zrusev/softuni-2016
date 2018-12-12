const contextService = (function () {
  function ctxHandler(ctx) {
    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
    ctx.username = sessionStorage.getItem('username');
  }

  function loadCommon(ctx) {
    return ctx.loadPartials({
      header: './views/common/header.hbs',
      footer: './views/common/footer.hbs'
    });
  }

  return {
    ctxHandler,
    loadCommon
  }
})();