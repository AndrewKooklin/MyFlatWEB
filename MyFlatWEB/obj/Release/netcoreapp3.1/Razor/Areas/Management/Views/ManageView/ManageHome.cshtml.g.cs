#pragma checksum "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edd456239b9d00c560090429659acd692cbc3337"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_ManageView_ManageHome), @"mvc.1.0.view", @"/Areas/Management/Views/ManageView/ManageHome.cshtml")]
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
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management.Models.EditPages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Areas.Management.Models.Rendering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using MyFlatWEB.Models.Rendering;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\_ViewImports.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edd456239b9d00c560090429659acd692cbc3337", @"/Areas/Management/Views/ManageView/ManageHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54f7191e946ee7823557e9cc32582e8915869f0b", @"/Areas/Management/Views/_ViewImports.cshtml")]
    public class Areas_Management_Views_ManageView_ManageHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrdersByServiceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ManageView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrdersByService", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Просмотреть"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-5 justify-content-center mt-3\">\r\n            <h3>Total orders : ");
#nullable restore
#line 6 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                          Write(Model.OrdersCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-5 justify-content-center mt-3"">
            <h2>Orders by services</h2>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-5 justify-content-center"">
            <table class=""table mt-3"">
                <thead class=""resp-table-header"">
                    <tr>
                        <th class=""serviceName text-left align-content-center"">Service name</th>
                        <th class=""orders-count text-center"">Orders count</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 24 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                     if (Model.ServiceOrders.Any())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                         foreach (var item in Model.ServiceOrders)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"serviceName text-left\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "edd456239b9d00c560090429659acd692cbc33377462", async() => {
#nullable restore
#line 33 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                                                      Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-serviceName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                                                  WriteLiteral(item.ServiceName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-serviceName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"orders-count text-center\">");
#nullable restore
#line 35 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                                                                Write(item.OrdersByServiceCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 37 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\repos\MyFlatWEB\MyFlatWEB\Areas\Management\Views\ManageView\ManageHome.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrdersByServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591