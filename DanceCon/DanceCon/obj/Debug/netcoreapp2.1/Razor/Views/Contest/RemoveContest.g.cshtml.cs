#pragma checksum "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20e28de5b151a1c3c43766bc2060caefb09d767d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contest_RemoveContest), @"mvc.1.0.view", @"/Views/Contest/RemoveContest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contest/RemoveContest.cshtml", typeof(AspNetCore.Views_Contest_RemoveContest))]
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
#line 1 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\_ViewImports.cshtml"
using DanceCon;

#line default
#line hidden
#line 2 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\_ViewImports.cshtml"
using DanceCon.Models;

#line default
#line hidden
#line 2 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e28de5b151a1c3c43766bc2060caefb09d767d", @"/Views/Contest/RemoveContest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a080552ebad2f18dd2003cfbbb783c8bb3f4006a", @"/Views/_ViewImports.cshtml")]
    public class Views_Contest_RemoveContest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DanceCon.Models.ContestViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height: 500px;  min-width:100px;  margin: auto;object-fit: scale-down;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveContest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
  
    ViewData["Title"] = "RemoveorEdit";
    var photoPath = "~/images/" + (Model.PhotoPath ?? "noimages.png");
    var contestid = ViewBag.contestid;

#line default
#line hidden
            BeginContext(290, 1121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31f7dff3348a4173b30dbaeb0bb384f1", async() => {
                BeginContext(367, 89, true);
                WriteLiteral("\r\n    <div class=\"card border-primary m-3 text-center\">\r\n        <h3 class=\"card-header\">");
                EndContext();
                BeginContext(457, 11, false);
#line 11 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                           Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(468, 51, true);
                WriteLiteral("</h3>\r\n        <h5 class=\"card-header\" type=\"date\">");
                EndContext();
                BeginContext(520, 53, false);
#line 12 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                       Write(Html.DisplayFor(m => m.ContestDate, "{0:dd/MM/yyyy}"));

#line default
#line hidden
                EndContext();
                BeginContext(573, 50, true);
                WriteLiteral("</h5>\r\n        <div class=\"blurOut\">\r\n            ");
                EndContext();
                BeginContext(623, 146, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0c6dc0cb8e1242539dc0349676a9ff0f", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#line 14 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                                                                                            WriteLiteral(photoPath);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(769, 95, true);
                WriteLiteral("\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">Country: ");
                EndContext();
                BeginContext(865, 13, false);
#line 17 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                       Write(Model.Country);

#line default
#line hidden
                EndContext();
                BeginContext(878, 7, true);
                WriteLiteral(" City: ");
                EndContext();
                BeginContext(886, 10, false);
#line 17 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                                            Write(Model.City);

#line default
#line hidden
                EndContext();
                BeginContext(896, 129, true);
                WriteLiteral("</h5>\r\n\r\n        </div>\r\n\r\n\r\n        <ul class=\"list-group list-group-flush\">\r\n            <li class=\"list-group-item\">Age Type: ");
                EndContext();
                BeginContext(1026, 14, false);
#line 23 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                             Write(Model.TypeText);

#line default
#line hidden
                EndContext();
                BeginContext(1040, 57, true);
                WriteLiteral("</li>\r\n            <li class=\"list-group-item\">Category: ");
                EndContext();
                BeginContext(1098, 18, false);
#line 24 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                             Write(Model.CategoryText);

#line default
#line hidden
                EndContext();
                BeginContext(1116, 90, true);
                WriteLiteral("</li>\r\n\r\n        </ul>\r\n        <div class=\"card-body\">\r\n            <p class=\"card-text\">");
                EndContext();
                BeginContext(1207, 17, false);
#line 28 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                            Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(1224, 24, true);
                WriteLiteral("</p>\r\n        </div>\r\n\r\n");
                EndContext();
#line 31 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
         if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
        {

#line default
#line hidden
                BeginContext(1331, 60, true);
                WriteLiteral("            <button class=\"btn btn-danger\">Remove</button>\r\n");
                EndContext();
#line 34 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
        }

#line default
#line hidden
                BeginContext(1402, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1411, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 37 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
 if (SignInManager.IsSignedIn(User) )
{

    

#line default
#line hidden
            BeginContext(1462, 132, false);
#line 40 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
Write(Html.ActionLink("Edit", "EditContest", new { id = @Model.ID }, htmlAttributes: new { @class = "btn btn-primary", @role = "button" }));

#line default
#line hidden
            EndContext();
#line 40 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
                                                                                                                                         

}

#line default
#line hidden
            BeginContext(1601, 92, true);
            WriteLiteral("     </div>\r\n<div class=\"card-footer text-muted\" type=\"date\" placeholder=\"YYYY-MM-DD\">\r\n    ");
            EndContext();
            BeginContext(1694, 15, false);
#line 45 "C:\Users\Użytkownik\Desktop\Kurs\DanceCon\DanceCon\Views\Contest\RemoveContest.cshtml"
Write(Model.AddedDate);

#line default
#line hidden
            EndContext();
            BeginContext(1709, 50, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n</div>\r\n</div>\r\n\r\n</div>\r\n</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DanceCon.Models.ContestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
