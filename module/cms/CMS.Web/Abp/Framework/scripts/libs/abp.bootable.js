var abp = abp || {};
(function ($) {
    if (!$ || !$.fn.bootstrapTable) {
        return;
    }

    abp.libs = abp.libs || {};

    abp.libs.bootable = {
        defaultOptions: {
            sidePagination: "server",
            queryParamsType: "limit",
            pageSize: 10,
            pageNumber: 1,
            method: "post",
            pagination: true,
            clickToSelect: true,
            idField: "id",
            sortName: "",
            search: !0,
            showRefresh: !0,
            showToggle: !0,
            showColumns: !0,
            iconSize: "outline",
            icons: {
                refresh: "glyphicon-repeat",
                toggle: "glyphicon-list-alt",
                columns: "glyphicon-list"
            },
            queryParams: function (params) { }
        }
    };

    abp.ui.createTable = function (elm, userOptions) {
        if (!userOptions || !userOptions.url)
            return;

        //合并用户输入设置和默认设置
        var options = $.extend({}, abp.libs.bootable.defaultOptions, userOptions);

        if (!!elm) {
            //设置toolbar
            var tableId = $(elm).attr("id");
            options.toolbar = abp.utils.formatString("#{0}Toolbar", tableId);
            abp.ui.setBusy(options.toolbar);

            //用户设置回调函数
            if (!!userOptions.responseHandler) {
                options.responseHandler = userOptions.responseHandler;
            }
            if (!options.responseHandler) {
                options.responseHandler = function (data) {
                    abp.ui.clearBusy(options.toolbar);
                    if (data.success) {
                        return {
                            "rows": data.result.items,
                            "total": data.result.totalCount
                        };
                    } else {
                        return {
                            "rows": [],
                            "total": 0
                        };
                    };
                };
            }

            //table元素存在
            $(elm).bootstrapTable(options);
        }


    };
})(jQuery);