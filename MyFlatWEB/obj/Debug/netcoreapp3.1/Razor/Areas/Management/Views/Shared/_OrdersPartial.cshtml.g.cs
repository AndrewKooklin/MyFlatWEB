#pragma checksum "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cba6d1e8c808874be5c4e851145d56211473a44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Shared__OrdersPartial), @"mvc.1.0.view", @"/Areas/Management/Views/Shared/_OrdersPartial.cshtml")]
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
#line 1 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management.Models.Rendering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Models.Rendering;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cba6d1e8c808874be5c4e851145d56211473a44", @"/Areas/Management/Views/Shared/_OrdersPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f80fd1473687b12c2d9de1650c76e404b881d61", @"/Areas/Management/Views/_ViewImports.cshtml")]
    public class Areas_Management_Views_Shared__OrdersPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrdersModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Select1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "status", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select-status-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("resp-table-row border-bottom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Statuses", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container m-0\">\r\n    <div class=\"row\">\r\n        <h2 class=\"mt-3\">");
#nullable restore
#line 5 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                    Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
    </div>
    <div>
        <div class=""row resp-table mt-3"">
            <div class=""resp-table-header"">
                <div class=""table-header-cell text-center align-content-center"">Id</div>
                <div class=""table-header-cell text-center align-content-center"">Date Create</div>
                <div class=""table-header-cell text-center align-content-center"">Name</div>
                <div class=""table-header-cell text-center align-content-center"">Email</div>
                <div class=""table-header-cell text-center align-content-center"">Mobile</div>
                <div class=""table-header-cell text-center align-content-center"">Service</div>
                <div class=""table-header-cell text-center align-content-center"">Message</div>
                <div class=""table-header-cell text-center align-content-center"">Status</div>
                <div class=""table-header-cell text-center align-content-center"">Statuses</div>
                <div class=""table-header-cell text-center ");
            WriteLiteral("align-content-center pl-1 pr-1\"><i>Change status</i></div>\r\n            </div>\r\n            <div class=\"resp-table-body\">\r\n");
#nullable restore
#line 22 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                 if (Model.OrderModels.Any())
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                     foreach (var item in Model.OrderModels)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cba6d1e8c808874be5c4e851145d56211473a448826", async() => {
                WriteLiteral("\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom pl-1 pr-1\">\r\n                                ");
#nullable restore
#line 33 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 36 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.DateCreate);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 39 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 42 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 45 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.Mobile);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 48 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.ServiceName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-left border-bottom\">\r\n                                ");
#nullable restore
#line 51 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"table-body-cell text-center align-content-center border-bottom\">\r\n                                ");
#nullable restore
#line 54 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                           Write(item.StatusName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n");
                WriteLiteral("                            <div class=\"table-body-cell select-status text-center align-content-center border-bottom\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cba6d1e8c808874be5c4e851145d56211473a4412701", async() => {
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 62 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.StatusName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 63 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.StatusNames;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                            <div class=""table-body-cell text-center align-content-center border-bottom"">
                                <button class=""btn btn-primary""
                                        title=""Изменить""
                                        type=""submit""
                                        onclick=""Change_status"">
                                    Change
                                </button>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                                    WriteLiteral(Model.StatusName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\Shared\_OrdersPartial.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrdersModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
