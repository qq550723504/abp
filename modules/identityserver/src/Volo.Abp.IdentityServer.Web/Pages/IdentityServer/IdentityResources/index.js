(function ($) {

    var l = abp.localization.getResource('AbpIdentityServer');

    var _identityResourceAppService = volo.abp.identityServer.identityResources;
    var _editModal = new abp.ModalManager(abp.appPath + 'IdentityServer/IdentityResources/EditModal');
    var _createModal = new abp.ModalManager(abp.appPath + 'IdentityServer/IdentityResources/CreateModal');

    $(function () {

        var _$wrapper = $('#IdentityResourcesWrapper');
        var _$table = _$wrapper.find('table');
        var _dataTable = _$table.DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
			processing: true,
			serverSide: true,
            scrollX: true,
			paging: true,
            ajax: abp.libs.datatables.createAjax(_identityResourceAppService.getList),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.IdentityResources.Update'),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.IdentityResources.Delete'),
                                    confirmMessage: function (data) { return l('IdentityResourceDeletionConfirmationMessage', data.record.userName); },
                                    action: function (data) {
                                        _identityResourceAppService
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
                    data: "name"
                },
                {
                    data: "displayName"
                },
                {
                    data: "description"
                }
            ]
        }));

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateIdentityResource]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });

})(jQuery);
