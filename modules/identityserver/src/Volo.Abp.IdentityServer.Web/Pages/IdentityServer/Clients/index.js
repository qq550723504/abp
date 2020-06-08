(function ($) {

    var l = abp.localization.getResource('AbpIdentityServer');

    var _clientAppService = volo.abp.identityServer.clients;
    var _editModal = new abp.ModalManager(abp.appPath + 'IdentityServer/Clients/EditModal');
    var _createModal = new abp.ModalManager(abp.appPath + 'IdentityServer/Clients/CreateModal');

    $(function () {

        var _$wrapper = $('#ClientsWrapper');
        var _$table = _$wrapper.find('table');
        var _dataTable = _$table.DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
			processing: true,
			serverSide: true,
            scrollX: true,
			paging: true,
            ajax: abp.libs.datatables.createAjax(_clientAppService.getList),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.Clients.Update'),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.Clients.Delete'),
                                    confirmMessage: function (data) { return l('ClientDeletionConfirmationMessage', data.record.userName); },
                                    action: function (data) {
                                        _clientAppService
                                            .delete(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    data: "clientId"
                },
                {
                    data: "clientName"
                },
                {
                    data: "description"
                },
                {
                    data: "enabled"
                }
            ]
        }));

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateClient]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });

})(jQuery);
