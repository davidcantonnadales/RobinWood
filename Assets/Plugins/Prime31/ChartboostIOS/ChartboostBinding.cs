using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Prime31;



#if UNITY_IOS


namespace Prime31
{
	public class ChartboostBinding
	{
		[DllImport("__Internal")]
		private static extern void _chartboostInit( string appId, string appSignature, bool shouldRequestInterstitialsInFirstSession );

		// Starts up Chartboost and records an app install
		public static void init( string appId, string appSignature, bool shouldRequestInterstitialsInFirstSession = true )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostInit( appId, appSignature, shouldRequestInterstitialsInFirstSession );
		}


		[DllImport("__Internal")]
		private static extern void _chartboostCacheInterstitial( string location );

		// Caches an interstitial. Location is used for tracking in the Chartboost web portal.
		public static void cacheInterstitial( string location )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostCacheInterstitial( location );
		}


		[DllImport("__Internal")]
		private static extern bool _chartboostHasCachedInterstitial( string location );

		// Checks to see if an interstitial is cached for the given location
		public static bool hasCachedInterstitial( string location )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				return _chartboostHasCachedInterstitial( location );

			return false;
		}


		[DllImport("__Internal")]
		private static extern void _chartboostShowInterstitial( string location );

		// Shows an interstitial. Location is used for tracking in the Chartboost web portal. If the interstitial was not first cached Chartboost
		// will first download it and then show it.
		public static void showInterstitial( string location )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostShowInterstitial( location );
		}


		[DllImport("__Internal")]
		private static extern void _chartboostCacheMoreApps( string location );

		// Caches the more apps screen optionally for a specific location
		public static void cacheMoreApps( string location = "None" )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostCacheMoreApps( location );
		}


		[DllImport("__Internal")]
		private static extern bool _chartboostHasCachedMoreApps( string location );

		// Checks to see if the more apps view is cached for the given location
		public static bool hasCachedMoreApps( string location )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				return _chartboostHasCachedMoreApps( location );

			return false;
		}


		[DllImport("__Internal")]
		private static extern void _chartboostShowMoreApps( string location );

		// Shows the more apps screen
		public static void showMoreApps( string location = "None" )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostShowMoreApps( location );
		}


		[DllImport("__Internal")]
		private static extern void _chartboostCacheRewardedVideo( string location );

		// Caches a rewarded video optionally for a specific location
		public static void cacheRewardedVideo( string location = "None" )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostCacheRewardedVideo( location );
		}


		[DllImport("__Internal")]
		private static extern bool _chartboostHasCachedRewardedVideo( string location );

		// Checks to see if a rewarded video is cached for the given location
		public static bool hasCachedRewardedVideo( string location = "None" )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				return _chartboostHasCachedRewardedVideo( location );

			return false;
		}


		[DllImport("__Internal")]
		private static extern void _chartboostShowRewardedVideo( string location );

		// Shows a rewarded video
		public static void showRewardedVideo( string location = "None" )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_chartboostShowRewardedVideo( location );
		}

	}
}
#endif
