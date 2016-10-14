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

            AddToList(list, 1, "Motorlar", "Motor grupları", null);
            AddToList(list, 101, "AC Motorlar", "AC Motor grupları", 1);
            AddToList(list, 102, "DC Motorlar", "DC Motor grupları", 1);
            AddToList(list, 103, "Step Motorlar", "Step Motor grupları", 1);
            AddToList(list, 104, "Servo Motorlar", "Servo Motor grupları", 1);

            AddToList(list, 1001, "AC 1", "AC1 Motor grupları", 101);
            AddToList(list, 1002, "AC 2", "AC2 Motor grupları", 101);
            AddToList(list, 1003, "DC1", "DC1 Motor grupları", 102);
            AddToList(list, 1004, "DC2", "DC2 Motor grupları", 102);
            AddToList(list, 1005, "DC3", "DC3 Motor grupları", 102);
            AddToList(list, 1006, "Step1", "Step1 Motor grupları", 103);
            AddToList(list, 1007, "Step2", "Step2 Motor grupları", 103);
            AddToList(list, 1008, "Step3", "Step3 Motor grupları", 103);
            AddToList(list, 1009, "Step4", "step4 Motor grupları", 103);

            AddToList(list, 1010, "Servo1 Motorlar", "Servo1 Motor grupları", 104);
            



            AddToList(list, 2, "Tekerlekler", "Tekerlek grupları", null);
            AddToList(list, 201, "Off Road", "Off Road tekerlek grupları", 2);
            AddToList(list, 202, "On road", "On road grupları", 2);
            AddToList(list, 203, "Palet", "Palet grupları", 2);
            AddToList(list, 204, "Özel", "Özel tasarım tekerlek grupları", 2);


            AddToList(list, 3, "Renkler", "Renk grupları", null);
            AddToList(list, 301, "Kırmızı", "Kırmızı renk grupları", 3);
            AddToList(list, 302, "Mavi", "Mavi Renk grupları", 3);
            AddToList(list, 303, "Yeşil", "Yeşil Renk", 3);
            AddToList(list, 304, "Sarı", "Sarı Renk grupları grupları", 3);
            


            
            AddToList(list, 3001, "Açık Kırmızı", "light red", 301);
            AddToList(list, 3002, "Koyu Kırmızı", "Dark Red", 301);
            AddToList(list, 3003, "Açık Yeşil", "light green", 302);
            AddToList(list, 3004, "Açık Sarı", "Light Yelllow", 303);



            return list;

        }

        public static List<TreeListModel> GetTreeListDataWithFilter(string filter,string columnList, string filterMode)
        {
            var list = GetTreeListData();
            string[] columnNames =columnList==null?null: columnList.Split(new char[] {','});

            if (string.IsNullOrEmpty(filter))
                return list;

            int mode = string.IsNullOrWhiteSpace(filterMode) || filterMode.Equals("1") ? 1 : 2;

            string filterLowerCase = filter.ToLower();

            List<TreeListModel> searchResult = null;
            //var searchResult = list.Where(t => t.Name.ToLower().Contains(filter.ToLower())).ToList();
            if(columnNames ==null || columnNames.Length == 0)
            {
                if (mode == 1)
                {
                    searchResult = list.Where(t => t.Name.ToLower().Contains(filterLowerCase) || t.Data.ToLower().Contains(filterLowerCase)).ToList();
                }
                else
                {
                    searchResult = list.Where(t => t.Name.ToLower().StartsWith(filterLowerCase) || t.Data.ToLower().StartsWith(filterLowerCase)).ToList();
                }
            }
            else
            {
                if (mode == 1)
                {
                    searchResult = list.Where(t =>
                                     (columnNames.Contains("Name") && t.Name.ToLower().Contains(filterLowerCase)) ||
                                     (columnNames.Contains("Data") && t.Data.ToLower().Contains(filterLowerCase))).ToList();
                }
                else
                {
                    searchResult = list.Where(t =>
                                    (columnNames.Contains("Name") && t.Name.ToLower().StartsWith(filterLowerCase)) ||
                                    (columnNames.Contains("Data") && t.Data.ToLower().StartsWith(filterLowerCase))).ToList();
                }
            }


             

            List<TreeListModel> result = new List<TreeListModel>(searchResult);

            foreach (TreeListModel item in searchResult)
            {
                TreeListModel parent = GetParent(list, item);
                while (parent!=null)
                {
                    if(!result.Contains(parent))
                    {
                        result.Add(parent);
                    }
                    parent = GetParent(list, parent);
                }
            }

            return result;
        }

        private static TreeListModel GetParent(List<TreeListModel> model, TreeListModel item)
        {
            return model.Find(c => c.Id == item.ParentId);
        }
        private static void AddToList(List<TreeListModel> list, int Id,string Name,string Data,int?ParentId)
        {
            list.Add(new TreeListModel { Id = Id, Name = Name, Data =Data,ParentId=ParentId });
        }
    }

    
}