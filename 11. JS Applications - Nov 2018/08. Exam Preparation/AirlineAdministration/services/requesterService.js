const requesterService = (() => {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_HkO6yVzlN";
    const kinveyAppSecret = "dc9e127f7e2543358309d7957bb846d0";
    const kinveyMasterAppSecret = "ff97c20c2ff546bfa4264746c6a530ac";

    // Creates the authentication header
    function makeAuth(type) {        
        switch (type) {
            case 'master':
                return 'Basic ' + btoa(kinveyAppKey + ':' + kinveyMasterAppSecret);
            case 'kinvey':
                return 'Kinvey ' + sessionStorage.getItem('authtoken');
            default:
                return 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret);
        }
    }

    // Creates request object to kinvey
    function makeRequest(method, module, endpoint, auth) {
        return req = {
            method,
            url: kinveyBaseUrl + module + '/' + kinveyAppKey + '/' + endpoint,
            headers: {
                'Authorization': makeAuth(auth)
            }
        };
    }

    // Function to return GET promise
    function get(module, endpoint, auth) {
        return $.ajax(makeRequest('GET', module, endpoint, auth));
    }

    // Function to return POST promise
    function post(module, endpoint, auth, data) {
        let req = makeRequest('POST', module, endpoint, auth);
        req.data = data;
        return $.ajax(req);
    }

    // Function to return PUT promise
    function update(module, endpoint, auth, data) {
        let req = makeRequest('PUT', module, endpoint, auth);
        req.data = data;
        return $.ajax(req);
    }

    // Function to return DELETE promise
    function remove(module, endpoint, auth) {
        return $.ajax(makeRequest('DELETE', module, endpoint, auth));
    }

    return {
        get,
        post,
        update,
        remove
    }
})()