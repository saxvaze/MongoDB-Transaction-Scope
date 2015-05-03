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
}

//window.onresize = function (event) {
//    if (event.target.innerWidth > 1000) {
//        var responsiveNav = document.getElementsByClassName("responsive-main-nav")[0];
//        var responsiveNavToggler = document.getElementsByClassName("responsive-menu-toggler")[0];
//    }
//}