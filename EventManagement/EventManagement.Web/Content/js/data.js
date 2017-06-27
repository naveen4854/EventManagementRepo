var postloaded = false;
var searchloaded = false;

function check() {
    spinner(true);
    var url = "";
    if ($('#ddlpCity').val() == "" || $('#ddlpCity').val() == "-1" || $('#ddlpCity').val() == undefined)
        url = baseUrl + 'Theatre/City/All'
    else
        url = baseUrl + 'Theatre/City/' + $('#ddlpCity').val()

    $.ajax({
        type: "post",
        url: url,
        datatype: "json",
        traditional: true,
        success: function (data) {
            var theatre = "<select id='ddlpTheatres'>";
            theatre = theatre;
            for (var i = 0; i < data.length; i++) {
                theatre = theatre + '<option value=' + data[i].Id + '>' + data[i].TheatreName + '</option>';
            }
            theatre = theatre + '</select>';
            $('#ddlpTheatres').html(theatre);
            spinner(false);
        }
    });

    var movieUrl = "";
    if ($('#ddlpCity').val() == "" || $('#ddlpCity').val() == "-1" || $('#ddlpCity').val() == undefined)
        movieUrl = baseUrl + 'Movie/City/All'
    else
        movieUrl = baseUrl + 'Movie/City/' + $('#ddlpCity').val()

    $.ajax({
        type: "post",
        url: movieUrl,
        datatype: "json",
        traditional: true,
        success: function (data) {
            var movie = "<select id='ddlpMovies'>";
            movie = movie;
            for (var i = 0; i < data.length; i++) {
                movie = movie + '<option value=' + data[i].Id + '>' + data[i].MovieName + '</option>';
            }
            movie = movie + '</select>';
            $('#ddlpMovies').html(movie);
        }
    });
}

function PostTicket() {
    if ($('#postTicketForm').valid()) {
        spinner(true);
        var data = new FormData();

        data.append("movieId", $("#ddlpMovies").val());
        data.append("TheatreId", $("#ddlpTheatres").val());
        data.append("CityId", $("#ddlpCity").val());
        data.append("emailId", $("#pEmailId").val());
        data.append("NoOfTickets", $("#NoOfTickets").val());
        data.append("Price", $("#pPrice").val());
        data.append("PhoneNumber", $("#pPhoneNumber").val());
        data.append("ShowDateTime", $("#ShowDateTime").val());

        var url = baseUrl + 'Ticket/AddTicket';

        $.ajax({
            type: 'POST',
            contentType: false,
            processData: false,
            url: url,
            data: data,
            success: function (response) {
                spinner(false);
                toastr.success('Ticket has been posted');
                window.location.href = baseUrl + 'Ticket/Success'
                //if (response.Url == undefined)
                //    toastr.info('Something went wrong!!')
                //else
                //    window.location.href = response.Url;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                toastr.info('Something went wrong!!')
            },
        });
    }
}

function SearchCityChange() {
    var url = "";
    if ($('#ddlSCity').val() == "" || $('#ddlSCity').val() == "-1" || $('#ddlSCity').val() == undefined)
        url = baseUrl + 'Theatre/City/All'
    else
        url = baseUrl + 'Theatre/City/' + $('#ddlSCity').val()

    $.ajax({
        type: "post",
        url: url,
        datatype: "json",
        traditional: true,
        success: function (data) {
            var theatre = "<select id='ddlSTheatres'>";
            theatre = theatre + '<option value="-1">Any</option>';
            for (var i = 0; i < data.length; i++) {
                theatre = theatre + '<option value=' + data[i].Id + '>' + data[i].TheatreName + '</option>';
            }
            theatre = theatre + '</select>';
            $('#ddlSTheatres').html(theatre);
        }
    });
    var movieUrl = "";
    if ($('#ddlSCity').val() == "" || $('#ddlSCity').val() == "-1" || $('#ddlSCity').val() == undefined)
        movieUrl = baseUrl + 'Movie/City/All'
    else
        movieUrl = baseUrl + 'Movie/City/' + $('#ddlSCity').val()

    $.ajax({
        type: "post",
        url: movieUrl,
        datatype: "json",
        traditional: true,
        success: function (data) {
            var movie = "<select id='ddlSMovies'>";
            movie = movie + '<option value="-1">Any</option>';
            movie = movie;
            for (var i = 0; i < data.length; i++) {
                movie = movie + '<option value=' + data[i].Id + '>' + data[i].MovieName + '</option>';
            }
            movie = movie + '</select>';
            $('#ddlSMovies').html(movie);
        }
    });
}

function SearchTicket() {
    spinner(true);
    var data = new FormData();

    if ($('#ddlSMovies').val() == "" || $('#ddlSMovies').val() == "-1" || $('#ddlSMovies').val() == undefined)
        data.append("movieId", null);
    else
        data.append("movieId", $("#ddlSMovies").val());

    if ($('#ddlSTheatres').val() == "" || $('#ddlSTheatres').val() == "-1" || $('#ddlSTheatres').val() == undefined)
        data.append("TheatreId", null);
    else
        data.append("TheatreId", $("#ddlSTheatres").val());

    
    data.append("CityId", $("#ddlSCity").val());
    var url = "";
    if (mobilecheck())
        url = baseUrl + 'Ticket/m/filter';
    else
        url = baseUrl + 'Ticket/filter';

    $.ajax({
        type: 'POST',
        contentType: false,
        processData: false,
        url: url,
        data: data,
        success: function (response) {
            spinner(false);
            $('#ticketresults').html(response)
        },
        error: function (xhr, ajaxOptions, thrownError) {
            toastr.info('Something went wrong!!')
        },
    });
}

function getDetails(key) {
    var url = baseUrl + 'Ticket/Details/' + key;
    window.open(url);
}

function LoadSearchPartial() {
    if (searchloaded)
        return;
    spinner(true);
    var url = baseUrl + 'Ticket/PartialSearchTicket';
    $.ajax({
        type: 'Get',
        contentType: false,
        processData: false,
        url: url,
        success: function (response) {
            spinner(false);
            searchloaded = true;
            $('.searchPartial').html(response)
        },
        error: function (xhr, ajaxOptions, thrownError) {
            spinner(false);
            toastr.info('Something went wrong!!')
        },
    });
}

function LoadPostPartial() {
    if (postloaded)
        return;
    spinner(true);
    var url = baseUrl + 'Ticket/PartialPostTicket';
    $.ajax({
        type: 'Get',
        contentType: false,
        processData: false,
        url: url,
        success: function (response) {
            spinner(false);
            postloaded = true;
            $('.postPartial').html(response)
        },
        error: function (xhr, ajaxOptions, thrownError) {
            spinner(false);
            toastr.info('Something went wrong!!')
        },
    });
}

function loadImages() {
    if (mobilecheck())
        url = baseUrl + 'Image/m/GetImages';
    else
        url = baseUrl + 'Image/GetImages/';
    spinner(true);
    $.ajax({
        type: 'Get',
        contentType: false,
        processData: false,
        url: url,
        success: function (response) {
            spinner(false);
            $('#HomeImages').html(response)
        },
        error: function (xhr, ajaxOptions, thrownError) {
            spinner(false);
            toastr.info('Something went wrong!!')
        },
    });
}