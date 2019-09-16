const uri = "api/Movies";
let todos = null;
function getCount(data) {
    const el = $("#counter");
    let name = "movie";
    if (data) {
        if (data > 1) {
            name = "movies";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#todos");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.title))
                    .append($("<td></td>").text(item.releaseDate))
                    .append($("<td></td>").text(item.genre))
                    .append($("<td></td>").text(item.price))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );

                tr.appendTo(tBody);
            });

            todos = data;
        }
    });
}

function addItem() {
    const item = {
        title: $("#add-title").val(),
        releaseDate: $("#add-release-date").val(),
        genre: $("#add-genre").val(),
        price: $("#add-price").val()
    };

    // $.ajax({
    //     type: "POST",
    //     accepts: "application/json",
    //     url: uri,
    //     contentType: "application/json",
    //     data: JSON.stringify(item),
    //     error: function (jqXHR, textStatus, errorThrown) {
    //         alert("Something went wrong!");
    //     },
    //     success: function (result) {
    //         getData();
    //         $("#add-name").val("");
    //     }
    // });

    requestWithCSRF(uri, item, 'POST');
    $("#add-title").val("");
    $("#add-release-date").val("");
    $("#add-genre").val("");
    $("#add-price").val("");
}

function deleteItem(id) {
    // $.ajax({
    //     url: uri + "/" + id,
    //     type: "DELETE",
    //     success: function (result) {
    //         getData();
    //     }
    // });
    var url = uri + "/" + id;
    requestWithCSRF(url, '', 'DELETE');
}
function SetDate(data){
    return data.toString().length != 2 ? `0${data}` : data;
}

function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            var releaseDate = new Date(item.releaseDate);
            var date = `${releaseDate.getFullYear()}-${SetDate(releaseDate.getMonth() + 1)}-${SetDate(releaseDate.getDate())}`;
            $("#edit-title").val(item.title);
            $("#edit-release-date").val(date);
            $("#edit-genre").val(item.genre);
            $("#edit-price").val(item.price);
            $("#edit-id").val(item.id);
            
        }
    });
    $("#spoiler").css({ display: "block" });
}

$(".my-form").on("submit", function () {
    const item = {
        title: $("#edit-title").val(),
        releaseDate: $("#edit-release-date").val(),
        genre: $("#edit-genre").val(),
        price: $("#edit-price").val(),
        id: $("#edit-id").val()
    };

    // $.ajax({
    //     url: uri + "/" + $("#edit-id").val(),
    //     type: "PUT",
    //     accepts: "application/json",
    //     contentType: "application/json",
    //     data: JSON.stringify(item),
    //     success: function (result) {
    //         getData();
    //     }
    // });
    var url = uri + "/" + $("#edit-id").val();
    requestWithCSRF(url, item, 'PUT');
    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function requestWithCSRF(url, data, requestType){
    var csrfToken = getCookie("CSRF-TOKEN");
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == XMLHttpRequest.DONE) {
            getData();
            // if (xhttp.status == 200) {
            //     alert(xhttp.responseText);
            // } else {
            //     alert('There was an error processing the AJAX request.');
            // }
        }
    };
    xhttp.open(requestType, url, true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("X-CSRF-TOKEN", csrfToken);
    xhttp.send(JSON.stringify(data));
}
// var csrfToken = getCookie("CSRF-TOKEN");

// var xhttp = new XMLHttpRequest();
// xhttp.onreadystatechange = function () {
//     if (xhttp.readyState == XMLHttpRequest.DONE) {
//         if (xhttp.status == 200) {
//             alert(xhttp.responseText);
//         } else {
//             alert('There was an error processing the AJAX request.');
//         }
//     }
// };
// xhttp.open('POST', '/api/password/changepassword', true);
// xhttp.setRequestHeader("Content-type", "application/json");
// xhttp.setRequestHeader("X-CSRF-TOKEN", csrfToken);
// xhttp.send(JSON.stringify({ "newPassword": "ReallySecurePassword999$$$" }));