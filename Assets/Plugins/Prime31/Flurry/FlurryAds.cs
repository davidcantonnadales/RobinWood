using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Prime31;




#if UNITY_IOS
public enum FlurryAdSize
{
	Top = 1,
	Bottom = 2,
	Fullscreen = 3
}



namespace Prime31
{
	public class FlurryAds
	{
		[DllImport("__Internal")]
		private static extern void _flurryAdsInitialize( bool enableTestAds );
	
		// Initializes the Flurry ad system optionally with test ads
		public static void enableAds( bool enableTestAds )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsInitialize( enableTestAds );
		}
	
	
		[DllImport("__Internal")]
		private static extern void _flurryAdsSetUserCookies( string cookies );
	
		// Sets user cookies for the ad session
		public static void adsSetUserCookies( Dictionary<string,string> cookies )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsSetUserCookies( cookies.toJson() );
		}
	
	
		[DllImport("__Internal")]
		private static extern void _flurryAdsClearUserCookies();
	
		// Clears the user cookies
		public static void adsClearUserCookies()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsClearUserCookies();
		}
	
	
		[DllImport("__Internal")]
		private static extern void _flurryAdsSetKeywords( string keywords );
	
		// Sets keywords for the ad session
		public static void adsSetKeywords( string keywords )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsSetKeywords( keywords );
		}
	
	
		[DllImport("__Internal")]
		private static extern void _flurryAdsClearKeywords();
	
		// Clears keywords
		public static void adsClearKeywords()
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsClearKeywords();
		}
	
	
		[DllImport("__Internal")]
		private static extern bool _flurryAdsFetchAdForSpace( string space, int adSize );
	
		// Fetches an ad
		public static void fetchAdForSpace( string space, FlurryAdSize adSize )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsFetchAdForSpace( space, (int)adSize );
		}
	
	
		[DllImport("__Internal")]
		private static extern bool _flurryAdsIsAdAvailableForSpace( string space, int adSize );
	
		// Checks to see if an ad is available
		public static bool isAdAvailableForSpace( string space, FlurryAdSize adSize )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				return _flurryAdsIsAdAvailableForSpace( space, (int)adSize );
			return false;
		}
	
	
		[DllImport("__Internal")]
		private static extern bool _flurryAdsFetchAndDisplayAdForSpace( string space, int adSize );
	
		// Fetches then shows an ad
		public static void fetchAndDisplayAdForSpace( string space, FlurryAdSize adSize )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsFetchAndDisplayAdForSpace( space, (int)adSize );
		}
	
	
		[DllImport("__Internal")]
		private static extern bool _flurryAdsDisplayAdForSpace( string space, int adSize );
	
		// Shows an ad
		public static void displayAdForSpace( string space, FlurryAdSize adSize )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsDisplayAdForSpace( space, (int)adSize );
		}
	
	
		[DllImport("__Internal")]
		private static extern void _flurryAdsRemoveAdFromSpace( string space );
	
		// Removes an ad
		public static void removeAdFromSpace( string space )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryAdsRemoveAdFromSpace( space );
		}
	}

}
#endif
