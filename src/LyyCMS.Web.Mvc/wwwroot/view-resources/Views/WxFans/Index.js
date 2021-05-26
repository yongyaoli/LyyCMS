(function ($) {
    var _wxfansService = abp.services.app.wxFansInfo,
        l = abp.localization.getSource('LyyCMS'),
        //_$modal = $('#UserCreateModal'),
        //_$form = _$modal.find('form'),
        _$table = $('#WxFansTable');
    console.log(_wxfansService);
    var accountId = getQueryVariable("id");
    console.log(accountId);

    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            console.log("记录一下", data);
            var filter = $('#UsersSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            //_wxfansService.getFansByAccount(filter)
            _wxfansService.getFansByAccount(accountId).done(function (result) {
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
                data: 'openid',
                sortable: false
            },
            {
                targets: 2,
                data: 'nickName',
                sortable: false
            },
            {
                targets: 3,
                data: 'sex',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#UserEditModal">`,
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

    //_$form.validate({
    //    rules: {
    //        Password: "required",
    //        ConfirmPassword: {
    //            equalTo: "#Password"
    //        }
    //    }
    //});

    //_$form.find('.save-button').on('click', (e) => {
    //    e.preventDefault();

    //    if (!_$form.valid()) {
    //        return;
    //    }

    //    var user = _$form.serializeFormToObject();
    //    user.roleNames = [];
    //    var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
    //    if (_$roleCheckboxes) {
    //        for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
    //            var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
    //            user.roleNames.push(_$roleCheckbox.val());
    //        }
    //    }
    //    console.log(user);
    //    abp.ui.setBusy(_$modal);
    //    _wxfansService.create(user).done(function () {
    //        _$modal.modal('hide');
    //        _$form[0].reset();
    //        abp.notify.info(l('SavedSuccessfully'));
    //        _$usersTable.ajax.reload();
    //    }).always(function () {
    //        abp.ui.clearBusy(_$modal);
    //    });
    //});

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
                    _wxfansService.delete({
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
        var userId = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Users/EditModal?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#UserEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#UserCreateModal"]', (e) => {
        console.log(e);
        $('.nav-tabs a[href="#user-details"]').tab('show');
    });

    abp.event.on('user.edited', (data) => {
        _$usersTable.ajax.reload();
    });

    //_$modal.on('shown.bs.modal', () => {
    //    _$modal.find('input:not([type=hidden]):first').focus();
    //}).on('hidden.bs.modal', () => {
    //   // _$form.clearForm();
    //});

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

        var fileUpload = $("#FaceImgFile").get(0);
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
                    $("#FaceImg").val(data.result);
                    $("#FaceImgShow").attr("src", data.result);
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


    function getQueryVariable(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) { return pair[1]; }
        }
        return (false);
    }
})(jQuery);
