/***************************************************
==================== JS INDEX ======================
****************************************************
01. PreLoader Js
02. Mobile Menu Js
03. Sidebar Js
04. Cart Toggle Js
05. Search Js
06. Sticky Header Js
07. Data Background Js
08. Testimonial Slider Js
09. Slider Js (Home 3)
10. Brand Js
11. Tesimonial Js
12. Course Slider Js
13. Masonary Js
14. Wow Js
15. Data width Js
16. Cart Quantity Js
17. Show Login Toggle Js
18. Show Coupon Toggle Js
19. Create An Account Toggle Js
20. Shipping Box Toggle Js
21. Counter Js
22. Parallax Js
23. InHover Active Js

****************************************************/

(function ($) {
	("use strict");

	var windowOn = $(window);
	////////////////////////////////////////////////////
	// 01. PreLoader Js
	windowOn.on("load", function () {
		$("#loading").fadeOut(500);
	});

	////////////////////////////////////////////////////
	// 02. Mobile Menu Js
	$("#mobile-menu").meanmenu({
		meanMenuContainer: ".mobile-menu",
		meanScreenWidth: "991",
		meanExpand: ['<i class="fal fa-plus"></i>'],
	});
	// 02. menu2 Mobile Menu Js
	$("#menu2-mobile-menu").meanmenu({
		meanMenuContainer: ".menu2-mobile-menu",
		meanScreenWidth: "5000",
		meanExpand: ['<i class="fal fa-plus"></i>'],
	});

	////////////////////////////////////////////////////
	// 03. Sidebar Js

	$(".side-info-close,.offcanvas-overlay").on("click", function () {
		$(".side-info").removeClass("info-open");
		$(".offcanvas-overlay").removeClass("overlay-open");
		$(".menu2-side-bar-wrapper").removeClass("open");
	});
	$(".side-toggle").on("click", function () {
		$(".side-info").addClass("info-open");
		$(".offcanvas-overlay").addClass("overlay-open");
		$(".menu2-side-bar-wrapper").addClass("open");
	});

	$(".side-info-close,.offcanvas-overlay").on("click", function () {
		$(".offcanvas-overlay").removeClass("overlay-open");
		$(".sidebar-category-filter-wrapper").removeClass("open");
	});
	$(".product-filter-btn").on("click", function () {
		$(".offcanvas-overlay").addClass("overlay-open");
		$(".sidebar-category-filter-wrapper").addClass("open");
	});

	////////////////////////////////////////////////////
	// 04. Cart Toggle Js
	$(".cart-toggle-btn").on("click", function () {
		$(".cartmini__wrapper").addClass("opened");
		$(".body-overlay").addClass("opened");
	});
	$(".cartmini__close-btn").on("click", function () {
		$(".cartmini__wrapper").removeClass("opened");
		$(".body-overlay").removeClass("opened");
	});
	$(".body-overlay").on("click", function () {
		$(".cartmini__wrapper").removeClass("opened");
		$(".sidebar__area").removeClass("sidebar-opened");
		$(".header__search-3").removeClass("search-opened");
		$(".body-overlay").removeClass("opened");
	});

	////////////////////////////////////////////////////
	// 05. Search Js
	$(".search-toggle").on("click", function () {
		$(".search__area").addClass("opened");
	});
	$(".search-close-btn").on("click", function () {
		$(".search__area").removeClass("opened");
	});

	////////////////////////////////////////////////////
	// 06. Sticky Header Js
	windowOn.on("scroll", function () {
		var scroll = $(window).scrollTop();
		if (scroll < 100) {
			$("#header-sticky").removeClass("sticky");
		} else {
			$("#header-sticky").addClass("sticky");
		}
	});

	////////////////////////////////////////////////////
	// 07. Data Background Js
	$("[data-background").each(function () {
		$(this).css(
			"background-image",
			"url( " + $(this).attr("data-background") + "  )"
		);
	});

	////////////////////////////////////////////////////
	// 07. Nice Select Js
	$("select").niceSelect();

	////////////////////////////////////////////////////
	// 08. slider__active Slider Js

	if (jQuery(".slider__active").length > 0) {
		let sliderActive1 = ".slider__active";
		let sliderInit1 = new Swiper(sliderActive1, {
			// Optional parameters
			slidesPerView: 1,
			slidesPerColumn: 1,
			paginationClickable: true,
			loop: true,
			effect: "fade",

			autoplay: {
				delay: 5000,
			},

			// If we need pagination
			pagination: {
				el: ".slider-paginations",
				// dynamicBullets: true,
				clickable: true,
			},

			// Navigation arrows
			navigation: {
				nextEl: ".slider-button-next",
				prevEl: ".slider-button-prev",
			},

			a11y: false,
		});

		function animated_swiper(selector, init) {
			let animated = function animated() {
				$(selector + " [data-animation]").each(function () {
					let anim = $(this).data("animation");
					let delay = $(this).data("delay");
					let duration = $(this).data("duration");

					$(this)
						.removeClass("anim" + anim)
						.addClass(anim + " animated")
						.css({
							webkitAnimationDelay: delay,
							animationDelay: delay,
							webkitAnimationDuration: duration,
							animationDuration: duration,
						})
						.one(
							"webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
							function () {
								$(this).removeClass(anim + " animated");
							}
						);
				});
			};
			animated();
			// Make animated when slide change
			init.on("slideChange", function () {
				$(sliderActive1 + " [data-animation]").removeClass("animated");
			});
			init.on("slideChange", animated);
		}

		animated_swiper(sliderActive1, sliderInit1);
	}

	if (jQuery(".slider__active-2").length > 0) {
		let sliderActive1 = ".slider__active-2";
		let sliderInit1 = new Swiper(sliderActive1, {
			// Optional parameters
			slidesPerView: 1,
			slidesPerColumn: 1,
			paginationClickable: true,
			loop: true,
			effect: "fade",

			autoplay: {
				delay: 5000,
			},

			// If we need pagination
			pagination: {
				el: ".swiper-paginations",
				// dynamicBullets: true,
				clickable: true,
			},

			// Navigation arrows
			navigation: {
				nextEl: ".swiper-button-next",
				prevEl: ".swiper-button-prev",
			},

			a11y: false,
		});

		function animated_swiper(selector, init) {
			let animated = function animated() {
				$(selector + " [data-animation]").each(function () {
					let anim = $(this).data("animation");
					let delay = $(this).data("delay");
					let duration = $(this).data("duration");

					$(this)
						.removeClass("anim" + anim)
						.addClass(anim + " animated")
						.css({
							webkitAnimationDelay: delay,
							animationDelay: delay,
							webkitAnimationDuration: duration,
							animationDuration: duration,
						})
						.one(
							"webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
							function () {
								$(this).removeClass(anim + " animated");
							}
						);
				});
			};
			animated();
			// Make animated when slide change
			init.on("slideChange", function () {
				$(sliderActive1 + " [data-animation]").removeClass("animated");
			});
			init.on("slideChange", animated);
		}

		animated_swiper(sliderActive1, sliderInit1);
	}

	var themeSlider = new Swiper(".classname", {
		slidesPerView: 1,
		spaceBetween: 30,
		loop: true,
		pagination: {
			el: ".swiper-pagination",
			clickable: true,
		},
		breakpoints: {
			1200: {
				slidesPerView: 3,
			},
			992: {
				slidesPerView: 2,
			},
			768: {
				slidesPerView: 1,
			},
			576: {
				slidesPerView: 1,
			},
			0: {
				slidesPerView: 1,
			},
		},
	});

	////////////////////////////////////////////////////
	// 13. Masonary Js
	$(".grid").imagesLoaded(function () {
		// init Isotope
		var $grid = $(".grid").isotope({
			itemSelector: ".grid-item",
			percentPosition: true,
			masonry: {
				// use outer width of grid-sizer for columnWidth
				columnWidth: ".grid-item",
			},
		});

		// filter items on button click
		$(".masonary-menu").on("click", "button", function () {
			var filterValue = $(this).attr("data-filter");
			$grid.isotope({ filter: filterValue });
		});

		//for menu active class
		$(".masonary-menu button").on("click", function (event) {
			$(this).siblings(".active").removeClass("active");
			$(this).addClass("active");
			event.preventDefault();
		});
	});

	/* magnificPopup img view */
	$(".image-popups").magnificPopup({
		type: "image",
		gallery: {
			enabled: true,
		},
	});

	/* magnificPopup video view */
	$(".popup-video").magnificPopup({
		type: "iframe",
	});

	////////////////////////////////////////////////////
	// 14. Wow Js
	new WOW().init();

	////////////////////////////////////////////////////
	// 15. Data width Js
	$("[data-width]").each(function () {
		$(this).css("width", $(this).attr("data-width"));
	});

	////////////////////////////////////////////////////
	// 16. Cart Quantity Js
	$(".cart-minus").click(function () {
		var $input = $(this).parent().find("input");
		var count = parseInt($input.val()) - 1;
		count = count < 1 ? 1 : count;
		$input.val(count);
		$input.change();
		return false;
	});
	$(".cart-plus").click(function () {
		var $input = $(this).parent().find("input");
		$input.val(parseInt($input.val()) + 1);
		$input.change();
		return false;
	});

	////////////////////////////////////////////////////
	// 17. Show Login Toggle Js
	$("#showlogin").on("click", function () {
		$("#checkout-login").slideToggle(900);
	});

	////////////////////////////////////////////////////
	// 18. Show Coupon Toggle Js
	$("#showcoupon").on("click", function () {
		$("#checkout_coupon").slideToggle(900);
	});

	////////////////////////////////////////////////////
	// 19. Create An Account Toggle Js
	$("#cbox").on("click", function () {
		$("#cbox_info").slideToggle(900);
	});

	////////////////////////////////////////////////////
	// 20. Shipping Box Toggle Js
	$("#ship-box").on("click", function () {
		$("#ship-box-info").slideToggle(1000);
	});

	////////////////////////////////////////////////////
	// 21. Counter Js
	$(".counter").counterUp({
		delay: 10,
		time: 1000,
	});

	////////////////////////////////////////////////////
	// 22. Parallax Js
	if ($(".scene").length > 0) {
		$(".scene").parallax({
			scalarX: 10.0,
			scalarY: 15.0,
		});
	}

	////////////////////////////////////////////////////
	// 23. InHover Active Js
	$(".hover__active").on("mouseenter", function () {
		$(this)
			.addClass("active")
			.parent()
			.siblings()
			.find(".hover__active")
			.removeClass("active");
	});

	if (typeof $.fn.knob != "undefined") {
		$(".knob").each(function () {
			var $this = $(this),
				knobVal = $this.attr("data-rel");

			$this.knob({
				draw: function () {
					$(this.i).val(this.cv + "%");
				},
			});

			$this.appear(
				function () {
					$({
						value: 0,
					}).animate(
						{
							value: knobVal,
						},
						{
							duration: 2000,
							easing: "swing",
							step: function () {
								$this
									.val(Math.ceil(this.value))
									.trigger("change");
							},
						}
					);
				},
				{
					accX: 0,
					accY: -150,
				}
			);
		});
	}

	// follow-artist btn
	$(".follow-artist").click(function () {
		$(this).toggleClass("followed");
		if ($(".follow-artist").hasClass("followed")) {
			$(this).html("فالو شد");
		} else {
			$(this).html("follow");
		}
	});

	// auction-active
	if (jQuery(".auction-active").length > 0) {
		let auction = new Swiper(".auction-active", {
			slidesPerView: 1,
			spaceBetween: 30,
			loop: true,
			infinite: true,
			autoplay: {
				delay: 5000,
			},
			pagination: {
				el: ".auction-pagination",
				clickable: true,
			},
			// Navigation arrows
			navigation: {
				nextEl: ".auction-button-next",
				prevEl: ".auction-button-prev",
			},

			breakpoints: {
				500: {
					slidesPerView: 1,
				},
				768: {
					slidesPerView: 2,
				},
				992: {
					slidesPerView: 3,
				},
				1200: {
					slidesPerView: 3,
				},
			},
		});
	}

	// auction2-active
	if (jQuery(".auction2-active").length > 0) {
		let auction2 = new Swiper(".auction2-active", {
			slidesPerView: 1,
			spaceBetween: 30,
			loop: true,
			infinite: true,
			autoplay: {
				delay: 5000,
			},
			pagination: {
				el: ".auction2-pagination",
				clickable: true,
			},
			// Navigation arrows
			navigation: {
				nextEl: ".auction2-button-next",
				prevEl: ".auction2-button-prev",
			},

			breakpoints: {
				500: {
					slidesPerView: 1,
				},
				768: {
					slidesPerView: 2,
				},
				992: {
					slidesPerView: 2,
				},
				1200: {
					slidesPerView: 3,
				},
			},
		});
	}

	// recent-act-active
	if (jQuery(".recent-act-active").length > 0) {
		let recentact = new Swiper(".recent-act-active", {
			slidesPerView: 1,
			spaceBetween: 10,
			loop: true,
			infinite: true,
			direction: "vertical",
			autoHeight: true,
			observer: true,
			observeParents: true,
			speed: 800,
			autoplay: {
				delay: 3000,
			},
			pagination: {
				el: ".recent-act-pagination",
				clickable: true,
			},
			// Navigation arrows
			navigation: {
				nextEl: ".recent-act-button-next",
				prevEl: ".recent-act-button-prev",
			},

			breakpoints: {
				500: {
					slidesPerView: 1,
				},
				768: {
					slidesPerView: 1,
				},
				992: {
					slidesPerView: 1,
				},
				1200: {
					slidesPerView: 1,
				},
			},
		});
	}

	// sidebar-auction-active
	if (jQuery(".sidebar-auction-active").length > 0) {
		let auction = new Swiper(".sidebar-auction-active", {
			slidesPerView: 1,
			spaceBetween: 30,
			loop: true,
			infinite: true,
			autoplay: {
				delay: 5000,
			},
			pagination: {
				el: ".auction-pagination",
				clickable: true,
			},
			// Navigation arrows
			navigation: {
				nextEl: ".auction-button-next",
				prevEl: ".auction-button-prev",
			},

			breakpoints: {
				500: {
					slidesPerView: 1,
				},
				768: {
					slidesPerView: 1,
				},
				992: {
					slidesPerView: 1,
				},
				1200: {
					slidesPerView: 1,
				},
			},
		});
	}

	// categories-bar-active
	if (jQuery(".categories-bar-active").length > 0) {
		let categories = new Swiper(".categories-bar-active", {
			slidesPerView: "auto",
			spaceBetween: 10,
			loop: true,
			infinite: true,
			autoplay: {
				delay: 5000,
			},
			pagination: {
				el: ".categories-bar-pagination",
				clickable: true,
			},
			// Navigation arrows
			navigation: {
				nextEl: ".categories-bar-button-next",
				prevEl: ".categories-bar-button-prev",
			},
		});
	}

	// countdown
	$("[data-countdown]").each(function () {
		var $this = $(this),
			finalDate = $(this).data("countdown");
		$this.countdown(finalDate, function (event) {
			$this.html(
				event.strftime(
					'<div class="count_down">%D<span></span></div><div class="count_down"> : %H<span></span></div><div class="count_down"> : %M<span></span></div><div class="count_down"> : %S<span></span></div>'
				)
			);
		});
	});

	// art-action like
	$(".art-action-like").on("click", function () {
		$(this).toggleClass("liked");
	});

	//color mode activation
	var styleMode = document.querySelector(
		'meta[name="theme-style-mode"]'
	).content;
	var cookieKey =
		styleMode == 1
			? "client_dark_mode_style_cookie"
			: "client_light_mode_style_cookie";
	if (Cookies.get(cookieKey) == "dark") {
		$("body").removeClass("active-light-mode");
		$("body").addClass("active-dark-mode");
	} else if (Cookies.get(cookieKey) == "light") {
		$("body").removeClass("active-dark-mode");
		$("body").addClass("active-light-mode");
	} else {
		if (styleMode == 1) {
			$("body").addClass("active-dark-mode");
		} else {
			$("body").addClass("active-light-mode");
		}
	}

	$(".drop-btn").on("click", function () {
		$(this).parent("").toggleClass("content-hidden");
	});

	// profile action
	$(".profile-item-header .profile-img").on("click", function () {
		$(".profile-img").toggleClass("show-element");
	});

	jQuery("body").on("click", function (e) {
		if ($(e.target).is(".profile-img")) {
			return;
		}
		if ($(".profile-img.show-element").length > 0) {
			$(".profile-img").removeClass("show-element");
		}
	});

	// art action
	$(".art-3dots-menu").on("click", function () {
		$(this).toggleClass("show-element");
	});

	jQuery("body").on("click", function (e) {
		if ($(e.target).is(".art-3dots-menu")) {
			return;
		}
		if ($(".art-3dots-menu.show-element").length > 0) {
			$(".art-3dots-menu").removeClass("show-element");
		}
	});

	// Parallax Stuff
	if ($(".stuff").length) {
		var stuff = $(".stuff").get(0);
		var parallaxInstance = new Parallax(stuff);
	}
	if ($(".stuff2").length) {
		var stuff = $(".stuff2").get(0);
		var parallaxInstance = new Parallax(stuff);
	}
	if ($(".stuff3").length) {
		var stuff = $(".stuff3").get(0);
		var parallaxInstance = new Parallax(stuff);
	}
	if ($(".stuff4").length) {
		var stuff = $(".stuff4").get(0);
		var parallaxInstance = new Parallax(stuff);
	}
	if ($(".stuff5").length) {
		var stuff = $(".stuff5").get(0);
		var parallaxInstance = new Parallax(stuff);
	}

	
})(jQuery);

