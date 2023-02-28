$(document).ready(function () {

    $(".title-tabs-text").unbind('click');
    loadTab('novel');
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
function loadTab(tab) {
    // Make the AJAX request to load the partial view
    $.ajax({
        url: "/Home/LoadBooks?tab=" + tab,
        type: "GET",
        success: function (result) {
            // Replace the contents of the container with the partial view
            $(this).closest('h2').addClass('active');
            $("#partial-view-container").html(result);
        },
        error: function () {
            console.log("Error loading partial view.");
        }
    });
}


$(document).ready(function () {
    $('.sidebar-block_title').unbind('click');
    $('.sidebar-block_title').click(function () {
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




