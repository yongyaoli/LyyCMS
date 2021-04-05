(function ($) {
    var _appService = abp.services.app.articleCategory,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#ArticleCategoryEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var articleCategory = _$form.serializeFormToObject();
        //user.roleNames = [];
        articleCategory.parentId = 0;
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='parent']:checked");
        if (_$roleCheckboxes) {
            console.log(_$roleCheckboxes);
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                //user.parentId.push(_$roleCheckbox.val());
                articleCategory.parentId = _$roleCheckbox.val();
            }
        }
        console.log(articleCategory);

        abp.ui.setBusy(_$form);
        _appService.updateEntry(articleCategory).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('user.edited', articleCategory);
            console.log("修改后", articleCategory);
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
