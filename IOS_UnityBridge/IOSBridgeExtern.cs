using System;
using System.Runtime.InteropServices;

namespace JCiOSSDK
{
    //--------------------------------------------------
    //----------This file is IOS Bridge external interface file----------
    //--------------------------------------------------

    public partial class IOSBridge
    {

        static IOSBridge()
        {
            UnityEngine.Debug.Log("IOSBridge static constructor");
            IOSListener.OnBannerLoaded += OnBannerLoaded;
        }

        private static void OnBannerLoaded(bool value)
        {
            if (value)
            {
                if (BannerLastState)
                {
                    showBannerView();
                }
            }
        }

#if UNITY_IPHONE && !UNITY_EDITOR
        //[DllImport("__Internal")]
        //static extern bool initSDKWithC();

        [DllImport("__Internal")]
        static extern int Inter_showpacingCallBack();

        [DllImport("__Internal")]
        static extern bool isReadyIntersitial();

        [DllImport("__Internal")]
        static extern void showIntersitial();

        [DllImport("__Internal")]
        static extern bool isReadyRewardVideo();

        [DllImport("__Internal")]
        static extern void showRewardVideo();

        [DllImport("__Internal")]
        static extern void showBannerView();

        [DllImport("__Internal")]
        static extern bool isReadyBanner();

        [DllImport("__Internal")]
        static extern void removeBannerView();

        [DllImport("__Internal")]
        static extern void sendEvent(string eventName, string eventData);

        //public static void InitSDK()
        //{
        //    initSDKWithC();
        //}
#else       
        static int Inter_showpacingCallBack() { return 0; }

        static bool isReadyIntersitial() { return true; }

        static void showIntersitial() { }

        static bool isReadyRewardVideo() { return true; }

        static void showRewardVideo() { }

        static bool isReadyBanner() { return true; }

        static void showBannerView() { }

        static void removeBannerView() { }

        static void sendEvent(string eventName, string eventData) { }
#endif
    }
}
