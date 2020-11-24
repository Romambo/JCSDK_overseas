//
//  JCSDK.h
//  JCSDK
//
//  Created by MS on 2020/8/11.
//  Copyright © 2020 wangyibo. All rights reserved.
//
// version:2.0.1 - 2020-11-10
// 优化了kochava归因逻辑
// 优化了unity初始化超时回调时间2s
// 优化了rv和inter混合使用时加载错误的bug
// 优化了rv和inter相关数据缓存、连续展示功能
//2020-11-17新增
// 回传指标接口返回count等于2的优化处理
//2020-11-18新增
//注释掉所有的GDPR相关内容
#import <Foundation/Foundation.h>
#import "JC_iOSAdApi.h"
#import "JCAdCallBackHeader.h"
#import "JCNativeView.h"
#import "JCNativeConfig.h"
#import "JC_unityAdApi.h"
#import "JC_unityCallBackApi.h"
//! Project version number for JCSDK.
FOUNDATION_EXPORT double JCSDKVersionNumber;

//! Project version string for JCSDK.
FOUNDATION_EXPORT const unsigned char JCSDKVersionString[];

// In this header, you should import all the public headers of your framework using statements like #import <JCSDK/PublicHeader.h>


