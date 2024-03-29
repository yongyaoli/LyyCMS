﻿(function ($) {
    console.log(abp.services);
    var _accountSerivce = abp.services.app.weChatAccount,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#WxAccountCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#WxAccountTable');
    console.log(_accountSerivce);
    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            console.log("记录一下", data);
            var filter = $('#WxAccountSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _accountSerivce.getAll(filter).done(function (result) {
                console.log(result);
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
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'appId',
                sortable: false
            },
            {
                targets: 3,
                data: 'originalid',
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
                        `   <button type="button" class="btn btn-sm bg-secondary get-menu" data-wx-id="${row.id}">`,
                        `       <i class="fas fa-handle-alt"></i> 获取微信菜单`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary get-fanslist" data-wx-id="${row.id}">`,
                        `       <i class="fas fa-handle-alt"></i> 拉取粉丝 `,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary get-fans" data-wx-id="${row.id}">`,
                        `       <i class="fas fa-handle-alt"></i> 粉丝 `,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary get-media" data-wx-id="${row.id}">`,
                        `       <i class="fas fa-handle-alt"></i> 素材 `,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#WxAccountEditModal">`,
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

        var user = _$form.serializeFormToObject();
        
        console.log(user);
        abp.ui.setBusy(_$modal);
        _accountSerivce.create(user).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    //获取菜单
    $(document).on('click', '.get-fans', function () {
        var id = $(this).attr("data-wx-id");
        var fansUrl = abp.appPath + "WxFans/Index?id=" + id;
        console.log(fansUrl);
        window.location.href = fansUrl;
    });
    //素材
    $(document).on('click', '.get-media', function () {
        var id = $(this).attr("data-wx-id");
        var fansUrl = abp.appPath + "Material/Index?id=" + id;
        console.log(fansUrl);
        window.location.href = fansUrl;
    });

    $(document).on('click', '.get-fanslist', function () {
        var id = $(this).attr("data-wx-id");
        getWxFans(id);
    });

    function getWxFans(id) {
        abp.ajax({
            url: abp.appPath + 'WeChatAccount/GetFans?id=' + id,
            type: 'GET',
            dataType: 'JSON',
            success: function (content) {
                console.log(content);
                abp.notify.info("获取微信粉丝成功");
            },
            error: function (e) {
                abp.notify.error("获取微信粉丝失败");
            }
        });
    }

    //粉丝
    //获取菜单
    $(document).on('click', '.get-menu', function () {
        var id = $(this).attr("data-wx-id");

        getWxMenu(id);
    });

    function getWxMenu(id) {
        abp.ajax({
            url: abp.appPath + 'WeChatMenu/GetMenuFromWx?id=' + id,
            type: 'GET',
            dataType: 'JSON',
            success: function (content) {
                console.log(content);
                abp.notify.info("获取微信菜单成功");
                //$('#WxAccountEditModal div.modal-content').html(content);
            },
            error: function (e) {
                abp.notify.error("获取微信菜单失败");
            }
        });
    }



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
                    _accountSerivce.delete({
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
        console.log(abp.appPath + 'WeChatAccount/EditModal?userId=' + userId);
        abp.ajax({
            url: abp.appPath + 'WeChatAccount/EditModal?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#WxAccountEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#WxAccountCreateModal"]', (e) => {
        console.log(e);
        $('.nav-tabs a[href="#user-details"]').tab('show');
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


})(jQuery);
