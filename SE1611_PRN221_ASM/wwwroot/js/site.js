/*
 Load books in home collection
 */
$(document).ready(function () {

    $(".title-tabs-text").unbind('click');

    loadTab('history');
    $(".title-tabs-text").click(function (e) {
        e.preventDefault();
        $(".title-tabs-text").closest('h2').removeClass('active');
        $(e.currentTarget).closest('h2').addClass('active');
        var tab = $(this).text().toLowerCase();
        console.log(tab);
        $.ajax({
            url: "/Home/LoadBooks?tab=" + tab,
            type: "GET",
            success: function (result) {
                $("#partial-view-container").html(result);
                //$(window).trigger('resize');
                //console.log(result);
            }
        });
    });
});
/**
 * Indicate the tab loading
 * @param {any} tab
 */

function loadTab(tab) {
    // Make the AJAX request to load the partial view
    //console.log(`Load Tabs: ${tab}`);
    $.ajax({
        url: "/Home/LoadBooks?tab=" + tab,
        type: "GET",
        success: function (result) {
            // Replace the contents of the container with the partial view           
            $("#partial-view-container").html(result);
        },
        error: function () {
            console.log("Error loading partial view.");
        }
    });
}


/*
 Side bar collapse in search
 */
$(document).ready(function () {
    $('.sidebar-block_genres').unbind('click');
    $('.sidebar-block_genres').click(function () {
        $(this).next('.sidebar-block_content').find('ul.category-list.clearfix').slideToggle();
        if ($(this).closest('.sidebar-block').hasClass('open')) {
            $(this).closest('.sidebar-block').removeClass('open')
        } else {
            $(this).closest('.sidebar-block').addClass('open')
        }
    });
});

$(document).ready(function () {
    $('#btnDisable').click((e) => {
        e.preventDefault();
        $('#btnDisable').confirm();
    })
})

/**
 * Get query value from the url
 * */
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

/**
 * Load comment in the Book Details page
 * @param {any} id
 * @param {any} page
 * @param {any} callback
 */
function loadComment(id, page, callback) {

    $.ajax({
        cache: false,
        url: "/Comment/GetComment?bookId=" + id + "&page=" + page,
        type: "GET",
        success: function (result) {
            $("#partial_comment_container").html(result);
            console.log(result);
            if (callback) {
                callback();
            }

            // Bind click event to pagination links
            $("#partial_comment_container").on('click', '#pagination .comment_page', function (e) {
                e.preventDefault();
                console.log(e.currentTarget);
                var page = $(this).text().toLowerCase();
                console.log(page);
                //$(".comment_page").removeClass('active');

                $.ajax({
                    cache: false,
                    url: "/Comment/GetComment?bookId=" + id + "&page=" + page,
                    type: "GET",
                    success: function (result) {
                        $("#partial_comment_container").html(result);
                        console.log(result);
                    }
                });
            });
        }
    });
}

/*
Load comment in Book Details page 
 */
$(document).ready(function () {
    var id = getUrlVars()["id"];
    console.log(id);
    $("#partial_comment_container").unbind('click');
    loadComment(id, 1);

});

/*
 Collapse toogle on write comment
 */
$(document).ready(function () {
    $("#write-review").unbind('click');
    $('#write-review').click(function () {
        $('#comment_section').slideToggle();
    });
});






