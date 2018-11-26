function attachEvents() {
    $("#btnLoad").on("click", loadRecords);

    $("#btnCreate").on("click", () => {
        let $person = $("#person");
        let $phone = $("#phone");

        $.ajax({
            method: "POST",
            url: "https://phonebook-nakov.firebaseio.com/phonebook.json",
            data: JSON.stringify({
                "person": $person.val(),
                "phone": $phone.val()
            }),
            success: loadRecords,
            error: catchError
        });

        $person.val("");
        $phone.val("");
    });

    function loadRecords() {
        $("#phonebook").empty();

        $.ajax({
            method: "GET",
            url: "https://phonebook-nakov.firebaseio.com/phonebook.json",
            success: displayData,
            error: catchError
        });

        function displayData(data) {
            for (let key in data) {

                let deleteBtn = $("<button>Delete</button>")
                    .on("click", function () {
                        $.ajax({
                            method: "DELETE",
                            url: `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`,
                            success: loadRecords,
                            error: catchError
                        });
                    });

                let $li = $(`<li>${data[key].person}: ${data[key].phone}</li>`).append(deleteBtn);

                $("#phonebook").append($li);
            }
        }
    }

    function catchError() {
        $("#phonebook").append($("<li>").text("Error"));
    }
}