const advertiser = (function () {
    // Load all ads
    async function loadAds() {
        try {
            let ads = await requester.get('appdata', 'adverts', '', {});
            let content = $('#content');

            ads.forEach((a) => {
                if (a._acl.creator === localStorage.getItem('id')) {
                    a.isAuthor = true;
                }
            });

            let context = {
                ads
            }

            let html = startUp.templates['catalog'](context);
            content.html(html);

            let editButton = $(content).find('.add-box').find('.edit');
            let deleteButton = $(content).find('.add-box').find('.delete');
            editButton.click(openEditAdd);
            deleteButton.click(deleteAd);

        } catch (error) {
            drawer.showError(error);
        }
    }

    // Create an add
    async function createAd() {

        let title = $('#formCreateAd input')[0].value;
        let description = $('#formCreateAd textarea')[0].value;
        let price = $('#formCreateAd input')[1].value;
        let imageURL = $('#formCreateAd input')[2].value;
        let publisher = localStorage.getItem('username');

        await requester.post('appdata', 'adverts', '', {
                title,
                description,
                price,
                imageURL,
                publisher
            })
            .done((res) => {
                drawer.showView('viewAds');
                drawer.showInfo('Ad created!');

                $('#formCreateAd').trigger('reset');
            })
            .catch((err) => {
                drawer.showError(err);
            })
    }

    // Delete an add
    async function deleteAd() {

    }

    // Edit an add
    async function editAd(id, publisher, date) {

    }

    // Open edit add view
    async function openEditAdd() {

    }

    return {
        loadAds,
        createAd,
        deleteAd,
        editAd,
        openEditAdd
    }
})();