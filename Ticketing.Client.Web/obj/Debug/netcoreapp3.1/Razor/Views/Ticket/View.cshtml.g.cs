#pragma checksum "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67d05020e8348939b7d6c9afce80b32e7fb638d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_View), @"mvc.1.0.view", @"/Views/Ticket/View.cshtml")]
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
#line 1 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\_ViewImports.cshtml"
using Ticketing.Client.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\_ViewImports.cshtml"
using Ticketing.Client.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67d05020e8348939b7d6c9afce80b32e7fb638d7", @"/Views/Ticket/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e004a99f0ee6153515837c877b544a5e7bdd9df", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketRepliesParameters>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ticket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CloseTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "View", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
  
    ViewData["Title"] = "View Ticket";
    Layout = "Layout";


#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67d05020e8348939b7d6c9afce80b32e7fb638d76252", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"container-fluid\">\r\n            <div class=\"row mt-4\">\r\n                <div class=\"col-1 mt-4 pl-5 linkHover\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67d05020e8348939b7d6c9afce80b32e7fb638d76678", async() => {
                    WriteLiteral("\r\n                        <i class=\"fas fa-arrow-circle-left txtDark\" style=\"font-size: 40px;\"></i>\r\n                    ");
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
                        <div class=""container-fluid"">
                            <hr />
                            <div class=""row"">
                                <div class=""col-8"">
                                    <table class=""table table-borderless"">
                                        <tbody>
                                            <ticket>
                                                <tr>
                                                    <th scope=""row"">Subject</th>
                                                    <td>");
#nullable restore
#line 31 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                   Write(Model.Ticket.Subject);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th scope=\"row\">Product</th>\r\n                                                    <td>");
#nullable restore
#line 35 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                   Write(Model.Ticket.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <th scope=\"row\">Priority</th>\r\n                                                    <td>");
#nullable restore
#line 39 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                   Write(Model.Ticket.Priority);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <th scope=""row"">Summary</th>
                                                    <td colspan=""2"">");
#nullable restore
#line 43 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                               Write(Model.Ticket.Summary);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <th scope=""row"">Attachment</th>
                                                    <td>
");
#nullable restore
#line 48 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                         if (@Model.Ticket.Files.Any())
                                                        {
                                                            foreach (var file in @Model.Ticket.Files)
                                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                <h5 class=\"linkColor\">\r\n                                                                    <a");
                BeginWriteAttribute("href", " href=", 2865, "", 2889, 1);
#nullable restore
#line 53 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
WriteAttributeValue("", 2871, file.DonwloadPath, 2871, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"font-weight-light\"> ");
#nullable restore
#line 53 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                                     Write(file.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                                               Write(file.Extension);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </a>\r\n                                                                </h5>\r\n");
#nullable restore
#line 55 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                            }
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <p>No Attachments</p>\r\n");
#nullable restore
#line 60 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"

                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    </td>
                                                </tr>
                                            </ticket>
                                        </tbody>
                                    </table>
                                </div>
                                <div rowspan=""3"" mb-5>
");
#nullable restore
#line 69 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                     using (Html.BeginForm("CloseTicket", "Ticket", FormMethod.Post, new
                                    {
                                        enctype = "multipart/form-data"
                                    }))
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                   Write(Html.HiddenFor(model => model.Ticket.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67d05020e8348939b7d6c9afce80b32e7fb638d715719", async() => {
                    WriteLiteral(" Close Ticket ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 78 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </div>
                            </div>
                            <hr />
                            <div class=""row"">
                                <div class=""col-11"">
                                    <div class=""card mb-3"">
                                        <div class=""card-body cardNoHover"">
                                            <table class=""table table-borderless"">
                                                <tbody>
                                                    <replies>
");
#nullable restore
#line 89 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                         if (Model.Replies.Any())
                                                        {
                                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                             foreach (var reply in Model.Replies)
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                 if (reply.SenderType.ToString() == "Client")//Client
                                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    <tr>\r\n                                                                        <th scope=\"row\">");
#nullable restore
#line 96 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                   Write(reply.ClientName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                                        <td colspan=\"2\">\r\n                                                                            ");
#nullable restore
#line 98 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                       Write(reply.Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                            <span style=\"text-align: right; color: gray\">\r\n                                                                                ");
#nullable restore
#line 100 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                           Write(reply.CreateDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                            </span>\r\n                                                                        </td>\r\n");
#nullable restore
#line 103 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                         if (reply.Files.Any())
                                                                        {
                                                                            foreach (var file in reply.Files)
                                                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                                <td class=\"linkColor\">\r\n                                                                                    <a");
                BeginWriteAttribute("href", " href=", 6768, "", 6792, 1);
#nullable restore
#line 108 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
WriteAttributeValue("", 6774, file.DonwloadPath, 6774, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 108 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                           Write(file.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                                     Write(file.Extension);

#line default
#line hidden
#nullable disable
                WriteLiteral("  </a> \r\n                                                                                </td>\r\n");
#nullable restore
#line 110 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                            }
                                                                        }
                                                                        else
                                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                                            <td>
                                                                                No Attachment
                                                                            </td>
");
#nullable restore
#line 117 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                    </tr>\r\n");
#nullable restore
#line 120 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                }
                                                                else//Staff
                                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    <tr style=\"background-color: rgba(248, 172, 89, 0.25);\">\r\n                                                                        <th scope=\"row\">");
#nullable restore
#line 124 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                   Write(reply.StaffMemberName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                                        <td colspan=\"2\">\r\n                                                                            ");
#nullable restore
#line 126 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                       Write(reply.Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                            <span style=\"text-align: right; color: gray\">\r\n                                                                                ");
#nullable restore
#line 128 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                           Write(reply.CreateDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                            </span>\r\n                                                                        </td>\r\n");
#nullable restore
#line 131 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                         if (reply.Files.Any())
                                                                        {
                                                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                             foreach (var file in reply.Files)
                                                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                                <td class=\"linkColor\">\r\n                                                                                    <a");
                BeginWriteAttribute("href", " href=", 9213, "", 9237, 1);
#nullable restore
#line 136 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
WriteAttributeValue("", 9219, file.DonwloadPath, 9219, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 136 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                           Write(file.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                                     Write(file.Extension);

#line default
#line hidden
#nullable disable
                WriteLiteral("  </a>\r\n                                                                                </td>\r\n");
#nullable restore
#line 138 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 138 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                             
                                                                        }
                                                                        else
                                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                                            <td>
                                                                                No Attachment
                                                                            </td>
");
#nullable restore
#line 145 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                    </tr>\r\n");
#nullable restore
#line 147 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 147 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                 

                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 149 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                             


                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                            <tr>

                                                                <td colspan=""2"">
                                                                    You don't have any replies.
                                                                    <span style=""text-align: right; color: gray"">

                                                                    </span>
                                                                </td>

                                                            </tr>
");
#nullable restore
#line 165 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    </replies>
                                                    <tr>
                                                        <th scope=""row"">Reply</th>
                                                        <td>
");
#nullable restore
#line 170 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                             using (Html.BeginForm("View", "Ticket", FormMethod.Post, new
                                                            {
                                                                enctype = "multipart/form-data"
                                                            }))
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 175 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 177 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                           Write(Html.HiddenFor(model => model.Ticket.ClientId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 178 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                           Write(Html.HiddenFor(model => model.Ticket.StaffMemberId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 179 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                           Write(Html.TextAreaFor(model => model.Reply.Content, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                <br />\r\n                                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67d05020e8348939b7d6c9afce80b32e7fb638d734158", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 181 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                                                                                                                      Write(Html.ActionLink("", "View", new { id = Model.Ticket.Id }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(" Send");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                                <input type=\"file\" name=\"Attachments\" multiple=\"multiple\" accept=\"image/*\" />\r\n");
#nullable restore
#line 183 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Ticket\View.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
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
