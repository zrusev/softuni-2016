$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');

        this.get('/index.html', routes.homeRoute);

        this.get('#/home', routes.homeRoute);

        this.get('#/about', routes.aboutRoute);

        this.get('#/login', routes.loginRoute);

        this.post('#/login', routes.loginRoutePost);

        this.get('#/logout', routes.logoutRoutePost);

        this.get('#/register', routes.registerRoute);

        this.post('#/register', routes.registerRoutePost);

        this.get('#/catalog', routes.catalogRoute);

        this.get('#/catalog/:id', routes.catalogRouteById);

        this.get('#/join/:teamId', routes.joinRouteById);

        this.get('#/leave', routes.leaveRoute);

        this.get('#/create', routes.createRoute);

        this.post('#/create', routes.createRoutePost);

        this.get('#/edit/:id', routes.editRouteById);

        this.post('#/edit/:id', routes.editRouteByIdPost);
    });

    app.run();
});