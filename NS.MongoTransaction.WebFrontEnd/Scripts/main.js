window.onload = function () {
    var mainNavToggler = document.getElementsByClassName("responsive-menu-toggler")[0];

    mainNavToggler.addEventListener("click", function (e) {
        var targetClassesArray = this.getAttribute("class").split(" ");

        if (targetClassesArray.length > 1) {
            var newClass = this.className.replace("toggled", "");
            newClass = newClass.replace(" ", "");
            this.removeAttribute("class");

            var newClass = document.createAttribute('class');
            newClass.value = targetClassesArray[0];
            this.setAttributeNode(newClass);

            var mainNav = document.getElementsByClassName("responsive-main-nav")[0];
            mainNav.style.display = "none";
        }
        else {
            var newClass = document.createAttribute('class');
            newClass.value = this.getAttribute("class") + " toggled";
            this.setAttributeNode(newClass);

            var mainNav = document.getElementsByClassName("responsive-main-nav")[0];
            mainNav.style.display = "inline-block";
        }
    });
}