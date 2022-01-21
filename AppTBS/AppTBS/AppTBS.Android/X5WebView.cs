using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.Smtt.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTBS.Droid
{
    public class X5WebView : WebView
    {
        internal TextView title;
        private WebViewClient client = new WebViewClientAnonymousInnerClass();

        private class WebViewClientAnonymousInnerClass : WebViewClient
        {
            /// <summary>
            /// 防止加载网页时调起系统浏览器
            /// </summary>
            public bool shouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }


        public X5WebView(Context arg0, Android.Util.IAttributeSet arg1) : base(arg0, arg1)
        {
            this.WebViewClient = client;
            // this.setWebChromeClient(chromeClient);
            // WebStorage webStorage = WebStorage.getInstance();
            initWebViewSettings();
            this.View.Clickable = true;
        }

        private void initWebViewSettings()
        {
            WebSettings webSetting = this.Settings;
            webSetting.JavaScriptEnabled = true;
            webSetting.JavaScriptCanOpenWindowsAutomatically = true;
            webSetting.AllowFileAccess = true;
            webSetting.SetLayoutAlgorithm(WebSettings.LayoutAlgorithm.NarrowColumns);
            webSetting.SetSupportZoom(true);
            webSetting.BuiltInZoomControls = true;
            webSetting.UseWideViewPort = true;
            webSetting.SetSupportMultipleWindows(true);
            // webSetting.setLoadWithOverviewMode(true);
            webSetting.SetAppCacheEnabled(true);
            // webSetting.setDatabaseEnabled(true);
            webSetting.DomStorageEnabled = true;
            webSetting.SetGeolocationEnabled(true);
            webSetting.SetAppCacheMaxSize(long.MaxValue);
            // webSetting.setPageCacheCapacity(IX5WebSettings.DEFAULT_CACHE_CAPACITY);
            webSetting.SetPluginState(WebSettings.PluginState.OnDemand);
            // webSetting.setRenderPriority(WebSettings.RenderPriority.HIGH);
            webSetting.CacheMode = WebSettings.LoadNoCache;

            // this.getSettingsExtension().setPageCacheCapacity(IX5WebSettings.DEFAULT_CACHE_CAPACITY);//extension
            // settings 的设计
        }
        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {

            bool ret = base.DrawChild(canvas, child, drawingTime);
            canvas.Save();
            Paint paint = new Paint();
            paint.Color = new Color(0x7fff0000);
            paint.TextSize = 24.0f;
            paint.AntiAlias = true;
            if (X5WebViewExtension != null)
            {
                canvas.DrawText(this.Context.PackageName + "-pid:" + Android.OS.Process.MyPid(), 10, 50, paint);
                canvas.DrawText("X5  Core:" + QbSdk.GetTbsVersion(this.Context) + " sdk " + QbSdk.TbsSdkVersion, 10, 100, paint);
            }
            else
            {
                canvas.DrawText(this.Context.PackageName + "-pid:" + Android.OS.Process.MyPid(), 10, 50, paint);
                canvas.DrawText("Sys Core" + " sdk " + QbSdk.TbsSdkVersion, 10, 100, paint);
            }
            canvas.DrawText(Build.Manufacturer, 10, 150, paint);
            canvas.DrawText(Build.Model, 10, 200, paint);
            canvas.Restore();
            return ret;
        }

        public X5WebView(Context arg0) : base(arg0)
        {
            SetBackgroundColor(new Color(85621));
            //  BackgroundColor = 85621;
        }

    }

}