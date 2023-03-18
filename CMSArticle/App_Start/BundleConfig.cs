using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CMSArticle.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Js/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-validate*",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-rtl.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));
        }
    }
}