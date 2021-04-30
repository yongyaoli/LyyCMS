(function ($) {
    var _appService = abp.services.app.article,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#articleEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var article = _$form.serializeFormToObject();
        //user.roleNames = [];
        //article.parentId = 0;
        //var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='parent']:checked");
        //if (_$roleCheckboxes) {
        //    console.log(_$roleCheckboxes);
        //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //        //user.parentId.push(_$roleCheckbox.val());
        //        article.parentId = _$roleCheckbox.val();
        //    }
        //}
        console.log(article);

        abp.ui.setBusy(_$form);

        return false;
        _appService.updateEntry(article).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('user.edited', article);
            console.log("修改后", article);
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
