//
//  AdMobManager.h
//  AdMobTest
//
//  Created by Mike on 1/27/11.
//  Copyright 2011 Prime31 Studios. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GoogleMobileAds/GoogleMobileAds.h>


typedef enum
{
	AdMobBannerTypeiPhone_320x50,
	AdMobBannerTypeiPad_728x90,
	AdMobBannerTypeiPad_468x60,
	AdMobBannerTypeiPad_320x250,
	AdMobBannerTypeSmartPortrait,
	AdMobBannerTypeSmartLandscape
} AdMobBannerType;

typedef enum
{
	AdMobAdPositionTopLeft,
	AdMobAdPositionTopCenter,
	AdMobAdPositionTopRight,
	AdMobAdPositionCentered,
	AdMobAdPositionBottomLeft,
	AdMobAdPositionBottomCenter,
	AdMobAdPositionBottomRight
} AdMobAdPosition;


@interface AdMobManager : NSObject <GADBannerViewDelegate, GADInterstitialDelegate, GADRewardBasedVideoAdDelegate>
@property (nonatomic, retain) GADBannerView *adView;
@property (nonatomic, retain) GADInterstitial *interstitialAd;
@property (nonatomic) BOOL isShowingSmartBanner;
@property (nonatomic) AdMobAdPosition bannerPosition;
@property (nonatomic, retain) NSMutableArray *testDevices;
@property (nonatomic) BOOL tagForChildDirectedTreatment;


+ (AdMobManager*)sharedManager;


- (GADRequest*)getRequest;

- (void)createBanner:(AdMobBannerType)bannerType withPosition:(AdMobAdPosition)position andAdUnitId:(NSString*)adUnitId;

- (void)createCustomSizedBannerWithWidth:(int)width height:(int)height position:(AdMobAdPosition)position andAdUnitId:(NSString*)adUnitId;

- (void)destroyBanner;

- (void)requestInterstitalAd:(NSString*)interstitialUnitId;

- (void)showInterstitialAd;

@end
