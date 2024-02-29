!(function (e) {
    "use strict";
    if (
        (e(window).on("load", function () {
            e(".preloader").fadeOut();
        }),
        e(".preloader").length > 0 &&
            e(".preloaderCls").each(function () {
                e(this).on("click", function (t) {
                    t.preventDefault(), e(".preloader").css("display", "none");
                });
            }),
        (e.fn.otmobilemenu = function (t) {
            var a = e.extend(
                {
                    menuToggleBtn: ".ot-menu-toggle",
                    bodyToggleClass: "ot-body-visible",
                    subMenuClass: "ot-submenu",
                    subMenuParent: "ot-item-has-children",
                    subMenuParentToggle: "ot-active",
                    meanExpandClass: "ot-mean-expand",
                    appendElement: '<span class="ot-mean-expand"></span>',
                    subMenuToggleClass: "ot-open",
                    toggleSpeed: 400,
                },
                t
            );
            return this.each(function () {
                var t = e(this);
                function n() {
                    t.toggleClass(a.bodyToggleClass);
                    var n = "." + a.subMenuClass;
                    e(n).each(function () {
                        e(this).hasClass(a.subMenuToggleClass) && (e(this).removeClass(a.subMenuToggleClass), e(this).css("display", "none"), e(this).parent().removeClass(a.subMenuParentToggle));
                    });
                }
                t.find("li").each(function () {
                    var t = e(this).find("ul");
                    t.addClass(a.subMenuClass), t.css("display", "none"), t.parent().addClass(a.subMenuParent), t.prev("a").append(a.appendElement), t.next("a").append(a.appendElement);
                });
                var s = "." + a.meanExpandClass;
                e(s).each(function () {
                    e(this).on("click", function (t) {
                        var n;
                        t.preventDefault(),
                            (n = e(this).parent()),
                            e(n).next("ul").length > 0
                                ? (e(n).parent().toggleClass(a.subMenuParentToggle), e(n).next("ul").slideToggle(a.toggleSpeed), e(n).next("ul").toggleClass(a.subMenuToggleClass))
                                : e(n).prev("ul").length > 0 && (e(n).parent().toggleClass(a.subMenuParentToggle), e(n).prev("ul").slideToggle(a.toggleSpeed), e(n).prev("ul").toggleClass(a.subMenuToggleClass));
                    });
                }),
                    e(a.menuToggleBtn).each(function () {
                        e(this).on("click", function () {
                            n();
                        });
                    }),
                    t.on("click", function (e) {
                        e.stopPropagation(), n();
                    }),
                    t.find("div").on("click", function (e) {
                        e.stopPropagation();
                    });
            });
        }),
        e(".ot-menu-wrapper").otmobilemenu(),
        e(window).scroll(function () {
            e(this).scrollTop() > 500 ? (e(".sticky-wrapper").addClass("sticky"), e(".category-menu").addClass("close-category")) : (e(".sticky-wrapper").removeClass("sticky"), e(".category-menu").removeClass("close-category"));
        }),
        e(".scroll-top").length > 0)
    ) {
        var t = document.querySelector(".scroll-top"),
            a = document.querySelector(".scroll-top path"),
            n = a.getTotalLength();
        (a.style.transition = a.style.WebkitTransition = "none"),
            (a.style.strokeDasharray = n + " " + n),
            (a.style.strokeDashoffset = n),
            a.getBoundingClientRect(),
            (a.style.transition = a.style.WebkitTransition = "stroke-dashoffset 10ms linear");
        var s = function () {
            var t = e(window).scrollTop(),
                s = e(document).height() - e(window).height(),
                o = n - (t * n) / s;
            a.style.strokeDashoffset = o;
        };
        s(), e(window).scroll(s);
        jQuery(window).on("scroll", function () {
            jQuery(this).scrollTop() > 50 ? jQuery(t).addClass("show") : jQuery(t).removeClass("show");
        }),
            jQuery(t).on("click", function (e) {
                return e.preventDefault(), jQuery("html, body").animate({ scrollTop: 0 }, 750), !1;
            });
    }
    e("[data-bg-src]").length > 0 &&
        e("[data-bg-src]").each(function () {
            var t = e(this).attr("data-bg-src");
            e(this).css("background-image", "url(" + t + ")"), e(this).removeAttr("data-bg-src").addClass("background-image");
        }),
        e("[data-bg-color]").length > 0 &&
            e("[data-bg-color]").each(function () {
                var t = e(this).attr("data-bg-color");
                e(this).css("background-color", t), e(this).removeAttr("data-bg-color");
            }),
        e("[data-mask-src]").length > 0 &&
            e("[data-mask-src]").each(function () {
                var t = e(this).attr("data-mask-src");
                e(this).css({ "mask-image": "url(" + t + ")", "-webkit-mask-image": "url(" + t + ")" }), e(this).addClass("bg-mask"), e(this).removeAttr("data-mask-src");
            }),
        e(".ot-slider").each(function () {
            var t = e(this),
                a = e(this).data("slider-options"),
                n = t.find(".slider-prev"),
                s = t.find(".slider-next"),
                o = t.find(".slider-pagination"),
                i = a.autoplay,
                l = {
                    slidesPerView: a.slidesPerView ? a.slidesPerView : 1,
                    spaceBetween: a.spaceBetween ? a.spaceBetween : 24,
                    loop: 0 != a.loop,
                    speed: a.speed ? a.speed : 1e3,
                    autoplay: i || { delay: 6e3, disableOnInteraction: !1 },
                    navigation: { nextEl: s.get(0), prevEl: n.get(0) },
                    pagination: {
                        el: o.get(0),
                        clickable: !0,
                        renderBullet: function (e, t) {
                            return '<span class="' + t + '" aria-label="Go to Slide ' + (e + 1) + '"></span>';
                        },
                    },
                },
                r = JSON.parse(t.attr("data-slider-options"));
            r = e.extend({}, l, r);
            new Swiper(t.get(0), r);
            e(".slider-area").length > 0 && e(".slider-area").closest(".container").parent().addClass("arrow-wrap");
        }),
        e("[data-ani]").each(function () {
            var t = e(this).data("ani");
            e(this).addClass(t);
        }),
        e("[data-ani-delay]").each(function () {
            var t = e(this).data("ani-delay");
            e(this).css("animation-delay", t);
        }),
        e("[data-slider-prev], [data-slider-next]").on("click", function () {
            var t = e(this).data("slider-prev") || e(this).data("slider-next"),
                a = e(t);
            if (a.length) {
                var n = a[0].swiper;
                n && (e(this).data("slider-prev") ? n.slidePrev() : n.slideNext());
            }
        });
    new Swiper(".swiper-newsticker", { spaceBetween: 130, slidesPerView: "auto", speed: 4e3, autoplay: { delay: 2, disableOnInteraction: !1 }, loop: !0, allowTouchMove: !1, disableOnInteraction: !0 });
    var o,
        i,
        l,
        r = ".ajax-contact",
        c = '[name="email"]',
        d = e(".form-messages");
    function u() {
        var t = e(r).serialize();
        (function () {
            var t,
                a = !0;
            function n(n) {
                n = n.split(",");
                for (var s = 0; s < n.length; s++) (t = r + " " + n[s]), e(t).val() ? (e(t).removeClass("is-invalid"), (a = !0)) : (e(t).addClass("is-invalid"), (a = !1));
            }
            n('[name="name"],[name="email"],[name="subject"],[name="number"],[name="message"]'),
                e(c).val() &&
                e(c)
                    .val()
                    .match(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/)
                    ? (e(c).removeClass("is-invalid"), (a = !0))
                    : (e(c).addClass("is-invalid"), (a = !1));
            return a;
        })() &&
            jQuery
                .ajax({ url: e(r).attr("action"), data: t, type: "POST" })
                .done(function (t) {
                    d.removeClass("error"), d.addClass("success"), d.text(t), e(r + ' input:not([type="submit"]),' + r + " textarea").val("");
                })
                .fail(function (e) {
                    d.removeClass("success"), d.addClass("error"), "" !== e.responseText ? d.html(e.responseText) : d.html("Oops! An error occured and your message could not be sent.");
                });
    }
    e(r).on("submit", function (e) {
        e.preventDefault(), u();
    }),
        (o = ".sidemenu-info"),
        (i = ".sideMenuCls"),
        (l = "show"),
        e(".sideMenuInfo").on("click", function (t) {
            t.preventDefault(), e(o).addClass(l);
        }),
        e(o).on("click", function (t) {
            t.stopPropagation(), e(o).removeClass(l);
        }),
        e(o + " > div").on("click", function (t) {
            t.stopPropagation(), e(o).addClass(l);
        }),
        e(i).on("click", function (t) {
            t.preventDefault(), t.stopPropagation(), e(o).removeClass(l);
        }),
        e(".popup-image").magnificPopup({ type: "image", mainClass: "mfp-zoom-in", removalDelay: 260, gallery: { enabled: !0 } }),
        e(".popup-video").magnificPopup({ type: "iframe", mainClass: "mfp-zoom-in", removalDelay: 260 }),
        e(".popup-content").magnificPopup({ type: "inline", midClick: !0, mainClass: "mfp-zoom-in", removalDelay: 260 }),
        e(".filter-active").imagesLoaded(function () {
            if (e(".filter-active").length > 0) {
                var t = e(".filter-active").isotope({ itemSelector: ".filter-item", filter: "*", masonry: { columnWidth: 1 } });
                e(".filter-menu-active").on("click", "button", function () {
                    var a = e(this).attr("data-filter");
                    t.isotope({ filter: a });
                }),
                    e(".filter-menu-active").on("click", "button", function (t) {
                        t.preventDefault(), e(this).addClass("active"), e(this).siblings(".active").removeClass("active");
                    });
            }
        }),
        e(".counter-number").counterUp({ delay: 10, time: 1e3 }),
        e(".counter-number2").counterUp({ delay: 25, time: 1600 }),
        (e.fn.shapeMockup = function () {
            e(this).each(function () {
                var t = e(this),
                    a = t.data("top"),
                    n = t.data("right"),
                    s = t.data("bottom"),
                    o = t.data("left");
                t.css({ top: a, right: n, bottom: s, left: o }).removeAttr("data-top").removeAttr("data-right").removeAttr("data-bottom").removeAttr("data-left").parent().addClass("shape-mockup-wrap");
            });
        }),
        e(".shape-mockup") && e(".shape-mockup").shapeMockup(),
        e(".progress-bar").waypoint(
            function () {
                e(".progress-bar").css({ animation: "animate-positive 2.6s", opacity: "1" });
            },
            { offset: "75%" }
        )
})(jQuery);
