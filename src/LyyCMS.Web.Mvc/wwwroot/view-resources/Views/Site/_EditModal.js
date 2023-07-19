﻿(function ($) {
    var _siteService = abp.services.app.site,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#SiteEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var slide = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        _siteService.updateEntry(slide).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));

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

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
