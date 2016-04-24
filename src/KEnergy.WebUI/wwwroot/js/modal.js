//ToDo

var orderApp;

(function () {
    orderApp.intOrderModal = function () {
        console.log('Init order is fine');
        $("#orderForm").validate({
            rules: {
                number: { required: true }
            },
            messages: {
                number: "Number field is required"
            },
            errorContainer: "#validationSummary",
            errorLabelContainer: "#validationSummary ul",
            wrapper: "li",
            submitHandler: function (form) {
                saveOrder($(form));
            }
        });
    };

    $("#orderEditor").on("click", function () {
        var orderId = $(this).data('orderId');
        $.ajax({
            url: "/article/get/" + orderId,
            cache: false
        }).done(function (data) {
            $("#orderId").val(data.orderId);
            $("#number").val(data.number);
            $("#shipment").val(data.shipment);
            $("#managerId").val(data.managerId);
        });

        console.log('On click');
        console.log(data);
    });

    orderApp.saveOrder = function (form) {
        var url = "/Order/SaveModal";
        var postData = form.serialize();
        $.post(url, postData, function (data) {
            if (data.toLowerCase() == "ok") {
                alert("Data saved!");
                return;
            }
            alert("Something went wrong. Please retry!");
        });
    };
})();

$(document).ready(function () {
    console.log('Document ready');
    orderApp.initOrderModal();
});