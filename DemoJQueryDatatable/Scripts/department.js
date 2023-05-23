

        var typeOfAction = null;

        /*Add a new department*/
        $(document).ready(function () {
            $('#btn-save').click(function () {
                var DEPARTMENTNAME = $('#txtDepartmentName').val();
                if (DEPARTMENTNAME === '') {
                    alert('Vui lòng nhập tên phòng ban!');
                } else {
                    if (typeOfAction === 'Create') {
                        $.ajax({
                            url: '@Url.Action("Create", "Department")',
                            type: 'POST',
                            data: { name: DEPARTMENTNAME },
                            datatype: 'JSON',
                            encode: true,
                            success: function (result) {
                                if (result.success) {
                                    alert(result.message);
                                    $("#create-department").hide();
                                    $('#form-create').trigger('reset');
                                    $('#modal-delete-department').trigger('reset');
                                    loadData();
                                    $("#department-container").show();
                                } else {
                                    alert('Thêm dữ liệu thất bại!');
                                }
                            },
                            error: function () {
                                alert('Đã xảy ra lỗi!');
                            }
                        });
                    } else {
                        var name = $('#txtDepartName').val();
                        $.ajax({
                            url: '@Url.Action("Edit", "Department")',
                            type: 'POST',
                            data: { id: idEdit.toString(), name: DEPARTMENTNAME },
                            datatype: 'JSON',
                            encode: true,
                            success: function (result) {
                                if (result.success) {
                                    alert(result.message);
                                    $("#create-department").hide();
                                    $('#form-create').trigger('reset');
                                    $('#modal-delete-department').trigger('reset');
                                    loadData();
                                    $("#department-container").show();
                                } else {
                                    alert('Thêm dữ liệu thất bại!');
                                }
                            },
                        })
                    }
                }
            });
        });


        /*Edit the Department*/
        var idEdit = 0;
        $(document).on('click', '.btn-edit-department', function () {
            typeOfAction = 'Update';
        var btnEdit = $(this);
        idEdit = btnEdit.data('id');
        if (idEdit == 0) {
            alert('404 Not found!');
            } else {
            alert('Edit ' + idEdit);
        $("#department-container").hide();
        $("#create-department").removeAttr("hidden");
        $("#create-department").show();
        $.ajax({
            url: '@Url.Action("Edit", "Department")',
        type: 'GET',
        datatype: 'JSON',
        data: {idEdit: idEdit},
        success: function (data) {
            $('#txtDepartmentName').val(data.data.DEPARTMENTNAME);
                    },
        error: function () {
            console.log('Error fetching data');
                    }
                })
            }
        });





        /*Delete the Department in datatable*/
        var id = 0;
        $(document).on('click', '.btn-delete-department', function () {
            var btnDelete = $(this);
        id = btnDelete.data('id');
        alert('Delete ' + id)
        })

        $("#btn-valid-delete").click(function () {
            $.ajax({
                url: '@Url.Action("Delete", "Department")',
                type: 'POST',
                data: { id: id },
                datatype: 'JSON',
                encode: true,
                success: function (result) {
                    loadData();
                    alert(result.message);
                },
                error: function () {
                    alert('Xóa xảy ra lỗi!')
                }
            });
            });



        /*Using AJAX to display data of DEPARTMENT TABLE*/
        var table = $("#tblDepartment").DataTable({
            "ajax": {
            "url": '@Url.Action("GetData", "Department")',
        "type": "GET",
        "datatype": "json"
            },
        "columns": [
        {
            "data": "departmentID",
        "title": 'ID',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "departmentName",
        "title": 'Name',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "createdBy",
        "title": 'Created by',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "createdDate",
        "title": 'Created date',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "updatedBy",
        "title": 'Updated by',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "updatedDate",
        "title": 'Updated date',
        "autoWidth": true,
        "searchable": true
                },
        {
            "data": "departmentID",
        "title": "Action",
        "autoWidth": true,
        "searchable": true,
        "render": function (data, type) {
                        return type === 'display' ? '<div class="container d-inline-flex"><a data-id="' + data + '" class="btn btn-primary text-light btn-m btn-edit-department" role="button"> Edit </a> <a data-id="' + data + '" class="btn-delete-department btn btn-danger btn-m ml-1" role="button" href="@Url.Action(" Delete")" data-toggle="modal" data-target="#modal-delete-department"> Delete </a></div>' : data;
}
                },
            ]
        });


/*Method reload datatable*/
function loadData() {
    table.ajax.reload();
}

/*This method wil be call to load data from database to datatable when user click at Department Management*/
loadData();


        /*Processing when Create New Button is clicked*/
        $('#btn-add-department').click(function () {
            typeOfAction = 'Create';
        $("#department-container").hide();
        $("#create-department").removeAttr("hidden");
        $("#create-department").show();
        });

        /* Processing when Cancel Button is clicked */
        $('#btn-cancel').click(function () {
            loadData();
        $("#department-container").show();
        $("#create-department").hide();
        });