(function (window, $) {
    'use strict';

    // Cache document for fast access.
    var document = window.document;


    /************** Toggle Menu *********************/
    $('a.toggle-menu').click(function () {
        $(".menu").slideToggle(400);
        return false;
    });

    $('#teamImg1,#teamImg2,#teamImg3').click(function () {
        var imagevalue = $(this).attr('data-value');
        if (imagevalue == "1") {
            $('#teamImage1').attr('src', 'images/team/member-1.jpg');
            $('#teamImage2').attr('src', 'images/team/member-2.jpg');
        }
        if (imagevalue == "2") {
            $('#teamImage1').attr('src', 'images/team/member-3.jpg');
            $('#teamImage2').attr('src', 'images/team/member-4.jpg');
        }
        if (imagevalue == "3") {
            $('#teamImage1').attr('src', 'images/team/member-5.jpg');
            $('#teamImage2').attr('src', 'images/team/member-6.jpg');
        }
    });

    $('#serviceTab1,#serviceTab2,#serviceTab3').click(function () {
        var tabvalue = $(this).attr('data-value');
        if (tabvalue == "1") {
            $('#servicesImage1').attr('src', 'images/services/industrial-1.jpg');
            $('#servicesImage2').attr('src', 'images/services/industrial-2.jpg');
        }
        if (tabvalue == "2") {
            $('#servicesImage1').attr('src', 'images/services/building-1.jpg');
            $('#servicesImage2').attr('src', 'images/services/building-2.jpg');
        }
        if (tabvalue == "3") {
            $('#servicesImage1').attr('src', 'images/services/renovation-1.jpg');
            $('#servicesImage2').attr('src', 'images/services/renovation-2.jpg');
        }
    });

    /************** Open Different Pages *********************/
    $(".menu a").click(function () {
        var id = $(this).attr('class');
        id = id.split('-');
        $("#menu-container .content").hide();
        $("#menu-container #menu-" + id[1]).addClass("animated fadeInDown").show();
        return false;
    });

    $(".menu a.homebutton").click(function () {
        $(".menu").slideUp();
    });


    $(window).resize(function () {
        if ($(window).width() <= 769) {
            $(".menu a").click(function () {
                $(".menu").hide();
                return false;
            });
        }
    });

    /*
	var dt = window.atob('IC0gPGEgcmVsPSJub2ZvbGxvdyIgaHJlZj0iaHR0cDovL3d3dy50ZW1wbGF0ZW1vLmNvbS9wcmV2aWV3L3RlbXBsYXRlbW9fNDEwX2NpcmNsZSI+Q2lyY2xlPC9hPiBieSA8YSByZWw9Im5vZm9sbG93IiBocmVmPSJodHRwOi8vd3d3LnRlbXBsYXRlbW8uY29tIj5GcmVlIFRlbXBsYXRlczwvYT4='); 
	var y = document.getElementById('footer-text');
	y.innerHTML += dt;
	*/

    /************** Tabs *********************/
    $('ul.tabs').each(function () {
        // For each set of tabs, we want to keep track of
        // which tab is active and it's associated content
        var $active, $content, $links = $(this).find('a');

        // If the location.hash matches one of the links, use that as the active tab.
        // If no match is found, use the first link as the initial active tab.
        $active = $($links.filter('[href="' + location.hash + '"]')[0] || $links[0]);
        $active.addClass('active');

        $content = $($active[0].hash);

        // Hide the remaining content
        $links.not($active).each(function () {
            $(this.hash).hide();
        });

        // Bind the click event handler
        $(this).on('click', 'a', function (e) {
            // Make the old tab inactive.
            $active.removeClass('active');
            $content.hide();

            // Update the variables with the new link and content
            $active = $(this);
            $content = $(this.hash);

            // Make the tab active.
            $active.addClass('active');
            $content.slideToggle();

            // Prevent the anchor's default click action
            e.preventDefault();
        });
    });


    /************** LightBox *********************/
    $(function () {
        $('[data-rel="lightbox"]').lightbox();
    });


})(window, jQuery);

