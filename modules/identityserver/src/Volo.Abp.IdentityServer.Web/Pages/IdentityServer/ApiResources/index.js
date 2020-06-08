(function ($) {

    var l = abp.localization.getResource('AbpIdentityServer');

    var _apiResourceAppService = volo.abp.identityServer.apiResources;
    var _editModal = new abp.ModalManager(abp.appPath + 'IdentityServer/ApiResources/EditModal');
    var _createModal = new abp.ModalManager(abp.appPath + 'IdentityServer/ApiResources/CreateModal');

    $(function () {

        var _$wrapper = $('#ApiResourcesWrapper');
        var _$table = _$wrapper.find('table');
        var _dataTable = _$table.DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
			processing: true,
			serverSide: true,
            scrollX: true,
			paging: true,
            ajax: abp.libs.datatables.createAjax(_apiResourceAppService.getList),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.ApiResources.Update'),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AbpIdentityServer.ApiResources.Delete'),
                                    confirmMessage: function (data) { return l('ApiResourceDeletionConfirmationMessage', data.record.userName); },
                                    action: function (data) {
                                        _apiResourceAppService
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

        _$wrapper.find('button[name=CreateApiResource]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });

})(jQuery);
