(function ($) {
    var _articleService = abp.services.app.article,
        l = abp.localization.getSource('LyyCMS'),
        _$form = $('#ArticleCreateForm');
    console.log(_articleService);
  
    _$form.validate({
        //rules: {
        //    Password: "required",
        //    ConfirmPassword: {
        //        equalTo: "#Password"
        //    }
        //}
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var article = _$form.serializeFormToObject();
        console.log(article);
        abp.ui.setBusy(_$form);
        _articleService.createArticle(article).done(function () {
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            window.location.href = abp.appPath + 'Article/Index'
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    });
     

    $('.btn-search').on('click', (e) => {
        _$usersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$usersTable.ajax.reload();
            return false;
        }
    });


    $('input[type="file"]').change("propertychange", function () {
        console.log("add");
        abp.ui.setBusy(_$form);
        ajaxFileUpload();
        abp.ui.clearBusy(_$form);
    });
    function ajaxFileUpload() {

        var fileUpload = $("#ThumbnailFile").get(0);
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
            url: abp.appPath + 'users/UploadAvatar',
            contentType: false,
            processData: false,
            data: data,
            success: function (data) {
                console.log(JSON.stringify(data));
                //成功之后
                if (data.success) {
                    $("#Thumbnail").val(data.result);
                    $("#ThumbnailShow").attr("src", abp.appPath + data.result);
                } else {
                    console.log("失败了");
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
