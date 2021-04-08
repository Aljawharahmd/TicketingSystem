#pragma checksum "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56ae6a05b528b12aab5e0094b09c7ca37d615f32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_RegistrationAttachments), @"mvc.1.0.view", @"/Views/Account/RegistrationAttachments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56ae6a05b528b12aab5e0094b09c7ca37d615f32", @"/Views/Account/RegistrationAttachments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e51773215c83b044f0fff1879fe29cb7a992f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_RegistrationAttachments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegistrationParameters>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml"
  
    ViewData["Title"] = "Registration Attachments";
    Layout = "Layout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56ae6a05b528b12aab5e0094b09c7ca37d615f323512", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("\r\n    <div class=\"contentAuth mt-5\">\r\n        <div class=\"mt-4 jumb\">\r\n            <h3>Choose your Preferred Authentication Method</h3>\r\n        </div>\r\n");
#nullable restore
#line 30 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml"
         using (Html.BeginForm("RegistrationAttachments", "Account", FormMethod.Post, new
        {
            enctype = "multipart/form-data"
        }))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div class=""row container-fluid mb-5"">
                <div class=""col-5"">
                    <div class=""card txtLight DetectFace"">
                        <div class=""card-body"">
                            <h1>Face Recognition</h1>
                            <div class=""row container-fluid mt-5"">
                                <input type=""file"" name=""Face"" accept=""image/*"" />
                            </div>
                            <div class=""row container-fluid mt-5"">
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-2"">
                    <div class=""card txtLight BiometricBG"">
                        <div class=""card-body cardNoHover"" style=""margin-top: 70px; margin-left: 25px;"">
                            <div class=""row container-fluid"" style="" background-color: #F8AC59"">
                                <button type=""submit"" class=""btn btn-light"">Submit</button>
");
                WriteLiteral(@"                            </div>
                            <div class=""row container-fluid mt-4"" style="" background-color: #F8AC59"">
                                <button type=""reset"" class=""btn btn-light"">&nbsp;Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-5"">
                    <div class=""card txtLight DetectVoice"">
                        <div class=""card-body"">
                            <h1>Voice Recognition</h1>
                            <div class=""row container-fluid mt-5"">
                                <input type=""file"" name=""Voice"" accept=""audio/*"" />
                            </div>
                            ");
#nullable restore
#line 67 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml"
                       Write(Html.HiddenFor(model => model.StaffId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 68 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml"
                       Write(Html.HiddenFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 73 "C:\Users\amd-5\Desktop\T2_Competition\TicketingSystem\Ticketing.Staff.Web\Views\Account\RegistrationAttachments.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegistrationParameters> Html { get; private set; }
    }
}
#pragma warning restore 1591
