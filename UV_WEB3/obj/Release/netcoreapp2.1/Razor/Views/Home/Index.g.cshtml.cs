#pragma checksum "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a57337bb585c3a7e7d932d11a125d4bc101f6391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\_ViewImports.cshtml"
using UV_WEB3;

#line default
#line hidden
#line 2 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\_ViewImports.cshtml"
using UV_WEB3.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a57337bb585c3a7e7d932d11a125d4bc101f6391", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"236e0aed2ff9be5c4905b9faa79e42f444007c49", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UV_WEB3.Models.Estaciones>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/carrusel.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/build/js/jQuerySwipe.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/bootstrap/dist/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";

#line default
#line hidden
            BeginContext(91, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(95, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ad7e0b4142da43bdbf30db7275c9de37", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(150, 793, true);
            WriteLiteral(@"

<div class=""container"" id=""container"">

    <div class=""carousel slide"" style=""position: inherit;"" data-ride=""carousel"" id=""postsCarousel"">
        <div class=""container"">
            <div class=""col-md-6 col-sm-6 col-xs-6"">
                <h3>Estaciones</h3>
            </div>
            <div class=""row"">
                <div class=""col-md-6 col-sm-6 col-xs-6 text-right"" style=""margin-top:7px"">
                    <a class=""btn btn-outline-secondary prev"" href="""" title=""Atrás""><i class=""fa fa-lg fa-chevron-left""></i></a>
                    <a class=""btn btn-outline-secondary next"" href="""" title=""Más""><i class=""fa fa-lg fa-chevron-right""></i></a>
                </div>
            </div>
        </div>
        <div class=""container p-t-0 m-t-2 carousel-inner"">
");
            EndContext();
#line 25 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
             for (int i = 0; i <= Model.Count() / 4; i++)
            {


#line default
#line hidden
            BeginContext(1019, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1039, "\"", 1098, 6);
            WriteAttributeValue("", 1047, "row", 1047, 3, true);
            WriteAttributeValue(" ", 1050, "row-equal", 1051, 10, true);
            WriteAttributeValue(" ", 1060, "item", 1061, 5, true);
#line 28 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1065, i == 0 ? "active" : "", 1066, 25, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1091, "m-t-0", 1092, 6, true);
            WriteAttributeValue(" ", 1097, "", 1098, 1, true);
            EndWriteAttribute();
            BeginContext(1099, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 29 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
                     foreach (var est in Model.Skip(i * 4).Take(4))
                    {

#line default
#line hidden
            BeginContext(1194, 308, true);
            WriteLiteral(@"                        <div class=""animated flipInY col-lg-3 col-md-3 col-sm-4 col-xs-6"" style=""display:block"">
                            <div class=""tile-stats"">
                                <div class=""icon""><i class=""fa fa-life-buoy""></i></div>
                                <div class=""count"">");
            EndContext();
            BeginContext(1503, 10, false);
#line 34 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
                                              Write(est.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(1513, 44, true);
            WriteLiteral("</div>\r\n\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1557, "\"", 1601, 2);
            WriteAttributeValue("", 1564, "/Home/detalleEstacion/", 1564, 22, true);
#line 36 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
WriteAttributeValue("", 1586, est.IdEstacion, 1586, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1602, 112, true);
            WriteLiteral(" style=\"margin-left: 1rem\" class=\"btn btn-success\">Acceder</a>\r\n\r\n\r\n                                <p>Latidud: ");
            EndContext();
            BeginContext(1715, 11, false);
#line 39 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
                                       Write(est.Latitud);

#line default
#line hidden
            EndContext();
            BeginContext(1726, 13, true);
            WriteLiteral(" , Longitud: ");
            EndContext();
            BeginContext(1740, 12, false);
#line 39 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
                                                                Write(est.Longitud);

#line default
#line hidden
            EndContext();
            BeginContext(1752, 74, true);
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 42 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1849, 24, true);
            WriteLiteral("                </div>\r\n");
            EndContext();
#line 44 "C:\Users\agus_\source\repos\UV_WEB3\UV_WEB3\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1888, 55, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <!-- jQuery -->\r\n    ");
            EndContext();
            BeginContext(1943, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36c7e5389eae45c1a7fa1b72f601e558", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2002, 8, true);
            WriteLiteral("\r\n\r\n    ");
            EndContext();
            BeginContext(2010, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f297ecbc6813418fac1dd66f3a816962", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2059, 30, true);
            WriteLiteral("\r\n    <!-- Bootstrap -->\r\n    ");
            EndContext();
            BeginContext(2089, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18b15bd87370466b8d6a1efaa8884559", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2157, 4077, true);
            WriteLiteral(@"

    <script>
        $(document).ready(function () {
            $('.carousel').carousel({
                interval: false
            });


            $("".carousel"").swipe({

                swipe: function (event, direction, distance, duration, fingerCount, fingerData) {

                    if (direction == 'left') $('.carousel').carousel('next');
                    if (direction == 'right') $('.carousel').carousel('prev');

                },
                allowPageScroll: ""vertical""

            });
            // manual carousel controls
            $('.next').click(function () { $('.carousel').carousel('next'); return false; });
            $('.prev').click(function () { $('.carousel').carousel('prev'); return false; });
        });

    </script>
    <div class=""col-md-12 col-sm-12 col-xs-12"">
        <div class=""dashboard_graph"">

            <div class=""row x_title"">
                <div class=""col-md-6"">
                    <h3>Mapa</h3>
                </div>");
            WriteLiteral(@"

            </div>

            <div class=""col-md-12 col-sm-12 col-xs-12"">

                <div id=""map"" style=""width:100%;height:400px;""></div>



                <script>

                    $(document).ready(function () {

                        callMethod();




                    });


                    function callMethod() {

                        $.ajax({
                            type: ""GET"",
                            url: ""GetStations2"",

                            contentType: ""application/json;charset=utf-8"",
                            dataType: ""json"",
                            success: function (result) {


                                llenar(result);

                            },
                            error: function (response) {

                                console.log('eror');
                            }
                        });
                    }

                </script>

                <script>



 ");
            WriteLiteral(@"                   function llenar(result) {
                        console.log(result);
                        var locations = result;
                        var map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 10,
                            mapTypeId: google.maps.MapTypeId.HYBRID
                        });

                        var infowindow = new google.maps.InfoWindow({
                            content: "" ""
                        });
                        var bounds = new google.maps.LatLngBounds();
                        var marker, i;

                        for (i = 0; i < locations.length; i++) {
                            marker = new google.maps.Marker({
                                position: new google.maps.LatLng(locations[i].latitud, locations[i].longitud),
                                map: map
                            });
                            bounds.extend(marker.position);


                    ");
            WriteLiteral(@"        google.maps.event.addListener(marker, 'click', (function (marker, i) {
                                return function () {
                                    infowindow.setContent('<h3>' + locations[i].nombre + '</h3><p>Latidud: ' + locations[i].latitud + '</p><p>Longitud: ' + locations[i].longitud + '</p>' +
                                        '<a  href=""/Home/detalleEstacion/' + locations[i].idEstacion + '"" style=""margin-left: 1rem"" class=""btn btn-success"">Acceder</a>');
                                    infowindow.open(map, marker);

                                }
                            })(marker, i));
                            map.fitBounds(bounds);
                        }
                    }
                </script>


                <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyDDuZGa9Bp-mA7Rkqeh1f56ggZ7tZZBniA""></script>


            </div>

            <div class=""clearfix""></div>
        </div>
    </div>
</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UV_WEB3.Models.Estaciones>> Html { get; private set; }
    }
}
#pragma warning restore 1591
