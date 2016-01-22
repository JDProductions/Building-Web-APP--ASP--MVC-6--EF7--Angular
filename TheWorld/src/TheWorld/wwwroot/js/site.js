// site.js
// Self executing annonomyous function
(function() {
    /*

    // Use this syntax because browsers are diffrent, cross platform capability
    var ele = $("#username"); // returning one object
    ele.text("James DuBois"); // Set the text of this object, set the text inside an element for me

    var main = $("#main"); // returning one object
    main.on("mouseenter", function() {
        main.style["background-color"] = "#888";
    }); // last parameter is almost always a callback )

    main.on("mouseleave", function() {
        main.style["background-color"] = "";
    });

    var menuItems = $("ul.menu li a"); // We want to do something by storring the actual items, the actual anchors in this structure
    // Work by attaching event to all menu items all at once
    menuItems.on("click", function () {
        var me = $(this);
        alert(me.text());
    });
    */

    /* show and hide sidebar by click of button*/
    var $sidebarAndWrapper = $("#sidebar, #wrapper"); // wrap set


        $("#sidebarToggle").on("click", function() {
        /*Add a class if doesnt a class or remove a class*/
            $sidebarAndWrapper.toggleClass("hide-sidebar");

            if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
                /*this = sidebar toggle button*/
                $(this).text("Show Sidebar");
            }
            else {
                $(this).text("Hide Sidebar");
            }
    });
})();



