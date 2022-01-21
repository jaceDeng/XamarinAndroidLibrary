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

//namespace AppTBS.Droid
//{


//    public class FilechooserActivity : Activity
//    {

//        /// <summary>
//        /// 用于展示在web端<input type=text>的标签被选择之后，文件选择器的制作和生成
//        /// </summary>

//        private X5WebView webView;
//        private ValueCallback<Uri> uploadFile;
//        private ValueCallback<Uri[]> uploadFiles;

//        protected internal override void onCreate(Bundle savedInstanceState)
//        {
//            // TODO Auto-generated method stub
//            base.onCreate(savedInstanceState);
//            ContentView = R.layout.filechooser_layout;

//            webView = (X5WebView)findViewById(R.id.web_filechooser);

//            webView.WebChromeClient = new WebChromeClientAnonymousInnerClass(this);

//            webView.loadUrl("file:///android_asset/webpage/fileChooser.html");

//        }

//        private class WebChromeClientAnonymousInnerClass : WebChromeClient
//        {
//            private readonly FilechooserActivity outerInstance;

//            public WebChromeClientAnonymousInnerClass(FilechooserActivity outerInstance)
//            {
//                this.outerInstance = outerInstance;
//            }

//            // For Android 3.0+
//            public void openFileChooser(ValueCallback<Uri> uploadMsg, string acceptType)
//            {
//                Log.i("test", "openFileChooser 1");
//                outerInstance.uploadFile = outerInstance.uploadFile;
//                outerInstance.openFileChooseProcess();
//            }

//            // For Android < 3.0
//            public void openFileChooser(ValueCallback<Uri> uploadMsgs)
//            {
//                Log.i("test", "openFileChooser 2");
//                outerInstance.uploadFile = outerInstance.uploadFile;
//                outerInstance.openFileChooseProcess();
//            }

//            // For Android  > 4.1.1
//            public void openFileChooser(ValueCallback<Uri> uploadMsg, string acceptType, string capture)
//            {
//                Log.i("test", "openFileChooser 3");
//                outerInstance.uploadFile = outerInstance.uploadFile;
//                outerInstance.openFileChooseProcess();
//            }

//            // For Android  >= 5.0
//            public bool onShowFileChooser(com.tencent.smtt.sdk.WebView webView, ValueCallback<Uri[]> filePathCallback, WebChromeClient.FileChooserParams fileChooserParams)
//            {
//                Log.i("test", "openFileChooser 4:" + filePathCallback.ToString());
//                outerInstance.uploadFiles = filePathCallback;
//                outerInstance.openFileChooseProcess();
//                return true;
//            }

//        }

//        private void openFileChooseProcess()
//        {
//            Intent i = new Intent(Intent.ACTION_GET_CONTENT);
//            i.addCategory(Intent.CATEGORY_OPENABLE);
//            i.Type = "*/*";
//            startActivityForResult(Intent.createChooser(i, "test"), 0);
//        }

//        protected internal override void onActivityResult(int requestCode, int resultCode, Intent data)
//        {
//            // TODO Auto-generated method stub
//            base.onActivityResult(requestCode, resultCode, data);

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
//                        if (null != uploadFiles)
//                        {
//                            Uri result = data == null || resultCode != RESULT_OK ? null : data.Data;
//                            uploadFiles.onReceiveValue(new Uri[] { result });
//                            uploadFiles = null;
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

//        /// <summary>
//        /// 确保注销配置能够被释放
//        /// </summary>
//        protected internal override void onDestroy()
//        {
//            // TODO Auto-generated method stub
//            if (this.webView != null)
//            {
//                webView.destroy();
//            }
//            base.onDestroy();
//        }

//    }
//}

