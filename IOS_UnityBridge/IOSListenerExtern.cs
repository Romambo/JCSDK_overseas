//#define SHOW_IOS_LISTENER_LOG
using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace JCiOSSDK
{
    //--------------------------------------------------
    //----------This file is IOS Listener external interface file----------
    //--------------------------------------------------

    public partial class IOSListener
    {
        /// <summary>
        /// Static constructor, convenient for automatic call
        /// </summary>
        static IOSListener()
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("IOSListener static constructor");
#endif
            //Generate context thread synchronization object
            var instance = JCiOSSDKSynchronizationContext.Instance;

#if UNITY_IPHONE && !UNITY_EDITOR
            // Before using Listener, call this method for initialization       
            RegistCallBacknotifition();

            RegistSplashCallBack();
            RegistBannerCallBack();
            RegistIntersitialCallBack();
            RegistRewardVideoCallBack();
#endif
        }

#if UNITY_IPHONE
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ResultHandler(string resultString);

        [DllImport("__Internal")]
        static extern void RegistCallBacknotifition();

        [DllImport("__Internal")]
        static extern void splash_CallBack(IntPtr failLoad, IntPtr didShow, IntPtr didClick, IntPtr didClose);

        [DllImport("__Internal")]
        static extern void banner_CallBack(IntPtr sucessLoad, IntPtr failLoad, IntPtr didShow, IntPtr didClick, IntPtr didAutoRefresh, IntPtr tapCloseBtn, IntPtr failToAutoRefresh);

        [DllImport("__Internal")]
        static extern void Intersitial_CallBack(IntPtr failLoad, IntPtr didShow, IntPtr failToShow, IntPtr didClose, IntPtr didClick, IntPtr failToPlayVideo, IntPtr startPlayingVideo, IntPtr endPlayingVideo);

        [DllImport("__Internal")]
        static extern void rewardVideo_CallBack(IntPtr failLoad, IntPtr didRewardSuccess, IntPtr didClose, IntPtr didClick, IntPtr failToPlayVideo, IntPtr startPlayingVideo, IntPtr endPlayingVideo);

        /// <summary>
        /// Register splash callback
        /// </summary>
        private static void RegistSplashCallBack()
        {
            var handler1 = new ResultHandler(splashFailLoad);
            var fp1 = Marshal.GetFunctionPointerForDelegate(handler1);

            var handler2 = new ResultHandler(splashDidShow);
            var fp2 = Marshal.GetFunctionPointerForDelegate(handler2);

            var handler3 = new ResultHandler(splashDidClick);
            var fp3 = Marshal.GetFunctionPointerForDelegate(handler3);

            var handler4 = new ResultHandler(splashDidClose);
            var fp4 = Marshal.GetFunctionPointerForDelegate(handler4);

            splash_CallBack(fp1, fp2, fp3, fp4);
        }

        /// <summary>
        /// Register banner callback
        /// </summary>
        private static void RegistBannerCallBack()
        {
            var handler0 = new ResultHandler(bannersucessLoad);
            var fp0 = Marshal.GetFunctionPointerForDelegate(handler0);

            var handler1 = new ResultHandler(bannerFailLoad);
            var fp1 = Marshal.GetFunctionPointerForDelegate(handler1);

            var handler2 = new ResultHandler(bannerDidShow);
            var fp2 = Marshal.GetFunctionPointerForDelegate(handler2);

            var handler3 = new ResultHandler(bannerDidClick);
            var fp3 = Marshal.GetFunctionPointerForDelegate(handler3);

            var handler4 = new ResultHandler(bannerDidAutoRefresh);
            var fp4 = Marshal.GetFunctionPointerForDelegate(handler4);

            var handler5 = new ResultHandler(bannerTapCloseBtn);
            var fp5 = Marshal.GetFunctionPointerForDelegate(handler5);

            var handler6 = new ResultHandler(bannerFailToAutoRefresh);
            var fp6 = Marshal.GetFunctionPointerForDelegate(handler6);
            banner_CallBack(fp0, fp1, fp2, fp3, fp4, fp5, fp6);
        }

        /// <summary>
        /// Register inter callback
        /// </summary>
        private static void RegistIntersitialCallBack()
        {
            var handler1 = new ResultHandler(interFailLoad);
            var fp1 = Marshal.GetFunctionPointerForDelegate(handler1);

            var handler2 = new ResultHandler(interDidShow);
            var fp2 = Marshal.GetFunctionPointerForDelegate(handler2);

            var handler3 = new ResultHandler(interFailtoShow);
            var fp3 = Marshal.GetFunctionPointerForDelegate(handler3);

            var handler4 = new ResultHandler(interDidClose);
            var fp4 = Marshal.GetFunctionPointerForDelegate(handler4);

            var handler5 = new ResultHandler(interDidClick);
            var fp5 = Marshal.GetFunctionPointerForDelegate(handler5);

            var handler6 = new ResultHandler(interFailToPlayVideo);
            var fp6 = Marshal.GetFunctionPointerForDelegate(handler6);

            var handler7 = new ResultHandler(interStartPlayingVideo);
            var fp7 = Marshal.GetFunctionPointerForDelegate(handler7);

            var handler8 = new ResultHandler(interEndPlayingVideo);
            var fp8 = Marshal.GetFunctionPointerForDelegate(handler8);

            Intersitial_CallBack(fp1, fp2, fp3, fp4, fp5, fp6, fp7, fp8);
        }

        /// <summary>
        /// Register rewardVideo callback
        /// </summary>
        private static void RegistRewardVideoCallBack()
        {
            var handler1 = new ResultHandler(rewardVfailLoad);
            var fp1 = Marshal.GetFunctionPointerForDelegate(handler1);

            var handler2 = new ResultHandler(rewardVdidRewardSuccess);
            var fp2 = Marshal.GetFunctionPointerForDelegate(handler2);

            var handler3 = new ResultHandler(rewardVdidClose);
            var fp3 = Marshal.GetFunctionPointerForDelegate(handler3);

            var handler4 = new ResultHandler(rewardVdidClick);
            var fp4 = Marshal.GetFunctionPointerForDelegate(handler4);

            var handler5 = new ResultHandler(rewardVfailToPlayVideo);
            var fp5 = Marshal.GetFunctionPointerForDelegate(handler5);

            var handler6 = new ResultHandler(rewardVstartPlayingVideo);
            var fp6 = Marshal.GetFunctionPointerForDelegate(handler6);

            var handler7 = new ResultHandler(rewardVendPlayingVideo);
            var fp7 = Marshal.GetFunctionPointerForDelegate(handler7);

            rewardVideo_CallBack(fp1, fp2, fp3, fp4, fp5, fp6, fp7);
        }


        #region rewardVideo callback
        //Maintain the reward status locally
        private static bool isRewardSuccess;

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVfailLoad(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVfailLoad");
#endif

            if (OnRewardVedioLoadFail != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioLoadFail(); }, null);
            }

            //OnRewardVedioLoadFail?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVdidClick(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVdidClick");
#endif

            if (OnRewardVedioClick != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioClick(); }, null);
            }

            //OnRewardVedioClick?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVdidClose(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVdidClose");
#endif
            if (OnRewardVedioClose != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioClose(isRewardSuccess); }, null);
            }

            //OnRewardVedioClose?.Invoke(isRewardSuccess);
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVfailToPlayVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVfailToPlayVideo");
#endif

            if (OnRewardVedioPlayVideoFail != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioPlayVideoFail(); }, null);
            }

            //OnRewardVedioPlayVideoFail?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVstartPlayingVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVstartPlayingVideo");
#endif
            isRewardSuccess = false;

            if (OnRewardVedioPlayVideoStart != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioPlayVideoStart(); }, null);
            }

            //OnRewardVedioPlayVideoStart?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVendPlayingVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVendPlayingVideo");
#endif

            if (OnRewardVedioPlayVideoEnd != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnRewardVedioPlayVideoEnd(); }, null);
            }

            //OnRewardVedioPlayVideoEnd?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void rewardVdidRewardSuccess(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("rewardVideo callback----->rewardVdidRewardSuccess");
#endif
            isRewardSuccess = true;
            //OnRewardVedioSuccess?.Invoke();
        }
        #endregion

        #region interstitial callback
        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interFailLoad(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interFailLoad");
#endif

            if (OnIntersitialLoadFail != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialLoadFail(); }, null);
            }
            //OnIntersitialLoadFail?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interFailtoShow(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interFailtoShow");
#endif
            if (OnIntersitialShow != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialShow(false); }, null);
            }
            //OnIntersitialShow?.Invoke(false);
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interDidShow(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interDidShow");
#endif
            if (OnIntersitialShow != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialShow(true); }, null);
            }
            //OnIntersitialShow?.Invoke(true);
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interDidClick(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interDidClick");
#endif
            if (OnIntersitialClick != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialClick(); }, null);
            }
            //OnIntersitialClick?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interDidClose(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interDidClose");
#endif
            if (OnIntersitialClose != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialClose(); }, null);
            }
            //OnIntersitialClose?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interFailToPlayVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interFailToPlayVideo");
#endif
            if (OnIntersitialPlayVideoFail != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialPlayVideoFail(); }, null);
            }
            //OnIntersitialPlayVideoFail?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interStartPlayingVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interStartPlayingVideo");
#endif
            if (OnIntersitialPlayVideoStart != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialPlayVideoStart(); }, null);
            }
            //OnIntersitialPlayVideoStart?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void interEndPlayingVideo(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("interstitial callback----->interEndPlayingVideo");
#endif
            if (OnIntersitialPlayVideoEnd != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnIntersitialPlayVideoEnd(); }, null);
            }
            //OnIntersitialPlayVideoEnd?.Invoke();
        }
        #endregion

        #region Banner callback
        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannersucessLoad(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannersucessLoad");
#endif
            if (OnBannerLoaded != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerLoaded(true); }, null);
            }
            //OnBannerLoaded?.Invoke(true);            
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerFailLoad(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerFailLoad");
#endif
            if (OnBannerLoaded != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerLoaded(false); }, null);
            }
            //OnBannerLoaded?.Invoke(false);
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerDidShow(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerDidShow");
#endif
            if (OnBannerShow != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerShow(); }, null);
            }
            //OnBannerShow?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerDidClick(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerDidClick");
#endif
            if (OnBannerClick != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerClick(); }, null);
            }
            //OnBannerClick?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerTapCloseBtn(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerTapCloseBtn");
#endif
            if (OnBannerTapClose != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerTapClose(); }, null);
            }
            //OnBannerTapClose?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerFailToAutoRefresh(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerFailToAutoRefresh");
#endif
            if (OnBannerAutoRefresh != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerAutoRefresh(false); }, null);
            }
            //OnBannerAutoRefresh?.Invoke(false);
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void bannerDidAutoRefresh(string resultString)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("Banner callback----->bannerDidAutoRefresh");
#endif
            if (OnBannerAutoRefresh != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnBannerAutoRefresh(true); }, null);
            }
            //OnBannerAutoRefresh?.Invoke(true);
        }
        #endregion

        #region splash callback

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void splashFailLoad(string resultStr)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("----->splashFailLoad");
#endif
            if (OnSplashLoadFail != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnSplashLoadFail(); }, null);
            }
            //OnSplashLoadFail?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void splashDidShow(string resultStr)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("----->splashDidShow");
#endif
            if (OnSplashShow != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnSplashShow(); }, null);
            }
            //OnSplashShow?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void splashDidClick(string resultStr)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("----->splashDidClick");
#endif
            if (OnSplashClick != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnSplashClick(); }, null);
            }
            //OnSplashClick?.Invoke();
        }

        [MonoPInvokeCallback(typeof(ResultHandler))]
        static void splashDidClose(string resultStr)
        {
#if SHOW_IOS_LISTENER_LOG
            Debug.Log("----->splashDidClose");
#endif
            if (OnSplashClose != null)
            {
                OneThreadSynchronizationContext.Instance.Post(o => { OnSplashClose(); }, null);
            }
            //OnSplashClose?.Invoke();
        }
        #endregion

#endif
    }
}