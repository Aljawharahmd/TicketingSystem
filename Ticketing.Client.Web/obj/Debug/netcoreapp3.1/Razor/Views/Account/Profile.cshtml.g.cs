#pragma checksum "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd01d8cffc5c0812f3a681d2f75b568c2cb66b98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd01d8cffc5c0812f3a681d2f75b568c2cb66b98", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e004a99f0ee6153515837c877b544a5e7bdd9df", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClientUpdateViewParameters>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark mr-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("LoginUser()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("profileForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("txtDark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/passwordStrength.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "Layout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd01d8cffc5c0812f3a681d2f75b568c2cb66b987738", async() => {
                WriteLiteral("\r\n    <div class=\"container profileBG\">\r\n        <div class=\"row mt-5\">\r\n            <div class=\"col-1 mt-3 pl-4 linkHover\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd01d8cffc5c0812f3a681d2f75b568c2cb66b988148", async() => {
                    WriteLiteral("\r\n                    <i class=\"fas fa-home txtDark\" style=\"font-size: 40px;\"></i>\r\n                ");
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
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-5\">\r\n                <h2 class=\"mt-3\"><strong>Update Profile</strong></h2>\r\n                <br />\r\n");
#nullable restore
#line 17 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                 using (Html.BeginForm("Profile", "Account", FormMethod.Post, htmlAttributes: new { oninput = "confirmPassword.setCustomValidity(confirmPassword.value != password.value ? 'Passwords do not match.' : '')" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd01d8cffc5c0812f3a681d2f75b568c2cb66b9810790", async() => {
                    WriteLiteral("\r\n                        <div");
                    BeginWriteAttribute("id", " id=\"", 939, "\"", 944, 0);
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-group justify-content-center\">\r\n                            <label>Full Name</label>\r\n                            <div class=\"form-inline\">\r\n                                ");
#nullable restore
#line 24 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                           Write(Html.TextBoxFor(model => model.FirstName, htmlAttributes: new { placeholder = "First Name", required = "true", @class = "form-control col-4 mr-3" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                           Write(Html.TextBoxFor(model => model.LastName, htmlAttributes: new { placeholder = "Last Name", required = "true", @class = "form-control col-4" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"


                            </div>
                        </div>
                        <div class=""form-group justify-content-center"">
                            <label>Mobile Number</label>
                            <div class=""form-inline"">
                                ");
#nullable restore
#line 33 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                           Write(Html.DropDownListFor(model => model.AreaCode,
                                    new SelectList(new List<string> { "+966", "+962", "+971" }), new { @class = "custom-select form-control col-3 mr-3" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                ");
#nullable restore
#line 35 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                           Write(Html.TextBoxFor(model => model.MobileNumber, htmlAttributes: new { id = "mobileNumber", placeholder = "", maxlength = "9", pattern = "[0-9]{9}", required = "true", @class = "form-control col-5" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"

                                <small id=""Mobilehelp"" class=""form-text text-muted"">The Mobile Number you Registered with</small>
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label>Email address</label>
                            ");
#nullable restore
#line 42 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                       Write(Html.TextBoxFor(model => model.Email, htmlAttributes: new { type = "email", required = "true", @class = "form-control col-7" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            <label>Password</label>\r\n                            <div class=\"form-inline\">\r\n                                ");
#nullable restore
#line 47 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                           Write(Html.PasswordFor(model => model.Password, htmlAttributes: new { id = "password", name = "password", type = "password", placeholder = "Password", required = "true", @class = "form-control col-7" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                                <div id=""meter_wrapper"">
                                    <div id=""meter""></div>
                                    <span id=""pass_type""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label>Confirm Password</label>
                            <input type=password name=confirmPassword class=""form-control col-7"" placeholder=""Confirm Password"" required>
                        </div>
                        ");
#nullable restore
#line 58 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd01d8cffc5c0812f3a681d2f75b568c2cb66b9815894", async() => {
                        WriteLiteral("Update");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        <button type=\"reset\" class=\"btn btn-dark\">Clear</button>\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 63 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </div>
            <div class=""col-5 mt-1"" style=""border-left: solid 1px #e0e0e0;"">
                <div class=""card"" style=""border: none !important; background-color: rgba(255, 255, 255, 0)"">
                    <div class=""card-body cardNoHover"">
                        <h2><strong>Profile Information</strong></h2>
                        <br />
                        <profile>
                            <h5><strong>Name </strong></h5>
                            <p>");
#nullable restore
#line 72 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                          Write(Model.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 72 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                                           Write(Model.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <h5><strong>Mobile Number </strong></h5>\r\n                            <p>");
#nullable restore
#line 74 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                          Write(Model.AreaCode);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 74 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                                          Write(Model.MobileNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <h5><strong>Email </strong></h5>\r\n                            <p>");
#nullable restore
#line 76 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Client.Web\Views\Account\Profile.cshtml"
                          Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </profile>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd01d8cffc5c0812f3a681d2f75b568c2cb66b9821515", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                DefineSection("Scripts", async() => {
                    WriteLiteral("\r\n        <script>\r\n            $(document).ready(function () {\r\n                $(\"#password\").keyup(function () {\r\n                    checkPasswordStrength();\r\n                });\r\n            });\r\n        </script>\r\n    ");
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
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClientUpdateViewParameters> Html { get; private set; }
    }
}
#pragma warning restore 1591
