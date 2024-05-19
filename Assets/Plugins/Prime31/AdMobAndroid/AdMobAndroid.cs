using UnityEngine;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID

public enum AdMobAdPlacement
{
	TopLeft,
	TopCenter,
	TopRight,
	Centered,
	BottomLeft,
	BottomCenter,
	BottomRight
}

public enum AdMobAndroidAd
{
	phone320x50,
	tablet300x250,
	tablet468x60,
	tablet728x90,
	smartBanner
}



namespace Prime31
{
	public class AdMobAndroid
	{
		private static AndroidJavaObject _admobPlugin;
	
	
		static AdMobAndroid()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			// find the plugin instance
			using( var pluginClass = new AndroidJavaClass( "com.prime31.AdMobPlugin" ) )
				_admobPlugin = pluginClass.CallStatic<AndroidJavaObject>( "instance" );
		}
	
	
		// Passing true will set a flag that indicates that your content should be treated as child-directed for purposes of COPPA
		public static void setTagForChildDirectedTreatment( bool shouldTag )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "setTagForChildDirectedTreatment", shouldTag );
		}
	
	
		// Sets test devices. This needs to be set BEFORE a banner is created. Watch the logcat logs to see your device ID while testing.
		public static void setTestDevices( string[] testDevices )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			var method = AndroidJNI.GetMethodID( _admobPlugin.GetRawClass(), "setTestDevices", "([Ljava/lang/String;)V" );
			AndroidJNI.CallVoidMethod( _admobPlugin.GetRawObject(), method, AndroidJNIHelper.CreateJNIArgArray( new object[] { testDevices } ) );
		}
	
	
		// Creates a banner of the given type at the given position. This method requires an adUnitId and you must be updated to the new AdMob system.
		public static void createBanner( string adUnitId, AdMobAndroidAd type, AdMobAdPlacement placement )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			createBanner( adUnitId, (int)type, (int)placement );
		}
	
	
		// Creates a banner of the given type at the given position. This method requires an adUnitId and you must be updated to the new AdMob system.
		public static void createBanner( string adUnitId, int type, int placement )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "createBanner", adUnitId, type, placement );
		}
	
	
	
		// Destroys the banner if it is showing
		public static void destroyBanner()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "destroyBanner" );
		}
	
	
		// Hides/shows the ad banner
		public static void hideBanner( bool shouldHide )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "hideBanner", shouldHide );
		}
	
	
		// Refreshes the banner with a new ad request
		public static void refreshAd()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "refreshAd" );
		}
	
	
		// Gets the height of the current ad view
		public static float getAdViewHeight()
		{
			if( Application.platform != RuntimePlatform.Android )
				return 0;
	
			return _admobPlugin.Call<float>( "getAdViewHeight" );
		}
	
	
		// Requests an interstitial ad.  When it is loaded, the the interstitialReceivedAdEvent will be fired
		public static void requestInterstitial( string interstitialUnitId )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "requestInterstital", interstitialUnitId );
		}
	
	
		// Check to see if an interstitial ad is ready to be displayed
		public static bool isInterstitialReady()
		{
			if( Application.platform != RuntimePlatform.Android )
				return false;
	
			return _admobPlugin.Call<bool>( "isInterstitalReady" );
		}
	
	
		// Displays an interstitial if it is ready to be displayed
		public static void displayInterstitial()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "displayInterstital" );
		}


		// Starts loading a reward based ad
		public static void requestRewardBasedAd( string adUnitId )
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "requestRewardBasedAd", adUnitId );
		}


		// If a reward based ad is loaded this will take over the screen and show the ad
		public static void showRewardBasedAd()
		{
			if( Application.platform != RuntimePlatform.Android )
				return;
	
			_admobPlugin.Call( "displayRewardBasedAd" );
		}
	
	}

}
#endif
