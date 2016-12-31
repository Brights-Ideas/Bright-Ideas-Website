$(document).ready(function () {

    $("a.switcher").bind("click", function (e) {
        e.preventDefault();
        
        var theid = $(this).attr("data-view");
        var theproducts = $(".ezsearch-results"); //$("section#properties");
        var classNames = $(this).attr('class').split(' ');

        var gridthumb = "images/products/grid-default-thumb.png";
        var listthumb = "images/products/list-default-thumb.png";

        if ($(this).hasClass("active")) {
            // if currently clicked button has the active class
            // then we do nothing!
            return false;
        } else {
            // otherwise we are clicking on the inactive button
            // and in the process of switching views!

            if (theid == "grid-view") {
                $(this).addClass("active");
                //$("#listview").removeClass("active");

                //$("#listview").children("img").attr("src", "images/list-view.png");

                var theimg = $(this).children("img");
                theimg.attr("src", "images/grid-view-active.png");

                // remove the list class and change to grid
                theproducts.removeClass("list");
                theproducts.removeAttr('data-view', 'list-view');
                theproducts.addClass("grid");
                theproducts.attr('data-view', 'grid-view');

                // update all thumbnails to larger size
                $("img.thumb").attr("src", gridthumb);
            }

            else if (theid == "list-view") {
                //$(this).parent("li").addClass("active");
                $(this).addClass("active");
                //$("#gridview").removeClass("active");
                //alert("word up");
                //$("#gridview").children("img").attr("src", "images/grid-view.png");

                var theimg = $(this).children("img");
                theimg.attr("src", "images/list-view-active.png");

                // remove the grid view and change to list
                theproducts.removeClass("grid")
                theproducts.addClass("list");
                theproducts.attr('data-view', 'list-view');
                // update all thumbnails to smaller size
                $("img.thumb").attr("src", listthumb);
            }
        }

    });
});