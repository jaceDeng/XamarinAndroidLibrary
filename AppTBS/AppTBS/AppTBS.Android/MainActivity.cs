using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tencent.Smtt.Sdk; 
namespace AppTBS.Droid
{
    [Activity(Label = "AppTBS", Icon = "@drawable/icon", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
    public class MainActivity : Activity
    { 
        X5WebView webView;
        protected override void OnCreate(Bundle bundle)
        { 
          
            base.OnCreate(bundle); 

            SetContentView(Resource.Layout.filechooser_layout);
            webView = (X5WebView)FindViewById(Resource.Id.web_filechooser);
            //debugtbs.qq.com
            //webView.LoadUrl("http://debugtbs.qq.com");

            webView.LoadUrl("file:///android_asset/webpage/fullscreenVideo.html");
            Window.SetFormat(Android.Graphics.Format.Translucent);// ().setFormat(PixelFormat.TRANSLUCENT);

            webView.View.OverScrollMode = OverScrollMode.Always;// (View.OVER_SCROLL_ALWAYS);
            webView.AddJavascriptInterface(new WebViewJavaScriptFunction(this )
            {
            }, "Android");

        }


        // /////////////////////////////////////////
        // 向webview发出信息
        internal void enableX5FullscreenFunc()
        {

            if (webView.X5WebViewExtension != null)
            {
                Toast.MakeText(this, "开启X5全屏播放模式", ToastLength.Long).Show();
                Bundle data = new Bundle();

                data.PutBoolean("standardFullScreen", false);// true表示标准全屏，false表示X5全屏；不设置默认false，

                data.PutBoolean("supportLiteWnd", false);// false：关闭小窗；true：开启小窗；不设置默认true，

                data.PutInt("DefaultVideoScreen", 2);// 1：以页面内开始播放，2：以全屏开始播放；不设置默认：1

                webView.X5WebViewExtension.InvokeMiscMethod("setVideoParams",
                        data);
            }
        }

        internal void disableX5FullscreenFunc()
        {
            if (webView.X5WebViewExtension != null)
            {
                Toast.MakeText(this, "恢复webkit初始状态", ToastLength.Long).Show();

                Bundle data = new Bundle();

                data.PutBoolean("standardFullScreen", true);// true表示标准全屏，会调起onShowCustomView()，false表示X5全屏；不设置默认false，

                data.PutBoolean("supportLiteWnd", false);// false：关闭小窗；true：开启小窗；不设置默认true，

                data.PutInt("DefaultVideoScreen", 2);// 1：以页面内开始播放，2：以全屏开始播放；不设置默认：1

                webView.X5WebViewExtension.InvokeMiscMethod("setVideoParams",
                        data);
            }
        }

        internal void enableLiteWndFunc()
        {
            if (webView.X5WebViewExtension != null)
            {
                Toast.MakeText(this, "开启小窗模式", ToastLength.Long).Show();
                Bundle data = new Bundle();

                data.PutBoolean("standardFullScreen", false);// true表示标准全屏，会调起onShowCustomView()，false表示X5全屏；不设置默认false，

                data.PutBoolean("supportLiteWnd", true);// false：关闭小窗；true：开启小窗；不设置默认true，

                data.PutInt("DefaultVideoScreen", 2);// 1：以页面内开始播放，2：以全屏开始播放；不设置默认：1

                webView.X5WebViewExtension.InvokeMiscMethod("setVideoParams",
                        data);
            }
        }

        internal void enablePageVideoFunc()
        {
            if (webView.X5WebViewExtension != null)
            {
                Toast.MakeText(this, "页面内全屏播放模式", ToastLength.Long).Show();
                Bundle data = new Bundle();

                data.PutBoolean("standardFullScreen", false);// true表示标准全屏，会调起onShowCustomView()，false表示X5全屏；不设置默认false，

                data.PutBoolean("supportLiteWnd", false);// false：关闭小窗；true：开启小窗；不设置默认true，

                data.PutInt("DefaultVideoScreen", 1);// 1：以页面内开始播放，2：以全屏开始播放；不设置默认：1

                webView.X5WebViewExtension.InvokeMiscMethod("setVideoParams", data);
            }
        }
    }
}

