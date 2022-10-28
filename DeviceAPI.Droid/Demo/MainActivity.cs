using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Com.Rscja.Barcode;
using Com.Rscja.Deviceapi.Entity;
using Java.Lang;

namespace Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        BarcodeDecoder barcodeDecoder = BarcodeFactory.Instance.BarcodeDecoder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void start()
        {
            barcodeDecoder.StartScan();
        }
        private void stop()
        {
            barcodeDecoder.StopScan();
        }

        class DecodeCallbackImp : Java.Lang.Object, BarcodeDecoder.IDecodeCallback
        {
            public DecodeCallbackImp(MainActivity activity)
            {

            }
            public void OnDecodeComplete(BarcodeEntity barcodeEntity)
            {
                //解码

                if (barcodeEntity.ResultCode == BarcodeDecoder.DecodeSuccess)
                {

                    System.Diagnostics.Debug.Print("data:" + barcodeEntity.BarcodeData);
                  
                }
                else
                {
                    System.Diagnostics.Debug.Print("fail");
                }
            }
        }
        private void open()
        {
            barcodeDecoder.Open(this);
          

            barcodeDecoder.SetDecodeCallback(new DecodeCallbackImp(this));
        }
        private void close()
        {
            barcodeDecoder.Close();
        }

    }
}