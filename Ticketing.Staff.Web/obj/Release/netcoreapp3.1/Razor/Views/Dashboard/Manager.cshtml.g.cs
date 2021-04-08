#pragma checksum "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9396300ea9293fdc51b192ece6036cf8ea19ed2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Manager), @"mvc.1.0.view", @"/Views/Dashboard/Manager.cshtml")]
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
#nullable restore
#line 1 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\_ViewImports.cshtml"
using Ticketing.Staff.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\_ViewImports.cshtml"
using Ticketing.Staff.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9396300ea9293fdc51b192ece6036cf8ea19ed2e", @"/Views/Dashboard/Manager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e51773215c83b044f0fff1879fe29cb7a992f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Manager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManagerDashboard>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/dashboard.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "ManagerLayout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9396300ea9293fdc51b192ece6036cf8ea19ed2e4665", async() => {
                WriteLiteral("\r\n    <meta http-equiv=\"refresh\" content=\"30\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9396300ea9293fdc51b192ece6036cf8ea19ed2e5685", async() => {
                WriteLiteral(@"
    <div id=""layoutSidenav"">
        <div id=""layoutSidenav_content"">
            <div class=""container-fluid"">
                <h1 class=""mt-4""><strong>Dashboard</strong></h1>
                <div class=""container pt-5"" style=""text-align: center; vertical-align: middle;"">

");
                WriteLiteral(@"                    <div class=""row"">
                        <div class=""col"">
                            <div class=""card text-dark bg-card mb-4"" style="" background-color: #F8AC59;"">
                                <div class=""card-body"">
                                    <h5 class=""card-title""><strong>Open Tickets</strong></h5>
                                    <p class=""card-text"">");
#nullable restore
#line 24 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                                    Write(Model.OpenTickets);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col"">
                            <div class=""card text-dark bg-card mb-4"" style=""background-color: #a3e1d4;"">
                                <div class=""card-body"">
                                    <h5 class=""card-title""><strong>Closed Tickets</strong></h5>
                                    <p class=""card-text"">");
#nullable restore
#line 32 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                                    Write(Model.ClosedTickets);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col"">
                            <div class=""card text-dark bg-card mb-3"" style=""background-color: #80c1d7;"">
                                <div class=""card-body"">
                                    <h5 class=""card-title""><strong>All Clients</strong></h5>
                                    <p class=""card-text"">");
#nullable restore
#line 40 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                                    Write(Model.AllClients);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""card text-dark bg-card mb-3"" style=""max-width: 140rem;background-color: #80c1d7;"">
                                <div class=""card-body"">
                                    <h5 class=""card-title""><strong>Most Productive Staff</strong></h5>
                                    <p class=""card-text"">
                                        ");
#nullable restore
#line 51 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                   Write(Model.MostProductiveEmployee.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span class=\"card-text ml-2\"><strong>With </strong>");
#nullable restore
#line 51 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                                                                                                        Write(Model.MostProductiveEmployee.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-6"">
                            <div class=""card text-dark bg-card mb-3"" style=""max-width: 140rem;background-color: #F8AC59;"">
                                <div class=""card-body"">
                                    <h5 class=""card-title""><strong>Average Tickets Per Staff</strong></h5>
                                    <p class=""card-text"">");
#nullable restore
#line 60 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                                    Write(Model.AverageTicketsPerStaff);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n");
                WriteLiteral(@"                    <div class=""row "">
                        <div class=""col-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h4>Number of Tickets Per Product</h4>
                                    <div id=""piechart-TicketsPerProduct""></div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h4>Number of Tickets</h4>
                                    <div id=""piechart-NoOfTickets""></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row mt-4 mb-5"">
                        <div class=""col-12"">
                            <div class=""card"">
 ");
                WriteLiteral(@"                               <div class=""card-body"">
                                    <h4>Staff Productivity</h4>
                                    <div id=""productivity"">

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
                DefineSection("Scripts", async() => {
                    WriteLiteral("\r\n\r\n        <script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9396300ea9293fdc51b192ece6036cf8ea19ed2e12721", async() => {
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
                    WriteLiteral("\r\n        <script>\r\n            var numberOfTickets = ");
#nullable restore
#line 106 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                             Write(Html.Raw(JsonConvert.SerializeObject(Model.NumberOfTicketsPerProduct)));

#line default
#line hidden
#nullable disable
                    WriteLiteral(";\r\n            var numberOfTicketsStatus = ");
#nullable restore
#line 107 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                   Write(Html.Raw(JsonConvert.SerializeObject(Model.NumberOfTicketsStatus)));

#line default
#line hidden
#nullable disable
                    WriteLiteral(";\r\n            var numberOfTicketsPerStaff =  ");
#nullable restore
#line 108 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Dashboard\Manager.cshtml"
                                      Write(Html.Raw(JsonConvert.SerializeObject(Model.NumberOfTicketsPerStaff)));

#line default
#line hidden
#nullable disable
                    WriteLiteral(";\r\n        </script>\r\n    ");
                }
                );
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManagerDashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591
