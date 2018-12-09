const user = (function () {
    // Saves username/id/authtoken to local storage
    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
        drawer.userLoggedIn();
    }

    // Logs in the user
    async function login() {
        let form = $('#formLogin');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            let response = await requester.post('user', 'login', 'basic', {
                username,
                password
            });
            saveSession(response);
            drawer.showView('viewAds');
            drawer.showInfo('Successfully logged in!');
        } catch (e) {
            drawer.handleError(e);
        }
    }

    // Register a user
    async function register() {
        let form = $('#formRegister');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            let response = await requester.post('user', '', 'basic', {
                username,
                password
            });
            saveSession(response);
            drawer.showView('viewAds');
            drawer.showInfo('Successfully registered!');
        } catch (e) {
            drawer.handleError(e);
        }
    }

    // Logout a user
    async function logout() {
        try {
            await requester.post('user', '_logout', 'kinvey', {
                authtoken: localStorage.getItem('authtoken')
            });
            localStorage.clear(); // Clears all session storage on logout
            drawer.userLoggedOut();
            drawer.showView('viewHome');
            drawer.showInfo('Logout successful!')
        } catch (e) {
            drawer.handleError(e);
        }
    }

    return {
        saveSession,
        login,
        register,
        logout
    }
})();