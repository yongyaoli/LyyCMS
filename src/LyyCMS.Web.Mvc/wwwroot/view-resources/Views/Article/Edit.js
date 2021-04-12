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