using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class FlurryUIManager : MonoBehaviourGUI
	{
#if UNITY_ANDROID

		void OnGUI()
		{
			beginColumn();

			if( GUILayout.Button( "Start Flurry Session" ) )
			{
				// replace with your Flurry app ID!!!
				FlurryAnalytics.startSession( "RPQYDGBDSQ7Z3DPM7XVU", true );
			}


			if( GUILayout.Button( "Log Timed Event" ) )
			{
				FlurryAnalytics.logEvent( "timed", true );
			}


			if( GUILayout.Button( "End Timed Event" ) )
			{
				FlurryAnalytics.endTimedEvent( "timed" );
			}


			if( GUILayout.Button( "Log Event" ) )
			{
				FlurryAnalytics.logEvent( "myFancyEvent" );
			}


			if( GUILayout.Button( "Log Event with Params" ) )
			{
				var dict = new Dictionary<string,string>();
				dict.Add( "akey1", "value1" );
				dict.Add( "bkey2", "value2" );
				dict.Add( "ckey3", "value3" );
				dict.Add( "dkey4", "value4" );

				FlurryAnalytics.logEvent( "EventWithParams", dict );
			}


			if( GUILayout.Button( "Log Page View" ) )
			{
				FlurryAnalytics.onPageView();
			}


			if( GUILayout.Button( "Log Error" ) )
			{
				FlurryAnalytics.onError( "666", "bad things happend", "Exception" );
			}


			endColumn( true );


			if( GUILayout.Button( "Enable Ads" ) )
			{
				FlurryAds.enableAds( true );
			}


			if( GUILayout.Button( "Fetch Ads" ) )
			{
				FlurryAds.fetchAdsForSpace( "space", FlurryAdPlacement.BannerBottom );
				FlurryAds.fetchAdsForSpace( "bigAd", FlurryAdPlacement.FullScreen );
			}


			if( GUILayout.Button( "Display Ad" ) )
			{
				FlurryAds.displayAd( "space", FlurryAdPlacement.BannerBottom, 1000 );
			}


			if( GUILayout.Button( "Display bigAd Ad" ) )
			{
				FlurryAds.displayAd( "bigAd", FlurryAdPlacement.FullScreen, 1000 );
			}


			if( GUILayout.Button( "Remove Ad" ) )
			{
				FlurryAds.removeAd( "space" );
			}


			endColumn();
		}
#endif
	}

}
