using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Armys.MusicEntity;

namespace Armys.MusicTool
{
    /// <summary>
    /// 分页
    /// </summary>
    public static class HtmlPagingHelper
    {
        public static HtmlString ShowPageNavigate(this HtmlHelper htmlHelper, ResultObjClass paging, int btnNumber = 9, string paramName = "page")
        {
            if (htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url == null) return null;

            var urlStr = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.ToString();

            var pageIndex = paging.PageIndex; //当前页数
            var pageCount = paging.PageCount; //总页数

            if (pageCount <= 1) return null;

            var outPut = new StringBuilder();
            outPut.AppendFormat("<ul>");

            if (pageIndex > 1)
            {
                var urlTo = HtmlUrlHelper.UpdateParam(urlStr, paramName, (pageIndex - 1).ToString());
                var firstPage = HtmlUrlHelper.UpdateParam(urlStr, paramName, "1");
                outPut.AppendFormat("<li class='firstPage'><a href='{0}'><span>首页</span></a></li>", firstPage);
                outPut.AppendFormat("<li class='prev'><a href='{0}'>← <span>上一页</span></a></li>", urlTo);
            }

            const int index = 5;
            for (var i = 0; i < btnNumber; i++)
            {
                if ((pageIndex + i - index) < 1 || (pageIndex + i - index) > pageCount) continue;

                var urlTo = HtmlUrlHelper.UpdateParam(urlStr, paramName, (pageIndex + i - index).ToString());

                outPut.AppendFormat(
                    pageIndex + i - index == pageIndex
                        ? "<li class='active'><a href='{0}'>{1}</a></li>"
                        : "<li><a href='{0}'>{1}</a></li>", urlTo, pageIndex + i - index);
            }

            if (pageIndex < pageCount)
            {
                var urlTo = HtmlUrlHelper.UpdateParam(urlStr, paramName, (pageIndex + 1).ToString());
                var trailerPage = HtmlUrlHelper.UpdateParam(urlStr, paramName, pageCount.ToString());

                outPut.AppendFormat("<li class='next'><a href='{0}'><span>下一页</span>→</a></li>", urlTo);
                outPut.AppendFormat("<li class='trailerPage'><a href='{0}'> <span>尾页</span></a></li>", trailerPage);
            }
            outPut.AppendFormat("</ul>");

            return new HtmlString(outPut.ToString());
        }

    }
}
