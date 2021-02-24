//
//  JCAdCallBackHeader.h
//  JCSDK
//
//  Created by MS on 2020/8/19.
//  Copyright © 2020 wangyibo. All rights reserved.
//

#ifndef JCAdCallBackHeader_h
#define JCAdCallBackHeader_h


#pragma mark - Please register to listen for notifications about the following keys to get callbacks for ad space

#define MSSplashADKey @"MSSplashADNotificationKey"

#define MSBannerADKey @"MSBannerADNotificationKey"

#define MSRewardVideoADKey @"MSRewardVideoADNotificationKey"

#define MSIntersitialADKey @"MSIntersitialADNotificationKey"

#define MSNativeADKey @"MSNativeADNotificationKey"

#define MSEvaViewShowKey @"ShowEvaViewKEY"//评、价、弹框没弹，或者点击了差评提交、关闭等为字符串1，点击好评0
#pragma mark - Callback data description

/*
  
  status        :   Please refer to the following enumeration for the types of ad position callbacks.
  channelConfig :   Channel-related parameters （The following is a collection of all ad position keys-value）
                    adId        :  Ad position id
                    ad_channel  :  ad channel
                    areaId      :  MS areaId of ad
                    area_ad_type:  Original ad type
                    priority    :  Advertising Priorities
                    adView      :  Native ad view info
 */

typedef enum : NSUInteger {
    
    #pragma mark - splash status
    
    MSAd_splashFailLoad =1,
    MSAd_splashDidShow,
    MSAd_splashDidClick,
    MSAd_splashDidClose,

    #pragma mark - banner status
    
    MSAd_BannerLoadSucess = 10,
    MSAd_BannerFailLoad,
    MSAd_bannerDidShow,
    MSAd_bannerDidClick,
    MSAd_bannerDidAutoRefreshAd,
    MSAd_bannerDidTapAdCloseButton,
    MSAd_bannerFailedToAutoRefresh,

    #pragma mark - rewardVideo status
    
    MSAd_rewardedVideoFailLoad=20,
    MSAd_rewardedVideoDidRewardSuccess,
    MSAd_rewardedVideoDidStartPlaying,
    MSAd_rewardedVideoDidEndPlaying,
    MSAd_rewardedVideoDidFailToPlay,
    MSAd_rewardedVideoDidClose,
    MSAd_rewardedVideoDidClick,

    #pragma mark - intersitial status
    
    MSAd_interstitialFailLoad=30,
    MSAd_interstitialDidShow,
    MSAd_interstitialFailedToShow,
    MSAd_interstitialDidClose,
    MSAd_interstitialDidClick,
    MSAd_interstitialDidFailToPlayVideo,
    MSAd_interstitialDidStartPlayingVideo,
    MSAd_interstitialDidEndPlayingVideo,

    #pragma mark - native status
    
    MSAd_nativeLoadSucess=40,
    MSAd_nativeFailLoad,
    MSAd_nativeDidShow,
    MSAd_nativeDidClick,
    MSAd_nativeDidStartPlayingVideo,
    MSAd_nativeDidEndPlayingVideo,
    MSAd_nativeDidEnterFullScreenVideo,
    MSAd_nativeDidExitFullScreenVideo,
    MSAd_nativeDidTapAdCloseButton,
    MSAd_nativeDidLoadSuccessDraw, // This feature is not enabled yet.
    
} MSAdCallBcakStatus;

#pragma mark - LogLevel

typedef enum : NSInteger {
    MSLogLevel_Close = 1,   //close log ,nomal state
    MSLogLevel_MSLog,       //open MS log
    MSLogLevel_ThreeAdLog,  //open MS log + Third party advertising logs
    MSLogLevel_DataSendLog  //open MS log + Third party advertising logs + Logs of third-party statistical platforms
    
} MSLogLevelStatus;

#endif /* JCAdCallBackHeader_h */

