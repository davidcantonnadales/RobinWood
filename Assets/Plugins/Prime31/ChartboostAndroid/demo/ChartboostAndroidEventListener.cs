using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



namespace Prime31
{
	public class ChartboostAndroidEventListener : MonoBehaviour
	{
#if UNITY_ANDROID
	
		void OnEnable()
		{
			// Listen to all events for illustration purposes
			ChartboostAndroidManager.didCacheInterstitialEvent += didCacheInterstitialEvent;
			ChartboostAndroidManager.didFailToCacheInterstitialEvent += didFailToLoadInterstitialEvent;
			ChartboostAndroidManager.didFinishInterstitialEvent += didFinishInterstitialEvent;
	
			ChartboostAndroidManager.didCacheMoreAppsEvent += didCacheMoreAppsEvent;
			ChartboostAndroidManager.didFailToCacheMoreAppsEvent += didFailToLoadMoreAppsEvent;
			ChartboostAndroidManager.didFinishMoreAppsEvent += didFinishMoreAppsEvent;
	
			ChartboostAndroidManager.didCacheRewardedVideoEvent += didCacheRewardedVideoEvent;
			ChartboostAndroidManager.didFailToLoadRewardedVideoEvent += didFailToLoadRewardedVideoEvent;
			ChartboostAndroidManager.didFinishRewardedVideoEvent += didFinishRewardedVideoEvent;
			ChartboostAndroidManager.didCompleteRewardedVideoEvent += didCompleteRewardedVideoEvent;
	
			ChartboostAndroidManager.didFailToLoadUrlEvent += didFailToLoadUrlEvent;
		}
	
	
		void OnDisable()
		{
			// Remove all event handlers
			ChartboostAndroidManager.didCacheInterstitialEvent -= didCacheInterstitialEvent;
			ChartboostAndroidManager.didFailToCacheInterstitialEvent -= didFailToLoadInterstitialEvent;
			ChartboostAndroidManager.didFinishInterstitialEvent -= didFinishInterstitialEvent;
	
			ChartboostAndroidManager.didCacheMoreAppsEvent -= didCacheMoreAppsEvent;
			ChartboostAndroidManager.didFailToCacheMoreAppsEvent -= didFailToLoadMoreAppsEvent;
			ChartboostAndroidManager.didFinishMoreAppsEvent -= didFinishMoreAppsEvent;
	
			ChartboostAndroidManager.didCacheRewardedVideoEvent -= didCacheRewardedVideoEvent;
			ChartboostAndroidManager.didFailToLoadRewardedVideoEvent -= didFailToLoadRewardedVideoEvent;
			ChartboostAndroidManager.didFinishRewardedVideoEvent -= didFinishRewardedVideoEvent;
			ChartboostAndroidManager.didCompleteRewardedVideoEvent -= didCompleteRewardedVideoEvent;
	
			ChartboostAndroidManager.didFailToLoadUrlEvent -= didFailToLoadUrlEvent;
		}
	
	
	
		void didCacheInterstitialEvent( string location )
		{
			Debug.Log( "didCacheInterstitialEvent: " + location );
		}
	
	
		void didFailToLoadInterstitialEvent( string location, string error )
		{
			Debug.Log( "didFailToLoadInterstitialEvent: " + location + ", error: " + error );
		}
	
	
		void didFinishInterstitialEvent( string location, string reason )
		{
			Debug.Log( "didFinishInterstitialEvent. Location: " + location + ", reason: " + reason );
		}
	
	
	
		void didCacheMoreAppsEvent( string location )
		{
			Debug.Log( "didCacheMoreAppsEvent: " + location );
		}
	
	
		void didFailToLoadMoreAppsEvent( string location, string error )
		{
			Debug.Log( "didFailToLoadMoreAppsEvent: " + location + ", error: " + error );
		}
	
	
		void didFinishMoreAppsEvent( string location, string reason )
		{
			Debug.Log( "didFinishMoreAppsEvent. Location: " + location + ", reason: " + reason );
		}
	
	
	
		void didCacheRewardedVideoEvent( string location )
		{
			Debug.Log( "didCacheRewardedVideoEvent: " + location );
		}
	
	
		void didFailToLoadRewardedVideoEvent( string location, string error )
		{
			Debug.Log( "didFailToLoadRewardedVideoEvent: " + location + ", error: " + error );
		}
	
	
		void didFinishRewardedVideoEvent( string location, string reason )
		{
			Debug.Log( "didFinishRewardedVideoEvent. Location: " + location + ", reason: " + reason );
		}
	
	
		void didCompleteRewardedVideoEvent( int reward )
		{
			Debug.Log( "didCompleteRewardedVideoEvent. Reward: " + reward );
		}
	
	
		void didFailToLoadUrlEvent( string url )
		{
			Debug.Log( "didFailToLoadUrlEvent: " + url );
		}
	
#endif
	}

}
	
	
