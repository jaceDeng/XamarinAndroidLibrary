//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using CustomViewCallback = Com.Tencent.Smtt.Export.External.Interfaces.IX5WebChromeClientCustomViewCallback;


//using WebChromeClient = Com.Tencent.Smtt.Sdk.WebChromeClient;
//using WebSettings = Com.Tencent.Smtt.Sdk.WebSettings;
//using LayoutAlgorithm = Com.Tencent.Smtt.Sdk.WebSettings.LayoutAlgorithm;
//using WebView = Com.Tencent.Smtt.Sdk.WebView;

//namespace AppTBS.Droid
//{
//    using Android.Text;
//    using Java.Net;
//    using System;




//    public class BrowserActivity : Activity
//    {
//        private bool InstanceFieldsInitialized = false;

//        public BrowserActivity()
//        {
//            if (!InstanceFieldsInitialized)
//            {
//                InitializeInstanceFields();
//                InstanceFieldsInitialized = true;
//            }
//        }

//        private void InitializeInstanceFields()
//        {
//            mCurrentUrl = mUrlStartNum;
//        }

//        /// <summary>
//        /// 作为一个浏览器的示例展示出来，采用android+web的模式
//        /// </summary>
//        private X5WebView mWebView;
//        private ViewGroup mViewParent;
//        private ImageButton mBack;
//        private ImageButton mForward;
//        private ImageButton mExit;
//        private ImageButton mHome;
//        private ImageButton mMore;
//        private Button mGo;
//        private EditText mUrl;

//        private const string mHomeUrl = "http://app.html5.qq.com/navi/index";
//        private const string TAG = "SdkDemo";
//        private const int MAX_LENGTH = 14;
//        private bool mNeedTestPage = false;

//        private readonly int disable = 120;
//        private readonly int enable = 255;

//        private ProgressBar mPageLoadingProgressBar = null;

//        private ValueCallback<Uri> uploadFile;

//        private URL mIntentUrl;

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            Window.Format = PixelFormat.TRANSLUCENT;

//            Intent intent = Intent;
//            if (intent != null)
//            {
//                try
//                {
//                    mIntentUrl = new URL(intent.Data.ToString());
//                }
//                catch (MalformedURLException e)
//                {
//                    Console.WriteLine(e.ToString());
//                    Console.Write(e.StackTrace);
//                }
//                catch (System.NullReferenceException)
//                {

//                }
//                catch (Exception)
//                {
//                }
//            }
//            //
//            try
//            {
//                if (int.Parse(android.os.Build.VERSION.SDK) >= 11)
//                {
//                    Window.setFlags(android.view.WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED, android.view.WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED);
//                }
//            }
//            catch (Exception)
//            {
//            }

//            /*
//             * getWindow().addFlags(
//             * android.view.WindowManager.LayoutParams.FLAG_FULLSCREEN);
//             */
//            ContentView = R.layout.activity_main;
//            mViewParent = (ViewGroup)findViewById(R.id.webView1);

//            initBtnListenser();

//            mTestHandler.sendEmptyMessageDelayed(MSG_INIT_UI, 10);

//        }

//        private void changGoForwardButton(WebView view)
//        {
//            if (view.CanGoBack())
//            {
//                mBack.Alpha = enable;
//            }
//            else
//            {
//                mBack.Alpha = disable;
//            }
//            if (view.CanGoForward())
//            {
//                mForward.Alpha = enable;
//            }
//            else
//            {
//                mForward.Alpha = disable;
//            }
//            if (view.Url != null && view.Url.equalsIgnoreCase(mHomeUrl))
//            {
//                mHome.Alpha = disable;
//                mHome.Enabled = false;
//            }
//            else
//            {
//                mHome.Alpha = enable;
//                mHome.Enabled = true;
//            }
//        }

//        private void initProgressBar()
//        {
//            mPageLoadingProgressBar = (ProgressBar)FindViewById(R.id.progressBar1); // new
//                                                                                    // ProgressBar(getApplicationContext(),
//                                                                                    // null,
//                                                                                    // android.R.attr.progressBarStyleHorizontal);
//            mPageLoadingProgressBar.Max = 100;
//            mPageLoadingProgressBar.ProgressDrawable = this.Resources.getDrawable(R.drawable.color_progressbar);
//        }

//        private void init()
//        {

//            mWebView = new X5WebView(this, null);

//            mViewParent.addView(mWebView, new FrameLayout.LayoutParams(FrameLayout.LayoutParams.FILL_PARENT, FrameLayout.LayoutParams.FILL_PARENT));

//            initProgressBar();

//            mWebView.WebViewClient = new WebViewClientAnonymousInnerClass(this);

//            mWebView.WebChromeClient = new WebChromeClientAnonymousInnerClass(this);

//            mWebView.DownloadListener = new DownloadListenerAnonymousInnerClass(this);

//            WebSettings webSetting = mWebView.Settings;
//            webSetting.AllowFileAccess = true;
//            webSetting.LayoutAlgorithm = WebSettings.LayoutAlgorithm.NARROW_COLUMNS;
//            webSetting.SupportZoom = true;
//            webSetting.BuiltInZoomControls = true;
//            webSetting.UseWideViewPort = true;
//            webSetting.SupportMultipleWindows = false;
//            // webSetting.setLoadWithOverviewMode(true);
//            webSetting.AppCacheEnabled = true;
//            // webSetting.setDatabaseEnabled(true);
//            webSetting.DomStorageEnabled = true;
//            webSetting.JavaScriptEnabled = true;
//            webSetting.GeolocationEnabled = true;
//            webSetting.AppCacheMaxSize = long.MaxValue;
//            webSetting.AppCachePath = this.getDir("appcache", 0).Path;
//            webSetting.DatabasePath = this.getDir("databases", 0).Path;
//            webSetting.GeolocationDatabasePath = this.getDir("geolocation", 0).Path;
//            // webSetting.setPageCacheCapacity(IX5WebSettings.DEFAULT_CACHE_CAPACITY);
//            webSetting.PluginState = WebSettings.PluginState.ON_DEMAND;
//            // webSetting.setRenderPriority(WebSettings.RenderPriority.HIGH);
//            // webSetting.setPreFectch(true);
//            long time = DateTimeHelper.CurrentUnixTimeMillis();
//            if (mIntentUrl == null)
//            {
//                mWebView.loadUrl(mHomeUrl);
//            }
//            else
//            {
//                mWebView.loadUrl(mIntentUrl.ToString());
//            }
//            TbsLog.d("time-cost", "cost time: " + (DateTimeHelper.CurrentUnixTimeMillis() - time));
//            CookieSyncManager.createInstance(this);
//            CookieSyncManager.Instance.sync();
//        }

//        private class WebViewClientAnonymousInnerClass : WebViewClient
//        {
//            private readonly BrowserActivity outerInstance;

//            public WebViewClientAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }

//            public override bool shouldOverrideUrlLoading(WebView view, string url)
//            {
//                return false;
//            }

//            public override void onPageFinished(WebView view, string url)
//            {
//                base.onPageFinished(view, url);
//                // mTestHandler.sendEmptyMessage(MSG_OPEN_TEST_URL);
//                mTestHandler.sendEmptyMessageDelayed(MSG_OPEN_TEST_URL, 5000); // 5s?
//                if (int.Parse(android.os.Build.VERSION.SDK) >= 16)
//                {
//                    outerInstance.changGoForwardButton(view);
//                }
//                /* mWebView.showLog("test Log"); */
//            }
//        }

//        private class WebChromeClientAnonymousInnerClass : WebChromeClient
//        {
//            private readonly BrowserActivity outerInstance;

//            public WebChromeClientAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override bool onJsConfirm(WebView arg0, string arg1, string arg2, JsResult arg3)
//            {
//                return base.onJsConfirm(arg0, arg1, arg2, arg3);
//            }

//            internal View myVideoView;
//            internal View myNormalView;
//            internal CustomViewCallback callback;

//            // /////////////////////////////////////////////////////////
//            //
//            /// <summary>
//            /// 全屏播放配置
//            /// </summary>
//            public override void onShowCustomView(View view, CustomViewCallback customViewCallback)
//            {
//                FrameLayout normalView = (FrameLayout)findViewById(R.id.web_filechooser);
//                ViewGroup viewGroup = (ViewGroup)normalView.Parent;
//                viewGroup.removeView(normalView);
//                viewGroup.addView(view);
//                myVideoView = view;
//                myNormalView = normalView;
//                callback = customViewCallback;
//            }

//            public override void onHideCustomView()
//            {
//                if (callback != null)
//                {
//                    callback.onCustomViewHidden();
//                    callback = null;
//                }
//                if (myVideoView != null)
//                {
//                    ViewGroup viewGroup = (ViewGroup)myVideoView.Parent;
//                    viewGroup.removeView(myVideoView);
//                    viewGroup.addView(myNormalView);
//                }
//            }

//            public override bool onJsAlert(WebView arg0, string arg1, string arg2, JsResult arg3)
//            {
//                /// <summary>
//                /// 这里写入你自定义的window alert
//                /// </summary>
//                return base.onJsAlert(null, arg1, arg2, arg3);
//            }
//        }

//        private class DownloadListenerAnonymousInnerClass : DownloadListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public DownloadListenerAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onDownloadStart(string arg0, string arg1, string arg2, string arg3, long arg4)
//            {
//                TbsLog.d(TAG, "url: " + arg0);
//                (new AlertDialog.Builder(outerInstance)).setTitle("allow to download？").setPositiveButton("yes", new OnClickListenerAnonymousInnerClass(this))
//                               .setNegativeButton("no", new OnClickListenerAnonymousInnerClass2(this))
//                               .setOnCancelListener(new OnCancelListenerAnonymousInnerClass(this))
//                               .show();
//            }

//            private class OnClickListenerAnonymousInnerClass : DialogInterface.OnClickListener
//            {
//                private readonly DownloadListenerAnonymousInnerClass outerInstance;

//                public OnClickListenerAnonymousInnerClass(DownloadListenerAnonymousInnerClass outerInstance) : base(outerInstance.outerInstance)
//                {
//                    this.outerInstance = outerInstance;
//                }

//                public override void onClick(DialogInterface dialog, int which)
//                {
//                    Toast.makeText(outerInstance.outerInstance, "fake message: i'll download...", 1000).show();
//                }
//            }

//            private class OnClickListenerAnonymousInnerClass2 : DialogInterface.OnClickListener
//            {
//                private readonly DownloadListenerAnonymousInnerClass outerInstance;

//                public OnClickListenerAnonymousInnerClass2(DownloadListenerAnonymousInnerClass outerInstance)
//                {
//                    this.outerInstance = outerInstance;
//                }


//                public override void onClick(DialogInterface dialog, int which)
//                {
//                    // TODO Auto-generated method stub
//                    Toast.makeText(outerInstance.outerInstance, "fake message: refuse download...", Toast.LENGTH_SHORT).show();
//                }
//            }

//            private class OnCancelListenerAnonymousInnerClass : DialogInterface.OnCancelListener
//            {
//                private readonly DownloadListenerAnonymousInnerClass outerInstance;

//                public OnCancelListenerAnonymousInnerClass(DownloadListenerAnonymousInnerClass outerInstance)
//                {
//                    this.outerInstance = outerInstance;
//                }


//                public override void onCancel(DialogInterface dialog)
//                {
//                    // TODO Auto-generated method stub
//                    Toast.makeText(outerInstance.outerInstance, "fake message: refuse download...", Toast.LENGTH_SHORT).show();
//                }
//            }
//        }

//        private void initBtnListenser()
//        {
//            mBack = (ImageButton)findViewById(R.id.btnBack1);
//            mForward = (ImageButton)findViewById(R.id.btnForward1);
//            mExit = (ImageButton)findViewById(R.id.btnExit1);
//            mHome = (ImageButton)findViewById(R.id.btnHome1);
//            mGo = (Button)findViewById(R.id.btnGo1);
//            mUrl = (EditText)findViewById(R.id.editUrl1);
//            mMore = (ImageButton)findViewById(R.id.btnMore);
//            if (int.Parse(android.os.Build.VERSION.SDK) >= 16)
//            {
//                mBack.Alpha = disable;
//                mForward.Alpha = disable;
//                mHome.Alpha = disable;
//            }
//            mHome.Enabled = false;

//            mBack.OnClickListener = new OnClickListenerAnonymousInnerClass(this);

//            mForward.OnClickListener = new OnClickListenerAnonymousInnerClass2(this);

//            mGo.OnClickListener = new OnClickListenerAnonymousInnerClass3(this);

//            mMore.OnClickListener = new OnClickListenerAnonymousInnerClass4(this);

//            mUrl.OnFocusChangeListener = new OnFocusChangeListenerAnonymousInnerClass(this);

//            mUrl.addTextChangedListener(new TextWatcherAnonymousInnerClass(this));

//            mHome.OnClickListener = new OnClickListenerAnonymousInnerClass5(this);

//            mExit.OnClickListener = new OnClickListenerAnonymousInnerClass6(this);
//        }

//        private class OnClickListenerAnonymousInnerClass : View.OnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onClick(View v)
//            {
//                if (outerInstance.mWebView != null && outerInstance.mWebView.canGoBack())
//                {
//                    outerInstance.mWebView.goBack();
//                }
//            }
//        }

//        private class OnClickListenerAnonymousInnerClass2 : View.OnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass2(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onClick(View v)
//            {
//                if (outerInstance.mWebView != null && outerInstance.mWebView.canGoForward())
//                {
//                    outerInstance.mWebView.goForward();
//                }
//            }
//        }

//        private class OnClickListenerAnonymousInnerClass3 : View.OnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass3(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onClick(View v)
//            {
//                string url = outerInstance.mUrl.Text.ToString();
//                outerInstance.mWebView.loadUrl(url);
//                outerInstance.mWebView.requestFocus();
//            }
//        }

//        private class OnClickListenerAnonymousInnerClass4 : View.OnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass4(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onClick(View v)
//            {
//                Toast.makeText(outerInstance, "not completed", Toast.LENGTH_LONG).show();
//            }
//        }

//        private class OnFocusChangeListenerAnonymousInnerClass : View.OnFocusChangeListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnFocusChangeListenerAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onFocusChange(View v, bool hasFocus)
//            {
//                if (hasFocus)
//                {
//                    outerInstance.mGo.Visibility = View.VISIBLE;
//                    if (null == outerInstance.mWebView.Url)
//                    {
//                        return;
//                    }
//                    if (outerInstance.mWebView.Url.equalsIgnoreCase(mHomeUrl))
//                    {
//                        outerInstance.mUrl.Text = "";
//                        outerInstance.mGo.Text = "首页";
//                        outerInstance.mGo.TextColor = 0X6F0F0F0F;
//                    }
//                    else
//                    {
//                        outerInstance.mUrl.Text = outerInstance.mWebView.Url;
//                        outerInstance.mGo.Text = "进入";
//                        outerInstance.mGo.TextColor = 0X6F0000CD;
//                    }
//                }
//                else
//                {
//                    outerInstance.mGo.Visibility = View.GONE;
//                    string title = outerInstance.mWebView.Title;
//                    if (!string.ReferenceEquals(title, null) && title.Length > MAX_LENGTH)
//                    {
//                        outerInstance.mUrl.Text = title.Substring(0, MAX_LENGTH) + "...";
//                    }
//                    else
//                    {
//                        outerInstance.mUrl.Text = title;
//                    }
//                    InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
//                    imm.hideSoftInputFromWindow(v.WindowToken, 0);
//                }
//            }

//        }

//        private class TextWatcherAnonymousInnerClass : Java.Lang.Object, ITextWatcher
//        {
//            private readonly BrowserActivity outerInstance;

//            public TextWatcherAnonymousInnerClass(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void AfterTextChanged(IEditable s)
//            {
//                // TODO Auto-generated method stub

//                string url = null;
//                if (outerInstance.mUrl.Text != null)
//                {
//                    url = outerInstance.mUrl.Text.ToString();
//                }

//                if (string.ReferenceEquals(url, null) || outerInstance.mUrl.Text.ToString().Equals("", StringComparison.OrdinalIgnoreCase))
//                {
//                    outerInstance.mGo.Text = "请输入网址";
//                    outerInstance.mGo.SetTextColor(0x6F0F0F0F);
//                }
//                else
//                {
//                    outerInstance.mGo.Text = "进入";
//                    outerInstance.mGo.TextColor = 0X6F0000CD;
//                }
//            }
//            override 
            
//        }

//        private class OnClickListenerAnonymousInnerClass5 : View.IOnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass5(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }


//            public override void onClick(View v)
//            {
//                if (outerInstance.mWebView != null)
//                {
//                    outerInstance.mWebView.loadUrl(mHomeUrl);
//                }
//            }
//        }

//        private class OnClickListenerAnonymousInnerClass6 : View.OnClickListener
//        {
//            private readonly BrowserActivity outerInstance;

//            public OnClickListenerAnonymousInnerClass6(BrowserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }

//            public override void onClick(View v)
//            {
//                Process.killProcess(Process.myPid());
//            }
//        }

//        internal bool[] m_selected = new bool[] { true, true, true, true, false, false, true };


//        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent @event)
//        {
          
//            if (keyCode == KeyEvent.KEYCODE_BACK)
//            {
//                if (mWebView != null && mWebView.canGoBack())
//                {
//                    mWebView.goBack();
//                    if (int.Parse(android.os.Build.VERSION.SDK) >= 16)
//                    {
//                        changGoForwardButton(mWebView);
//                    }
//                    return true;
//                }
//                else
//                {
//                    return base.onKeyDown(keyCode, @event);
//                }
//            }
//            return base.onKeyDown(keyCode, @event);
//        }

//        protected internal override void onActivityResult(int requestCode, int resultCode, Intent data)
//        {
//            TbsLog.d(TAG, "onActivityResult, requestCode:" + requestCode + ",resultCode:" + resultCode);

//            if (resultCode == RESULT_OK)
//            {
//                switch (requestCode)
//                {
//                    case 0:
//                        if (null != uploadFile)
//                        {
//                            Uri result = data == null || resultCode != RESULT_OK ? null : data.Data;
//                            uploadFile.onReceiveValue(result);
//                            uploadFile = null;
//                        }
//                        break;
//                    default:
//                        break;
//                }
//            }
//            else if (resultCode == RESULT_CANCELED)
//            {
//                if (null != uploadFile)
//                {
//                    uploadFile.onReceiveValue(null);
//                    uploadFile = null;
//                }

//            }

//        }

//        protected internal override void onNewIntent(Intent intent)
//        {
//            if (intent == null || mWebView == null || intent.Data == null)
//            {
//                return;
//            }
//            mWebView.loadUrl(intent.Data.ToString());
//        }

//        protected internal override void onDestroy()
//        {
//            if (mTestHandler != null)
//            {
//                mTestHandler.removeCallbacksAndMessages(null);
//            }
//            if (mWebView != null)
//            {
//                mWebView.destroy();
//            }
//            base.onDestroy();
//        }

//        public const int MSG_OPEN_TEST_URL = 0;
//        public const int MSG_INIT_UI = 1;
//        private readonly int mUrlStartNum = 0;
//        private int mCurrentUrl;
//        private Handler mTestHandler = new HandlerAnonymousInnerClass();

//        private class HandlerAnonymousInnerClass : Handler
//        {
//            public override void handleMessage(Message msg)
//            {
//                switch (msg.what)
//                {
//                    case MSG_OPEN_TEST_URL:
//                        if (!outerInstance.mNeedTestPage)
//                        {
//                            return;
//                        }

//                        string testUrl = "file:///sdcard/outputHtml/html/"
//                                + Convert.ToString(outerInstance.mCurrentUrl) + ".html";
//                        if (outerInstance.mWebView != null)
//                        {
//                            outerInstance.mWebView.loadUrl(testUrl);
//                        }

//                        outerInstance.mCurrentUrl++;
//                        break;
//                    case MSG_INIT_UI:
//                        outerInstance.init();
//                        break;
//                }
//                base.handleMessage(msg);
//            }
//        }

//    }
 
//    internal static class DateTimeHelper
//    {
//        private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
//        public static long CurrentUnixTimeMillis()
//        {
//            return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
//        }
//    }

//}