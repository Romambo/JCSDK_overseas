//
//  JC_unityAdApi.h
//  Unity-iPhone
//
//  Created by MS on 2020/9/2.
//

#import <Foundation/Foundation.h>

typedef void (^unityBlock)(BOOL showUnityTime);
NS_ASSUME_NONNULL_BEGIN

#if defined (__cplusplus)


extern "C"
{

/// Intersitial Ads isReady
bool isReadyIntersitial();

/// show Intersitial Ads
void showIntersitial();

/// rewardVideo Ads isReady
bool isReadyRewardVideo();

/// show rewardVideo Ads
void showRewardVideo();

/// isReady - banner
bool isReadyBanner();

/// show banner Ads
void showBannerView();

/// remove banner Ads
void removeBannerView();

/// Send Event UMeng、talkingData
/// @param event event
/// @param jsonEventInfo key-value converted json string, if there is no content to pass, you can set a null value
void sendEvent(char *event,char *jsonEventInfo);

/// Interstitial ad display time interval
int Inter_showpacingCallBack();
}

#endif

#if defined (__cplusplus)

#endif



@interface JC_unityAdApi : NSObject
+(instancetype)getInstance;

/// init sdk with oc .
-(void)initJCSDKWithUnityShow:(unityBlock)block;

/// Interstitial ad display time interval
-(int)getInterSpacing;
@end

NS_ASSUME_NONNULL_END
