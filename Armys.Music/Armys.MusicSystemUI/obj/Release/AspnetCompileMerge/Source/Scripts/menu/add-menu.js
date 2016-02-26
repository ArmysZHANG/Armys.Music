$(function() {
    $(".add-chile-menu").click(function () {
        var item = $(this);
        if ($(item).data("load") !== "ok") {
            $.ajax({
                type: "POST",
                url: "/Home/GetChildMenu",
                data: { menuId: $(this).data("menuid") },
                success: function(data) {
                    if (data != null) {
                        $(this).parent().find("ul").html("");
                        var html = "";
                        for (var i = 0; i < data.length; i++) {
                            html += '<li><a class="J_menuItem" href="/' + data[i].controller + '/' + data[i].action + '" data-index="0">' + data[i].name + '</a></li>';
                        }
                        $(item).attr("data-load", "ok");
                        $(item).parent().find("ul").html(html);
                        initialMenu();
                    } else {
                        $(this).parent().find("ul").html("");
                    }
                }
            });
        }
    });
})