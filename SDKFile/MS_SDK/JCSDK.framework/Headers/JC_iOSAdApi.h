//
//  JC_iOSAdApi.h
//  JCSDK
//
//  Created by wangyibo on 2020/8/11.
//  Copyright © 2020 wangyibo. All rights reserved.
//
#import "JCAdCallBackHeader.h"
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <AnyThinkNative/AnyThinkNative.h>
NS_ASSUME_NONNULL_BEGIN
@class JCNativeView;
@class JCNativeConfig;

@interface JC_iOSAdApi : NSObject

/// Globally unique instantiation object
+(instancetype)sharedManager;

#pragma mark - The log switch

/// The platform log switch is off by default.  release close
/// @param logLevel 1、 2 、3 、4 . check MSLogLevelStatus
+(void)setTheLogLevel:(MSLogLevelStatus)logLevel;

#pragma mark -  init sdk
/// Initialize the JCSDK API
/// @param appId appid （Provided by the platform）
/// @param channelId chanelId （Provided by the platform）
/// @param isOpenInBody Enable or disable Get Ads From Inside configuration : YES/NO
/// @param block Internal advertising logic request result block
+(void)jcSDKInitConfigWithAppId:(NSString*)appId channelId:(NSString*)channelId isOpenInBody:(BOOL)isOpenInBody block:(void(^)(BOOL isOk))block;


#pragma mark -  GDPR
/// Determine if it is EU territory API
/// @param block callback isEU? YES / NO
+(void)getLocationIsEU:(void(^)(BOOL isEU))block;

/// the GDPR interface API
/// @param dismissblock close Interface callback
/// @param failBlock show Fail callback
+(void)jcSDKShowGDPRWithDismissblock:(void(^)(void))dismissblock loadFailblock:(void(^)(NSError *error))failBlock;


#pragma mark - splash

/// load Splash Ads
+(BOOL)loadSplashView;

#pragma mark - banner

/// load  banner Ads
+(void)loadBannerConfig;

/// banner isReady ?
+(BOOL)bannerIsReady;

/// show banner
/// @param bannerCon Load the banner controller.
+(void)showBannerViewWithCon:(UIViewController*)bannerCon;


/// remove banner
+(void)removeBanner;
#pragma mark - rewardVideo

/// load RewaredVideo Ads

+(void)loadRewardConfig;

/// RewaredVideo Ads isReady?
/// return :YES/NO.
+(BOOL)rewardVIsReady;

/// show RewaredVideo Ads

+(void)showRewardView;

#pragma mark - intersitial

/// load Intersitial Ads
+(void)loadIntersitialConfig;

/// isReady Intersitial Ads?
/// return YES/NO
+(BOOL)intersitialIsReady;

/// show Intersitial Ads
+(void)showIntersitialView;

#pragma mark - native

/// load native Ads
/// @param size ads size （Please match the size of the ADFrame in the displayed ad space config, otherwise the display may be incomplete.）
+(void)loadNativeConfigWithSize:(CGSize)size;

/// isReady native Ads

+(BOOL)nativeIsReady;

/// show native Ads
/// @param config native Ads config
+(UIView*)showNativeConfigWithConfig:(JCNativeConfig*)config;


#pragma mark - UMeng And talkingData Send Event Api

/// If you are using UMeng and talkingdata in your app, use this reported data api
/// @param event event
/// @param jsonStr Please convert the key-value to json.
+(void)sendEvent:(NSString*)event detailedJsonString:(NSString*)jsonStr;
@end

NS_ASSUME_NONNULL_END
