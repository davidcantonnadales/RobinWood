using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;


#if UNITY_IOS || UNITY_ANDROID

#if UNITY_ANDROID
using Manager = Prime31.ChartboostAndroidManager;
#elif UNITY_IOS
using Manager = Prime31.ChartboostManager;
#endif


namespace Prime31
{
	public class Chartboost
	{
		// Fired when an interstitial is cached. Includes the location.
		public static event Action<string> didCacheInterstitialEvent;

		// Fired when an interstitial fails to load. Includes the location.
		public static event Action<string,string> didFailToCacheInterstitialEvent;

		// Fired when an interstitial is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishInterstitialEvent;


		// Fired when the more apps screen is cached. Includes the location.
		public static event Action<string> didCacheMoreAppsEvent;

		// Fired when the more apps screen fails to load. Includes the location.
		public static event Action<string,string> didFailToCacheMoreAppsEvent;

		// Fired when the more apps screen is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishMoreAppsEvent;


		// Fired when a rewarded video is cached. Includes the location.
		public static event Action<string> didCacheRewardedVideoEvent;

		// Fired when a rewarded video fails to load. Includes the location.
		public static event Action<string,string> didFailToLoadRewardedVideoEvent;

		// Fired when a rewarded video is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishRewardedVideoEvent;

		// Fired when a rewarded video is completed. Includes the reward amount.
		public static event Action<int> didCompleteRewardedVideoEvent;



		static Chartboost()
		{
			Manager.didCacheInterstitialEvent += ( location ) => { didCacheInterstitialEvent.fire( location ); };
			Manager.didFailToCacheInterstitialEvent += ( location, error ) => { didFailToCacheInterstitialEvent.fire( location, error ); };
			Manager.didFinishInterstitialEvent += ( location, reason ) => { didFinishInterstitialEvent.fire( location, reason ); };

			Manager.didCacheMoreAppsEvent += ( location ) => { didCacheMoreAppsEvent.fire( location ); };
			Manager.didFailToCacheMoreAppsEvent += ( location, error ) => { didFailToCacheMoreAppsEvent.fire( location, error ); };
			Manager.didFinishMoreAppsEvent += ( location, reason ) => { didFinishMoreAppsEvent.fire( location, reason ); };

			Manager.didCacheRewardedVideoEvent += ( location ) => { didCacheRewardedVideoEvent.fire( location ); };
			Manager.didFailToLoadRewardedVideoEvent += ( location, error ) => { didFailToLoadRewardedVideoEvent.fire( location, error ); };
			Manager.didFinishRewardedVideoEvent += ( location, reason ) => { didFinishRewardedVideoEvent.fire( location, reason ); };
			Manager.didCompleteRewardedVideoEvent += ( reward ) => { didCompleteRewardedVideoEvent.fire( reward ); };
		}


		// Starts up Chartboost and records an app install
		public static void init( string androidAppId, string androidAppSignature, string iosAppId, string iosAppSignature, bool shouldRequestInterstitialsInFirstSession = true )
		{
#if UNITY_IOS
			ChartboostBinding.init( iosAppId, iosAppSignature, shouldRequestInterstitialsInFirstSession );
#elif UNITY_ANDROID
			ChartboostAndroid.init( androidAppId, androidAppSignature, shouldRequestInterstitialsInFirstSession );
#endif
		}


		// Caches an interstitial. Location is used for tracking in the Chartboost web portal.
		public static void cacheInterstitial( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.cacheInterstitial( location );
#elif UNITY_ANDROID
			ChartboostAndroid.cacheInterstitial( location );
#endif
		}


		// Checks to see if an interstitial is cached for the given location
		public static bool hasCachedInterstitial( string location = "None" )
		{
#if UNITY_IOS
			return ChartboostBinding.hasCachedInterstitial( location );
#elif UNITY_ANDROID
			return ChartboostAndroid.hasCachedInterstitial( location );
#else
			return false;
#endif
		}


		// Shows an interstitial. Location is used for tracking in the Chartboost web portal. If the interstitial was not first cached Chartboost
		// will first download it and then show it.
		public static void showInterstitial( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.showInterstitial( location );
#elif UNITY_ANDROID
			ChartboostAndroid.showInterstitial( location );
#endif
		}


		// Caches the more apps screen. Specifying location is currently on available via Chartboosts iOS SDK so it will
		// be ignored on Android.
		public static void cacheMoreApps( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.cacheMoreApps( location );
#elif UNITY_ANDROID
			ChartboostAndroid.cacheMoreApps( location );
#endif
		}


		// Caches the more apps screen. Specifying location is currently on available via Chartboosts iOS SDK so it will
		// be ignored on Android.
		public static bool hasCachedMoreApps( string location = "None" )
		{
#if UNITY_IOS
			return ChartboostBinding.hasCachedMoreApps( location );
#elif UNITY_ANDROID
			return ChartboostAndroid.hasCachedMoreApps( location );
#endif
		}


		// Shows the more apps screen
		public static void showMoreApps( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.showMoreApps( location );
#elif UNITY_ANDROID
			ChartboostAndroid.showMoreApps( location );
#endif
		}


		// Caches a rewarded video optionally for a specific location
		public static void cacheRewardedVideo( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.cacheRewardedVideo( location );
#elif UNITY_ANDROID
			ChartboostAndroid.cacheRewardedVideo( location );
#endif
		}


		// Checks to see if a rewarded video is cached for the given location
		public static bool hasCachedRewardedVideo( string location = "None" )
		{
#if UNITY_IOS
			return ChartboostBinding.hasCachedRewardedVideo( location );
#elif UNITY_ANDROID
			return ChartboostAndroid.hasCachedRewardedVideo( location );
#endif
		}


		// Shows a rewarded video
		public static void showRewardedVideo( string location = "None" )
		{
#if UNITY_IOS
			ChartboostBinding.showRewardedVideo( location );
#elif UNITY_ANDROID
			ChartboostAndroid.showRewardedVideo( location );
#endif
		}

	}

}
#endif
