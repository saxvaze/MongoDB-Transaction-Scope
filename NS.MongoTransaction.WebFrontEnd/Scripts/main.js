window.onload = function () {
    var mainNavToggler = document.getElementsByClassName("responsive-menu-toggler")[0];

    mainNavToggler.addEventListener("click", function (e) {
        var targetClassesArray = this.getAttribute("class").split(" ");

        if (targetClassesArray.length > 1) {
            this.removeAttribute("class");

            var newClass = document.createAttribute('class');
            newClass.value = targetClassesArray[0];
            this.setAttributeNode(newClass);

            var mainNav = document.getElementsByClassName("responsive-main-nav")[0];
            mainNav.style.right = "-160px";
        }
        else {
            var newClass = document.createAttribute('class');
            newClass.value = this.getAttribute("class") + " toggled";
            this.setAttributeNode(newClass);

            var mainNav = document.getElementsByClassName("responsive-main-nav")[0];
            mainNav.style.right = "0";
        }
    });

    var transferAmountForm = document.getElementById("transfer-amount-form");

    if (transferAmountForm != null) {
        var transferAmountFormInputs = transferAmountForm.getElementsByTagName("input");

        for (var i = 0; i < transferAmountFormInputs.length; i++) {
            if (transferAmountFormInputs[i].getAttribute("type") == "text") {
                transferAmountFormInputs[i].onkeyup = function (e) {
                    if (e.target.value.length >= 11) {
                        var a = $.ajax({
                            url: document.getElementById("get-username-by-personal-number-url").value,
                            data: { personalNumber: e.target.value },
                            method: "POST",
                            success: function (e) {

                            }
                        });
                        console.log(a);
                    }
                };
            }
        }
    }
}

window.onresize = function (event) {
    if (event.target.innerWidth > 1000) {
        var responsiveNav = document.getElementsByClassName("responsive-main-nav")[0];
        var responsiveNavToggler = document.getElementsByClassName("responsive-menu-toggler")[0];

        //responsiveNav.style.display = "none";
        //responsiveNavToggler.className = "responsive-menu-toggler";
    }
}