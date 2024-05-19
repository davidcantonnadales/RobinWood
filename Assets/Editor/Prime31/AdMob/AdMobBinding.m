//
//  AdMobBinding.m
//  AdMobTest
//
//  Created by Mike on 1/27/11.
//  Copyright 2011 Prime31 Studios. All rights reserved.
//

#import "AdMobManager.h"


// Converts C style string to NSString
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

// Converts C style string to NSString as long as it isnt empty
#define GetStringParamOrNil( _x_ ) ( _x_ != NULL && strlen( _x_ ) ) ? [NSString stringWithUTF8String:_x_] : nil



void _adMobTagForChildDirectedTreatment( BOOL tagForChildDirectedTreatment )
{
	[AdMobManager sharedManager].tagForChildDirectedTreatment = tagForChildDirectedTreatment;
}


void _adMobSetTestDevice( const char * deviceId )
{
	[[AdMobManager sharedManager].testDevices addObject:GetStringParam( deviceId )];
}


void _adMobCreateBanner( const char * adUnitId, int bannerType, int bannerPosition )
{
	AdMobBannerType type = (AdMobBannerType)bannerType;
	AdMobAdPosition position = (AdMobAdPosition)bannerPosition;

	[[AdMobManager sharedManager] createBanner:type withPosition:position andAdUnitId:GetStringParamOrNil( adUnitId )];
}


void _adMobCreateCustomSizedBanner( const char * adUnitId, int width, int height, int bannerPosition )
{
	AdMobAdPosition position = (AdMobAdPosition)bannerPosition;

	[[AdMobManager sharedManager] createCustomSizedBannerWithWidth:width height:height position:position andAdUnitId:GetStringParamOrNil( adUnitId )];
}


void _adMobHideBanner( bool shouldHide )
{
	if( [AdMobManager sharedManager].adView )
		[AdMobManager sharedManager].adView.hidden = shouldHide;
}


void _adMobDestroyBanner()
{
	[[AdMobManager sharedManager] destroyBanner];
}


// interstitials
void _adMobRequestInterstitialAd( const char * interstitialUnitId )
{
	[[AdMobManager sharedManager] requestInterstitalAd:GetStringParam( interstitialUnitId )];
}


bool _adMobIsInterstitialAdReady()
{
	return [AdMobManager sharedManager].interstitialAd.isReady;
}


void _adMobShowInterstitialAd()
{
	[[AdMobManager sharedManager] showInterstitialAd];
}


// rewarded ads
void _adMobRequestRewardBasedAd( const char * adUnit )
{
	[AdMobManager sharedManager];
	[[GADRewardBasedVideoAd sharedInstance] loadRequest:[[AdMobManager sharedManager] getRequest] withAdUnitID:GetStringParam( adUnit )];
}


void _adMobShowRewardBasedAd()
{
	if( [[GADRewardBasedVideoAd sharedInstance] isReady] )
		[[GADRewardBasedVideoAd sharedInstance] presentFromRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController];
	else
		NSLog( @"no reward based ads are loaded" );
}


