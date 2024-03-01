namespace Application.Layout.Components_Layout.NavMenu;

public partial class NavMenu
{
    private IJSObjectReference? module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/vendor/jquery-3.6.0.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/vendor/waypoints.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/bootstrap.bundle.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/meanmenu.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/swiper-bundle.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/owl.carousel.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/magnific-popup.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/parallax.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/backToTop.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/cookie.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/style-switcher.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/nice-select.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/parallax.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/counterup.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/jquery.countdown.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/ajax-form.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/wow.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/isotope.pkgd.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/imagesloaded.pkgd.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./assets/js/main.js");

            await module!.InvokeVoidAsync(identifier: "DOMCleanup.createObserver");
        }
    }
}
