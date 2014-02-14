using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FundingPilotSystem.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString WebPage(this HtmlHelper htmlHelper, string page)
        {
            string serverPath = HttpContext.Current.Server.MapPath("~\\StaticHtmlPages");
            string filePath = serverPath + "\\" + page;
            string htmlContent = new WebClient().DownloadString(filePath);

            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regx = new Regex("<body>(?<bodyContent>.*)</body>", options);

            Match match = regx.Match(htmlContent);
            string theBody = htmlContent;
            if (match.Success)
            {
                theBody = match.Groups["bodyContent"].Value;
            }

            return MvcHtmlString.Create(theBody);
        }
    }
}