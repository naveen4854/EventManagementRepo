$(function ($) {
    //'use strict',

    //	//Countdown js
    //	 //$("#countdown").countdown({
    //	 //   	date: "10 july 2014 12:00:00",
    //	 //   	format: "on"
    //	 //   },

    //	//Scroll Menu

    function menuToggle() {
        var windowWidth = $(window).width();

        if (windowWidth > 767) {
            $(window).on('scroll', function () {
                if ($(window).scrollTop() > 405) {
                    $('.main-nav').addClass('fixed-menu animated slideInDown');
                    $.each($('.main-nav a'), function () {
                        if ($(this).hasClass('homeicon')) {
                            $(this).removeClass("homeicon").addClass("homeicon-fixed");
                        }
                    });
                } else {
                    $('.main-nav').removeClass('fixed-menu animated slideInDown');
                    $.each($('.main-nav a'), function () {
                        if ($(this).hasClass('homeicon-fixed')) {
                            $(this).removeClass("homeicon-fixed").addClass("homeicon");
                        }
                    });
                }
            });
        } else {
            $('.main-nav').addClass('fixed-menu animated slideInDown');
            $.each($('.main-nav a'), function () {
                if ($(this).hasClass('homeicon')) {
                    $(this).removeClass("homeicon").addClass("homeicon-fixed");
                }
            });
        }
    }

    menuToggle();


    // Carousel Auto Slide Off
    $('#event-carousel, #SA-carousel, #twitter-feed, #sponsor-carousel ').carousel({
        interval: false
    });

    //$('.post').addClass("hidden").viewportChecker({
    //    classToAdd: 'visible animated bounceInLeft', // Class to add to the elements when they are visible
    //    offset: 100
    //});


    //	$( window ).resize(function() {
    //		menuToggle();
    //	});

    $('.main-nav ul').onePageNav({
        currentClass: 'active',
        changeHash: false,
        scrollSpeed: 900,
        scrollOffset: 0,
        scrollThreshold: 0.3,
        filter: ':not(.no-scroll)'
    });

});
function showGoogleMaps(loc) {

    var latLng = new google.maps.LatLng(loc.lat, loc.long);

    var mapOptions = {
        zoom: 16, // initialize zoom level - the max value is 21
        streetViewControl: false, // hide the yellow Street View pegman
        scaleControl: true, // allow users to zoom the Google Map
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        center: latLng
    };

    map = new google.maps.Map(document.getElementById('googlemaps'),
        mapOptions);

    // Show the default red marker at the location
    marker = new google.maps.Marker({
        position: latLng,
        map: map,
        draggable: false,
        animation: google.maps.Animation.DROP
    });
}

function spinner(flag) {
    if (flag) {
        $(".overlay").show();
    }
    else {
        $(".overlay").hide();
    }
}

//function spinner() {
//    this.prototype.show = function(){
//        $(".overlay").show();
//    }
//    this.prototype.hide = function () {
//        $(".overlay").hide();
//    }
//}

//// Google Map Customization
////(function(){

////	var map;

////	map = new GMaps({
////		el: '#gmap',
////		lat: 43.04446,
////		lng: -76.130791,
////		scrollwheel:false,
////		zoom: 16,
////		zoomControl : false,
////		panControl : false,
////		streetViewControl : false,
////		mapTypeControl: false,
////		overviewMapControl: false,
////		clickable: false
////	});

////	var image = 'images/map-icon.png';
////	map.addMarker({
////		lat: 43.04446,
////		lng: -76.130791,
////		icon: image,
////		animation: google.maps.Animation.DROP,
////		verticalAlign: 'bottom',
////		horizontalAlign: 'center',
////		backgroundColor: '#3e8bff',
////	});


////	var styles = [ 

////	{
////		"featureType": "road",
////		"stylers": [
////		{ "color": "#b4b4b4" }
////		]
////	},{
////		"featureType": "water",
////		"stylers": [
////		{ "color": "#d8d8d8" }
////		]
////	},{
////		"featureType": "landscape",
////		"stylers": [
////		{ "color": "#f1f1f1" }
////		]
////	},{
////		"elementType": "labels.text.fill",
////		"stylers": [
////		{ "color": "#000000" }
////		]
////	},{
////		"featureType": "poi",
////		"stylers": [
////		{ "color": "#d9d9d9" }
////		]
////	},{
////		"elementType": "labels.text",
////		"stylers": [
////		{ "saturation": 1 },
////		{ "weight": 0.1 },
////		{ "color": "#000000" }
////		]
////	}

////	];

////	map.addStyle({
////		styledMapName:"Styled Map",
////		styles: styles,
////		mapTypeId: "map_style"  
////	});

////	map.setStyle("map_style");
////}());



