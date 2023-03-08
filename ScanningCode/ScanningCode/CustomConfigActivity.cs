using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Maning.Mlkitscanner.Scan;
using Com.Maning.Mlkitscanner.Scan.Callback;
using Com.Maning.Mlkitscanner.Scan.Callback.Act;
using Com.Maning.Mlkitscanner.Scan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Android.Media.MediaParser;

namespace ScanningCode
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class CustomConfigActivity : AppCompatActivity
    {

        /// <summary>
        /// 是否显示相册功能
        /// </summary>
        private CheckBox mCbPhoto;
        /// <summary>
        /// 是否显示闪光灯
        /// </summary>
        private CheckBox mCbLight;
        /// <summary>
        /// 是否需要全屏扫描识别（默认）
        /// </summary>
        private CheckBox mCbFullscreenScan;
        /// <summary>
        /// 是否开启扫描完成震动提醒
        /// </summary>
        private CheckBox mCbVibrate;
        /// <summary>
        /// 是否开启扫描完成声音提醒
        /// </summary>
        private CheckBox mCbBeep;
        /// <summary>
        /// 是否完全自定义遮罩层
        /// </summary>
        private CheckBox mCbCustomView;
        /// <summary>
        /// 输入自定义提示文案
        /// </summary>
        private EditText mEtHintText;
        /// <summary>
        /// 文字大小(sp)
        /// </summary>
        private EditText mEtHintTextSize;
        /// <summary>
        /// 网格扫描高度
        /// </summary>
        private EditText mEtGridlineHeight;
        /// <summary>
        /// 网格扫描列数
        /// </summary>
        private EditText mEtGridlineNum;

        private TextView mBtnColorPickerText;
        private TextView mBtnColorPickerLine;
        private TextView mBtnColorPickerBg;
        /// <summary>
        /// 线性
        /// </summary>
        private RadioButton mRbScanlineLine;
        /// <summary>
        /// 网格
        /// </summary>
        private RadioButton mRbScanlineGrid;


        private string colorText = "#22CE6B";
        private string colorLine = "#22CE6B";
        private string colorBackground = "#22FF0000";
        private string colorStatusBar = "#00000000";
        private string colorResultPoint = "#CC22CE6B";
        private string colorResultPointStroke = "#FFFFFFFF";

        /// <summary>
        /// 是否支持手势缩放
        /// </summary>
        private CheckBox mCbSupportZoom;
        /// <summary>
        /// 是否状态栏黑色字体
        /// </summary>
        private CheckBox mCbStatusDark;
        private TextView mBtnColorStatusbarBg;
        private SeekBar mSbarFrameSize;
        private TextView mTvFrameSize;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_config);
            initView();
        }

        private void initView()
        {
            FindViewById<Button>(Resource.Id.btnscan).Click += (sender, e) =>
            {
                scanCode();
            };
            //mCbPhoto = (CheckBox)FindViewById(Resource.Id.cb_photo);
            //mCbLight = (CheckBox)FindViewById(Resource.Id.cb_light);
            //mCbFullscreenScan = (CheckBox)FindViewById(Resource.Id.cb_fullscreen_scan);
            //mCbVibrate = (CheckBox)FindViewById(Resource.Id.cb_vibrate);
            //mCbBeep = (CheckBox)FindViewById(Resource.Id.cb_beep);
            //mCbCustomView = (CheckBox)FindViewById(Resource.Id.cb_custom_view);
            //mEtHintText = (EditText)FindViewById(Resource.Id.et_hint_text);
            //mEtHintTextSize = (EditText)FindViewById(Resource.Id.et_hint_text_size);
            //mEtGridlineHeight = (EditText)FindViewById(Resource.Id.et_gridline_height);
            //mEtGridlineNum = (EditText)FindViewById(Resource.Id.et_gridline_num);
            //mBtnColorPickerText = (TextView)FindViewById(Resource.Id.btn_color_picker_text);
            //mBtnColorPickerText.Click += (sender, e) =>
            //{
            //    //(new ColorPickerPopup.Builder(this))

            //    //       .InitialColor(Color.ParseColor(colorText)).
            //    //       EnableBrightness(true).EnableAlpha(false).
            //    //       OkTitle("选择颜色").CancelTitle("取消").
            //    //       ShowIndicator(true).ShowValue(true).Build().
            //    //       Show(mBtnColorPickerText, new ColorPickerObserverAnonymousInnerClass(this));


            //};
            //mBtnColorPickerLine = (TextView)FindViewById(Resource.Id.btn_color_picker_line);
            //mBtnColorPickerLine.Click += (sender, e) =>
            //{

            //    //(new ColorPickerPopup.Builder(this)).InitialColor(Color.ParseColor(colorLine))
            //    //.EnableBrightness(true).EnableAlpha(false).OkTitle("选择颜色").CancelTitle("取消")
            //    //.ShowIndicator(true).ShowValue(true).Build().Show(mBtnColorPickerLine, new ColorPickerObserverAnonymousInnerClass2(this));

            //};
            //mBtnColorPickerBg = (TextView)FindViewById(Resource.Id.btn_color_picker_bg);
            //mBtnColorPickerBg.Click += (sender, e) =>
            //{
            //    //(new ColorPickerPopup.Builder(this)).InitialColor(Color.ParseColor(colorBackground)).
            //    //EnableBrightness(true).EnableAlpha(true)
            //    //.OkTitle("选择颜色").CancelTitle("取消").ShowIndicator(true)
            //    //.ShowValue(true).Build()
            //    //.Show(mBtnColorPickerBg, new ColorPickerObserverAnonymousInnerClass3(this));


            //};
            //mRbScanlineLine = (RadioButton)FindViewById(Resource.Id.rb_scanline_line);
            //mRbScanlineGrid = (RadioButton)FindViewById(Resource.Id.rb_scanline_grid);
            //mCbSupportZoom = (CheckBox)FindViewById(Resource.Id.cb_support_zoom);
            //mCbStatusDark = (CheckBox)FindViewById(Resource.Id.cb_status_dark);
            //mBtnColorStatusbarBg = (TextView)FindViewById(Resource.Id.btn_color_statusbar_bg);
            //mBtnColorStatusbarBg.Click += (sender, e) =>
            //{

            //    //(new ColorPickerPopup.Builder(this)).InitialColor(Color.ParseColor(colorStatusBar))
            //    //                                    .EnableBrightness(true)
            //    //                                    .EnableAlpha(true)
            //    //                                    .OkTitle("选择颜色")
            //    //                                    .CancelTitle("取消")
            //    //                                    .ShowIndicator(true)
            //    //                                    .ShowValue(true)
            //    //                                    .Build()
            //    //                                    .Show(mBtnColorStatusbarBg, new ColorPickerObserverAnonymousInnerClass4(this));

            //};
            //mTvFrameSize = (TextView)FindViewById(Resource.Id.tv_frameSize);
            //mSbarFrameSize = (SeekBar)FindViewById(Resource.Id.sbar_frameSize);
            //mSbarFrameSize.ProgressChanged += (seekBar, e) =>
            //{


            //    if (mSbarFrameSize.Progress < 50)
            //    {
            //        mSbarFrameSize.Progress = 50;
            //    }
            //    if (mSbarFrameSize.Progress > 90)
            //    {
            //        mSbarFrameSize.Progress = 90;
            //    }
            //    mTvFrameSize.Text = "扫描框大小比例：" + (mSbarFrameSize.Progress / 100f) + "\n（非全屏模式生效，范围0.5-0.9）";

            //};


        }




        //private class ColorPickerObserverAnonymousInnerClass : ColorPickerPopup.ColorPickerObserver
        //{
        //    private readonly CustomConfigActivity outerInstance;

        //    public ColorPickerObserverAnonymousInnerClass(CustomConfigActivity outerInstance)
        //    {
        //        this.outerInstance = outerInstance;
        //    }

        //    public override void OnColorPicked(int color)
        //    {
        //        outerInstance.colorText = outerInstance.getHexString(color);
        //        outerInstance.mBtnColorPickerText.SetBackgroundColor(new Color(color));
        //    }
        //}

        //private class ColorPickerObserverAnonymousInnerClass2 : ColorPickerPopup.ColorPickerObserver
        //{
        //    private readonly CustomConfigActivity outerInstance;

        //    public ColorPickerObserverAnonymousInnerClass2(CustomConfigActivity outerInstance)
        //    {
        //        this.outerInstance = outerInstance;
        //    }

        //    public override void OnColorPicked(int color)
        //    {
        //        outerInstance.colorLine = outerInstance.getHexString(color);
        //        outerInstance.mBtnColorPickerLine.SetBackgroundColor(new Color(color));
        //    }
        //}

        //private class ColorPickerObserverAnonymousInnerClass3 : ColorPickerPopup.ColorPickerObserver
        //{
        //    private readonly CustomConfigActivity outerInstance;

        //    public ColorPickerObserverAnonymousInnerClass3(CustomConfigActivity outerInstance)
        //    {
        //        this.outerInstance = outerInstance;
        //    }

        //    public override void OnColorPicked(int color)
        //    {
        //        outerInstance.colorBackground = outerInstance.getHexString(color);
        //        outerInstance.mBtnColorPickerBg.SetBackgroundColor(new Color(color));
        //    }
        //}

        //private class ColorPickerObserverAnonymousInnerClass4 : ColorPickerPopup.ColorPickerObserver
        //{
        //    private readonly CustomConfigActivity outerInstance;

        //    public ColorPickerObserverAnonymousInnerClass4(CustomConfigActivity outerInstance)
        //    {
        //        this.outerInstance = outerInstance;
        //    }

        //    public override void OnColorPicked(int color)
        //    {
        //        outerInstance.colorStatusBar = outerInstance.getHexString(color);
        //        outerInstance.mBtnColorStatusbarBg.SetBackgroundColor(new Color(color));
        //    }
        //}

        private string getHexString(int color)
        {
            string format = string.Format("#{0:X}", color);
            Log.Error("=====", "format:" + format);
            if ("#0".Equals(format))
            {
                format = "#00000000";
                Log.Error("=====", "format:" + format);
            }
            return format;
        }

        public virtual void scanCode()
        {
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
        }

        private class MNCustomViewBindCallbackAnonymousInnerClass : Java.Lang.Object, IMNCustomViewBindCallback
        {
            private readonly CustomConfigActivity outerInstance;

            public MNCustomViewBindCallbackAnonymousInnerClass(CustomConfigActivity outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public void OnBindView(View customView)
            {
                if (customView == null)
                {
                    return;
                }
                ImageView iv_back = customView.FindViewById<ImageView>(Resource.Id.iv_back);
                ImageView iv_photo = customView.FindViewById<ImageView>(Resource.Id.iv_photo);
                LinearLayout btn_scan_light = customView.FindViewById<LinearLayout>(Resource.Id.btn_scan_light);
                ImageView iv_scan_light = customView.FindViewById<ImageView>(Resource.Id.iv_scan_light);
                TextView tv_scan_light = customView.FindViewById<TextView>(Resource.Id.tv_scan_light);
                LinearLayout btn_my_card = customView.FindViewById<LinearLayout>(Resource.Id.btn_my_card);
                LinearLayout btn_scan_record = customView.FindViewById<LinearLayout>(Resource.Id.btn_scan_record);
                iv_back.Click += (sender, e) =>
                {
                    MNScanManager.CloseScanPage();
                };
                btn_scan_light.Click += (sender, e) =>
                {

                    //手电筒
                    if (MNScanManager.IsLightOn)
                    {
                        MNScanManager.CloseScanLight();
                        iv_scan_light.SetImageResource(Resource.Drawable.icon_custom_light_close);
                        tv_scan_light.Text = "开启手电筒";
                    }
                    else
                    {
                        MNScanManager.OpenScanLight();
                        iv_scan_light.SetImageResource(Resource.Drawable.icon_custom_light_open);
                        tv_scan_light.Text = "关闭手电筒";
                    }
                };

                iv_photo.Click += (sender, e) =>
                {

                    //打开相册扫描
                    MNScanManager.OpenAlbumPage();
                };
                btn_my_card.Click += (sender, e) =>
                {

                    //我的名片
                    Toast.MakeText(outerInstance, "我的名片", ToastLength.Short).Show();
                };
                btn_scan_record.Click += (sender, e) =>
                {

                    //扫码记录
                    Toast.MakeText(outerInstance, "扫码记录", ToastLength.Short).Show();
                };
            }







        }

        private class MNScanCallbackAnonymousInnerClass : Java.Lang.Object, IMNScanCallback
        {
            private readonly CustomConfigActivity outerInstance;

            public MNScanCallbackAnonymousInnerClass(CustomConfigActivity outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public void OnActivityResult(int resultCode, Intent data)
            {
                outerInstance.handlerResult(resultCode, data);
            }
        }

        private void handlerResult(int resultCode, Intent data)
        {
            switch (resultCode)
            {
                case MNScanManager.ResultSuccess:
                    List<string> results = data.GetStringArrayListExtra(MNScanManager.IntentKeyResultSuccess).ToList();
                    StringBuilder resultStr = new StringBuilder();
                    for (int i = 0; i < results.Count; i++)
                    {
                        resultStr.Append("第" + (i + 1) + "条：");
                        resultStr.Append(results[i]);
                        resultStr.Append("\n");
                    }
                    Toast.MakeText(this, resultStr.ToString(), ToastLength.Short).Show();
                    break;
                case MNScanManager.ResultFail:
                    string resultError = data.GetStringExtra(MNScanManager.IntentKeyResultError);

                    Toast.MakeText(this, resultError.ToString(), ToastLength.Short).Show();
                    break;
                case MNScanManager.ResultCancle:

                    Toast.MakeText(this, "取消扫码", ToastLength.Short).Show();
                    break;
            }
        }

    }


}