//
//  ChartboostManager.m
//  CB
//
//  Created by Mike DeSaro on 12/20/11.
//

#import "ChartboostManager.h"



#if UNITY_VERSION < 500
void UnityPause( bool pause );
#else
void UnityPause( int pause );
#endif

void UnitySendMessage( const char * className, const char * methodName, const char * param );


@implementation ChartboostManager

///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark NSObject

+ (ChartboostManager*)sharedManager
{
	static ChartboostManager *sharedSingleton;
	
	if( !sharedSingleton )
		sharedSingleton = [[ChartboostManager alloc] init];
	
	return sharedSingleton;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark - Private

+ (id)objectFromJson:(NSString*)json
{
	NSError *error = nil;
	NSData *data = [NSData dataWithBytes:json.UTF8String length:json.length];
    NSObject *object = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingAllowFragments error:&error];
	
	if( error )
		NSLog( @"failed to deserialize JSON: %@ with error: %@", json, [error localizedDescription] );

    return object;
}


+ (NSString*)jsonFromObject:(id)object
{
	NSError *error = nil;
	NSData *jsonData = [NSJSONSerialization dataWithJSONObject:object options:0 error:&error];
	
	if( jsonData && !error )
		return [[[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding] autorelease];
	else
		NSLog( @"jsonData was null, error: %@", [error localizedDescription] );

    return @"{}";
}


+ (NSString*)logError:(CBLoadError)error
{
	switch( error )
	{
		case CBLoadErrorImpressionAlreadyVisible:
			NSLog( @"CBLoadErrorImpressionAlreadyVisible" );
			return @"CBLoadErrorImpressionAlreadyVisible";
			break;
		case CBLoadErrorPrefetchingIncomplete:
			NSLog( @"CBLoadErrorPrefetchingIncomplete" );
			return @"CBLoadErrorPrefetchingIncomplete";
			break;
		case CBLoadErrorInternal:
			NSLog( @"CBLoadErrorInternal" );
			return @"CBLoadErrorInternal";
			break;
		case CBLoadErrorInternetUnavailable:
			NSLog( @"CBLoadErrorInternetUnavailable" );
			return @"CBLoadErrorInternetUnavailable";
			break;
		case CBLoadErrorTooManyConnections:
			NSLog( @"CBLoadErrorTooManyConnections: Too many requests are pending for that location" );
			return @"CBLoadErrorTooManyConnections";
			break;
		case CBLoadErrorWrongOrientation:
			NSLog( @"CBLoadErrorWrongOrientation: Interstitial loaded with wrong orientation" );
			return @"CBLoadErrorWrongOrientation";
			break;
		case CBLoadErrorFirstSessionInterstitialsDisabled:
			NSLog( @"CBLoadErrorFirstSessionInterstitialsDisabled: Interstitial disabled, first session" );
			return @"CBLoadErrorFirstSessionInterstitialsDisabled";
			break;
		case CBLoadErrorNetworkFailure:
			NSLog( @"CBLoadErrorNetworkFailure: Network request failed" );
			return @"CBLoadErrorNetworkFailure";
			break;
		case CBLoadErrorNoAdFound:
			NSLog( @"CBLoadErrorNoAdFound: No ad received" );
			return @"CBLoadErrorNoAdFound";
			break;
		case CBLoadErrorSessionNotStarted:
			NSLog( @"CBLoadErrorSessionNotStarted: Session not started, use startSession method" );
			return @"CBLoadErrorSessionNotStarted";
			break;
		case CBLoadErrorUserCancellation:
			NSLog( @"CBLoadErrorUserCancellation" );
			return @"CBLoadErrorUserCancellation";
			break;
		case CBLoadErrorNoLocationFound:
			NSLog( @"CBLoadErrorNoLocationFound" );
			return @"CBLoadErrorNoLocationFound";
			break;
	}
	
	return @"Unknown Error";
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark ChartboostDelegate

// Interstitial
- (void)didFailToLoadInterstitial:(CBLocation)location withError:(CBLoadError)error
{
	UnityPause( false );

	NSLog( @"didFailToLoadInterstitial" );
	NSString *json = [ChartboostManager jsonFromObject:@{ @"location": location, @"error": [ChartboostManager logError:error] }];
    UnitySendMessage( "ChartboostManager", "didFailToLoadInterstitial", json.UTF8String );
}


- (void)didCacheInterstitial:(CBLocation)location
{
	UnitySendMessage( "ChartboostManager", "didCacheInterstitial", location.UTF8String );
}


- (void)didDismissInterstitial:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didDismissInterstitial", location.UTF8String );
}


- (void)didCloseInterstitial:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didCloseInterstitial", location.UTF8String );
}


- (void)didClickInterstitial:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didClickInterstitial", location.UTF8String );
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark - More Apps

- (void)didFailToLoadMoreApps:(CBLocation)location withError:(CBLoadError)error
{
	UnityPause( false );
	
	NSLog( @"didFailToLoadMoreApps" );
	NSString *json = [ChartboostManager jsonFromObject:@{ @"location": location, @"error": [ChartboostManager logError:error] }];
	UnitySendMessage( "ChartboostManager", "didFailToLoadMoreApps", json.UTF8String );
}


- (void)didCacheMoreApps:(CBLocation)location
{
	UnitySendMessage( "ChartboostManager", "didCacheMoreApps", location.UTF8String );
}


- (BOOL)shouldDisplayMoreApps:(CBLocation)location
{
    UnityPause( true );
    return YES;
}


- (void)didDismissMoreApps:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didDismissMoreApps", location.UTF8String );
}


- (void)didCloseMoreApps:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didCloseMoreApps", location.UTF8String );
}


- (void)didClickMoreApps:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didClickMoreApps", location.UTF8String );
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark - Rewarded Videos

- (void)didFailToLoadRewardedVideo:(CBLocation)location withError:(CBLoadError)error
{
	UnityPause( false );
	
	NSLog( @"didFailToLoadRewardedVideo" );
	NSString *json = [ChartboostManager jsonFromObject:@{ @"location": location, @"error": [ChartboostManager logError:error] }];
	UnitySendMessage( "ChartboostManager", "didFailToLoadRewardedVideo", json.UTF8String );
}


- (void)didCacheRewardedVideo:(CBLocation)location
{
	UnitySendMessage( "ChartboostManager", "didCacheRewardedVideo", location.UTF8String );
}


- (BOOL)shouldDisplayRewardedVideo:(CBLocation)location
{
	UnityPause( true );
	return YES;
}


- (void)didDismissRewardedVideo:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didDismissRewardedVideo", location.UTF8String );
}


- (void)didCloseRewardedVideo:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didCloseRewardedVideo", location.UTF8String );
}


- (void)didClickRewardedVideo:(CBLocation)location
{
    UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didClickRewardedVideo", location.UTF8String );
}


- (void)didCompleteRewardedVideo:(CBLocation)location withReward:(int)reward
{
	UnityPause( false );
    UnitySendMessage( "ChartboostManager", "didCompleteRewardedVideo", [NSString stringWithFormat:@"%i", reward].UTF8String );
}


@end
