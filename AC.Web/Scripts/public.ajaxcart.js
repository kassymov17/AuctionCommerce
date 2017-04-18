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
        if (response.updatetopcartsectionhtml) {
            $(AjaxCart.topcartselector).html(response.updatetopcartsectionhtml);
        }

        if (response.updatetopwishlistsectionhtml) {
            $(AjaxCart.topwishlistselector).html(response.updatetopwishlistsectionhtml);
        }

        if (response.updateflyoutcartsectionhtml) {
            $(AjaxCart.flyoutcartselector).html(response.updateflyoutcartsectionhtml);
        }

        if (response.message) {
            // показать уведомления
            if (response.success == true) {
                // успешно
                if (AjaxCart.usepopupnotifications == true) {
                    displayPopupNotification(response.message, 'success', true);
                } else {
                    displayBarNotification(response.message, 'success', 3500);
                }
            }
            else {
                // ошибка
                if (AjaxCart.usepopupnotifications == true) {
                    displayPopupNotification(response.message, 'error', true);
                }
                else {
                    displayBarNotification(response.message, 'error', 0);
                }
            }
            return false;
        }
        if (response.redirect) {
            location.href = response.redirect;
            return true;
        }
        return false;
    },

    resetLoadWaiting: function() {
        AjaxCart.setLoadWaiting(false);
    },

    ajaxFailure: function() {
        alert('Не удалось добавить товар в корзину. Пожалуйста, перезагрузите страницу и попробуйте еще раз.');
    }
};