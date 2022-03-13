using System;
using System.Collections.Generic;
using System.Text;


namespace Com.Pedro.Rtmp.Rtmp.Message.Control
{

    public sealed partial class UserControl : global::Com.Pedro.Rtmp.Rtmp.Message.RtmpMessage
    {
        /// <summary>
        /// 为了和java的api 保持一致 可以用GetTypeEnum代替
        /// </summary>
        /// <returns></returns>
        public Type getType()
        {

            return GetTypeEnum();
        }

         

    }
}
