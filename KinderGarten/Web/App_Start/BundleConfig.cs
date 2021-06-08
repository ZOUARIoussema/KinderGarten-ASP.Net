using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/Content/css/plugins.min.css",
                      "~/Content/plugins/fontawesome/css/font-awesome.min.css",
                      "~/Content/plugins/line-awesome/css/line-awesome.min.css",
                      "~/Content/plugins/flaticon/flaticon.css",
                      "~/Content/plugins/flaticon/education/flaticon.css",
                      "~/Content/plugins/themify/themify-icons.css",
                        "~/Content/css/style.min.css",
                        "~/Content/css/templete.min.css",
                        "~/Content/css/skin/skin-2.css",
                          "~/Content/css/font.css"


                      ));


            bundles.Add(new ScriptBundle("~/template/js").Include(
                   "~/Scripts/combining.js",
                     "~/Scripts/jquery.lazy.min.js",
                     "~/Scripts/rev.slider.js",
                      "~/Content/plugins/revolution/revolution/js/jquery.themepunch.tools.min.js",
                       "~/Content/plugins/revolution/revolution/js/jquery.themepunch.revolution.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.slideanims.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.actions.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.kenburn.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.navigation.min.js",
                       "~/Content/plugins/revolution/revolution/js/extensions/revolution.extension.parallax.min.js"

                    ));

            bundles.Add(new ScriptBundle("~/admin/js").Include(
             "~/Scripts/admin/js/jquery-ui-1.10.3.min.js",
             "~/Scripts/admin/js/bootstrap.min.js",
             "~/Scripts/admin/js/plugins/morris/morris.min.js",
             "~/Scripts/admin/js/plugins/sparkline/jquery.sparkline.min.js",
             "~/Scripts/admin/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
             "~/Scripts/admin/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
             "~/Scripts/admin/js/plugins/fullcalendar/fullcalendar.min.js",
             "~/Scripts/admin/js/plugins/jqueryKnob/jquery.knob.js",
             "~/Scripts/admin/js/plugins/daterangepicker/daterangepicker.js",
             "~/Scripts/admin/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
             "~/Scripts/admin/js/plugins/iCheck/icheck.min.js",
             "~/Scripts/admin/js/AdminLTE/app.js",
             "~/Scripts/admin/js/AdminLTE/dashboard.js",
             "~/Scripts/admin/js/sweetalert.min.js"
             ));

            bundles.Add(new StyleBundle("~/admin/css").Include(
                      "~/Content/admin/css/bootstrap.min.css",
                      "~/Content/admin/css/font-awesome.min.css",
                      "~/Content/admin/css/ionicons.min.css",
                      "~/Content/admin/css/morris/morris.css",
                      "~/Content/admin/css/jvectormap/jquery-jvectormap-1.2.2.css",
                      "~/Content/admin/css/fullcalendar/fullcalendar.css",
                      "~/Content/admin/css/daterangepicker/daterangepicker-bs3.css",
                      "~/Content/admin/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/Content/admin/css/AdminLTE.css",
                      "~/Content/admin/css/sweetalert.min.css"
                      ));



        }
    }
}
