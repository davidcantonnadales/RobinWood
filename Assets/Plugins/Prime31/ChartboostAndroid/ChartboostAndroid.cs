using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;


#if UNITY_ANDROID

namespace Prime31
{
	public class ChartboostAndroid
	{
		private static AndroidJavaObject _plugin;
	
	
		static ChartboostAndroid()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			// find the plugin instance
			using( var pluginClass = new AndroidJavaClass( "com.prime31.ChartboostPlugin" ) )
				_plugin = pluginClass.CallStatic<AndroidJavaObject>( "instance" );
		}

	
		// Starts up Chartboost and records an app install
		public static void init( string appId, string appSignature, bool shouldRequestInterstitialsInFirstSession = true )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "init", appId, appSignature, shouldRequestInterstitialsInFirstSession );
		}
	
	
		// Caches an interstitial. Location is used for tracking in the Chartboost web portal.
		public static void cacheInterstitial( string location )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "cacheInterstitial", location );
		}
	
	
		// Checks to see if an interstitial is cached for the given location
		public static bool hasCachedInterstitial( string location )
		{
			if( Application.platform != RuntimePlatform.Android )
				return false;
	
			return _plugin.Call<bool>( "hasCachedInterstitial", location );
		}
	
	
		// Shows an interstitial. Location is used for tracking in the Chartboost web portal. If the interstitial was not first cached Chartboost
		// will download it and then show it.
		public static void showInterstitial( string location )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "showInterstitial", location );
		}
	
	
		// Caches the more apps screen
		public static void cacheMoreApps( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "cacheMoreApps", location );
		}
	
	
		// Checks to see if the more apps screen is cached
		public static bool hasCachedMoreApps( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return false;
	
			return _plugin.Call<bool>( "hasCachedMoreApps", location );
		}
	
	
		// Shows the more apps screen
		public static void showMoreApps( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "showMoreApps", location );
		}
	
	
	
		// Caches a rewarded video optionally for a specific location
		public static void cacheRewardedVideo( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "cacheRewardedVideo", location );
		}
	
	
		// Checks to see if a rewarded video is cached for the given location
		public static bool hasCachedRewardedVideo( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return false;
	
			return _plugin.Call<bool>( "hasCachedRewardedVideo", location );
		}
	
	
		// Shows a rewarded video
		public static void showRewardedVideo( string location = "None" )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_plugin.Call( "showRewardedVideo", location );
		}
	
	}

}
#endif
