console.log("*************************");
(function ($) {
    
});

console.log("1111111111111");
var _articleService = abp.services.app.article,
    l = abp.localization.getSource('LyyCMS'),
    _$form = $('#ArticleEditForm');
console.log(_articleService);
console.log(_$form);
console.log("article edit");
_$form.find('.save-button').on('click', (e) => {
    e.preventDefault();

    if (!_$form.valid()) {
        return;
    }
    console.log("提交");

    var article = _$form.serializeFormToObject();
    console.log(article);
    abp.ui.setBusy(_$form);
    _articleService.updateEntry(article).done(function () {
        abp.notify.info(l('SavedSuccessfully'));
        var url = abp.appPath + "Article/Index";
        console.log(url);
        window.location.href = url;
    }).always(function () {
        abp.ui.clearBusy(_$form);
    });
});

_$form.find(".close-button").on("click", (e) => {
    window.location.href = abp.appPath + "Article/Index";
})

$('input[type="file"]').change("propertychange", function () {
    console.log("add");
    ajaxFileUpload();
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
        url: 'users/UploadAvatar',
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            console.log(JSON.stringify(data));
            //成功之后
            if (data.success) {
                $("#Thumbnail").val(data.result);
                $("#ThumbnailShow").attr("src", data.result);
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