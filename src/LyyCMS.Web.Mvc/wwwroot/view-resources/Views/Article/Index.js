(function ($) {
    var _articleService = abp.services.app.article,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#ArticleModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ArticleTable');
    console.log(_articleService);
    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            console.log("记录一下", data);
            var filter = $('#ArticleSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _articleService.getPagedArticle(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$usersTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'source',
                sortable: false
            },
            {
                targets: 3,
                data: 'categoryName',
                sortable: false
            },
            {
                targets: 4,
                data: 'red',
                sortable: false
            },
            {
                targets: 5,
                data: 'status',
                sortable: false
            },
            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        //`   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#ArticleEditModal">`,
                        //`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        //'   </button>',
                        `<a asp-action="Edit" asp-route-id="${row.id}"> </a>`,
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user-page" data-user-id="${row.id}">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

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
        abp.ui.setBusy(_$modal);
        _articleService.createArticle(article).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on("click", ".edit-user-page", function () {
        var id = $(this).attr("data-user-id");
        var editurl = "/artilce/edit/" + id;
        var url = abp.appPath + 'Article/Edit?id=' + id;
        console.log(editurl, url);
        window.location.href=url;
    })

    $(document).on('click', '.delete-user', function () {
        var userId = $(this).attr("data-user-id");
        var userName = $(this).attr('data-user-name');

        deleteUser(userId, userName);
    });

    function deleteUser(userId, userName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                userName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _articleService.delete({
                        id: userId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$usersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-user', function (e) {
        var id = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Article/EditModal?id=' + id,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ArticleEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#ArticleCreateModal"]', (e) => {
        console.log(e);
        $('.nav-tabs a[href="#user-details"]').tab('show')
    });

    abp.event.on('user.edited', (data) => {
        _$usersTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
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
