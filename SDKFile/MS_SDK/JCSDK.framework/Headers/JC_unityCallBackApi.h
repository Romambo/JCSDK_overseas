//
//  JC_unityCallBackApi.h
//  Unity-iPhone
//
//  Created by MS on 2020/9/2.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef void (*ResultHandler) (const char *object);


@interface JC_unityCallBackApi : NSObject

@end
#if defined (__cplusplus)


extern "C"
{


/// Sign up for callback listening
void RegistCallBacknotifition();


/// splash callbacks
/// @param failLoad
/// @param didShow
/// @param didClick
/// @param didClose
void splash_CallBack(ResultHandler failLoad,ResultHandler didShow, ResultHandler didClick, ResultHandler didClose);

/// intersitial callbacks
/// @param failLoad
/// @param didShow
/// @param failToShow
/// @param didClose
/// @param didClick
/// @param failToPlayVideo
/// @param startPlayingVideo
/// @param endPlayingVideo
void Intersitial_CallBack(ResultHandler failLoad,ResultHandler didShow, ResultHandler failToShow, ResultHandler didClose,ResultHandler didClick,ResultHandler failToPlayVideo, ResultHandler startPlayingVideo, ResultHandler endPlayingVideo);

/// banner callbacks
/// @param sucessLoad
/// @param failLoad
/// @param didShow
/// @param didClick
/// @param didAutoRefresh
/// @param tapCloseBtn
/// @param failToAutoRefresh
void banner_CallBack(ResultHandler sucessLoad,ResultHandler failLoad,ResultHandler didShow,ResultHandler didClick,ResultHandler didAutoRefresh, ResultHandler tapCloseBtn, ResultHandler failToAutoRefresh);

/// rewardVideo  callbacks
/// @param failLoad
/// @param didRewardSuccess
/// @param didClose
/// @param didClick
/// @param failToPlayVideo
/// @param startPlayingVideo
/// @param endPlayingVideo
void rewardVideo_CallBack(ResultHandler failLoad,ResultHandler didRewardSuccess, ResultHandler didClose,ResultHandler didClick,ResultHandler failToPlayVideo, ResultHandler startPlayingVideo, ResultHandler endPlayingVideo);

/// native callbacks
/// @param sucessLoad
/// @param failLoad
/// @param didShow
/// @param didClick
/// @param startPlayingVideo
/// @param endPlayingVideo
/// @param tapCloseBtn
/// @param enterFullScreenV
/// @param exitFullScreenV 
void native_CallBack(ResultHandler sucessLoad,ResultHandler failLoad,ResultHandler didShow, ResultHandler didClick, ResultHandler startPlayingVideo, ResultHandler endPlayingVideo,ResultHandler tapCloseBtn,ResultHandler enterFullScreenV,ResultHandler exitFullScreenV);

}

#endif

#if defined (__cplusplus)

#endif
NS_ASSUME_NONNULL_END
