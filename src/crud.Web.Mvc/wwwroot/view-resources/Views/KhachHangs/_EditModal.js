﻿(function ($) {
    debugger
    var _khachHangService = abp.services.app.khachHang,
        l = abp.localization.getSource('crud'),
        _$modal = $('#KhachHangEditModal'),
        _$form = _$modal.find('form');
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var khachHang = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        _khachHangService.update(khachHang).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('khachhang.edited', khachHang);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });
})(jQuery);
