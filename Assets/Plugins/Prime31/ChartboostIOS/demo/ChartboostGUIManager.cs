using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class ChartboostGUIManager : MonoBehaviourGUI
	{
#if UNITY_IOS
		void OnGUI()
		{
			beginColumn();


			if( GUILayout.Button( "Init" ) )
			{
				// Replace with your app ID and app signature!!!
				ChartboostBinding.init( "4eed78896d9619a066000096", "c885a2a0615a1c5acb6c6f207dea3a38972bf0ec" );
			}


			GUILayout.Space( 20 );
			if( GUILayout.Button( "Cache Interstitial" ) )
			{
				ChartboostBinding.cacheInterstitial( "Startup" );
			}


			if( GUILayout.Button( "Has Cached Interstitial?" ) )
			{
				Debug.Log( "is interstitial cached: " + ChartboostBinding.hasCachedInterstitial( "Startup" ) );
			}


			if( GUILayout.Button( "Show Interstitial" ) )
			{
				ChartboostBinding.showInterstitial( "Startup" );
			}

			GUILayout.Space( 20 );

			if( GUILayout.Button( "Cache More Apps" ) )
			{
				ChartboostBinding.cacheMoreApps( "Intermission" );
			}


			if( GUILayout.Button( "Has Cached More Apps?" ) )
			{
				Debug.Log( "is more apps view cached: " + ChartboostBinding.hasCachedMoreApps( "Intermission" ) );
			}


			if( GUILayout.Button( "Show More Apps" ) )
			{
				ChartboostBinding.showMoreApps( "Intermission" );
			}

			endColumn( true );


			if( GUILayout.Button( "Cache Rewarded Video" ) )
			{
				ChartboostBinding.cacheRewardedVideo( "VideoSpot" );
			}


			if( GUILayout.Button( "Has Cached Rewarded Video?" ) )
			{
				Debug.Log( "has cached rewarded video: " + ChartboostBinding.hasCachedRewardedVideo( "VideoSpot" ) );
			}


			if( GUILayout.Button( "Show Rewarded Video" ) )
			{
				ChartboostBinding.showRewardedVideo( "VideoSpot" );
			}


			endColumn();
		}
#endif
	}

}
