﻿(function ($) {
    var _articleCategoryService = abp.services.app.articleCategory,
        l = abp.localization.getSource('LyyCMS'),
        _$modal = $('#ArticleCategoryModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ArticleCategoryTable');
    console.log(_articleCategoryService);
    console.log(_articleCategoryService.getPagedArticleCategory);
    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            console.log("记录一下", data);
            var filter = $('#ArticleCategorySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            console.log(filter);
            abp.ui.setBusy(_$table);
            //getPagedArticleCategory
            _articleCategoryService.getAll(filter).done(function (result) {
                console.log("返回的结果:", result);
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
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'orderNum',
                sortable: false
            },
            {
                targets: 4,
                data: 'parentName',
                sortable: false
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#ArticleCategoryEditModal">`,
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
        rules: {
            Password: "required",
            ConfirmPassword: {
                equalTo: "#Password"
            }
        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject();
        //user.roleNames = [];
        //var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        //if (_$roleCheckboxes) {
        //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //        user.roleNames.push(_$roleCheckbox.val());
        //    }
        //}
        console.log(user);
        abp.ui.setBusy(_$modal);
        _articleCategoryService.createEntity(user).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

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
                    _articleCategoryService.deleteEntity({
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
        console.log("edit ...", abp.appPath);
        abp.ajax({
            url: abp.appPath + 'ArticleCategory/EditModal?id=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                console.log(abp.appPath);
                $('#ArticleCategoryEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#ArticleCategoryModal"]', (e) => {
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


    var setting = {
        view: { //效果参数
            selectedMulti: true //获取多个节点
        },
        callback: {//回调函数
            onClick: zTreeOnClick,//点击树形节点                  
        }
    }

    //获取树状数据
    //abp.ajax({
    //    url: abp.appPath + "ArticleCategory/GetArticleCategory",
    //    dataType: "JSON",
    //    type: "GET",
    //    success: function (res) {
    //        console.log("res", res);
    //        $.fn.zTree.init($("#tree"), setting, res);//初始化树形
    //    },
    //    error: function (e) {
    //        console.log(e);
    //    }
    //})

    function zTreeOnClick(event, treeId, treeNode) {
        console.log(treeId);
        console.log(treeNode);
        console.log(treeNode.id + ", " + treeNode.name);
        console.log(event);
        $("#name").html(treeNode.name);
    }


})(jQuery);
