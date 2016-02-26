$(document).ready(function () {
    var a = function (d) {
        var c = d.length ? d : $(d.target),
        b = c.data("output");
        if (window.JSON) {
            b.val(window.JSON.stringify(c.nestable("serialize")));
        } else {
            b.val("浏览器不支持");
        }
    };
    $('#nestable').nestable();
    $(".dd").nestable("collapseAll");
    a($("#nestable").data("output", $("#nestable-output")));
    $("#nestable-menu").on("click",
        function (d) {
            var c = $(d.target),
                b = c.data("action");
            if (b === "expand-all") {
                $(".dd").nestable("expandAll");
            }
            if (b === "collapse-all") {
                $(".dd").nestable("collapseAll");
            }
        });
    $(document).on("click", ".onoffswitch-checkbox", function () {
        var allcheck = $(this);
        var usergroupId = $('#group_Id').val();
        var functionid = $(this).parents(".dd3-item").attr("data-id");
        if (allcheck.attr("id").indexOf("all") >= 0) {
            var states;
            allcheck.is(":checked") ?
            (allcheck.parents(".dd3-content").find('input[name="states"]').trigger("click"),
                states = true) :
            (allcheck.parents(".dd3-content").find('input[name="states"]').trigger("click"),
                states = false);
            $.ajax({
                type: "POST",
                url: "/OrganizationManagement/Tags",
                data: { function_id: functionid, usergroup_id: usergroupId, display: states, edit: states, delete: states, insert: states },
                success: function(data) {
                    if (data < 1) {
                        swal('更新失败', '系统提示', 'error');
                    }
                }
            });
        }
    });
    $('[data-action="expand"]').click(function () {
        var menu = $(this).parent();
        var id = menu.data("id"), html = "";
        if (id !== "") {
            $.ajax({
                type: "POST",
                url: "/OrganizationManagement/GetAllChildMenu",
                data: { menuId: id },
                success: function (data) {
                    var s = data;
                    if (data != null) {
                        for (var i = 0; i < data.length; i++) {
                            html += '<li class="dd-item dd3-item" data-id=' + data[i].id + '><div class="dd-handle dd3-handle">Drag</div><div class="dd3-content"><span class="label label-info"></span>' +
                                '<span class="pull-right padding-l10"><div class="onoffswitch">' +
                                '<input name="states" class="onoffswitch-checkbox" id="all_' + data[i].function_id + '_' + data[i].id + '" type="checkbox">' +
                                '<label class="onoffswitch-label" for="all_' + data[i].function_id + '_' + data[i].id + '" >' +
                                '<span class="onoffswitch-inner"></span><span class="onoffswitch-switch"></span></label></div></span> ' +
                                '<span class="pull-right padding-l10"><div class="onoffswitch">' +
                                '<input name="states" class="onoffswitch-checkbox" id="delete_' + data[i].function_id + '_' + data[i].id + '" type="checkbox">' +
                                '<label class="onoffswitch-label" for="delete_' + data[i].function_id + '_' + data[i].id + '">' +
                                '<span class="onoffswitch-inner"></span><span class="onoffswitch-switch"></span></label></div></span>' +
                                '<span class="pull-right padding-l10"><div class="onoffswitch">' +
                                '<input name="states" class="onoffswitch-checkbox" id="update_' + data[i].function_id + '_' + data[i].id + '" type="checkbox">' +
                                '<label class="onoffswitch-label" for="update_' + data[i].function_id + '_' + data[i].id + '"><span class="onoffswitch-inner"></span>' +
                                '<span class="onoffswitch-switch"></span></label></div></span>' +
                                '<span class="pull-right padding-l10"><div class="onoffswitch">' +
                                '<input name="states" class="onoffswitch-checkbox" id="create_' + data[i].function_id + '_' + data[i].id + '" type="checkbox">' +
                                '<label class="onoffswitch-label" for="create_' + data[i].function_id + '_' + data[i].id + '"><span class="onoffswitch-inner"></span>' +
                                '<span class="onoffswitch-switch"></span></label></div></span>' +
                                '<span class="pull-right padding-l10"><div class="onoffswitch">' +
                                '<input name="states" class="onoffswitch-checkbox" id="read_' + data[i].function_id + '_' + data[i].id + '" type="checkbox">' +
                                '<label class="onoffswitch-label" for="read_' + data[i].function_id + '_' + data[i].id + '"><span class="onoffswitch-inner"></span>' +
                                '<span class="onoffswitch-switch"></span></label></div></span>' + data[i].name + '</div></li>';
                        }
                        menu.find(".dd-list").html(html);
                    }
                }
            });
        }
    });
});