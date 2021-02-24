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

/*
 version:2.1.0 - 2020-12-01
 banner平台刷新优化
 更新topon和所有广告源sdk
 新增go接口上报数据
 新增修改plan_id为空时上传normal
 新增用户留存天数统计
 优化测试和正式接口自动转换条件，debug和宏联合判断开启测试接口
 
 新增try-crash 修复关于banner计时器开关可能造成的崩溃
 开启后台控制强弹广告功能
 
 系统优化上报公共参数判空处理，crash逻辑进行主线程包裹
 
 新增开屏请求、load结果的埋点上报
 */
/*
 2020-12-7
 新增埋点上报
 优化相关bug
 优化开启应用时因网络缓慢导致的开屏无展示和banner无展示的情况（双接口无返回时，优化后无法避免网络慢导致先进入游戏，再展示开屏（为了确保开屏展示率））
 banner新增二次请求
 修复banner重置展示控制器
 新增ry_deviceid - 热云
 新增后台主控制log 优化开启应用就上报用户时长导致的bug
 修改不能保存代码的问题
 2020-12-09
 优化了插屏和激励视频展示完成再次load兜底bug
 新增IDFA获取为空使用UUID替代
 
 2020-12-10
 version2.1.5 稳定出包记录
 
 优化umeng-key默认为本地配置
 新增用户留存天数上报
 新增数数游戏上报功能
 */
/*
 2020-12-17
 version2.1.6 稳定出包记录
 新增热云上报广告展示和点击事件
 修复部分bug
 scheme/attribution 新增ry 和 userid上报
 2020-12-28
 新增数数自动事件上报
 新增应用内评、价、弹框和埋点上报
 2021-1-13
 提供对外评、价弹框API、广告点位预留接口
 */
/*
 2021-1-18
 version2.2.6
 新增fb数据统计
 移除评、论功能
 2021-1-20
 优化一下load成功广告，判断isReady失败导致重复load循环的问题
 
 2021-2-1
 移除location收集，用于粘液定制
 */
/*
2021-2-19
 更新版本3.0.0，支持topon5.7.13 以及对应的第三方广告库
 //2021-2-19新增
 // 请求开屏
 static NSString *REQUEST_SPLASH = @"request_splash_ios";
 // 开屏load成功
 static NSString *LOAD_SPLASH_SUCCESS = @"loadsplash_success_ios";
 // 开屏load失败
 static NSString *LOAD_SPLASH_FAILURE = @"loadsplash_failure_ios";
 // 展示开屏成功
 static NSString *SHOW_SPLASH_SUCCESS = @"showsplash_success_ios";
 // 展示开屏失败
 static NSString *SHOW_SPLASH_FAILURE = @"showsplash_failure_ios";
 //开屏isready失败
 static NSString *ISREADY_SPLASH_FAILURE = @"isReadysplash_failure_ios";
*/
/*
 体内接口超时时间由2s增加到3s
 启动时开屏请求延迟0.5s,激励、插屏请求延迟1s改为2s
 开屏新增预加载，开屏关闭后缓存一个供下次使用
 
 开屏增加部分第三方广告渠道直连参数 ，sigmob、MTG等没有appkey ，google默认竖屏
 
 修改iOS上报_splash_ios
 修复fb上报数据头文件重复导致的bug1
 */

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


