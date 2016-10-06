using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class RibbonFeaturesDemoOptions
    {
        public RibbonFeaturesDemoOptions()
        {
            AllowMinimize = true;
            ShowFileTab = true;
            ShowTabs = true;
            ShowGroupNames = true;
        }
        [Display(Name = "Allow Minimize")]
        public bool AllowMinimize { get; set; }
        [Display(Name = "Show File Tab")]
        public bool ShowFileTab { get; set; }
        [Display(Name = "Show Tabs")]
        public bool ShowTabs { get; set; }
        [Display(Name = "Show Group Names")]
        public bool ShowGroupNames { get; set; }
    }
}