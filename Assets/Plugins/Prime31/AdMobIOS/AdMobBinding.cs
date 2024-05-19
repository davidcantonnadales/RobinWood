using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


#if UNITY_IOS

public enum AdMobBannerType
{
	iPhone_320x50,
	iPad_728x90,
	iPad_468x60,
	iPad_320x250,
	SmartBannerPortrait,
	SmartBannerLandscape
}

public enum AdMobAdPosition
{
	TopLeft,
	TopCenter,
	TopRight,
	Centered,
	BottomLeft,
	BottomCenter,
	BottomRight
}




namespace Prime31
{
	public class AdMobBinding
	{
		[DllImport("__Internal")]
		private static extern void _adMobTagForChildDirectedTreatment( bool tagForChildDirectedTreatment );

		// Passing true will set a flag that indicates that your content should be treated as child-directed for purposes of COPPA
		public static void setTagForChildDirectedTreatment( bool shouldTag )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobTagForChildDirectedTreatment( shouldTag );
		}


		[DllImport("__Internal")]
		private static extern void _adMobSetTestDevice( string deviceId );

		// Adds a test device
		public static void setTestDevices( string[] deviceIds )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
			{
				foreach( var deviceId in deviceIds )
					_adMobSetTestDevice( deviceId );
			}
		}


		[DllImport("__Internal")]
		private static extern void _adMobCreateBanner( string adUnitId, int bannerType, int position );

		// Creates a banner of the given type at the given position
		public static void createBanner( string adUnitId, AdMobBannerType bannerType, AdMobAdPosition position )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobCreateBanner( adUnitId, (int)bannerType, (int)position );
		}


		[DllImport("__Internal")]
		private static extern void _adMobCreateCustomSizedBanner( string adUnitId, int width, int height, int bannerPosition );

		// Creates a custom sized banner at the given position
		public static void createBanner( string adUnitId, int width, int height, AdMobAdPosition position )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobCreateCustomSizedBanner( adUnitId, width, height, (int)position );
		}


		[DllImport("__Internal")]
		private static extern void _adMobDestroyBanner();

		// Destroys the banner and removes it from view
		public static void destroyBanner()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobDestroyBanner();
		}


		[DllImport("__Internal")]
		private static extern void _adMobHideBanner( bool shouldHide );

		// Hides/shows the ad banner
		public static void hideBanner( bool shouldHide )
		{
			if( Application.platform != RuntimePlatform.IPhonePlayer )
				return;

			_adMobHideBanner( shouldHide );
		}


		[DllImport("__Internal")]
		private static extern void _adMobRequestInterstitialAd( string interstitialUnitId );

		// Starts loading an interstitial ad
		public static void requestInterstitial( string interstitialUnitId )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobRequestInterstitialAd( interstitialUnitId );
		}


		[DllImport("__Internal")]
		private static extern bool _adMobIsInterstitialAdReady();

		// Checks to see if the interstitial ad is loaded and ready to show
		public static bool isInterstitialAdReady()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				return _adMobIsInterstitialAdReady();

			return false;
		}


		[DllImport("__Internal")]
		private static extern void _adMobShowInterstitialAd();

		// If an interstitial ad is loaded this will take over the screen and show the ad
		public static void displayInterstitial()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobShowInterstitialAd();
		}


		[DllImport("__Internal")]
		private static extern void _adMobRequestRewardBasedAd( string interstitialUnitId );

		// Starts loading an interstitial ad
		public static void requestRewardBasedAd( string adUnitId )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobRequestRewardBasedAd( adUnitId );
		}


		[DllImport("__Internal")]
		private static extern void _adMobShowRewardBasedAd();

		// If a reward based ad is loaded this will take over the screen and show the ad
		public static void showRewardBasedAd()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_adMobShowRewardBasedAd();
		}

	}

}
#endif
