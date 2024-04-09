(function ($) {
    var _khachHangService = abp.services.app.khachHang,
        l = abp.localization.getSource('crud'),
        _$modal = $('#KhachHangCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#KhachHangsTable');
    var _$khachHangsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#KhachHangsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            if (filter.date) {
                var splitTime = filter.date.split("-");
                var startTime = splitTime[0].trim().split("/");
                var endTime = splitTime[1].trim().split("/");
                filter.startTime = startTime[1] + "/" + startTime[0] + "/" + startTime[2];
                filter.endTime = endTime[1] + "/" + endTime[0] + "/" + endTime[2];
            }
            abp.ui.setBusy(_$table);
            _khachHangService.getAllList(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result,
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$khachHangsTable.draw(false)
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
                data: 'userName',
                sortable: false
            },
            {
                targets: 2,
                data: 'displayName',
                sortable: false
            },
            {
                targets: 3,
                data: 'ngaySinh',
                sortable: false,
                render: (data) => {
                    const date = new Date(data);
                    return ('0' + date.getDate()).slice(-2) + '/' + ('0' + (date.getMonth() + 1)).slice(-2) + '/' + date.getFullYear();
                }
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-khachHang" data-khachhang-username="${row.userName}" data-toggle="modal" data-target="#KhachHangEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-khachHang" data-khachHang-username="${row.userName}" data-khachhang-displayname="${row.displayName}">`,
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

        abp.ui.setBusy(_$modal);
        var dateParts = _$form.find("#ngaySinh").val().split("/");
        var newKhachHang = {
            UserName: _$form.find("#username").val(),
            DisplayName: _$form.find("#displayname").val(),
            NgaySinh: dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2],
        };
        
        _khachHangService.create(newKhachHang).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$khachHangsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-khachHang', function () {
        var userName = $(this).attr("data-khachhang-username");
        var displayName = $(this).attr('data-khachhang-displayname');
        deleteKhachHang(userName, displayName);
    });

    function deleteKhachHang(userName, displayName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                displayName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _khachHangService.delete({userName: userName }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$khachHangsTable.ajax.reload();
                    });
                }
            }
        );
    }
    $(document).on('click', '.edit-khachHang', function (e) {
        var userName = $(this).attr("data-khachhang-username");
        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'KhachHang/EditModal?userName=' + userName,
            type: 'POST',
            dataType: 'html',
            success: (content) => {
                $('#KhachHangEditModal div.modal-content').html(content);
            }
        })
       
    });

    /*$(document).on('click', 'a[data-target="#KhachHangCreateModal"]', (e) => {
        $('.nav-tabs a[href="#khachhang-details"]').tab('show')
    });*/

    abp.event.on('khachHang.edited', (data) => {
        _$khachHangsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$khachHangsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$khachHangsTable.ajax.reload();
            return false;
        }
    });
    _$form.find("#ngaySinh").datepicker({
        dateFormat: "dd/mm/yy"
    });
    $("#date-search").daterangepicker({
        opens: 'right',
        autoUpdateInput: false,
        locale: {
            format: "DD/MM/YYYY"
        }
    });
    $("#date-search").on("apply.daterangepicker", function (ev, picker) {
        $(this).val(picker.startDate.format('DD/MM/YYYY') + ' - ' + picker.endDate.format('DD/MM/YYYY'));
    });
    $("#date-search").on("cancel.daterangepicker", function (ev, picker) {
        $(this).val('');
    });
    $("#date-search").on("keydown", (e) => {
        e.preventDefault();
    })
    _$form.find("#ngaySinh").on("keydown", (e) => {
        e.preventDefault();
    })

        
})(jQuery);
