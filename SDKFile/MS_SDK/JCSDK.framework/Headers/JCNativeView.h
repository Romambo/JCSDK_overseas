//
//  JCNativeView.h
//  JCSDK
//
//  Created by MS on 2020/8/21.
//  Copyright © 2020 wangyibo. All rights reserved.
//

#import <AnyThinkNative/AnyThinkNative.h>

NS_ASSUME_NONNULL_BEGIN


@interface JCNativeView : ATNativeADView

/// All child views are initialized here. Subclass implementation has to call [super initSubviews] for the ad view to work properly. By the time this method's called, the ad view is not yet full fledged.
-(void) initSubviews;

/**
* Create constraints for subviews in this method if you are using autolayout.
*/
-(void) makeConstraintsForSubviews;

/**
 * Set the frame of the mediaview
 */
-(void) layoutMediaView;

/**
 * Whether the ad being shown is a video ad.
 */
-(BOOL) isVideoContents;

/*
 * ALWAYS call this method to retrieve the REAL rendered adview.
 */
-(ATNativeADView*)embededAdView;

/**
 * Return all clickable views
 */
-(NSArray<UIView*>*)clickableViews;


@property(nonatomic, strong) UILabel *advertiserLabel;
@property(nonatomic, strong) UILabel *textLabel;
@property(nonatomic, strong) UILabel *titleLabel;
@property(nonatomic, strong) UILabel *ctaLabel;
@property(nonatomic, strong) UILabel *ratingLabel;
@property(nonatomic, strong) UIImageView *iconImageView;
@property(nonatomic, strong) UIImageView *mainImageView;
@property(nonatomic, strong) UIImageView *sponsorImageView;
@end

NS_ASSUME_NONNULL_END
