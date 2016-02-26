$(function() {
    $("#SignIn").click(function () {
        // form
        var form = $('#SignIn_From');
        if (form.parsley('validate')) {
            swal({
                title: "正在登录到乐听...",
                text: "",
                showConfirmButton: false,
                imageUrl: "/Images/login.gif"
            });
            $.ajax({
                type: "POST",
                url: "/User/Login",
                data: form.serialize(),
                success: function (data) {
                    if (data) {
                        window.location = "/Home/Index";
                    } else {
                        swal('用户名或者密码错误', '系统提示', 'error');
                    }
                }
            });
        }
    });
})