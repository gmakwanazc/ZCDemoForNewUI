using System;
using System.Collections.Generic;

namespace ZCDemoForNewUI.Model
{
    public class LeftNavigationData
    {
        public LeftNavigationData()
        {
            ChildItemList = new List<LeftNavigationChild>();
        }
        public bool IsLogout { get; set; }
        public bool IsProfile { get; set; }
        public string Section { get; set; }
        public List<LeftNavigationChild> ChildItemList { get; set; }
    }
}
