$(function() {
    $(".onoffswitch-checkbox").click(function () {
        var status,groupId = $(this).attr("id");
        $(this).is(":checked") ? (
        status = true):
        status = false;
        submitStates(groupId, status);
    });
    function submitStates(groupId, status) {
        $.ajax({
                type: "POST",
                url: "/User/UpdateStatus",
                data: { groupId: groupId, status: status },
                success: function (data) {
                    if (data < 1) {
                        swal('更新失败', '系统提示', 'error');
                    }
                }
            });
    }
    $(".tags").click(function () {
        $("#group_Id").val($(this).parents("#tags").find("#groupId").text());
        //iframe窗
        var index = layer.open({
            type: 2,
            area: ['700px', '530px'],
            fix: false, //不固定
            maxmin: true,
            title: '编辑',
            content: '/OrganizationManagement/Tags'
        });
        layer.full(index);
    });
});