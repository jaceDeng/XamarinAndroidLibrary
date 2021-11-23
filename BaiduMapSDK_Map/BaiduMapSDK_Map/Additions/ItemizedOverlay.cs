using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapSDK_Map.Additions
{
    public partial class ItemizedOverlay : global::Com.Baidu.Platform.Comapi.Map.Overlay, global::Java.Util.IComparator
    {
        public int Compare(Java.Lang.Object o1, Java.Lang.Object o2)
        {
            return Compare((Java.Lang.Integer)o1, (Java.Lang.Integer)o2);
                 
        }
    }
}
