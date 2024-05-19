using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class ChartboostUIManager : MonoBehaviourGUI
	{
#if UNITY_ANDROID
		void OnGUI()
		{
			beginColumn();
	
			if( GUILayout.Button( "Init" ) )
			{
				// Replace with your app ID and app signature!!!
				ChartboostAndroid.init( "4f7b433509b6025804000002", "dd2d41b69ac01b80f443f5b6cf06096d457f82bd" );
			}


			if( GUILayout.Button( "Cache Interstitial" ) )
			{
				ChartboostAndroid.cacheInterstitial( "ItemStore" );
			}
	
	
			if( GUILayout.Button( "Is Interstitial Cached?" ) )
			{
				Debug.Log( "is cached: " + ChartboostAndroid.hasCachedInterstitial( "ItemStore" ) );
			}
	
	
			if( GUILayout.Button( "Show Interstitial" ) )
			{
				ChartboostAndroid.showInterstitial( "ItemStore" );
			}
	
	
			if( GUILayout.Button( "Cache More Apps" ) )
			{
				ChartboostAndroid.cacheMoreApps( "Startup" );
			}
	
	
			if( GUILayout.Button( "Has Cached More Apps" ) )
			{
				Debug.Log( "has cached more apps: " + ChartboostAndroid.hasCachedMoreApps( "Startup" ) );
			}
	
	
			if( GUILayout.Button( "Show More Apps" ) )
			{
				ChartboostAndroid.showMoreApps( "Startup" );
			}
	
			endColumn( true );
	
	
			if( GUILayout.Button( "Cache Rewarded Video" ) )
			{
				ChartboostAndroid.cacheRewardedVideo( "VideoSpot" );
			}
	
	
			if( GUILayout.Button( "Has Cached Rewarded Video" ) )
			{
				Debug.Log( "has cached rewarded video: " + ChartboostAndroid.hasCachedRewardedVideo( "VideoSpot" ) );
			}
	
	
			if( GUILayout.Button( "Show Rewarded Video" ) )
			{
				ChartboostAndroid.showRewardedVideo( "VideoSpot" );
			}
	
			endColumn();
		}
#endif
	}

}
