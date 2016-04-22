(function () {
    var onSelectManager = function (e) {
        $el = $(e.target);
        var filter = $el.find("option:selected").attr("value");
        console.log("Filter = " + filter);

        $.ajax({
            type: "get",
            url: "/Order/FilterByManager",
            dataType: "html",
            data: "filterContext=" + e.target.value
        })
            .done(function (data) {
                console.log("ajax filter is done!" + data);
                $("#orders").html(data);
            })
            .fail(function () {
                console.log("ajax filter is FAIL");
            });
    };

    var initManagerFilter = function () {
        $("#manager").on("change", onSelectManager);
        console.log("Status: filter init is fine");
    };

    $(function () {
        initManagerFilter();
        console.log("order.js is loaded");
    });
})();