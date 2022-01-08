using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.Smtt.Export.External;
using Com.Tencent.Smtt.Sdk;

namespace AppTBS.Droid
{
    [Application]
    public class MApplication : Android.App.Application
    { 
        protected MApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }
        public override void OnCreate()
        {
            var  map = new Dictionary<string,Java.Lang.Object>();
            map.Add(TbsCoreSettings.TbsSettingsUseSpeedyClassloader, true);
            map.Add(TbsCoreSettings.TbsSettingsUseDexloaderService, true);
            QbSdk.InitTbsSettings(map);
            QbSdk.DownloadWithoutWifi=(true);
            TbsDownloader.StartDownload(this);
            Com.Tencent.Smtt.Sdk.QbSdk.InitX5Environment(this,null);
            //Com.Tencent.Bugly.Bugly.Init(this.ApplicationContext, APP_ID, false);
            base.OnCreate();
        }
    }

}