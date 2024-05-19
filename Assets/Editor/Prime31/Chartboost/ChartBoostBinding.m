//
//  ChartBoostBinding.m
//  CB
//
//  Created by Mike DeSaro on 12/20/11.
//

#import "ChartboostManager.h"
#import <CommonCrypto/CommonDigest.h>
#import <AdSupport/AdSupport.h>


// to print out the IFA (which can be used to add your device as a test device in the Chartboost web portal) uncomment the following line
// then run the app on your device and when you call init the IFA will be printed to the console. Note: this only works for iOS 6+ devices!
//#define PRINT_ISA 1



// Converts C style string to NSString
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

// Converts C style string to NSString as long as it isnt empty
#define GetStringParamOrNil( _x_ ) ( _x_ != NULL && strlen( _x_ ) ) ? [NSString stringWithUTF8String:_x_] : nil



void _chartboostInit( const char * appId, const char * appSignature, BOOL shouldRequestInterstitialsInFirstSession )
{
	[Chartboost startWithAppId:GetStringParam( appId ) appSignature:GetStringParam( appSignature ) delegate:[ChartboostManager sharedManager]];
	[Chartboost setShouldRequestInterstitialsInFirstSession:shouldRequestInterstitialsInFirstSession];
	[Chartboost setFramework:CBFrameworkPrime31Unreal];

#if PRINT_ISA
	// iOS 6+
	NSString* ifa = [[[NSClassFromString( @"ASIdentifierManager" ) sharedManager] advertisingIdentifier] UUIDString];
	ifa = [[ifa stringByReplacingOccurrencesOfString:@"-" withString:@""] lowercaseString];
	NSLog( @"IFA: %@", ifa );
#endif
}


// interstitial
void _chartboostCacheInterstitial( const char * location )
{
	[Chartboost cacheInterstitial:GetStringParam( location )];
}


BOOL _chartboostHasCachedInterstitial( const char * location )
{
	return [Chartboost hasInterstitial:GetStringParam( location )];
}


void _chartboostShowInterstitial( const char * location )
{
	[Chartboost showInterstitial:GetStringParam( location )];
}


// more apps
void _chartboostCacheMoreApps( const char * location )
{
	[Chartboost cacheMoreApps:GetStringParam( location )];
}


BOOL _chartboostHasCachedMoreApps( const char * location )
{
	return [Chartboost hasMoreApps:GetStringParam( location )];
}


void _chartboostShowMoreApps( const char * location )
{
	[Chartboost showMoreApps:GetStringParam( location )];
}


// rewarded videoes
void _chartboostCacheRewardedVideo( const char * location )
{
	[Chartboost cacheRewardedVideo:GetStringParam( location )];
}


BOOL _chartboostHasCachedRewardedVideo( const char * location )
{
	return [Chartboost hasRewardedVideo:GetStringParam( location )];
}


void _chartboostShowRewardedVideo( const char * location )
{
	[Chartboost showRewardedVideo:GetStringParam( location )];
}

