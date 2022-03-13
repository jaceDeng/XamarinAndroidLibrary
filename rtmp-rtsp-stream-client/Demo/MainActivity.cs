using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Pedro.Rtplibrary.Rtmp;
using Com.Pedro.Rtplibrary.Rtsp;

namespace Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private class ConnectCheckerRtsp : Java.Lang.Object, Com.Pedro.Rtsp.Utils.IConnectCheckerRtsp
        {
            public void OnAuthErrorRtsp()
            {
                //throw new System.NotImplementedException();
            }

            public void OnAuthSuccessRtsp()
            {
              //  throw new System.NotImplementedException();
            }

            public void OnConnectionFailedRtsp(string reason)
            {
               // throw new System.NotImplementedException();
            }

            public void OnConnectionStartedRtsp(string rtspUrl)
            {
               // throw new System.NotImplementedException();
            }

            public void OnConnectionSuccessRtsp()
            {
               // throw new System.NotImplementedException();
            }

            public void OnDisconnectRtsp()
            {
              //  throw new System.NotImplementedException();
            }

            public void OnNewBitrateRtsp(long bitrate)
            {
               // throw new System.NotImplementedException();
            }
        }
        private class ConnectCheckerRtmp : Java.Lang.Object, Com.Pedro.Rtmp.Utils.IConnectCheckerRtmp
        {
            public void OnAuthErrorRtmp()
            {
                System.Diagnostics.Debug.Fail("授权失败");

                //  throw new System.NotImplementedException();
            }

            public void OnAuthSuccessRtmp()
            {
                System.Diagnostics.Debug.Print("授权成功");
                // throw new System.NotImplementedException();
            }

            public void OnConnectionFailedRtmp(string reason)
            {
                //throw new System.NotImplementedException();
            }

            public void OnConnectionStartedRtmp(string rtmpUrl)
            {
                System.Diagnostics.Debug.Print("开始成功" + rtmpUrl);
                // throw new System.NotImplementedException();
            }

            public void OnConnectionSuccessRtmp()
            {
                System.Diagnostics.Debug.Print("连接成功");
                //  throw new System.NotImplementedException();
            }

            public void OnDisconnectRtmp()
            {
                // throw new System.NotImplementedException();
            }

            public void OnNewBitrateRtmp(long bitrate)
            {
                //  throw new System.NotImplementedException();
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            FindViewById<Button>(Resource.Id.btn).Click += MainActivity_Click; ;

        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            //请先获取下摄像头  麦克风权限 文件读写权限
            //create builder
            //by default TCP protocol.
            RtspCamera1 rtspCamera1 = new RtspCamera1(this, new ConnectCheckerRtsp());
            //start stream
            if (rtspCamera1.PrepareAudio() && rtspCamera1.PrepareVideo())
            {
                rtspCamera1.StartStream("rtsp://61.157.96.59:8554/live/play");
            }
            else
            {
                /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
            }
            //stop stream
          //  rtspCamera1.StopStream();

            ////
            ////default

            ////create builder
            //RtmpCamera1 rtmpCamera1 = new RtmpCamera1(this, new ConnectCheckerRtmp());
            ////start stream
            //if (rtmpCamera1.PrepareAudio() && rtmpCamera1.PrepareVideo())
            //{
            //    rtmpCamera1.StartStream("rtmp://yourEndPoint");
            //}
            //else
            //{
            //    /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
            //}
            ////stop stream
            //rtmpCamera1.StopStream();

            ////with params

            ////create builder
            //RtmpCamera1 rtmpCamera1 = new RtmpCamera1(openGlView, connectCheckerRtmp);
            ////start stream
            //if (rtmpCamera1.prepareAudio(int bitrate, int sampleRate, boolean isStereo, boolean echoCanceler,
            //      boolean noiseSuppressor) && rtmpCamera1.prepareVideo(int width, int height, int fps, int bitrate, int rotation))
            //{
            //    rtmpCamera1.startStream("rtmp://yourEndPoint");
            //}
            //else
            //{
            //    /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
            //}
            ////stop stream
            //rtmpCamera1.stopStream();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}