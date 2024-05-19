using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;


#if UNITY_IOS

namespace Prime31
{
	public class ChartboostManager : AbstractManager
	{
		// Fired when an interstitial is cached. Includes the location.
		public static event Action<string> didCacheInterstitialEvent;
	
		// Fired when an interstitial fails to load. Includes the location and error.
		public static event Action<string,string> didFailToCacheInterstitialEvent;
	
		// Fired when an interstitial is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishInterstitialEvent;
	
	
	
		// Fired when the more apps screen is cached. Includes the location.
		public static event Action<string> didCacheMoreAppsEvent;
	
		// Fired when the more apps screen fails to load. Includes the location and error.
		public static event Action<string,string> didFailToCacheMoreAppsEvent;
	
		// Fired when the more apps screen is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishMoreAppsEvent;
	
	
	
		// Fired when a rewarded video is cached. Includes the location.
		public static event Action<string> didCacheRewardedVideoEvent;
	
		// Fired when a rewarded video fails to load. Includes the location and error.
		public static event Action<string,string> didFailToLoadRewardedVideoEvent;
	
		// Fired when a rewarded video is finished. Includes the location and the reason for completion (dismiss, close or click)
		public static event Action<string,string> didFinishRewardedVideoEvent;
	
		// Fired when a rewarded video is completed. Includes the reward amount.
		public static event Action<int> didCompleteRewardedVideoEvent;
	
	
	
		static ChartboostManager()
		{
			AbstractManager.initialize( typeof( ChartboostManager ) );
		}
	
	
	
		// Interstitials
		public void didCacheInterstitial( string location )
		{
			if( didCacheInterstitialEvent != null )
				didCacheInterstitialEvent( location );
		}
	
	
		public void didFailToLoadInterstitial( string json )
		{
			if( didFailToCacheInterstitialEvent != null )
			{
				var dict = Json.decode<Dictionary<string,string>>( json );
				didFailToCacheInterstitialEvent( dict["location"], dict["error"] );
			}
		}
	
	
		public void didDismissInterstitial( string location )
		{
			if( didFinishInterstitialEvent != null )
				didFinishInterstitialEvent( location, "dismiss" );
		}
	
	
		public void didClickInterstitial( string location )
		{
			if( didFinishInterstitialEvent != null )
				didFinishInterstitialEvent( location, "click" );
		}
	
	
		public void didCloseInterstitial( string location )
		{
			if( didFinishInterstitialEvent != null )
				didFinishInterstitialEvent( location, "close" );
		}
	
	
		// More apps
		public void didCacheMoreApps( string location )
		{
			if( didCacheMoreAppsEvent != null )
				didCacheMoreAppsEvent( location );
		}
	
	
		public void didFailToLoadMoreApps( string json )
		{
			if( didFailToCacheMoreAppsEvent != null )
			{
				var dict = Json.decode<Dictionary<string,string>>( json );
				didFailToCacheMoreAppsEvent( dict["location"], dict["error"] );
			}
		}
	
	
		public void didDismissMoreApps( string location )
		{
			if( didFinishMoreAppsEvent != null )
				didFinishMoreAppsEvent( location, "dismiss" );
		}
	
	
		public void didCloseMoreApps( string location )
		{
			if( didFinishMoreAppsEvent != null )
				didFinishMoreAppsEvent( location, "close" );
		}
	
	
		public void didClickMoreApps( string location )
		{
			if( didFinishMoreAppsEvent != null )
				didFinishMoreAppsEvent( location, "click" );
		}
	
	
		// Rewarded Video
		public void didCacheRewardedVideo( string location )
		{
			if( didCacheRewardedVideoEvent != null )
				didCacheRewardedVideoEvent( location );
		}
	
	
		public void didFailToLoadRewardedVideo( string json )
		{
			if( didFailToLoadRewardedVideoEvent != null )
			{
				var dict = Json.decode<Dictionary<string,string>>( json );
				didFailToLoadRewardedVideoEvent( dict["location"], dict["error"] );
			}
		}
	
	
		public void didDismissRewardedVideo( string location )
		{
			if( didFinishRewardedVideoEvent != null )
				didFinishRewardedVideoEvent( location, "dismiss" );
		}
	
	
		public void didCloseRewardedVideo( string location )
		{
			if( didFinishRewardedVideoEvent != null )
				didFinishRewardedVideoEvent( location, "close" );
		}
	
	
		public void didClickRewardedVideo( string location )
		{
			if( didFinishRewardedVideoEvent != null )
				didFinishRewardedVideoEvent( location, "click" );
		}
	
	
		public void didCompleteRewardedVideo( string reward )
		{
			if( didCompleteRewardedVideoEvent != null )
				didCompleteRewardedVideoEvent( int.Parse( reward ) );
		}
	
	}

}
#endif
