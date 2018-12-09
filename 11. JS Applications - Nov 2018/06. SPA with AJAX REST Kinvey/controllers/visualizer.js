const drawer = (function () {
    let loggedIn;

    if (localStorage.getItem('authtoken') !== null) {
        userLoggedIn();
        loggedIn = true;
    } else {
        userLoggedOut();
        loggedIn = false;
    }

    function navigateTo(a) {
        //Invoke by name if needed
        // let fn = a.target.id.replace('link', '').toLowerCase();
        // if(drawer.loggedIn){            
        //     advertiser[fn](); 
        // } else {
        //     user[fn]();           
        // }

        let view = a.target.dataset.target;
        showView(view);
    }

    function showView(viewName) {
        // Hide all views and show the selected view only
        let prom = new Promise(function (resolve, reject) {
            $('main > section').hide();
            $('#' + viewName).show();

            if (viewName === 'viewAds') {
                advertiser.loadAds()
                    .then((res) => {
                        console.log(res);                        
                    })
                    .catch((err) => {
                        console.log(err);                        
                    })
            }
            resolve();
        });

        return prom;
    }

    //No actual need to load promises, performed as an exercise
    // Shows only the correct links for a logged in user
    async function userLoggedIn() {
        await Promise.all([
            new Promise((resolve) => {
                let span = $('#loggedInUser');
                span.text(`Welcome ${localStorage.getItem('username')}!`);
                span.show();

                resolve($('#menu > a').hide());
            }),
            showView('linkHome'),
            showView('linkListAds'),
            showView('linkCreateAd'),
            showView('linkLogout')
        ]);
    }

    //No actual need to load promises, performed as an exercise
    // Shows only the correct links for an anonymous user
    async function userLoggedOut() {
        await Promise.all([
            new Promise((resolve) => {
                let span = $('#loggedInUser');
                span.text('');
                span.hide();

                resolve($('#menu > a').hide());
            }),
            showView('linkHome'),
            showView('linkLogin'),
            showView('linkRegister'),
            showView('viewHome')
        ]);
    }

    function showInfo(message) {
        let infoBox = $('#infoBox');
        infoBox.text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    function showError(message) {
        let errorBox = $('#errorBox');
        errorBox.text(message);
        errorBox.show();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    return {
        navigateTo,
        loggedIn,
        showView,
        userLoggedIn,
        userLoggedOut,
        showInfo,
        showError,
        handleError
    }
})();