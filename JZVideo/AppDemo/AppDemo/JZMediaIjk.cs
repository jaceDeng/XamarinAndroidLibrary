using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CN.Jzvd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TV.Danmaku.Ijk.Media.Player;

namespace AppDemo
{
    /// <summary>
    /// Created by Nathen on 2017/11/18.
    /// ijk兼容SO库:https://github.com/NamHofstadter/IjkPlayerSos
    /// ijk默认不支持https协议,需要的请自行下载so库
    /// https://github.com/Jzvd/JZVideo/blob/develop/demo/src/main/java/cn/jzvd/demo/CustomMedia/JZMediaIjk.java
    /// </summary>

    public class JZMediaIjk : JZMediaInterface, IMediaPlayerOnPreparedListener, IMediaPlayerOnVideoSizeChangedListener, IMediaPlayerOnCompletionListener, IMediaPlayerOnErrorListener, IMediaPlayerOnInfoListener, IMediaPlayerOnBufferingUpdateListener, IMediaPlayerOnSeekCompleteListener, IMediaPlayerOnTimedTextListener
    {
        internal IjkMediaPlayer ijkMediaPlayer;

        public JZMediaIjk(Jzvd jzvd) : base(jzvd)
        {
        }

        public override void Start()
        {
            if (ijkMediaPlayer != null)
            {
                ijkMediaPlayer.Start();
            }
        }
        public override void Prepare()
        {


            Release();
            MMediaHandlerThread = new HandlerThread("JZVD");
            MMediaHandlerThread.Start();
            MMediaHandler = new Handler(MMediaHandlerThread.Looper); //主线程还是非主线程，就在这里
            Handler = new Handler();

            MMediaHandler.Post(() =>
            {
                ijkMediaPlayer = new IjkMediaPlayer();
                ijkMediaPlayer.SetAudioStreamType((int)Android.Media.Stream.Music);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec", 0);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec-auto-rotate", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "mediacodec-handle-resolution-change", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "opensles", 0);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "overlay-format", IjkMediaPlayer.SdlFccRv32);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "framedrop", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "start-on-prepared", 0);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "http-detect-range-support", 0);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryCodec, "skip_loop_filter", 48);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "max-buffer-size", 1024 * 1024);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "enable-accurate-seek", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "reconnect", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "dns_cache_clear", 1);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "fflags", "fastseek");
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryFormat, "probesize", 1024 * 10);
                ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryPlayer, "soundtouch", 1);
                ijkMediaPlayer.SetOnPreparedListener(this);
                ijkMediaPlayer.SetOnVideoSizeChangedListener(this);
                ijkMediaPlayer.SetOnCompletionListener(this);
                ijkMediaPlayer.SetOnErrorListener(this);
                ijkMediaPlayer.SetOnInfoListener(this);
                ijkMediaPlayer.SetOnBufferingUpdateListener(this);
                ijkMediaPlayer.SetOnSeekCompleteListener(this);
                ijkMediaPlayer.SetOnTimedTextListener(this);
                try
                {
                    ijkMediaPlayer.DataSource = Jzvd.JzDataSource.CurrentUrl.ToString();
                    ijkMediaPlayer.SetAudioStreamType((int)Android.Media.Stream.Music);
                    ijkMediaPlayer.SetScreenOnWhilePlaying(true);
                    ijkMediaPlayer.PrepareAsync();
                    ijkMediaPlayer.SetSurface(new Surface(Jzvd.TextureView.SurfaceTexture));
                }
                catch (Java.IO.IOException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.Write(e.StackTrace);
                }
            });

        }

        public override void Pause()
        {
            ijkMediaPlayer.Pause();
        }

        public override bool IsPlaying
        {
            get
            {
                return ijkMediaPlayer.IsPlaying;
            }
        }

        public override void SeekTo(long time)
        {
            ijkMediaPlayer.SeekTo(time);
        }

        public override void Release()
        {
            if (MMediaHandler != null && MMediaHandlerThread != null && ijkMediaPlayer != null)
            { //不知道有没有妖孽
                HandlerThread tmpHandlerThread = MMediaHandlerThread;
                IjkMediaPlayer tmpMediaPlayer = ijkMediaPlayer;
                JZMediaInterface.SavedSurface = null;

                MMediaHandler.Post(() =>
                {
                    tmpMediaPlayer.SetSurface(null);
                    tmpMediaPlayer.Release();
                    tmpHandlerThread.Quit();
                });
                ijkMediaPlayer = null;
            }
        }

        public override long CurrentPosition
        {
            get
            {
                return ijkMediaPlayer.CurrentPosition;
            }
        }

        public override long Duration
        {
            get
            {
                if (ijkMediaPlayer == null)
                {
                    return 0;
                }
                return ijkMediaPlayer.Duration;
            }
        }

        public override void SetVolume(float leftVolume, float rightVolume)
        {
            ijkMediaPlayer.SetVolume(leftVolume, rightVolume);
        }

        public override void SetSpeed(float val)
        {

            ijkMediaPlayer.SetSpeed(val);

        }

        public void OnPrepared(IMediaPlayer iMediaPlayer)
        {
            Handler.Post(() => Jzvd.OnPrepared());
        }

        public void OnVideoSizeChanged(IMediaPlayer iMediaPlayer, int i, int i1, int i2, int i3)
        {
            Handler.Post(() => Jzvd.OnVideoSizeChanged(iMediaPlayer.VideoWidth, iMediaPlayer.VideoHeight));
        }

        // @Override public boolean onError(tv.danmaku.ijk.media.player.IMediaPlayer iMediaPlayer, final int what, final int extra)
        public bool OnError(IMediaPlayer iMediaPlayer, int what, int extra)
        {
            Handler.Post(() => Jzvd.OnError(what, extra));
            return true;
        }

        //@Override public boolean onInfo(tv.danmaku.ijk.media.player.IMediaPlayer iMediaPlayer, final int what, final int extra)
        public bool OnInfo(IMediaPlayer iMediaPlayer, int what, int extra)
        {
            Handler.Post(() => Jzvd.OnInfo(what, extra));
            return false;
        }
        // @Override public void onBufferingUpdate(tv.danmaku.ijk.media.player.IMediaPlayer iMediaPlayer, final int percent)
        public void OnBufferingUpdate(IMediaPlayer iMediaPlayer, int percent)
        {
            Handler.Post(() => Jzvd.SetBufferProgress(percent));
        }

        public void OnSeekComplete(IMediaPlayer iMediaPlayer)
        {
            Handler.Post(() => Jzvd.OnSeekComplete());
        }

        public void OnTimedText(IMediaPlayer iMediaPlayer, IjkTimedText ijkTimedText)
        {

        }

        public override void SetSurface(Surface value)
        {

            ijkMediaPlayer.SetSurface(value);

        }
        public override bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            return false;
        }
        public override void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            if (SavedSurface == null)
            {
                SavedSurface = surface;
                Prepare();
            }
            else
            {
                Jzvd.TextureView.SurfaceTexture = SavedSurface;
            }
        }
        public override void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {


        }



        public override void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {

        }

        public void OnCompletion(IMediaPlayer iMediaPlayer)
        {
            Handler.Post(() => Jzvd.OnCompletion());
        }
    }

}