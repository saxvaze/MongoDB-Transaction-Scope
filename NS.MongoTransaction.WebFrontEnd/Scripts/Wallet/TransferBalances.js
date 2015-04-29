window.onload = function () {
    var transferAmountForm = document.getElementById("transfer-amount-form");
    var transferAmountFormInputs = transferAmountForm.getElementsByTagName("input");

    for (var i = 0; i < transferAmountFormInputs.length; i++) {
        if (transferAmountFormInputs[i].getAttribute("type") == "text") {
            transferAmountFormInputs[i].onkeyup = function (e) {
                if (e.target.value.length >= 11 && Number(e.target.value) > 0) {
                    var targetElement = e.target.parentNode.parentNode;
                    targetElement = targetElement.childNodes;
                    targetElement = targetElement[5];
                    targetElement = targetElement.childNodes;
                    targetElement = targetElement[1];
                    targetElement = targetElement.childNodes;
                    targetElement = targetElement[1];

                    var a = $.ajax({
                        url: document.getElementById("get-username-by-personal-number-url").value,
                        data: { personalNumber: e.target.value },
                        method: "POST",
                        success: function (e) {
                            if (e.length > 0)
                                targetElement.innerHTML = e;
                        }
                    });
                }
            };
        }
    }
}