using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;



#if UNITY_ANDROID
namespace Prime31
{
	public enum FlurryAdPlacement
	{
		BannerBottom,
		BannerTop,
		FullScreen
	}


	public class FlurryAds
	{
		private static AndroidJavaObject _plugin;


		static FlurryAds()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			// find the plugin instance
			using( var pluginClass = new AndroidJavaClass( "com.prime31.ads.FlurryAds" ) )
				_plugin = pluginClass.CallStatic<AndroidJavaObject>( "instance" );
		}



		// Enables ads for your Flurry session optionally enabling test ads as well
		public static void enableAds( bool enableTestAds = false )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			_plugin.Call( "enableAds", enableTestAds );
		}


		// Fetches an ad for the given space
		public static void fetchAdsForSpace( string adSpace, FlurryAdPlacement adSize )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			_plugin.Call( "fetchAdsForSpace", adSpace, (int)adSize );
		}


		// Attempts to display an ad if available. Timeout is the maximum time in milliseconds that Flurry should take to load the ad
		public static void displayAd( string adSpace, FlurryAdPlacement adSize, long timeout )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			_plugin.Call( "displayAd", adSpace, (int)adSize, timeout );
		}


		// Removes the ad from view
		public static void removeAd( string adSpace )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			_plugin.Call( "removeAd", adSpace );
		}


		// Checks to see if an ad is available.
		public static void checkIfAdIsAvailable( string adSpace, FlurryAdPlacement adSize, long timeout )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;

			_plugin.Call( "isAdAvailable", adSpace, (int)adSize, timeout );
		}
	}
}
#endif
