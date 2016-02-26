using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Armys.MusicSystemUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*登录 开始*/
            bundles.Add(new ScriptBundle("~/user/script").Include(
                        "~/Scripts/jquerymin.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/parsley/parsley.js",
                        "~/Scripts/sweetalert/sweetalert.js"
                        ));
            bundles.Add(new StyleBundle("~/user/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/checkbox/awesome-bootstrap-checkbox.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/animate.min.css",
                        "~/Content/sweetalert/sweetalert.css"
                        ));
            /*登录 结束*/

            /*主页 开始*/
            bundles.Add(new ScriptBundle("~/home/script").Include(
                        "~/Scripts/jquerymin.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/menu/add-menu.js",
                        "~/Scripts/menu/jquery.metisMenu.js",
                        "~/Scripts/slimscroll/jquery.slimscroll.min.js",
                        "~/Scripts/layer/layer.js",
                        "~/Scripts/hplus.js",
                        "~/Scripts/contabs.min.js",
                        "~/Scripts/pace/pace.min.js",
                        "~/Scripts/sweetalert/sweetalert.js"
                        ));
            
            bundles.Add(new StyleBundle("~/home/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/checkbox/awesome-bootstrap-checkbox.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/animate.min.css",
                        "~/Content/style.css",
                        "~/Content/sweetalert/sweetalert.css"
                        ));
            /*主页 结束*/

            bundles.Add(new ScriptBundle("~/public/script").Include(
                         "~/Scripts/jquerymin.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/slimscroll/jquery.slimscroll.min.js",
                        "~/Scripts/layer/layer.js",
                         "~/Scripts/contabs.min.js",
                         "~/Scripts/public.js",
                         "~/Scripts/sweetalert/sweetalert.js",
                         "~/Scripts/validate/jquery.validate.min.js",
                         "~/Scripts/validate/messages_zh.min.js"
                         ));
        }
    }
}