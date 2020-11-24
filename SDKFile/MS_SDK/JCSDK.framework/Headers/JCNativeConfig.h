//
//  JCNativeConfig.h
//  JCSDK
//
//  Created by MS on 2020/8/24.
//  Copyright © 2020 wangyibo. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
NS_ASSUME_NONNULL_BEGIN

@interface JCNativeConfig : NSObject
//@property(nonatomic) NSDictionary *context;
@property(nonatomic) Class renderingViewClass; //Custom ad classes
@property(nonatomic) CGRect ADFrame; //ads frame
@property(nonatomic) CGRect mediaViewFrame; //
@property(nonatomic, weak) UIViewController *rootViewController; //
@end

NS_ASSUME_NONNULL_END
