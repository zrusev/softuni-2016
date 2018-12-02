function attachEvents() {
    $('#btnLoadTowns').click(() => {
        let source = $('#towns-template').html();

        let template = Handlebars.compile(source);

        let values = $('#towns').val().split(', ');

        let arr = values.reduce((acc, el) => {
            acc.push({
                "name": el
            });

            return acc;
        }, []);

        let towns = {
            "items": arr
        };

        $('#root').html(template(towns));
    });
}