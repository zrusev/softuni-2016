const startUp = (function startApp() {
    const templates = {};

    loadTemplates();

    async function loadTemplates() {
        const [adsCatalogTemplate, adBoxTemplate] = await Promise.all([
                $.get('../templates/ads-catalog.html'),
                $.get('../templates/ad-box-partial.html')
        ]);

        templates['catalog'] = Handlebars.compile(adsCatalogTemplate);
        Handlebars.registerPartial('adBox', adBoxTemplate);
    }
    
    // Attach click events
    (() => {
        $('header').find('a[data-target]').click(drawer.navigateTo);
        $('#buttonLoginUser').click(user.login);
        $('#buttonRegisterUser').click(user.register);
        $('#linkLogout').click(user.logout);
        $('#buttonCreateAd').click(advertiser.createAd);
        $('.notification').click(function () {
            $(this).hide();
        });
        drawer.showView('viewHome');
    })();

    // Handle notifications
    $(document).on({
        ajaxStart: () => $("#loadingBox").show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    return {
        templates
    }
})();