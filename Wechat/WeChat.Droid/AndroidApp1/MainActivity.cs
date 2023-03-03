namespace AndroidApp1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static Com.Tencent.MM.Opensdk.Openapi.IWXAPI mWxApi { get; set; }
        private const string WX_APPID = "";
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // 2.³õÊ¼»¯Î¢ÐÅSDK
            mWxApi = Com.Tencent.MM.Opensdk.Openapi.WXAPIFactory.CreateWXAPI(this, WX_APPID, true);
            mWxApi.RegisterApp(WX_APPID);
            //  Com.Tencent.MM.Opensdk.Openapi.IWXAPI api= 
        }
    }
}