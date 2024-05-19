using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class ChartboostComboUI : MonoBehaviourGUI
	{
#if UNITY_IOS || UNITY_ANDROID

		void OnGUI()
		{
			beginColumn();

			if( GUILayout.Button( "Init" ) )
			{
				// Replace with your app IDs and app signatures!!!
				Chartboost.init( "4f7b433509b6025804000002", "dd2d41b69ac01b80f443f5b6cf06096d457f82bd", "4eed78896d9619a066000096", "c885a2a0615a1c5acb6c6f207dea3a38972bf0ec" );
			}


			GUILayout.Space( 20 );
			if( GUILayout.Button( "Cache Interstitial" ) )
			{
				Chartboost.cacheInterstitial( "Startup" );
			}


			if( GUILayout.Button( "Has Cached Interstitial?" ) )
			{
				Debug.Log( "is cached: " + Chartboost.hasCachedInterstitial( "Startup" ) );
			}


			if( GUILayout.Button( "Show Interstitial" ) )
			{
				Chartboost.showInterstitial( "Startup" );
			}


			GUILayout.Space( 20 );
			if( GUILayout.Button( "Cache More Apps" ) )
			{
				Chartboost.cacheMoreApps( "MoApps" );
			}


			if( GUILayout.Button( "Has Cached More Apps?" ) )
			{
				Debug.Log( "has cached more apps: " + Chartboost.hasCachedMoreApps( "MoApps" ) );
			}


			if( GUILayout.Button( "Show More Apps" ) )
			{
				Chartboost.showMoreApps( "MoApps" );
			}

			endColumn( true );


			if( GUILayout.Button( "Cache Rewarded Video" ) )
			{
				Chartboost.cacheRewardedVideo( "VideoSpot" );
			}


			if( GUILayout.Button( "Has Cached Rewarded Video?" ) )
			{
				Debug.Log( "has cached rewarded video: " + Chartboost.hasCachedRewardedVideo( "VideoSpot" ) );
			}


			if( GUILayout.Button( "Show Rewarded Video" ) )
			{
				Chartboost.showRewardedVideo( "VideoSpot" );
			}

			endColumn();
		}



		#region Example of Subscribing to All Events

		void OnEnable()
		{
			Chartboost.didCacheInterstitialEvent += didCacheInterstitialEvent;
			Chartboost.didFailToCacheInterstitialEvent += didFailToCacheInterstitialEvent;
			Chartboost.didFinishInterstitialEvent += didFinishInterstitialEvent;

			Chartboost.didCacheMoreAppsEvent += didCacheMoreAppsEvent;
			Chartboost.didFailToCacheMoreAppsEvent += didFailToCacheMoreAppsEvent;
			Chartboost.didFinishMoreAppsEvent += didFinishMoreAppsEvent;

			Chartboost.didCacheRewardedVideoEvent += didCacheRewardedVideoEvent;
			Chartboost.didFailToLoadRewardedVideoEvent += didFailToLoadRewardedVideoEvent;
			Chartboost.didFinishRewardedVideoEvent += didFinishRewardedVideoEvent;
			Chartboost.didCompleteRewardedVideoEvent += didCompleteRewardedVideoEvent;
		}


		void OnDisable()
		{
			Chartboost.didCacheInterstitialEvent -= didCacheInterstitialEvent;
			Chartboost.didFailToCacheInterstitialEvent -= didFailToCacheInterstitialEvent;
			Chartboost.didFinishInterstitialEvent -= didFinishInterstitialEvent;

			Chartboost.didCacheMoreAppsEvent -= didCacheMoreAppsEvent;
			Chartboost.didFailToCacheMoreAppsEvent -= didFailToCacheMoreAppsEvent;
			Chartboost.didFinishMoreAppsEvent -= didFinishMoreAppsEvent;

			Chartboost.didCacheRewardedVideoEvent -= didCacheRewardedVideoEvent;
			Chartboost.didFailToLoadRewardedVideoEvent -= didFailToLoadRewardedVideoEvent;
			Chartboost.didFinishRewardedVideoEvent -= didFinishRewardedVideoEvent;
			Chartboost.didCompleteRewardedVideoEvent -= didCompleteRewardedVideoEvent;
		}


		void didCacheInterstitialEvent( string location )
		{
			Debug.Log( "didCacheInterstitialEvent: " + location );
		}


		void didFailToCacheInterstitialEvent( string location, string error )
		{
			Debug.Log( "didFailToCacheInterstitialEvent: " + location + ", error: " + error );
		}


		void didFinishInterstitialEvent( string location, string reason )
		{
			Debug.Log( "didFinishInterstitialEvent. Location: " + location + ", reason: " + reason );
		}


		void didCacheMoreAppsEvent( string location )
		{
			Debug.Log( "didCacheMoreAppsEvent: " + location );
		}


		void didFailToCacheMoreAppsEvent( string location, string error )
		{
			Debug.Log( "didFailToCacheMoreAppsEvent: " + location + ", error: " + error );
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

		#endregion

#endif
	}

}
