

$(function () {

    var l = abp.localization.getResource('Film');
    var createModal = new abp.ModalManager(abp.appPath + 'Movies/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Movies/EditModal');
    var infoModal = new abp.ModalManager(abp.appPath + 'Movies/InfoModal');

    $('#MoviesTable thead tr')
        .clone(true)
        .addClass('filters')
        .appendTo('#MoviesTable thead');

    var dataTable = $('#MoviesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            order: [[2, 'asc']],
            processing: true,
            serverSide: true,
            scrollX: true,
            paging: true,
            searching: true,
            ajax: abp.libs.datatables.createAjax(film.movies.movie.getList),

            columnDefs: [
                {
                    title: l('logo'),
                    data: "logo",
                    orderable: false,
                    render: function (data, type, row) {
                        if (data) {
                            return `<img height="100" width="75" src="${data}"/>`;
                        }
                        else {
                            return `<div class="pl-4"></div>`;
                        }
                    }
                },
                {
                    title: l('Title'),
                    data: "title"
                },
                {
                    title: l('Year'),
                    data: "year"
                },
                {
                    title: l('Genre'),
                    data: "genre"
                },
                {
                    title: l('Director'),
                    data: "director"
                },
                {
                    title: l('Description'),
                    data: "description"
                },
                {
                    title: l('Rating'),
                    data: "rating"
                },
                {
                    title: l('Duration'),
                    data: "duration"
                },
                {
                    data: 'id',
                    render: function (data, type, row) {
                        return '<i class="fas fa-eye ml-2"/>'
                    },
                    className: 'row-info dt-center',
                    orderable: false
                },
                {
                    data: 'id',
                    render: function (data, type, row) {
                        return '<i class="fas fa-pen ml-2"/>'
                    },
                    className: 'row-edit dt-center',
                    orderable: false
                },
                {
                    data: 'id',
                    render: function (data, type, row) {
                        return '<i class="fas fa-trash ml-2"/>'
                    },
                    className: 'row-delete dt-center',
                    orderable: false
                }
            ],
            rowCallback: function (row, data) {
                $('input.editor-active', row).prop('checked', data.activa === true);
            }
        })
    );


    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    createModal.onResult(function () {
        //abp.message.success('Correcto!');
        abp.notify.success(l('Correcto!'));
    });


    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        //abp.message.success('Correcto!');
        abp.notify.success(l('Correcto!'));
    });

    $('#ButtonCreateMovie').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    //detect click info button
    $('#MoviesTable').on('click', 'tbody td.row-info', function (e) {
        var id = dataTable.cell(this, ".row-info").data();
        infoModal.open({ id: id });
    });

    //detect click edit button
    $('#MoviesTable').on('click', 'tbody td.row-edit', function (e) {
        if (abp.auth.isGranted('Film.Movie.Update')) {
            var id = dataTable.cell(this, ".row-edit").data();
            editModal.open({ id: id });
        }
        else {
            alert("You don't have permission to edit a movie!");
        }
    });

    //detect click delete button
    $('#MoviesTable').on('click', 'tbody td.row-delete', function (e) {
        if (abp.auth.isGranted('Film.Movie.Delete')) {
            var id = dataTable.cell(this, ".row-edit").data();
            abp.message.confirm('¿Quiere eliminar?')
                .then(function (confirmed) {
                    if (confirmed) {
                        film.movies.movie
                            .delete(id)
                            .then(function () {
                                abp.notify.success(l('SuccessfullyDeleted'));
                                dataTable.ajax.reload();
                            });
                    }
                });
        }
        else {
            alert("You don't have permission to delete a movie!");
        }
    });
});
