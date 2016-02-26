$(function() {
    $(".get_userInfo").click(function () {
        $(this).parents(".row").find(".userList").removeClass("col-sm-12");
        $(this).parents(".row").find(".userList").addClass("col-sm-8");
        var userInfo = $(this).parents(".row").find(".userInfo");
        userInfo.find("#user-headportrait").attr("src", $(this).find(".client-avatar").find("img").attr("src"));
        userInfo.find("#user-name").text($(this).find(".client-link").text());
        userInfo.find("#group-Name").text($(this).find(".groupName").text());
        userInfo.find("#user-personalinformation").text($(this).find(".personalinformation").text());
        userInfo.find("#user-remark").text($(this).find(".remark").text());
        $(this).parents(".row").find(".userInfo").removeClass("hidden");
        $(this).parents(".row").find(".userInfo").addClass("show");
        
    });

    $(".groupName").click(function () {
        //iframe窗
        var index = layer.open({
            type: 2,
            area: ['700px', '530px'],
            maxmin: true,
            title: '权限分配',
            content: '/OrganizationManagement/SecurityKeys'
        });
        layer.full(index);
    });
})