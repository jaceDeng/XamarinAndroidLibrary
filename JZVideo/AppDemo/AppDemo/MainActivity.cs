using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Bumptech.Glide;
using CN.Jzvd;

namespace AppDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        JzvdStd jzvdStd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            jzvdStd = FindViewById<JzvdStd>(Resource.Id.videoplayer);

            jzvdStd.SetUp("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
                    //当前使用 ijk的内核 可以根据自己需要 切换相关的内核
                    //https://github.com/Jzvd/JZVideo/tree/develop/demo/src/main/java/cn/jzvd/demo/CustomMedia 相关其他内核的切换
                    , "标题好", JzvdStd.ScreenNormal,Java.Lang.Class.FromType(typeof(JZMediaIjk)));

            Glide.With(this)
                    .Load("https://ns-strategy.cdn.bcebos.com/ns-strategy/upload/fc_big_pic/part-00636-3399.jpg")
                    .Into(jzvdStd.PosterImageView);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}