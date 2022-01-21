using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Bumptech.Glide;
using Com.Devil.Library.Media;
using Com.Devil.Library.Media.Common;
using Com.Devil.Library.Media.Listener;
using System.Collections.Generic;

namespace App9
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //可使用Glide、Picasso等方式加载，由调用者自己决定
            //设置加载器
          
            MediaSelectorManager.Instance.InitImageLoader(new ImageLoader());
            //最简单的调用
            MediaSelectorManager.OpenSelectMediaWithConfig(this, MediaSelectorManager.DefaultListConfigBuilder.Build(), new OnSelectMediaListener());
        }

        internal class ImageLoader : Java.Lang.Object, IImageLoader
        {
            public void DisplayImage(Context context, string path, ImageView imageView)
            {
                Glide.With(context).Load(path).Into(imageView);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    internal class OnSelectMediaListener : Java.Lang.Object, IOnSelectMediaListener
    {
        public void OnSelectMedia(IList<string> li_path)
        {
            foreach (var item in li_path)
            {
                //这里面是选择的路径
            }

        }
    }
}