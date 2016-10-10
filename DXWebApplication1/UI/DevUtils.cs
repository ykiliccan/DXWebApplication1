using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.UI
{
    public static class DevUtils
    {

        public static void SetDataCellTemplateContentForSearch(this MVCxTreeListColumn col,HtmlHelper helper,string searchText,string className)
        {
                col.SetDataCellTemplateContent(c =>
                {
                    string cell_text = c.Text;


                    if (searchText.Length > cell_text.Length)
                        helper.ViewContext.Writer.Write(cell_text);

                    if (searchText != "")
                    {
                        string cell_text_lower = cell_text.ToLower();
                        string serchText_lower = searchText.ToLower();
                        int start_pos = cell_text_lower.IndexOf(serchText_lower);
                        int span_length = ("<span class='highlight'>").Length;
                        if (start_pos >= 0)
                        {
                            cell_text = cell_text.Insert(start_pos, "<span class='highlight'>");
                            cell_text = cell_text.Insert(start_pos + span_length + serchText_lower.Length, "</span>");
                        }

                        helper.ViewContext.Writer.Write(cell_text);
                    }
                    else
                        helper.ViewContext.Writer.Write(cell_text);

                });
        }

    }
}