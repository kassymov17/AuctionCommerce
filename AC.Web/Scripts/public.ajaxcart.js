var AjaxCart = {
    loadWaiting: false,
    usepopupnotifications: false,
    topcartselector: '',
    topwishlistselector: '',
    flyoutcartselector: '',

    init: function (usepopupnotifications, topcartselector, topwishlistselector, flyoutcartselector) {
        this.loadWaiting = false;
        this.usepopupnotifications = usepopupnotifications;
        this.topcartselector = topcartselector;
        this.topwishlistselector = topwishlistselector;
        this.flyoutcartselector = flyoutcartselector;
    },

    setLoadWaiting: function(display) {
        displayAjaxLoading(display);
        this.loadWaiting = display;
    },

    // добавить в корзину с каталога
    additemtocart_catalog: function(urladd) { 
        if (this.loadWaiting != false)
            return;

        this.setLoadWaiting(true);

        $.ajax({
            cache: false,
            url: urladd,
            type: 'post',
            success: this.success_process,
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },
    success_process: function(response) {
        
    },

    resetLoadWaiting: function() {
        AjaxCart.setLoadWaiting(false);
    },

    ajaxFailure: function() {
        alert('Не удалось добавить товар в корзину. Пожалуйста, перезагрузите страницу и попробуйте еще раз.');
    }
};