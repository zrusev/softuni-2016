$(() => {

    renderCatTemplate();

    function renderCatTemplate() {
        let source = $('#cat-template').html();

        let template = Handlebars.compile(source);

        let cats = {
            "items": window.cats
        }

        $('#allCats').html(template(cats));

        $('button').toArray().forEach((btn) => {
            $(btn).click(showAndHideInfo);
        });
    }

    function showAndHideInfo() {
        let btn = $(this);

        if (btn.text() === 'Show status code') {
            btn.next().css('display', 'block');
            btn.text('Hide status code');
        } else {
            btn.next().css('display', 'none');
            btn.text('Show status code');
        }
    }
})