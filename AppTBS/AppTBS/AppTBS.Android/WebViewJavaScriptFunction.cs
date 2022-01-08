using Android.Webkit;
using Java.Interop;

namespace AppTBS.Droid
{
    internal class WebViewJavaScriptFunction : Java.Lang.Object
    {
        private MainActivity activity;
        public WebViewJavaScriptFunction(MainActivity activity)
        {
            this.activity = activity;
        }

        [JavascriptInterface]
        [Export("onJsFunctionCalled")]

        public void onJsFunctionCalled(string tag)
        {
            // TODO Auto-generated method stub

        }

        [JavascriptInterface]
        [Export("onX5ButtonClicked")]

        public void onX5ButtonClicked()
        {
            activity.enableX5FullscreenFunc();
        }

        [JavascriptInterface]
        [Export("onCustomButtonClicked")]
        public void onCustomButtonClicked()
        {
            activity.disableX5FullscreenFunc();
        }

        [JavascriptInterface]
        [Export("onLiteWndButtonClicked")]
        public void onLiteWndButtonClicked()
        {
            activity.enableLiteWndFunc();
        }

        [JavascriptInterface]
        [Export("onPageVideoClicked")]
        public void onPageVideoClicked()
        {
            activity.enablePageVideoFunc();
        }
    }
}