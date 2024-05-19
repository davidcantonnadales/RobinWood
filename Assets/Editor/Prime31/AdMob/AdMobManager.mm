//
//  AdMobManager.mm
//  AdMobTest
//
//  Created by Mike on 1/27/11.
//  Copyright 2011 Prime31 Studios. All rights reserved.
//

#import "AdMobManager.h"
#import <CommonCrypto/CommonDigest.h>


#if UNITY_VERSION < 500
void UnityPause( bool pause );
#else
void UnityPause( int pause );
#endif


UIViewController *UnityGetGLViewController();


@implementation AdMobManager

@synthesize adView = _adView, interstitialAd = _interstitialAd, isShowingSmartBanner, bannerPosition, testDevices,
	tagForChildDirectedTreatment;

///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark NSObject

+ (AdMobManager*)sharedManager
{
	static AdMobManager *sharedSingleton;
	
	if( !sharedSingleton )
		sharedSingleton = [[AdMobManager alloc] init];
	
	return sharedSingleton;
}


- (id)init
{
	if( ( self = [super init] ) )
	{
		[GADRewardBasedVideoAd sharedInstance].delegate = self;
		self.testDevices = [NSMutableArray arrayWithCapacity:0];
		
		[[NSNotificationCenter defaultCenter] addObserver:self
												 selector:@selector(orientationChanged:)
													 name:UIApplicationWillChangeStatusBarOrientationNotification
												   object:nil];
		[[NSNotificationCenter defaultCenter] addObserver:self
												 selector:@selector(orientationChanged:)
													 name:UIApplicationDidChangeStatusBarOrientationNotification
												   object:nil];
	}
	return self;
}


- (GADRequest*)getRequest
{
	GADRequest* request = [GADRequest request];
	request.testDevices = self.testDevices;

	if( self.tagForChildDirectedTreatment )
		[request tagForChildDirectedTreatment:tagForChildDirectedTreatment];

	return request;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark - NSNotification

- (void)orientationChanged:(NSNotification*)note
{
	if( !self.adView || !self.isShowingSmartBanner )
		return;

	// we change orientation gracefully for smart banners
	UIDeviceOrientation deviceOrientation = [[UIDevice currentDevice] orientation];
	if( [note.name isEqualToString:UIApplicationWillChangeStatusBarOrientationNotification] )
	{
		self.adView.alpha = 0;
		[UIView animateWithDuration:0.1 delay:0.0 options:UIViewAnimationOptionAllowUserInteraction animations:^{ self.adView.alpha = 1; } completion:nil];
		self.adView.adSize = [self adSizeForOrientation:UIDeviceOrientationIsLandscape( deviceOrientation )];
	}
	else
	{
		self.adView.alpha = 0;
		[UIView animateWithDuration:1.0 delay:0.0 options:UIViewAnimationOptionAllowUserInteraction animations:^{ self.adView.alpha = 1; } completion:nil];
	}
}



///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark Private

- (void)adjustAdViewFrameToShowAdView
{
	// fetch screen dimensions and useful values
	CGRect origFrame = _adView.frame;

	CGFloat screenHeight = [UIScreen mainScreen].bounds.size.height;
	CGFloat screenWidth = [UIScreen mainScreen].bounds.size.width;
	
	if( UIInterfaceOrientationIsLandscape( UnityGetGLViewController().interfaceOrientation ) && screenWidth < screenHeight )
	{
		screenWidth = screenHeight;
		screenHeight = [UIScreen mainScreen].bounds.size.width;
	}
	
	
	switch( bannerPosition )
	{
		case AdMobAdPositionTopLeft:
			origFrame.origin.x = 0;
			origFrame.origin.y = 0;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleRightMargin | UIViewAutoresizingFlexibleBottomMargin );
			break;
		case AdMobAdPositionTopCenter:
			origFrame.origin.x = ( screenWidth / 2 ) - ( origFrame.size.width / 2 );
			origFrame.origin.y = 0;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleRightMargin | UIViewAutoresizingFlexibleBottomMargin );
			break;
		case AdMobAdPositionTopRight:
			origFrame.origin.x = screenWidth - origFrame.size.width;
			origFrame.origin.y = 0;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleBottomMargin );
			break;
		case AdMobAdPositionCentered:
			origFrame.origin.x = ( screenWidth / 2 ) - ( origFrame.size.width / 2 );
			origFrame.origin.y = ( screenHeight / 2 ) - ( origFrame.size.height / 2 );
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleRightMargin | UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleTopMargin | UIViewAutoresizingFlexibleBottomMargin );
			break;
		case AdMobAdPositionBottomLeft:
			origFrame.origin.x = 0;
			origFrame.origin.y = screenHeight - origFrame.size.height;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleRightMargin | UIViewAutoresizingFlexibleTopMargin );
			break;
		case AdMobAdPositionBottomCenter:
			origFrame.origin.x = ( screenWidth / 2 ) - ( origFrame.size.width / 2 );
			origFrame.origin.y = screenHeight - origFrame.size.height;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleRightMargin | UIViewAutoresizingFlexibleTopMargin );
			break;
		case AdMobAdPositionBottomRight:
			origFrame.origin.x = screenWidth - _adView.frame.size.width;
			origFrame.origin.y = screenHeight - origFrame.size.height;
			self.adView.autoresizingMask = ( UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleTopMargin );
			break;
	}
	
	self.adView.frame = origFrame;
}


- (void)finishBannerSetupWithAdUnitId:(NSString*)adUnitId
{
	// finish setting up the banner
	_adView.adUnitID = adUnitId;

	_adView.delegate = self;
	_adView.rootViewController = UnityGetGLViewController();

	// setup the request
	GADRequest *request = [GADRequest request];
	request.testDevices = self.testDevices;

	if( self.tagForChildDirectedTreatment )
		[request tagForChildDirectedTreatment:tagForChildDirectedTreatment];

	[_adView loadRequest:request];


	[self adjustAdViewFrameToShowAdView];

	[UnityGetGLViewController().view addSubview:_adView];
}


- (GADAdSize)adSizeForOrientation:(BOOL)isLandscape
{
	// Landscape
	if( isLandscape )
		return kGADAdSizeSmartBannerLandscape;
	else
		return kGADAdSizeSmartBannerPortrait;
}



///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark Public

- (void)createBanner:(AdMobBannerType)bannerType withPosition:(AdMobAdPosition)position andAdUnitId:(NSString*)adUnitId
{
	// kill the current adView if we have one
	if( _adView )
		[self destroyBanner];
	
	bannerPosition = position;
	self.isShowingSmartBanner = NO;

	switch( bannerType )
	{
		case AdMobBannerTypeiPhone_320x50:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeBanner];
			break;
		}
		case AdMobBannerTypeiPad_320x250:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeMediumRectangle];
			break;
		}
		case AdMobBannerTypeiPad_468x60:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeFullBanner];
			break;
		}
		case AdMobBannerTypeiPad_728x90:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeLeaderboard];
			break;
		}
		case AdMobBannerTypeSmartPortrait:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeSmartBannerPortrait];
			self.isShowingSmartBanner = YES;
			break;
		}
		case AdMobBannerTypeSmartLandscape:
		{
			_adView = [[GADBannerView alloc] initWithAdSize:kGADAdSizeSmartBannerLandscape];
			self.isShowingSmartBanner = YES;
			break;
		}
	}
	
	// finish setting up the banner
	[self finishBannerSetupWithAdUnitId:adUnitId];
}


- (void)createCustomSizedBannerWithWidth:(int)width height:(int)height position:(AdMobAdPosition)position andAdUnitId:(NSString*)adUnitId
{
	// kill the current adView if we have one
	if( _adView )
		[self destroyBanner];

	bannerPosition = position;
	self.isShowingSmartBanner = NO;

	GADAdSize adSize;
	adSize.flags = 1;
	adSize.size = CGSizeMake( width, height );

	_adView = [[GADBannerView alloc] initWithAdSize:adSize];
	[self finishBannerSetupWithAdUnitId:adUnitId];
}


- (void)destroyBanner
{
	_adView.hidden = YES;
	
	[_adView removeFromSuperview];
	_adView.delegate = nil;
	self.adView = nil;
}


- (void)requestInterstitalAd:(NSString*)interstitialUnitId
{
	// only kill the ad if it is already loaded
	if( _interstitialAd && _interstitialAd.isReady )
	{
		_interstitialAd.delegate = nil;
		self.interstitialAd = nil;
	}
	
	// this will return nil if there is already a load in progress
	_interstitialAd = [[GADInterstitial alloc] initWithAdUnitID:interstitialUnitId];
	_interstitialAd.delegate = self;

	[_interstitialAd loadRequest:[self getRequest]];
}


- (void)showInterstitialAd
{
	if( !_interstitialAd.isReady )
	{
		NSLog( @"interstitial ad is not yet loaded" );
		return;
	}

	[_interstitialAd presentFromRootViewController:UnityGetGLViewController()];
}





///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark GADBannerViewDelegate

- (void)adViewDidReceiveAd:(GADBannerView*)bannerView
{
	[self adjustAdViewFrameToShowAdView];
	_adView.hidden = NO;

	UnitySendMessage( "AdMobManager", "adViewDidReceiveAd", "" );
}


- (void)adView:(GADBannerView*)bannerView didFailToReceiveAdWithError:(GADRequestError*)error
{
	_adView.hidden = YES;

	UnitySendMessage( "AdMobManager", "adViewFailedToReceiveAd", [error localizedDescription].UTF8String );
}


- (void)adViewWillPresentScreen:(GADBannerView*)bannerView
{
	_adView.hidden = YES;
	UnityPause( true );
}


- (void)adViewDidDismissScreen:(GADBannerView*)bannerView
{
	UnityPause( false );
}


- (void)adViewWillLeaveApplication:(GADBannerView*)bannerView
{
	NSLog( @"adViewWillLeaveApplication" );
}




///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark GADInterstitialDelegate

- (void)interstitialDidReceiveAd:(GADInterstitial*)interstitial
{
	UnitySendMessage( "AdMobManager", "interstitialDidReceiveAd", "" );
}


// Sent when an interstitial ad request completed without an interstitial to show.  This is
// common since interstitials are shown sparingly to users.
- (void)interstitial:(GADInterstitial*)interstitial didFailToReceiveAdWithError:(GADRequestError*)error
{
	UnitySendMessage( "AdMobManager", "interstitialFailedToReceiveAd", [error localizedDescription].UTF8String );
	
	if( _interstitialAd )
	{
		_interstitialAd.delegate = nil;
		self.interstitialAd = nil;
	}
	
	UnityPause( false );
}


- (void)interstitialWillPresentScreen:(GADInterstitial*)interstitial
{
	UnitySendMessage( "AdMobManager", "interstitialWillPresentScreen", "" );
	UnityPause( true );
}


- (void)interstitialWillDismissScreen:(GADInterstitial*)interstitial
{
	UnityPause( false );
}


- (void)interstitialDidDismissScreen:(GADInterstitial*)interstitial
{
	// clean up the interstitial.  It can only be used once.
	self.interstitialAd.delegate = nil;
	self.interstitialAd = nil;
	UnityPause( false );
	UnitySendMessage( "AdMobManager", "interstitialDidDismissScreen", "" );
}


- (void)interstitialWillLeaveApplication:(GADInterstitial*)interstitial
{
	UnitySendMessage( "AdMobManager", "interstitialWillLeaveApplication", "" );
}



///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark GADRewardBasedDelegate

/// Tells the delegate that the reward based video ad has been received.
- (void)rewardBasedVideoAdDidReceiveAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd
{
	UnitySendMessage( "AdMobManager", "rewardBasedAdDidReceiveAd", "" );
}


/// Tells the delegate that the reward based video ad has failed to load.
- (void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didFailToLoadWithError:(NSError *)error
{
	UnitySendMessage( "AdMobManager", "rewardBasedAdFailedToReceiveAd", [error localizedDescription].UTF8String );
}


/// Tells the delegate that the reward based video ad is opened.
- (void)rewardBasedVideoAdDidOpen:(GADRewardBasedVideoAd *)rewardBasedVideoAd
{
	UnityPause( true );
}


/// Tells the delegate that the reward based video ad has started playing.
- (void)rewardBasedVideoAdDidStartPlaying:(GADRewardBasedVideoAd *)rewardBasedVideoAd
{
	
}


/// Tells the delegate that the reward based video ad is closed.
- (void)rewardBasedVideoAdDidClose:(GADRewardBasedVideoAd *)rewardBasedVideoAd
{
	UnityPause( false );
}


/// Tells the delegate that the reward based video ad will leave the application.
- (void)rewardBasedVideoAdWillLeaveApplication:(GADRewardBasedVideoAd *)rewardBasedVideoAd
{
	
}


/// Tells the delegate that the reward based video ad has rewarded the user.
- (void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didRewardUserWithReward:(GADAdReward*)reward
{
	NSString* result = [NSString stringWithFormat:@"%@|%f", reward.type, reward.amount.doubleValue];
	UnitySendMessage( "AdMobManager", "rewardBasedAdRewardedUser", result.UTF8String );
}

@end
