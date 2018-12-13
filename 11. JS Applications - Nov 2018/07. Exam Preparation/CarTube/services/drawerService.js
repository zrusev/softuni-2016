$(document).on({
  ajaxStart: () => $("#loadingBox").show(),
  ajaxStop: () => $('#loadingBox').fadeOut()
});

const drawerService = (function () {

  function handleError(reason) {
    showError(reason.responseJSON.description);
  }

  function showInfo(message) {
    let infoBox = $('#infoBox');
    infoBox.children(0).text(message);
    infoBox.show();
    setTimeout(() => infoBox.fadeOut(), 3000);
  }

  function showError(message) {
    let errorBox = $('#errorBox');
    errorBox.children(0).text(message);
    errorBox.show();
    setTimeout(() => errorBox.fadeOut(), 3000);
  }

  return {
    showInfo,
    showError,
    handleError
  }
})();