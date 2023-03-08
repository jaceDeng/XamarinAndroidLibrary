 
 

## XamainAndroidBindLibary
自己做的一些安卓绑定好的第三方库并带demo的项目
<label style="color:red">喜欢请帮我点个star</label>
希望能够帮助大家。<br>
使用demo进行更改首先考虑 application然后是AndroidManifest.xml<br>
里面的很多细节请注意复制和查看尤其是包名
以下demo都是以真机为主。如果想在模拟器运行。请注意拷贝x86相关so文件到lib中

### 1、信鸽推送demo已经完成
<img src="https://raw.githubusercontent.com/jaceDeng/XamarinAndroidLibrary/master/Screenshot/xinge-push-demo.png" width="30%"  style="width:30%"/>

<https://github.com/jsonsugar/XamainAndroidBindLibary/tree/master/Xg-Push/XinGeDemo>

<http://xg.qq.com/>

***
### 2、腾讯Bugly demo
<https://bugly.qq.com/v2/>相关介绍

**注意更换为你自己的app_id**

### 3、weex 集成到你的xamarin中
<https://weex.apache.org/>

### 4、有赞商场集成到你app

<img src="https://raw.githubusercontent.com/jaceDeng/XamarinAndroidLibrary/master/Screenshot/youzan.png" width="30%"  style="width:30%"/>
<https://github.com/youzan/YouzanMobileSDK-Android/>

### 5、阿里云播放器
<img src="https://github.com/jaceDeng/XamarinAndroidLibrary/blob/master/Screenshot/alivec.jpg?raw=true" width="30%"  style="width:30%"/>

### 6、增加一个安卓的摄像头预览的demo演示
新的安卓版本导致预览会非常麻烦 比如我们要在预览中加个框框或者设计个图标之类的 需要用到预览实现 所以我编写了一个demo 方便大家定制化摄像头预览

### 7、Safia 
<https://github.com/yanzhenjie/Sofia/>  沉浸状态栏
<img src="https://raw.githubusercontent.com/yanzhenjie/Sofia/master/image/1.gif" width="30%"  style="width:30%"/>

### 8、友盟推送带
注意友盟推送需要签入java文件才行 因为友盟会起一个新进程

### 9、MobIM.Droid 
聊天im集成
<https://github.com/MobClub/MobIM-for-Android/>
<img src="http://mobim.mob.com/assets/images/mobIM-da65e38d.gif" width="30%"  style="width:30%"/>

### 10、Rongyun 及时通信IM

### 11、SerialPortDemo 安卓串口库
安卓里面使用串口
 

### 12、Glide.Xamarin
这个库官方nuget上有最新的 绑定只是我需要3.6的所以单独绑定了下

### 13、百度推送
百度的安卓推送 示例代码

### 14、微信支付
微信支付与分享安卓绑定库

### 15、极光推送
极光绑定库

### 16、支付宝iot 绑定
https://opendocs.alipay.com/iot/01kjr6 
需要注意 库里面依赖了fastjson 所以需要单独处理下json
我们用Newtonsoft 中的json 处理好后序列化为String  调用JSON.Parse(string)  再传入onMessage() 中


### 17、讯飞语音合成 离线sdk 语音唤醒 语音识别相关sdk 绑定
https://www.xfyun.cn/doc/tts/offline_tts/Android-SDK.html#_2%E3%80%81sdk%E9%9B%86%E6%88%90%E6%8C%87%E5%8D%97


### 18、 百度地图

### 19、新增饺子播放器UI 支持多种播放器内核

### 20、安卓图片多媒体选择库 DVMediaSelector   仿造微信的
绑定来源 https://github.com/Devil-Chen/DVMediaSelector

<img src="https://github.com/Devil-Chen/DVMediaSelector/raw/master/screenshot/single_select.png" width="30%"  style="width:30%"/>

### 21 安卓推送RTSP 和RTMP到服务端 推送客户端 不依赖ffmpeg

* [Xamarin.Android.Rtplibrary.Droid](https://www.nuget.org/packages/Xamarin.Android.Rtplibrary.Droid) [![NuGet](https://img.shields.io/nuget/v/Xamarin.Android.Rtplibrary.Droid.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Android.Rtplibrary.Droid)
使用方式
### RTMP:

```csharp
//default
//create builder
RtmpCamera1 rtmpCamera1 = new RtmpCamera1(openGlView, connectCheckerRtmp);
//start stream
if (rtmpCamera1.PrepareAudio() && rtmpCamera1.PrepareVideo()) {
  rtmpCamera1.StartStream("rtmp://yourEndPoint");
} else {
 /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
}
//stop stream
rtmpCamera1.StopStream();
//with params
//create builder
RtmpCamera1 rtmpCamera1 = new RtmpCamera1(openGlView, connectCheckerRtmp);
//start stream
if (rtmpCamera1.PrepareAudio(int bitrate, int sampleRate, boolean isStereo, boolean echoCanceler,
      boolean noiseSuppressor) && rtmpCamera1.PrepareVideo(int width, int height, int fps, int bitrate, int rotation)) {
  rtmpCamera1.StartStream("rtmp://yourEndPoint");
} else {
 /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
}
//stop stream
rtmpCamera1.StopStream();
```

### RTSP:

```csharp
 //请先获取下摄像头  麦克风权限 文件读写权限
            //create builder
            //by default TCP protocol.
            RtspCamera1 rtspCamera1 = new RtspCamera1(this, new ConnectCheckerRtsp());
            //start stream
            if (rtspCamera1.PrepareAudio() && rtspCamera1.PrepareVideo())
            {
                rtspCamera1.StartStream("rtsp://yourEndPoint");
            }
            else
            {
                /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
            }
            //stop stream
//with params
//create builder
RtspCamera1 rtspCamera1 = new RtspCamera1(openGlView, connectCheckerRtsp);
rtspCamera1.setProtocol(protocol);
//start stream
if (rtspCamera1.PrepareAudio(int bitrate, int sampleRate, boolean isStereo, boolean echoCanceler,
      boolean noiseSuppressor) && rtspCamera1.PrepareVideo(int width, int height, int fps, int bitrate, int rotation)) {
  rtspCamera1.StartStream("rtsp://yourEndPoint");
} else {
 /**This device cant init encoders, this could be for 2 reasons: The encoder selected doesnt support any configuration setted or your device hasnt a H264 or AAC encoder (in this case you can see log error valid encoder not found)*/
}
//stop stream
rtspCamera1.StopStream();
```

### 22 极速扫码绑定组件
```
 //需要判断有没有权限
            MNScanConfig scanConfig = new MNScanConfig.Builder()
                //是否震动
                .IsShowVibrate(true)
                //是否鸣叫
                .IsShowBeep(false)
                //是否显示扫码相册
                .IsShowPhotoAlbum(true)

                //显示闪光灯
                .IsShowLightController(true)
                .SetActivityOpenAnime(Resource.Animation.activity_anmie_in)
                .SetActivityExitAnime(Resource.Animation.activity_anmie_out)
                //自定义文案
                .SetScanHintText("")
                //.SetScanHintTextColor(colorText)
                //.SetScanHintTextSize(TextUtils.IsEmpty(mEtHintTextSize.Text.ToString()) ? 14 : int.Parse(mEtHintTextSize.Text.ToString()))
                .SetScanColor(colorLine)
                // .SetSupportZoom(mCbSupportZoom.Checked)
                // .SetLaserStyle(mRbScanlineGrid.Checked ? MNScanConfig.LaserStyle.Grid : MNScanConfig.LaserStyle.Line)
                .SetBgColor(colorBackground)
                  //   .SetGridScanLineColumn(TextUtils.IsEmpty(mEtGridlineNum.Text.ToString()) ? 30 : int.Parse(mEtGridlineNum.Text.ToString()))
                  //  .SetGridScanLineHeight(TextUtils.IsEmpty(mEtGridlineHeight.Text.ToString()) ? 0 : int.Parse(mEtGridlineHeight.Text.ToString()))
                  .SetFullScreenScan(true)
                .SetResultPointConfigs(36, 12, 3, colorResultPointStroke, colorResultPoint)
                //.SetStatusBarConfigs(colorStatusBar, mCbStatusDark.Checked)
                //   .SetScanFrameSizeScale(30 / 100f)
                //   .SetCustomShadeViewLayoutID(Resource.Layout.layout_custom_view, new MNCustomViewBindCallbackAnonymousInnerClass(this))
                .InvokeBuilder();
            MNScanManager.StartScan(this, scanConfig, new MNScanCallbackAnonymousInnerClass(this));
```