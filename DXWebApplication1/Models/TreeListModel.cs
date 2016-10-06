using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class TreeListModel
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public static List<TreeListModel> GetTreeListData()
        {
            List<TreeListModel> list = new List<TreeListModel>();

            for(int i=1;i<21;i++)
            {
                TreeListModel m = new TreeListModel { Id=i,Name="Parent-" + i.ToString(), }

            }



            return list;

        }
    }

    
}