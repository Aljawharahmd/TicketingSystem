#pragma checksum "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78f49ad3fc0e84c9cd6be2ef9d6ee842b5ea15cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_ManagerView), @"mvc.1.0.view", @"/Views/Ticket/ManagerView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78f49ad3fc0e84c9cd6be2ef9d6ee842b5ea15cb", @"/Views/Ticket/ManagerView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e51773215c83b044f0fff1879fe29cb7a992f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_ManagerView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketRepliesParameters>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ticket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
  
    ViewData["Title"] = "ManagerView Ticket";
    Layout = "ManagerLayout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f49ad3fc0e84c9cd6be2ef9d6ee842b5ea15cb4500", async() => {
                WriteLiteral("\r\n    <div id=\"layoutSidenav\">\r\n        <div id=\"layoutSidenav_content\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"row mt-4\">\r\n                    <div class=\"col-1 mt-4 pl-5 linkHover\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f49ad3fc0e84c9cd6be2ef9d6ee842b5ea15cb5018", async() => {
                    WriteLiteral("\r\n                            <i class=\"fas fa-arrow-circle-left txtDark\" style=\"font-size: 40px;\"></i>\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                    <div class=""col-11"">
                        <div class=""container-fluid"">
                            <h3 class=""mt-4"">
                                <strong> Ticket Details </strong>
                            </h3>
                            <br />
                            <h5><strong>Client Information</strong> </h5>

                            <table class=""table table-borderless"">
                                <tbody class=""border"">

                                    <tr>
                                        <th scope=""row"">Client ID</th>
                                        <td>");
#nullable restore
#line 30 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                       Write(Model.Ticket.ClientId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <th scope=\"row\">Client Name</th>\r\n                                        <td>");
#nullable restore
#line 34 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                       Write(Model.Ticket.ClientName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <th scope=\"row\">Client Email</th>\r\n                                        <td>");
#nullable restore
#line 38 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                       Write(Model.Ticket.ClientEmail);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                    </tr>

                                </tbody>
                            </table>
                            <hr />
                          
                                    <br />

                                    <h5><strong>Ticket Information</strong> </h5>
                                    <table class=""table table-borderless"">
                                        <tbody class=""border-bottom border-top border-right border-left"">
                                            <tr>
                                                <th>Subject</th>

                                                <td");
                BeginWriteAttribute("colspan", " colspan=\"", 2399, "\"", 2409, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 53 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                                          Write(Model.Ticket.Subject);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <th>Assigned To</th>\r\n                                                <td colspan=\"4\">");
#nullable restore
#line 55 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                                           Write(Model.Ticket.EmployeeName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <th>Product</th>\r\n                                                <td>");
#nullable restore
#line 59 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                                                <th>Priority</th>\r\n                                                <td>");
#nullable restore
#line 62 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.Priority);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>

                                                <th>&nbsp;</th>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <th>Date</th>
                                                <td>");
#nullable restore
#line 69 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.CreateDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                                                <th>Last Modified</th>\r\n                                                <td>");
#nullable restore
#line 72 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.LastModifiedDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                                                <th>Status</th>\r\n                                                <td>");
#nullable restore
#line 75 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class=""table border"">
                                        <tbody>
                                            <tr>
                                                <th>Summary</th>
                                                <td colspan=""6"">
                                                    ");
#nullable restore
#line 84 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Ticket\ManagerView.cshtml"
                                               Write(Model.Ticket.Summary);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicketRepliesParameters> Html { get; private set; }
    }
}
#pragma warning restore 1591
