(function ($) {
    var _userService = abp.services.app.user,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#UserEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject();
        user.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                user.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$form);
        _userService.update(user).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('user.edited', user);
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


    $('input[type="file"]').change("propertychange", function () {
        console.log("edit")
        ajaxFileUpload();
    });
    function ajaxFileUpload() {

        var fileUpload = $("#FaceImgFileEdit").get(0);
        console.log(fileUpload);
        var files = fileUpload.files;
        console.log(files);
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        console.log(data);
        if (files.length < 1) {
            console.log("没有数据");
            return false;
        }

        $.ajax({
            type: "POST",
            url: 'users/UploadAvatar',
            contentType: false,
            processData: false,
            data: data,
            success: function (data) {
                console.log(JSON.stringify(data));
                //成功之后
                if (data.success) {
                    console.log(data.result);
                    //$("#FaceImg").val(data.result);
                    $('input[name="FaceImg"]').val(data.result);
                    $("#FaceImgEditShow").attr("src", data.result);
                } else {
                    abp.notify.info(l('SavedSuccessfully'));
                }

            },
            error: function () {
                console.log(JSON.stringify(data));
            }
        });

        $('input[type="file"]').change(function (e) {//再次绑定
            ajaxFileUpload();
        })
        return false;
    }
})(jQuery);
