using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

//namespace CursoASPMVC1.CustomHelpers
//{
//}

public static class HtmlHelpers
{
    public static IHtmlString LabelWithClass(this HtmlHelper helper, string target, string className, string text)
    {
        //return String.Format("<label for='{0}' class='{1}'>{2}</label>", target, className, text);
        return new HtmlString(String.Format("<label for='{0}' class='{1}'>{2}</label>", target, className, text));
    }
}